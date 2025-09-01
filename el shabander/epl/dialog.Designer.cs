
namespace el_shabander.epl
{
    partial class dialog
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txt_capthion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txt_capthion
            // 
            this.txt_capthion.BackColor = System.Drawing.Color.DarkRed;
            this.txt_capthion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_capthion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_capthion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.txt_capthion.Font = new System.Drawing.Font("Cairo", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_capthion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_capthion.Location = new System.Drawing.Point(0, 0);
            this.txt_capthion.Name = "txt_capthion";
            this.txt_capthion.Size = new System.Drawing.Size(800, 115);
            this.txt_capthion.TabIndex = 9;
            this.txt_capthion.Text = "الرسالة";
            this.txt_capthion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txt_capthion.Click += new System.EventHandler(this.txt_capthion_Click);
            // 
            // dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 115);
            this.Controls.Add(this.txt_capthion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "dialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "dialog";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label txt_capthion;
    }
}