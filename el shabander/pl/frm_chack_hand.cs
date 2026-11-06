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
    public partial class frm_chack_hand : Form
    {
        DB_BarbershopEntities db = new DB_BarbershopEntities();
        tb_Shift tb_Shift = new tb_Shift();
       
        bl.methods methods = new bl.methods();
        tb_employees tb_Employees = new tb_employees();
        double storadd, stortotal;
       // DateTime time;
        //pl.frm_supp frm_Cat = new frm_supp();
        public int id;
        public frm_chack_hand  ()

        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            toast toast = new toast();
            dialog dialog = new dialog();

          if(id==0)
            {
                tb_Shift.name_from = edt_namefrom.Text;
                tb_Shift.name_to = edt_nameto.Text;
                tb_Shift.date =Convert.ToDateTime( date.Text);
                tb_Shift.mount = Convert.ToDouble(edt_add.Text);
                tb_Shift.staywithcasher = Convert.ToDouble(stay.Text);
                main user = (main)Application.OpenForms["main"];
                string casherName = user?.la_username.Text;
                var openSession = db.Sessions
                   .Where(x => x.namecasher == casherName)
                   .OrderByDescending(x => x.StartTime)
                   .FirstOrDefault();
                tb_Shift.SessionID = openSession.SessionID;
               
                db.tb_Shift.Add(tb_Shift);
                db.SaveChanges();
              

                toast.Width = this.Width;
                toast.txt_caption.Text = "تم تسليم الوردية";
                toast.Show();
                this.Close();
            }else
            {
                tb_Shift.id = id;
                tb_Shift.name_from = edt_namefrom.Text;
                tb_Shift.name_to = edt_nameto.Text;
                tb_Shift.date = Convert.ToDateTime(date.Text);
                tb_Shift.mount = Convert.ToDouble(edt_add.Text);
                tb_Shift.staywithcasher = Convert.ToDouble(stay.Text);
                
               
                db.Entry(tb_Shift).State = System.Data.Entity.EntityState.Modified;
               
                db.SaveChanges();


                toast.Width = this.Width;
                toast.txt_caption.Text = "تم تعديل الاستلام";
                toast.Show();
                this.Close();


            }
               
               

           
               
            
        }

        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void edt_salery_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_add.Text))
            {
                // إذا كانت القيمة فارغة، يمكنك تعيين القيمة الافتراضية مرة أخرى
                edt_add.Text = "0";
            }
            stay.Text = (Convert.ToDouble(cashbox.Text) - Convert.ToDouble(edt_add.Text)).ToString();
        }

       

        private void frm_stor_add_Activated(object sender, EventArgs e)
        {
             
        }

      

      

        private void frm_chack_hand_Load(object sender, EventArgs e)
        {
           
           
            if (id == 0)
            {
                date.Text = DateTime.Now.ToString();
                var r1 = db.tb_safe.Select(x => x.safe_name).ToList();
                main user = (main)Application.OpenForms["main"];
                string casherName = user?.la_username.Text;
                edt_namefrom.Text = casherName;
                var r3 = db.tb_user.Select(x => x.user_name).ToList();
                edt_nameto.DataSource = r3;
                AutoCompleteStringCollection acsc3 = new AutoCompleteStringCollection();
                acsc3.AddRange(r3.ToArray());
                edt_nameto.AutoCompleteCustomSource = acsc3;
                var openSession = db.Sessions
                    .Where(x => x.namecasher == casherName)
                    .OrderByDescending(x => x.StartTime)
                    .FirstOrDefault();

                if (openSession != null)
                {
                    cashbox.Text = openSession.ClosingAmount.ToString();
                    stay.Text = openSession.ClosingAmount.ToString();
                }

            }else
            {
                tb_Shift = db.tb_Shift.Where(x => x.id == id).FirstOrDefault();
                var openSession = db.Sessions
                   .Where(x => x.namecasher == tb_Shift.name_from && x.SessionID==tb_Shift.SessionID )
                   
                   .FirstOrDefault();

                if (openSession != null)
                {
                    cashbox.Text = openSession.ClosingAmount.ToString();
                    
                }
                stay.Text = (Convert.ToDouble(cashbox.Text) - Convert.ToDouble(edt_add.Text)).ToString();
            }
            
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        
    }
}
