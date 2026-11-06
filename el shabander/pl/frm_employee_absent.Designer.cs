
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
            this.panel_status = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CheckOut = new System.Windows.Forms.TextBox();
            this.CheckIn = new System.Windows.Forms.TextBox();
            this.AttendDate = new System.Windows.Forms.TextBox();
            this.OvertimeHours = new System.Windows.Forms.TextBox();
            this.WorkedHours = new System.Windows.Forms.TextBox();
            this.Status = new System.Windows.Forms.TextBox();
            this.NameEmployee = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_titelpage = new System.Windows.Forms.Label();
            this.panel_status.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_status
            // 
            this.panel_status.BackColor = System.Drawing.Color.Gray;
            this.panel_status.Controls.Add(this.label7);
            this.panel_status.Controls.Add(this.label6);
            this.panel_status.Controls.Add(this.label5);
            this.panel_status.Controls.Add(this.CheckOut);
            this.panel_status.Controls.Add(this.CheckIn);
            this.panel_status.Controls.Add(this.AttendDate);
            this.panel_status.Controls.Add(this.OvertimeHours);
            this.panel_status.Controls.Add(this.WorkedHours);
            this.panel_status.Controls.Add(this.Status);
            this.panel_status.Controls.Add(this.NameEmployee);
            this.panel_status.Controls.Add(this.label1);
            this.panel_status.Controls.Add(this.label4);
            this.panel_status.Controls.Add(this.label3);
            this.panel_status.Controls.Add(this.label2);
            this.panel_status.Controls.Add(this.lb_titelpage);
            this.panel_status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_status.Location = new System.Drawing.Point(0, 0);
            this.panel_status.Name = "panel_status";
            this.panel_status.Size = new System.Drawing.Size(703, 509);
            this.panel_status.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Cairo", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(430, 386);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(198, 60);
            this.label7.TabIndex = 71;
            this.label7.Text = "وقت الحضور";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Cairo", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(473, 326);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 60);
            this.label6.TabIndex = 70;
            this.label6.Text = "التاريخ";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Cairo", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(369, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(328, 60);
            this.label5.TabIndex = 69;
            this.label5.Text = "عدد الساعات الاضافية";
            // 
            // CheckOut
            // 
            this.CheckOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckOut.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.CheckOut.Enabled = false;
            this.CheckOut.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckOut.Location = new System.Drawing.Point(13, 457);
            this.CheckOut.Name = "CheckOut";
            this.CheckOut.ReadOnly = true;
            this.CheckOut.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CheckOut.Size = new System.Drawing.Size(357, 37);
            this.CheckOut.TabIndex = 68;
            this.CheckOut.Text = "0";
            this.CheckOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CheckIn
            // 
            this.CheckIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckIn.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.CheckIn.Enabled = false;
            this.CheckIn.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckIn.Location = new System.Drawing.Point(13, 397);
            this.CheckIn.Name = "CheckIn";
            this.CheckIn.ReadOnly = true;
            this.CheckIn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CheckIn.Size = new System.Drawing.Size(357, 37);
            this.CheckIn.TabIndex = 67;
            this.CheckIn.Text = "0";
            this.CheckIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AttendDate
            // 
            this.AttendDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AttendDate.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.AttendDate.Enabled = false;
            this.AttendDate.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AttendDate.Location = new System.Drawing.Point(13, 337);
            this.AttendDate.Name = "AttendDate";
            this.AttendDate.ReadOnly = true;
            this.AttendDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.AttendDate.Size = new System.Drawing.Size(357, 37);
            this.AttendDate.TabIndex = 66;
            this.AttendDate.Text = "0";
            this.AttendDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // OvertimeHours
            // 
            this.OvertimeHours.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OvertimeHours.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.OvertimeHours.Enabled = false;
            this.OvertimeHours.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OvertimeHours.Location = new System.Drawing.Point(13, 277);
            this.OvertimeHours.Name = "OvertimeHours";
            this.OvertimeHours.ReadOnly = true;
            this.OvertimeHours.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.OvertimeHours.Size = new System.Drawing.Size(357, 37);
            this.OvertimeHours.TabIndex = 65;
            this.OvertimeHours.Text = "0";
            this.OvertimeHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // WorkedHours
            // 
            this.WorkedHours.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.WorkedHours.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.WorkedHours.Enabled = false;
            this.WorkedHours.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WorkedHours.Location = new System.Drawing.Point(13, 217);
            this.WorkedHours.Name = "WorkedHours";
            this.WorkedHours.ReadOnly = true;
            this.WorkedHours.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.WorkedHours.Size = new System.Drawing.Size(357, 37);
            this.WorkedHours.TabIndex = 64;
            this.WorkedHours.Text = "0";
            this.WorkedHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Status
            // 
            this.Status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Status.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Status.Enabled = false;
            this.Status.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status.Location = new System.Drawing.Point(13, 157);
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Status.Size = new System.Drawing.Size(357, 37);
            this.Status.TabIndex = 63;
            this.Status.Text = "0";
            this.Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NameEmployee
            // 
            this.NameEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NameEmployee.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.NameEmployee.Enabled = false;
            this.NameEmployee.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameEmployee.Location = new System.Drawing.Point(13, 97);
            this.NameEmployee.Name = "NameEmployee";
            this.NameEmployee.ReadOnly = true;
            this.NameEmployee.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.NameEmployee.Size = new System.Drawing.Size(357, 37);
            this.NameEmployee.TabIndex = 62;
            this.NameEmployee.Text = "0";
            this.NameEmployee.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cairo", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(475, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 60);
            this.label1.TabIndex = 61;
            this.label1.Text = "الحالة";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Cairo", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(166, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(355, 90);
            this.label4.TabIndex = 60;
            this.label4.Text = "تفاصيل الحضور";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Cairo", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(418, 446);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(223, 60);
            this.label3.TabIndex = 59;
            this.label3.Text = "وقت الانصراف";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Cairo", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(392, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(274, 60);
            this.label2.TabIndex = 57;
            this.label2.Text = "عدد ساعات العمل";
            // 
            // lb_titelpage
            // 
            this.lb_titelpage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lb_titelpage.AutoSize = true;
            this.lb_titelpage.BackColor = System.Drawing.Color.Transparent;
            this.lb_titelpage.Font = new System.Drawing.Font("Cairo", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_titelpage.ForeColor = System.Drawing.Color.Black;
            this.lb_titelpage.Location = new System.Drawing.Point(421, 86);
            this.lb_titelpage.Name = "lb_titelpage";
            this.lb_titelpage.Size = new System.Drawing.Size(216, 60);
            this.lb_titelpage.TabIndex = 58;
            this.lb_titelpage.Text = "اسم الموظف";
            // 
            // frm_employee_absent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(703, 509);
            this.Controls.Add(this.panel_status);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_employee_absent";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.frm_stor_add_Activated);
            this.Load += new System.EventHandler(this.frm_stor_add_Load);
            this.panel_status.ResumeLayout(false);
            this.panel_status.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_status;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox CheckOut;
        public System.Windows.Forms.TextBox CheckIn;
        public System.Windows.Forms.TextBox AttendDate;
        public System.Windows.Forms.TextBox OvertimeHours;
        public System.Windows.Forms.TextBox WorkedHours;
        public System.Windows.Forms.TextBox Status;
        public System.Windows.Forms.TextBox NameEmployee;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_titelpage;
    }
}