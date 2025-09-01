using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using el_shabander.epl;

namespace el_shabander.pl
{
    public partial class frm_stuk_add: Form
    {
        DB_elshEntities db = new DB_elshEntities();
       // tb_supp tB_supp = new tb_supp();
        tb_stuk tb_stuk = new tb_stuk();
        bl.methods methods = new bl.methods();
        
        double buy, qt,tbuy ;
        //pl.frm_supp frm_Cat = new frm_supp();
        public int id;
        public frm_stuk_add ()

        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            toast toast = new toast();
            dialog dialog = new dialog();
            if (edt_name.Text=="")
            {
               dialog.Width = this.Width;
                dialog.txt_capthion.Text = "  اسم المورد مطلوب";
                dialog.Show();
            }else
            {
                if(id==0)
                {
                    tb_stuk.stuk_name = edt_name.Text;
                    tb_stuk.stuk_type = edt_tybe.Text;
                    tb_stuk.stuk_cat = edt_cat.Text;
                    tb_stuk.stuk_supp = edt_supp.Text;
                    // tb_Pur.pur_det = edt_det.Text;
                    tb_stuk.stuk_buy = Convert.ToDouble(edt_buy.Text);
                  //  tb_Pur.pur_sell = Convert.ToDouble(edt_sell.Text);
                   tb_stuk.stuk_qt = Convert.ToDouble(edt_qt.Text);
                    tb_stuk.stuk_tbuy = Convert.ToDouble(txt_tbuy.Text);
                    tb_stuk.stuk_qtfact = 0;
                    tb_stuk.stuk_qtfacttotal = 0;
                    // tb_Pur.pur_tsell = Convert.ToDouble(edt_tsell.Text);
                    // tb_Pur.pur_trev = Convert.ToDouble(edt_trev.Text);
                    db.tb_stuk.Add(tb_stuk);
                    db.SaveChanges();
                    toast.Width = this.Width;
                    toast.txt_caption.Text = "تم اجراء عملية الشراء";
                    toast.Show();
                    this.Close();

                }
                else
                {
                    tb_stuk.id = id;
                    tb_stuk.stuk_name = edt_name.Text;
                    tb_stuk.stuk_type = edt_tybe.Text;
                    tb_stuk.stuk_cat = edt_cat.Text;
                    tb_stuk.stuk_supp = edt_supp.Text;
                    // tb_Pur.pur_det = edt_det.Text;
                    tb_stuk.stuk_qtfact = tb_stuk.stuk_qtfact;
                    tb_stuk.stuk_qtfacttotal = tb_stuk.stuk_qtfacttotal;

                  //  tb_stuk.stuk_buy = Convert.ToDouble(edt_buy.Text);
                    //  tb_Pur.pur_sell = Convert.ToDouble(edt_sell.Text);
                    tb_stuk.stuk_qt += Convert.ToDouble(edt_qt.Text);
                   // tb_stuk.stuk_tbuy = Convert.ToDouble(txt_tbuy.Text);
                    // tb_Pur.pur_tsell = Convert.ToDouble(edt_tsell.Text);
                    // tb_Pur.pur_trev = Convert.ToDouble(edt_trev.Text);
                   // db.tb_stuk.Add(tb_stuk);
                    //db.tb_stuk.Add(tb_stuk);
                    db.Entry(tb_stuk).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    toast.Width = this.Width;
                    toast.txt_caption.Text = "تم اجراء عملية الشراء";
                    toast.Show();
                    this.Close();
                }
            }
        }

        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void edt_buy_TextChanged(object sender, EventArgs e)
        {
            pro_call();
        }

        

        private void edt_qt_EditValueChanged(object sender, EventArgs e)
        {
            pro_call();
        }
        private void frm_pur_add_Load(object sender, EventArgs e)
        {

        }

        private void frm_pur_add_Activated(object sender, EventArgs e)
        {
            edt_cat.DataSource = db.TB_cat.Select(x => x.cat_name).ToList();
            edt_supp.DataSource = db.tb_supp.Select(x => x.supp_name).ToList();
        }

       

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pl.frm_cat_add frm_Cat_Add = new frm_cat_add();
            frm_Cat_Add.id = 0;
            frm_Cat_Add.btn_add.Text = "اضافة";
            frm_Cat_Add.Show();
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pl.frm_supp_add frm_supp_Add = new frm_supp_add();
            frm_supp_Add.id = 0;
            frm_supp_Add.btn_add.Text = "اضافة";
            frm_supp_Add.Show();
        }
        private void pro_call()
        {
            /* sell = Convert.ToDouble(edt_sell.Text);
           
             tsell = sell * qt;

             trev = tsell - tbuy;
             edt_tsell.Text = tsell.ToString();
             
             edt_trev.Text = trev.ToString();*/
            buy = Convert.ToDouble(edt_buy.Text);
            qt = Convert.ToDouble(edt_qt.Text);
            tbuy = buy * qt;
            txt_tbuy.Text = tbuy.ToString();

        }
    }
}
