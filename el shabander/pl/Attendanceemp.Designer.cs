
namespace el_shabander.pl
{
    partial class Attendanceemp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Attendanceemp));
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition1 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition1 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition2 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition3 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition4 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement1 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement2 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement3 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement4 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            this.edt_day_serch = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btn_connect_device = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_device_status = new System.Windows.Forms.Label();
            this.btn_fetch_device = new DevExpress.XtraEditors.SimpleButton();
            this.btn_delete = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.edt_dateserc = new System.Windows.Forms.DateTimePicker();
            this.btn_leave = new DevExpress.XtraEditors.SimpleButton();
            this.btn_close = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_absent = new DevExpress.XtraEditors.SimpleButton();
            this.edt_date = new System.Windows.Forms.Label();
            this.btn_open = new DevExpress.XtraEditors.SimpleButton();
            this.edt_employee = new System.Windows.Forms.ComboBox();
            this.btn_updata = new DevExpress.XtraEditors.SimpleButton();
            this.btn_in = new DevExpress.XtraEditors.SimpleButton();
            this.pn_cat = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colsafe_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tileView1 = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.cardView1 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.colsupp_image = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colid = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colsupp_name = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colsupp_phone = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colsupp_email = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.pn_cat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).BeginInit();
            this.SuspendLayout();
            // 
            // edt_day_serch
            // 
            this.edt_day_serch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.edt_day_serch.CalendarFont = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_day_serch.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_day_serch.Location = new System.Drawing.Point(773, 5);
            this.edt_day_serch.Name = "edt_day_serch";
            this.edt_day_serch.Size = new System.Drawing.Size(244, 37);
            this.edt_day_serch.TabIndex = 134;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupControl1);
            this.panel1.Controls.Add(this.btn_delete);
            this.panel1.Controls.Add(this.edt_day_serch);
            this.panel1.Controls.Add(this.simpleButton1);
            this.panel1.Controls.Add(this.groupControl2);
            this.panel1.Controls.Add(this.btn_updata);
            this.panel1.Controls.Add(this.btn_in);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 470);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1030, 250);
            this.panel1.TabIndex = 2;
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.Lime;
            this.groupControl1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupControl1.Appearance.BorderColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.groupControl1.Appearance.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Appearance.Options.UseBorderColor = true;
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl1.Controls.Add(this.btn_connect_device);
            this.groupControl1.Controls.Add(this.lbl_device_status);
            this.groupControl1.Controls.Add(this.btn_fetch_device);
            this.groupControl1.Location = new System.Drawing.Point(434, 5);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(333, 232);
            this.groupControl1.TabIndex = 137;
            this.groupControl1.Text = "الجهاز";
            // 
            // btn_connect_device
            // 
            this.btn_connect_device.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_connect_device.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btn_connect_device.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btn_connect_device.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_connect_device.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btn_connect_device.Appearance.Options.UseBackColor = true;
            this.btn_connect_device.Appearance.Options.UseBorderColor = true;
            this.btn_connect_device.Appearance.Options.UseFont = true;
            this.btn_connect_device.Appearance.Options.UseForeColor = true;
            this.btn_connect_device.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_connect_device.ImageOptions.Image")));
            this.btn_connect_device.Location = new System.Drawing.Point(32, 132);
            this.btn_connect_device.Name = "btn_connect_device";
            this.btn_connect_device.Size = new System.Drawing.Size(264, 41);
            this.btn_connect_device.TabIndex = 137;
            this.btn_connect_device.Text = "الاتصال بالجهاز";
            this.btn_connect_device.Click += new System.EventHandler(this.btn_connect_device_Click);
            // 
            // lbl_device_status
            // 
            this.lbl_device_status.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_device_status.BackColor = System.Drawing.Color.Transparent;
            this.lbl_device_status.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_device_status.Location = new System.Drawing.Point(5, 43);
            this.lbl_device_status.Name = "lbl_device_status";
            this.lbl_device_status.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_device_status.Size = new System.Drawing.Size(323, 70);
            this.lbl_device_status.TabIndex = 136;
            this.lbl_device_status.Text = "label1";
            this.lbl_device_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_fetch_device
            // 
            this.btn_fetch_device.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_fetch_device.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btn_fetch_device.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btn_fetch_device.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_fetch_device.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btn_fetch_device.Appearance.Options.UseBackColor = true;
            this.btn_fetch_device.Appearance.Options.UseBorderColor = true;
            this.btn_fetch_device.Appearance.Options.UseFont = true;
            this.btn_fetch_device.Appearance.Options.UseForeColor = true;
            this.btn_fetch_device.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_fetch_device.ImageOptions.Image")));
            this.btn_fetch_device.Location = new System.Drawing.Point(32, 178);
            this.btn_fetch_device.Name = "btn_fetch_device";
            this.btn_fetch_device.Size = new System.Drawing.Size(264, 41);
            this.btn_fetch_device.TabIndex = 2;
            this.btn_fetch_device.Text = "جلب حضور من الجهاز";
            this.btn_fetch_device.Click += new System.EventHandler(this.btn_fetch_device_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_delete.Appearance.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.Appearance.Options.UseFont = true;
            this.btn_delete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_delete.ImageOptions.Image")));
            this.btn_delete.Location = new System.Drawing.Point(872, 189);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(143, 41);
            this.btn_delete.TabIndex = 135;
            this.btn_delete.Text = "حذف";
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(872, 48);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(143, 41);
            this.simpleButton1.TabIndex = 132;
            this.simpleButton1.Text = "بحث بالتاريخ";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Appearance.BackColor = System.Drawing.Color.Lime;
            this.groupControl2.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupControl2.Appearance.BorderColor = System.Drawing.Color.Teal;
            this.groupControl2.Appearance.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl2.Appearance.Options.UseBackColor = true;
            this.groupControl2.Appearance.Options.UseBorderColor = true;
            this.groupControl2.Appearance.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl2.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl2.Controls.Add(this.edt_dateserc);
            this.groupControl2.Controls.Add(this.btn_leave);
            this.groupControl2.Controls.Add(this.btn_close);
            this.groupControl2.Controls.Add(this.label1);
            this.groupControl2.Controls.Add(this.btn_absent);
            this.groupControl2.Controls.Add(this.edt_date);
            this.groupControl2.Controls.Add(this.btn_open);
            this.groupControl2.Controls.Add(this.edt_employee);
            this.groupControl2.Location = new System.Drawing.Point(11, 5);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(417, 232);
            this.groupControl2.TabIndex = 129;
            this.groupControl2.Text = "تسجيل الحضور والانصراف";
            // 
            // edt_dateserc
            // 
            this.edt_dateserc.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.edt_dateserc.CalendarFont = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_dateserc.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_dateserc.Location = new System.Drawing.Point(6, 76);
            this.edt_dateserc.Name = "edt_dateserc";
            this.edt_dateserc.Size = new System.Drawing.Size(271, 37);
            this.edt_dateserc.TabIndex = 133;
            // 
            // btn_leave
            // 
            this.btn_leave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_leave.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btn_leave.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btn_leave.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_leave.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btn_leave.Appearance.Options.UseBackColor = true;
            this.btn_leave.Appearance.Options.UseBorderColor = true;
            this.btn_leave.Appearance.Options.UseFont = true;
            this.btn_leave.Appearance.Options.UseForeColor = true;
            this.btn_leave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_leave.ImageOptions.Image")));
            this.btn_leave.Location = new System.Drawing.Point(279, 139);
            this.btn_leave.Name = "btn_leave";
            this.btn_leave.Size = new System.Drawing.Size(132, 41);
            this.btn_leave.TabIndex = 135;
            this.btn_leave.Text = "إجازة";
            this.btn_leave.Click += new System.EventHandler(this.btn_leave_Click);
            // 
            // btn_close
            // 
            this.btn_close.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_close.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btn_close.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btn_close.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btn_close.Appearance.Options.UseBackColor = true;
            this.btn_close.Appearance.Options.UseBorderColor = true;
            this.btn_close.Appearance.Options.UseFont = true;
            this.btn_close.Appearance.Options.UseForeColor = true;
            this.btn_close.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_close.ImageOptions.Image")));
            this.btn_close.Location = new System.Drawing.Point(279, 92);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(132, 41);
            this.btn_close.TabIndex = 134;
            this.btn_close.Text = "تسجيل خروج";
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 137);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(148, 36);
            this.label1.TabIndex = 133;
            this.label1.Text = "اسم الموظف";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_absent
            // 
            this.btn_absent.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_absent.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btn_absent.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btn_absent.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_absent.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btn_absent.Appearance.Options.UseBackColor = true;
            this.btn_absent.Appearance.Options.UseBorderColor = true;
            this.btn_absent.Appearance.Options.UseFont = true;
            this.btn_absent.Appearance.Options.UseForeColor = true;
            this.btn_absent.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_absent.ImageOptions.Image")));
            this.btn_absent.Location = new System.Drawing.Point(279, 186);
            this.btn_absent.Name = "btn_absent";
            this.btn_absent.Size = new System.Drawing.Size(132, 41);
            this.btn_absent.TabIndex = 132;
            this.btn_absent.Text = "غائب";
            this.btn_absent.Click += new System.EventHandler(this.btn_absent_Click);
            // 
            // edt_date
            // 
            this.edt_date.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.edt_date.BackColor = System.Drawing.Color.Transparent;
            this.edt_date.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_date.Location = new System.Drawing.Point(6, 37);
            this.edt_date.Name = "edt_date";
            this.edt_date.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_date.Size = new System.Drawing.Size(271, 36);
            this.edt_date.TabIndex = 3;
            this.edt_date.Text = "label1";
            this.edt_date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_open
            // 
            this.btn_open.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_open.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btn_open.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btn_open.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_open.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btn_open.Appearance.Options.UseBackColor = true;
            this.btn_open.Appearance.Options.UseBorderColor = true;
            this.btn_open.Appearance.Options.UseFont = true;
            this.btn_open.Appearance.Options.UseForeColor = true;
            this.btn_open.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_open.ImageOptions.Image")));
            this.btn_open.Location = new System.Drawing.Point(279, 45);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(132, 41);
            this.btn_open.TabIndex = 2;
            this.btn_open.Text = "تسجيل دخول";
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // edt_employee
            // 
            this.edt_employee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_employee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.edt_employee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.edt_employee.BackColor = System.Drawing.Color.LimeGreen;
            this.edt_employee.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_employee.FormattingEnabled = true;
            this.edt_employee.Location = new System.Drawing.Point(5, 186);
            this.edt_employee.Name = "edt_employee";
            this.edt_employee.Size = new System.Drawing.Size(271, 32);
            this.edt_employee.TabIndex = 131;
            // 
            // btn_updata
            // 
            this.btn_updata.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_updata.Appearance.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_updata.Appearance.Options.UseFont = true;
            this.btn_updata.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_updata.ImageOptions.Image")));
            this.btn_updata.Location = new System.Drawing.Point(872, 142);
            this.btn_updata.Name = "btn_updata";
            this.btn_updata.Size = new System.Drawing.Size(143, 41);
            this.btn_updata.TabIndex = 4;
            this.btn_updata.Text = "تحديث";
            this.btn_updata.Click += new System.EventHandler(this.btn_updata_Click);
            // 
            // btn_in
            // 
            this.btn_in.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_in.Appearance.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_in.Appearance.Options.UseFont = true;
            this.btn_in.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_in.ImageOptions.Image")));
            this.btn_in.Location = new System.Drawing.Point(872, 95);
            this.btn_in.Name = "btn_in";
            this.btn_in.Size = new System.Drawing.Size(143, 41);
            this.btn_in.TabIndex = 1;
            this.btn_in.Text = "عرض الصف";
            this.btn_in.Click += new System.EventHandler(this.btn_in_Click);
            // 
            // pn_cat
            // 
            this.pn_cat.BackColor = System.Drawing.Color.Silver;
            this.pn_cat.Controls.Add(this.gridControl1);
            this.pn_cat.Controls.Add(this.panel1);
            this.pn_cat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_cat.Location = new System.Drawing.Point(0, 0);
            this.pn_cat.Name = "pn_cat";
            this.pn_cat.Size = new System.Drawing.Size(1030, 720);
            this.pn_cat.TabIndex = 2;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = typeof(el_shabander.Attendance);
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControl1.Size = new System.Drawing.Size(1030, 470);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.tileView1,
            this.cardView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colsafe_name,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView1_RowStyle);
            // 
            // colsafe_name
            // 
            this.colsafe_name.AppearanceHeader.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold);
            this.colsafe_name.AppearanceHeader.Options.UseFont = true;
            this.colsafe_name.Caption = "اسم الموظف";
            this.colsafe_name.FieldName = "NameEmployee";
            this.colsafe_name.Name = "colsafe_name";
            this.colsafe_name.Visible = true;
            this.colsafe_name.VisibleIndex = 0;
            this.colsafe_name.Width = 214;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.Caption = "وقت الحضور";
            this.gridColumn1.DisplayFormat.FormatString = " hh:mm tt";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn1.FieldName = "CheckIn";
            this.gridColumn1.GroupFormat.FormatString = " hh:mm tt";
            this.gridColumn1.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 162;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.Caption = "وقت الانصراف";
            this.gridColumn2.DisplayFormat.FormatString = " hh:mm tt";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn2.FieldName = "CheckOut";
            this.gridColumn2.GroupFormat.FormatString = " hh:mm tt";
            this.gridColumn2.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 139;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "الحالة";
            this.gridColumn3.FieldName = "Status";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 141;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "تاريخ اليوم";
            this.gridColumn4.FieldName = "AttendDate";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 158;
            // 
            // tileView1
            // 
            this.tileView1.GridControl = this.gridControl1;
            this.tileView1.Name = "tileView1";
            this.tileView1.OptionsTiles.ItemSize = new System.Drawing.Size(326, 306);
            this.tileView1.TileColumns.Add(tableColumnDefinition1);
            tableRowDefinition1.Length.Value = 38D;
            tableRowDefinition2.Length.Value = 42D;
            tableRowDefinition3.Length.Value = 42D;
            tableRowDefinition4.Length.Value = 168D;
            this.tileView1.TileRows.Add(tableRowDefinition1);
            this.tileView1.TileRows.Add(tableRowDefinition2);
            this.tileView1.TileRows.Add(tableRowDefinition3);
            this.tileView1.TileRows.Add(tableRowDefinition4);
            tileViewItemElement1.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tileViewItemElement1.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement1.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement1.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement1.Text = "colsupp_name";
            tileViewItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement2.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tileViewItemElement2.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement2.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement2.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement2.RowIndex = 1;
            tileViewItemElement2.Text = "colsupp_phone";
            tileViewItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement3.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tileViewItemElement3.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement3.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement3.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement3.RowIndex = 2;
            tileViewItemElement3.Text = "colsupp_email";
            tileViewItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement4.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement4.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement4.RowIndex = 3;
            tileViewItemElement4.Text = "colsupp_image";
            tileViewItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.tileView1.TileTemplate.Add(tileViewItemElement1);
            this.tileView1.TileTemplate.Add(tileViewItemElement2);
            this.tileView1.TileTemplate.Add(tileViewItemElement3);
            this.tileView1.TileTemplate.Add(tileViewItemElement4);
            // 
            // cardView1
            // 
            this.cardView1.GridControl = this.gridControl1;
            this.cardView1.Name = "cardView1";
            // 
            // colsupp_image
            // 
            this.colsupp_image.FieldName = "supp_image";
            this.colsupp_image.Name = "colsupp_image";
            this.colsupp_image.Visible = true;
            this.colsupp_image.VisibleIndex = 2;
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            this.colid.Visible = true;
            this.colid.VisibleIndex = 0;
            // 
            // colsupp_name
            // 
            this.colsupp_name.FieldName = "supp_name";
            this.colsupp_name.Name = "colsupp_name";
            this.colsupp_name.Visible = true;
            this.colsupp_name.VisibleIndex = 3;
            // 
            // colsupp_phone
            // 
            this.colsupp_phone.FieldName = "supp_phone";
            this.colsupp_phone.Name = "colsupp_phone";
            this.colsupp_phone.Visible = true;
            this.colsupp_phone.VisibleIndex = 4;
            // 
            // colsupp_email
            // 
            this.colsupp_email.FieldName = "supp_email";
            this.colsupp_email.Name = "colsupp_email";
            this.colsupp_email.Visible = true;
            this.colsupp_email.VisibleIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Attendanceemp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1030, 720);
            this.Controls.Add(this.pn_cat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Attendanceemp";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RightToLeftLayout = true;
            this.Text = "frm_cat";
            this.Load += new System.EventHandler(this.frm_cashbox_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.pn_cat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DateTimePicker edt_day_serch;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btn_delete;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        public System.Windows.Forms.DateTimePicker edt_dateserc;
        private DevExpress.XtraEditors.SimpleButton btn_leave;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btn_absent;
        private System.Windows.Forms.Label edt_date;
        public System.Windows.Forms.ComboBox edt_employee;
        private DevExpress.XtraEditors.SimpleButton btn_updata;
        private DevExpress.XtraEditors.SimpleButton btn_in;
        public System.Windows.Forms.Panel pn_cat;
        public DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colsafe_name;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Views.Tile.TileView tileView1;
        private DevExpress.XtraGrid.Views.Card.CardView cardView1;
        private DevExpress.XtraGrid.Columns.TileViewColumn colsupp_image;
        private DevExpress.XtraGrid.Columns.TileViewColumn colid;
        private DevExpress.XtraGrid.Columns.TileViewColumn colsupp_name;
        private DevExpress.XtraGrid.Columns.TileViewColumn colsupp_phone;
        private DevExpress.XtraGrid.Columns.TileViewColumn colsupp_email;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btn_connect_device;
        private System.Windows.Forms.Label lbl_device_status;
        private DevExpress.XtraEditors.SimpleButton btn_fetch_device;
        public DevExpress.XtraEditors.SimpleButton btn_close;
        public DevExpress.XtraEditors.SimpleButton btn_open;
    }
}