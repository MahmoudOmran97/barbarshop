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
using System.Data.Entity;
using el_shabander.epl;
using Microsoft.Reporting.WinForms;
namespace el_shabander.pl
{
    public partial class frm_calc_day : Form
    {
        DB_BarbershopEntities db = new DB_BarbershopEntities();
        tb_safe tb_Safe = new tb_safe();
        bl.methods methods = new bl.methods();
        tb_employees tb_Employees = new tb_employees();
     
        // double storadd, stortotal, storstay;
        // DateTime time;
        //pl.frm_supp frm_Cat = new frm_supp();
        public int id;
        public frm_calc_day()

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

            // جمع قيمة total_price من جدول tb_appointment حيث التاريخ بعد آخر تاريخ
            var totalSum = db.tb_appointment
                            .Where(x => DbFunctions.TruncateTime(x.sell_date) ==fromDate)
                            .Select(x => new
                            {
                                OperationType = "عملية بيع صاله",
                                Date = x.sell_date,

                                Returned = x.sell_tprice,
                                PaidAmount = x.pay,
                                invoice = x.invocie_id
                                // فرضًا لا يوجد مرتجع في عملية البيع
                            }).ToList();
           /* var totalSumtake = db.tb_sell_takeway
                           .Where(x => DbFunctions.TruncateTime(x.sell_date) == fromDate)
                           .Select(x => new
                           {
                               OperationType = "عملية بيع خارجى",
                               Date = x.sell_date,

                               Returned = x.sell_tprice,
                               PaidAmount = x.pay,
                               invoice = x.invocie_id
                               // فرضًا لا يوجد مرتجع في عملية البيع
                           }).ToList();*/

            // عرض النتيجة في TextBox
            var combinedData = totalSum
            .OrderBy(x => x.Date).ToList();
            DataSet1 dataSet = new DataSet1();
            dataSet.Tables["tb_import_export"].Clear();
            frm_report_view1 reportForm = new frm_report_view1();
            foreach (var item in combinedData)
            {
                dataSet.Tables["tb_import_export"].Rows.Add(id, item.OperationType, item.Date, item.Returned, item.PaidAmount, item.invoice);
            }
            var totalPaidAmount = combinedData.Sum(x => x.PaidAmount);
            var totalPaidAmount2 = combinedData.Sum(x => x.Returned) - combinedData.Sum(x => x.PaidAmount);
            string totall_price = totalPaidAmount.ToString();
            string totall_stay = totalPaidAmount2.ToString();
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dataSet.Tables["tb_import_export"]);

            reportForm.reportViewer1.LocalReport.DataSources.Clear();
            reportForm.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            reportForm.LoadReport(totall_price, totall_stay);
            this.Close();
            reportForm.ShowDialog();
            


        }

        private void frm_calc_earning_Load(object sender, EventArgs e)
        {
           
        }
    }
}