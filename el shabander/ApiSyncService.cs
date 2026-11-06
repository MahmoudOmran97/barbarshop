using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace el_shabander
{
    public class ApiSyncService
    {
        private readonly HttpClient _client = new HttpClient();
        private const string BASE = "https://almaystro.runasp.net/api";

        // ← آخر وقت تمت فيه المزامنة
        // أول مرة يبعت اللي في آخر 11 دقيقة

        // ========== حضور ==========
        public async Task SyncAttendanceAsync(List<Attendance> list)
        {
            if (!list.Any()) return;

            var dtos = list.Select(x => new {
                x.EmployeeId,
                x.NameEmployee,
                AttendDate = x.AttendDate?.ToString("yyyy-MM-dd"),
                CheckIn = x.CheckIn?.ToString(@"hh\:mm\:ss"),
                CheckOut = x.CheckOut?.ToString(@"hh\:mm\:ss"),
                x.Status,
                WorkedHours = x.WorkedHours ?? 0,
                OvertimeHours = x.OvertimeHours ?? 0
            });

            var json = JsonConvert.SerializeObject(dtos);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync($"{BASE}/attendance", content);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[Sync Attendance] Error: {ex.Message}");
            }
        }

        // ========== فواتير ==========
        // ========== فواتير ==========
        public async Task SyncAppointmentsAsync(List<tb_appointment> list)
        {
            if (!list.Any()) return;

            var dtos = list.Select(x => new {
                SellCus = x.sell_cus,
                SellTprice = x.sell_tprice,
                SellDate = x.sell_date,
                Pay = x.pay,
                Stay = x.stay,
                TotalPrice = x.total_price,
                SellAdd = x.sell_add,
                Cut = x.cut,
                InvoiceId = x.invocie_id,
                TotalEarnings = x.total_earnings,
                Safe = x.safe,
                NameCasher = x.namecasher,
                BarberName = x.barber_name,
                AppStatus = x.app_status,
                CusName = x.cus_name
            }).ToList();

            var json = JsonConvert.SerializeObject(dtos);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync($"{BASE}/appointment/sync", content);

                // ✅ اطبع الـ response للـ debug
                var body = await response.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine($"[Sync] {response.StatusCode} | {body}");

                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[Sync Appointments] Error: {ex.Message}");
            }
        }
        // ========== جيب الإشعارات الجديدة من السيرفر ==========


        // Model يطابق الـ API Response

        // ========== نوتيفيكيشن ==========
        public async Task SendNotificationAsync(string message)
        {
            var body = JsonConvert.SerializeObject(new { message });
            var content = new StringContent(body, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync($"{BASE}/notification", content);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[Send Notification] Error: {ex.Message}");
            }
        }
        // ========== مزامنة الحذف ==========
        // ========== مزامنة حذف الحضور ==========
        public async Task SyncDeletedAttendanceAsync(List<int> localEmployeeIds)
        {
            try
            {
                var json = JsonConvert.SerializeObject(localEmployeeIds);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync($"{BASE}/attendance/sync-delete", content);

                // ✅ اطبع الـ response عشان تشوف إيه اللي بيرجع
                var responseBody = await response.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine($"[Sync Delete Attendance] Status: {response.StatusCode} | Body: {responseBody}");

                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[Sync Delete Attendance] Error: {ex.Message}");
            }
        }
        public async Task SyncDeletedAppointmentsAsync(List<int> localIds)
        {
            try
            {
                var json = JsonConvert.SerializeObject(localIds);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync($"{BASE}/appointment/sync-delete", content);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[Sync Delete] Error: {ex.Message}");
            }
        }
        // ========== Cleanup - امسح القديم من السيرفر ==========
        public async Task CleanupOldDataAsync()
        {
            try
            {
                await _client.DeleteAsync($"{BASE}/appointment/cleanup");
                await _client.DeleteAsync($"{BASE}/attendance/cleanup");
                await _client.DeleteAsync($"{BASE}/booking/cleanup");
                System.Diagnostics.Debug.WriteLine("[Cleanup] تم حذف البيانات القديمة من السيرفر ✅");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[Cleanup] Error: {ex.Message}");
            }
        }
    }
}