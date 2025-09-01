using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using el_shabander.epl;

namespace el_shabander.pl
{
    public partial class frm_user_add : Form
    {
        DB_restoraintEntities db = new DB_restoraintEntities();
        tb_user tB_user = new tb_user();
        bl.methods methods = new bl.methods();
       
        //pl.frm_supp frm_Cat = new frm_supp();
        public int id;
        public frm_user_add  ()

        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            toast toast = new toast();
            dialog dialog = new dialog();

            if (string.IsNullOrEmpty(edt_name.Text))
            {
                dialog.Width = this.Width;
                dialog.txt_capthion.Text = "اسم المستخدم مطلوب";
                dialog.Show();
                return;
            }

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

            if (string.IsNullOrEmpty(edt_mail.Text))
            {
                dialog.Width = this.Width;
                dialog.txt_capthion.Text = "الإيميل مطلوب";
                dialog.Show();
                return;
            }

            if (id == 0)
            {
                tB_user.user_name = edt_name.Text;
                tB_user.user_pass = edt_pass.Text;
                tB_user.user_roll = edt_roll.Text;
                tB_user.user_state = "مغلق";
                tB_user.user_mail = edt_mail.Text;
                tB_user.user_image = bl.methods.convert_byte(pic_cover.Image);

                db.tb_user.Add(tB_user);
                db.SaveChanges();

                toast.Width = this.Width;
                toast.txt_caption.Text = "تم إضافة مستخدم جديد";
                toast.Show();
                this.Close();
            }
            else
            {
                var existingUser = db.tb_user.FirstOrDefault(x => x.id == id);
                if (existingUser != null)
                {
                    existingUser.user_name = edt_name.Text;
                    existingUser.user_pass = edt_pass.Text;
                    existingUser.user_roll = edt_roll.Text;
                    existingUser.user_mail = edt_mail.Text;
                    existingUser.user_image = bl.methods.convert_byte(pic_cover.Image);

                    // التحقق من حالة المستخدم
                    existingUser.user_state = (existingUser.user_state == "مغلق") ? "مغلق" : "مفتوح";

                    db.Entry(existingUser).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    toast.Width = this.Width;
                    toast.txt_caption.Text = "تم تعديل المستخدم الحالي";
                    toast.Show();
                    this.Close();
                }
                else
                {
                    dialog.Width = this.Width;
                    dialog.txt_capthion.Text = "المستخدم غير موجود للتعديل";
                    dialog.Show();
                }
            }
        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void btnAddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select an Image",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",  // أنواع الصور المدعومة
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)  // مجلد الصور الافتراضي
            };

            // إظهار نافذة اختيار الملفات والتحقق إذا كان المستخدم قد اختار صورة
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // تحميل الصورة المختارة في PictureEdit
                pic_cover.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void frm_user_add_Load(object sender, EventArgs e)
        {
            if(id==0)
            {
                edt_roll.Text="مدير";
            }
            else
            {
                edt_name.Enabled = false;
            }
        }
    }
}
