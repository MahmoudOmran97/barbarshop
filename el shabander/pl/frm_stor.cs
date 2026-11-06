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
    public partial class frm_stor : Form
    {
        DB_BarbershopEntities db = new DB_BarbershopEntities();
        tb_stor tb_Stor = new tb_stor();
        tb_safe tb_Safe = new tb_safe();
        bl.send send = new bl.send();
        Notfication notfication = new Notfication();
        bl.methods methods = new bl.methods();
        toast toast = new toast();
      //  tb_employees tb_Employees = new tb_employees();
        tb_OperationLog tb_OperationLog = new tb_OperationLog();
        int id;
        public frm_stor()
        {
            InitializeComponent();




          
            el_shabander.DB_BarbershopEntities dbContext = new el_shabander.DB_BarbershopEntities();
            // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
            dbContext.tb_stor.LoadAsync().ContinueWith(loadTask =>
            {
    // Bind data to control when loading complete
    gridControl1.DataSource = dbContext.tb_stor.Local.ToBindingList().Reverse();
            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
            gridView1.OptionsBehavior.Editable = false;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            main user = (main)Application.OpenForms["main"];
            string casherName = user?.la_username.Text;

            var openSession = db.Sessions
                .FirstOrDefault(x => x.namecasher == casherName && x.IsClosed == true);

            if (openSession == null)
            {
                MessageBox.Show("يرجى فتح الكاش بوكس أولاً");
                return;
            }

            // ✅ التحقق من وجود موظفين
           

            // ✅ فتح الفورم
            pl.frm_stor_add frm_supp_Add = new frm_stor_add();
            frm_supp_Add.id = 0;
            frm_supp_Add.btn_add.Text = "اضافة";
            frm_supp_Add.Show();
        }

        public void btn_updata_Click(object sender, EventArgs e)
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
                    


                    tb_Stor = db.tb_stor.Where(x => x.id == id).FirstOrDefault();
                    db.Entry(tb_Stor).State = EntityState.Deleted;
                    db.SaveChanges();
                    tb_Safe = db.tb_safe.Where(x => x.safe_name == tb_Stor.safe_name).FirstOrDefault();
                    tb_Safe.safe_count += tb_Stor.stor_spen;
                    db.Entry(tb_Safe).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                   
                    main user1 = (main)Application.OpenForms["main"];
                    string casherName1 = user1?.la_username.Text;
                    var openSession1 = db.Sessions.FirstOrDefault(x => x.namecasher == casherName1 && x.IsClosed == true);
                    if (openSession1 != null)
                    {
                        tb_OperationLog.SessionID = openSession1.SessionID;
                        tb_OperationLog.OperationType = "حذف";
                        tb_OperationLog.TableName = "عملية مصاريف";
                        tb_OperationLog.OldValue = openSession1.ClosingAmount;
                        tb_OperationLog.NewValue = Convert.ToDouble(openSession1.ClosingAmount + tb_Stor.stor_spen);
                        tb_OperationLog.AmountDifference = tb_Stor.stor_spen;
                        db.tb_OperationLog.Add(tb_OperationLog);
                        db.SaveChanges();

                        openSession1.ClosingAmount = tb_OperationLog.NewValue;

                        db.SaveChanges();

                    }
                    main frm_supp_Add = (main)Application.OpenForms["main"];

                    string notificationMessage = $"تم حذف عملية مصاريف : {tb_Stor.stor_type} عن طريق : {frm_supp_Add.la_username.Text} التاريخ والوقت: {DateTime.Now:yyyy/MM/dd hh:mm tt}.";

                    send.SendEmailWithHtmlGridData(notificationMessage);
                    notfication.notfication1 = notificationMessage;
                    notfication.CreatedAt = DateTime.Now;


                    db.Notfications.Add(notfication);
                    db.SaveChanges();
                    toast.txt_caption.Text = "تم الحذف بنجاح";
                    toast.Show();
                    updata_data();
                }
               
            }
            catch
            {
                dialog.Width = this.Width;
                dialog.txt_capthion.Text = "لا يوجد مصروفات لحزفها  ";
                dialog.Show();
            }
        }

        public void updata_data()
        {
            db = new DB_BarbershopEntities();
            List<tb_stor> data = db.tb_stor.ToList();// جلب البيانات
            data.Reverse();
            gridControl1.DataSource = data;
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
            pl.frm_stor_add frm_supp_Add = new pl.frm_stor_add();
            id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("id"));
            tb_Stor = db.tb_stor.Where(x => x.id == id).FirstOrDefault();
            frm_supp_Add.edt_safe.DataSource = db.tb_safe.Select(x => x.safe_name).ToList();

          //  frm_supp_Add.edt_name.DataSource = db.tb_employees.Select(x => x.emp_name).ToList();

          //  frm_supp_Add.edt_name.Text = tb_Stor.stor_empname;
            frm_supp_Add.edt_type.Text = tb_Stor.stor_type;
            frm_supp_Add.edt_spen.Text = tb_Stor.stor_spen.ToString();


            frm_supp_Add.edt_date.Text = tb_Stor.stor_dete.ToString();
            frm_supp_Add.edt_dat.Text = tb_Stor.stor_det;
            frm_supp_Add.edt_safe.Text = tb_Stor.safe_name;


            frm_supp_Add.id = id;
            frm_supp_Add.btn_add.Text = "تعديل ";
            frm_supp_Add.Show();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            var _search = edit_txt.Text;
            List<tb_stor> data = db.tb_stor.Where(x => x.stor_empname.Contains(_search) || x.stor_type.Contains(_search)).ToList();// جلب البيانات
            data.Reverse();
            gridControl1.DataSource = data;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            btn_edit_Click(sender, e);
        }

        private void edt_send_Click(object sender, EventArgs e)
        {
           
        }
    }
}
