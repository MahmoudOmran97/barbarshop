using System;
using System.Drawing;
using DevExpress.XtraReports.UI;

namespace el_shabander.pl
{
    public partial class rpt_Advance_Report : XtraReport
    {
        private TopMarginBand topMarginBand1;
        private DetailBand detailBand1;
        private BottomMarginBand bottomMarginBand1;

        public rpt_Advance_Report()
        {
            InitializeComponent();
            CreateReport();
        }

        private void CreateReport()
        {
            // حذف جميع الـ Bands الموجودة
            this.Bands.Clear();

            // إعدادات الصفحة
            this.Margins = new System.Drawing.Printing.Margins(50, 50, 50, 50);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.RightToLeftLayout = DevExpress.XtraReports.UI.RightToLeftLayout.Yes;

            // ============================================
            // رأس التقرير
            // ============================================
            ReportHeaderBand reportHeader = new ReportHeaderBand();
            reportHeader.HeightF = 200;
            reportHeader.Borders = DevExpress.XtraPrinting.BorderSide.All;
            reportHeader.BorderWidth = 2;
            reportHeader.BorderColor = Color.FromArgb(52, 73, 94);

            // العنوان
            XRLabel title = new XRLabel();
            title.LocationFloat = new DevExpress.Utils.PointFloat(10, 10);
            title.SizeF = new System.Drawing.SizeF(707, 45);
            title.Text = "سند سلفة";
            title.Font = new Font("Cairo", 16, FontStyle.Bold);
            title.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            title.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            title.BorderWidth = 3;
            title.BorderColor = Color.FromArgb(231, 76, 60);
            title.BackColor = Color.FromArgb(236, 240, 241);
            reportHeader.Controls.Add(title);

            // معلومات السلفة
            int yPos = 70;
            AddLabelPair(reportHeader, "اسم الموظف:", "[EmployeeName]", yPos);
            AddLabelPair(reportHeader, "المبلغ:", "[Amount] جنيه", yPos + 35);
            AddLabelPair(reportHeader, "تاريخ السلفة:", "[AdvanceDate]", yPos + 70);
            AddLabelPair(reportHeader, "الشهر / السنة:", "[Month] / [Year]", yPos + 105);

            this.Bands.Add(reportHeader);

            // ============================================
            // التفاصيل
            // ============================================
            DetailBand detail = new DetailBand();
            detail.HeightF = 150;
            detail.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right;
            detail.BorderWidth = 2;
            detail.BorderColor = Color.FromArgb(52, 73, 94);

            // ملاحظات
            XRLabel notesTitle = new XRLabel();
            notesTitle.LocationFloat = new DevExpress.Utils.PointFloat(10, 10);
            notesTitle.SizeF = new System.Drawing.SizeF(707, 35);
            notesTitle.Text = "ملاحظات";
            notesTitle.Font = new Font("Cairo", 11, FontStyle.Bold);
            notesTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            notesTitle.BackColor = Color.FromArgb(52, 152, 219);
            notesTitle.ForeColor = Color.White;
            notesTitle.Borders = DevExpress.XtraPrinting.BorderSide.All;
            notesTitle.BorderWidth = 2;
            notesTitle.BorderColor = Color.FromArgb(52, 73, 94);
            detail.Controls.Add(notesTitle);

            // مربع الملاحظات
            XRLabel notesBox = new XRLabel();
            notesBox.LocationFloat = new DevExpress.Utils.PointFloat(10, 55);
            notesBox.SizeF = new System.Drawing.SizeF(707, 80);
            notesBox.Text = "";
            notesBox.Font = new Font("Cairo", 9);
            notesBox.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            notesBox.BackColor = Color.FromArgb(245, 245, 245);
            notesBox.Borders = DevExpress.XtraPrinting.BorderSide.All;
            notesBox.BorderWidth = 1;
            notesBox.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 10, 10);
            detail.Controls.Add(notesBox);

            this.Bands.Add(detail);

            // ============================================
            // تذييل التقرير
            // ============================================
            ReportFooterBand footer = new ReportFooterBand();
            footer.HeightF = 180;
            footer.Borders = DevExpress.XtraPrinting.BorderSide.All;
            footer.BorderWidth = 2;
            footer.BorderColor = Color.FromArgb(52, 73, 94);

