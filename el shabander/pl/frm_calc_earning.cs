using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using el_shabander.epl;
using Microsoft.Reporting.WinForms;
namespace el_shabander.pl
{
    public partial class frm_calc_earning : Form
    {
        DB_BarbershopEntities db = new DB_BarbershopEntities();
        tb_safe tb_Safe = new tb_safe();
        bl.methods methods = new bl.methods();
        tb_employees tb_Employees = new tb_employees();
     
        // double storadd, stortotal, storstay;
        // DateTime time;
        //pl.frm_supp frm_Cat = new frm_supp();
        public int id;
        public frm_calc_earning()

        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            
            // report1.la_cus_price.Text = tb_stuk.total_price.ToString();
            FetchAndCombineData();
           

        }



        private void label3_Click(object sender, EventArgs e)
        {

        }





        private void frm_stor_add_Activated(object sender, EventArgs e)
        {



            ApplyArabicCulture();

            // ضبط DateTimePicker
            SetArabicDateFormat(edt_from);
            SetArabicDateFormat(edt_to);


        }
        private void ApplyArabicCulture()
        {
            CultureInfo arabicCulture = new CultureInfo("ar-EG");
            Thread.CurrentThread.CurrentCulture = arabicCulture;
            Thread.CurrentThread.CurrentUICulture = arabicCulture;
        }
        private void SetArabicDateFormat(DateTimePicker picker)
        {
            picker.Format = DateTimePickerFormat.Custom;
            picker.CustomFormat = GetArabicFormattedDate(picker.Value);

            // إجبار النصوص على أن تكون باللغة العربية وعدم الانعكاس
            picker.RightToLeft = RightToLeft.No;
            picker.RightToLeftLayout = false;

            // تحديث عند تغيير التاريخ
            picker.ValueChanged += (s, e) =>
            {
                picker.CustomFormat = GetArabicFormattedDate(picker.Value);
            };
        }

        // دالة لتنسيق التاريخ يدويًا باللغة العربية
        private string GetArabicFormattedDate(DateTime date)
        {
            string[] arabicDays = { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" };
            string[] arabicMonths = { "", "يناير", "فبراير", "مارس", "أبريل", "مايو", "يونيو", "يوليو", "أغسطس", "سبتمبر", "أكتوبر", "نوفمبر", "ديسمبر" };

            string dayName = arabicDays[(int)date.DayOfWeek];
            string monthName = arabicMonths[date.Month];

            return $"{dayName}, {date.Day} {monthName} {date.Year}";
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }
       
        public void FetchAndCombineData()
        {
            DateTime fromDate = edt_from.Value.Date;
            DateTime toDate = edt_to.Value.Date;

            // جلب البيانات من الجداول الثلاثة بناءً على اسم العميل


            var spends = db.tb_appointment.ToList()
               .Where(x => x.sell_date.HasValue &&
                x.sell_date.Value.Date >= fromDate &&
                x.sell_date.Value.Date <= toDate)
              .Select(x => new
              {
                  OperationType = "عملية بيع صاله",
                  Date = x.sell_date,
                  name = x.sell_cus,
                  PreviousBalance = x.pay,
                  PaidAmount = x.pay - x.pay
              }).ToList();
           /* var spendsout = db.tb_sell_takeway.ToList()
             .Where(x => x.sell_date.HasValue &&
                x.sell_date.Value.Date >= fromDate &&
                x.sell_date.Value.Date <= toDate)
             .Select(x => new
             {
                 OperationType = "عملية بيع دليفرى",
                 Date = x.sell_date,
                 name = x.sell_cus,
                 PreviousBalance = x.pay,
                 PaidAmount = x.pay - x.pay
             }).ToList();*/
            var spendsbuy = db.tb_buy.ToList()
             .Where(x => x.pur_dat.HasValue && x.pur_dat.Value.Date >= fromDate && x.pur_dat.Value.Date <= toDate)
             .Select(x => new
             {
                 OperationType = "عملية شراء",
                 Date = x.pur_dat,
                 name = x.pur_supp,
                 PreviousBalance = x.total_price - x.total_price,
                 PaidAmount = x.total_price
             }).ToList();
            var expense = db.tb_stor.ToList()
               .Where(x => x.stor_dete.HasValue &&
                x.stor_dete.Value.Date >= fromDate &&
                x.stor_dete.Value.Date <= toDate)
               .Select(x => new
               {
                   OperationType = "مصاريف",
                   Date = x.stor_dete,
                   name = x.stor_empname,
                   PreviousBalance = x.stor_spen-x.stor_spen,
                   PaidAmount = x.stor_spen
                   // فرضًا لا يوجد مرتجع في سداد العميل
               }).ToList();
            // دمج البيانات في قائمة واحدة وترتيبها حسب التاريخ
            var combinedData = spends
                
                 .Concat(spendsbuy)
                .Concat(expense)
                 .OrderBy(x => x.Date)
                .ToList();



            // إنشاء DataTable وإضافة الأعمدة
            DataSet1 dataSet = new DataSet1();
            dataSet.Tables["total_earnings"].Clear();
            frm_report_view11 reportForm = new frm_report_view11();
            foreach (var item in combinedData)
            {
                dataSet.Tables["total_earnings"].Rows.Add(id, item.OperationType, item.Date, item.PreviousBalance, item.PaidAmount,item.name);
            }
            var totalPaidAmount = combinedData.Sum(x => x.PaidAmount);
            var PreviousBalance = combinedData.Sum(x => x.PreviousBalance);
           
           // tb_stuk = db.tb_stuk.Where(x => x.stuk_name == edt_from.Text).FirstOrDefault();
            
            string customername = edt_from.Text;
            string customername1 = edt_to.Text;
            string customername2 = (PreviousBalance - totalPaidAmount).ToString();
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dataSet.Tables["total_earnings"]);

            reportForm.reportViewer1.LocalReport.DataSources.Clear();
            reportForm.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            reportForm.LoadReport(customername, customername1, customername2);
            this.Close();
            reportForm.ShowDialog();



        }

        private void frm_calc_earning_Load(object sender, EventArgs e)
        {
            edt_to.Text = (DateTime.Now).ToString();
            edt_from.Text = (DateTime.Now).ToString();
        }
    }
}