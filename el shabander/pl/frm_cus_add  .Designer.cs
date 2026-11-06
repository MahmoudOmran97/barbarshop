
namespace el_shabander.pl
{
    partial class frm_cus_add 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_cus_add));
            this.lb_titelpage = new System.Windows.Forms.Label();
            this.btn_add = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.edt_table = new System.Windows.Forms.ComboBox();
            this.num_tab = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.num_tab)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_titelpage
            // 
            this.lb_titelpage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lb_titelpage.AutoSize = true;
            this.lb_titelpage.BackColor = System.Drawing.Color.Transparent;
            this.lb_titelpage.Font = new System.Drawing.Font("Cairo", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_titelpage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_titelpage.Location = new System.Drawing.Point(515, 183);
            this.lb_titelpage.Name = "lb_titelpage";
            this.lb_titelpage.Size = new System.Drawing.Size(191, 60);
            this.lb_titelpage.TabIndex = 7;
            this.lb_titelpage.Text = "رقم المقعد";
            // 
            // btn_add
            // 
            this.btn_add.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_add.Appearance.Font = new System.Drawing.Font("Cairo", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Appearance.Options.UseFont = true;
            this.btn_add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_add.ImageOptions.Image")));
            this.btn_add.Location = new System.Drawing.Point(78, 404);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(538, 56);
            this.btn_add.TabIndex = 10;
            this.btn_add.Text = "اضافة ";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Cairo", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(535, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 60);
            this.label2.TabIndex = 7;
            this.label2.Text = "المنطقة";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cairo", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(203, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 90);
            this.label1.TabIndex = 11;
            this.label1.Text = "اضافة مقعد";
            // 
            // edt_table
            // 
            this.edt_table.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.edt_table.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.edt_table.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.edt_table.Font = new System.Drawing.Font("Cairo", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_table.FormattingEnabled = true;
            this.edt_table.Location = new System.Drawing.Point(28, 296);
            this.edt_table.Name = "edt_table";
            this.edt_table.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_table.Size = new System.Drawing.Size(452, 58);
            this.edt_table.TabIndex = 43;
            // 
            // num_tab
            // 
            this.num_tab.BackColor = System.Drawing.Color.Teal;
            this.num_tab.Font = new System.Drawing.Font("Cairo", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_tab.ForeColor = System.Drawing.Color.LightYellow;
            this.num_tab.Location = new System.Drawing.Point(28, 185);
            this.num_tab.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_tab.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_tab.Name = "num_tab";
            this.num_tab.Size = new System.Drawing.Size(452, 58);
            this.num_tab.TabIndex = 44;
            this.num_tab.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_tab.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // frm_cus_add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Moccasin;
            this.ClientSize = new System.Drawing.Size(728, 498);
            this.Controls.Add(this.num_tab);
            this.Controls.Add(this.edt_table);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_titelpage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_cus_add";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frm_cus_add_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_tab)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lb_titelpage;
        public DevExpress.XtraEditors.SimpleButton btn_add;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox edt_table;
        private System.Windows.Forms.NumericUpDown num_tab;
    }
}