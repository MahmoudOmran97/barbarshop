using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Data.Svg;
using System.Net.Mail;
using System.Net;

using el_shabander.epl;
using System.Data.Entity;

namespace el_shabander.pl
{
    public partial class frm_changepass : Form
    {
        DB_BarbershopEntities db = new DB_BarbershopEntities();
        tb_user tB_user = new tb_user();
        main main = new main();
        bl.methods methods = new bl.methods();
        private bool saveButtonClicked = false;
        sendmailcode sendmailcode = new sendmailcode();
        //pl.frm_supp frm_Cat = new frm_supp();

        public frm_changepass()

        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            dialog dialog = new dialog();
            if (string.IsNullOrEmpty(edt_pass.Text))
            {
                dialog.Width = this.Width;
                dialog.txt_capthion.Text = "كلمة المرور مطلوبة";
                dialog.Show();
                return;
            }

            if (edt_pass.Text.Length < 8)
            {
                dialog.Width = this.Width;
                dialog.txt_capthion.Text = "كلمة المرور يجب ألا تقل عن 8 أحرف";
                dialog.Show();
                return;
            }
            if (string.IsNullOrEmpty(edt_pass2.Text))
            {
                dialog.Width = this.Width;
                dialog.txt_capthion.Text = "تاكيد كلمة المرور مطلوب";
                dialog.Show();
                return;
            }

            if (edt_pass2.Text!= edt_pass.Text)
            {
                dialog.Width = this.Width;
                dialog.txt_capthion.Text = "كلمة المرور غير مطابقة";
                dialog.Show();
                return;
            }


            var tB_user = db.tb_user.Where(x => x.user_mail == edt_name.Text).FirstOrDefault();
            var sendcode= db.sendmailcodes.Where(x => x.user_mail == tB_user.user_mail&&x.code==edt_code.Text).FirstOrDefault();
            if (sendcode!=null)
            {
                tB_user.user_pass = edt_pass.Text;

                db.Entry(tB_user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
               

                db.Entry(sendcode).State = EntityState.Deleted;

                db.SaveChanges();
               
                
                this.Close();

            }
            else
            {
                dialog.txt_capthion.Text = "الكود خطاء";
                dialog.Show();
            }

           

        }




