using System;
using System.Drawing;
using DevExpress.XtraReports.UI;

namespace el_shabander.pl
{
    public partial class rpt_Salary_Report : XtraReport
    {
        private TopMarginBand topMarginBand1;
        private DetailBand detailBand1;
        private BottomMarginBand bottomMarginBand1;

        public rpt_Salary_Report()
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
            reportHeader.HeightF = 220;
            reportHeader.Borders = DevExpress.XtraPrinting.BorderSide.All;
            reportHeader.BorderWidth = 2;
            reportHeader.BorderColor = Color.FromArgb(52, 73, 94);

            // العنوان
            XRLabel title = new XRLabel();
            title.LocationFloat = new DevExpress.Utils.PointFloat(10, 10);
            title.SizeF = new System.Drawing.SizeF(707, 45);
            title.Text = "كشف مرتب شهري";
            title.Font = new Font("Cairo", 16, FontStyle.Bold);
            title.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            title.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            title.BorderWidth = 3;
            title.BorderColor = Color.FromArgb(231, 76, 60);
            title.BackColor = Color.FromArgb(236, 240, 241);
            reportHeader.Controls.Add(title);

            // معلومات الموظف
            int yPos = 70;
            AddLabelPair(reportHeader, "اسم الموظف:", "[EmployeeName]", yPos);
            AddLabelPair(reportHeader, "الوظيفة:", "[JobTitle]", yPos + 35);
            AddLabelPair(reportHeader, "الشهر / السنة:", "[Month] / [Year]", yPos + 70);
            AddLabelPair(reportHeader, "تاريخ الطباعة:", "[PrintDate]", yPos + 105);

            this.Bands.Add(reportHeader);

            // ============================================
            // التفاصيل
            // ============================================
            DetailBand detail = new DetailBand();
            detail.HeightF = 370;
            detail.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right;
            detail.BorderWidth = 2;
            detail.BorderColor = Color.FromArgb(52, 73, 94);

            // قسم الحضور
            XRLabel attendanceTitle = CreateSectionTitle("تفاصيل الحضور", 10, Color.FromArgb(52, 152, 219));
            detail.Controls.Add(attendanceTitle);

            int detailY = 55;
            AddDetailLabelPair(detail, "عدد أيام العمل:", "[WorkedDays] يوم", detailY);
            AddDetailLabelPair(detail, "ساعات العمل:", "[TotalWorkedHours] ساعة", detailY + 35);
            AddDetailLabelPair(detail, "الساعات الإضافية:", "[OvertimeHours] ساعة", detailY + 70);

            // قسم المرتب
            XRLabel salaryTitle = CreateSectionTitle("تفاصيل المرتب", 175, Color.FromArgb(46, 204, 113));
            detail.Controls.Add(salaryTitle);

            detailY = 220;
            AddDetailLabelPair(detail, "المرتب الأساسي:", "[BaseSalary] جنيه", detailY);
            AddDetailLabelPair(detail, "مبلغ الإضافي:", "[OvertimeAmount] جنيه", detailY + 35);
            AddDetailLabelPair(detail, "السلف المخصومة:", "[AdvancesAmount] جنيه", detailY + 70);

            this.Bands.Add(detail);

            // ============================================
            // تذييل التقرير - المرتب النهائي
            // ============================================
            ReportFooterBand footer = new ReportFooterBand();
            footer.HeightF = 230;
            footer.Borders = DevExpress.XtraPrinting.BorderSide.All;
            footer.BorderWidth = 2;
            footer.BorderColor = Color.FromArgb(52, 73, 94);

            // المرتب النهائي
            XRPanel finalPanel = new XRPanel();
            finalPanel.LocationFloat = new DevExpress.Utils.PointFloat(160, 15);
            finalPanel.SizeF = new System.Drawing.SizeF(407, 60);
            finalPanel.BackColor = Color.FromArgb(231, 76, 60);
            finalPanel.Borders = DevExpress.XtraPrinting.BorderSide.All;
            finalPanel.BorderWidth = 3;
            finalPanel.BorderColor = Color.FromArgb(192, 57, 43);

            // المبلغ على اليمين
            XRLabel finalValue = new XRLabel();
            finalValue.LocationFloat = new DevExpress.Utils.PointFloat(180, 15);
            finalValue.SizeF = new System.Drawing.SizeF(210, 30);
            finalValue.Text = "[FinalSalary] جنيه";
            finalValue.Font = new Font("Cairo", 12, FontStyle.Bold);
            finalValue.ForeColor = Color.White;
            finalValue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            finalPanel.Controls.Add(finalValue);

            // النص على الشمال
            XRLabel finalLabel = new XRLabel();
            finalLabel.LocationFloat = new DevExpress.Utils.PointFloat(20, 15);
            finalLabel.SizeF = new System.Drawing.SizeF(150, 30);
            finalLabel.Text = "المرتب النهائي:";
            finalLabel.Font = new Font("Cairo", 12, FontStyle.Bold);
            finalLabel.ForeColor = Color.White;
            finalLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            finalPanel.Controls.Add(finalLabel);

            footer.Controls.Add(finalPanel);

            // التوقيعات
            XRLabel sigTitle = new XRLabel();
            sigTitle.LocationFloat = new DevExpress.Utils.PointFloat(10, 90);
            sigTitle.SizeF = new System.Drawing.SizeF(707, 30);
            sigTitle.Text = "التوقيعات";
            sigTitle.Font = new Font("Cairo", 11, FontStyle.Bold);
            sigTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            sigTitle.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            sigTitle.BorderWidth = 2;
            sigTitle.BackColor = Color.FromArgb(236, 240, 241);
            footer.Controls.Add(sigTitle);

            // امضاء الموظف (على اليمين)
            XRLabel empSig = new XRLabel();
            empSig.LocationFloat = new DevExpress.Utils.PointFloat(377, 135);
            empSig.SizeF = new System.Drawing.SizeF(340, 70);
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
            managerSig.LocationFloat = new DevExpress.Utils.PointFloat(10, 135);
            managerSig.SizeF = new System.Drawing.SizeF(360, 70);
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

        private XRLabel CreateSectionTitle(string text, float yPos, Color backColor)
        {
            XRLabel label = new XRLabel();
            label.LocationFloat = new DevExpress.Utils.PointFloat(10, yPos);
            label.SizeF = new System.Drawing.SizeF(707, 35);
            label.Text = text;
            label.Font = new Font("Cairo", 11, FontStyle.Bold);
            label.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            label.BackColor = backColor;
            label.ForeColor = Color.White;
            label.Borders = DevExpress.XtraPrinting.BorderSide.All;
            label.BorderWidth = 2;
            label.BorderColor = Color.FromArgb(52, 73, 94);
            return label;
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

        private void AddDetailLabelPair(Band band, string labelText, string valueText, float yPos)
        {
            // Label على الشمال
            XRLabel label = new XRLabel();
            label.LocationFloat = new DevExpress.Utils.PointFloat(17, yPos);
            label.SizeF = new System.Drawing.SizeF(190, 30);
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
            value.LocationFloat = new DevExpress.Utils.PointFloat(217, yPos);
            value.SizeF = new System.Drawing.SizeF(493, 30);
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
            // rpt_Salary_Report
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