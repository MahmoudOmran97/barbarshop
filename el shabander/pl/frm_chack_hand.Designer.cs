
namespace el_shabander.pl
{
    partial class frm_chack_hand
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_chack_hand));
            this.btn_add = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.edt_add = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cashbox = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.edt_nameto = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.stay = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.edt_namefrom = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_add
            // 
            this.btn_add.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_add.Appearance.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Appearance.Options.UseFont = true;
            this.btn_add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_add.ImageOptions.Image")));
            this.btn_add.Location = new System.Drawing.Point(38, 506);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(504, 56);
            this.btn_add.TabIndex = 10;
            this.btn_add.Text = "تسليم النقدية";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Cairo", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(149, -1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(297, 90);
            this.label3.TabIndex = 7;
            this.label3.Text = "تسليم وردية";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(375, 293);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 45);
            this.label4.TabIndex = 7;
            this.label4.Text = "المبلغ المستلم";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // edt_add
            // 
            this.edt_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_add.Location = new System.Drawing.Point(24, 299);
            this.edt_add.Name = "edt_add";
            this.edt_add.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_add.Size = new System.Drawing.Size(282, 31);
            this.edt_add.TabIndex = 11;
            this.edt_add.Text = "0";
            this.edt_add.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.edt_add.TextChanged += new System.EventHandler(this.edt_salery_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(359, 429);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 45);
            this.label2.TabIndex = 7;
            this.label2.Text = "مبلغ الكاش بوكس";
            // 
            // cashbox
            // 
            this.cashbox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cashbox.BackColor = System.Drawing.Color.Silver;
            this.cashbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cashbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashbox.ForeColor = System.Drawing.Color.Green;
            this.cashbox.Location = new System.Drawing.Point(24, 435);
            this.cashbox.Name = "cashbox";
            this.cashbox.Size = new System.Drawing.Size(282, 37);
            this.cashbox.TabIndex = 7;
            this.cashbox.Text = "0";
            this.cashbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(391, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 45);
            this.label5.TabIndex = 13;
            this.label5.Text = "اسم الكاشير";
            // 
            // edt_nameto
            // 
            this.edt_nameto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.edt_nameto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.edt_nameto.BackColor = System.Drawing.Color.LimeGreen;
            this.edt_nameto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_nameto.FormattingEnabled = true;
            this.edt_nameto.Location = new System.Drawing.Point(24, 168);
            this.edt_nameto.Name = "edt_nameto";
            this.edt_nameto.Size = new System.Drawing.Size(282, 32);
            this.edt_nameto.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(343, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(246, 45);
            this.label6.TabIndex = 15;
            this.label6.Text = "اسم الكاشير المستلم";
            // 
            // date
            // 
            this.date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.date.Enabled = false;
            this.date.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date.Location = new System.Drawing.Point(24, 234);
            this.date.Name = "date";
            this.date.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.date.Size = new System.Drawing.Size(282, 31);
            this.date.TabIndex = 18;
            this.date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(425, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 45);
            this.label7.TabIndex = 17;
            this.label7.Text = "التاريخ";
            // 
            // stay
            // 
            this.stay.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.stay.BackColor = System.Drawing.Color.Silver;
            this.stay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.stay.Location = new System.Drawing.Point(24, 364);
            this.stay.Name = "stay";
            this.stay.Size = new System.Drawing.Size(282, 37);
            this.stay.TabIndex = 19;
            this.stay.Text = "0";
            this.stay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(374, 361);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(184, 45);
            this.label9.TabIndex = 20;
            this.label9.Text = "المبلغ المتبقى";
            // 
            // edt_namefrom
            // 
            this.edt_namefrom.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.edt_namefrom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.edt_namefrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edt_namefrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_namefrom.ForeColor = System.Drawing.Color.White;
            this.edt_namefrom.Location = new System.Drawing.Point(24, 102);
            this.edt_namefrom.Name = "edt_namefrom";
            this.edt_namefrom.Size = new System.Drawing.Size(282, 32);
            this.edt_namefrom.TabIndex = 21;
            this.edt_namefrom.Text = "0";
            this.edt_namefrom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frm_chack_hand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(616, 574);
            this.Controls.Add(this.edt_namefrom);
            this.Controls.Add(this.stay);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.date);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.edt_nameto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.edt_add);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.cashbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_chack_hand";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.frm_stor_add_Activated);
            this.Load += new System.EventHandler(this.frm_chack_hand_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public DevExpress.XtraEditors.SimpleButton btn_add;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox edt_add;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label cashbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox date;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label stay;
        public System.Windows.Forms.ComboBox edt_nameto;
        public System.Windows.Forms.Label edt_namefrom;
    }
}