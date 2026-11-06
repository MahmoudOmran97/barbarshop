using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Xml.Linq;
namespace el_shabander
{
    public class HikvisionService : IDisposable
    {
        private readonly string _baseUrl;
        private readonly HttpClient _client;

        public HikvisionService(string ip, string username, string password)
        {
            _baseUrl = $"http://{ip}";

            var handler = new HttpClientHandler
            {
                Credentials = new System.Net.NetworkCredential(username, password),
                PreAuthenticate = false
            };
            _client = new HttpClient(handler)
            {
                Timeout = TimeSpan.FromSeconds(15)
            };
        }

        public async Task<bool> TestConnectionAsync()
        {
            try
            {
                var res = await _client.GetAsync($"{_baseUrl}/ISAPI/System/deviceInfo");
                return res.IsSuccessStatusCode;
            }
            catch { return false; }
        }

        public async Task<(bool Success, string Message)> RegisterEmployeeAsync(
      int employeeId, string employeeName, string password = "")
        {
            try
            {
                string passwordField = string.IsNullOrWhiteSpace(password)
                    ? ""
                    : $"\"password\":\"{password}\",";

                string authType = string.IsNullOrWhiteSpace(password)
                    ? "\"userVerifyMode\":\"face\","
                   : "\"userVerifyMode\":\"faceAndPw\",";

                string jsonBody = "{\"UserInfo\":{" +
                    $"\"employeeNo\":\"{employeeId}\"," +
                    $"\"name\":\"{employeeName}\"," +
                    "\"userType\":\"normal\"," +
                    passwordField +
                    authType +
                    "\"Valid\":{" +
                        "\"enable\":true," +
                        "\"beginTime\":\"2024-01-01T00:00:00\"," +
                        "\"endTime\":\"2035-12-31T23:59:59\"" +
                    "}," +
                    "\"doorRight\":\"1\"," +
                    "\"RightPlan\":[{\"doorNo\":1,\"planTemplateNo\":\"1\"}]" +
                    "}}";

                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                var res = await _client.PostAsync(
                    $"{_baseUrl}/ISAPI/AccessControl/UserInfo/Record?format=json",
                    content);

                var responseText = await res.Content.ReadAsStringAsync();

                if (res.IsSuccessStatusCode)
                    return (true, "تم تسجيل الموظف بنجاح ✅");

                if (responseText.Contains("employeeNoAlreadyExist") ||
                    responseText.Contains("reuse"))
                    return await UpdateEmployeeAsync(employeeId, employeeName, password);

                return (false, responseText);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        public async Task<string> GetUserVerifyModesAsync()
        {
            try
            {
                var res = await _client.GetAsync(
                    $"{_baseUrl}/ISAPI/AccessControl/UserInfo/capabilities?format=json");
                return await res.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<(bool Success, string Message)> UpdateEmployeeAsync(
            int employeeId, string employeeName, string password = "")
        {
            try
            {
                string passwordField = string.IsNullOrWhiteSpace(password)
                    ? ""
                    : $"\"password\":\"{password}\",";

                string authType = string.IsNullOrWhiteSpace(password)
     ? "\"userVerifyMode\":\"face\","
     : "\"userVerifyMode\":\"faceAndPw\",";

                string jsonBody = "{\"UserInfo\":{" +
                    $"\"employeeNo\":\"{employeeId}\"," +
                    $"\"name\":\"{employeeName}\"," +
                    "\"userType\":\"normal\"," +
                    passwordField +
                    authType +
                    "\"Valid\":{" +
                        "\"enable\":true," +
                        "\"beginTime\":\"2024-01-01T00:00:00\"," +
                        "\"endTime\":\"2035-12-31T23:59:59\"" +
                    "}," +
                    "\"doorRight\":\"1\"," +
                    "\"RightPlan\":[{\"doorNo\":1,\"planTemplateNo\":\"1\"}]" +
                    "}}";

                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                var res = await _client.PutAsync(
                    $"{_baseUrl}/ISAPI/AccessControl/UserInfo/Modify?format=json",
                    content);

                var responseText = await res.Content.ReadAsStringAsync();

                return res.IsSuccessStatusCode
                    ? (true, "تم تحديث الموظف بنجاح ✅")
                    : (false, responseText);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        public async Task<string> ClearAttendanceLogsAsync()
        {
            try
            {
                // ← جرب DELETE بدل PUT
                var res = await _client.DeleteAsync(
                    $"{_baseUrl}/ISAPI/AccessControl/AcsEvent?format=json");

                var responseText = await res.Content.ReadAsStringAsync();
                return $"Status: {(int)res.StatusCode}\n{responseText}";
            }
            catch (Exception ex)
            {
                return "خطأ: " + ex.Message;
            }
        }
        public async Task<(List<DeviceAttendanceLog> Logs, string RawResponse)>
     GetAttendanceLogsAsync(DateTime from, DateTime to)
        {
            var logs = new List<DeviceAttendanceLog>();
            string rawResponse = "";

            try
            {
                string startTime = from.Date.ToString("yyyy-MM-dd") + "T00:00:00+03:00";
                string endTime = to.Date.ToString("yyyy-MM-dd") + "T23:59:59+03:00";
                string searchId = new Random().Next(1000, 9999).ToString();

                var allInfoList = new JArray();
                int position = 0;
                int totalMatches = int.MaxValue;

                while (position < totalMatches)
                {
                    string jsonBody = "{" +
                        "\"AcsEventCond\":{" +
                        $"\"searchID\":\"{searchId}\"," +
                        $"\"searchResultPosition\":{position}," +
                        "\"maxResults\":100000," +
                        "\"major\":0," +
                        "\"minor\":0," +
                        $"\"startTime\":\"{startTime}\"," +
                        $"\"endTime\":\"{endTime}\"" +
                        "}}";

                    var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                    var res = await _client.PostAsync(
                        $"{_baseUrl}/ISAPI/AccessControl/AcsEvent?format=json", content);

                    rawResponse = await res.Content.ReadAsStringAsync();

                    if (!res.IsSuccessStatusCode)
                        return (logs, $"Error {(int)res.StatusCode}: {rawResponse}");

                    var parsed = JObject.Parse(rawResponse);
                    totalMatches = parsed["AcsEvent"]?["totalMatches"]?.Value<int>() ?? 0;
                    int numOfMatches = parsed["AcsEvent"]?["numOfMatches"]?.Value<int>() ?? 0;

                    var page = parsed["AcsEvent"]?["InfoList"] as JArray;
                    if (page == null || numOfMatches == 0) break;

                    foreach (var item in page)
                        allInfoList.Add(item);

                    position += numOfMatches;

                    string status = parsed["AcsEvent"]?["responseStatusStrg"]?.ToString();
                    if (status == "END" || status == "NO MATCH") break;
                }

                if (!allInfoList.Any())
                    return (logs, "No InfoList found.");

                foreach (var item in allInfoList)
                {
                    // ← لازم يكون فيه employeeNo
                    string empNoStr = item["employeeNoString"]?.ToString() ??
                                      item["employeeNo"]?.ToString() ?? "";
                    if (string.IsNullOrEmpty(empNoStr)) continue;

                    var timeStr = item["time"]?.ToString();
                    if (string.IsNullOrEmpty(timeStr)) continue;

                    if (!DateTimeOffset.TryParse(timeStr, out DateTimeOffset eventTimeOffset)) continue;

                    DateTime eventTime = eventTimeOffset.LocalDateTime;
                    string name = item["name"]?.ToString() ?? "";

                    // ← قرأ الـ attendanceStatus مباشرة من الجهاز
                    string attendanceStatus = item["attendanceStatus"]?.ToString() ?? "";

                    string eventType = null;

                    if (attendanceStatus == "checkIn")
                        eventType = "CheckIn";
                    else if (attendanceStatus == "checkOut")
                        eventType = "CheckOut";
                    else
                        continue; // تجاهل أي event مش فيه attendanceStatus واضح

                    if (!int.TryParse(empNoStr, out int empId)) continue;

                    logs.Add(new DeviceAttendanceLog
                    {
                        EmployeeId = empId,
                        EmployeeName = name,
                        EventTime = eventTime,
                        EventType = eventType
                    });
                }

                rawResponse = $"✅ Total: {totalMatches}, Fetched: {allInfoList.Count}, Logs: {logs.Count}";
            }
            catch (Exception ex)
            {
                rawResponse = "Exception: " + ex.Message;
            }

            return (logs, rawResponse);
        }
        public async Task<(bool Success, string Message)> UploadFaceAsync(
     int employeeId, string imagePath)
        {
            try
            {
                byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);

                string boundary = "---------------------------7e13971310878";

                string jsonPart =
                    "{" +
                    "\"faceLibType\":\"blackFD\"," +
                    "\"FDID\":\"1\"," +
                    "\"FPID\":\"" + employeeId + "\"" +
                    "}";

                byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonPart);

                // ← بناء الـ multipart يدوياً بالظبط زي Hikvision docs
                string header =
                    "--" + boundary + "\r\n" +
                    "Content-Disposition: form-data; name=\"FaceDataRecord\"\r\n" +
                    "Content-Type: application/json\r\n" +
                    "Content-Length: " + jsonBytes.Length + "\r\n" +
                    "\r\n" +
                    jsonPart + "\r\n" +
                    "--" + boundary + "\r\n" +
                    "Content-Disposition: form-data; name=\"FaceImage\"\r\n" +
                    "Content-Type: image/jpeg\r\n" +
                    "Content-Length: " + imageBytes.Length + "\r\n" +
                    "\r\n";

                string footer = "\r\n--" + boundary + "--\r\n";

                byte[] headerBytes = Encoding.UTF8.GetBytes(header);
                byte[] footerBytes = Encoding.UTF8.GetBytes(footer);

                // دمج كل الأجزاء
                byte[] body = new byte[headerBytes.Length + imageBytes.Length + footerBytes.Length];
                Buffer.BlockCopy(headerBytes, 0, body, 0, headerBytes.Length);
                Buffer.BlockCopy(imageBytes, 0, body, headerBytes.Length, imageBytes.Length);
                Buffer.BlockCopy(footerBytes, 0, body, headerBytes.Length + imageBytes.Length, footerBytes.Length);

                var content = new ByteArrayContent(body);
                content.Headers.Remove("Content-Type");
                content.Headers.TryAddWithoutValidation(
                    "Content-Type",
                    "multipart/form-data; boundary=" + boundary);

                var res = await _client.PostAsync(
                    $"{_baseUrl}/ISAPI/Intelligent/FDLib/FaceDataRecord?format=json",
                    content);

                var responseText = await res.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine($"UploadFace Response: {responseText}");

                if (res.IsSuccessStatusCode)
                    return (true, "تم رفع الصورة بنجاح ✅");

                if (responseText.Contains("reuse") || responseText.Contains("alreadyExist"))
                    return (true, "الصورة مسجّلة مسبقاً ✅");

                return (false, responseText);
            }
            catch (Exception ex)
            {
                return (false, $"Exception: {ex.Message}");
            }
        }
        public async Task<(bool Success, string Message)> DeleteUserFromDeviceAsync(int employeeId)
        {
            try
            {
                // ✅ الـ key الصح هو UserInfoDelCond
                string jsonBody =
                    "{\"UserInfoDelCond\":{" +
                    "\"EmployeeNoList\":[{\"employeeNo\":\"" + employeeId + "\"}]" +
                    "}}";

                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                var res = await _client.PutAsync(
                    $"{_baseUrl}/ISAPI/AccessControl/UserInfo/Delete?format=json",
                    content);

                var responseText = await res.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine($"DeleteUser: {responseText}");

                if (res.IsSuccessStatusCode ||
                    responseText.Contains("ok") ||
                    responseText.Contains("OK"))
                    return (true, "تم حذف المستخدم ✅");

                return (false, responseText);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        public async Task<string> GetFaceLibrariesAsync()
        {
            try
            {
                var res = await _client.GetAsync(
                    $"{_baseUrl}/ISAPI/Intelligent/FDLib?format=json");
                return await res.Content.ReadAsStringAsync();
            }
            catch (Exception ex) { return ex.Message; }
        }
        public void Dispose() => _client?.Dispose();
    }

    public class DeviceAttendanceLog
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime EventTime { get; set; }
        public string EventType { get; set; }
    }
}