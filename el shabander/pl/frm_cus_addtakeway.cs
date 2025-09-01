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
    public partial class frm_cus_addtakeway : Form
    {
        DB_restoraintEntities db = new DB_restoraintEntities();
          tb_cus tB_cus = new tb_cus();
       // tb_table tb_Table = new tb_table();
        bl.methods methods = new bl.methods();
       
        //pl.frm_supp frm_Cat = new frm_supp();
        public int id;
        public frm_cus_addtakeway()

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
                dialog.txt_capthion.Text = "اسم العميل مطلوب";
                dialog.Show();
            }
            else
            {
                // التحقق مما إذا كان اسم الطاولة موجودًا بالفعل في قاعدة البيانات
                bool isTableExists = db.tb_cus.Any(x => x.cus_name == edt_name.Text);

                if (isTableExists)
                {
                    dialog.Width = this.Width;
                    dialog.txt_capthion.Text = "اسم العميل موجود من قبل";
                    dialog.Show();
                }
                else
                {
                    if (id == 0)
                    {

                        tB_cus.cus_name = edt_name.Text;

                        tB_cus.cus_email = string.IsNullOrEmpty(edt_email.Text) ? "لا يوجد" : edt_email.Text;
                        tB_cus.cus_phone = string.IsNullOrEmpty(edt_phone.Text) ? "لا يوجد" : edt_phone.Text;
                        tB_cus.cus_max = 0;


                        db.tb_cus.Add(tB_cus);
                        db.SaveChanges();
                        toast.Width = this.Width;
                        toast.txt_caption.Text = "تم اضافة عميل جديد";
                        toast.Show();
                        this.Close();

                    }
                }
            }
        }

        

        private void label3_Click(object sender, EventArgs e)
        {

        }

      

       
    }
}
