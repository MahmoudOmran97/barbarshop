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
    public partial class frm_pur : Form
    {
        DB_BarbershopEntities db = new DB_BarbershopEntities();
        tb_buy tb_buy = new tb_buy();
        bl.methods methods = new bl.methods();
        bl.send send = new bl.send();
        toast toast = new toast();
        tb_safe tb_Safe = new tb_safe();
        Notfication notfication = new Notfication();
        tb_OperationLog tb_OperationLog = new tb_OperationLog();
        tb_supp tb_Supp = new tb_supp();
        int id;
        public frm_pur()
        {
            InitializeComponent();

           
            el_shabander.DB_BarbershopEntities dbContext = new el_shabander.DB_BarbershopEntities();
            // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
            dbContext.tb_buy.LoadAsync().ContinueWith(loadTask =>
            {
                gridControl1.DataSource = dbContext.tb_buy.Local.ToBindingList().Reverse();
               
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
            bool isMainExists = db.tb_supp.Any();


            if (!isMainExists)
            {

                MessageBox.Show("الرجاء اضافة مورد اولا");

                return;
            }
            // نبحث إذا فيه جلسة مفتوحة لهذا الكاشر

            pl.frm_pur_add frm_supp_Add = new frm_pur_add();
            frm_supp_Add.id = 0;
            frm_supp_Add.btn_add.Text = "اضافة";
            frm_supp_Add.Show();
        }

        private void btn_updata_Click(object sender, EventArgs e)
        {
            updata_data();
        }
        public List<tb_order_buy> listorder;
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
                   tb_buy= db.tb_buy.Where(x => x.id == id).FirstOrDefault();
                    db.Entry(tb_buy).State = EntityState.Deleted;
                    db.SaveChanges();
                   

                    listorder = db.tb_order_buy.Where(x => x.sell_id == id).ToList();
                    for (int i = 0; i < listorder.Count; i++)
                    {

                        string dd = listorder[i].name_cat;
                        double bb =Convert.ToDouble( listorder[i].qt_sell);

                        var tb_cat = db.tb_cat.Where(x => x.cat_name == dd).FirstOrDefault();
                        tb_cat.qt -= Convert.ToDouble(bb);
                        db.Entry(tb_cat).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();


                    }
                    tb_Supp = db.tb_supp.Where(x => x.supp_name == tb_buy.pur_supp).FirstOrDefault();

                    tb_Supp.total_price -= (tb_buy.total_price - tb_buy.pay);
                    db.Entry(tb_Supp).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    tb_Safe = db.tb_safe.Where(x => x.safe_name == tb_buy.safe).FirstOrDefault();
                    tb_Safe.safe_count += tb_buy.pay;
                    db.Entry(tb_Safe).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    main user1 = (main)Application.OpenForms["main"];
                    string casherName1 = user1?.la_username.Text;
                    var openSession1 = db.Sessions.FirstOrDefault(x => x.namecasher == casherName1 && x.IsClosed == true);
                    if (openSession1 != null)
                    {
                        tb_OperationLog.SessionID = openSession1.SessionID;
                        tb_OperationLog.OperationType = "حذف";
                        tb_OperationLog.TableName = "عملية شراء";
                        tb_OperationLog.OldValue = openSession1.ClosingAmount;
                        tb_OperationLog.NewValue = Convert.ToDouble(openSession1.ClosingAmount + tb_buy.pay);
                        tb_OperationLog.AmountDifference = tb_buy.pay ;
                        db.tb_OperationLog.Add(tb_OperationLog);
                        db.SaveChanges();

                        openSession1.ClosingAmount = tb_OperationLog.NewValue;

                        db.SaveChanges();

                    }
                    main frm_supp_Add = (main)Application.OpenForms["main"];

                    string notificationMessage = $"تم حذف فاتورة مشتريات رقم : {tb_buy.invocie_id} عن طريق : {frm_supp_Add.la_username.Text} التاريخ والوقت: {DateTime.Now:yyyy/MM/dd hh:mm tt}.  ";

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
                dialog.txt_capthion.Text = "لا يوجد مشتريات لحزفها ";
                dialog.Show();
            }
        }

        public void updata_data()
        {
            
            db = new DB_BarbershopEntities();
            List<tb_buy> data = db.tb_buy.ToList(); // جلب البيانات
            data.Reverse();
            gridControl1.DataSource = data;
        }

        

        private void btn_search_Click(object sender, EventArgs e)
        {
            var _search = edit_txt.Text;
            List<tb_buy> data = db.tb_buy.Where(x =>  x.pur_supp.Contains(_search) || x.invocie_id.ToString().Contains(_search)).ToList(); // جلب البيانات
            data.Reverse();
            gridControl1.DataSource = data;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            
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
            pl.frm_pur_add frm_supp_Add = new frm_pur_add();
            id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("id"));
            tb_buy = db.tb_buy.Where(x => x.id == id).FirstOrDefault();
            // frm_supp_Add.edt_name.Text = tb_sell.sell_name;
            // tb_sell = db.tb_sell.Where(x => x.sell_cus == edt_cus.Text).FirstOrDefault();
            // 
            //frm_supp_Add.edt_sell.Text = tb_sell.sell_price.ToString();
            // frm_supp_Add.edt_cat.Text = tb.sell_qt.ToString();
            frm_supp_Add.edt_date.Text = (tb_buy.pur_dat).ToString();
            frm_supp_Add.edt_pay.Text = tb_buy.pay.ToString();
            frm_supp_Add.txt_totaldata.Text = tb_buy.total_price.ToString();
            frm_supp_Add.edt_stay.Text = tb_buy.pur_tbuy.ToString();
            tb_Supp = db.tb_supp.Where(x => x.id == tb_buy.supp_id).FirstOrDefault();
            frm_supp_Add.save.Text = tb_buy.safe;
            frm_supp_Add.edt_supp.Text = tb_buy.pur_supp;
            // tb_Cus = db.tb_cus.Where(x => x.cus_name == edt_cus.Text).FirstOrDefault();

            frm_supp_Add.id = id;
            frm_supp_Add.btn_add.Text = "حفظ";
            frm_supp_Add.Show();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            btn_edit_Click(sender, e);
        }
    }
}
