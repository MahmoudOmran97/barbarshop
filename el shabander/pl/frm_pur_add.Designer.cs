
namespace el_shabander.pl
{
    partial class frm_pur_add
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_pur_add));
            this.qts_qt = new System.Windows.Forms.Label();
            this.btn_add = new DevExpress.XtraEditors.SimpleButton();
            this.chack = new System.Windows.Forms.Label();
            this.txt_id = new System.Windows.Forms.Label();
            this.invice_id = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.save = new System.Windows.Forms.ComboBox();
            this.edt_date = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.التاريخ = new System.Windows.Forms.Label();
            this.edt_supp = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.edt_name = new System.Windows.Forms.TextBox();
            this.edt_cat = new System.Windows.Forms.ComboBox();
            this.lb_titelpage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_qt = new DevExpress.XtraEditors.SpinEdit();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.edt_buy = new System.Windows.Forms.TextBox();
            this.btn_delete = new DevExpress.XtraEditors.SimpleButton();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_edit = new DevExpress.XtraEditors.SimpleButton();
            this.btn_add_pur = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_totaldata = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.edt_staybehaver = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.edt_pay = new System.Windows.Forms.TextBox();
            this.edt_stay = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_qt.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // qts_qt
            // 
            this.qts_qt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.qts_qt.AutoSize = true;
            this.qts_qt.BackColor = System.Drawing.Color.Transparent;
            this.qts_qt.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qts_qt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.qts_qt.Location = new System.Drawing.Point(204, 6);
            this.qts_qt.Name = "qts_qt";
            this.qts_qt.Size = new System.Drawing.Size(40, 42);
            this.qts_qt.TabIndex = 25;
            this.qts_qt.Text = "0";
            this.qts_qt.Visible = false;
            // 
            // btn_add
            // 
            this.btn_add.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_add.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Appearance.Options.UseFont = true;
            this.btn_add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_add.ImageOptions.Image")));
            this.btn_add.Location = new System.Drawing.Point(261, 518);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(789, 50);
            this.btn_add.TabIndex = 26;
            this.btn_add.Text = "اضافة ";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click_1);
            // 
            // chack
            // 
            this.chack.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chack.AutoSize = true;
            this.chack.BackColor = System.Drawing.Color.Transparent;
            this.chack.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.chack.Location = new System.Drawing.Point(418, 0);
            this.chack.Name = "chack";
            this.chack.Size = new System.Drawing.Size(40, 42);
            this.chack.TabIndex = 27;
            this.chack.Text = "0";
            this.chack.Visible = false;
            // 
            // txt_id
            // 
            this.txt_id.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_id.BackColor = System.Drawing.Color.Transparent;
            this.txt_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_id.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txt_id.Location = new System.Drawing.Point(105, 19);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(265, 29);
            this.txt_id.TabIndex = 33;
            this.txt_id.Text = "0";
            this.txt_id.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txt_id.Visible = false;
            // 
            // invice_id
            // 
            this.invice_id.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.invice_id.BackColor = System.Drawing.Color.Transparent;
            this.invice_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invice_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invice_id.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.invice_id.Location = new System.Drawing.Point(551, 5);
            this.invice_id.Name = "invice_id";
            this.invice_id.Size = new System.Drawing.Size(265, 29);
            this.invice_id.TabIndex = 34;
            this.invice_id.Text = "0";
            this.invice_id.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.invice_id.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.BackColor = System.Drawing.Color.PeachPuff;
            this.groupBox1.Controls.Add(this.save);
            this.groupBox1.Controls.Add(this.edt_date);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.التاريخ);
            this.groupBox1.Controls.Add(this.edt_supp);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(686, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(553, 197);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "معلومات اساسية";
            // 
            // save
            // 
            this.save.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.save.BackColor = System.Drawing.Color.LightCoral;
            this.save.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save.FormattingEnabled = true;
            this.save.Location = new System.Drawing.Point(10, 94);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(296, 28);
            this.save.TabIndex = 32;
            this.save.SelectedIndexChanged += new System.EventHandler(this.save_SelectedIndexChanged);
            // 
            // edt_date
            // 
            this.edt_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_date.Location = new System.Drawing.Point(10, 142);
            this.edt_date.Name = "edt_date";
            this.edt_date.Size = new System.Drawing.Size(296, 26);
            this.edt_date.TabIndex = 33;
            this.edt_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label19.Location = new System.Drawing.Point(366, 81);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(95, 45);
            this.label19.TabIndex = 31;
            this.label19.Text = "الخزينة";
            this.label19.Click += new System.EventHandler(this.label19_Click);
            // 
            // التاريخ
            // 
            this.التاريخ.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.التاريخ.AutoSize = true;
            this.التاريخ.BackColor = System.Drawing.Color.Transparent;
            this.التاريخ.Font = new System.Drawing.Font("Cairo", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.التاريخ.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.التاريخ.Location = new System.Drawing.Point(366, 126);
            this.التاريخ.Name = "التاريخ";
            this.التاريخ.Size = new System.Drawing.Size(95, 50);
            this.التاريخ.TabIndex = 27;
            this.التاريخ.Text = "التاريخ";
            this.التاريخ.Click += new System.EventHandler(this.التاريخ_Click);
            // 
            // edt_supp
            // 
            this.edt_supp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.edt_supp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.edt_supp.BackColor = System.Drawing.Color.Gold;
            this.edt_supp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_supp.FormattingEnabled = true;
            this.edt_supp.Location = new System.Drawing.Point(10, 46);
            this.edt_supp.Name = "edt_supp";
            this.edt_supp.Size = new System.Drawing.Size(296, 28);
            this.edt_supp.TabIndex = 31;
            this.edt_supp.SelectedIndexChanged += new System.EventHandler(this.edt_supp_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Cairo", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(364, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 50);
            this.label4.TabIndex = 28;
            this.label4.Text = "المورد";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // edt_name
            // 
            this.edt_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_name.BackColor = System.Drawing.Color.Lime;
            this.edt_name.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_name.Location = new System.Drawing.Point(41, 80);
            this.edt_name.Name = "edt_name";
            this.edt_name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_name.Size = new System.Drawing.Size(296, 37);
            this.edt_name.TabIndex = 37;
            this.edt_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.edt_name.TextChanged += new System.EventHandler(this.edt_name_TextChanged);
            // 
            // edt_cat
            // 
            this.edt_cat.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.edt_cat.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_cat.FormattingEnabled = true;
            this.edt_cat.Location = new System.Drawing.Point(41, 152);
            this.edt_cat.Name = "edt_cat";
            this.edt_cat.Size = new System.Drawing.Size(296, 38);
            this.edt_cat.TabIndex = 32;
            this.edt_cat.SelectedIndexChanged += new System.EventHandler(this.edt_cat_SelectedIndexChanged_1);
            // 
            // lb_titelpage
            // 
            this.lb_titelpage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lb_titelpage.AutoSize = true;
            this.lb_titelpage.BackColor = System.Drawing.Color.Transparent;
            this.lb_titelpage.Font = new System.Drawing.Font("Cairo", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_titelpage.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lb_titelpage.Location = new System.Drawing.Point(364, 69);
            this.lb_titelpage.Name = "lb_titelpage";
            this.lb_titelpage.Size = new System.Drawing.Size(153, 50);
            this.lb_titelpage.TabIndex = 26;
            this.lb_titelpage.Text = "اسم المادة";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Cairo", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(389, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 50);
            this.label2.TabIndex = 30;
            this.label2.Text = "الصنف";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Cairo", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(386, 285);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 50);
            this.label10.TabIndex = 25;
            this.label10.Text = "الكمية";
            // 
            // txt_qt
            // 
            this.txt_qt.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_qt.Location = new System.Drawing.Point(41, 297);
            this.txt_qt.Name = "txt_qt";
            this.txt_qt.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_qt.Properties.Appearance.Options.UseFont = true;
            this.txt_qt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_qt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_qt.Size = new System.Drawing.Size(296, 36);
            this.txt_qt.TabIndex = 29;
            this.txt_qt.EditValueChanged += new System.EventHandler(this.txt_qt_EditValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.BackColor = System.Drawing.Color.LightBlue;
            this.groupBox2.Controls.Add(this.edt_buy);
            this.groupBox2.Controls.Add(this.edt_name);
            this.groupBox2.Controls.Add(this.btn_delete);
            this.groupBox2.Controls.Add(this.edt_cat);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.lb_titelpage);
            this.groupBox2.Controls.Add(this.btn_edit);
            this.groupBox2.Controls.Add(this.txt_qt);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.btn_add_pur);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(131, 37);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(544, 449);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "معلومات الشراء";
            // 
            // edt_buy
            // 
            this.edt_buy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_buy.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_buy.Location = new System.Drawing.Point(40, 225);
            this.edt_buy.Name = "edt_buy";
            this.edt_buy.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_buy.Size = new System.Drawing.Size(298, 37);
            this.edt_buy.TabIndex = 36;
            this.edt_buy.Text = "0";
            this.edt_buy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.edt_buy.TextChanged += new System.EventHandler(this.edt_buy_TextChanged);
            // 
            // btn_delete
            // 
            this.btn_delete.Appearance.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.Appearance.Options.UseFont = true;
            this.btn_delete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_delete.ImageOptions.Image")));
            this.btn_delete.Location = new System.Drawing.Point(32, 381);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(139, 49);
            this.btn_delete.TabIndex = 33;
            this.btn_delete.Text = "حذف";
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Cairo", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(362, 213);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(156, 50);
            this.label9.TabIndex = 35;
            this.label9.Text = "سعر الشراء";
            // 
            // btn_edit
            // 
            this.btn_edit.Appearance.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.Appearance.Options.UseFont = true;
            this.btn_edit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_edit.ImageOptions.Image")));
            this.btn_edit.Location = new System.Drawing.Point(197, 381);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(139, 49);
            this.btn_edit.TabIndex = 32;
            this.btn_edit.Text = "تعديل";
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_add_pur
            // 
            this.btn_add_pur.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_add_pur.Appearance.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add_pur.Appearance.Options.UseFont = true;
            this.btn_add_pur.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_add_pur.ImageOptions.Image")));
            this.btn_add_pur.Location = new System.Drawing.Point(362, 381);
            this.btn_add_pur.Name = "btn_add_pur";
            this.btn_add_pur.Size = new System.Drawing.Size(135, 49);
            this.btn_add_pur.TabIndex = 31;
            this.btn_add_pur.Text = "اضافة ";
            this.btn_add_pur.Click += new System.EventHandler(this.btn_add_pur_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox3.BackColor = System.Drawing.Color.Bisque;
            this.groupBox3.Controls.Add(this.txt_totaldata);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.edt_staybehaver);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.edt_pay);
            this.groupBox3.Controls.Add(this.edt_stay);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(686, 240);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox3.Size = new System.Drawing.Size(553, 246);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "معلومات الدفع";
            // 
            // txt_totaldata
            // 
            this.txt_totaldata.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_totaldata.BackColor = System.Drawing.Color.Gray;
            this.txt_totaldata.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_totaldata.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_totaldata.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txt_totaldata.Location = new System.Drawing.Point(10, 42);
            this.txt_totaldata.Name = "txt_totaldata";
            this.txt_totaldata.Size = new System.Drawing.Size(296, 36);
            this.txt_totaldata.TabIndex = 38;
            this.txt_totaldata.Text = "0";
            this.txt_totaldata.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txt_totaldata.Click += new System.EventHandler(this.txt_totaldata_Click_2);
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label17.Location = new System.Drawing.Point(326, 33);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(186, 45);
            this.label17.TabIndex = 39;
            this.label17.Text = "اجمالى الفاتورة";
            // 
            // edt_staybehaver
            // 
            this.edt_staybehaver.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.edt_staybehaver.BackColor = System.Drawing.Color.Gray;
            this.edt_staybehaver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edt_staybehaver.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_staybehaver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.edt_staybehaver.Location = new System.Drawing.Point(10, 92);
            this.edt_staybehaver.Name = "edt_staybehaver";
            this.edt_staybehaver.Size = new System.Drawing.Size(296, 36);
            this.edt_staybehaver.TabIndex = 36;
            this.edt_staybehaver.Text = "0";
            this.edt_staybehaver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.edt_staybehaver.Click += new System.EventHandler(this.edt_staybehaver_Click);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label12.Location = new System.Drawing.Point(332, 83);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(175, 45);
            this.label12.TabIndex = 37;
            this.label12.Text = "حساب سابق له";
            // 
            // edt_pay
            // 
            this.edt_pay.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_pay.Location = new System.Drawing.Point(10, 142);
            this.edt_pay.Name = "edt_pay";
            this.edt_pay.Size = new System.Drawing.Size(296, 35);
            this.edt_pay.TabIndex = 30;
            this.edt_pay.Text = "0";
            this.edt_pay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.edt_pay.TextChanged += new System.EventHandler(this.edt_pay_TextChanged);
            // 
            // edt_stay
            // 
            this.edt_stay.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.edt_stay.BackColor = System.Drawing.Color.Gray;
            this.edt_stay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edt_stay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_stay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.edt_stay.Location = new System.Drawing.Point(10, 191);
            this.edt_stay.Name = "edt_stay";
            this.edt_stay.Size = new System.Drawing.Size(296, 38);
            this.edt_stay.TabIndex = 27;
            this.edt_stay.Text = "0";
            this.edt_stay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.edt_stay.Click += new System.EventHandler(this.edt_stay_Click);
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label13.Location = new System.Drawing.Point(364, 183);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 45);
            this.label13.TabIndex = 28;
            this.label13.Text = "الاجمالى";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(364, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 45);
            this.label5.TabIndex = 29;
            this.label5.Text = "المدفوع";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.invice_id);
            this.panel1.Controls.Add(this.txt_id);
            this.panel1.Controls.Add(this.chack);
            this.panel1.Controls.Add(this.btn_add);
            this.panel1.Controls.Add(this.qts_qt);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 173);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1370, 576);
            this.panel1.TabIndex = 21;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.Size = new System.Drawing.Size(1370, 173);
            this.dataGridView1.TabIndex = 39;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cell);
            // 
            // frm_pur_add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_pur_add";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.frm_pur_add_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_pur_add_FormClosing_1);
            this.Load += new System.EventHandler(this.frm_pur_add_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_qt.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Label qts_qt;
        public DevExpress.XtraEditors.SimpleButton btn_add;
        public System.Windows.Forms.Label chack;
        public System.Windows.Forms.Label txt_id;
        public System.Windows.Forms.Label invice_id;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.ComboBox edt_supp;
        public System.Windows.Forms.ComboBox edt_cat;
        private System.Windows.Forms.Label lb_titelpage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        public DevExpress.XtraEditors.SpinEdit txt_qt;
        private System.Windows.Forms.Label التاريخ;
        public System.Windows.Forms.TextBox edt_date;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox edt_buy;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.ComboBox save;
        private System.Windows.Forms.Label label19;
        public System.Windows.Forms.TextBox edt_pay;
        public System.Windows.Forms.Label edt_stay;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label5;
        public DevExpress.XtraEditors.SimpleButton btn_delete;
        public DevExpress.XtraEditors.SimpleButton btn_edit;
        public DevExpress.XtraEditors.SimpleButton btn_add_pur;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.TextBox edt_name;
        public System.Windows.Forms.Label txt_totaldata;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.Label edt_staybehaver;
        private System.Windows.Forms.Label label12;
    }
}