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
    public partial class frm_report_view11 : Form
    {
        DB_restoraintEntities db = new DB_restoraintEntities();
        tb_safe tb_Safe = new tb_safe();
        bl.methods methods = new bl.methods();
        tb_employees tb_Employees = new tb_employees();
    
        // double storadd, stortotal, storstay;
        // DateTime time;
        //pl.frm_supp frm_Cat = new frm_supp();
        public int id;
        public frm_report_view11()

        {
            InitializeComponent();
        }

        



       




        private void frm_stor_add_Activated(object sender, EventArgs e)
        {
           
        }

        private void frm_report_view_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
          

            this.reportViewer1.RefreshReport();
            // this.reportViewer1.PrintDialog();
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
        }

        public void LoadReport( string customerName, string sellDate, string totall_price)
        {
            // byte[] imageBytes = Convert.FromBase64String(base64Image);
            this.reportViewer1.RefreshReport();
            // تعيين المعلمات
            ReportParameter[] parameters = new ReportParameter[]
            {
        new ReportParameter("CustomerName1",  customerName),
         new ReportParameter("CustomerName2",  sellDate),
         new ReportParameter("totall_price",  totall_price)
            };
           
            // تعيين المعلمات للتقرير فيور
            this.reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            // تحديث التقرير
           
        }
        
       
    }
}