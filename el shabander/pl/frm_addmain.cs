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
using System.Data.Entity;
namespace el_shabander.pl
{
    public partial class frm_addmain : Form
    {
        DB_BarbershopEntities db = new DB_BarbershopEntities();
        tb_main tb_main = new tb_main();
        bl.methods methods = new bl.methods();
        tb_employees tb_Employees = new tb_employees();
       // double storadd, stortotal, storstay;
       // DateTime time;
        //pl.frm_supp frm_Cat = new frm_supp();
        public int id;
        public frm_addmain()

        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            toast toast = new toast();
            dialog dialog = new dialog();

            if (id == 0)
            {
               // tb_Safe.id = id;
                tb_main.name_main = edt_name.Text;
               // tb_Safe.safe_add = Convert.ToDouble(edt_count.Text);
              
               // tb_Safe.safe_stay = 0;
                // tb_Stor.stor_spen = Convert.ToDouble(edt_count.Text);
                
                // time= Convert.ToDateTime(edt_date.Text);
                // tb_Stor.stor_dete = time;
                //tb_Stor.stor_det =edt_dat.Text;
                // tb_Safe.safe_stay=con
               // db.Entry(tb_Safe).State = System.Data.Entity.EntityState.Modified;
                db.tb_main.Add(tb_main);
                db.SaveChanges();


                toast.Width = this.Width;
                toast.txt_caption.Text = "تم اضافة قائمة جديدة";
                toast.Show();
                this.Close();

            }
               
            
        }

        

        private void label3_Click(object sender, EventArgs e)
        {

        }

      
        private void edt_salerypay_TextChanged(object sender, EventArgs e)
        {
            sumsaler();
        }

        private void edt_salerystay_TextChanged(object sender, EventArgs e)
        {
            sumsaler();
        }

        private void frm_stor_add_Activated(object sender, EventArgs e)
        {
            
        }

      

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void sumsaler()
        {
          /* storadd = Convert.ToDouble(edt_count.Text);
           // storstay =Convert.ToDouble(tb_Safe.safe_stay);
            stortotal= storstay   + storadd;
            tb_Safe.safe_count = stortotal;*/
            
        }

        private void btn_ChangeTable_Click(object sender, EventArgs e)
        {
            var rs = MessageBox.Show("عملية حذف", "هل انت متاكد من هذة العملية", MessageBoxButtons.YesNo);
            if (rs == DialogResult.Yes)
            {
                // استخراج الـ id من الـ TextBox
                int idToDelete = Convert.ToInt32(edt_del.Text);

                // البحث عن السجل باستخدام الـ id في قاعدة البيانات
                 tb_main = db.tb_main.Where(x => x.id == idToDelete).FirstOrDefault() ;
                  var recordToDelete = db.tb_main.Find(idToDelete);
                if (tb_main != null)
                {
                    try
                    {
                        // حذف السجل
                        db.Entry(recordToDelete).State = EntityState.Deleted;
                        db.SaveChanges();
                        MessageBox.Show($"تم حذف السجل رقم {idToDelete} بنجاح.", "نجاح");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"حدث خطأ أثناء حذف السجل: {ex.Message}", "خطأ");
                    }
                }
                else
                {
                    MessageBox.Show($"لم يتم العثور على سجل بالرقم {idToDelete}.", "خطأ");
                }
            }

            // إعادة تحميل بيانات ComboBox بعد الحذف
            var r1 = db.tb_main.Select(x => x.name_main).ToList();
            edt_table.DataSource = r1;

            // تحديث مصدر الإكمال التلقائي
            AutoCompleteStringCollection acsc1 = new AutoCompleteStringCollection();
            acsc1.AddRange(r1.ToArray());
            edt_table.AutoCompleteCustomSource = acsc1;

        }

        private void edt_table_SelectedIndexChanged(object sender, EventArgs e)
        {
            // احتياطي: التأكد من أن هناك عنصر محدد
            if (edt_table.SelectedItem != null)
            {
                string selectedName = edt_table.SelectedItem.ToString();

                // البحث عن السجل باستخدام name_main
                var tb_main = db.tb_main.FirstOrDefault(x => x.name_main == selectedName);

                if (tb_main != null)
                {
                    // استخراج الـ id من السجل المحدد
                    int idToDelete = tb_main.id;
                    edt_del.Text = idToDelete.ToString();
                }
            }
        }

        private void frm_addmain_Load(object sender, EventArgs e)
        {
            var r1 = db.tb_main.Select(x => x.name_main).ToList();
            edt_table.DataSource = r1;
            AutoCompleteStringCollection acsc1 = new AutoCompleteStringCollection();
            acsc1.AddRange(r1.ToArray());
            edt_table.AutoCompleteCustomSource = acsc1;
        }
    }
}
