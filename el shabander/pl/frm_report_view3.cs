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
using System.Drawing.Printing;
using System.Drawing.Imaging;

namespace el_shabander.pl
{
    public partial class frm_report_view3 : Form
    {
        DB_restoraintEntities db = new DB_restoraintEntities();
        tb_safe tb_Safe = new tb_safe();
        bl.methods methods = new bl.methods();
        tb_employees tb_Employees = new tb_employees();
     
        // double storadd, stortotal, storstay;
        // DateTime time;
        //pl.frm_supp frm_Cat = new frm_supp();
        public int id;
       

        public frm_report_view3()
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
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            this.reportViewer1.RenderingComplete += new RenderingCompleteEventHandler(PrintReport);
        }

       
       
       
        private void PrintReport(object sender, RenderingCompleteEventArgs e)
        {
            // إظهار مربع حوار الطباعة
            this.reportViewer1.PrintDialog();
        }

        public void LoadReport(string invoiceId, string sellDate ,string CustomerName)
        {
            this.reportViewer1.RefreshReport();
            ReportParameter[] parameters = new ReportParameter[]
            {
           new ReportParameter("CustomerName", CustomerName),
            new ReportParameter("InvoiceId", invoiceId),
            new ReportParameter("SellDate", sellDate)
            };

            this.reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            

            // تصدير التقرير إلى تنسيق EMF
           

            // طباعة التقرير مباشرة
           
        }

    }
}