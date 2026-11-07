// C# 7.3 / .NET Framework 4.5+ compatible. NuGet needed: Newtonsoft.Json
// Keeps bookings in a local JSON file when the server is unreachable and uploads them later.
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Barbarshop
{
    public class PendingBooking
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public int? ServiceId { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
    }

    public enum SaveOutcome { Saved, QueuedOffline, Rejected }

    public class OfflineBookingQueue
    {
        private readonly AlMaystroApiClient _api;
        private readonly string _filePath;
        private readonly SemaphoreSlim _lock = new SemaphoreSlim(1, 1);

        public OfflineBookingQueue(AlMaystroApiClient api, string filePath)
        {
            _api = api;
            _filePath = filePath;
        }

        public async Task<SaveOutcome> SaveAsync(PendingBooking b)
        {
            BookingResult r = await _api.CreateBookingAsync(b.Name, b.Phone, b.ServiceId, b.Date, b.Notes)
                                        .ConfigureAwait(false);
            if (r == BookingResult.Saved) return SaveOutcome.Saved;
            if (r == BookingResult.Rejected) return SaveOutcome.Rejected;

            await _lock.WaitAsync().ConfigureAwait(false);
            try
            {
                var list = Read(_filePath);
                list.Add(b);
                Write(_filePath, list);
            }
            finally { _lock.Release(); }
            return SaveOutcome.QueuedOffline;
        }

        // Call on app start and from a Timer (e.g. every 60 seconds).
        public async Task FlushAsync()
        {
            await _lock.WaitAsync().ConfigureAwait(false);
            try
            {
                var list = Read(_filePath);
                if (list.Count == 0) return;

                var left = new List<PendingBooking>();
                var rejected = new List<PendingBooking>();
                foreach (var b in list)
                {
                    BookingResult r = await _api.CreateBookingAsync(b.Name, b.Phone, b.ServiceId, b.Date, b.Notes)
                                                .ConfigureAwait(false);
                    if (r == BookingResult.Failed) left.Add(b);
                    else if (r == BookingResult.Rejected) rejected.Add(b);   // never retried
                }
                Write(_filePath, left);

                if (rejected.Count > 0)
                {
                    string rejPath = _filePath + ".rejected";
                    var old = Read(rejPath);
                    old.AddRange(rejected);
                    Write(rejPath, old);
                }
            }
            finally { _lock.Release(); }
        }

        private static List<PendingBooking> Read(string path)
        {
            if (!File.Exists(path)) return new List<PendingBooking>();
            var list = JsonConvert.DeserializeObject<List<PendingBooking>>(File.ReadAllText(path));
            return list ?? new List<PendingBooking>();
        }

        private static void Write(string path, List<PendingBooking> list)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(list));
        }
    }
}