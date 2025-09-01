
namespace el_shabander.pl
{
    partial class frm_stor_addmanyedit 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_stor_addmanyedit));
            this.btn_add = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.edt_name = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.edt_stay = new System.Windows.Forms.Label();
            this.edt_add = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.edt_move = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_add
            // 
            this.btn_add.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_add.Appearance.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Appearance.Options.UseFont = true;
            this.btn_add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_add.ImageOptions.Image")));
            this.btn_add.Location = new System.Drawing.Point(38, 429);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(504, 56);
            this.btn_add.TabIndex = 10;
            this.btn_add.Text = "اجراء العملية";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Cairo", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(106, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(400, 90);
            this.label3.TabIndex = 7;
            this.label3.Text = "معلومات الخزينة";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(436, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 45);
            this.label4.TabIndex = 7;
            this.label4.Text = "التاريخ";
            // 
            // date
            // 
            this.date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.date.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date.Location = new System.Drawing.Point(12, 223);
            this.date.Name = "date";
            this.date.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.date.Size = new System.Drawing.Size(282, 31);
            this.date.TabIndex = 11;
            this.date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.date.TextChanged += new System.EventHandler(this.edt_salery_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(397, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 45);
            this.label1.TabIndex = 7;
            this.label1.Text = "اسم الخزينة";
            // 
            // edt_name
            // 
            this.edt_name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.edt_name.BackColor = System.Drawing.Color.PaleVioletRed;
            this.edt_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.edt_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_name.FormattingEnabled = true;
            this.edt_name.Location = new System.Drawing.Point(12, 106);
            this.edt_name.Name = "edt_name";
            this.edt_name.Size = new System.Drawing.Size(282, 32);
            this.edt_name.TabIndex = 12;
            this.edt_name.SelectedIndexChanged += new System.EventHandler(this.edt_name_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(309, 329);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(307, 45);
            this.label2.TabIndex = 7;
            this.label2.Text = "المبلغ المتبقى فى الخزينة";
            // 
            // edt_stay
            // 
            this.edt_stay.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.edt_stay.BackColor = System.Drawing.Color.Silver;
            this.edt_stay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edt_stay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_stay.ForeColor = System.Drawing.Color.Green;
            this.edt_stay.Location = new System.Drawing.Point(12, 338);
            this.edt_stay.Name = "edt_stay";
            this.edt_stay.Size = new System.Drawing.Size(282, 37);
            this.edt_stay.TabIndex = 7;
            this.edt_stay.Text = "0";
            this.edt_stay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // edt_add
            // 
            this.edt_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_add.Location = new System.Drawing.Point(12, 282);
            this.edt_add.Name = "edt_add";
            this.edt_add.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_add.Size = new System.Drawing.Size(282, 31);
            this.edt_add.TabIndex = 14;
            this.edt_add.Text = "0";
            this.edt_add.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.edt_add.TextChanged += new System.EventHandler(this.edt_add_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(384, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 45);
            this.label5.TabIndex = 13;
            this.label5.Text = "المبلغ المضاف";
            // 
            // edt_move
            // 
            this.edt_move.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.edt_move.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.edt_move.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.edt_move.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_move.FormattingEnabled = true;
            this.edt_move.Items.AddRange(new object[] {
            "سحب",
            "ايداع"});
            this.edt_move.Location = new System.Drawing.Point(12, 165);
            this.edt_move.Name = "edt_move";
            this.edt_move.Size = new System.Drawing.Size(282, 32);
            this.edt_move.TabIndex = 16;
            this.edt_move.SelectedIndexChanged += new System.EventHandler(this.edt_move_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(408, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 45);
            this.label6.TabIndex = 15;
            this.label6.Text = "نوع الحركة";
            // 
            // frm_stor_addmanyedit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(616, 497);
            this.Controls.Add(this.edt_move);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.edt_add);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.edt_name);
            this.Controls.Add(this.date);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edt_stay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_stor_addmanyedit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.frm_stor_add_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public DevExpress.XtraEditors.SimpleButton btn_add;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox date;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox edt_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label edt_stay;
        public System.Windows.Forms.TextBox edt_add;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox edt_move;
        private System.Windows.Forms.Label label6;
    }
}