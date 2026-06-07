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
                .Where(e => !e.SyncCode.StartsWith("BN", StringComparison.OrdinalIgnoreCase))
                .ToList();

            var sheetPatients = sheetPatientsRaw
                .Where(p => !string.IsNullOrWhiteSpace(p.PatientCode))
                .Where(p => !string.IsNullOrWhiteSpace(p.FullName))
                .ToList();

            var sheetEmployees = sheetEmployeesRaw
                .Where(e => !string.IsNullOrWhiteSpace(e.SyncCode))
                .Where(e => !string.IsNullOrWhiteSpace(e.FullName))
                .Where(e => !e.SyncCode.StartsWith("BN", StringComparison.OrdinalIgnoreCase))
                .ToList();

            EnrichEmployeeFields(supabaseEmployees);
            EnrichEmployeeFields(sheetEmployees);

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

            result.MergedEmployees = supabaseEmployees
                .Concat(sheetEmployees)
                .Where(e => !string.IsNullOrWhiteSpace(e.SyncCode))
                .Where(e => !string.IsNullOrWhiteSpace(e.FullName))
                .GroupBy(e => e.SyncUuid.HasValue ? "UUID:" + e.SyncUuid.Value : "CODE:" + NormalizeCode(e.SyncCode))
                .Select(g => g.First())
                .OrderBy(e => e.SyncCode)
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

        public async Task<string> SyncRequestsFromSupabaseAsync()
        {
            // 1. Sync core Patients and Employees first to update references
            try
            {
                await SyncAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Core Sync failed: " + ex.Message);
            }

            int imagingCount = 0;
            int labCount = 0;

            // 2. Fetch flat requests and details lists from Supabase
            var details = await repository.GetSupabaseImagingRequestDetailsFlatAsync();
            var reqs = await repository.GetSupabaseImagingRequestsFlatAsync();
            var encs = await repository.GetSupabaseEncountersFlatAsync();
            var pats = await repository.GetSupabasePatientsAsync();
            var empsRaw = await repository.GetSupabaseEmployeesAsync();
            var emps = empsRaw.Where(e => e.SyncCode != null && !e.SyncCode.StartsWith("BN", StringComparison.OrdinalIgnoreCase)).ToList();
            EnrichEmployeeFields(emps);
            var svcs = await repository.GetSupabaseServicesFlatAsync();
            var resList = await repository.GetSupabaseImagingResultsFlatAsync();

            var labRequests = await repository.GetSupabaseLabRequestsFlatAsync();
            var labResults = await repository.GetSupabaseLabResultsFlatAsync();

            // 3. Create lookups/dictionaries for O(1) matching
            var reqMap = reqs.ToDictionary(r => r.ImagingID, StringComparer.OrdinalIgnoreCase);
            var encMap = encs.ToDictionary(e => e.EncounterID);
            var svcMap = svcs.ToDictionary(s => s.ServiceID);
            var resMap = resList.GroupBy(r => r.DetailID).ToDictionary(g => g.Key, g => g.FirstOrDefault());
            var labResMap = labResults.GroupBy(r => r.LabID).ToDictionary(g => g.Key, g => g.FirstOrDefault());

            // 4. Process Imaging Requests
            foreach (var detail in details)
            {
                // Find parent request
                if (string.IsNullOrEmpty(detail.ImagingID) || !reqMap.TryGetValue(detail.ImagingID, out var req)) continue;

                // Find encounter
                if (!encMap.TryGetValue(req.EncounterID, out var enc)) continue;

                // Find patient code
                ApiPatientDTO patient = null;
                if (!string.IsNullOrEmpty(enc.PatientID))
                {
                    var normalizedPatientId = enc.PatientID.Trim().ToLowerInvariant();
                    patient = pats.FirstOrDefault(p => 
                        (p.PatientId.HasValue && p.PatientId.Value.ToString().ToLowerInvariant() == normalizedPatientId) ||
                        (p.LegacyPatientUuid.HasValue && p.LegacyPatientUuid.Value.ToString().ToLowerInvariant() == normalizedPatientId)
                    );
                }
                var patientCode = patient?.PatientCode;

                // Find doctor code
                ApiEmployeeDTO doctor = null;
                if (!string.IsNullOrEmpty(req.DoctorID))
                {
                    var normalizedDoctorId = req.DoctorID.Trim().ToLowerInvariant();
                    doctor = emps.FirstOrDefault(e => 
                        e.EmployeeId.HasValue && e.EmployeeId.Value.ToString().ToLowerInvariant() == normalizedDoctorId
                    );
                }
                var doctorCode = doctor?.EmployeeCode;

                if (string.IsNullOrEmpty(patientCode) || string.IsNullOrEmpty(doctorCode)) continue;

                var patId = await repository.GetLocalPatientIdByCodeAsync(patientCode);
                if (!patId.HasValue && patient != null)
                {
                    await repository.UpsertLocalPatientAsync(patient);
                    patId = await repository.GetLocalPatientIdByCodeAsync(patientCode);
                }

                var docId = await repository.GetLocalDoctorIdByCodeAsync(doctorCode);
                if (!docId.HasValue && doctor != null)
                {
                    await repository.UpsertLocalEmployeeAsync(doctor);
                    docId = await repository.GetLocalDoctorIdByCodeAsync(doctorCode);
                }

                if (!patId.HasValue || !docId.HasValue) continue;

                string code = !string.IsNullOrEmpty(req.ImagingCode) 
                    ? $"{req.ImagingCode}_{detail.DetailID}" 
                    : $"IM_REQ_DET_{detail.DetailID}";

                // Find service name
                svcMap.TryGetValue(detail.ServiceID, out var svc);
                string serviceType = svc?.ServiceName ?? "Chụp MRI/X-Ray";

                // Find result
                resMap.TryGetValue(detail.DetailID, out var res);
                string note = res?.Notes;
                string imageUrl = res?.ImageUrl;
                string pdfUrl = res?.PdfUrl;
                string status = MapRequestStatus(detail.Status);

                DateTime? reqDate = null;
                if (!string.IsNullOrEmpty(req.CreatedAt) && DateTime.TryParse(req.CreatedAt, out DateTime parsedDate))
                {
                    reqDate = parsedDate;
                }

                await repository.UpsertLocalRequestAsync(code, patId.Value, docId.Value, serviceType, null, "Thường", status, imageUrl, pdfUrl, null, reqDate, note);
                imagingCount++;
            }

            // 5. Process Lab Requests
            foreach (var lab in labRequests)
            {
                // Find encounter
                if (!encMap.TryGetValue(lab.EncounterID, out var enc)) continue;

                // Find patient code
                ApiPatientDTO patient = null;
                if (!string.IsNullOrEmpty(enc.PatientID))
                {
                    var normalizedPatientId = enc.PatientID.Trim().ToLowerInvariant();
                    patient = pats.FirstOrDefault(p => 
                        (p.PatientId.HasValue && p.PatientId.Value.ToString().ToLowerInvariant() == normalizedPatientId) ||
                        (p.LegacyPatientUuid.HasValue && p.LegacyPatientUuid.Value.ToString().ToLowerInvariant() == normalizedPatientId)
                    );
                }
                var patientCode = patient?.PatientCode;

                // Find doctor code
                ApiEmployeeDTO doctor = null;
                if (!string.IsNullOrEmpty(lab.DoctorID))
                {
                    var normalizedDoctorId = lab.DoctorID.Trim().ToLowerInvariant();
                    doctor = emps.FirstOrDefault(e => 
                        e.EmployeeId.HasValue && e.EmployeeId.Value.ToString().ToLowerInvariant() == normalizedDoctorId
                    );
                }
                var doctorCode = doctor?.EmployeeCode;

                if (string.IsNullOrEmpty(patientCode) || string.IsNullOrEmpty(doctorCode)) continue;

                var patId = await repository.GetLocalPatientIdByCodeAsync(patientCode);
                if (!patId.HasValue && patient != null)
                {
                    await repository.UpsertLocalPatientAsync(patient);
                    patId = await repository.GetLocalPatientIdByCodeAsync(patientCode);
                }

                var docId = await repository.GetLocalDoctorIdByCodeAsync(doctorCode);
                if (!docId.HasValue && doctor != null)
                {
                    await repository.UpsertLocalEmployeeAsync(doctor);
                    docId = await repository.GetLocalDoctorIdByCodeAsync(doctorCode);
                }

                if (!patId.HasValue || !docId.HasValue) continue;

                string code = $"LAB_REQ_{lab.LabID}";
                string serviceType = lab.TestType ?? "Xét nghiệm sinh hóa máu";

                // Find result
                labResMap.TryGetValue(lab.LabID, out var res);
                string labValues = res?.ResultText;
                string pdfUrl = res?.FileUrl;
                string status = MapRequestStatus(lab.Status);

                DateTime? reqDate = null;
                if (!string.IsNullOrEmpty(enc.StartTime) && DateTime.TryParse(enc.StartTime, out DateTime parsedDate))
                {
                    reqDate = parsedDate;
                }

                await repository.UpsertLocalRequestAsync(code, patId.Value, docId.Value, serviceType, null, "Thường", status, null, pdfUrl, labValues, reqDate);
                labCount++;
            }

            return $"Đồng bộ thành công!\n- Kéo về {imagingCount} chỉ định hình ảnh (MRI/X-Ray).\n- Kéo về {labCount} chỉ định xét nghiệm Lab.";
        }

        private string MapRequestStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status)) return "Chờ xử lý";
            string s = status.Trim().ToLowerInvariant();
            if (s.Contains("hoàn thành") || s.Contains("completed") || s.Contains("done")) return "Hoàn thành";
            if (s.Contains("đang xử lý") || s.Contains("processing") || s.Contains("inprogress")) return "Đang xử lý";
            return "Chờ xử lý";
        }

        private static void EnrichEmployeeFields(List<ApiEmployeeDTO> employees)
        {
            var deptMap = new Dictionary<int, string>
            {
                { 1, "Khoa Nội tổng hợp" },
                { 2, "Khoa Ngoại tổng hợp" },
                { 3, "Khoa Chẩn đoán hình ảnh" },
                { 4, "Khoa Xét nghiệm" },
                { 7, "Khoa Tim mạch" }
            };

            foreach (var emp in employees)
            {
                if (string.IsNullOrWhiteSpace(emp.DepartmentName) && emp.DepartmentID.HasValue)
                {
                    if (deptMap.TryGetValue(emp.DepartmentID.Value, out string deptName))
                    {
                        emp.DepartmentName = deptName;
                    }
                    else
                    {
                        emp.DepartmentName = $"Khoa {emp.DepartmentID.Value}";
                    }
                }

                if (string.IsNullOrWhiteSpace(emp.RoleName) && emp.SyncCode != null && emp.SyncCode.StartsWith("BS", StringComparison.OrdinalIgnoreCase))
                {
                    emp.RoleName = "Bác sĩ";
                }

                if (string.IsNullOrWhiteSpace(emp.Status))
                {
                    emp.Status = "Đang làm việc";
                }
            }
        }
    }
}
