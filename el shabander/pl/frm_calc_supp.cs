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
using Microsoft.Reporting.WinForms;

namespace el_shabander.pl
{
    public partial class frm_calc_supp : Form
    {
        DB_BarbershopEntities db = new DB_BarbershopEntities();
        tb_supp tb_supp = new tb_supp();

        // double storadd, stortotal, storstay;
        // DateTime time;
        //pl.frm_supp frm_Cat = new frm_supp();
        public int id;
        public frm_calc_supp()

        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
           
            FetchAndCombineData();
           

        }



        private void label3_Click(object sender, EventArgs e)
        {

        }





        private void frm_stor_add_Activated(object sender, EventArgs e)
        {
            var r2 = db.tb_supp.Select(x => x.supp_name).ToList();

            edt_cus.DataSource = r2;

            AutoCompleteStringCollection acsc2 = new AutoCompleteStringCollection();

            acsc2.AddRange(r2.ToArray());

            edt_cus.AutoCompleteCustomSource = acsc2;
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        public void FetchAndCombineData()
        {
            string customerName = edt_cus.Text; // فرضًا أن اسم TextBox هو textBoxCustomerName
            var tbstuck = db.tb_supp.ToList();
            if (!tbstuck.Any())
            {
                MessageBox.Show("الرجاء اضافة مورد", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // الخروج من العملية إذا لم يتم العثور على العميل
            }

            // جلب البيانات من الجداول الثلاثة بناءً على اسم العميل
            var sells = db.tb_buy
                .Where(x => x.pur_supp == customerName)
                .Select(x => new
                {
                    OperationType = "عملية شراء",
                    Date = x.pur_dat,
                    PreviousBalance = x.supp_price,
                    PaidAmount = x.pay,
                    Remaining = x.stay,
                    Returned = x.pay - x.pay // فرضًا لا يوجد مرتجع في عملية البيع
                }).ToList();

            var spends = db.tb_spend_supp
                .Where(x => x.name_supp == customerName)
                .Select(x => new
                {
                    OperationType = "سداد مورد",
                    Date = x.date,
                    PreviousBalance = x.mony_rev,
                    PaidAmount = x.mony_spend,
                    Remaining = x.mony_stay,
                    Returned = x.mony_spend - x.mony_spend // فرضًا لا يوجد مرتجع في سداد العميل
                }).ToList();

           

            // دمج البيانات في قائمة واحدة وترتيبها حسب التاريخ
            var combinedData = sells
                .Concat(spends)
                
                .OrderBy(x => x.Date)
                .ToList();

            // إنشاء DataTable وإضافة الأعمدة
            DataSet1 dataSet = new DataSet1();
            dataSet.Tables["tb_calc_cus"].Clear();
            frm_report_view4 reportForm = new frm_report_view4();
            foreach (var item in combinedData)
            {
                dataSet.Tables["tb_calc_cus"].Rows.Add(id, item.OperationType, item.Date, item.PreviousBalance, item.PaidAmount, item.Remaining, item.Returned);
            }
            tb_supp = db.tb_supp.Where(x => x.supp_name == edt_cus.Text).FirstOrDefault();
            string customername = edt_cus.Text;
            string totall_price = tb_supp.total_price.ToString();


            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dataSet.Tables["tb_calc_cus"]);

            reportForm.reportViewer1.LocalReport.DataSources.Clear();
            reportForm.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            reportForm.LoadReport(customerName, totall_price);
            this.Close();
            reportForm.ShowDialog();

        }
    }
}