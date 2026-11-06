using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using el_shabander.epl;
using DevExpress.XtraGrid.Views.Grid;

namespace el_shabander.pl
{
    public partial class frm_booking : Form
    {
        DB_BarbershopEntities db = new DB_BarbershopEntities();
        Session session = new Session();
        bl.methods methods = new bl.methods();
        toast toast = new toast();
        tb_user tb_User = new tb_user();
        int id;
        private System.Windows.Forms.Timer timerSync = new System.Windows.Forms.Timer();
        public class ApiBooking
        {
            public int Id { get; set; }
            public string CusName { get; set; }
            public string CusPhone { get; set; }
            public DateTime BookingDate { get; set; }
        }
        public frm_booking()
        {
            InitializeComponent();
            timerSync.Interval = 30000; // كل 30 ثانية
            timerSync.Tick += TimerSync_Tick;
            timerSync.Start();
            el_shabander.DB_BarbershopEntities dbContext = new el_shabander.DB_BarbershopEntities();
            dbContext.tb_booking.LoadAsync().ContinueWith(loadTask =>
            {
                gridControl1.DataSource = dbContext.tb_booking.Local.ToBindingList();
            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            gridView1.OptionsBehavior.Editable = false;
        }
        private async void TimerSync_Tick(object sender, EventArgs e)
        {
            try
            {
                using (var client = new System.Net.Http.HttpClient())
                {
                    var response = await client.GetAsync(
                        "https://almaystro.runasp.net/api/booking/unread");

                    if (!response.IsSuccessStatusCode) return;

                    var json = await response.Content.ReadAsStringAsync();

                    var list = Newtonsoft.Json.JsonConvert
                        .DeserializeObject<List<ApiBooking>>(json);

                    if (list == null || list.Count == 0) return;

                    using (var dbLocal = new DB_BarbershopEntities())
                    {
                        int added = 0;
                        foreach (var item in list)
                        {
                            bool existsInDb = dbLocal.tb_booking.Any(x =>
          x.cus_name == item.CusName &&
          x.cus_phone == item.CusPhone &&
          DbFunctions.TruncateTime(x.booking_date) == DbFunctions.TruncateTime(item.BookingDate));

                            // 2. شيك في الـ Local (الأشياء اللي لسه مضافه في اللوب ده ومتحفظتش)
                            bool existsInLocal = dbLocal.tb_booking.Local.Any(x =>
                                x.cus_name == item.CusName &&
                                x.cus_phone == item.CusPhone &&
                                DbFunctions.TruncateTime(x.booking_date) == DbFunctions.TruncateTime(item.BookingDate));

                            if (existsInDb || existsInLocal) continue;

                            DateTime date = item.BookingDate.Date;

                            int lastQueue = dbLocal.tb_booking
                                .Where(x => DbFunctions.TruncateTime(x.booking_date) == date)
                                .Any()
                                    ? (dbLocal.tb_booking
                                        .Where(x => DbFunctions.TruncateTime(x.booking_date) == date)
                                        .Max(x => x.queue_number) ?? 0)
                                    : 0;

                            dbLocal.tb_booking.Add(new tb_booking
                            {
                                cus_name = item.CusName,
                                cus_phone = item.CusPhone,
                                booking_date = item.BookingDate,
                                queue_number = lastQueue + 1,
                                status = "انتظار",
                                created_at = DateTime.Now
                            });

                            added++;
                        }

                        if (added > 0)
                        {
                            // ========== إضافة Notification ==========
                            foreach (var item in list)
                            {
                                var notfication = new Notfication();
                                string msg = $"حجز جديد من الموقع - العميل: {item.CusName} | الهاتف: {item.CusPhone} | التاريخ: {item.BookingDate:dd/MM/yyyy}";
                                notfication.notfication1 = msg;
                                notfication.CreatedAt = DateTime.Now;
                                dbLocal.Notfications.Add(notfication);
                            }

                            dbLocal.SaveChanges();

                            this.Invoke(new Action(() => {
                               updata_data();
                            }));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // مش هيوقف البرنامج لو في مشكلة نت
                System.Diagnostics.Debug.WriteLine($"Sync Error: {ex.Message}");
            }
        }
        public void updata_data()
        {
            db = new DB_BarbershopEntities();

            // ← يجيب حجوزات اليوم فقط عند الفتح
            DateTime today = DateTime.Today;
            gridControl1.DataSource = db.tb_booking
                .Where(x => DbFunctions.TruncateTime(x.booking_date) == today)
                .OrderBy(x => x.queue_number)
                .ToList();
           // gridControl1.DataSource = db.tb_booking.ToList();

            // 3. إجبار الواجهة على إعادة الرسم
            gridControl1.RefreshDataSource();
            ApplyArabicCulture();
            SetArabicDateFormat(edt_from);
          //  SetArabicDateFormat(edt_from2);
            edt_from2.Format = DateTimePickerFormat.Custom;
            edt_from2.CustomFormat = "dd/MM/yyyy hh:mm:ss tt"; // التاريخ والوقت
            edt_from2.ShowUpDown = true;
            LoadQueue();
          
        }

        private void frm_safe_as_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        }

        private void ApplyArabicCulture()
        {
            CultureInfo arabicCulture = new CultureInfo("ar-EG");
            Thread.CurrentThread.CurrentCulture = arabicCulture;
            Thread.CurrentThread.CurrentUICulture = arabicCulture;
        }

        private void SetArabicDateFormat(DateTimePicker picker)
        {
            picker.Format = DateTimePickerFormat.Custom;
            picker.CustomFormat = GetArabicFormattedDate(picker.Value);
            picker.RightToLeft = RightToLeft.No;
            picker.RightToLeftLayout = false;
            picker.ValueChanged += (s, e) =>
            {
                picker.CustomFormat = GetArabicFormattedDate(picker.Value);
            };
        }

        private string GetArabicFormattedDate(DateTime date)
        {
            string[] arabicDays = { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" };
            string[] arabicMonths = { "", "يناير", "فبراير", "مارس", "أبريل", "مايو", "يونيو", "يوليو", "أغسطس", "سبتمبر", "أكتوبر", "نوفمبر", "ديسمبر" };
            string dayName = arabicDays[(int)date.DayOfWeek];
            string monthName = arabicMonths[date.Month];
            return $"{dayName}, {date.Day} {monthName} {date.Year}";
        }

        // ========== تلوين صفوف الجدول حسب الحالة ==========
        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0)
            {
                var status = view.GetRowCellValue(e.RowHandle, "status")?.ToString();
                switch (status)
                {
                    case "انتظار":
                        e.Appearance.BackColor = Color.LightYellow;
                        e.Appearance.ForeColor = Color.Black;
                        break;
                    case "يتخدم":
                        e.Appearance.BackColor = Color.LightGreen;
                        e.Appearance.ForeColor = Color.Black;
                        break;
                    case "تم":
                        e.Appearance.BackColor = Color.LightBlue;
                        e.Appearance.ForeColor = Color.Black;
                        break;
                    case "ملغى":
                        e.Appearance.BackColor = Color.LightCoral;
                        e.Appearance.ForeColor = Color.Black;
                        break;
                }
            }
        }

        // ========== تحميل بيانات الانتظار ==========
        private void LoadQueue()
        {
            DateTime today = DateTime.Today;

            var next = db.tb_booking
                .Where(x => x.status == "انتظار")
                .OrderBy(x => DbFunctions.TruncateTime(x.booking_date))  // ← أولوية التاريخ
                .ThenBy(x => x.queue_number)                              // ← ثم رقم الدور
                .FirstOrDefault();

            int count = db.tb_booking
                .Count(x => x.status == "انتظار"
                       && DbFunctions.TruncateTime(x.booking_date) == today); // ← عدد انتظار اليوم فقط

            if (next != null)
            {
                lbl_next.Text =
      $"👤 الدور على: {next.cus_name}  |  رقم: {next.queue_number}\n" +
      $"📅 التاريخ: {next.booking_date:dd/MM/yyyy}";
                lbl_next.ForeColor = Color.DarkGreen;
            }
            else
            {
                lbl_next.Text = "لا يوجد عملاء في الانتظار";
                lbl_next.ForeColor = Color.Gray;
            }

            lbl_count.Text = $"عدد المنتظرين اليوم: {count}";
        }

        // ========== إضافة عميل - الكونتر يومي ولا يرجع ==========
        private void btn_add_booking_Click(object sender, EventArgs e)
        {
            // التحقق من اسم العميل
            if (string.IsNullOrWhiteSpace(txt_cusname.Text))
            {
                MessageBox.Show("ادخل اسم العميل", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_cusname.Focus();
                return;
            }

            // ← التحقق من رقم التليفون: مطلوب و11 رقم بالظبط
            string phone = txt_phone.Text.Trim();
            if (string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("رقم الهاتف مطلوب", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_phone.Focus();
                return;
            }
            if (!phone.All(char.IsDigit) || phone.Length != 11)
            {
                MessageBox.Show("رقم الهاتف لازم يكون 11 رقم بالظبط", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_phone.Clear();
                txt_phone.Focus();
                return;
            }

            DateTime selectedDate = edt_from2.Value.Date;

            int lastQueue = db.tb_booking
                .Where(x => DbFunctions.TruncateTime(x.booking_date) == selectedDate)
                .Any()
                    ? (db.tb_booking
                        .Where(x => DbFunctions.TruncateTime(x.booking_date) == selectedDate)
                        .Max(x => x.queue_number) ?? 0)
                    : 0;

            var booking = new tb_booking
            {
                cus_name = txt_cusname.Text.Trim(),
                cus_phone = phone,
                booking_date = edt_from2.Value,
                queue_number = lastQueue + 1,
                status = "انتظار",
                notes = txt_notes.Text.Trim(),
                created_at = DateTime.Now
            };

            db.tb_booking.Add(booking);
            db.SaveChanges();

            txt_cusname.Clear();
            txt_phone.Clear();
            txt_notes.Clear();
            txt_cusname.Focus();
            ClearFields();
            RefreshByDate(selectedDate);

            MessageBox.Show(
                $"تم تسجيل: {booking.cus_name}\nرقم الدور: {booking.queue_number}\nتاريخ: {selectedDate:dd/MM/yyyy}",
                "تم الحجز", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void RefreshByDate(DateTime date)
        {
            db = new DB_BarbershopEntities();
            gridControl1.DataSource = db.tb_booking
                .Where(x => DbFunctions.TruncateTime(x.booking_date) == date)
                .OrderBy(x => x.queue_number)
                .ToList();
            LoadQueue();
        }
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            updata_data();
        }

        // ========== إلغاء الحجز - يلغي الصف المحدد فقط ==========
        private void btn_skip_Click_Click(object sender, EventArgs e)
        {
            int rowHandle = gridView1.FocusedRowHandle;

            if (rowHandle < 0)
            {
                MessageBox.Show("اختر صف من الجدول أولاً", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedId = gridView1.GetRowCellValue(rowHandle, "id");
            if (selectedId == null) return;

            int bookingId = Convert.ToInt32(selectedId);

            var booking = db.tb_booking.Find(bookingId);

            if (booking == null)
            {
                MessageBox.Show("لم يتم العثور على الحجز");
                return;
            }

            // 🔴 منع الإلغاء لو تم أو يتخدم
            if (booking.status == "تم" || booking.status == "يتخدم")
            {
                MessageBox.Show("لا يمكن إلغاء حجز حالته (تم أو يتخدم)",
                    "ممنوع", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (booking.status == "ملغى")
            {
                MessageBox.Show("هذا الحجز ملغى بالفعل", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var rs = MessageBox.Show(
                $"إلغاء حجز: {booking.cus_name} ؟",
                "تأكيد الإلغاء", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                booking.status = "ملغى";
                db.SaveChanges();
                updata_data();

                MessageBox.Show("تم إلغاء الحجز بنجاح", "تم",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ClearFields()
        {

            edt_from2.Value = DateTime.Now;
        }
        // ========== البحث بالتاريخ ==========
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = edt_from.Value.Date;
            RefreshByDate(selectedDate);

            int count = db.tb_booking
                .Count(x => DbFunctions.TruncateTime(x.booking_date) == selectedDate);

            if (count == 0)
                MessageBox.Show($"لا توجد حجوزات بتاريخ {selectedDate:dd/MM/yyyy}",
                    "بحث", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show($"تم العثور على {count} حجز بتاريخ {selectedDate:dd/MM/yyyy}",
                    "نتيجة البحث", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e) { }
        private void gridControl1_Click(object sender, EventArgs e) { }
        private void frm_safe_as_Activated(object sender, EventArgs e) { }
        private void simpleButton1_Click_1(object sender, EventArgs e) { }

        private void whats_Click(object sender, EventArgs e)
        {
            // ========== جلب العميل المحدد في الجريد ==========
            int rowHandle = gridView1.FocusedRowHandle;

            if (rowHandle < 0)
            {
                MessageBox.Show("اختر عميل من الجدول أولاً", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedId = gridView1.GetRowCellValue(rowHandle, "id");
            if (selectedId == null) return;

            int bookingId = Convert.ToInt32(selectedId);
            var booking = db.tb_booking.Find(bookingId);

            if (booking == null)
            {
                MessageBox.Show("لم يتم العثور على بيانات العميل");
                return;
            }

            string phone = booking.cus_phone?.Trim().Replace(" ", "");
            if (string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("لا يوجد رقم هاتف لهذا العميل", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ========== جلب بيانات الصالون ==========
            var setting = db.AppSettings.FirstOrDefault(s => s.id == 1);
            string companyName = setting?.namecomp?.Trim() ?? "الصالون";
            string companyAddress = setting?.address?.Trim() ?? "";
            string companyPhone = setting?.phonenam?.Trim() ?? "";

            // ========== بناء الرسالة ==========
            string message =
                $"💈 *{companyName}* 💈\n" +
                $"━━━━━━━━━━━━\n" +
                $"السيد: *{booking.cus_name}*\n\n" +
                $"🔔 تنبيه: دورك اقترب!\n" +
                $"رقم دورك: *{booking.queue_number}*\n\n" +
                $"يرجى التوجه إلى الصالون الآن.\n" +
                $"━━━━━━━━━━━━\n";

            if (!string.IsNullOrWhiteSpace(companyAddress))
                message += $"📍 *العنوان:* {companyAddress}\n";

            if (!string.IsNullOrWhiteSpace(companyPhone))
                message += $"📞 *للتواصل:* {companyPhone}\n";

            message += $"━━━━━━━━━━━━\n";
            message += $"شكراً لاختيارك {companyName} 🙏";

            // ========== تنسيق رقم الهاتف ==========
            if (!phone.StartsWith("+"))
            {
                // لو الرقم بيبدأ بـ 0 → استبدلها بمفتاح مصر
                if (phone.StartsWith("0"))
                    phone = "+2" + phone;
                else
                    phone = "+2" + phone; // افتراضي مصر
            }

            // ========== فتح واتساب ديسكتوب ==========
            string encodedMessage = Uri.EscapeDataString(message);
            string url = $"whatsapp://send?phone={phone}&text={encodedMessage}";

            var psi = new System.Diagnostics.ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = url
            };

            try
            {
                System.Diagnostics.Process.Start(psi);

                // انتظر 3 ثواني وابعت ENTER تلقائياً
                System.Threading.Thread.Sleep(3000);
                SendKeys.SendWait("{ENTER}");

                MessageBox.Show(
                    $"تم فتح واتساب لإرسال التنبيه إلى {booking.cus_name}",
                    "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"فشل فتح واتساب: {ex.Message}",
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            int rowHandle = gridView1.FocusedRowHandle;

            if (rowHandle < 0)
            {
                MessageBox.Show("اختر صف من الجدول أولاً", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedId = gridView1.GetRowCellValue(rowHandle, "id");
            if (selectedId == null) return;

            int bookingId = Convert.ToInt32(selectedId);

            var booking = db.tb_booking.Find(bookingId);

            if (booking == null)
            {
                MessageBox.Show("لم يتم العثور على الحجز");
                return;
            }

            // 🔴 منع التعديل
            if (booking.status == "تم" || booking.status == "يتخدم")
            {
                MessageBox.Show("لا يمكن تعديل حجز حالته (تم أو يتخدم)",
                    "ممنوع", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var editForm = new frm_cus_addtakeway();
            editForm.Text = "تعديل حجز";

            editForm.booking_id = bookingId;

            editForm.Load += (s, ev) =>
            {
                editForm.edt_name.Text = booking.cus_name;
                editForm.edt_phone.Text = booking.cus_phone;
                editForm.txt_notes.Text = booking.notes;
                editForm.edt_from2.Value = booking.booking_date ?? DateTime.Now;
            };

            editForm.FormClosed += (s, ev) =>
            {
                updata_data();
            };

            editForm.ShowDialog();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var selectedRows = gridView1.GetSelectedRows();

            if (selectedRows.Length == 0)
            {
                MessageBox.Show("حدد صف واحد على الأقل للحذف", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedIds = new List<int>();
            var blockedNames = new List<string>();

            foreach (var rowHandle in selectedRows)
            {
                var idVal = gridView1.GetRowCellValue(rowHandle, "id");
                if (idVal == null) continue;

                int id = Convert.ToInt32(idVal);
                var booking = db.tb_booking.Find(id);

                if (booking == null) continue;

                // 🔴 منع الحذف
                if (booking.status == "تم" || booking.status == "يتخدم")
                {
                    blockedNames.Add(booking.cus_name);
                    continue;
                }

                selectedIds.Add(id);
            }

            if (selectedIds.Count == 0)
            {
                MessageBox.Show("كل العناصر المحددة لا يمكن حذفها لأنها (تم / يتخدم)",
                    "ممنوع", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rs = MessageBox.Show(
                $"هتحذف {selectedIds.Count} حجز ؟\nالحذف نهائي ولا يمكن التراجع!",
                "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (rs == DialogResult.Yes)
            {
                var toDelete = db.tb_booking
                    .Where(x => selectedIds.Contains(x.id))
                    .ToList();

                db.tb_booking.RemoveRange(toDelete);
                db.SaveChanges();

                updata_data();

                MessageBox.Show($"تم حذف {toDelete.Count} حجز بنجاح",
                    "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (blockedNames.Count > 0)
            {
                MessageBox.Show("تم تجاهل بعض الحجوزات لأنها (تم / يتخدم)",
                    "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}