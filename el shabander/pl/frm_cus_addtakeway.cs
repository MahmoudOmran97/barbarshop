using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using el_shabander.epl;

namespace el_shabander.pl
{
    public partial class frm_cus_addtakeway : Form
    {
        DB_BarbershopEntities db = new DB_BarbershopEntities();
        bl.methods methods = new bl.methods();
        public int id;
        public int booking_id = 0;

        //pl.frm_supp frm_Cat = new frm_supp();
       
        public frm_cus_addtakeway()

        {
            InitializeComponent();
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
        private void btn_add_Click(object sender, EventArgs e)
        {
            toast toast = new toast();

            if (string.IsNullOrWhiteSpace(edt_name.Text))
            {
                MessageBox.Show("ادخل اسم العميل", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                edt_name.Focus();
                return;
            }

            string phone = edt_phone.Text.Trim();
            if (string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("رقم الهاتف مطلوب", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                edt_phone.Focus();
                return;
            }
            if (!phone.All(char.IsDigit) || phone.Length != 11)
            {
                MessageBox.Show("رقم الهاتف لازم يكون 11 رقم بالظبط", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                edt_phone.Clear();
                edt_phone.Focus();
                return;
            }

            DateTime selectedDate = edt_from2.Value.Date;

            if (booking_id == 0)
            {
                // ========== وضع الإضافة ==========
                int lastQueue = db.tb_booking
                    .Where(x => DbFunctions.TruncateTime(x.booking_date) == selectedDate)
                    .Any()
                        ? (db.tb_booking
                            .Where(x => DbFunctions.TruncateTime(x.booking_date) == selectedDate)
                            .Max(x => x.queue_number) ?? 0)
                        : 0;

                var booking = new tb_booking
                {
                    cus_name = edt_name.Text.Trim(),
                    cus_phone = phone,
                    booking_date = edt_from2.Value,
                    queue_number = lastQueue + 1,
                    status = "انتظار",
                    notes = txt_notes.Text.Trim(),
                    created_at = DateTime.Now
                };

                db.tb_booking.Add(booking);
                db.SaveChanges();

                MessageBox.Show(
                    $"تم تسجيل: {booking.cus_name}\nرقم الدور: {booking.queue_number}",
                    "تم الحجز", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // ========== وضع التعديل ==========
                var booking = db.tb_booking.Find(booking_id);
                if (booking == null)
                {
                    MessageBox.Show("لم يتم العثور على الحجز");
                    return;
                }

                booking.cus_name = edt_name.Text.Trim();
                booking.cus_phone = phone;
                booking.booking_date = edt_from2.Value;
                booking.notes = txt_notes.Text.Trim();

                db.Entry(booking).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                MessageBox.Show("تم تعديل الحجز بنجاح", "تم",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            toast.txt_caption.Text = booking_id == 0 ? "تم إضافة عميل" : "تم تعديل الحجز";
            toast.Show();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frm_cus_addtakeway_Load(object sender, EventArgs e)
        {
            ApplyArabicCulture();

            SetArabicDateFormat(edt_from2);
            btn_add.Text = booking_id == 0 ? "إضافة" : "حفظ التعديل";
            this.Text = booking_id == 0 ? "اضافة حجز" : "تعديل حجز";
        }
    }
}
