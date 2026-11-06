
namespace el_shabander.pl
{
    partial class frm_booking
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
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition1 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition1 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition2 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition3 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition4 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement1 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement2 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement3 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement4 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_booking));
            this.pn_cat = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colsafe_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsafe_count = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cardView1 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.tileView1 = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_delete = new DevExpress.XtraEditors.SimpleButton();
            this.btn_edit = new DevExpress.XtraEditors.SimpleButton();
            this.whats = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label2 = new System.Windows.Forms.Label();
            this.edt_from2 = new System.Windows.Forms.DateTimePicker();
            this.txt_cusname = new System.Windows.Forms.TextBox();
            this.txt_phone = new System.Windows.Forms.TextBox();
            this.btn_skip_Click = new DevExpress.XtraEditors.SimpleButton();
            this.txt_notes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_add_booking = new DevExpress.XtraEditors.SimpleButton();
            this.ملاحظة = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.edt_from = new System.Windows.Forms.DateTimePicker();
            this.time = new System.Windows.Forms.Label();
            this.lbl_next = new System.Windows.Forms.Label();
            this.lbl_count = new System.Windows.Forms.Label();
            this.btn_refresh = new DevExpress.XtraEditors.SimpleButton();
            this.colid = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colsupp_name = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colsupp_phone = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colsupp_email = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colsupp_image = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pn_cat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
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
            this.pn_cat.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = typeof(el_shabander.tb_booking);
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControl1.Size = new System.Drawing.Size(1030, 434);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.cardView1,
            this.tileView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
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
            this.colsafe_count,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView1_RowStyle);
            // 
            // colsafe_name
            // 
            this.colsafe_name.AppearanceHeader.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold);
            this.colsafe_name.AppearanceHeader.Options.UseFont = true;
            this.colsafe_name.Caption = "رقم_الدور";
            this.colsafe_name.FieldName = "queue_number";
            this.colsafe_name.Name = "colsafe_name";
            this.colsafe_name.Visible = true;
            this.colsafe_name.VisibleIndex = 0;
            this.colsafe_name.Width = 116;
            // 
            // colsafe_count
            // 
            this.colsafe_count.AppearanceHeader.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold);
            this.colsafe_count.AppearanceHeader.Options.UseFont = true;
            this.colsafe_count.Caption = "اسم_العميل";
            this.colsafe_count.FieldName = "cus_name";
            this.colsafe_count.Name = "colsafe_count";
            this.colsafe_count.Visible = true;
            this.colsafe_count.VisibleIndex = 1;
            this.colsafe_count.Width = 302;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "الهاتف ";
            this.gridColumn1.FieldName = "cus_phone";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            this.gridColumn1.Width = 186;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "الحالة";
            this.gridColumn2.FieldName = "status";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 106;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "ملاحظات";
            this.gridColumn3.FieldName = "notes";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 231;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "تاريخ الحجز";
            this.gridColumn4.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm tt";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn4.FieldName = "booking_date";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 160;
            // 
            // cardView1
            // 
            this.cardView1.GridControl = this.gridControl1;
            this.cardView1.Name = "cardView1";
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_delete);
            this.panel1.Controls.Add(this.btn_edit);
            this.panel1.Controls.Add(this.whats);
            this.panel1.Controls.Add(this.groupControl1);
            this.panel1.Controls.Add(this.groupControl2);
            this.panel1.Controls.Add(this.btn_refresh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 434);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1030, 286);
            this.panel1.TabIndex = 2;
            // 
            // btn_delete
            // 
            this.btn_delete.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_delete.Appearance.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.Appearance.Options.UseFont = true;
            this.btn_delete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_delete.ImageOptions.Image")));
            this.btn_delete.Location = new System.Drawing.Point(425, 236);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(126, 43);
            this.btn_delete.TabIndex = 87;
            this.btn_delete.Text = "حذف";
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_edit.Appearance.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.Appearance.Options.UseFont = true;
            this.btn_edit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_edit.ImageOptions.Image")));
            this.btn_edit.Location = new System.Drawing.Point(425, 159);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(126, 43);
            this.btn_edit.TabIndex = 86;
            this.btn_edit.Text = "تعديل";
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // whats
            // 
            this.whats.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.whats.Appearance.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.whats.Appearance.Options.UseFont = true;
            this.whats.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("whats.ImageOptions.Image")));
            this.whats.Location = new System.Drawing.Point(425, 82);
            this.whats.Name = "whats";
            this.whats.Size = new System.Drawing.Size(126, 43);
            this.whats.TabIndex = 85;
            this.whats.Text = "واتساب";
            this.whats.Click += new System.EventHandler(this.whats_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControl1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.groupControl1.Appearance.BorderColor = System.Drawing.Color.Orange;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Appearance.Options.UseBorderColor = true;
            this.groupControl1.AppearanceCaption.BackColor = System.Drawing.Color.White;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupControl1.AppearanceCaption.Options.UseBackColor = true;
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl1.AppearanceCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.edt_from2);
            this.groupControl1.Controls.Add(this.txt_cusname);
            this.groupControl1.Controls.Add(this.txt_phone);
            this.groupControl1.Controls.Add(this.btn_skip_Click);
            this.groupControl1.Controls.Add(this.txt_notes);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.btn_add_booking);
            this.groupControl1.Controls.Add(this.ملاحظة);
            this.groupControl1.Controls.Add(this.label18);
            this.groupControl1.Location = new System.Drawing.Point(557, 5);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Padding = new System.Windows.Forms.Padding(4);
            this.groupControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupControl1.Size = new System.Drawing.Size(460, 277);
            this.groupControl1.TabIndex = 84;
            this.groupControl1.Text = "اضافة حجز";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(340, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 39);
            this.label2.TabIndex = 137;
            this.label2.Text = "تاريخ الحجز";
            // 
            // edt_from2
            // 
            this.edt_from2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.edt_from2.CalendarFont = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_from2.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_from2.Location = new System.Drawing.Point(9, 179);
            this.edt_from2.Name = "edt_from2";
            this.edt_from2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.edt_from2.Size = new System.Drawing.Size(310, 37);
            this.edt_from2.TabIndex = 136;
            // 
            // txt_cusname
            // 
            this.txt_cusname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_cusname.BackColor = System.Drawing.Color.DimGray;
            this.txt_cusname.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cusname.ForeColor = System.Drawing.Color.Red;
            this.txt_cusname.Location = new System.Drawing.Point(9, 37);
            this.txt_cusname.Name = "txt_cusname";
            this.txt_cusname.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_cusname.Size = new System.Drawing.Size(310, 31);
            this.txt_cusname.TabIndex = 72;
            this.txt_cusname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_phone
            // 
            this.txt_phone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_phone.BackColor = System.Drawing.Color.Gold;
            this.txt_phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_phone.ForeColor = System.Drawing.Color.Black;
            this.txt_phone.Location = new System.Drawing.Point(9, 71);
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_phone.Size = new System.Drawing.Size(310, 31);
            this.txt_phone.TabIndex = 75;
            this.txt_phone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_skip_Click
            // 
            this.btn_skip_Click.Appearance.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_skip_Click.Appearance.Options.UseFont = true;
            this.btn_skip_Click.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_skip_Click.ImageOptions.Image")));
            this.btn_skip_Click.Location = new System.Drawing.Point(9, 228);
            this.btn_skip_Click.Name = "btn_skip_Click";
            this.btn_skip_Click.Size = new System.Drawing.Size(213, 43);
            this.btn_skip_Click.TabIndex = 80;
            this.btn_skip_Click.Text = "الغاء الحجز";
            this.btn_skip_Click.Click += new System.EventHandler(this.btn_skip_Click_Click);
            // 
            // txt_notes
            // 
            this.txt_notes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_notes.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txt_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_notes.ForeColor = System.Drawing.Color.Black;
            this.txt_notes.Location = new System.Drawing.Point(9, 105);
            this.txt_notes.Multiline = true;
            this.txt_notes.Name = "txt_notes";
            this.txt_notes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_notes.Size = new System.Drawing.Size(310, 68);
            this.txt_notes.TabIndex = 77;
            this.txt_notes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(328, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 39);
            this.label1.TabIndex = 76;
            this.label1.Text = "رقم الهاتف";
            // 
            // btn_add_booking
            // 
            this.btn_add_booking.Appearance.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add_booking.Appearance.Options.UseFont = true;
            this.btn_add_booking.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_add_booking.ImageOptions.Image")));
            this.btn_add_booking.Location = new System.Drawing.Point(234, 228);
            this.btn_add_booking.Name = "btn_add_booking";
            this.btn_add_booking.Size = new System.Drawing.Size(213, 43);
            this.btn_add_booking.TabIndex = 74;
            this.btn_add_booking.Text = "اضافة";
            this.btn_add_booking.Click += new System.EventHandler(this.btn_add_booking_Click);
            // 
            // ملاحظة
            // 
            this.ملاحظة.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ملاحظة.AutoSize = true;
            this.ملاحظة.BackColor = System.Drawing.Color.Transparent;
            this.ملاحظة.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ملاحظة.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ملاحظة.Location = new System.Drawing.Point(346, 119);
            this.ملاحظة.Name = "ملاحظة";
            this.ملاحظة.Size = new System.Drawing.Size(88, 39);
            this.ملاحظة.TabIndex = 78;
            this.ملاحظة.Text = "ملاحظة";
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label18.Location = new System.Drawing.Point(327, 30);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(127, 39);
            this.label18.TabIndex = 73;
            this.label18.Text = "اسم العميل";
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupControl2.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControl2.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.groupControl2.Appearance.BorderColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.groupControl2.Appearance.Options.UseBackColor = true;
            this.groupControl2.Appearance.Options.UseBorderColor = true;
            this.groupControl2.AppearanceCaption.BackColor = System.Drawing.Color.White;
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl2.AppearanceCaption.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.groupControl2.AppearanceCaption.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupControl2.AppearanceCaption.Options.UseBackColor = true;
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl2.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl2.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl2.AppearanceCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.groupControl2.Controls.Add(this.simpleButton1);
            this.groupControl2.Controls.Add(this.edt_from);
            this.groupControl2.Controls.Add(this.time);
            this.groupControl2.Controls.Add(this.lbl_next);
            this.groupControl2.Controls.Add(this.lbl_count);
            this.groupControl2.Location = new System.Drawing.Point(3, 5);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Padding = new System.Windows.Forms.Padding(4);
            this.groupControl2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupControl2.Size = new System.Drawing.Size(416, 277);
            this.groupControl2.TabIndex = 83;
            this.groupControl2.Text = "الانتظار";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(129, 228);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(158, 43);
            this.simpleButton1.TabIndex = 134;
            this.simpleButton1.Text = "بحث بالتاريخ";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // edt_from
            // 
            this.edt_from.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.edt_from.CalendarFont = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_from.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_from.Location = new System.Drawing.Point(9, 185);
            this.edt_from.Name = "edt_from";
            this.edt_from.Size = new System.Drawing.Size(398, 37);
            this.edt_from.TabIndex = 135;
            // 
            // time
            // 
            this.time.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.time.BackColor = System.Drawing.Color.Transparent;
            this.time.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time.Location = new System.Drawing.Point(9, 32);
            this.time.Name = "time";
            this.time.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.time.Size = new System.Drawing.Size(398, 42);
            this.time.TabIndex = 85;
            this.time.Text = "label1";
            this.time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_next
            // 
            this.lbl_next.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_next.BackColor = System.Drawing.Color.White;
            this.lbl_next.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_next.Font = new System.Drawing.Font("Cairo", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_next.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbl_next.Location = new System.Drawing.Point(9, 124);
            this.lbl_next.Name = "lbl_next";
            this.lbl_next.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_next.Size = new System.Drawing.Size(398, 58);
            this.lbl_next.TabIndex = 84;
            this.lbl_next.Text = "0";
            this.lbl_next.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_next.UseMnemonic = false;
            this.lbl_next.UseWaitCursor = true;
            // 
            // lbl_count
            // 
            this.lbl_count.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_count.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_count.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_count.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_count.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbl_count.Location = new System.Drawing.Point(9, 80);
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_count.Size = new System.Drawing.Size(398, 38);
            this.lbl_count.TabIndex = 83;
            this.lbl_count.Text = "0";
            this.lbl_count.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_count.UseMnemonic = false;
            this.lbl_count.UseWaitCursor = true;
            // 
            // btn_refresh
            // 
            this.btn_refresh.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_refresh.Appearance.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_refresh.Appearance.Options.UseFont = true;
            this.btn_refresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_refresh.ImageOptions.Image")));
            this.btn_refresh.Location = new System.Drawing.Point(425, 5);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(126, 43);
            this.btn_refresh.TabIndex = 79;
            this.btn_refresh.Text = "تحديث";
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
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
            // colsupp_image
            // 
            this.colsupp_image.FieldName = "supp_image";
            this.colsupp_image.Name = "colsupp_image";
            this.colsupp_image.Visible = true;
            this.colsupp_image.VisibleIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frm_booking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1030, 720);
            this.Controls.Add(this.pn_cat);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_booking";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.frm_safe_as_Activated);
            this.Load += new System.EventHandler(this.frm_safe_as_Load);
            this.pn_cat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pn_cat;
        private System.Windows.Forms.Panel panel1;
        public DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Card.CardView cardView1;
        private DevExpress.XtraGrid.Views.Tile.TileView tileView1;
        private DevExpress.XtraGrid.Columns.TileViewColumn colid;
        private DevExpress.XtraGrid.Columns.TileViewColumn colsupp_name;
        private DevExpress.XtraGrid.Columns.TileViewColumn colsupp_phone;
        private DevExpress.XtraGrid.Columns.TileViewColumn colsupp_email;
        private DevExpress.XtraGrid.Columns.TileViewColumn colsupp_image;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colsafe_name;
        private DevExpress.XtraGrid.Columns.GridColumn colsafe_count;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        public System.Windows.Forms.TextBox txt_cusname;
        private System.Windows.Forms.Label label18;
        public DevExpress.XtraEditors.SimpleButton btn_add_booking;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txt_phone;
        private System.Windows.Forms.Label ملاحظة;
        public System.Windows.Forms.TextBox txt_notes;
        public DevExpress.XtraEditors.SimpleButton btn_skip_Click;
        public DevExpress.XtraEditors.SimpleButton btn_refresh;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        public System.Windows.Forms.Label lbl_next;
        public System.Windows.Forms.Label lbl_count;
        private System.Windows.Forms.Label time;
        public System.Windows.Forms.DateTimePicker edt_from;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DateTimePicker edt_from2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        public DevExpress.XtraEditors.SimpleButton whats;
        public DevExpress.XtraEditors.SimpleButton btn_delete;
        public DevExpress.XtraEditors.SimpleButton btn_edit;
    }
}