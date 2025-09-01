using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Tile;
using el_shabander.epl;

namespace el_shabander.pl
{
    public partial class frm_supp_add : Form
    {
        DB_restoraintEntities db = new DB_restoraintEntities();
        tb_supp tB_supp = new tb_supp();
        bl.methods methods = new bl.methods();
       
        //pl.frm_supp frm_Cat = new frm_supp();
        public int id;
        public frm_supp_add ()

        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            toast toast = new toast();
            dialog dialog = new dialog();
            if (edt_name.Text=="")
            {
               dialog.Width = this.Width;
                dialog.txt_capthion.Text = "  اسم المورد مطلوب";
                dialog.Show();
            }else
            {
                bool supplierExists = db.tb_supp.Any(x => x.supp_name == edt_name.Text && x.id != id);

                if (supplierExists)
                {
                    MessageBox.Show("اسم المورد موجود مسبقًا، الرجاء اختيار اسم آخر.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                tB_supp.supp_phone = string.IsNullOrWhiteSpace(edt_phone.Text) ? "لا يوجد" : edt_phone.Text;
                tB_supp.supp_email = string.IsNullOrWhiteSpace(edt_email.Text) ? "لا يوجد" : edt_email.Text;

                if (id==0)
                {
                    
                    tB_supp.supp_name = edt_name.Text;
                    tB_supp.supp_image = bl.methods.convert_byte(pic_cover.Image);
                    tB_supp.total_price = Convert.ToDouble(edt_sales.Text);
                    tB_supp.supp_max = Convert.ToDouble(edt_max.Text); 
                    db.tb_supp.Add(tB_supp);
                    db.SaveChanges();
                   // toast.Width = this.Width;
                    toast.txt_caption.Text = "تم اضافة مورد جديد";
                    toast.Show();
                    this.Close();

                }
                else
                {
                    
                   
                    tB_supp.id = id;
                    tB_supp.supp_name = edt_name.Text;
                    tB_supp.supp_image = bl.methods.convert_byte(pic_cover.Image);
                    tB_supp.total_price = Convert.ToDouble(edt_sales.Text);
                    tB_supp.supp_max = Convert.ToDouble(edt_max.Text); 
                    db.Entry(tB_supp).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    if (edt_name_old.Text != tB_supp.supp_name)
                    {

                        var purRecords = db.tb_buy.Where(x => x.pur_supp == edt_name_old.Text).ToList();
                        foreach (var pur in purRecords)
                        {
                            pur.pur_supp = tB_supp.supp_name;
                            db.Entry(pur).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                        var spendRecords = db.tb_spend_supp.Where(x => x.name_supp == edt_name_old.Text).ToList();
                        foreach (var pur in spendRecords)
                        {
                            pur.name_supp = tB_supp.supp_name;
                            db.Entry(pur).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                    toast.Width = this.Width;
                    toast.txt_caption.Text = "تم تعديل مورد ";
                    toast.Show();
                    this.Close();
                }
            }
        }

        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void edt_sales_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_sales.Text))
            {
                // إذا كانت القيمة فارغة، يمكنك تعيين القيمة الافتراضية مرة أخرى
                edt_sales.Text = "0";
            }
        }

        private void edt_max_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_max.Text))
            {
                // إذا كانت القيمة فارغة، يمكنك تعيين القيمة الافتراضية مرة أخرى
                edt_max.Text = "0";
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
