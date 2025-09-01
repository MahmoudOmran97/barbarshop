
namespace el_shabander.pl
{
    partial class frm_supp_add 
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_supp_add));
            this.lb_titelpage = new System.Windows.Forms.Label();
            this.edt_name = new System.Windows.Forms.TextBox();
            this.pic_cover = new DevExpress.XtraEditors.PictureEdit();
            this.btn_add = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.edt_phone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.edt_email = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.edt_sales = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.edt_max = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddImage = new DevExpress.XtraEditors.SimpleButton();
            this.edt_name_old = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic_cover.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_titelpage
            // 
            this.lb_titelpage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lb_titelpage.AutoSize = true;
            this.lb_titelpage.BackColor = System.Drawing.Color.Transparent;
            this.lb_titelpage.Font = new System.Drawing.Font("Cairo", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_titelpage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_titelpage.Location = new System.Drawing.Point(427, 86);
            this.lb_titelpage.Name = "lb_titelpage";
            this.lb_titelpage.Size = new System.Drawing.Size(155, 50);
            this.lb_titelpage.TabIndex = 7;
            this.lb_titelpage.Text = "اسم المورد";
            // 
            // edt_name
            // 
            this.edt_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_name.BackColor = System.Drawing.Color.Lime;
            this.edt_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_name.Location = new System.Drawing.Point(79, 98);
            this.edt_name.Name = "edt_name";
            this.edt_name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_name.Size = new System.Drawing.Size(282, 31);
            this.edt_name.TabIndex = 8;
            this.edt_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pic_cover
            // 
            this.pic_cover.EditValue = ((object)(resources.GetObject("pic_cover.EditValue")));
            this.pic_cover.Location = new System.Drawing.Point(79, 263);
            this.pic_cover.Name = "pic_cover";
            this.pic_cover.Properties.InitialImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("pic_cover.Properties.InitialImageOptions.Image")));
            this.pic_cover.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pic_cover.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pic_cover.Size = new System.Drawing.Size(282, 238);
            this.pic_cover.TabIndex = 9;
            // 
            // btn_add
            // 
            this.btn_add.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_add.Appearance.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Appearance.Options.UseFont = true;
            this.btn_add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_add.ImageOptions.Image")));
            this.btn_add.Location = new System.Drawing.Point(52, 622);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(538, 56);
            this.btn_add.TabIndex = 10;
            this.btn_add.Text = "اضافة ";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cairo", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(425, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 50);
            this.label1.TabIndex = 7;
            this.label1.Text = "رقم الهاتف";
            // 
            // edt_phone
            // 
            this.edt_phone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_phone.Location = new System.Drawing.Point(79, 153);
            this.edt_phone.Name = "edt_phone";
            this.edt_phone.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_phone.Size = new System.Drawing.Size(282, 31);
            this.edt_phone.TabIndex = 8;
            this.edt_phone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Cairo", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(448, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 50);
            this.label2.TabIndex = 7;
            this.label2.Text = "العنوان";
            // 
            // edt_email
            // 
            this.edt_email.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_email.Location = new System.Drawing.Point(79, 208);
            this.edt_email.Name = "edt_email";
            this.edt_email.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_email.Size = new System.Drawing.Size(282, 31);
            this.edt_email.TabIndex = 8;
            this.edt_email.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Cairo", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(175, -8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(284, 90);
            this.label3.TabIndex = 7;
            this.label3.Text = "اضافة مورد";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // edt_sales
            // 
            this.edt_sales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_sales.BackColor = System.Drawing.SystemColors.Info;
            this.edt_sales.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_sales.Location = new System.Drawing.Point(79, 580);
            this.edt_sales.Name = "edt_sales";
            this.edt_sales.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_sales.Size = new System.Drawing.Size(282, 31);
            this.edt_sales.TabIndex = 12;
            this.edt_sales.Text = "0";
            this.edt_sales.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.edt_sales.TextChanged += new System.EventHandler(this.edt_sales_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Cairo", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(375, 568);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(229, 50);
            this.label4.TabIndex = 11;
            this.label4.Text = "الحساب الباقى لة";
            // 
            // edt_max
            // 
            this.edt_max.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_max.BackColor = System.Drawing.Color.OrangeRed;
            this.edt_max.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_max.Location = new System.Drawing.Point(79, 525);
            this.edt_max.Name = "edt_max";
            this.edt_max.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_max.Size = new System.Drawing.Size(282, 31);
            this.edt_max.TabIndex = 14;
            this.edt_max.Text = "0";
            this.edt_max.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.edt_max.TextChanged += new System.EventHandler(this.edt_max_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Cairo", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(363, 510);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(253, 50);
            this.label5.TabIndex = 13;
            this.label5.Text = "الحد الاقصى للمورد";
            // 
            // btnAddImage
            // 
            this.btnAddImage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAddImage.Appearance.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddImage.Appearance.Options.UseFont = true;
            this.btnAddImage.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddImage.ImageOptions.Image")));
            this.btnAddImage.Location = new System.Drawing.Point(416, 345);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(166, 45);
            this.btnAddImage.TabIndex = 27;
            this.btnAddImage.Text = "اضافة صورة";
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // edt_name_old
            // 
            this.edt_name_old.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.edt_name_old.AutoSize = true;
            this.edt_name_old.BackColor = System.Drawing.Color.Transparent;
            this.edt_name_old.Font = new System.Drawing.Font("Cairo", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_name_old.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.edt_name_old.Location = new System.Drawing.Point(48, 24);
            this.edt_name_old.Name = "edt_name_old";
            this.edt_name_old.Size = new System.Drawing.Size(93, 20);
            this.edt_name_old.TabIndex = 28;
            this.edt_name_old.Text = "الحساب الباقى لة";
            this.edt_name_old.Visible = false;
            // 
            // frm_supp_add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(639, 685);
            this.Controls.Add(this.edt_name_old);
            this.Controls.Add(this.btnAddImage);
            this.Controls.Add(this.edt_max);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.edt_sales);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.pic_cover);
            this.Controls.Add(this.edt_email);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.edt_phone);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edt_name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_titelpage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_supp_add";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pic_cover.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lb_titelpage;
        public DevExpress.XtraEditors.SimpleButton btn_add;
        public System.Windows.Forms.TextBox edt_name;
        public DevExpress.XtraEditors.PictureEdit pic_cover;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox edt_phone;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox edt_email;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox edt_sales;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox edt_max;
        private System.Windows.Forms.Label label5;
        public DevExpress.XtraEditors.SimpleButton btnAddImage;
        public System.Windows.Forms.Label edt_name_old;
    }
}