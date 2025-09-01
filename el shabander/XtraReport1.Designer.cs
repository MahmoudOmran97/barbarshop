
namespace el_shabander
{
    partial class XtraReport1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.company = new DevExpress.XtraReports.UI.XRLabel();
            this.barcodeImage = new DevExpress.XtraReports.UI.XRPictureBox();
            this.productName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.price = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.company,
            this.barcodeImage,
            this.productName,
            this.xrLabel2,
            this.price});
            this.Detail.HeightF = 87.71928F;
            this.Detail.Name = "Detail";
            // 
            // company
            // 
            this.company.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.company.Font = new System.Drawing.Font("Cairo", 6F, System.Drawing.FontStyle.Bold);
            this.company.LocationFloat = new DevExpress.Utils.PointFloat(10F, 0F);
            this.company.Multiline = true;
            this.company.Name = "company";
            this.company.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.company.SizeF = new System.Drawing.SizeF(168F, 16.75F);
            this.company.StylePriority.UseBorders = false;
            this.company.StylePriority.UseFont = false;
            this.company.StylePriority.UseTextAlignment = false;
            this.company.Text = "السعر";
            this.company.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // barcodeImage
            // 
            this.barcodeImage.LocationFloat = new DevExpress.Utils.PointFloat(4.000003F, 16.75F);
            this.barcodeImage.Name = "barcodeImage";
            this.barcodeImage.SizeF = new System.Drawing.SizeF(180F, 35.24998F);
            // 
            // productName
            // 
            this.productName.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.productName.Font = new System.Drawing.Font("Cairo", 5F, System.Drawing.FontStyle.Bold);
            this.productName.LocationFloat = new DevExpress.Utils.PointFloat(35.41667F, 51.99998F);
            this.productName.Multiline = true;
            this.productName.Name = "productName";
            this.productName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.productName.SizeF = new System.Drawing.SizeF(122.9167F, 16.75F);
            this.productName.StylePriority.UseBorders = false;
            this.productName.StylePriority.UseFont = false;
            this.productName.StylePriority.UseTextAlignment = false;
            this.productName.Text = "productName";
            this.productName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel2.Font = new System.Drawing.Font("Cairo", 5F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(98.95834F, 68.74998F);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(59.37499F, 16.75F);
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "السعر";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // price
            // 
            this.price.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.price.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price.LocationFloat = new DevExpress.Utils.PointFloat(35.41667F, 68.74998F);
            this.price.Multiline = true;
            this.price.Name = "price";
            this.price.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.price.SizeF = new System.Drawing.SizeF(63.54167F, 16.75F);
            this.price.StylePriority.UseBorders = false;
            this.price.StylePriority.UseFont = false;
            this.price.StylePriority.UseTextAlignment = false;
            this.price.Text = "xrLabel1";
            this.price.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // XtraReport1
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail});
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            this.PageHeight = 100;
            this.PageWidth = 188;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Version = "19.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        public DevExpress.XtraReports.UI.XRLabel company;
        public DevExpress.XtraReports.UI.XRPictureBox barcodeImage;
        public DevExpress.XtraReports.UI.XRLabel productName;
        public DevExpress.XtraReports.UI.XRLabel xrLabel2;
        public DevExpress.XtraReports.UI.XRLabel price;
    }
}
