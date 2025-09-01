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
    public partial class frm_edtitstuck: Form
    {
        DB_restoraintEntities db = new DB_restoraintEntities();
        //tb_stor tb_Stor = new tb_stor();
       // bl.methods methods = new bl.methods();
      //  tb_safe tb_Safe = new tb_safe();
        //tb_employees tb_Employees = new tb_employees();
       // double storspen, stortotal, storstay;
       //DateTime time;
       // tb_stuk tb_stuk = new tb_stuk();
        //pl.frm_supp frm_Cat = new frm_supp();
        public int id;
        public frm_edtitstuck ()

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
                dialog.txt_capthion.Text = "  اسم المادة مطلوب";
                dialog.Show();
            }else
            {
                if(id==0)
                {
                   // pic_cover.Image.Save(methods.ma, System.Drawing.Imaging.ImageFormat.Png);
                   

                }else
                {
                  
                    toast.Width = this.Width;
                    toast.txt_caption.Text = "تم تعديل المخزن";
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
            if (string.IsNullOrWhiteSpace(edt_sell.Text))
            {
                // إذا كانت القيمة فارغة، يمكنك تعيين القيمة الافتراضية مرة أخرى
               
            }
        }

       

       

        private void frm_stor_add_Activated(object sender, EventArgs e)
        {
           /* var r1 = db.tb_employees.Select(x => x.emp_name).ToList();
            var r2 = db.tb_safe.Select(x => x.safe_name).ToList();
            edt_name.DataSource = r1;
            edt_safe.DataSource = r2;
            AutoCompleteStringCollection acsc1 = new AutoCompleteStringCollection();
            AutoCompleteStringCollection acsc2 = new AutoCompleteStringCollection();
            acsc1.AddRange(r1.ToArray());
            acsc2.AddRange(r2.ToArray());
            edt_name.AutoCompleteCustomSource = acsc1;
            edt_safe.AutoCompleteCustomSource = acsc2;
            edt_qt.Text = (DateTime.Now).ToString();
           // edt_countsafe.Text = tb_Safe.safe_count.ToString();*/
        }

        private void edt_name_SelectedIndexChanged(object sender, EventArgs e)
        {
           // tb_Employees = db.tb_employees.Where(x => x.emp_name == edt_name.Text).FirstOrDefault();

        }

        private void frm_stor_add_Load(object sender, EventArgs e)
        {

        }

       

       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void edt_qt_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_qt.Text))
            {
                // إذا كانت القيمة فارغة، يمكنك تعيين القيمة الافتراضية مرة أخرى
              
            }
        }

        private void edt_buy_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_buy.Text))
            {
                
            }
        }
    }
}
