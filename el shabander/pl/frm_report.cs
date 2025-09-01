using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using el_shabander.epl;
using DevExpress.XtraReports.UI;
using Microsoft.Reporting.WinForms;

namespace el_shabander.pl
{
    public partial class frm_report : Form
    {
        DB_restoraintEntities db = new DB_restoraintEntities();
        tb_safe tb_Safe = new tb_safe();
       
        public int id;
        public frm_report()
        {
            InitializeComponent();
           
        }

        

        private void tileItem1_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {

            pl.frm_calc_day frm_Calc_Cus = new frm_calc_day();
            frm_Calc_Cus.Show();

        }

        private void tileItem6_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frm_report_view14 reportForm = new frm_report_view14();
            var sells = db.tb_buy.Select(x => new
            {
                cus_name = x.pur_supp,
                Date = x.pur_dat,
                totall = x.pur_tbuy,
                PaidAmount = x.pay,
                Remaining = x.stay,
                // فرضًا لا يوجد مرتجع في عملية البيع
            }).ToList();
            DataSet1 dataSet = new DataSet1();
            dataSet.Tables["tb_pur"].Clear();


            foreach (var item in sells)
            {
                dataSet.Tables["tb_pur"].Rows.Add(item.cus_name, item.Date, item.totall, item.PaidAmount, item.Remaining);
            }
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dataSet.Tables["tb_pur"]);

            reportForm.reportViewer1.LocalReport.DataSources.Clear();
            reportForm.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            reportForm.ShowDialog();
        }

        private void فاتورة_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            pl.frm_calc_cat frm_Calc_Cus = new frm_calc_cat();
            frm_Calc_Cus.Show();
        }

        private void tileItem8_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            pl.frm_calc_earning frm_Calc_Cus = new frm_calc_earning();
            frm_Calc_Cus.Show();
        }

        private void tileItem7_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frm_report_view5 reportForm = new frm_report_view5();
            var sells = db.tb_supp.Select(x => new
            {
                cus_name = x.supp_name,
                address = x.supp_email,
                totall = x.total_price,
                phone = x.supp_phone

                // فرضًا لا يوجد مرتجع في عملية البيع
            }).ToList();
            DataSet1 dataSet = new DataSet1();
            dataSet.Tables["tb_supp"].Clear();


            foreach (var item in sells)
            {
                dataSet.Tables["tb_supp"].Rows.Add(item.cus_name, item.address, item.totall, item.phone);
            }
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dataSet.Tables["tb_supp"]);

            reportForm.reportViewer1.LocalReport.DataSources.Clear();
            reportForm.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            reportForm.ShowDialog();
        }

        private void tileItem12_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            pl.frm_calc_supp frm_Calc_Cus = new frm_calc_supp();
            frm_Calc_Cus.Show();
        }

        private void tileItem5_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frm_report_view13 reportForm = new frm_report_view13();
            var sells = db.tb_cat.Select(x => new
            {
                cat_name= x.cat_name,
                qt = x.qt,
                unit=x.unit
                
            }).ToList();
            DataSet1 dataSet = new DataSet1();
            dataSet.Tables["tb_cat"].Clear();


            foreach (var item in sells)
            {
                dataSet.Tables["tb_cat"].Rows.Add(item.cat_name, item.qt,item.unit);
            }
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dataSet.Tables["tb_cat"]);

            reportForm.reportViewer1.LocalReport.DataSources.Clear();
            reportForm.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            reportForm.ShowDialog();

        }

        private void tileItem10_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            pl.frm_calc_safe frm_Calc_Cus = new frm_calc_safe();
            frm_Calc_Cus.Show();
        }

       
    }
       
}
