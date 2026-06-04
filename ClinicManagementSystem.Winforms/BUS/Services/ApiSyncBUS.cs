using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class ApiSyncBUS
    {
        private readonly ApiSyncRepository repository = new ApiSyncRepository();

        public async Task<ApiSyncResultDTO> SyncAsync()
        {
            var result = new ApiSyncResultDTO();

            var supabasePatientsRaw = await repository.GetSupabasePatientsAsync();
            var supabaseEmployeesRaw = await repository.GetSupabaseEmployeesAsync();
            var sheetPatientsRaw = await repository.GetSheetPatientsAsync();
            var sheetEmployeesRaw = await repository.GetSheetEmployeesAsync();

            var supabasePatients = supabasePatientsRaw
                .Where(p => !string.IsNullOrWhiteSpace(p.PatientCode))
                .Where(p => !string.IsNullOrWhiteSpace(p.FullName))
                .ToList();

            var supabaseEmployees = supabaseEmployeesRaw
                .Where(e => !string.IsNullOrWhiteSpace(e.SyncCode))
                .Where(e => !string.IsNullOrWhiteSpace(e.FullName))
                .ToList();

            var sheetPatients = sheetPatientsRaw
                .Where(p => !string.IsNullOrWhiteSpace(p.PatientCode))
                .Where(p => !string.IsNullOrWhiteSpace(p.FullName))
                .ToList();

            var sheetEmployees = sheetEmployeesRaw
                .Where(e => !string.IsNullOrWhiteSpace(e.SyncCode))
                .Where(e => !string.IsNullOrWhiteSpace(e.FullName))
                .ToList();

            result.SkippedPatientRows = sheetPatientsRaw.Count - sheetPatients.Count;
            result.SkippedEmployeeRows = sheetEmployeesRaw.Count - sheetEmployees.Count;

            await LinkMissingSheetPatientUuidsFromSupabaseAsync(sheetPatients, supabasePatients, result);
            await LinkMissingSheetEmployeeUuidsFromSupabaseAsync(sheetEmployees, supabaseEmployees, result);

            await SyncPatientsToLocalSqlServerAsync(sheetPatients, result, patchSheetWhenMissingUuid: true);
            await SyncEmployeesToLocalSqlServerAsync(sheetEmployees, result, patchSheetWhenMissingUuid: true);
            await SyncPatientsToLocalSqlServerAsync(supabasePatients, result, patchSheetWhenMissingUuid: false);
            await SyncEmployeesToLocalSqlServerAsync(supabaseEmployees, result, patchSheetWhenMissingUuid: false);

            await SyncPatientsSheetToSupabaseAsync(sheetPatients, supabasePatients, result);
            await SyncEmployeesSheetToSupabaseAsync(sheetEmployees, supabaseEmployees, result);
            await SyncPatientsSupabaseToSheetAsync(supabasePatients, sheetPatients, result);
            await SyncEmployeesSupabaseToSheetAsync(supabaseEmployees, sheetEmployees, result);

            result.MergedPatients = supabasePatients
                .Concat(sheetPatients)
                .Where(p => !string.IsNullOrWhiteSpace(p.PatientCode))
                .Where(p => !string.IsNullOrWhiteSpace(p.FullName))
                .GroupBy(p => p.SyncUuid.HasValue ? "UUID:" + p.SyncUuid.Value : "CODE:" + NormalizeCode(p.PatientCode))
                .Select(g => g.First())
                .OrderBy(p => p.PatientCode)
                .ToList();

            return result;
        }

        private async Task LinkMissingSheetPatientUuidsFromSupabaseAsync(List<ApiPatientDTO> sheetPatients, List<ApiPatientDTO> supabasePatients, ApiSyncResultDTO result)
        {
            foreach (var patient in sheetPatients.Where(p => !p.SyncUuid.HasValue))
            {
                var existingByCode = supabasePatients.FirstOrDefault(x => x.SyncUuid.HasValue && NormalizeCode(x.PatientCode) == NormalizeCode(patient.PatientCode));
                if (existingByCode == null) continue;

                patient.SyncUuid = existingByCode.SyncUuid;
                await repository.PatchPatientSheetUuidAsync(patient.PatientCode, existingByCode.SyncUuid.Value);
                result.PatchedPatientUuidToSheet++;
                result.LinkedExistingPatientByCode++;
            }
        }

        private async Task LinkMissingSheetEmployeeUuidsFromSupabaseAsync(List<ApiEmployeeDTO> sheetEmployees, List<ApiEmployeeDTO> supabaseEmployees, ApiSyncResultDTO result)
        {
            foreach (var employee in sheetEmployees.Where(e => !e.SyncUuid.HasValue))
            {
                if (string.IsNullOrWhiteSpace(employee.SyncCode)) continue;

                var existingByCode = supabaseEmployees.FirstOrDefault(x =>
                    x.SyncUuid.HasValue &&
                    NormalizeCode(x.SyncCode) == NormalizeCode(employee.SyncCode));
                if (existingByCode == null) continue;

                employee.SyncUuid = existingByCode.SyncUuid;
                await repository.PatchEmployeeSheetUuidAsync(employee.SyncCode, existingByCode.SyncUuid.Value);
                result.PatchedEmployeeUuidToSheet++;
                result.LinkedExistingEmployeeByCode++;
            }
        }

        private async Task SyncPatientsToLocalSqlServerAsync(List<ApiPatientDTO> patients, ApiSyncResultDTO result, bool patchSheetWhenMissingUuid)
        {
            foreach (var patient in patients)
            {
                bool missingExternalUuid = !patient.SyncUuid.HasValue;
                var local = await repository.UpsertLocalPatientAsync(patient);
                patient.SyncUuid = local.Uuid;

                if (local.Inserted)
                {
                    result.InsertedPatientsToLocal++;
                }

                if (local.Generated)
                {
                    result.GeneratedPatientUuidInLocal++;
                }

                if (patchSheetWhenMissingUuid && missingExternalUuid)
                {
                    await repository.PatchPatientSheetUuidAsync(patient.PatientCode, local.Uuid);
                    result.PatchedPatientUuidToSheet++;
                }
            }
        }

        private async Task SyncEmployeesToLocalSqlServerAsync(List<ApiEmployeeDTO> employees, ApiSyncResultDTO result, bool patchSheetWhenMissingUuid)
        {
            foreach (var employee in employees)
            {
                bool missingExternalUuid = !employee.SyncUuid.HasValue;
                var local = await repository.UpsertLocalEmployeeAsync(employee);
                employee.SyncUuid = local.Uuid;

                if (local.Inserted)
                {
                    result.InsertedEmployeesToLocal++;
                }

                if (local.Generated)
                {
                    result.GeneratedEmployeeUuidInLocal++;
                }

                if (patchSheetWhenMissingUuid && missingExternalUuid)
                {
                    await repository.PatchEmployeeSheetUuidAsync(employee.SyncCode, local.Uuid);
                    result.PatchedEmployeeUuidToSheet++;
                }
            }
        }

        private async Task SyncPatientsSheetToSupabaseAsync(List<ApiPatientDTO> sheetPatients, List<ApiPatientDTO> supabasePatients, ApiSyncResultDTO result)
        {
            foreach (var patient in sheetPatients)
            {
                ApiPatientDTO existingByUuid = null;
                if (patient.SyncUuid.HasValue)
                {
                    existingByUuid = supabasePatients.FirstOrDefault(x => x.SyncUuid == patient.SyncUuid);
                }

                var existingByCode = supabasePatients.FirstOrDefault(x => NormalizeCode(x.PatientCode) == NormalizeCode(patient.PatientCode));

                if (existingByUuid != null)
                {
                    continue;
                }

                if (existingByCode != null)
                {
                    if (patient.SyncUuid.HasValue && !existingByCode.SyncUuid.HasValue)
                    {
                        await repository.PatchSupabasePatientUuidByCodeAsync(patient.PatientCode, patient.SyncUuid.Value);
                        existingByCode.SyncUuid = patient.SyncUuid;
                        result.PatchedPatientUuidToSupabase++;
                    }
                    else if (!patient.SyncUuid.HasValue && existingByCode.SyncUuid.HasValue)
                    {
                        await repository.PatchPatientSheetUuidAsync(patient.PatientCode, existingByCode.SyncUuid.Value);
                        patient.SyncUuid = existingByCode.SyncUuid;
                        result.PatchedPatientUuidToSheet++;
                        result.LinkedExistingPatientByCode++;
                    }
                    continue;
                }

                var inserted = await repository.InsertSupabasePatientAsync(BuildPatientPayload(patient, includeUuid: patient.SyncUuid.HasValue));
                if (inserted != null)
                {
                    result.InsertedPatientsToSupabase++;
                    if (!patient.SyncUuid.HasValue && inserted.SyncUuid.HasValue)
                    {
                        await repository.PatchPatientSheetUuidAsync(patient.PatientCode, inserted.SyncUuid.Value);
                        patient.SyncUuid = inserted.SyncUuid;
                        result.PatchedPatientUuidToSheet++;
                    }
                    supabasePatients.Add(inserted);
                }
            }
        }

        private async Task SyncEmployeesSheetToSupabaseAsync(List<ApiEmployeeDTO> sheetEmployees, List<ApiEmployeeDTO> supabaseEmployees, ApiSyncResultDTO result)
        {
            foreach (var employee in sheetEmployees)
            {
                ApiEmployeeDTO existingByUuid = null;
                if (employee.SyncUuid.HasValue)
                {
                    existingByUuid = supabaseEmployees.FirstOrDefault(x => x.SyncUuid == employee.SyncUuid);
                }

                var existingByCode = !string.IsNullOrWhiteSpace(employee.SyncCode)
                    ? supabaseEmployees.FirstOrDefault(x => NormalizeCode(x.SyncCode) == NormalizeCode(employee.SyncCode))
                    : null;

                if (existingByUuid != null)
                {
                    continue;
                }

                if (existingByCode != null)
                {
                    if (employee.SyncUuid.HasValue && !existingByCode.SyncUuid.HasValue)
                    {
                        await repository.PatchSupabaseEmployeeUuidByCodeAsync(existingByCode.SyncCode, employee.SyncUuid.Value);
                        existingByCode.SyncUuid = employee.SyncUuid;
                        result.PatchedEmployeeUuidToSupabase++;
                    }
                    else if (!employee.SyncUuid.HasValue && existingByCode.SyncUuid.HasValue)
                    {
                        await repository.PatchEmployeeSheetUuidAsync(employee.SyncCode, existingByCode.SyncUuid.Value);
                        employee.SyncUuid = existingByCode.SyncUuid;
                        result.PatchedEmployeeUuidToSheet++;
                        result.LinkedExistingEmployeeByCode++;
                    }
                    continue;
                }

                await repository.EnsureSupabaseDepartmentAsync(employee.DepartmentID, employee.DepartmentName);
                var inserted = await repository.InsertSupabaseEmployeeAsync(BuildSupabaseEmployeePayload(employee, includeUuid: employee.SyncUuid.HasValue));
                if (inserted != null)
                {
                    result.InsertedEmployeesToSupabase++;
                    if (!employee.SyncUuid.HasValue && inserted.SyncUuid.HasValue)
                    {
                        await repository.PatchEmployeeSheetUuidAsync(employee.SyncCode, inserted.SyncUuid.Value);
                        employee.SyncUuid = inserted.SyncUuid;
                        result.PatchedEmployeeUuidToSheet++;
                    }
                    supabaseEmployees.Add(inserted);
                }
            }
        }

        private async Task SyncPatientsSupabaseToSheetAsync(List<ApiPatientDTO> supabasePatients, List<ApiPatientDTO> sheetPatients, ApiSyncResultDTO result)
        {
            var sheetUuids = sheetPatients.Where(p => p.SyncUuid.HasValue).Select(p => p.SyncUuid.Value).ToHashSet();
            var sheetCodes = sheetPatients.Select(p => NormalizeCode(p.PatientCode)).Where(x => !string.IsNullOrWhiteSpace(x)).ToHashSet();

            var newRows = supabasePatients
                .Where(p => p.SyncUuid.HasValue)
                .Where(p => !string.IsNullOrWhiteSpace(p.PatientCode))
                .Where(p => !sheetUuids.Contains(p.SyncUuid.Value) && !sheetCodes.Contains(NormalizeCode(p.PatientCode)))
                .Select(BuildPatientSheetRow)
                .ToList();

            if (newRows.Count > 0)
            {
                await repository.InsertSheetPatientsAsync(newRows);
                result.InsertedPatientsToSheet = newRows.Count;
            }
        }

        private async Task SyncEmployeesSupabaseToSheetAsync(List<ApiEmployeeDTO> supabaseEmployees, List<ApiEmployeeDTO> sheetEmployees, ApiSyncResultDTO result)
        {
            var sheetUuids = sheetEmployees.Where(e => e.SyncUuid.HasValue).Select(e => e.SyncUuid.Value).ToHashSet();
            var sheetCodes = sheetEmployees.Select(e => NormalizeCode(e.SyncCode)).Where(x => !string.IsNullOrWhiteSpace(x)).ToHashSet();

            var newRows = supabaseEmployees
                .Where(e => e.SyncUuid.HasValue)
                .Where(e => !string.IsNullOrWhiteSpace(e.SyncCode))
                .Where(e => !sheetUuids.Contains(e.SyncUuid.Value) && !sheetCodes.Contains(NormalizeCode(e.SyncCode)))
                .Select(BuildEmployeeSheetRow)
                .ToList();

            if (newRows.Count > 0)
            {
                await repository.InsertSheetEmployeesAsync(newRows);
                result.InsertedEmployeesToSheet = newRows.Count;
            }
        }

        private Dictionary<string, object> BuildPatientPayload(ApiPatientDTO patient, bool includeUuid)
        {
            var payload = new Dictionary<string, object>();
            if (includeUuid && patient.SyncUuid.HasValue)
            {
                payload["patientid"] = patient.SyncUuid.Value.ToString();
            }

            payload["patientcode"] = SafeString(patient.PatientCode);
            payload["fullname"] = SafeString(patient.FullName);
            payload["gender"] = SafeString(patient.Gender);
            
            var dobVal = FormatDateOnly(patient.DOB);
            if (dobVal != null)
            {
                payload["dob"] = dobVal;
            }
            else
            {
                payload["dob"] = null;
            }

            payload["phone"] = SafeString(patient.Phone);
            payload["address"] = SafeString(patient.Address);
            payload["bloodtype"] = SafeString(patient.BloodType);
            payload["allergy"] = SafeString(patient.Allergy);
            return payload;
        }

        private Dictionary<string, object> BuildSupabaseEmployeePayload(ApiEmployeeDTO employee, bool includeUuid)
        {
            var payload = new Dictionary<string, object>();
            if (includeUuid && employee.SyncUuid.HasValue)
            {
                payload["employeeid"] = employee.SyncUuid.Value.ToString();
            }

            payload["employeecode"] = SafeString(employee.SyncCode);
            payload["fullname"] = SafeString(employee.FullName);
            payload["rolename"] = SafeString(employee.RoleName);
            payload["departmentid"] = employee.DepartmentID.HasValue ? (object)employee.DepartmentID.Value : null;
            payload["phone"] = SafeString(employee.Phone);
            payload["status"] = SafeString(employee.Status);
            return payload;
        }

        private Dictionary<string, object> BuildEmployeePayload(ApiEmployeeDTO employee, bool includeUuid)
        {
            var payload = new Dictionary<string, object>();
            if (includeUuid && employee.SyncUuid.HasValue)
            {
                payload["employeeid"] = employee.SyncUuid.Value.ToString();
            }

            payload["employeecode"] = SafeString(employee.SyncCode);
            payload["fullname"] = SafeString(employee.FullName);
            payload["rolename"] = SafeString(employee.RoleName);
            payload["departmentid"] = employee.DepartmentID.HasValue ? (object)employee.DepartmentID.Value : null;
            payload["departmentname"] = SafeString(employee.DepartmentName);
            payload["phone"] = SafeString(employee.Phone);
            payload["status"] = SafeString(employee.Status);
            return payload;
        }

        private Dictionary<string, object> BuildPatientSheetRow(ApiPatientDTO patient)
        {
            var row = BuildPatientPayload(patient, includeUuid: true);
            row["allergy_flag"] = BuildAllergyFlag(patient.Allergy);
            return row;
        }

        private Dictionary<string, object> BuildEmployeeSheetRow(ApiEmployeeDTO employee)
        {
            return BuildEmployeePayload(employee, includeUuid: true);
        }

        private static string FormatDateOnly(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return null;
            if (DateTime.TryParse(value, out DateTime parsed))
            {
                return parsed.ToString("yyyy-MM-dd");
            }
            string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "yyyy-MM-dd" };
            if (DateTime.TryParseExact(value, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime parsedExact))
            {
                return parsedExact.ToString("yyyy-MM-dd");
            }
            return null;
        }

        private static string SafeString(string value)
        {
            return value == null ? "" : value.Trim();
        }

        private static string NormalizeCode(string value)
        {
            return value == null ? "" : value.Trim().ToUpperInvariant();
        }

        private static string BuildAllergyFlag(string allergy)
        {
            if (string.IsNullOrWhiteSpace(allergy)) return "No allergy";
            string value = allergy.Trim().ToLowerInvariant();
            return value == "không có" || value == "khong co" || value == "none" || value == "no"
                ? "No allergy"
                : "Has allergy";
        }
    }
}
