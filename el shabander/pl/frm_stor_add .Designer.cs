
namespace el_shabander.pl
{
    partial class frm_stor_add
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_stor_add));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.edt_spen = new System.Windows.Forms.TextBox();
            this.edt_dat = new System.Windows.Forms.TextBox();
            this.edt_type = new System.Windows.Forms.ComboBox();
            this.edt_many = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.edt_safe = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.edt_countsafe = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_add = new DevExpress.XtraEditors.SimpleButton();
            this.edt_date = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(435, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 45);
            this.label1.TabIndex = 7;
            this.label1.Text = "نوع المصروفات";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Cairo", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(145, -1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(386, 90);
            this.label3.TabIndex = 7;
            this.label3.Text = "اضافة مصروفات";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(435, 341);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 45);
            this.label4.TabIndex = 7;
            this.label4.Text = "المبلغ المستلم";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(483, 406);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 45);
            this.label7.TabIndex = 7;
            this.label7.Text = "التاريخ";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(469, 490);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 45);
            this.label8.TabIndex = 7;
            this.label8.Text = "ملاحظات";
            // 
            // edt_spen
            // 
            this.edt_spen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_spen.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_spen.Location = new System.Drawing.Point(42, 358);
            this.edt_spen.Name = "edt_spen";
            this.edt_spen.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_spen.Size = new System.Drawing.Size(321, 31);
            this.edt_spen.TabIndex = 11;
            this.edt_spen.Text = "0";
            this.edt_spen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.edt_spen.TextChanged += new System.EventHandler(this.edt_salery_TextChanged);
            // 
            // edt_dat
            // 
            this.edt_dat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_dat.Location = new System.Drawing.Point(42, 470);
            this.edt_dat.Multiline = true;
            this.edt_dat.Name = "edt_dat";
            this.edt_dat.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.edt_dat.Size = new System.Drawing.Size(321, 90);
            this.edt_dat.TabIndex = 15;
            this.edt_dat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edt_type
            // 
            this.edt_type.BackColor = System.Drawing.SystemColors.HotTrack;
            this.edt_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.edt_type.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_type.FormattingEnabled = true;
            this.edt_type.Items.AddRange(new object[] {
            "قهوة / شاي",
            "مناديل",
            "أكياس قمامة",
            "تنظيف",
            "إيجار",
            "كهرباء",
            "مياه",
            "إنترنت",
            "صيانة",
            "رسوم حكومية",
            "أخرى"});
            this.edt_type.Location = new System.Drawing.Point(42, 123);
            this.edt_type.Name = "edt_type";
            this.edt_type.Size = new System.Drawing.Size(321, 44);
            this.edt_type.TabIndex = 16;
            // 
            // edt_many
            // 
            this.edt_many.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.edt_many.AutoSize = true;
            this.edt_many.BackColor = System.Drawing.Color.Transparent;
            this.edt_many.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_many.ForeColor = System.Drawing.Color.Red;
            this.edt_many.Location = new System.Drawing.Point(119, 300);
            this.edt_many.Name = "edt_many";
            this.edt_many.Size = new System.Drawing.Size(207, 36);
            this.edt_many.TabIndex = 17;
            this.edt_many.Text = "لا توجد نقود فى الخزنة";
            this.edt_many.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(469, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 45);
            this.label2.TabIndex = 7;
            this.label2.Text = "الخزنة";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // edt_safe
            // 
            this.edt_safe.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.edt_safe.BackColor = System.Drawing.Color.LightPink;
            this.edt_safe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.edt_safe.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_safe.FormattingEnabled = true;
            this.edt_safe.Items.AddRange(new object[] {
            "سولار",
            "نثريات",
            "اخرى",
            "مرتبات",
            "نولون سيرات"});
            this.edt_safe.Location = new System.Drawing.Point(42, 181);
            this.edt_safe.Name = "edt_safe";
            this.edt_safe.Size = new System.Drawing.Size(321, 44);
            this.edt_safe.TabIndex = 16;
            this.edt_safe.SelectedIndexChanged += new System.EventHandler(this.edt_safe_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(378, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(295, 45);
            this.label5.TabIndex = 7;
            this.label5.Text = "المبلغ الموجود فى الخزنة";
            // 
            // edt_countsafe
            // 
            this.edt_countsafe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.edt_countsafe.BackColor = System.Drawing.Color.Lime;
            this.edt_countsafe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edt_countsafe.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_countsafe.ForeColor = System.Drawing.Color.OrangeRed;
            this.edt_countsafe.Location = new System.Drawing.Point(42, 241);
            this.edt_countsafe.Name = "edt_countsafe";
            this.edt_countsafe.Size = new System.Drawing.Size(321, 37);
            this.edt_countsafe.TabIndex = 17;
            this.edt_countsafe.Text = "0";
            this.edt_countsafe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 4000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btn_add
            // 
            this.btn_add.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_add.Appearance.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Appearance.Options.UseFont = true;
            this.btn_add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_add.ImageOptions.Image")));
            this.btn_add.Location = new System.Drawing.Point(76, 576);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(499, 56);
            this.btn_add.TabIndex = 10;
            this.btn_add.Text = "اضافة مصروفات";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // edt_date
            // 
            this.edt_date.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.edt_date.CalendarFont = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_date.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_date.Location = new System.Drawing.Point(42, 411);
            this.edt_date.Name = "edt_date";
            this.edt_date.Size = new System.Drawing.Size(321, 37);
            this.edt_date.TabIndex = 136;
            // 
            // frm_stor_add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(673, 644);
            this.Controls.Add(this.edt_date);
            this.Controls.Add(this.edt_countsafe);
            this.Controls.Add(this.edt_many);
            this.Controls.Add(this.edt_safe);
            this.Controls.Add(this.edt_type);
            this.Controls.Add(this.edt_dat);
            this.Controls.Add(this.edt_spen);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_stor_add";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.frm_stor_add_Activated);
            this.Load += new System.EventHandler(this.frm_stor_add_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public DevExpress.XtraEditors.SimpleButton btn_add;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox edt_spen;
        public System.Windows.Forms.TextBox edt_dat;
        private System.Windows.Forms.Label edt_many;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label edt_countsafe;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.ComboBox edt_type;
        public System.Windows.Forms.ComboBox edt_safe;
        public System.Windows.Forms.DateTimePicker edt_date;
    }
}