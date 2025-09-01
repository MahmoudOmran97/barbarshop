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

namespace el_shabander.pl
{
    public partial class frm_login : Form
    {
        DB_restoraintEntities db = new DB_restoraintEntities();
        tb_user tB_user = new tb_user();
        main main = new main();
        bl.methods methods = new bl.methods();
        private bool saveButtonClicked = false;
        //pl.frm_supp frm_Cat = new frm_supp();

        public frm_login()

        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            toast toast = new toast();
            dialog dialog = new dialog();
            if (edt_pass.Text == "")
            {
                dialog.Width = this.Width;
                dialog.txt_capthion.Text = "  برجاء ادخال كلمة المرور";
                dialog.Show();
            }
            else
            {

                var tB_user = db.tb_user.Where(x => (x.user_name == edt_name.Text || x.user_mail == edt_name.Text) && x.user_pass == edt_pass.Text).FirstOrDefault();

                if (tB_user != null)
                {
                    // التحقق من حالة المستخدم
                    if (tB_user.user_state == "مفتوح")
                    {
                        MessageBox.Show("  هذا الحساب مفتوح من قبل حاول مرة اخرى");
                        tB_user.user_state = "مغلق";
                        db.Entry(tB_user).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        // تحديث حالة المستخدم إلى "مفتوح"
                        tB_user.user_state = "مفتوح";
                        db.Entry(tB_user).State = System.Data.Entity.EntityState.Modified;

                        // تحديث واجهة المستخدم
                        main.la_username.Text = tB_user.user_name;
                        main.la_roll.Text = tB_user.user_roll;

                        // التحقق من الصورة
                        if (tB_user.user_image != null)
                        {
                           
                            main.pic_cover.Image = bl.methods.convert_image(tB_user.user_image);
                        }

                        main.Enabled = true;

                        // حفظ التغييرات في قاعدة البيانات
                        try
                        {
                            db.SaveChanges();
                            //  MessageBox.Show("تم حفظ التغييرات بنجاح");
                            main.CurrentUser = tB_user; // تعيين المستخدم الحالي في النموذج الرئيسي
                            main.Show();
                            saveButtonClicked = true;
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"خطأ في حفظ التغييرات: {ex.Message}");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("فشل تسجيل الدخول");
                }


            }
        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }






        private void frm_login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saveButtonClicked)
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    // تنفيذ الكود الخاص بالزر الذي تريد تأثيره فقط
                    // هنا يمكنك وضع الكود الذي تريده
                    Application.Exit();
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
        private void edt_name_Enter(object sender, EventArgs e)
        {
            if (edt_name.Text == "Username")
            {
                edt_name.Text = "";
                edt_name.ForeColor = Color.Black; // تغيير اللون للنص الحقيقي
            }
        }

        // حدث مغادرة TextBox لاسم المستخدم
        private void edt_name_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_name.Text))
            {
                edt_name.Text = "Username";
                edt_name.ForeColor = Color.Gray; // تغيير اللون للنص الافتراضي
            }
        }

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
            if (che_us.Checked)
            {
                // حفظ اسم المستخدم وكلمة المرور في إعدادات التطبيق
                Properties.Settings.Default.Username = edt_name.Text;
                Properties.Settings.Default.Password2 = edt_pass.Text;
                Properties.Settings.Default.RememberMe = true; // تفعيل تذكر المستخدم
                Properties.Settings.Default.Save(); // حفظ الإعدادات
            }
            else
            {
                // إزالة اسم المستخدم وكلمة المرور من الإعدادات
                Properties.Settings.Default.Username = string.Empty;
                Properties.Settings.Default.Password2 = string.Empty;
                Properties.Settings.Default.RememberMe = false; // تعطيل تذكر المستخدم
                Properties.Settings.Default.Save();
            }
        }

        private void frm_login_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.RememberMe)
            {
                edt_name.Text = Properties.Settings.Default.Username;
                edt_pass.Text = Properties.Settings.Default.Password2;
                che_us.Checked = true; // تحديد CheckEdit إذا تم حفظ المعلومات
                edt_name.ForeColor = Color.Black;
                edt_pass.ForeColor = Color.Black;
                edt_pass.PasswordChar = '*';
            }
            else
            {
                edt_name.Text = "Username"; // النص الافتراضي
                edt_pass.Text = "Password";
                edt_name.ForeColor = Color.Gray;
                edt_pass.ForeColor = Color.Gray; // النص الافتراضي
                che_us.Checked = false;
                edt_pass.PasswordChar = '*';
            }

        }

        private void edt_pass_TextChanged(object sender, EventArgs e)
        {
            edt_pass.PasswordChar = '*';
        }
       
        
        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pl.frm_changepass frm_supp_Add = new frm_changepass();
            
            frm_supp_Add.Show();
            saveButtonClicked = true;
            this.Close();
        }
    }
}
