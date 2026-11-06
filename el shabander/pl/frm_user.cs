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
using DevExpress.XtraGrid.Views.Grid;
namespace el_shabander.pl
{
    public partial class frm_user : Form
    {
        DB_BarbershopEntities db = new DB_BarbershopEntities();
        tb_user tb_user = new tb_user();
        bl.methods methods = new bl.methods();
        toast toast = new toast();
        DataTable dt = new DataTable();

        int id;
        public frm_user()
        {
            InitializeComponent();


         
            el_shabander.DB_BarbershopEntities dbContext = new el_shabander.DB_BarbershopEntities();
            // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
            dbContext.tb_user.LoadAsync().ContinueWith(loadTask =>
            {
    // Bind data to control when loading complete
    gridControl1.DataSource = dbContext.tb_user.Local.ToBindingList();
            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            pl.frm_user_add frm_supp_Add = new frm_user_add();
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

            toast toast = new toast();
            dialog dialog = new dialog();
            try
            {
                id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("id"));
                var rs = MessageBox.Show("عملية حذف", "هل انت متاكد من هذة العملية", MessageBoxButtons.YesNo);
                if (rs == DialogResult.Yes)
                {
                   tb_user= db.tb_user.Where(x => x.id == id).FirstOrDefault();
                    db.Entry(tb_user).State = EntityState.Deleted;
                    db.SaveChanges();
                    toast.txt_caption.Text = "تم الحذف بنجاح";
                    toast.Show();
                    updata_data();
                }
               
            }
            catch
            {
                dialog.Width = this.Width;
                dialog.txt_capthion.Text = "لا يوجد مستخدم لحزفه ";
                dialog.Show();
            }
        }

        public void updata_data()
        {
            db = new DB_BarbershopEntities();
            gridControl1.DataSource = db.tb_user.ToList();
          //  string gg = gridView1.GetRowCellValue(3, "user_state");
          

        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            pl.frm_user_add frm_supp_Add = new frm_user_add();
           id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("id"));
           tb_user= db.tb_user.Where(x => x.id == id).FirstOrDefault();
            frm_supp_Add.edt_name.Text = tb_user.user_name;
            frm_supp_Add.edt_pass.Text = tb_user.user_pass;
            frm_supp_Add.edt_roll.Text = tb_user.user_roll;
           
            frm_supp_Add.pic_cover.Image = bl.methods.convert_image(tb_user.user_image);
            frm_supp_Add.edt_mail.Text = tb_user.user_mail;
            frm_supp_Add.id = id;
            frm_supp_Add.btn_add.Text = "تعديل";
            frm_supp_Add.Show();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            var _search = edit_txt.Text;
            gridControl1.DataSource = db.tb_user.Where(x => x.user_name.Contains(_search) ).ToList();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView gridView = sender as GridView; 
            if (e.RowHandle>=0)
            {
                string pr = gridView.GetRowCellDisplayText(e.RowHandle, gridView.Columns["user_state"]);
                if(pr=="مفتوح")
                {
                    e.Appearance.BackColor = System.Drawing.Color.Green;
                    e.Appearance.ForeColor = System.Drawing.Color.White;
                }else
                {
                    e.Appearance.BackColor = System.Drawing.Color.Red;
                    e.Appearance.ForeColor = System.Drawing.Color.White;
                }
            
           
            }
        }
    }
}
