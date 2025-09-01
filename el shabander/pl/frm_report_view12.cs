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
    public partial class frm_report_view12 : Form
    {
        DB_restoraintEntities db = new DB_restoraintEntities();
        tb_safe tb_Safe = new tb_safe();
        bl.methods methods = new bl.methods();
        tb_employees tb_Employees = new tb_employees();
     
        // double storadd, stortotal, storstay;
        // DateTime time;
        //pl.frm_supp frm_Cat = new frm_supp();
        public int id;
        public frm_report_view12()

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
            this.reportViewer1.RenderingComplete += new RenderingCompleteEventHandler(PrintReport);

        }
        private void PrintReport(object sender, RenderingCompleteEventArgs e)
        {
            // إظهار مربع حوار الطباعة
            this.reportViewer1.PrintDialog();
        }

        public void LoadReport( string invoiceId, string customerName, string sellDate, string payment,  string total, string customerPhone, string customerEmail ,string cut ,string add)
        {
            this.reportViewer1.RefreshReport();
            // byte[] imageBytes = Convert.FromBase64String(base64Image);
            var setting = db.AppSettings.FirstOrDefault(s => s.id == 1); // افتراض أن لديك عمود cid فريد يمثل السجل

            if (setting == null)
            {
                MessageBox.Show("Settings not found in the database.");
                return;
            }

            // تحويل الشعار المخزن كـ byte[] إلى صورة
            Image logoImage = null;
            if (setting.logocomp != null)
            {
                logoImage = ByteArrayToImage(setting.logocomp);
            }
            // تعيين المعلمات
            ReportParameter[] parameters = new ReportParameter[]
            {
       new ReportParameter("CompanyName", setting.namecomp), // اسم الشركة من قاعدة البيانات
            new ReportParameter("Phone", setting.phonenam), // رقم الهاتف من قاعدة البيانات
            new ReportParameter("Address", setting.address),
        new ReportParameter("InvoiceId", invoiceId),
        new ReportParameter("CustomerName", customerName),
        new ReportParameter("SellDate", sellDate),
        new ReportParameter("Payment", payment),
     
        new ReportParameter("Total", total),
      new ReportParameter("cut", cut),
          new ReportParameter("add", add),
        new ReportParameter("CustomerPhone", customerPhone),
        new ReportParameter("CustomerEmail", customerEmail),

       new ReportParameter("Logo", Convert.ToBase64String(ConvertImageToByteArray(logoImage)))
            };
           
            // تعيين المعلمات للتقرير فيور
            this.reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            // تحديث التقرير
           
        }
        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        private byte[] ConvertImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private void frm_report_view12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}