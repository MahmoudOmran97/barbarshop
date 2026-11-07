// C# 7.3 / .NET Framework 4.5+ compatible. NuGet needed: Newtonsoft.Json
// References needed: System.Net.Http
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Barbarshop
{
    public class MenuService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
        public int CategoryId { get; set; }
    }

    public class MenuCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public List<MenuService> Services { get; set; } = new List<MenuService>();
    }

    public enum BookingResult { Saved, Rejected, Failed }

    public class AlMaystroApiClient
    {
        private readonly HttpClient _http;

        public AlMaystroApiClient(string baseUrl)
        {
            // older .NET Framework versions don't use TLS 1.2 by default
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
            _http = new HttpClient
            {
                BaseAddress = new Uri(baseUrl),
                Timeout = TimeSpan.FromSeconds(15)
            };
        }

        public async Task<List<MenuCategory>> GetMenuAsync()
        {
            string json = await _http.GetStringAsync("api/categories").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<MenuCategory>>(json) ?? new List<MenuCategory>();
        }

        // Saved    = stored on the server
        // Rejected = server refused it (invalid data) - retrying won't help
        // Failed   = no internet / server error / rate limit - safe to retry later
        public async Task<BookingResult> CreateBookingAsync(string name, string phone, int? serviceId,
            DateTime date, string notes = null)
        {
            try
            {
                string body = JsonConvert.SerializeObject(new
                {
                    customerName = name,
                    phone = phone,
                    serviceId = serviceId,
                    date = date.ToUniversalTime(),   // the API converts it to Cairo time
                    source = "Desktop",
                    notes = notes
                });
                var res = await _http.PostAsync("api/bookings",
                    new StringContent(body, Encoding.UTF8, "application/json")).ConfigureAwait(false);

                if (res.IsSuccessStatusCode) return BookingResult.Saved;
                int code = (int)res.StatusCode;
                if (code == 429 || code >= 500) return BookingResult.Failed;
                return BookingResult.Rejected;
            }
            catch (Exception)
            {
                return BookingResult.Failed;
            }
        }
    }
}