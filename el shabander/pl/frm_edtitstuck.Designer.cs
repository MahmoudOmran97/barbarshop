
namespace el_shabander.pl
{
    partial class frm_edtitstuck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_edtitstuck));
            this.lb_titelpage = new System.Windows.Forms.Label();
            this.btn_add = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.edt_sell = new System.Windows.Forms.TextBox();
            this.edt_qt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.edt_buy = new System.Windows.Forms.TextBox();
            this.edt_name = new System.Windows.Forms.TextBox();
            this.edt_cat = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lb_titelpage
            // 
            this.lb_titelpage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lb_titelpage.AutoSize = true;
            this.lb_titelpage.BackColor = System.Drawing.Color.Transparent;
            this.lb_titelpage.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_titelpage.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lb_titelpage.Location = new System.Drawing.Point(499, 160);
            this.lb_titelpage.Name = "lb_titelpage";
            this.lb_titelpage.Size = new System.Drawing.Size(137, 37);
            this.lb_titelpage.TabIndex = 7;
            this.lb_titelpage.Text = "اسم المادة ";
            // 
            // btn_add
            // 
            this.btn_add.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_add.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Appearance.Options.UseFont = true;
            this.btn_add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_add.ImageOptions.Image")));
            this.btn_add.Location = new System.Drawing.Point(71, 576);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(499, 56);
            this.btn_add.TabIndex = 10;
            this.btn_add.Text = "حفظ التعديل";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(539, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 37);
            this.label1.TabIndex = 7;
            this.label1.Text = "الصنف";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.OrangeRed;
            this.label3.Location = new System.Drawing.Point(223, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(246, 55);
            this.label3.TabIndex = 7;
            this.label3.Text = "تعديل المخزن";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(510, 376);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 37);
            this.label4.TabIndex = 7;
            this.label4.Text = "سعر البيع";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label7.Location = new System.Drawing.Point(552, 452);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 37);
            this.label7.TabIndex = 7;
            this.label7.Text = "الكمية";
            // 
            // edt_sell
            // 
            this.edt_sell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_sell.BackColor = System.Drawing.Color.LimeGreen;
            this.edt_sell.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_sell.ForeColor = System.Drawing.Color.Red;
            this.edt_sell.Location = new System.Drawing.Point(74, 379);
            this.edt_sell.Name = "edt_sell";
            this.edt_sell.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_sell.Size = new System.Drawing.Size(282, 31);
            this.edt_sell.TabIndex = 11;
            this.edt_sell.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.edt_sell.TextChanged += new System.EventHandler(this.edt_salery_TextChanged);
            // 
            // edt_qt
            // 
            this.edt_qt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_qt.BackColor = System.Drawing.Color.LimeGreen;
            this.edt_qt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_qt.ForeColor = System.Drawing.Color.Red;
            this.edt_qt.Location = new System.Drawing.Point(74, 452);
            this.edt_qt.Name = "edt_qt";
            this.edt_qt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_qt.Size = new System.Drawing.Size(282, 31);
            this.edt_qt.TabIndex = 14;
            this.edt_qt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.edt_qt.TextChanged += new System.EventHandler(this.edt_qt_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(485, 304);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 37);
            this.label2.TabIndex = 7;
            this.label2.Text = "سعر الشراء";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // edt_buy
            // 
            this.edt_buy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_buy.BackColor = System.Drawing.Color.LimeGreen;
            this.edt_buy.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_buy.ForeColor = System.Drawing.Color.Red;
            this.edt_buy.Location = new System.Drawing.Point(74, 306);
            this.edt_buy.Name = "edt_buy";
            this.edt_buy.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_buy.Size = new System.Drawing.Size(282, 31);
            this.edt_buy.TabIndex = 15;
            this.edt_buy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.edt_buy.TextChanged += new System.EventHandler(this.edt_buy_TextChanged);
            // 
            // edt_name
            // 
            this.edt_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_name.BackColor = System.Drawing.Color.LimeGreen;
            this.edt_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_name.ForeColor = System.Drawing.Color.Red;
            this.edt_name.Location = new System.Drawing.Point(74, 160);
            this.edt_name.Name = "edt_name";
            this.edt_name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_name.Size = new System.Drawing.Size(282, 31);
            this.edt_name.TabIndex = 16;
            this.edt_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // edt_cat
            // 
            this.edt_cat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_cat.BackColor = System.Drawing.Color.LimeGreen;
            this.edt_cat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_cat.ForeColor = System.Drawing.Color.Red;
            this.edt_cat.Location = new System.Drawing.Point(74, 233);
            this.edt_cat.Name = "edt_cat";
            this.edt_cat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_cat.Size = new System.Drawing.Size(282, 31);
            this.edt_cat.TabIndex = 17;
            this.edt_cat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frm_edtitstuck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(662, 644);
            this.Controls.Add(this.edt_cat);
            this.Controls.Add(this.edt_name);
            this.Controls.Add(this.edt_buy);
            this.Controls.Add(this.edt_qt);
            this.Controls.Add(this.edt_sell);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_titelpage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_edtitstuck";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.frm_stor_add_Activated);
            this.Load += new System.EventHandler(this.frm_stor_add_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lb_titelpage;
        public DevExpress.XtraEditors.SimpleButton btn_add;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox edt_sell;
        public System.Windows.Forms.TextBox edt_qt;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox edt_buy;
        public System.Windows.Forms.TextBox edt_name;
        public System.Windows.Forms.TextBox edt_cat;
    }
}