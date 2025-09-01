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
    public partial class frm_sell : Form
    {
        DB_restoraintEntities db = new DB_restoraintEntities();
        tb_sell_table tb_sell_table = new tb_sell_table();
        bl.methods methods = new bl.methods();
        toast toast = new toast();
        tb_cus tb_Cus = new tb_cus();
        tb_order_sell_table tb_order_sell_table = new tb_order_sell_table();
       // tb_stuk tb_Stuk = new tb_stuk();
        tb_safe tb_Safe = new tb_safe();
        int id;
        public frm_sell()
        {
            InitializeComponent();


           
            el_shabander.DB_restoraintEntities dbContext = new el_shabander.DB_restoraintEntities();
            // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
            dbContext.tb_sell_table.LoadAsync().ContinueWith(loadTask =>
            {
               /* List<tb_sell_table> data = db.tb_sell_table.ToList(); // جلب البيانات
                data.Reverse();
                gridControl1.DataSource = data;*/
                // Bind data to control when loading complete
                gridControl1.DataSource = dbContext.tb_sell_table.Local.ToBindingList().Reverse();
            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            pl.frm_sell_add frm_supp_Add = new frm_sell_add();
            frm_supp_Add.id = 0;
            frm_supp_Add.btn_save.Text = "إضافة"; // يجب أن يكون btn_save وليس btn_add
            frm_supp_Add.Show();

        }

        private void btn_updata_Click(object sender, EventArgs e)
        {
            updata_data();
        }
        public List<tb_order_sell_table> listorder;

        private void btn_delete_Click(object sender, EventArgs e)
        {

            toast toast = new toast();
            dialog dialog = new dialog();
            try
            {
                id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("id"));
               
                var rs = MessageBox.Show("عملية حذف", "هل انت متاكد من هذة العملية", MessageBoxButtons.YesNo);
                if (rs == DialogResult.Yes)
                {
                    tb_sell_table = db.tb_sell_table.Where(x => x.id == id).FirstOrDefault();
                    db.Entry(tb_sell_table).State = EntityState.Deleted;

                    db.SaveChanges();

                    listorder = db.tb_order_sell_table.Where(x => x.sell_id ==tb_sell_table.id).ToList();
                    for (int i = 0; i < listorder.Count; i++)
                    {
                    
                       string dd = listorder[i].name_sell;

                     // tb_Stuk = db.tb_stuk.Where(x => x.stuk_name == dd).FirstOrDefault();

                    //  MessageBox.Show("ghg" + listorder[i].name_sell);
                      double ss=Convert.ToDouble (listorder[i].qt_sell);
                        if (listorder[i].weight == "كبرى")
                        {
                            //tb_Stuk = db.tb_stuk.Where(x => x.stuk_name == edt_name.Text).FirstOrDefault();
                         //  ss *= Convert.ToDouble(tb_Stuk.stuk_qtfacttotal);

                        }
                      //  tb_Stuk.stuk_qt += ss;
                      try
                      {
                      //  db.Entry(tb_Stuk).State = System.Data.Entity.EntityState.Modified;
                       //   db.SaveChanges();
                      }
                      catch
                      {
                         MessageBox.Show("ghg");
                     }


                     }
                    tb_Cus = db.tb_cus.Where(x => x.cus_name == tb_sell_table.sell_cus).FirstOrDefault();
                  // tb_Cus.total_price += tb_sell_table.cus_price;
                  //  tb_Cus.total_price -= tb_sell_table.total_sell-tb_sell_table.pay;
                   
                    db.Entry(tb_Cus).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    tb_Safe = db.tb_safe.Where(x => x.safe_name ==tb_sell_table.safe).FirstOrDefault();
                    tb_Safe.safe_count -= tb_sell_table.pay;
                    db.Entry(tb_Safe).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    toast.txt_caption.Text = "تم الحذف بنجاح";
                    toast.Show();
                    updata_data();
                }
               
            }
            catch
            {
                dialog.Width = this.Width;
               dialog.txt_capthion.Text = "لا يوجد بيع لحزفها ";
                dialog.Show();
            }
        }

        private void updata_data()
        {
            db = new DB_restoraintEntities();
            List<tb_sell_table> data = db.tb_sell_table.ToList(); // جلب البيانات
            data.Reverse();
            gridControl1.DataSource = data;
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {

            pl.frm_sell_add frm_supp_Add = new frm_sell_add();
            int selectedIndex = gridView1.FocusedRowHandle;

            if (selectedIndex >= 0 && selectedIndex < gridView1.RowCount)
            {
                id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("id"));

              //  frm_supp_Add.Invoices = db.tb_sell_table.ToList();
                frm_supp_Add.CurrentInvoiceIndex = frm_supp_Add.Invoices.FindIndex(x => x.id == id);

                if (frm_supp_Add.CurrentInvoiceIndex >= 0)
                {
                    frm_supp_Add.id = id;
                    frm_supp_Add.btn_save.Text = "حفظ";
                    frm_supp_Add.Show();
                }
                else
                {
                    MessageBox.Show("لا يمكن العثور على الفاتورة المحددة.");
                }
            }
            else
            {
                MessageBox.Show("لم يتم تحديد فاتورة.");
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            var _search = edit_txt.Text;
            List<tb_sell_table> data = db.tb_sell_table.Where(x =>  x.sell_cus.Contains(_search) || x.invocie_id.ToString().Contains(_search) ).ToList(); // جلب البيانات
            data.Reverse();

            gridControl1.DataSource = data;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
