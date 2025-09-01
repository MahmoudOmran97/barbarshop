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
    public partial class frm_employees_add: Form
    {
        DB_restoraintEntities db = new DB_restoraintEntities();
        tb_employees tb_Employees = new tb_employees();
        bl.methods methods = new bl.methods();
        double saltot, salpay, salstay;
        //pl.frm_supp frm_Cat = new frm_supp();
        public int id;
        public frm_employees_add ()

        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            
            toast toast = new toast();
            dialog dialog = new dialog();
            if (edt_name.Text == "")
            {
                dialog.Width = this.Width;
                dialog.txt_capthion.Text = "  اسم المستخدم مطلوب";
                dialog.Show();
            }
            else
            {
                if (id == 0)
                {
                    // pic_cover.Image.Save(methods.ma, System.Drawing.Imaging.ImageFormat.Png);
                    tb_Employees.emp_name = edt_name.Text;
                    tb_Employees.emp_type_emp = edt_typeemp.Text;
                    tb_Employees.emp_freeday = edt_freeday.Text;
                    tb_Employees.emp_salers = Convert.ToDouble(edt_salery.Text);
                    tb_Employees.emp_paysalers = Convert.ToDouble(edt_salerypay.Text);
                    tb_Employees.emp_staysalers = Convert.ToDouble(edt_salerystay.Text);
                    tb_Employees.emp_datemont = edt_saleryday.Text;

                   
                    tb_Employees.emp_image = bl.methods.convert_byte(pic_cover.Image);
                    tb_Employees.emp_absent = 0;
                    db.tb_employees.Add(tb_Employees);
                    db.SaveChanges();
                    toast.Width = this.Width;
                    toast.txt_caption.Text = "تم اضافة موظف جديد";
                    toast.Show();
                    this.Close();

                }
                else
                {
                    tb_Employees = db.tb_employees.Where(x => x.id == id).FirstOrDefault();
                    tb_Employees.emp_name = edt_name.Text;
                    tb_Employees.emp_type_emp = edt_typeemp.Text;
                    tb_Employees.emp_freeday = edt_freeday.Text;
                    tb_Employees.emp_salers = Convert.ToDouble(edt_salery.Text);
                    tb_Employees.emp_paysalers = Convert.ToDouble(edt_salerypay.Text);
                    tb_Employees.emp_staysalers = Convert.ToDouble(edt_salerystay.Text);
                    tb_Employees.emp_datemont = edt_saleryday.Text;

                   
                    //tb_Employees.emp_absent = 0;
                    tb_Employees.emp_image = bl.methods.convert_byte(pic_cover.Image);
                    db.Entry(tb_Employees).State = System.Data.Entity.EntityState.Modified;

                    db.SaveChanges();

                    toast.Width = this.Width;
                    toast.txt_caption.Text = "تم تعديل موظف حالى";
                    toast.Show();
                    this.Close();

                }
            }
        }

        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void edt_salery_TextChanged(object sender, EventArgs e)
        {
            sumsaler();
        }

        private void edt_salerypay_TextChanged(object sender, EventArgs e)
        {
            sumsaler();
            if (string.IsNullOrWhiteSpace(edt_salerypay.Text))
            {
                // إذا كانت القيمة فارغة، يمكنك تعيين القيمة الافتراضية مرة أخرى
                edt_salerypay.Text = "0";
            }
        }

        private void edt_salerystay_TextChanged(object sender, EventArgs e)
        {
            sumsaler();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void sumsaler()
        {
            saltot = Convert.ToDouble(edt_salery.Text);
            salpay = Convert.ToDouble(edt_salerypay.Text);
            salstay = saltot - salpay;
            edt_salerystay.Text = salstay.ToString();
            
        }
    }
}
