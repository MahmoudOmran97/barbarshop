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
    public partial class frm_stor_addmany : Form
    {
        DB_restoraintEntities db = new DB_restoraintEntities();
        tb_safe tb_Safe = new tb_safe();
        bl.methods methods = new bl.methods();
        tb_employees tb_Employees = new tb_employees();
       // double storadd, stortotal, storstay;
       // DateTime time;
        //pl.frm_supp frm_Cat = new frm_supp();
        public int id;
        public frm_stor_addmany  ()

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
                tb_Safe.safe_name = edt_name.Text;
               // tb_Safe.safe_add = Convert.ToDouble(edt_count.Text);
                tb_Safe.safe_count = Convert.ToDouble(edt_count.Text); 
               // tb_Safe.safe_stay = 0;
                // tb_Stor.stor_spen = Convert.ToDouble(edt_count.Text);
                
                // time= Convert.ToDateTime(edt_date.Text);
                // tb_Stor.stor_dete = time;
                //tb_Stor.stor_det =edt_dat.Text;
                // tb_Safe.safe_stay=con
               // db.Entry(tb_Safe).State = System.Data.Entity.EntityState.Modified;
                db.tb_safe.Add(tb_Safe);
                db.SaveChanges();


                toast.Width = this.Width;
                toast.txt_caption.Text = "تم اضافة خزنة جديدة";
                toast.Show();
                this.Close();

            }
               
            
        }

        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void edt_salery_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_count.Text))
            {
                // إذا كانت القيمة فارغة، يمكنك تعيين القيمة الافتراضية مرة أخرى
                edt_count.Text = "0";
            }
            sumsaler();
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
            // var r1 = db.tb_employees.Select(x => x.emp_name).ToList();
            // edt_name.DataSource = r1;
            //  AutoCompleteStringCollection acsc1 = new AutoCompleteStringCollection();
            //  acsc1.AddRange(r1.ToArray());
            //  edt_name.AutoCompleteCustomSource = acsc1;
            // edt_date.Text = (DateTime.Now).ToString();
           // edt_stay.Text =tb_Safe.safe_stay.ToString();
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
            var tb_safe = db.tb_safe.Where(x => x.safe_name == edt_table.Text).FirstOrDefault();
            if (tb_safe.safe_count > 0)
            {
                MessageBox.Show("لا يمكن حذف الخزينة لان يوجد بيها مبلغ مالى", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // الخروج من العملية إذا لم يتم العثور على العميل
            }
            var rs = MessageBox.Show("عملية حذف", "هل انت متاكد من هذة العملية", MessageBoxButtons.YesNo);
            if (rs == DialogResult.Yes)
            {
                // استخراج الـ id من الـ TextBox
                int idToDelete = Convert.ToInt32(edt_del.Text);

                // البحث عن السجل باستخدام الـ id في قاعدة البيانات
                tb_Safe = db.tb_safe.Where(x => x.id == idToDelete).FirstOrDefault();
                var recordToDelete = db.tb_safe.Find(idToDelete);
                if (tb_Safe != null)
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
            var r1 = db.tb_safe.Select(x => x.safe_name).ToList();
            edt_table.DataSource = r1;

            // تحديث مصدر الإكمال التلقائي
            AutoCompleteStringCollection acsc1 = new AutoCompleteStringCollection();
            acsc1.AddRange(r1.ToArray());
            edt_table.AutoCompleteCustomSource = acsc1;
        }

        private void frm_stor_addmany_Load(object sender, EventArgs e)
        {
            var r1 = db.tb_safe.Select(x => x.safe_name).ToList();
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
                var tb_safe = db.tb_safe.FirstOrDefault(x => x.safe_name == selectedName);

                if (tb_safe != null)
                {
                    // استخراج الـ id من السجل المحدد
                    int idToDelete = tb_safe.id;
                    edt_del.Text = idToDelete.ToString();
                }
            }
        }
    }
}
