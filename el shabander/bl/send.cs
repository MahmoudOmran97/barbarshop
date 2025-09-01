using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;

namespace el_shabander.bl
{
    class send
    {
        DB_restoraintEntities db = new DB_restoraintEntities();
        public string GetHtmlFromTextBoxContent(string messageContent)
        {
            // جلب محتوى TextBox
            // يمكنك استخدام ToList() للحصول على جميع البيانات
            // تهيئة المتغير المحتوي على الرسالة

            string html = "<html><head><style>";
            html += "@import url('https://fonts.googleapis.com/css2?family=Cairo:wght@700&display=swap');"; // استيراد خط كايرو
            html += "body { font-family: 'Cairo', sans-serif; background: linear-gradient(to right, #38ef7d, #38ef7d); padding: 20px; color: #38ef7d; }"; // تدرج بين الأخضر الفاتح والأخضر الداكن
            html += ".email-container { background-color: #34495e; padding: 30px; border-radius: 15px; max-width: 700px; margin: auto; box-shadow: 0 4px 15px rgba(0, 0, 0, 0.3); color: #ffffff; }";
            html += "h2 { color: #f39c12; text-align: center; font-size: 28px; margin-bottom: 20px; font-weight: bold; }"; // عنوان بلون برتقالي فاتح
            html += "h3 { color: #ecf0f1; text-align: center; font-size: 20px; margin-bottom: 20px; font-weight: bold; }"; // نص توضيحي بلون أبيض فاتح
            html += ".message-box { background-color: #2c3e50; padding: 25px; border-radius: 10px; text-align: center; box-shadow: inset 0 0 15px rgba(0, 0, 0, 0.3); margin: auto; max-width: 600px; font-size: 20px; font-weight: bold; color: #f1c40f; }"; // صندوق الرسالة مع ظل داخلي ولون أصفر
            html += "footer { text-align: center; font-size: 14px; color: #bdc3c7; margin-top: 20px; padding-top: 10px; border-top: 1px solid #7f8c8d; }"; // فوتر بلون رمادي فاتح
            html += "</style></head><body>";

            // إضافة المحتوى إلى الحاوية
            html += "<div class='email-container'>";
            html += "<h2>EngineeCode for Software</h2>"; // العنوان الرئيسي
            html += $"<h3>تنبيه</h3>"; // النص الثانوي
            html += $"<div class='message-box'><p>{messageContent}</p></div>"; // صندوق الرسالة
            html += "<footer>Thank you for using our services. We appreciate your support!</footer>"; // الفوتر
            html += "</div>"; // إغلاق حاوية البريد
            html += "</body></html>";

            return html; // إرجاع المحتوى
        }
        public void SendEmailWithHtmlGridData(string messageContent)
        {
            string htmlContent = GetHtmlFromTextBoxContent(messageContent); // استخراج البيانات كـ HTML
            if (!string.IsNullOrEmpty(htmlContent)) // تحقق من عدم كون المحتوى فارغًا
            {
                SendEmailWithHtml(htmlContent); // إرسال البريد الإلكتروني مع HTML
            } // إرسال البريد الإلكتروني مع HTML
        }
        public void SendEmailWithHtml(string htmlContent)
        {

            var userEmails = db.tb_user
                 .Where(u => u.user_roll == "مدير") // استبدل حسب الحاجة
                 .Select(u => u.user_mail)
                 .ToList();

            // إضافة البريد الثابت
            //userEmails.Add(Properties.Settings.Default.Email);
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("engineecode12@gmail.com");
                // mail.To.Add(userEmail);
                mail.Subject = "تنبيهات";
                mail.Body = htmlContent;
                mail.IsBodyHtml = true;
                smtpServer.Port = 587;
                smtpServer.Credentials = new NetworkCredential("engineecode12@gmail.com", "shjhvhnebtuisfsg");
                smtpServer.EnableSsl = true; // Enable SSL for security
                foreach (var userEmail in userEmails)
                {
                    mail.To.Clear(); // امسح العناوين السابقة
                    mail.To.Add(userEmail); // أضف عنوان البريد الإلكتروني الحالي
                    smtpServer.Send(mail); // أرسل البريد الإلكتروني
                }



            }
            catch (Exception ex)
            {
              
            }
        }

    }
}
