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
    public partial class frm_cus_add  : Form
    {
        DB_restoraintEntities db = new DB_restoraintEntities();
        //  tb_cus tB_cus = new tb_cus();
        tb_table tb_Table = new tb_table();
        bl.methods methods = new bl.methods();
       
        //pl.frm_supp frm_Cat = new frm_supp();
        public int id;
        public frm_cus_add  ()

        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            toast toast = new toast();
            dialog dialog = new dialog();

            if (string.IsNullOrEmpty(num_tab.Text))
            {
                dialog.Width = this.Width;
                dialog.txt_capthion.Text = "رقم الطاولة مطلوب";
                dialog.Show();
                return;
            }
            if (string.IsNullOrEmpty(edt_table.Text))
            {
                dialog.Width = this.Width;
                dialog.txt_capthion.Text = "الرجاء اضافة منطقة";
                dialog.Show();
                return;
            }
            var islocationExists = db.tb_location.Where(x=>x.location==edt_table.Text).FirstOrDefault();
            if(islocationExists==null)
            {
                dialog.Width = this.Width;
                dialog.txt_capthion.Text = "الرجاءاضافة منطقة جديدة ";
                dialog.Show();
                return;
            }


            string fullTableName = $"{edt_table.Text} : {num_tab.Text}";
            // التحقق مما إذا كان اسم الطاولة موجودًا بالفعل في قاعدة البيانات
            bool isTableExists = db.tb_table.Any(x => x.name_table == fullTableName);

            if (isTableExists)
            {
                dialog.Width = this.Width;
                dialog.txt_capthion.Text = "اسم الطاولة موجود من قبل";
                dialog.Show();
                return;
            }
           
                    if (id == 0)
                    {
                        tb_Table.name_table = fullTableName;
                        tb_Table.totall_price = 0;
                        tb_Table.name_location = edt_table.Text;

                        db.tb_table.Add(tb_Table);
                        db.SaveChanges();

                        toast.Width = this.Width;
                        toast.txt_caption.Text = "تم إضافة طاولة جديدة";
                        toast.Show();
                        this.Close();
                    }
                
            
        }

        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frm_cus_add_Load(object sender, EventArgs e)
        {
            var r1 = db.tb_location.Select(x => x.location).ToList();
            edt_table.DataSource = r1;

            // تحديث مصدر الإكمال التلقائي
            AutoCompleteStringCollection acsc1 = new AutoCompleteStringCollection();
            acsc1.AddRange(r1.ToArray());
            edt_table.AutoCompleteCustomSource = acsc1;
        }
    }
}
