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
    public partial class frm_report_view6 : Form
    {
        DB_elshEntities1 db = new DB_elshEntities1();
        tb_safe tb_Safe = new tb_safe();
        bl.methods methods = new bl.methods();
        tb_employees tb_Employees = new tb_employees();
       tb_stuk tb_stuk = new tb_stuk();
        // double storadd, stortotal, storstay;
        // DateTime time;
        //pl.frm_supp frm_Cat = new frm_supp();
        public int id;
        public frm_report_view6()

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

        public void LoadReport( string invoiceId, string customerName, string sellDate, string payment, string stayCustomer, string total, string totalAll, string customerPhone, string customerEmail, string remaining)
        {
          
           // byte[] imageBytes = Convert.FromBase64String(base64Image);
            string base64Image = Properties.Settings.Default.logocomp;
            Image logoImage = Base64StringToImage(base64Image);
            // تعيين المعلمات
            ReportParameter[] parameters = new ReportParameter[]
            {
        new ReportParameter("CompanyName",  Properties.Settings.Default.namecomp),
        new ReportParameter("Phone", Properties.Settings.Default.phonenam),
        new ReportParameter("Address", Properties.Settings.Default.address),
        new ReportParameter("InvoiceId", invoiceId),
        new ReportParameter("CustomerName", customerName),
        new ReportParameter("SellDate", sellDate),
        new ReportParameter("Payment", payment),
        new ReportParameter("StayCustomer", stayCustomer),
        new ReportParameter("Total", total),
        new ReportParameter("TotalAll", totalAll),
        new ReportParameter("CustomerPhone", customerPhone),
        new ReportParameter("CustomerEmail", customerEmail),
        new ReportParameter("Remaining", remaining),
        new ReportParameter("Logo",Convert.ToBase64String(  ConvertImageToByteArray(logoImage)))
            };
           
            // تعيين المعلمات للتقرير فيور
            this.reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            // تحديث التقرير
            this.reportViewer1.RefreshReport();
        }
        private Image Base64StringToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                return Image.FromStream(ms);
            }
        }
        private byte[] ConvertImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }
    }
}