using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using DevExpress.Utils.Extensions;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Management;
using DevExpress.Utils.About;
using DevExpress.XtraGrid.Views.Grid;

namespace el_shabander.pl
{
    public partial class frm_whats : Form
    {

        DB_BarbershopEntities db = new DB_BarbershopEntities();
        bl.methods methods = new bl.methods();
        public frm_whats()
        {
            InitializeComponent();

            el_shabander.DB_BarbershopEntities dbContext = new el_shabander.DB_BarbershopEntities();

            // ← جلب عملاء tb_booking بدون تكرار برقم التليفون
            var uniqueCustomers = dbContext.tb_booking
                .AsEnumerable()
                .GroupBy(x => x.cus_phone?.Trim())
                .Where(g => !string.IsNullOrWhiteSpace(g.Key))
                .Select(g => g.OrderByDescending(x => x.booking_date).First())
                .Select(x => new
                {
                    cus_name = x.cus_name,
                    cus_phone = x.cus_phone,
                    آخر_حجز = x.booking_date
                })
                .OrderBy(x => x.cus_name)
                .ToList();

            gridControl1.DataSource = uniqueCustomers;
        }





        private void frm_setting_Load(object sender, EventArgs e)
        {
           
           
        }
      
        
       

       
       

          

       

        private void btnSendWhatsApp_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text.Trim(); // الرسالة المراد إرسالها

            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("يرجى إدخال الرسالة!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // جلب إعدادات الشركة
            var setting = db.AppSettings.FirstOrDefault(s => s.id == 1);
            string companyName = setting != null ? setting.namecomp.Trim() : "شركتنا";
            string companyAddress = setting != null ? setting.address.Trim() : "العنوان غير متوفر";
            string contactNumber = setting != null ? setting.phonenam.Trim() : "0123456789"; // رقم الهاتف

            // وضع اسم الشركة بين 💡💡 و **Bold**
            string formattedCompanyName = $"💡 **{companyName}** 💡\n━━━━━━\n";

            // تقسيم الرسالة إلى سطور ومعرفة نوعها لإضافة الأيقونات المناسبة
            string[] messageLines = txtMessage.Text.Trim().Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < messageLines.Length; i++)
            {
                string line = messageLines[i];

                // التحقق من نوع الرسالة وإضافة أيقونة مناسبة
                if (line.Contains("عرض") || line.Contains("خاص"))
                {
                    line = $"🔥 {line} 🔥";  // عرض خاص
                }
                else if (line.Contains("تخفيض") || line.Contains("خصم"))
                {
                    line = $"💰 {line} 💰";  // تخفيضات
                }
                else if (line.Contains("تنبيه") || line.Contains("اشعار"))
                {
                    line = $"⚠️ {line} ⚠️";  // إشعار مهم
                }

                // إضافة 🔹 و 🔸 بالتناوب
                messageLines[i] = (i % 2 == 0 ? "🔹 " : "🔸 ") + line;
            }

            // إعادة تجميع السطور بعد التنسيق
            string formattedMessageBody = string.Join("\n", messageLines);

            // إضافة العنوان مع **Bold** وأيقونة 📍
            string formattedAddress = $"\n━━━━━━\n📍 **زورونا في:** {companyAddress}";

            // إضافة رقم الهاتف مع أيقونة 📞
            string formattedContact = $"\n📞 **للاستفسار:** {contactNumber}";

            // دمج الرسالة النهائية
            string formattedMessage = $"{formattedCompanyName}{formattedMessageBody}{formattedAddress}{formattedContact}";

            // ترميز الرسالة لواتساب
            formattedMessage = Uri.EscapeDataString(formattedMessage);

            // قائمة بمفاتيح الدول
            Dictionary<string, string> countryCodes = new Dictionary<string, string>
    {
        { "20", "+20" }, // مصر
        { "966", "+966" }, // السعودية
        { "971", "+971" }, // الإمارات
        { "965", "+965" }, // الكويت
        { "974", "+974" }, // قطر
        { "973", "+973" }, // البحرين
        { "968", "+968" }, // عمان
        { "962", "+962" }, // الأردن
        { "963", "+963" }, // سوريا
        { "964", "+964" }, // العراق
        { "218", "+218" }, // ليبيا
        { "212", "+212" }, // المغرب
        { "213", "+213" }, // الجزائر
        { "216", "+216" }, // تونس
        { "1", "+1" }, // أمريكا وكندا
        { "44", "+44" }, // بريطانيا
        { "49", "+49" }, // ألمانيا
        { "33", "+33" }, // فرنسا
        { "39", "+39" }, // إيطاليا
        { "34", "+34" }, // إسبانيا
    };

            string defaultCountryCode = "+20"; // المفتاح الافتراضي في حالة عدم التعرف على الدولة

            // جلب الأرقام المحددة من الـ GridControl
            GridView view = gridControl1.MainView as GridView;
            if (view == null) return;

            var selectedNumbers = new List<string>();
            int[] selectedRows = view.GetSelectedRows();

            foreach (int rowIndex in selectedRows)
            {
                string phoneNumber = view.GetRowCellValue(rowIndex, "cus_phone")?.ToString();

                if (!string.IsNullOrEmpty(phoneNumber))
                {
                    selectedNumbers.Add(phoneNumber.Trim().Replace(" ", ""));
                }
            }

            if (selectedNumbers.Count == 0)
            {
                MessageBox.Show("من فضلك حدد أرقام لإرسال الرسائل.");
                return;
            }

            foreach (var number in selectedNumbers)
            {
                // تقسيم الأرقام إذا كانت مفصولة بـ "/" أو "," أو "-"
                string[] phoneNumbers = number.Split(new char[] { '/', ',', '-' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string rawNumber in phoneNumbers)
                {
                    string formattedNumber = rawNumber.Trim().Replace(" ", "");

                    if (!formattedNumber.StartsWith("+")) // إذا لم يكن الرقم يحتوي على مفتاح دولة
                    {
                        string countryCode = defaultCountryCode; // القيمة الافتراضية

                        foreach (var entry in countryCodes)
                        {
                            if (formattedNumber.StartsWith(entry.Key))
                            {
                                countryCode = entry.Value;
                                formattedNumber = formattedNumber.Substring(entry.Key.Length);
                                break;
                            }
                        }

                        formattedNumber = countryCode + formattedNumber;
                    }

                    string url = $"whatsapp://send?phone={formattedNumber}&text={formattedMessage}";

                    var psi = new System.Diagnostics.ProcessStartInfo
                    {
                        UseShellExecute = true,
                        FileName = url
                    };

                    try
                    {
                        System.Diagnostics.Process.Start(psi);
                        System.Threading.Thread.Sleep(3000); // تأخير بين الرسائل
                        SendKeys.SendWait("{ENTER}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"فشل في إرسال الرسالة إلى الرقم {formattedNumber}: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }

}
