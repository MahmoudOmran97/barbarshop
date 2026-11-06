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
        DB_BarbershopEntities db = new DB_BarbershopEntities();
        //  tb_cus tB_cus = new tb_cus();
        tb_chair tb_chair = new tb_chair();
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
                dialog.txt_capthion.Text = "رقم المقعد مطلوب";
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
            // التحقق مما إذا كان اسم المقعد موجودًا بالفعل في قاعدة البيانات
            bool isTableExists = db.tb_chair.Any(x => x.name_chair == fullTableName);

            if (isTableExists)
            {
                dialog.Width = this.Width;
                dialog.txt_capthion.Text = "اسم المقعد موجود من قبل";
                dialog.Show();
                return;
            }
           
                    if (id == 0)
                    {
                        tb_chair.name_chair = fullTableName;
                        tb_chair.totall_price = 0;
                        tb_chair.name_location = edt_table.Text;

                        db.tb_chair.Add(tb_chair);
                        db.SaveChanges();

                        toast.Width = this.Width;
                        toast.txt_caption.Text = "تم إضافة مقعد جديدة";
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