        private void frm_login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saveButtonClicked)
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    frm_login frm_Login = new frm_login();
                    frm_Login.Show();
                }
            }
        }

        private void frm_login_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void frm_login_Click(object sender, EventArgs e)
        {

        }


        private void frm_login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // تنفيذ الإجراءات التي تريدها عند الضغط على هذا المفتاح
                btn_add.PerformClick(); // هنا يتم استدعاء حدث النقر على الزر المعني
            }

        }
       

        // حدث مغادرة TextBox لاسم المستخدم
       

        // حدث دخول إلى TextBox لكلمة المرور
        private void edt_pass_Enter(object sender, EventArgs e)
        {
            if (edt_pass.Text == "Password")
            {
                edt_pass.Text = "";
                edt_pass.ForeColor = Color.Black;
                //edt_pass.UseSystemPasswordChar = true;
                edt_pass.PasswordChar = '*';// إخفاء النص لكلمة المرور
            }
        }

        // حدث مغادرة TextBox لكلمة المرور
        private void edt_pass_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_pass.Text))
            {
                edt_pass.Text = "Password";
                edt_pass.ForeColor = Color.Gray;
                //edt_pass.UseSystemPasswordChar = false; // عرض النص الافتراضي
                edt_pass.PasswordChar = '*';
            }
        }
        private void frm_login_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void frm_login_Activated(object sender, EventArgs e)
        {

        }

        private void che_us_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void frm_login_Load(object sender, EventArgs e)
        {

        }

       
        public string GetHtmlFromTextBoxContent()
        {
            // جلب محتوى TextBox
            var allUsers = db.tb_user.ToList(); // يمكنك استخدام ToList() للحصول على جميع البيانات
            string messageContent = string.Empty; // تهيئة المتغير المحتوي على الرسالة
            bool userFound = false; // علم لتحديد ما إذا تم العثور على المستخدم
            Random random = new Random();
            string code;
            bool isUnique;

            do
            {
                code = random.Next(10000000, 99999999).ToString();
                isUnique = !db.sendmailcodes.Any(x => x.code == code); // التحقق من أن الكود غير مكرر
            }
            while (!isUnique);
           
            
            // استخدام حلقة for للمرور عبر قائمة المستخدمين
            foreach (var ituser in allUsers)
            {
                if ( ituser.user_mail== edt_name.Text)
                {
                    messageContent = code; // الحصول على كلمة المرور
                    userFound = true;
                   
                    break; // الخروج من الحلقة عند العثور على المستخدم
                }
            }
            sendmailcode.user_mail = edt_name.Text;
            sendmailcode.code = code;
            db.sendmailcodes.Add(sendmailcode);
            db.SaveChanges();
            // تحقق مما إذا تم العثور على المستخدم، إذا لم يكن كذلك، أظهر رسالة
            if (!userFound)
            {
                MessageBox.Show("الرجاء ادخال اسم الحساب الصحيح ");
                return string.Empty; // العودة إذا لم يكن هناك محتوى
            }

            // إنشاء هيكل HTML مع تنسيق جديد
            string html = "<html><head><style>";
            html += "@import url('https://fonts.googleapis.com/css2?family=Cairo:wght@700&display=swap');"; // استيراد خط كيرو
            html += "body { font-family: 'Cairo', sans-serif; background: linear-gradient(to right, #8e44ad, #3498db); padding: 20px; color: #ecf0f1; }"; // تدرج بين الأرجواني والأزرق
            html += ".email-container { background-color: rgba(0, 0, 0, 0.8); padding: 30px; border-radius: 15px; max-width: 700px; margin: auto; box-shadow: 0 4px 15px rgba(0, 0, 0, 0.2); color: #3498db; }";
            html += "h2 { color: #e74c3c; text-align: center; font-size: 28px; margin-bottom: 20px; font-weight: bold; }";
            html += "h3 { color: #ecf0f1; text-align: center; font-size: 20px; margin-bottom: 20px; font-weight: bold; }";
            html += ".message-box { background-color: #2c3e50; padding: 25px; border-radius: 10px; text-align: center; box-shadow: inset 0 0 15px rgba(0, 0, 0, 0.3); margin: auto; max-width: 600px; font-size: 20px; font-weight: bold; color: #f1c40f; }";
            html += "footer { text-align: center; font-size: 14px; color: #bdc3c7; margin-top: 20px; padding-top: 10px; border-top: 1px solid #444; }";
            html += "</style></head><body>";

            // إضافة المحتوى إلى الحاوية
            html += "<div class='email-container'>";
            html += "<h2>EngineeCode for Software</h2>";
            html += $"<h3>الكود الخاص بك فى الاسفل</h3>";
            html += $"<div class='message-box'><p>{messageContent}</p></div>"; // النص داخل صندوق مع خط كيرو وتنسيق خاص
            html += "<footer>Thank you for using our services. We appreciate your support!</footer>";
            html += "</div>"; // إغلاق حاوية البريد
            html += "</body></html>";

            return html; // إرجاع المحتوى
        }
        public void SendEmailWithHtmlGridData()
        {
            string htmlContent = GetHtmlFromTextBoxContent(); // استخراج البيانات كـ HTML
            if (!string.IsNullOrEmpty(htmlContent)) // تحقق من عدم كون المحتوى فارغًا
            {
                SendEmailWithHtml(htmlContent); // إرسال البريد الإلكتروني مع HTML
            } // إرسال البريد الإلكتروني مع HTML
        }
        public void SendEmailWithHtml(string htmlContent)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("engineecode12@gmail.com");
                var allUsers = db.tb_user.ToList(); // يمكنك استخدام ToList() للحصول على جميع البيانات

                // استخدام حلقة for للمرور عبر قائمة المستخدمين
                foreach (var ituser in allUsers)
                {
                    if (ituser.user_mail == edt_name.Text)
                    {
                        mail.To.Add(ituser.user_mail); // إضافة البريد الإلكتروني للمستخدم
                        break; // الخروج من الحلقة عند العثور على المستخدم
                    }
                }

                // إضافة البريد الثابت
                mail.Subject = " EngineeCode ";
                mail.Body = htmlContent;
                mail.IsBodyHtml = true;

                smtpServer.Port = 587;
                smtpServer.Credentials = new NetworkCredential("engineecode12@gmail.com", "shjhvhnebtuisfsg");
                smtpServer.EnableSsl = true; // تفعيل SSL لأمان الإرسال

                smtpServer.Send(mail); // إرسال البريد الإلكتروني
                MessageBox.Show("تم ارسال الكود بنجاح.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending email: " + ex.Message);
            }
        }

       

        private void edt_pass_TextChanged_1(object sender, EventArgs e)
        {
            edt_pass.PasswordChar = '*';
        }

        private void edt_pass2_TextChanged(object sender, EventArgs e)
        {
            edt_pass2.PasswordChar = '*';
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var tB_user = db.tb_user.Where(x =>  x.user_mail == edt_name.Text ).FirstOrDefault();
            if (tB_user != null)
            {
                SendEmailWithHtmlGridData();
                edt_name.Enabled = false;

            }else
            {
                MessageBox.Show("هذا الحساب غير موجود");
            }

        }
    }
}
