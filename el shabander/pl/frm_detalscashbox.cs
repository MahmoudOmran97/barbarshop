using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Net.Mail;
using System.Net;
using el_shabander.epl;
namespace el_shabander.pl
{
    public partial class frm_detalscashbox : Form
    {
        DB_BarbershopEntities db = new DB_BarbershopEntities();
      
        bl.methods methods = new bl.methods();
        bl.send send = new bl.send();
        toast toast = new toast();
        tb_cus tb_Cus = new tb_cus();
        tb_appointment tb_appointment = new tb_appointment();
        tb_safe tb_Safe = new tb_safe();
        tb_user tb_User = new tb_user();
            
        
        Notfication notfication = new Notfication();
        public int id;
        public frm_detalscashbox()
        {
            InitializeComponent();






            

            /*el_shabander.DB_BarbershopEntities dbContext = new el_shabander.DB_BarbershopEntities();
            // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
            dbContext.tb_OperationLog.LoadAsync().ContinueWith(loadTask =>
            {
                // Bind data to control when loading complete
                gridControl1.DataSource = dbContext.tb_OperationLog.Local.ToBindingList();
            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());*/
            gridView1.OptionsBehavior.Editable = false;
        }



      
       
       

        public void updata_data()
        {

            db = new DB_BarbershopEntities();
            List<tb_OperationLog> data = db.tb_OperationLog.Where(x => x.SessionID == id).ToList(); // جلب البيانات
            data.Reverse();
            gridControl1.DataSource = data;

            var openSession = db.Sessions.FirstOrDefault(x => x.SessionID == id);
            if (openSession != null)
            {
                newamount.Text = openSession.ClosingAmount.ToString();
                oldamount.Text = openSession.OpeningAmount.ToString();
            }

        }

        

       

        private void gridControl1_Click(object sender, EventArgs e)
        {
            
        }

        private void frm_spend_cus_Activated(object sender, EventArgs e)
        {
            
        }

       

      
        private void frm_spend_cus_Load(object sender, EventArgs e)
        {
              this.WindowState = FormWindowState.Maximized;
            
           

        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            
        }
    }
}
