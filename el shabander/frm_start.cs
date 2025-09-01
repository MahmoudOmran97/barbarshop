using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
namespace el_shabander
{
    public partial class frm_start : SplashScreen
    {
        DB_restoraintEntities db = new DB_restoraintEntities();
        tb_user tb_User = new tb_user();
        main main = new main();
        pl.frm_login login = new pl.frm_login();
        bl.methods methods = new bl.methods();
        public frm_start()
        {
            InitializeComponent();
            this.labelCopyright.Text = "Copyright © 2024-" + DateTime.Now.Year.ToString();
        }

        #region Overrides

       

        #endregion

        public enum SplashScreenCommand
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           /* tb_User = db.tb_user.Where(x => x.user_state == "مفتوح").FirstOrDefault();
            if (tb_User != null)
            {

                MessageBox.Show("");
                *//* main.la_username.Text = tb_User.user_name;
                 main.la_roll.Text = tb_User.user_roll;
                 methods.by = tb_User.user_image;
                 main.pic_cover.Image = Image.FromStream(methods.convert_image());
                 main.Show();*//*

            }
            else
            {*/
                login.Show();
           // }
            this.Hide();
            timer1.Enabled = false;
        }

        private void frm_start_Activated(object sender, EventArgs e)
        {
            
        }
    }
}