
namespace el_shabander.pl
{
    partial class frm_stor_addmany 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_stor_addmany));
            this.btn_add = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.edt_count = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.edt_name = new System.Windows.Forms.TextBox();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.edt_del = new System.Windows.Forms.TextBox();
            this.edt_table = new System.Windows.Forms.ComboBox();
            this.btn_ChangeTable = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_add
            // 
            this.btn_add.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_add.Appearance.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Appearance.Options.UseFont = true;
            this.btn_add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_add.ImageOptions.Image")));
            this.btn_add.Location = new System.Drawing.Point(49, 308);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(504, 56);
            this.btn_add.TabIndex = 10;
            this.btn_add.Text = "اضافة خزنة ";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Cairo", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(144, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(298, 90);
            this.label3.TabIndex = 7;
            this.label3.Text = "اضافة خزينة";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Cairo", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(392, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(199, 50);
            this.label4.TabIndex = 7;
            this.label4.Text = "المبلغ المضاف";
            // 
            // edt_count
            // 
            this.edt_count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_count.Location = new System.Drawing.Point(49, 239);
            this.edt_count.Name = "edt_count";
            this.edt_count.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_count.Size = new System.Drawing.Size(337, 31);
            this.edt_count.TabIndex = 11;
            this.edt_count.Text = "0";
            this.edt_count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.edt_count.TextChanged += new System.EventHandler(this.edt_salery_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cairo", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(415, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 50);
            this.label1.TabIndex = 7;
            this.label1.Text = "اسم الخزينة";
            // 
            // edt_name
            // 
            this.edt_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_name.Location = new System.Drawing.Point(49, 160);
            this.edt_name.Name = "edt_name";
            this.edt_name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_name.Size = new System.Drawing.Size(337, 31);
            this.edt_name.TabIndex = 11;
            this.edt_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.edt_name.TextChanged += new System.EventHandler(this.edt_salery_TextChanged);
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupControl2.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControl2.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.groupControl2.Appearance.BorderColor = System.Drawing.Color.Red;
            this.groupControl2.Appearance.Options.UseBackColor = true;
            this.groupControl2.Appearance.Options.UseBorderColor = true;
            this.groupControl2.AppearanceCaption.BackColor = System.Drawing.Color.White;
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl2.AppearanceCaption.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.groupControl2.AppearanceCaption.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupControl2.AppearanceCaption.Options.UseBackColor = true;
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl2.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl2.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl2.AppearanceCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.groupControl2.Controls.Add(this.edt_del);
            this.groupControl2.Controls.Add(this.edt_table);
            this.groupControl2.Controls.Add(this.btn_ChangeTable);
            this.groupControl2.Location = new System.Drawing.Point(12, 370);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Padding = new System.Windows.Forms.Padding(4);
            this.groupControl2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupControl2.Size = new System.Drawing.Size(573, 126);
            this.groupControl2.TabIndex = 46;
            this.groupControl2.Text = "حذف خزينة";
            // 
            // edt_del
            // 
            this.edt_del.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_del.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_del.Location = new System.Drawing.Point(20, 86);
            this.edt_del.Name = "edt_del";
            this.edt_del.ReadOnly = true;
            this.edt_del.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_del.Size = new System.Drawing.Size(296, 31);
            this.edt_del.TabIndex = 43;
            this.edt_del.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // edt_table
            // 
            this.edt_table.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.edt_table.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.edt_table.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.edt_table.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_table.FormattingEnabled = true;
            this.edt_table.Location = new System.Drawing.Point(20, 48);
            this.edt_table.Name = "edt_table";
            this.edt_table.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_table.Size = new System.Drawing.Size(296, 28);
            this.edt_table.TabIndex = 42;
            this.edt_table.SelectedIndexChanged += new System.EventHandler(this.edt_table_SelectedIndexChanged);
            // 
            // btn_ChangeTable
            // 
            this.btn_ChangeTable.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_ChangeTable.Appearance.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ChangeTable.Appearance.Options.UseFont = true;
            this.btn_ChangeTable.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_ChangeTable.ImageOptions.Image")));
            this.btn_ChangeTable.Location = new System.Drawing.Point(374, 64);
            this.btn_ChangeTable.Name = "btn_ChangeTable";
            this.btn_ChangeTable.Size = new System.Drawing.Size(167, 42);
            this.btn_ChangeTable.TabIndex = 41;
            this.btn_ChangeTable.Text = "حذف";
            this.btn_ChangeTable.Click += new System.EventHandler(this.btn_ChangeTable_Click);
            // 
            // frm_stor_addmany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(616, 497);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.edt_name);
            this.Controls.Add(this.edt_count);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_stor_addmany";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.frm_stor_add_Activated);
            this.Load += new System.EventHandler(this.frm_stor_addmany_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public DevExpress.XtraEditors.SimpleButton btn_add;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox edt_count;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox edt_name;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        public System.Windows.Forms.TextBox edt_del;
        public System.Windows.Forms.ComboBox edt_table;
        public DevExpress.XtraEditors.SimpleButton btn_ChangeTable;
    }
}