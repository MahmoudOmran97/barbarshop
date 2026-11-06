
namespace el_shabander.pl
{
    partial class frm_settingpro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_settingpro));
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.edt_serildevice = new System.Windows.Forms.TextBox();
            this.edt_serilnam = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dark = new DevExpress.XtraEditors.ToggleSwitch();
            this.label12 = new System.Windows.Forms.Label();
            this.edt_time = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_send = new DevExpress.XtraEditors.SimpleButton();
            this.btn_restor = new DevExpress.XtraEditors.SimpleButton();
            this.btn_backup = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.edt_addres = new System.Windows.Forms.TextBox();
            this.edt_logo = new DevExpress.XtraEditors.PictureEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddImage = new DevExpress.XtraEditors.SimpleButton();
            this.edt_phone = new System.Windows.Forms.TextBox();
            this.edt_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.frm_cat = new System.Windows.Forms.Panel();
            this.pn_prog = new DevExpress.XtraWaitForm.ProgressPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txt_print = new System.Windows.Forms.ComboBox();
            this.txt_invoce = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_printcode = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_save = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_pass = new System.Windows.Forms.TextBox();
            this.txt_admin = new System.Windows.Forms.TextBox();
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_time)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_logo.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.frm_cat.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(429, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 36);
            this.label3.TabIndex = 29;
            this.label3.Text = "العنوان";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.BackColor = System.Drawing.Color.Silver;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(450, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 36);
            this.label6.TabIndex = 30;
            this.label6.Text = "سريل الجهاز";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.edt_serildevice);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.edt_serilnam);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Font = new System.Drawing.Font("Cairo", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 261);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox3.Size = new System.Drawing.Size(602, 131);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ترخيص النسخة";
            // 
            // edt_serildevice
            // 
            this.edt_serildevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_serildevice.BackColor = System.Drawing.Color.Lime;
            this.edt_serildevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_serildevice.Location = new System.Drawing.Point(51, 49);
            this.edt_serildevice.Name = "edt_serildevice";
            this.edt_serildevice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_serildevice.Size = new System.Drawing.Size(382, 31);
            this.edt_serildevice.TabIndex = 31;
            this.edt_serildevice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // edt_serilnam
            // 
            this.edt_serilnam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_serilnam.BackColor = System.Drawing.Color.Crimson;
            this.edt_serilnam.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_serilnam.Location = new System.Drawing.Point(51, 90);
            this.edt_serilnam.Name = "edt_serilnam";
            this.edt_serilnam.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_serilnam.Size = new System.Drawing.Size(382, 31);
            this.edt_serilnam.TabIndex = 29;
            this.edt_serilnam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.BackColor = System.Drawing.Color.Silver;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(450, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 36);
            this.label5.TabIndex = 28;
            this.label5.Text = "الترخيص";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(38, 547);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox4.Size = new System.Drawing.Size(564, 131);
            this.groupBox4.TabIndex = 27;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ترخيص النسخة";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.dark);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.edt_time);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btn_send);
            this.groupBox2.Controls.Add(this.btn_restor);
            this.groupBox2.Controls.Add(this.btn_backup);
            this.groupBox2.Font = new System.Drawing.Font("Cairo", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 382);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(602, 282);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "قاعدة البيانات";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label9.Location = new System.Drawing.Point(184, 243);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(155, 36);
            this.label9.TabIndex = 34;
            this.label9.Text = "active dark mode";
            // 
            // dark
            // 
            this.dark.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dark.EditValue = null;
            this.dark.Location = new System.Drawing.Point(345, 241);
            this.dark.Name = "dark";
            this.dark.Properties.AutoHeight = false;
            this.dark.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.dark.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.dark.Properties.OffText = "Off";
            this.dark.Properties.OnText = "On";
            this.dark.Size = new System.Drawing.Size(73, 45);
            this.dark.TabIndex = 35;
            this.dark.Toggled += new System.EventHandler(this.dark_Toggled);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Cairo", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label12.Location = new System.Drawing.Point(312, 166);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 50);
            this.label12.TabIndex = 27;
            this.label12.Text = "كل";
            // 
            // edt_time
            // 
            this.edt_time.BackColor = System.Drawing.Color.Teal;
            this.edt_time.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_time.ForeColor = System.Drawing.Color.LightYellow;
            this.edt_time.Location = new System.Drawing.Point(146, 174);
            this.edt_time.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.edt_time.Name = "edt_time";
            this.edt_time.Size = new System.Drawing.Size(147, 43);
            this.edt_time.TabIndex = 24;
            this.edt_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Cairo", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(56, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 50);
            this.label2.TabIndex = 26;
            this.label2.Text = " ساعة";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label8.Location = new System.Drawing.Point(400, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(173, 36);
            this.label8.TabIndex = 25;
            this.label8.Text = "فترة ارسال البيانات";
            // 
            // btn_send
            // 
            this.btn_send.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_send.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_send.Appearance.Options.UseFont = true;
            this.btn_send.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_send.ImageOptions.Image")));
            this.btn_send.Location = new System.Drawing.Point(127, 103);
            this.btn_send.Name = "btn_send";
            this.btn_send.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_send.Size = new System.Drawing.Size(291, 46);
            this.btn_send.TabIndex = 23;
            this.btn_send.Text = "ارسال البيانات";
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // btn_restor
            // 
            this.btn_restor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_restor.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_restor.Appearance.Options.UseFont = true;
            this.btn_restor.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_restor.ImageOptions.Image")));
            this.btn_restor.Location = new System.Drawing.Point(19, 43);
            this.btn_restor.Name = "btn_restor";
            this.btn_restor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_restor.Size = new System.Drawing.Size(241, 46);
            this.btn_restor.TabIndex = 22;
            this.btn_restor.Text = "استعادة نسخة احتياطية";
            this.btn_restor.Click += new System.EventHandler(this.btn_restor_Click);
            // 
            // btn_backup
            // 
            this.btn_backup.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_backup.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_backup.Appearance.Options.UseFont = true;
            this.btn_backup.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_backup.ImageOptions.Image")));
            this.btn_backup.Location = new System.Drawing.Point(293, 43);
            this.btn_backup.Name = "btn_backup";
            this.btn_backup.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_backup.Size = new System.Drawing.Size(255, 46);
            this.btn_backup.TabIndex = 21;
            this.btn_backup.Text = "اخذ نسخة احتياطية";
            this.btn_backup.Click += new System.EventHandler(this.btn_backup_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.BackColor = System.Drawing.Color.Silver;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(429, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 36);
            this.label4.TabIndex = 31;
            this.label4.Text = "رقم الهاتف";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // edt_addres
            // 
            this.edt_addres.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_addres.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_addres.Location = new System.Drawing.Point(41, 119);
            this.edt_addres.Name = "edt_addres";
            this.edt_addres.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_addres.Size = new System.Drawing.Size(382, 31);
            this.edt_addres.TabIndex = 30;
            this.edt_addres.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // edt_logo
            // 
            this.edt_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.edt_logo.Location = new System.Drawing.Point(111, 238);
            this.edt_logo.Name = "edt_logo";
            this.edt_logo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.edt_logo.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.edt_logo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.edt_logo.Size = new System.Drawing.Size(226, 202);
            this.edt_logo.TabIndex = 28;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddImage);
            this.groupBox1.Controls.Add(this.edt_phone);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.edt_addres);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.edt_logo);
            this.groupBox1.Controls.Add(this.edt_name);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Cairo", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(639, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(562, 445);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "اعدادات عامة";
            // 
            // btnAddImage
            // 
            this.btnAddImage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAddImage.Appearance.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddImage.Appearance.Options.UseFont = true;
            this.btnAddImage.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddImage.ImageOptions.Image")));
            this.btnAddImage.Location = new System.Drawing.Point(389, 271);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(166, 45);
            this.btnAddImage.TabIndex = 33;
            this.btnAddImage.Text = "اضافة شعار";
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // edt_phone
            // 
            this.edt_phone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_phone.Location = new System.Drawing.Point(41, 180);
            this.edt_phone.Name = "edt_phone";
            this.edt_phone.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_phone.Size = new System.Drawing.Size(382, 31);
            this.edt_phone.TabIndex = 32;
            this.edt_phone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // edt_name
            // 
            this.edt_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_name.Location = new System.Drawing.Point(41, 65);
            this.edt_name.Name = "edt_name";
            this.edt_name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_name.Size = new System.Drawing.Size(382, 31);
            this.edt_name.TabIndex = 26;
            this.edt_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(429, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 36);
            this.label1.TabIndex = 24;
            this.label1.Text = "اسم الشركة";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frm_cat
            // 
            this.frm_cat.BackColor = System.Drawing.Color.LightCyan;
            this.frm_cat.Controls.Add(this.groupBox6);
            this.frm_cat.Controls.Add(this.pn_prog);
            this.frm_cat.Controls.Add(this.groupBox5);
            this.frm_cat.Controls.Add(this.groupBox3);
            this.frm_cat.Controls.Add(this.groupBox2);
            this.frm_cat.Controls.Add(this.groupBox1);
            this.frm_cat.Controls.Add(this.btn_save);
            this.frm_cat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frm_cat.Location = new System.Drawing.Point(0, 0);
            this.frm_cat.Name = "frm_cat";
            this.frm_cat.Size = new System.Drawing.Size(1213, 751);
            this.frm_cat.TabIndex = 21;
            this.frm_cat.Paint += new System.Windows.Forms.PaintEventHandler(this.frm_cat_Paint);
            // 
            // pn_prog
            // 
            this.pn_prog.Appearance.BackColor = System.Drawing.Color.Gray;
            this.pn_prog.Appearance.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pn_prog.Appearance.Options.UseBackColor = true;
            this.pn_prog.Appearance.Options.UseFont = true;
            this.pn_prog.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pn_prog.AppearanceCaption.Options.UseFont = true;
            this.pn_prog.AppearanceCaption.Options.UseTextOptions = true;
            this.pn_prog.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.pn_prog.AppearanceCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.pn_prog.AppearanceCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.pn_prog.AppearanceDescription.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pn_prog.AppearanceDescription.Options.UseFont = true;
            this.pn_prog.AppearanceDescription.Options.UseTextOptions = true;
            this.pn_prog.AppearanceDescription.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.pn_prog.AppearanceDescription.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.pn_prog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pn_prog.Caption = "                      الرجاء الانتظار  ";
            this.pn_prog.Description = "تحتاج هذة العملية بعض الوقت";
            this.pn_prog.Location = new System.Drawing.Point(416, 229);
            this.pn_prog.Name = "pn_prog";
            this.pn_prog.Size = new System.Drawing.Size(379, 85);
            this.pn_prog.TabIndex = 33;
            this.pn_prog.Text = "progress";
            this.pn_prog.Visible = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txt_print);
            this.groupBox5.Controls.Add(this.txt_invoce);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.txt_printcode);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Font = new System.Drawing.Font("Cairo", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(12, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox5.Size = new System.Drawing.Size(602, 252);
            this.groupBox5.TabIndex = 24;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "نوع الطباعة";
            // 
            // txt_print
            // 
            this.txt_print.BackColor = System.Drawing.Color.PeachPuff;
            this.txt_print.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_print.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_print.FormattingEnabled = true;
            this.txt_print.Items.AddRange(new object[] {
            "XP(fast)",
            "XP(slow)"});
            this.txt_print.Location = new System.Drawing.Point(19, 53);
            this.txt_print.Name = "txt_print";
            this.txt_print.Size = new System.Drawing.Size(379, 33);
            this.txt_print.TabIndex = 31;
            // 
            // txt_invoce
            // 
            this.txt_invoce.BackColor = System.Drawing.Color.PeachPuff;
            this.txt_invoce.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_invoce.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_invoce.FormattingEnabled = true;
            this.txt_invoce.Location = new System.Drawing.Point(19, 187);
            this.txt_invoce.Name = "txt_invoce";
            this.txt_invoce.Size = new System.Drawing.Size(379, 33);
            this.txt_invoce.TabIndex = 39;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.BackColor = System.Drawing.Color.Silver;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(404, 188);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(189, 36);
            this.label11.TabIndex = 38;
            this.label11.Text = "طابعة الفاتورة";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.BackColor = System.Drawing.Color.Silver;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(404, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(189, 36);
            this.label7.TabIndex = 37;
            this.label7.Text = " نوع طباعة الفاتورة";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_printcode
            // 
            this.txt_printcode.BackColor = System.Drawing.Color.PeachPuff;
            this.txt_printcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_printcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_printcode.FormattingEnabled = true;
            this.txt_printcode.Items.AddRange(new object[] {
            "50mmx25mm",
            "40mm×20mm"});
            this.txt_printcode.Location = new System.Drawing.Point(19, 120);
            this.txt_printcode.Name = "txt_printcode";
            this.txt_printcode.Size = new System.Drawing.Size(379, 33);
            this.txt_printcode.TabIndex = 36;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.BackColor = System.Drawing.Color.Silver;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(404, 119);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(189, 36);
            this.label10.TabIndex = 35;
            this.label10.Text = "نوع طباعة الباركود";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_save
            // 
            this.btn_save.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_save.Appearance.Font = new System.Drawing.Font("Cairo", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Appearance.Options.UseFont = true;
            this.btn_save.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_save.ImageOptions.Image")));
            this.btn_save.Location = new System.Drawing.Point(416, 683);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(379, 65);
            this.btn_save.TabIndex = 20;
            this.btn_save.Text = "حفظ";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click_1);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txt_pass);
            this.groupBox6.Controls.Add(this.txt_admin);
            this.groupBox6.Controls.Add(this.txt_ip);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Font = new System.Drawing.Font("Cairo", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(639, 458);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox6.Size = new System.Drawing.Size(562, 210);
            this.groupBox6.TabIndex = 34;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "جهاز الحضور والانصراف";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label13.BackColor = System.Drawing.Color.Silver;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(429, 166);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(126, 36);
            this.label13.TabIndex = 38;
            this.label13.Text = "كلمة المرور";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label14.BackColor = System.Drawing.Color.Silver;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label14.Location = new System.Drawing.Point(429, 54);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(126, 36);
            this.label14.TabIndex = 37;
            this.label14.Text = "عنوان ip";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label15.BackColor = System.Drawing.Color.Silver;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(429, 110);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(126, 36);
            this.label15.TabIndex = 35;
            this.label15.Text = "اسم المستخدم";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_pass
            // 
            this.txt_pass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pass.Location = new System.Drawing.Point(28, 174);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_pass.Size = new System.Drawing.Size(382, 31);
            this.txt_pass.TabIndex = 41;
            this.txt_pass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_admin
            // 
            this.txt_admin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_admin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_admin.Location = new System.Drawing.Point(28, 113);
            this.txt_admin.Name = "txt_admin";
            this.txt_admin.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_admin.Size = new System.Drawing.Size(382, 31);
            this.txt_admin.TabIndex = 40;
            this.txt_admin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_ip
            // 
            this.txt_ip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ip.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ip.Location = new System.Drawing.Point(28, 59);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_ip.Size = new System.Drawing.Size(382, 31);
            this.txt_ip.TabIndex = 39;
            this.txt_ip.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frm_settingpro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 751);
            this.Controls.Add(this.frm_cat);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_settingpro";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الاعدادات";
            this.Load += new System.EventHandler(this.frm_setting_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_time)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_logo.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.frm_cat.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.TextBox edt_serildevice;
        public System.Windows.Forms.TextBox edt_serilnam;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown edt_time;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.SimpleButton btn_send;
        private DevExpress.XtraEditors.SimpleButton btn_restor;
        private DevExpress.XtraEditors.SimpleButton btn_backup;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox edt_addres;
        private DevExpress.XtraEditors.PictureEdit edt_logo;
        private System.Windows.Forms.GroupBox groupBox1;
        public DevExpress.XtraEditors.SimpleButton btnAddImage;
        public System.Windows.Forms.TextBox edt_phone;
        public System.Windows.Forms.TextBox edt_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel frm_cat;
        private System.Windows.Forms.ComboBox txt_print;
        private DevExpress.XtraWaitForm.ProgressPanel pn_prog;
        private System.Windows.Forms.GroupBox groupBox5;
        private DevExpress.XtraEditors.SimpleButton btn_save;
        private System.Windows.Forms.Label label9;
        public DevExpress.XtraEditors.ToggleSwitch dark;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox txt_printcode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox txt_invoce;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox6;
        public System.Windows.Forms.TextBox txt_pass;
        public System.Windows.Forms.TextBox txt_admin;
        public System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
    }
}