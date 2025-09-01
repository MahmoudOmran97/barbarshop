
namespace el_shabander.pl
{
    partial class frm_employee_absent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_employee_absent));
            this.txt_qt = new DevExpress.XtraEditors.SpinEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.edt_name = new System.Windows.Forms.ComboBox();
            this.edt_dat = new System.Windows.Forms.TextBox();
            this.edt_spen = new System.Windows.Forms.TextBox();
            this.btn_add = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_titelpage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txt_qt.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_qt
            // 
            this.txt_qt.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_qt.Location = new System.Drawing.Point(7, 278);
            this.txt_qt.Name = "txt_qt";
            this.txt_qt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txt_qt.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_qt.Properties.Appearance.Options.UseBackColor = true;
            this.txt_qt.Properties.Appearance.Options.UseFont = true;
            this.txt_qt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_qt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_qt.Size = new System.Drawing.Size(357, 30);
            this.txt_qt.TabIndex = 50;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Cairo", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(197, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 90);
            this.label4.TabIndex = 49;
            this.label4.Text = "الغياب";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Cairo", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(403, 381);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 60);
            this.label3.TabIndex = 48;
            this.label3.Text = "ملاحظة";
            // 
            // edt_name
            // 
            this.edt_name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.edt_name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.edt_name.BackColor = System.Drawing.Color.Gold;
            this.edt_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_name.FormattingEnabled = true;
            this.edt_name.Location = new System.Drawing.Point(7, 133);
            this.edt_name.Name = "edt_name";
            this.edt_name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_name.Size = new System.Drawing.Size(357, 32);
            this.edt_name.TabIndex = 47;
            this.edt_name.SelectedIndexChanged += new System.EventHandler(this.edt_name_SelectedIndexChanged);
            // 
            // edt_dat
            // 
            this.edt_dat.BackColor = System.Drawing.Color.Snow;
            this.edt_dat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_dat.Location = new System.Drawing.Point(7, 349);
            this.edt_dat.Multiline = true;
            this.edt_dat.Name = "edt_dat";
            this.edt_dat.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.edt_dat.Size = new System.Drawing.Size(357, 178);
            this.edt_dat.TabIndex = 46;
            this.edt_dat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edt_spen
            // 
            this.edt_spen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_spen.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.edt_spen.Enabled = false;
            this.edt_spen.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_spen.Location = new System.Drawing.Point(7, 206);
            this.edt_spen.Name = "edt_spen";
            this.edt_spen.ReadOnly = true;
            this.edt_spen.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_spen.Size = new System.Drawing.Size(357, 31);
            this.edt_spen.TabIndex = 45;
            this.edt_spen.Text = "0";
            this.edt_spen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_add
            // 
            this.btn_add.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_add.Appearance.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Appearance.Options.UseFont = true;
            this.btn_add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_add.ImageOptions.Image")));
            this.btn_add.Location = new System.Drawing.Point(102, 559);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(392, 56);
            this.btn_add.TabIndex = 44;
            this.btn_add.Text = "حفظ";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Cairo", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(389, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 60);
            this.label2.TabIndex = 41;
            this.label2.Text = "اضافة غياب";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cairo", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(364, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 60);
            this.label1.TabIndex = 42;
            this.label1.Text = "عدد ايام الغياب";
            // 
            // lb_titelpage
            // 
            this.lb_titelpage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lb_titelpage.AutoSize = true;
            this.lb_titelpage.BackColor = System.Drawing.Color.Transparent;
            this.lb_titelpage.Font = new System.Drawing.Font("Cairo", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_titelpage.ForeColor = System.Drawing.Color.Black;
            this.lb_titelpage.Location = new System.Drawing.Point(375, 113);
            this.lb_titelpage.Name = "lb_titelpage";
            this.lb_titelpage.Size = new System.Drawing.Size(216, 60);
            this.lb_titelpage.TabIndex = 43;
            this.lb_titelpage.Text = "اسم الموظف";
            // 
            // frm_employee_absent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(616, 627);
            this.Controls.Add(this.txt_qt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.edt_name);
            this.Controls.Add(this.edt_dat);
            this.Controls.Add(this.edt_spen);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_titelpage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_employee_absent";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.frm_stor_add_Activated);
            this.Load += new System.EventHandler(this.frm_stor_add_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_qt.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.SpinEdit txt_qt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox edt_name;
        public System.Windows.Forms.TextBox edt_dat;
        public System.Windows.Forms.TextBox edt_spen;
        public DevExpress.XtraEditors.SimpleButton btn_add;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_titelpage;
    }
}