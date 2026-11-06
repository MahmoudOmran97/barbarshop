using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using el_shabander.epl;
namespace el_shabander.pl
{
    public partial class frm_spend_supp : Form
    {
        DB_BarbershopEntities db = new DB_BarbershopEntities();
      
        bl.methods methods = new bl.methods();
        toast toast = new toast();
       tb_supp tb_Supp = new tb_supp();
        tb_spend_supp tb_Spend_supp = new tb_spend_supp();
        Notfication notfication = new Notfication();
        tb_OperationLog tb_OperationLog = new tb_OperationLog();
        tb_safe tb_Safe = new tb_safe();
        int id;
        public frm_spend_supp()
        {
            InitializeComponent();





          
            el_shabander.DB_BarbershopEntities dbContext = new el_shabander.DB_BarbershopEntities();
            // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
            dbContext.tb_spend_supp.LoadAsync().ContinueWith(loadTask =>
            {
    // Bind data to control when loading complete
            gridControl1.DataSource = dbContext.tb_spend_supp.Local.ToBindingList().Reverse();
            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
            gridView1.OptionsBehavior.Editable = false;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            main user = (main)Application.OpenForms["main"];
            string casherName = user?.la_username.Text;
            var openSession = db.Sessions.FirstOrDefault(x => x.namecasher == casherName && x.IsClosed == true);
            if (openSession == null)
            {
                MessageBox.Show("يرجى فتح الكاش بوكس أولاً");
                return;
            }
            toast toast = new toast();
            dialog dialog = new dialog();
            if(Convert.ToDouble(edt_count.Text) <= 0)
            {
                MessageBox.Show("يجب ان تكون قيمه السداد اكبر من صفر", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var islocationExists = db.tb_supp.Where(x => x.supp_name == comboBox1.Text).FirstOrDefault();
            if (islocationExists == null)
            {
                dialog.Width = this.Width;
                dialog.txt_capthion.Text = "الرجاءاضافة مورد اولا ";
                dialog.Show();
                return;
            }
            if (id == 0)
            {

                tb_Spend_supp.name_supp = comboBox1.Text;
                tb_Spend_supp.mony_spend = Convert.ToDouble(edt_count.Text);
                tb_Spend_supp.mony_stay = Convert.ToDouble(txt_stay.Text);
                tb_Spend_supp.mony_rev = Convert.ToDouble(txt_rev.Text);
                tb_Spend_supp.date = Convert.ToDateTime(edt_date.Text);
                tb_Spend_supp.safe = save.Text;
                main frm_supp_Add = (main)Application.OpenForms["main"];
                if (frm_supp_Add != null)
                {
                    // التحقق من أن la_roll يحتوي على قيمة
                    if (!string.IsNullOrEmpty(frm_supp_Add.la_username.Text))
                    {
                        tb_Spend_supp.namecasher = frm_supp_Add.la_username.Text;
                    }
                }
                db.tb_spend_supp.Add(tb_Spend_supp);
                db.SaveChanges();


                tb_Supp.total_price = Convert.ToDouble(txt_stay.Text) ;

                db.Entry(tb_Supp).State = System.Data.Entity.EntityState.Modified;
                // db.tb_safe.Add(tb_Safe);
                db.SaveChanges();
                tb_Safe = db.tb_safe.Where(x => x.safe_name == save.Text).FirstOrDefault();
                tb_Safe.safe_count -= Convert.ToDouble(edt_count.Text);
                db.Entry(tb_Safe).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                main user1 = (main)Application.OpenForms["main"];
                string casherName1 = user1?.la_username.Text;
                var openSession1 = db.Sessions.FirstOrDefault(x => x.namecasher == casherName1 && x.IsClosed == true);
                if (openSession1 != null)
                { 
                    tb_OperationLog.SessionID = openSession1.SessionID;
                    tb_OperationLog.OperationType = "اضافة";
                    tb_OperationLog.TableName = "عملية سداد مورد";
                    tb_OperationLog.OldValue = openSession1.ClosingAmount;
                    tb_OperationLog.NewValue = Convert.ToDouble(openSession1.ClosingAmount - Convert.ToDouble(edt_count.Text));
                    tb_OperationLog.AmountDifference = -Convert.ToDouble(edt_count.Text);
                    db.tb_OperationLog.Add(tb_OperationLog);
                    db.SaveChanges();

                    openSession.ClosingAmount = tb_OperationLog.NewValue;

                    db.SaveChanges();

                }

                toast.Width = this.Width;
                toast.txt_caption.Text = "تم سداد مبلغ مورد";
                toast.Show();
                this.Close();

            }
        }

        private void btn_updata_Click(object sender, EventArgs e)
        {
            updata_data();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            main user = (main)Application.OpenForms["main"];
            string casherName = user?.la_username.Text;
            var openSession = db.Sessions.FirstOrDefault(x => x.namecasher == casherName && x.IsClosed == true);
            if (openSession == null)
            {
                MessageBox.Show("يرجى فتح الكاش بوكس أولاً");
                return;
            }
            toast toast = new toast();
            dialog dialog = new dialog();
            try
            {
                id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("id"));
                var rs = MessageBox.Show("عملية حذف", "هل انت متاكد من هذة العملية", MessageBoxButtons.YesNo);
                if (rs == DialogResult.Yes)
                {
                    tb_Supp = db.tb_supp.Where(x => x.supp_name == tb_Spend_supp.name_supp).FirstOrDefault();
                    tb_Supp.total_price += Convert.ToDouble(edt_count.Text);
                    db.Entry(tb_Supp).State = System.Data.Entity.EntityState.Modified;

                    db.SaveChanges();
                    tb_Spend_supp = db.tb_spend_supp.Where(x => x.id == id).FirstOrDefault();
                    db.Entry(tb_Spend_supp).State = EntityState.Deleted;
                  
                    db.SaveChanges();
                   
                    tb_Safe = db.tb_safe.Where(x => x.safe_name == save.Text).FirstOrDefault();
                    tb_Safe.safe_count += Convert.ToDouble(edt_count.Text);
                    db.Entry(tb_Safe).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    main user1 = (main)Application.OpenForms["main"];
                    string casherName1 = user1?.la_username.Text;
                    var openSession1 = db.Sessions.FirstOrDefault(x => x.namecasher == casherName1 && x.IsClosed == true);
                    if (openSession1 != null)
                    {
                        tb_OperationLog.SessionID = openSession1.SessionID;
                        tb_OperationLog.OperationType = "حذف";
                        tb_OperationLog.TableName = "عملية سداد مورد";
                        tb_OperationLog.OldValue = openSession1.ClosingAmount;
                        tb_OperationLog.NewValue = Convert.ToDouble(openSession1.ClosingAmount + Convert.ToDouble(edt_count.Text));
                        tb_OperationLog.AmountDifference = Convert.ToDouble(edt_count.Text);
                        db.tb_OperationLog.Add(tb_OperationLog);
                        db.SaveChanges();

                        openSession.ClosingAmount = tb_OperationLog.NewValue;

                        db.SaveChanges();

                    }

                    btn_delete.Enabled = false;
                    btn_edit.Enabled = false;
                    btn_add.Enabled = true;
                    btn_updata.Enabled = true;
                    toast.txt_caption.Text = "تم الحذف بنجاح";
                    toast.Show();
                    updata_data();
                }
               
            }
            catch
            {
                dialog.Width = this.Width;
                dialog.txt_capthion.Text = "لا يوجد مورد لحزفه ";
                dialog.Show();
            }
        }

        private void updata_data()
        {
            db = new DB_BarbershopEntities(); 
            List<tb_spend_supp> data = db.tb_spend_supp.ToList();
            data.Reverse();
            gridControl1.DataSource = data;
        }

        

        private void btn_search_Click(object sender, EventArgs e)
        {
            var _search = edit_txt.Text;
            List<tb_spend_supp> data = db.tb_spend_supp.Where(x => x.name_supp.Contains(_search)).ToList();
            data.Reverse();

            gridControl1.DataSource = data;
        }

        

        private void frm_spend_cus_Activated(object sender, EventArgs e)
        {
          
        }

        private void txt_rev_Click(object sender, EventArgs e)
        {
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_Supp= db.tb_supp.Where(x => x.supp_name == comboBox1.Text).FirstOrDefault();
            txt_stay.Text = tb_Supp.total_price.ToString();
            txt_rev.Text= tb_Supp.total_price.ToString();
        }

        private void edt_count_TextChanged(object sender, EventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(edt_count.Text))
            {
                // إذا كانت القيمة فارغة، يمكنك تعيين القيمة الافتراضية مرة أخرى
                edt_count.Text = "0";
                tb_Supp = db.tb_supp.Where(x => x.supp_name == comboBox1.Text).FirstOrDefault();
                txt_stay.Text = (Convert.ToDouble(txt_rev.Text) - Convert.ToDouble(edt_count.Text)).ToString();
            }
            else
            {
                tb_Supp = db.tb_supp.Where(x => x.supp_name == comboBox1.Text).FirstOrDefault();
                txt_stay.Text = (Convert.ToDouble(txt_rev.Text) - Convert.ToDouble(edt_count.Text)).ToString();
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            main user = (main)Application.OpenForms["main"];
            string casherName = user?.la_username.Text;
            var openSession = db.Sessions.FirstOrDefault(x => x.namecasher == casherName && x.IsClosed == true);
            if (openSession == null)
            {
                MessageBox.Show("يرجى فتح الكاش بوكس أولاً");
                return;
            }
            toast toast = new toast();
            dialog dialog = new dialog();
            if (Convert.ToDouble(edt_count.Text) <= 0)
            {
                MessageBox.Show("يجب ان تكون قيمه السداد اكبر من صفر", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btn_delete.Enabled = false;
                btn_edit.Enabled = false;
                btn_add.Enabled = true;
                btn_updata.Enabled = true;
                return;
            }
            tb_Safe = db.tb_safe.Where(x => x.safe_name == save.Text).FirstOrDefault();
            tb_Safe.safe_count += tb_Spend_supp.mony_spend;
            tb_Safe.safe_count -= Convert.ToDouble(edt_count.Text);


            try
            {
                db.Entry(tb_Safe).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                // tb_Sellorder.id = x += 1;
            }
            catch
            {
                MessageBox.Show("ghg");

            }
            main user1 = (main)Application.OpenForms["main"];
            string casherName1 = user1?.la_username.Text;
            var openSession1 = db.Sessions.FirstOrDefault(x => x.namecasher == casherName1 && x.IsClosed == true);
            if (openSession1 != null)
            {
                tb_OperationLog.SessionID = openSession1.SessionID;
                tb_OperationLog.OperationType = "تعديل";
                tb_OperationLog.TableName = "عملية سداد مورد";
                tb_OperationLog.OldValue = openSession1.ClosingAmount;
                tb_OperationLog.NewValue = Convert.ToDouble(openSession1.ClosingAmount - (Convert.ToDouble(edt_count.Text) - tb_Spend_supp.mony_spend));
                tb_OperationLog.AmountDifference = (tb_Spend_supp.mony_spend-Convert.ToDouble(edt_count.Text) );
                db.tb_OperationLog.Add(tb_OperationLog);
                db.SaveChanges();

                openSession.ClosingAmount = tb_OperationLog.NewValue;

                db.SaveChanges();

            }
            tb_Supp.total_price += tb_Spend_supp.mony_spend;
            tb_Supp.total_price -= Convert.ToDouble(edt_count.Text);

            db.Entry(tb_Supp).State = System.Data.Entity.EntityState.Modified;
            // db.tb_safe.Add(tb_Safe);
            db.SaveChanges();
            if (id == 0)
            {

               

            }
            else
            {
                tb_Spend_supp.name_supp = comboBox1.Text;
                tb_Spend_supp.mony_spend = Convert.ToDouble(edt_count.Text);
                tb_Spend_supp.mony_stay = Convert.ToDouble(txt_stay.Text);
                tb_Spend_supp.mony_rev = Convert.ToDouble(txt_rev.Text);
                tb_Spend_supp.date = Convert.ToDateTime(edt_date.Text);
                tb_Spend_supp.safe = save.Text;
                main frm_supp_Add = (main)Application.OpenForms["main"];
                if (frm_supp_Add != null)
                {
                    // التحقق من أن la_roll يحتوي على قيمة
                    if (!string.IsNullOrEmpty(frm_supp_Add.la_username.Text))
                    {
                        tb_Spend_supp.namecasher = frm_supp_Add.la_username.Text;
                    }
                }
                db.Entry(tb_Spend_supp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                
                string notificationMessage = $"تم تعديل عمليه سداد مورد : {tb_Supp.supp_name} عن طريق : {frm_supp_Add.la_username.Text}  ";


                notfication.notfication1 = notificationMessage;
                notfication.CreatedAt = DateTime.Now;


                db.Notfications.Add(notfication);
                db.SaveChanges();

               

                toast.Width = this.Width;
                toast.txt_caption.Text = "تم تعديل سداد مبلغ مورد";
                toast.Show();
                btn_delete.Enabled = false;
                btn_edit.Enabled = false;
                btn_add.Enabled = true;
                btn_updata.Enabled = true;
                this.Close();
            }

        }

       
        private void gridControl1_Click(object sender, EventArgs e)
        {
             id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("id"));
            tb_Spend_supp = db.tb_spend_supp.Where(x => x.id == id).FirstOrDefault();
            comboBox1.Text = tb_Spend_supp.name_supp;
            edt_count.Text = tb_Spend_supp.mony_spend.ToString();
            txt_stay.Text = tb_Spend_supp.mony_stay.ToString();
            txt_rev.Text = tb_Spend_supp.mony_rev.ToString();
            edt_date.Text = tb_Spend_supp.date.ToString();
            save.Text = tb_Spend_supp.safe;
            btn_delete.Enabled = true;
            btn_edit.Enabled = true;
            btn_add.Enabled = false;
            btn_updata.Enabled = false;
        }

        private void frm_spend_supp_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            save.DataSource = db.tb_safe.Select(x => x.safe_name).ToList();
            var r1 = db.tb_supp.Select(x => x.supp_name).ToList();
            comboBox1.DataSource = r1;
            AutoCompleteStringCollection acsc1 = new AutoCompleteStringCollection();
            acsc1.AddRange(r1.ToArray());
            comboBox1.AutoCompleteCustomSource = acsc1;
            edt_date.Text = (DateTime.Now).ToString();
            btn_edit.Enabled = false;
            btn_delete.Enabled = false;
        }
    }
}
