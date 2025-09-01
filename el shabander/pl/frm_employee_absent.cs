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
using Microsoft.Reporting.WinForms;
namespace el_shabander.pl
{
    public partial class frm_employee_absent : Form
    {
        DB_restoraintEntities db = new DB_restoraintEntities();
        tb_safe tb_Safe = new tb_safe();
        bl.methods methods = new bl.methods();
        tb_employees tb_Employees = new tb_employees();
        double saltot, salpay;
        // double storadd, stortotal, storstay;
        // DateTime time;
        //pl.frm_supp frm_Cat = new frm_supp();
        public int id;
        public frm_employee_absent()

        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {

            tb_Employees = db.tb_employees.Where(x => x.emp_name == edt_name.Text).FirstOrDefault();
            double saltot = Math.Round(Convert.ToDouble(tb_Employees.emp_salers) / 30);
            salpay = saltot * Convert.ToDouble(txt_qt.Text);
            tb_Employees.emp_dat = edt_dat.Text;
            tb_Employees.emp_absent = Convert.ToDouble(edt_spen.Text) + Convert.ToDouble(txt_qt.Text);
            tb_Employees.emp_staysalers -= salpay;
            db.Entry(tb_Employees).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();

            this.Close();



        }



        private void label3_Click(object sender, EventArgs e)
        {

        }



        private void edt_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_Employees = db.tb_employees.Where(x => x.emp_name == edt_name.Text).FirstOrDefault();
            edt_spen.Text = tb_Employees.emp_absent.ToString();
            edt_dat.Text = tb_Employees.emp_dat;

        }







        private void frm_stor_add_Activated(object sender, EventArgs e)
        {

            // edt_countsafe.Text = tb_Safe.safe_count.ToString();
        }



        private void frm_stor_add_Load(object sender, EventArgs e)
        {
            var r1 = db.tb_employees.Select(x => x.emp_name).ToList();
            // var r2 = db.tb_safe.Select(x => x.safe_name).ToList();
            edt_name.DataSource = r1;
            // edt_safe.DataSource = r2;
            AutoCompleteStringCollection acsc1 = new AutoCompleteStringCollection();
            //  AutoCompleteStringCollection acsc2 = new AutoCompleteStringCollection();
            acsc1.AddRange(r1.ToArray());
            //  acsc2.AddRange(r2.ToArray());
            edt_name.AutoCompleteCustomSource = acsc1;
        }
    }
}