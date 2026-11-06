using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace el_shabander.pl
{
    public partial class frm_home : Form
    {
        DB_BarbershopEntities db = new DB_BarbershopEntities();
        pl.frm_report frm_report = new pl.frm_report();
        public frm_home()
        {
            InitializeComponent();


           

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       

      

       

        

      

       

        private void frm_home_Activated(object sender, EventArgs e)
        {
            //lb_cat.Text = list_cat.Count.ToString();
           

        }

        private void frm_home_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void tileItem1_ItemDoubleClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (tileItem1.CurrentFrameIndex == 0)
            {
                // إذا كان الفريم الأول هو المعروض، ننفذ هذا الكود
                pl.frm_supp_add frm_supp_Add = new frm_supp_add();
                frm_supp_Add.id = 0;
                frm_supp_Add.btn_add.Text = "اضافة";
                frm_supp_Add.Show();
            }
            else if (tileItem1.CurrentFrameIndex == 1)
            {
                // إذا كان الفريم الثاني هو المعروض، ننفذ هذا الكود
                pl.frm_employees_add frm_cus_Add = new frm_employees_add();
                frm_cus_Add.id = 0;
                frm_cus_Add.btn_add.Text = "اضافة";
                frm_cus_Add.Show();
            }
            else
            {
                // في حالة الفريمات الأخرى
                pl.frm_cus_addtakeway frm_cus_Add = new frm_cus_addtakeway();
                frm_cus_Add.id = 0;
                frm_cus_Add.btn_add.Text = "اضافة";
                frm_cus_Add.Show();
            }
        }

        private void tileItem2_ItemDoubleClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (tileItem2.CurrentFrameIndex == 2)
            {
                pl.frm_cus_addtakeway frm_supp_Add = new frm_cus_addtakeway();
                frm_supp_Add.id = 0;
                frm_supp_Add.btn_add.Text = "اضافة";
                frm_supp_Add.Show();
            }
            else if (tileItem2.CurrentFrameIndex == 3)
            {
                // إذا كان الفريم الأول هو المعروض، ننفذ هذا الكود
                pl.frm_cat_add frm_Cat_Add = new frm_cat_add();
                frm_Cat_Add.id = 0;
                frm_Cat_Add.btn_add.Text = "اضافة";
                frm_Cat_Add.Show();
            }
            else if (tileItem2.CurrentFrameIndex == 0)
            {
                // إذا كان الفريم الأول هو المعروض، ننفذ هذا الكود
                pl.frm_cus_add frm_Cat_Add = new frm_cus_add();
                frm_Cat_Add.id = 0;
                frm_Cat_Add.btn_add.Text = "اضافة";
                frm_Cat_Add.Show();
            }
            else
            {
                main user = (main)Application.OpenForms["main"];
                string casherName = user?.la_username.Text;
                var openSession = db.Sessions.FirstOrDefault(x => x.namecasher == casherName && x.IsClosed == true);
                if (openSession == null)
                {
                    MessageBox.Show("يرجى فتح الكاش بوكس أولاً");
                    return;
                }
                pl.frm_pur_add frm_supp_Add = new frm_pur_add();
                frm_supp_Add.id = 0;
                frm_supp_Add.btn_add.Text = "اضافة";
                frm_supp_Add.Show();
            }
        }

        private void tileItem10_ItemDoubleClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (tileItem10.CurrentFrameIndex == 1)
            {
                // إذا كان الفريم الأول هو المعروض، ننفذ هذا الكود
                pl.frm_supp_add frm_supp_Add = new frm_supp_add();
                frm_supp_Add.id = 0;
                frm_supp_Add.btn_add.Text = "اضافة";
                frm_supp_Add.Show();
            }
            else if (tileItem10.CurrentFrameIndex == 2)
            {
                // إذا كان الفريم الثاني هو المعروض، ننفذ هذا الكود
                pl.frm_employees_add frm_cus_Add = new frm_employees_add();
                frm_cus_Add.id = 0;
                frm_cus_Add.btn_add.Text = "اضافة";
                frm_cus_Add.Show();
            }
            else
            {
                // في حالة الفريمات الأخرى
                pl.frm_cus_addtakeway frm_cus_Add = new frm_cus_addtakeway();
                frm_cus_Add.id = 0;
                frm_cus_Add.btn_add.Text = "اضافة";
                frm_cus_Add.Show();
            }
        }

        private void tileItem4_ItemDoubleClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (tileItem2.CurrentFrameIndex == 3)
            {
                pl.frm_cus_addtakeway frm_supp_Add = new frm_cus_addtakeway();
                frm_supp_Add.id = 0;
                frm_supp_Add.btn_add.Text = "اضافة";
                frm_supp_Add.Show();
            }
            else if (tileItem2.CurrentFrameIndex == 0)
            {
                // إذا كان الفريم الأول هو المعروض، ننفذ هذا الكود
                pl.frm_cat_add frm_Cat_Add = new frm_cat_add();
                frm_Cat_Add.id = 0;
                frm_Cat_Add.btn_add.Text = "اضافة";
                frm_Cat_Add.Show();
            }
            else if (tileItem2.CurrentFrameIndex == 1)
            {
                // إذا كان الفريم الأول هو المعروض، ننفذ هذا الكود
                pl.frm_cus_add frm_Cat_Add = new frm_cus_add();
                frm_Cat_Add.id = 0;
                frm_Cat_Add.btn_add.Text = "اضافة";
                frm_Cat_Add.Show();
            }
            else
            {
                main user = (main)Application.OpenForms["main"];
                string casherName = user?.la_username.Text;
                var openSession = db.Sessions.FirstOrDefault(x => x.namecasher == casherName && x.IsClosed == true);
                if (openSession == null)
                {
                    MessageBox.Show("يرجى فتح الكاش بوكس أولاً");
                    return;
                }
                pl.frm_pur_add frm_supp_Add = new frm_pur_add();
                frm_supp_Add.id = 0;
                frm_supp_Add.btn_add.Text = "اضافة";
                frm_supp_Add.Show();
            }
        }

        private void tileItem6_ItemDoubleClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (tileItem2.CurrentFrameIndex == 3)
            {
                pl.frm_cus_addtakeway frm_supp_Add = new frm_cus_addtakeway();
                frm_supp_Add.id = 0;
                frm_supp_Add.btn_add.Text = "اضافة";
                frm_supp_Add.Show();
            }
            else if (tileItem2.CurrentFrameIndex ==1)
            {
                // إذا كان الفريم الأول هو المعروض، ننفذ هذا الكود
                pl.frm_cat_add frm_Cat_Add = new frm_cat_add();
                frm_Cat_Add.id = 0;
                frm_Cat_Add.btn_add.Text = "اضافة";
                frm_Cat_Add.Show();
            }
            else if (tileItem2.CurrentFrameIndex ==0)
            {
                // إذا كان الفريم الأول هو المعروض، ننفذ هذا الكود
                pl.frm_cus_add frm_Cat_Add = new frm_cus_add();
                frm_Cat_Add.id = 0;
                frm_Cat_Add.btn_add.Text = "اضافة";
                frm_Cat_Add.Show();
            }
            else
            {
                main user = (main)Application.OpenForms["main"];
                string casherName = user?.la_username.Text;
                var openSession = db.Sessions.FirstOrDefault(x => x.namecasher == casherName && x.IsClosed == true);
                if (openSession == null)
                {
                    MessageBox.Show("يرجى فتح الكاش بوكس أولاً");
                    return;
                }
                pl.frm_pur_add frm_supp_Add = new frm_pur_add();
                frm_supp_Add.id = 0;
                frm_supp_Add.btn_add.Text = "اضافة";
                frm_supp_Add.Show();
            }
        }

        private void tileItem7_ItemDoubleClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (tileItem7.CurrentFrameIndex == 1)
            {
                // إذا كان الفريم الأول هو المعروض، ننفذ هذا الكود
                pl.frm_supp_add frm_supp_Add = new frm_supp_add();
                frm_supp_Add.id = 0;
                frm_supp_Add.btn_add.Text = "اضافة";
                frm_supp_Add.Show();
            }
            else if (tileItem7.CurrentFrameIndex == 0)
            {
                // إذا كان الفريم الثاني هو المعروض، ننفذ هذا الكود
                pl.frm_employees_add frm_cus_Add = new frm_employees_add();
                frm_cus_Add.id = 0;
                frm_cus_Add.btn_add.Text = "اضافة";
                frm_cus_Add.Show();
            }
            else
            {
                // في حالة الفريمات الأخرى
                pl.frm_cus_addtakeway frm_cus_Add = new frm_cus_addtakeway();
                frm_cus_Add.id = 0;
                frm_cus_Add.btn_add.Text = "اضافة";
                frm_cus_Add.Show();
            }
        }

        private void tileItem8_ItemDoubleClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (tileItem8.CurrentFrameIndex == 1)
            {
                main user = (main)Application.OpenForms["main"];
                string casherName = user?.la_username.Text;
                var openSession = db.Sessions.FirstOrDefault(x => x.namecasher == casherName && x.IsClosed == true);
                if (openSession == null)
                {
                    MessageBox.Show("يرجى فتح الكاش بوكس أولاً");
                    return;
                }
                pl.frm_stor_add frm_supp_Add = new frm_stor_add();
                frm_supp_Add.id = 0;
                frm_supp_Add.btn_add.Text = "اضافة";
                frm_supp_Add.Show();
            }
            else
            {
                main frm_supp_Add = (main)Application.OpenForms["main"];
                frm_supp_Add.pn_cont.Controls.Clear();
                frm_supp_Add.pn_cont.Controls.Add(frm_report.tileControl1);


                frm_supp_Add.lb_titelpage.Text = "التقارير";
            }
        }

        private void tileItem9_ItemDoubleClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (tileItem9.CurrentFrameIndex == 0)
            {
                main user = (main)Application.OpenForms["main"];
                string casherName = user?.la_username.Text;
                var openSession = db.Sessions.FirstOrDefault(x => x.namecasher == casherName && x.IsClosed == true);
                if (openSession == null)
                {
                    MessageBox.Show("يرجى فتح الكاش بوكس أولاً");
                    return;
                }
                pl.frm_stor_add frm_supp_Add = new frm_stor_add();
                frm_supp_Add.id = 0;
                frm_supp_Add.btn_add.Text = "اضافة";
                frm_supp_Add.Show();
            }
            else
            {
                main frm_supp_Add = (main)Application.OpenForms["main"];
                frm_supp_Add.pn_cont.Controls.Clear();
                frm_supp_Add.pn_cont.Controls.Add(frm_report.tileControl1);


                frm_supp_Add.lb_titelpage.Text = "التقارير";
            }
        }
    }
}
