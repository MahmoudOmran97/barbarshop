
namespace el_shabander.pl
{
    partial class frm_employees_add
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_employees_add));
            this.workingdays = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.edt_overtime_rate = new System.Windows.Forms.TextBox();
            this.edt_freeday = new System.Windows.Forms.ComboBox();
            this.edt_work_hours = new DevExpress.XtraEditors.SpinEdit();
            this.edt_typeemp = new System.Windows.Forms.ComboBox();
            this.edt_salery = new System.Windows.Forms.TextBox();
            this.btn_add = new DevExpress.XtraEditors.SimpleButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.edt_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_titelpage = new System.Windows.Forms.Label();
            this.btn_select_image = new DevExpress.XtraEditors.SimpleButton();
            this.pic_employee = new DevExpress.XtraEditors.PictureEdit();
            this.edt_password = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.workingdays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_work_hours.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_employee.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // workingdays
            // 
            this.workingdays.BackColor = System.Drawing.Color.Gray;
            this.workingdays.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.workingdays.ForeColor = System.Drawing.Color.LightYellow;
            this.workingdays.Location = new System.Drawing.Point(380, 404);
            this.workingdays.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.workingdays.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.workingdays.Name = "workingdays";
            this.workingdays.Size = new System.Drawing.Size(367, 43);
            this.workingdays.TabIndex = 92;
            this.workingdays.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(753, 406);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(324, 41);
            this.label7.TabIndex = 91;
            this.label7.Text = "عدد ايام العمل";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // edt_overtime_rate
            // 
            this.edt_overtime_rate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_overtime_rate.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_overtime_rate.Location = new System.Drawing.Point(380, 355);
            this.edt_overtime_rate.Name = "edt_overtime_rate";
            this.edt_overtime_rate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_overtime_rate.Size = new System.Drawing.Size(367, 37);
            this.edt_overtime_rate.TabIndex = 90;
            this.edt_overtime_rate.Text = "0";
            this.edt_overtime_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // edt_freeday
            // 
            this.edt_freeday.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.edt_freeday.BackColor = System.Drawing.Color.Lime;
            this.edt_freeday.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.edt_freeday.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_freeday.FormattingEnabled = true;
            this.edt_freeday.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.edt_freeday.Items.AddRange(new object[] {
            "شهري",
            "بالساعة"});
            this.edt_freeday.Location = new System.Drawing.Point(380, 208);
            this.edt_freeday.Name = "edt_freeday";
            this.edt_freeday.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.edt_freeday.Size = new System.Drawing.Size(367, 38);
            this.edt_freeday.TabIndex = 89;
            // 
            // edt_work_hours
            // 
            this.edt_work_hours.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edt_work_hours.Location = new System.Drawing.Point(380, 307);
            this.edt_work_hours.Name = "edt_work_hours";
            this.edt_work_hours.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_work_hours.Properties.Appearance.Options.UseFont = true;
            this.edt_work_hours.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edt_work_hours.Size = new System.Drawing.Size(367, 36);
            this.edt_work_hours.TabIndex = 87;
            // 
            // edt_typeemp
            // 
            this.edt_typeemp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.edt_typeemp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.edt_typeemp.BackColor = System.Drawing.Color.Orange;
            this.edt_typeemp.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_typeemp.FormattingEnabled = true;
            this.edt_typeemp.Items.AddRange(new object[] {
            "مدير عام",
            "مدير حسابات",
            "مدير مالي",
            "مدير عمليات",
            "محاسب",
            "حلاق",
            "محاسب رئيسي",
            "مساعد محاسب",
            "محصل",
            "مدرب",
            "عامل",
            "مشرف",
            "فني صيانة",
            "سائق",
            "موظف خدمة عملاء",
            "موظف تسويق",
            "موظف استقبال",
            "موظف نظافة",
            "حارس أمن"});
            this.edt_typeemp.Location = new System.Drawing.Point(380, 158);
            this.edt_typeemp.Name = "edt_typeemp";
            this.edt_typeemp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_typeemp.Size = new System.Drawing.Size(367, 38);
            this.edt_typeemp.TabIndex = 88;
            // 
            // edt_salery
            // 
            this.edt_salery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_salery.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_salery.Location = new System.Drawing.Point(380, 258);
            this.edt_salery.Name = "edt_salery";
            this.edt_salery.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_salery.Size = new System.Drawing.Size(367, 37);
            this.edt_salery.TabIndex = 86;
            this.edt_salery.Text = "0";
            this.edt_salery.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.edt_salery.TextChanged += new System.EventHandler(this.edt_salery_TextChanged);
            // 
            // btn_add
            // 
            this.btn_add.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_add.Appearance.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Appearance.Options.UseFont = true;
            this.btn_add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_add.ImageOptions.Image")));
            this.btn_add.Location = new System.Drawing.Point(279, 543);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(509, 56);
            this.btn_add.TabIndex = 85;
            this.btn_add.Text = "اضافة موظف";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(753, 356);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(324, 41);
            this.label6.TabIndex = 77;
            this.label6.Text = "سعر الساعة الإضافية (أوفر تايم)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(753, 306);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(324, 41);
            this.label5.TabIndex = 78;
            this.label5.Text = "عدد ساعات العمل )خلال الشهر)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(753, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(324, 41);
            this.label4.TabIndex = 79;
            this.label4.Text = "المرتب الشهرى او سعر الساعة";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(753, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(324, 41);
            this.label2.TabIndex = 80;
            this.label2.Text = "نوع الوظيفة";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(753, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 41);
            this.label1.TabIndex = 81;
            this.label1.Text = "الوظيفة / المسمى الوظيفي";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // edt_name
            // 
            this.edt_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_name.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.edt_name.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_name.Location = new System.Drawing.Point(380, 109);
            this.edt_name.Name = "edt_name";
            this.edt_name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_name.Size = new System.Drawing.Size(367, 37);
            this.edt_name.TabIndex = 84;
            this.edt_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.edt_name.TextChanged += new System.EventHandler(this.edt_name_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Cairo", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(336, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(332, 90);
            this.label3.TabIndex = 82;
            this.label3.Text = "اضافة موظف";
            // 
            // lb_titelpage
            // 
            this.lb_titelpage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lb_titelpage.BackColor = System.Drawing.Color.LightSeaGreen;
            this.lb_titelpage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_titelpage.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_titelpage.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lb_titelpage.Location = new System.Drawing.Point(753, 106);
            this.lb_titelpage.Name = "lb_titelpage";
            this.lb_titelpage.Size = new System.Drawing.Size(324, 41);
            this.lb_titelpage.TabIndex = 83;
            this.lb_titelpage.Text = "اسم الموظف كامل";
            this.lb_titelpage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_select_image
            // 
            this.btn_select_image.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_select_image.Appearance.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_select_image.Appearance.Options.UseFont = true;
            this.btn_select_image.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_select_image.ImageOptions.Image")));
            this.btn_select_image.Location = new System.Drawing.Point(82, 473);
            this.btn_select_image.Name = "btn_select_image";
            this.btn_select_image.Size = new System.Drawing.Size(166, 45);
            this.btn_select_image.TabIndex = 94;
            this.btn_select_image.Text = "اضافة صورة";
            this.btn_select_image.Click += new System.EventHandler(this.btn_select_image_Click);
            // 
            // pic_employee
            // 
            this.pic_employee.EditValue = ((object)(resources.GetObject("pic_employee.EditValue")));
            this.pic_employee.Location = new System.Drawing.Point(12, 108);
            this.pic_employee.Name = "pic_employee";
            this.pic_employee.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.pic_employee.Properties.InitialImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("pic_employee.Properties.InitialImageOptions.Image")));
            this.pic_employee.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pic_employee.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pic_employee.Size = new System.Drawing.Size(332, 359);
            this.pic_employee.TabIndex = 93;
            // 
            // edt_password
            // 
            this.edt_password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_password.BackColor = System.Drawing.Color.DarkOrange;
            this.edt_password.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_password.ForeColor = System.Drawing.SystemColors.Window;
            this.edt_password.Location = new System.Drawing.Point(380, 459);
            this.edt_password.Name = "edt_password";
            this.edt_password.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_password.Size = new System.Drawing.Size(367, 37);
            this.edt_password.TabIndex = 95;
            this.edt_password.Text = "0";
            this.edt_password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(753, 456);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(324, 41);
            this.label8.TabIndex = 96;
            this.label8.Text = "رمز مرور الموظف";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frm_employees_add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(1095, 615);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.edt_password);
            this.Controls.Add(this.btn_select_image);
            this.Controls.Add(this.pic_employee);
            this.Controls.Add(this.workingdays);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.edt_overtime_rate);
            this.Controls.Add(this.edt_freeday);
            this.Controls.Add(this.edt_work_hours);
            this.Controls.Add(this.edt_typeemp);
            this.Controls.Add(this.edt_salery);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edt_name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_titelpage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_employees_add";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frm_employees_add_Load);
            ((System.ComponentModel.ISupportInitialize)(this.workingdays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_work_hours.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_employee.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown workingdays;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox edt_overtime_rate;
        public System.Windows.Forms.ComboBox edt_freeday;
        public DevExpress.XtraEditors.SpinEdit edt_work_hours;
        public System.Windows.Forms.ComboBox edt_typeemp;
        public System.Windows.Forms.TextBox edt_salery;
        public DevExpress.XtraEditors.SimpleButton btn_add;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox edt_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_titelpage;
        public DevExpress.XtraEditors.SimpleButton btn_select_image;
        public DevExpress.XtraEditors.PictureEdit pic_employee;
        public System.Windows.Forms.TextBox edt_password;
        private System.Windows.Forms.Label label8;
    }
}