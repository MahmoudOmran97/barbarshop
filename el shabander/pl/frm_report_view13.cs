using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;
using el_shabander.epl;
using System.IO;
using Microsoft.Reporting.WinForms;
namespace el_shabander.pl
{
    public partial class frm_report_view13 : Form
    {
        DB_restoraintEntities db = new DB_restoraintEntities();
        tb_safe tb_Safe = new tb_safe();
        bl.methods methods = new bl.methods();
        tb_employees tb_Employees = new tb_employees();
      
        // double storadd, stortotal, storstay;
        // DateTime time;
        //pl.frm_supp frm_Cat = new frm_supp();
        public int id;
        public frm_report_view13()

        {
            InitializeComponent();
        }

        



       




        private void frm_stor_add_Activated(object sender, EventArgs e)
        {
           
        }

        private void frm_report_view_Load(object sender, EventArgs e)
        {
           
            this.reportViewer1.RefreshReport();

            this.WindowState = FormWindowState.Maximized;




            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
        }




    }
}