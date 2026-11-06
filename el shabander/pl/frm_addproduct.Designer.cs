
namespace el_shabander.pl
{
    partial class frm_addproduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_addproduct));
            this.lb_titelpage = new System.Windows.Forms.Label();
            this.edt_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.edt_sales = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.edt_max = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.edt_supp = new System.Windows.Forms.ComboBox();
            this.edt_cat = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btn_delete = new DevExpress.XtraEditors.SimpleButton();
            this.btn_edit = new DevExpress.XtraEditors.SimpleButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_addcat = new DevExpress.XtraEditors.SimpleButton();
            this.edt_code = new System.Windows.Forms.TextBox();
            this.printcode = new DevExpress.XtraEditors.SimpleButton();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.btn_createcode = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddImage = new DevExpress.XtraEditors.SimpleButton();
            this.btn_add = new DevExpress.XtraEditors.SimpleButton();
            this.pic_cover = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_cover.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_titelpage
            // 
            this.lb_titelpage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lb_titelpage.BackColor = System.Drawing.Color.White;
            this.lb_titelpage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_titelpage.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_titelpage.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lb_titelpage.Location = new System.Drawing.Point(807, 123);
            this.lb_titelpage.Name = "lb_titelpage";
            this.lb_titelpage.Size = new System.Drawing.Size(156, 38);
            this.lb_titelpage.TabIndex = 7;
            this.lb_titelpage.Text = "اسم الخدمة";
            this.lb_titelpage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // edt_name
            // 
            this.edt_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_name.Location = new System.Drawing.Point(475, 129);
            this.edt_name.Name = "edt_name";
            this.edt_name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_name.Size = new System.Drawing.Size(326, 31);
            this.edt_name.TabIndex = 8;
            this.edt_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(807, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 38);
            this.label1.TabIndex = 7;
            this.label1.Text = "القائمة";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // edt_sales
            // 
            this.edt_sales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_sales.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_sales.Location = new System.Drawing.Point(37, 40);
            this.edt_sales.Name = "edt_sales";
            this.edt_sales.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_sales.Size = new System.Drawing.Size(247, 31);
            this.edt_sales.TabIndex = 8;
            this.edt_sales.Text = "1";
            this.edt_sales.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.edt_sales.TextChanged += new System.EventHandler(this.edt_sales_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(274, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 39);
            this.label4.TabIndex = 7;
            this.label4.Text = "التكلفة من الصنف";
            // 
            // edt_max
            // 
            this.edt_max.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_max.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_max.Location = new System.Drawing.Point(75, 63);
            this.edt_max.Name = "edt_max";
            this.edt_max.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_max.Size = new System.Drawing.Size(236, 31);
            this.edt_max.TabIndex = 16;
            this.edt_max.Text = "0";
            this.edt_max.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.edt_max.TextChanged += new System.EventHandler(this.edt_max_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label5.Location = new System.Drawing.Point(314, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 38);
            this.label5.TabIndex = 15;
            this.label5.Text = "سعر البيع";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Cairo", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(392, -9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 69);
            this.label2.TabIndex = 17;
            this.label2.Text = "اضافة خدمة";
            // 
            // edt_supp
            // 
            this.edt_supp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.edt_supp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.edt_supp.BackColor = System.Drawing.Color.Gold;
            this.edt_supp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_supp.FormattingEnabled = true;
            this.edt_supp.Location = new System.Drawing.Point(476, 65);
            this.edt_supp.Name = "edt_supp";
            this.edt_supp.Size = new System.Drawing.Size(325, 33);
            this.edt_supp.TabIndex = 32;
            // 
            // edt_cat
            // 
            this.edt_cat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.edt_cat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.edt_cat.BackColor = System.Drawing.Color.Lime;
            this.edt_cat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_cat.FormattingEnabled = true;
            this.edt_cat.Location = new System.Drawing.Point(464, 40);
            this.edt_cat.Name = "edt_cat";
            this.edt_cat.Size = new System.Drawing.Size(247, 33);
            this.edt_cat.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label6.Location = new System.Drawing.Point(723, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 39);
            this.label6.TabIndex = 33;
            this.label6.Text = "الصنف";
            // 
            // groupControl2
            // 
            this.groupControl2.Appearance.BackColor = System.Drawing.Color.Orange;
            this.groupControl2.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupControl2.Appearance.BorderColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
            this.groupControl2.Appearance.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl2.Appearance.Options.UseBackColor = true;
            this.groupControl2.Appearance.Options.UseBorderColor = true;
            this.groupControl2.Appearance.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl2.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl2.Controls.Add(this.btn_delete);
            this.groupControl2.Controls.Add(this.btn_edit);
            this.groupControl2.Controls.Add(this.dataGridView1);
            this.groupControl2.Controls.Add(this.edt_cat);
            this.groupControl2.Controls.Add(this.btn_addcat);
            this.groupControl2.Controls.Add(this.label4);
            this.groupControl2.Controls.Add(this.edt_sales);
            this.groupControl2.Controls.Add(this.label6);
            this.groupControl2.Location = new System.Drawing.Point(75, 376);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(823, 277);
            this.groupControl2.TabIndex = 129;
            this.groupControl2.Text = "اختيار الاصناف لتصنيع الخدمة";
            // 
            // btn_delete
            // 
            this.btn_delete.Appearance.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.Appearance.Options.UseFont = true;
            this.btn_delete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_delete.ImageOptions.Image")));
            this.btn_delete.Location = new System.Drawing.Point(52, 89);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(218, 46);
            this.btn_delete.TabIndex = 46;
            this.btn_delete.Text = "حذف";
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Appearance.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.Appearance.Options.UseFont = true;
            this.btn_edit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_edit.ImageOptions.Image")));
            this.btn_edit.Location = new System.Drawing.Point(290, 89);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(218, 46);
            this.btn_edit.TabIndex = 45;
            this.btn_edit.Text = "تعديل";
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(52, 140);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.Size = new System.Drawing.Size(694, 123);
            this.dataGridView1.TabIndex = 39;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btn_addcat
            // 
            this.btn_addcat.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_addcat.Appearance.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addcat.Appearance.Options.UseFont = true;
            this.btn_addcat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_addcat.ImageOptions.Image")));
            this.btn_addcat.Location = new System.Drawing.Point(528, 89);
            this.btn_addcat.Name = "btn_addcat";
            this.btn_addcat.Size = new System.Drawing.Size(218, 45);
            this.btn_addcat.TabIndex = 38;
            this.btn_addcat.Text = "اضافة الصنف";
            this.btn_addcat.Click += new System.EventHandler(this.btn_addcat_Click);
            // 
            // edt_code
            // 
            this.edt_code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_code.BackColor = System.Drawing.Color.DimGray;
            this.edt_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_code.ForeColor = System.Drawing.Color.Red;
            this.edt_code.Location = new System.Drawing.Point(476, 191);
            this.edt_code.Name = "edt_code";
            this.edt_code.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_code.Size = new System.Drawing.Size(325, 31);
            this.edt_code.TabIndex = 130;
            this.edt_code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.edt_code.TextChanged += new System.EventHandler(this.edt_code_TextChanged);
            // 
            // printcode
            // 
            this.printcode.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.printcode.Appearance.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printcode.Appearance.Options.UseFont = true;
            this.printcode.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("printcode.ImageOptions.Image")));
            this.printcode.Location = new System.Drawing.Point(807, 300);
            this.printcode.Name = "printcode";
            this.printcode.Size = new System.Drawing.Size(158, 45);
            this.printcode.TabIndex = 134;
            this.printcode.Text = "طباعة الكود";
            this.printcode.Click += new System.EventHandler(this.printcode_Click);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(476, 253);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.pictureEdit1.Properties.InitialImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("pictureEdit1.Properties.InitialImageOptions.Image")));
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.ShowMenu = false;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit1.Size = new System.Drawing.Size(325, 118);
            this.pictureEdit1.TabIndex = 133;
            // 
            // btn_createcode
            // 
            this.btn_createcode.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_createcode.Appearance.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_createcode.Appearance.Options.UseFont = true;
            this.btn_createcode.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_createcode.ImageOptions.Image")));
            this.btn_createcode.Location = new System.Drawing.Point(806, 186);
            this.btn_createcode.Name = "btn_createcode";
            this.btn_createcode.Size = new System.Drawing.Size(158, 45);
            this.btn_createcode.TabIndex = 131;
            this.btn_createcode.Text = "تفعيل كود";
            this.btn_createcode.Click += new System.EventHandler(this.btn_createcode_Click);
            // 
            // btnAddImage
            // 
            this.btnAddImage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAddImage.Appearance.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddImage.Appearance.Options.UseFont = true;
            this.btnAddImage.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddImage.ImageOptions.Image")));
            this.btnAddImage.Location = new System.Drawing.Point(314, 212);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(156, 45);
            this.btnAddImage.TabIndex = 37;
            this.btnAddImage.Text = "اضافة صورة";
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // btn_add
            // 
            this.btn_add.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_add.Appearance.Font = new System.Drawing.Font("Cairo", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Appearance.Options.UseFont = true;
            this.btn_add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_add.ImageOptions.Image")));
            this.btn_add.Location = new System.Drawing.Point(252, 659);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(454, 53);
            this.btn_add.TabIndex = 10;
            this.btn_add.Text = "اضافة ";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // pic_cover
            // 
            this.pic_cover.EditValue = ((object)(resources.GetObject("pic_cover.EditValue")));
            this.pic_cover.Location = new System.Drawing.Point(75, 123);
            this.pic_cover.Name = "pic_cover";
            this.pic_cover.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.pic_cover.Properties.InitialImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("pic_cover.Properties.InitialImageOptions.Image")));
            this.pic_cover.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pic_cover.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pic_cover.Size = new System.Drawing.Size(236, 232);
            this.pic_cover.TabIndex = 9;
            // 
            // frm_addproduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(971, 714);
            this.Controls.Add(this.printcode);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.btn_createcode);
            this.Controls.Add(this.edt_code);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.btnAddImage);
            this.Controls.Add(this.edt_supp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pic_cover);
            this.Controls.Add(this.edt_max);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edt_name);
            this.Controls.Add(this.lb_titelpage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_addproduct";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.frm_addproduct_Activated);
            this.Load += new System.EventHandler(this.frm_addproduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
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
        public System.Windows.Forms.TextBox edt_sales;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox edt_max;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox edt_supp;
        public System.Windows.Forms.ComboBox edt_cat;
        private System.Windows.Forms.Label label6;
        public DevExpress.XtraEditors.SimpleButton btnAddImage;
        public DevExpress.XtraEditors.SimpleButton btn_addcat;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.DataGridView dataGridView1;
        public DevExpress.XtraEditors.SimpleButton btn_delete;
        public DevExpress.XtraEditors.SimpleButton btn_edit;
        public DevExpress.XtraEditors.SimpleButton btn_createcode;
        public System.Windows.Forms.TextBox edt_code;
        public DevExpress.XtraEditors.PictureEdit pictureEdit1;
        public DevExpress.XtraEditors.SimpleButton printcode;
    }
}