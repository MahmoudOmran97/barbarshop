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
    public partial class frm_stor_addmanyedit : Form
    {
        DB_restoraintEntities db = new DB_restoraintEntities();
        tb_safe tb_Safe = new tb_safe();
        tb_movement tb_Movement = new tb_movement();
        bl.methods methods = new bl.methods();
        tb_employees tb_Employees = new tb_employees();
        bl.send send = new bl.send();
        Notfication notfication = new Notfication();
        double storadd, stortotal;
       // DateTime time;
        //pl.frm_supp frm_Cat = new frm_supp();
        public int id;
        public frm_stor_addmanyedit  ()

        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            toast toast = new toast();
            dialog dialog = new dialog();

            tb_Movement.save = edt_name.Text;
            tb_Movement.typemotion = edt_move.Text;
            tb_Movement.date =Convert.ToDateTime(date.Text);
            tb_Movement.mount = Convert.ToDouble(edt_add.Text);
            db.tb_movement.Add(tb_Movement);
            db.SaveChanges();
            tb_Safe.safe_count =Convert.ToDouble(edt_stay.Text);
               
                db.Entry(tb_Safe).State = System.Data.Entity.EntityState.Modified;
               
                db.SaveChanges();
            main frm_supp_Add = (main)Application.OpenForms["main"];

            string notificationMessage = $" تم اضافة عملية: {edt_move.Text} عن طريق : {frm_supp_Add.la_username.Text} المبلغ : {edt_add.Text}  التاريخ والوقت: {date.Text:yyyy/MM/dd hh:mm tt}.  ";

            send.SendEmailWithHtmlGridData(notificationMessage);
            notfication.notfication1 = notificationMessage;
            notfication.CreatedAt = DateTime.Now;


            db.Notfications.Add(notfication);
            db.SaveChanges();

            toast.Width = this.Width;
                toast.txt_caption.Text = "تم اضافة مبلغ للخزنة";
                toast.Show();
                this.Close();

           
               
            
        }

        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void edt_salery_TextChanged(object sender, EventArgs e)
        {
            /*if (string.IsNullOrWhiteSpace(date.Text))
            {
                // إذا كانت القيمة فارغة، يمكنك تعيين القيمة الافتراضية مرة أخرى
                date.Text = "0";
            }
            sumsaler();*/
        }

        private void edt_salerypay_TextChanged(object sender, EventArgs e)
        {
            sumsaler();
        }

        private void edt_salerystay_TextChanged(object sender, EventArgs e)
        {
            sumsaler();
        }

        private void frm_stor_add_Activated(object sender, EventArgs e)
        {
             var r1 = db.tb_safe.Select(x => x.safe_name).ToList();
             edt_name.DataSource = r1;
              AutoCompleteStringCollection acsc1 = new AutoCompleteStringCollection();
              acsc1.AddRange(r1.ToArray());
             edt_name.AutoCompleteCustomSource = acsc1;
            edt_move.Text = "سحب";
            date.Text = DateTime.Now.ToString();
           
        }

        private void edt_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_Safe = db.tb_safe.Where(x => x.safe_name == edt_name.Text).FirstOrDefault();
            edt_stay.Text = tb_Safe.safe_count.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void edt_add_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_add.Text))
            {
                // إذا كانت القيمة فارغة، يمكنك تعيين القيمة الافتراضية مرة أخرى
                edt_add.Text = "0";
            }
            sumsaler();
        }

        private void edt_move_SelectedIndexChanged(object sender, EventArgs e)
        {
            sumsaler();
        }

        private void sumsaler()
        {
           storadd = Convert.ToDouble(edt_add.Text);
           stortotal =Convert.ToDouble(tb_Safe.safe_count);
            if (edt_move.Text == "سحب")
            {
                stortotal -= storadd;
            }else
            {
                stortotal += storadd;
            }
           
            edt_stay.Text= stortotal.ToString();
            
        }
    }
}