            // التوقيعات
            XRLabel sigTitle = new XRLabel();
            sigTitle.LocationFloat = new DevExpress.Utils.PointFloat(10, 10);
            sigTitle.SizeF = new System.Drawing.SizeF(707, 30);
            sigTitle.Text = "التوقيعات";
            sigTitle.Font = new Font("Cairo", 11, FontStyle.Bold);
            sigTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            sigTitle.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            sigTitle.BorderWidth = 2;
            sigTitle.BackColor = Color.FromArgb(236, 240, 241);
            footer.Controls.Add(sigTitle);

            // امضاء المستلم (على اليمين)
            XRLabel empSig = new XRLabel();
            empSig.LocationFloat = new DevExpress.Utils.PointFloat(377, 55);
            empSig.SizeF = new System.Drawing.SizeF(340, 110);
            empSig.Text = "امضاء المستلم:_________________التاريخ:___________";
            empSig.Font = new Font("Cairo", 9);
            empSig.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            empSig.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            empSig.Borders = DevExpress.XtraPrinting.BorderSide.All;
            empSig.BorderWidth = 1;
            empSig.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 10, 5, 5);
            empSig.CanGrow = false;
            footer.Controls.Add(empSig);

            // امضاء المسؤول (على الشمال)
            XRLabel managerSig = new XRLabel();
            managerSig.LocationFloat = new DevExpress.Utils.PointFloat(10, 55);
            managerSig.SizeF = new System.Drawing.SizeF(360, 110);
            managerSig.Text = "امضاء المسؤول:__________________التاريخ:___________";
            managerSig.Font = new Font("Cairo", 9);
            managerSig.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            managerSig.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            managerSig.Borders = DevExpress.XtraPrinting.BorderSide.All;
            managerSig.BorderWidth = 1;
            managerSig.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 10, 5, 5);
            managerSig.CanGrow = false;
            footer.Controls.Add(managerSig);

            this.Bands.Add(footer);

            // ============================================
            // تذييل الصفحة
            // ============================================
            PageFooterBand pageFooter = new PageFooterBand();
            pageFooter.HeightF = 35;

            XRPageInfo pageInfo = new XRPageInfo();
            pageInfo.LocationFloat = new DevExpress.Utils.PointFloat(0, 7);
            pageInfo.SizeF = new System.Drawing.SizeF(727, 23);
            pageInfo.PageInfo = DevExpress.XtraPrinting.PageInfo.NumberOfTotal;
            pageInfo.Format = "صفحة {0} من {1}";
            pageInfo.Font = new Font("Cairo", 9);
            pageInfo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            pageInfo.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            pageInfo.BorderWidth = 1;
            pageFooter.Controls.Add(pageInfo);

            this.Bands.Add(pageFooter);
        }

        private void AddLabelPair(Band band, string labelText, string valueText, float yPos)
        {
            // Label على الشمال
            XRLabel label = new XRLabel();
            label.LocationFloat = new DevExpress.Utils.PointFloat(17, yPos);
            label.SizeF = new System.Drawing.SizeF(170, 30);
            label.Text = labelText;
            label.Font = new Font("Cairo", 9, FontStyle.Bold);
            label.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            label.Borders = DevExpress.XtraPrinting.BorderSide.All;
            label.BorderWidth = 1;
            label.BackColor = Color.FromArgb(189, 195, 199);
            label.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5);
            band.Controls.Add(label);

            // Value على اليمين
            XRLabel value = new XRLabel();
            value.LocationFloat = new DevExpress.Utils.PointFloat(197, yPos);
            value.SizeF = new System.Drawing.SizeF(513, 30);
            value.Text = valueText;
            value.Font = new Font("Cairo", 9);
            value.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            value.BackColor = Color.FromArgb(245, 245, 245);
            value.Borders = DevExpress.XtraPrinting.BorderSide.All;
            value.BorderWidth = 1;
            value.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 10, 5, 5);
            band.Controls.Add(value);
        }

        private void InitializeComponent()
        {
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.detailBand1 = new DevExpress.XtraReports.UI.DetailBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // topMarginBand1
            // 
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // detailBand1
            // 
            this.detailBand1.Name = "detailBand1";
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // rpt_Advance_Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.topMarginBand1,
            this.detailBand1,
            this.bottomMarginBand1});
            this.Version = "19.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
    }
}