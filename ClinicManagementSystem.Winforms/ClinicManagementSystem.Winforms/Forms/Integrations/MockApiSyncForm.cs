using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.Forms.Integrations
{
    public partial class MockApiSyncForm : Form
    {
        private readonly string supabaseUrl = "https://swnbagptdoozwvcxfmqp.supabase.co";
        private readonly string supabaseKey = "sb_publishable_0WsU65Jd6rTgCTHqA5-yng_5fn0Q9x0";

        private readonly string sheetDbPatientUrl = "https://sheetdb.io/api/v1/bdiy5t2crif1p";
        private readonly string sheetDbDoctorUrl = "https://sheetdb.io/api/v1/jci04wz60pp1n";

        private JsonSerializerOptions jsonOptions;

        public MockApiSyncForm()
        {
            InitializeComponent();

            jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                NumberHandling = JsonNumberHandling.AllowReadingFromString,
                WriteIndented = true
            };

            jsonOptions.Converters.Add(new NullableGuidConverter());
        }

        private void MockApiSyncForm_Load(object sender, EventArgs e)
        {
            btnSync.Text = "Đồng bộ & Hợp nhất";
        }

        private async void btnSync_Click(object sender, EventArgs e)
        {
            btnSync.Text = "Đang đồng bộ...";
            btnSync.Enabled = false;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // =====================================================
                    // BƯỚC 1: LOAD SUPABASE
                    // =====================================================
                    SetSupabaseHeaders(client);

                    string supaPatientJson = await GetApiTextAsync(
                        client,
                        $"{supabaseUrl}/rest/v1/patients?select=*",
                        "GET SUPABASE PATIENTS"
                    );

                    string supaDoctorJson = await GetApiTextAsync(
                        client,
                        $"{supabaseUrl}/rest/v1/employees?select=*",
                        "GET SUPABASE EMPLOYEES"
                    );

                    var supabasePatientsRaw = DeserializeList<PatientTest>(
                        supaPatientJson,
                        "PARSE SUPABASE PATIENTS"
                    );

                    var supabaseDoctorsRaw = DeserializeList<DoctorTest>(
                        supaDoctorJson,
                        "PARSE SUPABASE EMPLOYEES"
                    );

                    var supabasePatients = supabasePatientsRaw
                        .Where(p => !string.IsNullOrWhiteSpace(p.PatientCode))
                        .Where(p => !string.IsNullOrWhiteSpace(p.FullName))
                        .ToList();

                    var supabaseDoctors = supabaseDoctorsRaw
                        .Where(d => !string.IsNullOrWhiteSpace(d.EmployeeCode))
                        .Where(d => !string.IsNullOrWhiteSpace(d.FullName))
                        .ToList();

                    // =====================================================
                    // BƯỚC 2: LOAD SHEETDB
                    // =====================================================
                    client.DefaultRequestHeaders.Clear();

                    string sheetPatientJson = await GetApiTextAsync(
                        client,
                        sheetDbPatientUrl,
                        "GET SHEETDB PATIENTS"
                    );

                    string sheetDoctorJson = await GetApiTextAsync(
                        client,
                        sheetDbDoctorUrl,
                        "GET SHEETDB EMPLOYEES"
                    );

                    var sheetPatientsRaw = DeserializeList<PatientTest>(
                        sheetPatientJson,
                        "PARSE SHEETDB PATIENTS"
                    );

                    var sheetDoctorsRaw = DeserializeList<DoctorTest>(
                        sheetDoctorJson,
                        "PARSE SHEETDB EMPLOYEES"
                    );

                    var sheetPatients = sheetPatientsRaw
                        .Where(p => !string.IsNullOrWhiteSpace(p.PatientCode))
                        .Where(p => !string.IsNullOrWhiteSpace(p.FullName))
                        .ToList();

                    var sheetDoctors = sheetDoctorsRaw
                        .Where(d => !string.IsNullOrWhiteSpace(d.EmployeeCode))
                        .Where(d => !string.IsNullOrWhiteSpace(d.FullName))
                        .ToList();

                    int skippedPatientRows = sheetPatientsRaw.Count - sheetPatients.Count;
                    int skippedDoctorRows = sheetDoctorsRaw.Count - sheetDoctors.Count;

                    // =====================================================
                    // BƯỚC 3: SHEETDB -> SUPABASE
                    // Insert lên Supabase, lấy UUID, ghi ngược về SheetDB
                    // =====================================================
                    SetSupabaseHeaders(client);

                    int insertedPatientsToSupa = 0;
                    int patchedPatientUuidToSheet = 0;
                    int linkedOldPatientByCode = 0;

                    foreach (var p in sheetPatients)
                    {
                        PatientTest existingById = null;
                        PatientTest existingByCode = null;

                        if (p.PatientID.HasValue)
                        {
                            existingById = supabasePatients.FirstOrDefault(x =>
                                x.PatientID.HasValue &&
                                x.PatientID.Value == p.PatientID.Value
                            );
                        }

                        existingByCode = supabasePatients.FirstOrDefault(x =>
                            NormalizeCode(x.PatientCode) == NormalizeCode(p.PatientCode)
                        );

                        // Case 1: Sheet đã có UUID và Supabase cũng có UUID đó
                        if (existingById != null)
                            continue;

                        // Case 2: Sheet chưa có UUID, nhưng Supabase đã có patientcode
                        // => không insert trùng, chỉ lấy UUID ghi ngược về Sheet
                        if (!p.PatientID.HasValue && existingByCode != null && existingByCode.PatientID.HasValue)
                        {
                            bool patchOk = await PatchSheetByColumnAsync(
                                client,
                                sheetDbPatientUrl,
                                "patientcode",
                                p.PatientCode,
                                new Dictionary<string, object>
                                {
                                    ["patientid"] = existingByCode.PatientID.Value.ToString()
                                },
                                "PATCH EXISTING PATIENT UUID BACK TO SHEET"
                            );

                            if (patchOk)
                            {
                                p.PatientID = existingByCode.PatientID;
                                patchedPatientUuidToSheet++;
                                linkedOldPatientByCode++;
                            }

                            continue;
                        }

                        // Case 3: Sheet là bệnh nhân mới
                        var insertPayload = BuildPatientSupabasePayload(
                            p,
                            includePatientId: p.PatientID.HasValue
                        );

                        var inserted = await PostJsonReturnOneAsync<PatientTest>(
                            client,
                            $"{supabaseUrl}/rest/v1/patients",
                            insertPayload,
                            "POST SHEET PATIENT -> SUPABASE"
                        );

                        if (inserted != null)
                        {
                            insertedPatientsToSupa++;

                            if (!p.PatientID.HasValue && inserted.PatientID.HasValue)
                            {
                                bool patchOk = await PatchSheetByColumnAsync(
                                    client,
                                    sheetDbPatientUrl,
                                    "patientcode",
                                    p.PatientCode,
                                    new Dictionary<string, object>
                                    {
                                        ["patientid"] = inserted.PatientID.Value.ToString()
                                    },
                                    "PATCH NEW PATIENT UUID BACK TO SHEET"
                                );

                                if (patchOk)
                                {
                                    p.PatientID = inserted.PatientID;
                                    patchedPatientUuidToSheet++;
                                }
                            }

                            supabasePatients.Add(inserted);
                        }
                    }

                    int insertedDoctorsToSupa = 0;
                    int patchedDoctorUuidToSheet = 0;
                    int linkedOldDoctorByCode = 0;

                    foreach (var d in sheetDoctors)
                    {
                        DoctorTest existingById = null;
                        DoctorTest existingByCode = null;

                        if (d.EmployeeID.HasValue)
                        {
                            existingById = supabaseDoctors.FirstOrDefault(x =>
                                x.EmployeeID.HasValue &&
                                x.EmployeeID.Value == d.EmployeeID.Value
                            );
                        }

                        existingByCode = supabaseDoctors.FirstOrDefault(x =>
                            NormalizeCode(x.EmployeeCode) == NormalizeCode(d.EmployeeCode)
                        );

                        // Case 1: Sheet đã có UUID và Supabase cũng có UUID đó
                        if (existingById != null)
                            continue;

                        // Case 2: Sheet chưa có UUID, nhưng Supabase đã có employeecode
                        if (!d.EmployeeID.HasValue && existingByCode != null && existingByCode.EmployeeID.HasValue)
                        {
                            bool patchOk = await PatchSheetByColumnAsync(
                                client,
                                sheetDbDoctorUrl,
                                "employeecode",
                                d.EmployeeCode,
                                new Dictionary<string, object>
                                {
                                    ["employeeid"] = existingByCode.EmployeeID.Value.ToString()
                                },
                                "PATCH EXISTING EMPLOYEE UUID BACK TO SHEET"
                            );

                            if (patchOk)
                            {
                                d.EmployeeID = existingByCode.EmployeeID;
                                patchedDoctorUuidToSheet++;
                                linkedOldDoctorByCode++;
                            }

                            continue;
                        }

                        // Case 3: Sheet là nhân viên/bác sĩ mới
                        var insertPayload = BuildDoctorSupabasePayload(
                            d,
                            includeEmployeeId: d.EmployeeID.HasValue
                        );

                        var inserted = await PostJsonReturnOneAsync<DoctorTest>(
                            client,
                            $"{supabaseUrl}/rest/v1/employees",
                            insertPayload,
                            "POST SHEET EMPLOYEE -> SUPABASE"
                        );

                        if (inserted != null)
                        {
                            insertedDoctorsToSupa++;

                            if (!d.EmployeeID.HasValue && inserted.EmployeeID.HasValue)
                            {
                                bool patchOk = await PatchSheetByColumnAsync(
                                    client,
                                    sheetDbDoctorUrl,
                                    "employeecode",
                                    d.EmployeeCode,
                                    new Dictionary<string, object>
                                    {
                                        ["employeeid"] = inserted.EmployeeID.Value.ToString()
                                    },
                                    "PATCH NEW EMPLOYEE UUID BACK TO SHEET"
                                );

                                if (patchOk)
                                {
                                    d.EmployeeID = inserted.EmployeeID;
                                    patchedDoctorUuidToSheet++;
                                }
                            }

                            supabaseDoctors.Add(inserted);
                        }
                    }

                    // =====================================================
                    // BƯỚC 4: SUPABASE -> SHEETDB
                    // Record nào chỉ có ở Supabase thì ghi xuống Sheet kèm UUID
                    // =====================================================
                    client.DefaultRequestHeaders.Clear();

                    int insertedPatientsToSheet = 0;
                    int insertedDoctorsToSheet = 0;

                    var sheetPatientIds = sheetPatients
                        .Where(p => p.PatientID.HasValue)
                        .Select(p => p.PatientID.Value)
                        .ToHashSet();

                    var sheetPatientCodes = sheetPatients
                        .Select(p => NormalizeCode(p.PatientCode))
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .ToHashSet();

                    var newPatientsFromSupa = supabasePatients
                        .Where(p => p.PatientID.HasValue)
                        .Where(p => !string.IsNullOrWhiteSpace(p.PatientCode))
                        .Where(p =>
                            !sheetPatientIds.Contains(p.PatientID.Value) &&
                            !sheetPatientCodes.Contains(NormalizeCode(p.PatientCode))
                        )
                        .ToList();

                    if (newPatientsFromSupa.Count > 0)
                    {
                        var rows = newPatientsFromSupa.Select(p => new Dictionary<string, object>
                        {
                            ["patientid"] = p.PatientID.HasValue ? p.PatientID.Value.ToString() : "",
                            ["patientcode"] = SafeString(p.PatientCode),
                            ["fullname"] = SafeString(p.FullName),
                            ["gender"] = SafeString(p.Gender),
                            ["dob"] = FormatDateOnly(p.DOB),
                            ["phone"] = SafeString(p.Phone),
                            ["address"] = SafeString(p.Address),
                            ["bloodtype"] = SafeString(p.BloodType),
                            ["allergy"] = SafeString(p.Allergy),
                            ["allergy_flag"] = BuildAllergyFlag(p.Allergy)
                        }).ToList();

                        bool ok = await PostJsonAsync(
                            client,
                            sheetDbPatientUrl,
                            new Dictionary<string, object> { ["data"] = rows },
                            "POST SUPABASE PATIENTS -> SHEETDB"
                        );

                        if (ok)
                            insertedPatientsToSheet = newPatientsFromSupa.Count;
                    }

                    var sheetDoctorIds = sheetDoctors
                        .Where(d => d.EmployeeID.HasValue)
                        .Select(d => d.EmployeeID.Value)
                        .ToHashSet();

                    var sheetDoctorCodes = sheetDoctors
                        .Select(d => NormalizeCode(d.EmployeeCode))
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .ToHashSet();

                    var newDoctorsFromSupa = supabaseDoctors
                        .Where(d => d.EmployeeID.HasValue)
                        .Where(d => !string.IsNullOrWhiteSpace(d.EmployeeCode))
                        .Where(d =>
                            !sheetDoctorIds.Contains(d.EmployeeID.Value) &&
                            !sheetDoctorCodes.Contains(NormalizeCode(d.EmployeeCode))
                        )
                        .ToList();

                    if (newDoctorsFromSupa.Count > 0)
                    {
                        var rows = newDoctorsFromSupa.Select(d => new Dictionary<string, object>
                        {
                            ["employeeid"] = d.EmployeeID.HasValue ? d.EmployeeID.Value.ToString() : "",
                            ["employeecode"] = SafeString(d.EmployeeCode),
                            ["fullname"] = SafeString(d.FullName),
                            ["rolename"] = SafeString(d.RoleName),
                            ["departmentid"] = d.DepartmentID.HasValue ? d.DepartmentID.Value : 0,
                            ["phone"] = SafeString(d.Phone),
                            ["status"] = SafeString(d.Status)
                        }).ToList();

                        bool ok = await PostJsonAsync(
                            client,
                            sheetDbDoctorUrl,
                            new Dictionary<string, object> { ["data"] = rows },
                            "POST SUPABASE EMPLOYEES -> SHEETDB"
                        );

                        if (ok)
                            insertedDoctorsToSheet = newDoctorsFromSupa.Count;
                    }

                    // =====================================================
                    // BƯỚC 5: HIỂN THỊ GRID
                    // =====================================================
                    var mergedPatients = supabasePatients
                        .Concat(sheetPatients)
                        .Where(p => !string.IsNullOrWhiteSpace(p.PatientCode))
                        .Where(p => !string.IsNullOrWhiteSpace(p.FullName))
                        .GroupBy(p =>
                            p.PatientID.HasValue
                                ? "ID:" + p.PatientID.Value.ToString()
                                : "CODE:" + NormalizeCode(p.PatientCode)
                        )
                        .Select(g => g.First())
                        .OrderBy(p => p.PatientCode)
                        .ToList();

                    dgvTest.DataSource = mergedPatients;

                    MessageBox.Show(
                        $"ĐỒNG BỘ HOÀN TẤT!\n\n" +

                        $"--- SHEETDB -> SUPABASE ---\n" +
                        $"+ Bệnh nhân insert mới lên Supabase: {insertedPatientsToSupa}\n" +
                        $"+ Bác sĩ/Nhân viên insert mới lên Supabase: {insertedDoctorsToSupa}\n\n" +

                        $"--- GHI UUID NGƯỢC VỀ SHEETDB ---\n" +
                        $"+ Patient UUID đã ghi về Sheet: {patchedPatientUuidToSheet}\n" +
                        $"+ Employee UUID đã ghi về Sheet: {patchedDoctorUuidToSheet}\n" +
                        $"+ PatientCode cũ được liên kết lại: {linkedOldPatientByCode}\n" +
                        $"+ EmployeeCode cũ được liên kết lại: {linkedOldDoctorByCode}\n\n" +

                        $"--- SUPABASE -> SHEETDB ---\n" +
                        $"+ Bệnh nhân mới từ Supabase ghi xuống Sheet: {insertedPatientsToSheet}\n" +
                        $"+ Nhân viên mới từ Supabase ghi xuống Sheet: {insertedDoctorsToSheet}\n\n" +

                        $"--- DÒNG BỊ BỎ QUA ---\n" +
                        $"+ Sheet bệnh nhân thiếu mã hoặc tên: {skippedPatientRows}\n" +
                        $"+ Sheet nhân viên thiếu mã hoặc tên: {skippedDoctorRows}\n\n" +

                        $"=> Grid đang hiển thị: {mergedPatients.Count} bệnh nhân.",
                        "Kết quả đồng bộ"
                    );
                }
            }
            catch (JsonException jsonEx)
            {
                MessageBox.Show(
                    $"LỖI JSON PARSE\n\n" +
                    $"Có thể SheetDB trả về UUID rỗng, departmentid rỗng, hoặc JSON không đúng dạng.\n\n" +
                    $"Chi tiết:\n{jsonEx.Message}",
                    "Debug: Lỗi JSON"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"LỖI HỆ THỐNG/API\n\n" +
                    $"Message:\n{ex.Message}\n\n" +
                    $"StackTrace:\n{ex.StackTrace}",
                    "Debug: Lỗi chung"
                );
            }
            finally
            {
                btnSync.Text = "Đồng bộ & Hợp nhất";
                btnSync.Enabled = true;
            }
        }

        // =====================================================
        // BUILD PAYLOAD
        // =====================================================
        private Dictionary<string, object> BuildPatientSupabasePayload(PatientTest p, bool includePatientId)
        {
            var payload = new Dictionary<string, object>();

            if (includePatientId && p.PatientID.HasValue)
                payload["patientid"] = p.PatientID.Value.ToString();

            payload["patientcode"] = SafeString(p.PatientCode);
            payload["fullname"] = SafeString(p.FullName);
            payload["gender"] = SafeString(p.Gender);
            payload["dob"] = FormatDateOnly(p.DOB);
            payload["phone"] = SafeString(p.Phone);
            payload["address"] = SafeString(p.Address);
            payload["bloodtype"] = SafeString(p.BloodType);
            payload["allergy"] = SafeString(p.Allergy);

            return payload;
        }

        private Dictionary<string, object> BuildDoctorSupabasePayload(DoctorTest d, bool includeEmployeeId)
        {
            var payload = new Dictionary<string, object>();

            if (includeEmployeeId && d.EmployeeID.HasValue)
                payload["employeeid"] = d.EmployeeID.Value.ToString();

            payload["employeecode"] = SafeString(d.EmployeeCode);
            payload["fullname"] = SafeString(d.FullName);
            payload["rolename"] = SafeString(d.RoleName);
            payload["departmentid"] = d.DepartmentID.HasValue ? d.DepartmentID.Value : 0;
            payload["phone"] = SafeString(d.Phone);
            payload["status"] = SafeString(d.Status);

            return payload;
        }

        // =====================================================
        // API HELPERS
        // =====================================================
        private void SetSupabaseHeaders(HttpClient client)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("apikey", supabaseKey);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + supabaseKey);
            client.DefaultRequestHeaders.Add("Prefer", "return=representation");
        }

        private async Task<string> GetApiTextAsync(HttpClient client, string url, string stepName)
        {
            HttpResponseMessage response = await client.GetAsync(url);
            string responseText = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(
                    $"[{stepName}] GET thất bại\n\n" +
                    $"URL:\n{url}\n\n" +
                    $"StatusCode:\n{(int)response.StatusCode} - {response.StatusCode}\n\n" +
                    $"Response:\n{LimitText(responseText, 3000)}"
                );
            }

            return responseText;
        }

        private async Task<bool> PostJsonAsync(HttpClient client, string url, object payloadObj, string stepName)
        {
            string json = JsonSerializer.Serialize(payloadObj, jsonOptions);

            using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                HttpResponseMessage response = await client.PostAsync(url, content);
                string responseText = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        $"[{stepName}] POST thất bại\n\n" +
                        $"URL:\n{url}\n\n" +
                        $"StatusCode:\n{(int)response.StatusCode} - {response.StatusCode}\n\n" +
                        $"JSON gửi đi:\n{LimitText(json, 3000)}\n\n" +
                        $"Response:\n{LimitText(responseText, 3000)}",
                        "Debug: POST lỗi"
                    );

                    return false;
                }

                return true;
            }
        }

        private async Task<T> PostJsonReturnOneAsync<T>(HttpClient client, string url, object payloadObj, string stepName)
        {
            string json = JsonSerializer.Serialize(payloadObj, jsonOptions);

            using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                HttpResponseMessage response = await client.PostAsync(url, content);
                string responseText = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        $"[{stepName}] POST Supabase thất bại\n\n" +
                        $"URL:\n{url}\n\n" +
                        $"StatusCode:\n{(int)response.StatusCode} - {response.StatusCode}\n\n" +
                        $"JSON gửi đi:\n{LimitText(json, 3000)}\n\n" +
                        $"Response:\n{LimitText(responseText, 3000)}",
                        "Debug: POST Supabase lỗi"
                    );

                    return default(T);
                }

                var list = JsonSerializer.Deserialize<List<T>>(responseText, jsonOptions);

                if (list != null && list.Count > 0)
                    return list[0];

                MessageBox.Show(
                    $"[{stepName}] Insert thành công nhưng không nhận được record trả về.\n\n" +
                    $"Response:\n{LimitText(responseText, 3000)}",
                    "Debug: Không nhận được UUID"
                );

                return default(T);
            }
        }

        private async Task<bool> PatchSheetByColumnAsync(
            HttpClient client,
            string baseSheetUrl,
            string columnName,
            string columnValue,
            Dictionary<string, object> fieldsToUpdate,
            string stepName
        )
        {
            string url = $"{baseSheetUrl}/{columnName}/{Uri.EscapeDataString(columnValue)}";

            var payload = new Dictionary<string, object>
            {
                ["data"] = fieldsToUpdate
            };

            string json = JsonSerializer.Serialize(payload, jsonOptions);

            using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                var request = new HttpRequestMessage(new HttpMethod("PATCH"), url)
                {
                    Content = content
                };

                HttpResponseMessage response = await client.SendAsync(request);
                string responseText = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        $"[{stepName}] PATCH SheetDB thất bại\n\n" +
                        $"URL:\n{url}\n\n" +
                        $"StatusCode:\n{(int)response.StatusCode} - {response.StatusCode}\n\n" +
                        $"JSON gửi đi:\n{LimitText(json, 3000)}\n\n" +
                        $"Response:\n{LimitText(responseText, 3000)}",
                        "Debug: PATCH SheetDB lỗi"
                    );

                    return false;
                }

                return true;
            }
        }

        private List<T> DeserializeList<T>(string json, string stepName)
        {
            try
            {
                return JsonSerializer.Deserialize<List<T>>(json, jsonOptions) ?? new List<T>();
            }
            catch (Exception ex)
            {
                throw new JsonException(
                    $"[{stepName}] Không parse được JSON thành List<{typeof(T).Name}>.\n\n" +
                    $"JSON nhận được:\n{LimitText(json, 3000)}\n\n" +
                    $"Lỗi gốc:\n{ex.Message}"
                );
            }
        }

        // =====================================================
        // FORMAT HELPERS
        // =====================================================
        private string FormatDateOnly(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return "";

            if (DateTime.TryParse(value, out DateTime parsed))
                return parsed.ToString("yyyy-MM-dd");

            return value.Trim();
        }

        private string SafeString(string value)
        {
            return value == null ? "" : value.Trim();
        }

        private string NormalizeCode(string value)
        {
            return value == null ? "" : value.Trim().ToUpper();
        }

        private string BuildAllergyFlag(string allergy)
        {
            if (string.IsNullOrWhiteSpace(allergy))
                return "No allergy";

            string a = allergy.Trim().ToLower();

            if (a == "không có" || a == "khong co" || a == "none" || a == "no")
                return "No allergy";

            return "Has allergy";
        }

        private string LimitText(string text, int maxLength)
        {
            if (string.IsNullOrEmpty(text))
                return "";

            if (text.Length <= maxLength)
                return text;

            return text.Substring(0, maxLength) + "\n\n... [Đã rút gọn vì quá dài]";
        }
    }
}
