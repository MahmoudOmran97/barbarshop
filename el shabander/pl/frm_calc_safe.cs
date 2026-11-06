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
    public partial class frm_calc_safe : Form
    {
        DB_BarbershopEntities db = new DB_BarbershopEntities();
        tb_safe tb_Safe = new tb_safe();
        bl.methods methods = new bl.methods();
        tb_employees tb_Employees = new tb_employees();
      
        // double storadd, stortotal, storstay;
        // DateTime time;
        //pl.frm_supp frm_Cat = new frm_supp();
        public int id;
        public frm_calc_safe()

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
            var r2 = db.tb_safe.Select(x => x.safe_name).ToList();

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

            var tbstuck = db.tb_safe.ToList();
            if (!tbstuck.Any())
            {
                MessageBox.Show("الرجاء اضافة خزينة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // الخروج من العملية إذا لم يتم العثور على العميل
            }
            // جلب البيانات من الجداول الثلاثة بناءً على اسم العميل


            var sells = db.tb_appointment
               .Where(x => x.safe == edt_cus.Text)
               .Select(x => new
               {
                   OperationType = "عملية بيع صاله",
                   Date = x.sell_date,
                   name = x.sell_cus,
                   PreviousBalance = x.pay - x.pay,
                   Returned = x.sell_tprice,
                   PaidAmount = x.pay,
                   Remaining = x.pay - x.pay
                   // فرضًا لا يوجد مرتجع في عملية البيع
               }).ToList();

           /* var spendcus = db.tb_sell_takeway
                .Where(x => x.safe == edt_cus.Text)
                .Select(x => new
                {
                    OperationType = "عملية بيع خارجى",
                    Date = x.sell_date,
                    name = x.sell_cus,
                    PreviousBalance = x.pay - x.pay,
                    Returned = x.sell_tprice,
                    PaidAmount = x.pay,
                    Remaining = x.pay - x.pay
                    // فرضًا لا يوجد مرتجع في سداد العميل
                }).ToList();*/
            var spendsupp = db.tb_spend_supp
               .Where(x => x.safe == edt_cus.Text)
               .Select(x => new
               {
                   OperationType = "سداد مورد",
                   Date = x.date,
                   name = x.name_supp,
                   PreviousBalance = x.mony_rev,
                   Returned = x.mony_spend - x.mony_spend,
                   PaidAmount = x.mony_spend,
                   Remaining = x.mony_stay
                   // فرضًا لا يوجد مرتجع في سداد العميل
               }).ToList();
            var pay = db.tb_buy
              .Where(x => x.safe == edt_cus.Text)
              .Select(x => new
              {
                  OperationType = "عملية شراء",
                  Date = x.pur_dat,
                  name = x.pur_supp,
                  PreviousBalance = x.supp_price,
                  Returned = x.total_price,
                  PaidAmount = x.pay,
                  Remaining = x.stay
                  // فرضًا لا يوجد مرتجع في عملية البيع
              }).ToList();
            var stor = db.tb_stor
             .Where(x => x.safe_name == edt_cus.Text)
             .Select(x => new
             {
                 OperationType = "مصاريف",
                 Date = x.stor_dete,
                 name = x.stor_empname,
                 PreviousBalance = x.stor_spen - x.stor_spen,
                 Returned = x.stor_spen - x.stor_spen,
                 PaidAmount = x.stor_spen,
                 Remaining = x.stor_spen - x.stor_spen
                 // فرضًا لا يوجد مرتجع في عملية البيع
             }).ToList();
            var smove = db.tb_movement
           .Where(x => x.save == edt_cus.Text)
           .Select(x => new
           {
               OperationType = "حركة نقدية",
               Date = x.date,
               name = x.typemotion,
               PreviousBalance = x.mount - x.mount,
               Returned = x.mount - x.mount,
               PaidAmount = x.mount,
               Remaining = x.mount - x.mount
               // فرضًا لا يوجد مرتجع في عملية البيع
           }).ToList();
            // دمج البيانات في قائمة واحدة وترتيبها حسب التاريخ
            var combinedData = sells
                
                .Concat(spendsupp)
                .Concat(pay)
                .Concat(stor)
                .Concat(smove)
                .OrderBy(x => x.Date)
                .ToList();

            // إنشاء DataTable وإضافة الأعمدة
            DataSet1 dataSet = new DataSet1();
            dataSet.Tables["tb_import_export"].Clear();
            frm_report_view8 reportForm = new frm_report_view8();
            foreach (var item in combinedData)
            {
                dataSet.Tables["tb_import_export"].Rows.Add(id, item.OperationType, item.Date, item.PreviousBalance, item.Returned, item.PaidAmount, item.Remaining,item.name);
            }
            tb_Safe = db.tb_safe.Where(x => x.safe_name == edt_cus.Text).FirstOrDefault();
            string customername = edt_cus.Text;
            string totall_price = tb_Safe.safe_count.ToString();
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dataSet.Tables["tb_import_export"]);

            reportForm.reportViewer1.LocalReport.DataSources.Clear();
            reportForm.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            reportForm.LoadReport(customerName, totall_price);
            this.Close();
            reportForm.ShowDialog();

        }
    }
}