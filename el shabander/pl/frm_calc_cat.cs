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
    public partial class frm_calc_cat : Form
    {
        DB_restoraintEntities db = new DB_restoraintEntities();
        tb_safe tb_Safe = new tb_safe();
        bl.methods methods = new bl.methods();
        tb_employees tb_Employees = new tb_employees();
      
        // double storadd, stortotal, storstay;
        // DateTime time;
        //pl.frm_supp frm_Cat = new frm_supp();
        public int id;
        public frm_calc_cat()

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
            var r2 = db.tb_cat.Select(x => x.cat_name).ToList();

            edt_cus.DataSource = r2;

            AutoCompleteStringCollection acsc2 = new AutoCompleteStringCollection();

            acsc2.AddRange(r2.ToArray());

            edt_cus.AutoCompleteCustomSource = acsc2;
            var r3 = db.tb_product.Where(x => x.name_cat == edt_cus.Text).Select(x => x.name_product).ToList();

            // تعيين DataSource الخاص بـ ComboBox أو TextBox
            edt_prod.DataSource = r3;

            // إعداد AutoCompleteStringCollection
            AutoCompleteStringCollection acsc3 = new AutoCompleteStringCollection();
            acsc3.AddRange(r3.ToArray());
            edt_prod.AutoCompleteCustomSource = acsc3;
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void FetchAndCombineData()
        {
            string catName = edt_cus.Text; // افترض أن اسم TextBox هو edt_cus ويحتوي على اسم الصنف
            string productname = edt_prod.Text;
            // جلب البيانات من جدول tb_product بناءً على اسم الصنف
            var tb_product = db.tb_product.Where(p => p.name_product == productname).FirstOrDefault();

            // جلب بيانات البيع من جدول tb_order_sell_table بناءً على اسم المنتج (name_sell)
            var spends = db.tb_order_sell_table
                            .Where(x => x.name_sell == tb_product.name_product)
                            .Select(x => new
                            {
                                x.sell_id,
                                x.qt_sell,
                                x.name_sell
                            }).ToList();

            // جلب بيانات البيع من جدول tb_order_sell_takeway بناءً على اسم المنتج (name_sell)
            var spends0 = db.tb_order_sell_takeway
                            .Where(x => x.name_sell == tb_product.name_product)
                            .Select(x => new
                            {
                                x.sell_id,
                                x.qt_sell,
                                x.name_sell
                            }).ToList();

            // دمج البيانات من الجدولين tb_sell_table و tb_sell_takeway
            var combinedData = (from s in spends
                                join se in db.tb_sell_table on s.sell_id equals se.id
                                join p in db.tb_product on s.name_sell equals p.name_product
                                select new
                                {
                                    IdInvoice = se.invocie_id,
                                    name = "الصالة",
                                    Date = se.sell_date,
                                    PaidAmount = s.qt_sell * p.price,
                                    Returned = s.name_sell
                                }).OrderBy(x => x.Date).ToList();

            var combinedData0 = (from s in spends0
                                 join sa in db.tb_sell_takeway on s.sell_id equals sa.id
                                 join p in db.tb_product on s.name_sell equals p.name_product
                                 select new
                                 {
                                     IdInvoice = sa.invocie_id,
                                     name = "الدليفرى/التيك اوى",
                                     Date = sa.sell_date,
                                     PaidAmount = s.qt_sell * p.price,
                                     Returned = s.name_sell
                                 }).OrderBy(x => x.Date).ToList();

            // دمج البيانات النهائي بين الجدولين المدموجين
            var allSpends= combinedData.Concat(combinedData0).ToList();

            // إنشاء DataTable وإضافة الأعمدة إليه
            DataSet1 dataSet = new DataSet1();
            dataSet.Tables["tb_cat_card"].Clear();
            frm_report_view10 reportForm = new frm_report_view10();
            foreach (var item in allSpends)
            {
                dataSet.Tables["tb_cat_card"].Rows.Add(id, item.IdInvoice, item.Date, item.PaidAmount, item.Returned,item.name);
            }

            // تحميل التقرير
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dataSet.Tables["tb_cat_card"]);
            reportForm.reportViewer1.LocalReport.DataSources.Clear();
            reportForm.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            reportForm.LoadReport(catName);

            // إغلاق النموذج الحالي وعرض نموذج التقرير
            this.Close();
            reportForm.ShowDialog();
        }

        private void edt_cus_SelectedIndexChanged(object sender, EventArgs e)
        {
            var r2 = db.tb_product.Where(x => x.name_cat == edt_cus.Text ).Select(x => x.name_product).ToList();

            // تعيين DataSource الخاص بـ ComboBox أو TextBox
            edt_prod.DataSource = r2;

            // إعداد AutoCompleteStringCollection
            AutoCompleteStringCollection acsc2 = new AutoCompleteStringCollection();
            acsc2.AddRange(r2.ToArray());
            edt_prod.AutoCompleteCustomSource = acsc2;
        }
    }
}