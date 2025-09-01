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
using DevExpress.XtraGrid.Views.Tile;
namespace el_shabander.pl
{
    public partial class frm_supp : Form
    {
        DB_restoraintEntities db = new DB_restoraintEntities();
        tb_supp tB_supp = new tb_supp();
        bl.methods methods = new bl.methods();
        bl.send send = new bl.send();
        epl.toast toast = new epl.toast();
        dialog dialog = new dialog();
        Notfication notfication = new Notfication();
        int id;
        public frm_supp()
        {
            InitializeComponent();
            
            el_shabander.DB_restoraintEntities dbContext = new el_shabander.DB_restoraintEntities();
            // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
            dbContext.tb_supp.LoadAsync().ContinueWith(loadTask =>
            {
    // Bind data to control when loading complete
    gridControl1.DataSource = dbContext.tb_supp.Local.ToBindingList();
            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
             tileView1.ItemCustomize += tileView1_ItemCustomize;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            pl.frm_supp_add frm_supp_Add = new frm_supp_add();
            frm_supp_Add.id = 0;
            frm_supp_Add.btn_add.Text = "اضافة";
            frm_supp_Add.Show();
        }

        private void btn_updata_Click(object sender, EventArgs e)
        {
            updata_data();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

            // toast toast = new toast();

            try
            {
                id = Convert.ToInt32(tileView1.GetFocusedRowCellValue("id"));

                // جلب المورد للتحقق من القيمة
                tB_supp = db.tb_supp.FirstOrDefault(x => x.id == id);

                if (tB_supp != null)
                {
                    // التحقق إذا كان total_price أكبر من 0
                    if (tB_supp.total_price > 0)
                    {
                        main frm_supp_Add = (main)Application.OpenForms["main"];

                        string notificationMessage = $"لقد حاول :  {frm_supp_Add.la_username.Text}   حذف المورد : {tB_supp.supp_name} من البيانات . ";
                        send.SendEmailWithHtmlGridData(notificationMessage);
                        notfication.notfication1 = notificationMessage;
                        notfication.CreatedAt = DateTime.Now;


                        db.Notfications.Add(notfication);
                        db.SaveChanges();
                        MessageBox.Show("لا يمكن حذف هذا المورد لأنه لديه باقي حساب", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var rs = MessageBox.Show("عملية حذف", "هل انت متاكد من هذة العملية", MessageBoxButtons.YesNo);
                    if (rs == DialogResult.Yes)
                    {
                        db.Entry(tB_supp).State = EntityState.Deleted;
                        db.SaveChanges();
                        main frm_supp_Add = (main)Application.OpenForms["main"];

                        string notificationMessage = $"تم حذف المورد : {tB_supp.supp_name} عن طريق : {frm_supp_Add.la_username.Text} التاريخ والوقت: {DateTime.Now:yyyy/MM/dd HH:mm:ss}.  ";
                        send.SendEmailWithHtmlGridData(notificationMessage);
                        notfication.notfication1 = notificationMessage;
                        notfication.CreatedAt = DateTime.Now;


                        db.Notfications.Add(notfication);
                        db.SaveChanges();
                        // عرض رسالة النجاح
                        toast.txt_caption.Text = "تم الحذف بنجاح";
                        toast.Show();
                        updata_data();
                    }
                }
                else
                {
                    MessageBox.Show("لم يتم العثور على المورد", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                dialog.Width = this.Width;
                dialog.txt_capthion.Text = "لا يوجد مورد لحذفه";
                dialog.Show();
            }
        }

        public void updata_data()
        {
            db = new DB_restoraintEntities();
            gridControl1.DataSource = db.tb_supp.ToList();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            pl.frm_supp_add frm_supp_Add = new frm_supp_add();
            id = Convert.ToInt32(tileView1.GetFocusedRowCellValue("id"));
            tB_supp = db.tb_supp.Where(x => x.id == id).FirstOrDefault();
            frm_supp_Add.edt_name.Text = tB_supp.supp_name.ToString();
            frm_supp_Add.edt_name_old.Text = tB_supp.supp_name.ToString();
            frm_supp_Add.edt_phone.Text = tB_supp.supp_phone.ToString();
            frm_supp_Add.edt_email.Text = tB_supp.supp_email.ToString();
            
            frm_supp_Add.edt_sales.ReadOnly = true;
            frm_supp_Add.edt_sales.Text = tB_supp.total_price.ToString();
            frm_supp_Add.edt_max.Text = tB_supp.supp_max.ToString();
            frm_supp_Add.pic_cover.Image = bl.methods.convert_image(tB_supp.supp_image);
            frm_supp_Add.id = id;
            frm_supp_Add.btn_add.Text = "تعديل";
            frm_supp_Add.Show();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            var _search = edit_txt.Text;
            gridControl1.DataSource = db.tb_supp.Where(x => x.supp_name.Contains(_search) || x.supp_phone.Contains(_search) || x.supp_email.Contains(_search) ).ToList();
        }

        private void btn_spend_Click(object sender, EventArgs e)
        {
            pl.frm_spend_supp frm_supp_Add = new frm_spend_supp();
            //frm_supp_Add.id = 0;
            // frm_supp_Add.btn_add.Text = "اضافة";
            frm_supp_Add.Show();
        }
        private void tileView1_ItemCustomize(object sender, TileViewItemCustomizeEventArgs e)
        {
            // افترض أن tileView1 هو الـ TileView الخاص بك
            var view = sender as TileView;
            if (view == null)
                return;

            // الحصول على قيم total_price و supp_max
            var currentRow = view.GetRow(e.RowHandle) as tb_supp;
            if (currentRow == null)
                return;

            // الحصول على قيم total_price و supp_max
            double totalPrice = Convert.ToDouble(currentRow.total_price);
            double suppMax = Convert.ToDouble(currentRow.supp_max);

            // تحقق من الشرط لتغيير اللون
            if (totalPrice > suppMax)
            {
                e.Item.AppearanceItem.Normal.BackColor = Color.Red;
                e.Item.AppearanceItem.Normal.ForeColor = Color.White;
            }
            else if (totalPrice >= (suppMax / 2) && totalPrice <= suppMax)
            {
                e.Item.AppearanceItem.Normal.BackColor = Color.Yellow;
                e.Item.AppearanceItem.Normal.ForeColor = Color.Black;
            }
            else
            {
                // تعيين اللون الافتراضي
                e.Item.AppearanceItem.Normal.BackColor = Color.White;
                e.Item.AppearanceItem.Normal.ForeColor = Color.Black;
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            btn_edit_Click(sender, e);
        }
    }
}
