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
    public partial class frm_employees : Form
    {
        DB_restoraintEntities db = new DB_restoraintEntities();
        // tb_user tb_user = new tb_user();
        tb_employees tb_Employees = new tb_employees();
        bl.methods methods = new bl.methods();
        toast toast = new toast();
        
        int id;
        public frm_employees()
        {
            InitializeComponent();




            el_shabander.DB_restoraintEntities dbContext = new el_shabander.DB_restoraintEntities();
            // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
            dbContext.tb_employees.LoadAsync().ContinueWith(loadTask =>
            {
    // Bind data to control when loading complete
    gridControl1.DataSource = dbContext.tb_employees.Local.ToBindingList();
            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
            gridView1.OptionsBehavior.Editable = false;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            pl.frm_employees_add frm_supp_Add = new frm_employees_add();
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
                    tb_Employees = db.tb_employees.Where(x => x.id == id).FirstOrDefault();
                    db.Entry(tb_Employees).State = EntityState.Deleted;
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
            db = new DB_restoraintEntities();
            gridControl1.DataSource = db.tb_employees.ToList();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            pl.frm_employees_add frm_supp_Add = new frm_employees_add();
            id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("id"));
            tb_Employees = db.tb_employees.Where(x => x.id == id).FirstOrDefault();
            frm_supp_Add.edt_name.Text = tb_Employees.emp_name;
            frm_supp_Add.edt_typeemp.Text = tb_Employees.emp_type_emp;
            frm_supp_Add.edt_salery.Text = tb_Employees.emp_salers.ToString();
            frm_supp_Add.edt_salerypay.Text = tb_Employees.emp_paysalers.ToString();
            frm_supp_Add.edt_salerystay.Text = tb_Employees.emp_staysalers.ToString();
            frm_supp_Add.edt_saleryday.Text = tb_Employees.emp_datemont;
            frm_supp_Add.edt_freeday.Text = tb_Employees.emp_freeday.ToString();

            
            frm_supp_Add.pic_cover.Image = bl.methods.convert_image(tb_Employees.emp_image);

            frm_supp_Add.id = id;
            frm_supp_Add.btn_add.Text = "تعديل";
            frm_supp_Add.Show();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            var _search = edit_txt.Text;
            gridControl1.DataSource = db.tb_employees.Where(x => x.emp_name.Contains(_search) || x.emp_type_emp.Contains(_search)).ToList();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void edt_absent_Click(object sender, EventArgs e)
        {
            pl.frm_employee_absent frm_supp_Add = new frm_employee_absent();
            frm_supp_Add.Show();
        }
    }
}
