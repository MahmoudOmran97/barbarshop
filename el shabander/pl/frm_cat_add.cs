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
    public partial class frm_cat_add : Form
    {
        DB_BarbershopEntities db = new DB_BarbershopEntities();
        tb_cat tb_cat = new tb_cat();
        bl.methods methods = new bl.methods();
       
        pl.frm_cat frm_Cat = new frm_cat();
        public int id;
        public frm_cat_add()

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
                dialog.txt_capthion.Text = "اسم الصنف مطلوب";
                dialog.Show();
            }
            else
            {
                // التحقق مما إذا كان اسم الصنف موجودًا بالفعل
                bool isCatExists = db.tb_cat.Any(x => x.cat_name == edt_name.Text && x.id != id);

                if (isCatExists)
                {
                    dialog.Width = this.Width;
                    dialog.txt_capthion.Text = "اسم الصنف موجود من قبل";
                    dialog.Show();
                }
                else
                {
                    if (id == 0) // إضافة صنف جديد
                    {
                        
                        tb_cat.cat_name = edt_name.Text;
                        tb_cat.unit = edt_type.Text;
                        tb_cat.qt = Convert.ToDouble(edt_qt.Text);
                        tb_cat.cat_cover = bl.methods.convert_byte(pic_cover.Image);
                        tb_cat.max_note = Convert.ToDouble(edt_max.Text);
                        db.tb_cat.Add(tb_cat);
                        db.SaveChanges();

                        // تحديث البيانات بعد الإضافة
                        db = new DB_BarbershopEntities();
                        frm_Cat.gridControl1.DataSource = db.tb_cat.ToList();

                        toast.txt_caption.Text = "تم إضافة صنف جديد";
                        toast.Show();
                        this.Close();
                    }
                    else // تعديل صنف موجود
                    {
                        tb_cat = db.tb_cat.Where(x => x.id == id).FirstOrDefault();
                      
                        tb_cat.cat_name = edt_name.Text;
                        tb_cat.unit = edt_type.Text;
                        tb_cat.cat_cover = bl.methods.convert_byte(pic_cover.Image);
                        tb_cat.qt = Convert.ToDouble(edt_qt.Text);
                        tb_cat.max_note = Convert.ToDouble(edt_max.Text);
                        db.Entry(tb_cat).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        // تحديث البيانات بعد التعديل
                        db = new DB_BarbershopEntities();
                        frm_Cat.gridControl1.DataSource = db.tb_cat.ToList();

                        toast.txt_caption.Text = "تم تعديل الصنف";
                        toast.Show();
                        this.Close();
                    }
                }
            }

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void edt_qt_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_qt.Text))
            {
                // إذا كانت القيمة فارغة، يمكنك تعيين القيمة الافتراضية مرة أخرى

                edt_qt.Text = "0";

                // edt_cat.Text = tb_stuk.stuk_cat;

            }
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
    }
}
