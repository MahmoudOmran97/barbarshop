using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.CodeParser;
using System.Net.Mail;
using System.Net;

using el_shabander.epl;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace el_shabander.pl
{
    public partial class frm_pur_add: Form
    {
        DB_restoraintEntities db = new DB_restoraintEntities();
       
        tb_buy tb_buy = new tb_buy();
       // bl.methods methods = new bl.methods();
        tb_supp tb_Supp = new tb_supp();
        tb_safe tb_Safe = new tb_safe();    
       // double buy,  qt, tbuy,stay,pay,total ;
        DataTable datasells = new DataTable();
        double qtp, qtn, qtr, qts;
        Notfication notfication = new Notfication();
        int selectrowindex;
        double curnt, prives;
        tb_order_buy tb_Ordersell = new tb_order_buy();
        tb_OperationLog tb_OperationLog = new tb_OperationLog();
        double oldamount = 0;
        private bool saveButtonClicked = false;
        //pl.frm_supp frm_Cat = new frm_supp();
        public int id;
        public frm_pur_add ()

        {
            InitializeComponent();
        }
        public List<tb_order_buy> listorder;
       

        

       

       

       

      

      

        private void frm_pur_add_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            if (id == 0)
            {

                datasells.Columns.Add("اسم المادة");
                datasells.Columns.Add("سعر الوحدة");
                datasells.Columns.Add("الصنف");
                datasells.Columns.Add("الكمية");
                datasells.Columns.Add("الاجمالى");

                dataGridView1.DataSource = datasells;
                dataGridView1.DefaultCellStyle.Font = new Font("cairo", 16);  // يمكنك تعديل نوع وحجم الخط حسب الحاجة
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("cairo", 16, FontStyle.Bold);  // تكبير خط رؤوس الأعمدة
                dataGridView1.RowTemplate.Height = 30;
                edt_cat.DataSource = db.tb_cat.Select(x => x.cat_name).ToList();
                save.DataSource = db.tb_safe.Select(x => x.safe_name).ToList();

                var r2 = db.tb_supp.Select(x => x.supp_name).ToList();


                edt_supp.DataSource = r2;

                // AutoCompleteStringCollection acsc1 = new AutoCompleteStringCollection();
                AutoCompleteStringCollection acsc2 = new AutoCompleteStringCollection();


                acsc2.AddRange(r2.ToArray());

                // edt_name.AutoCompleteCustomSource = acsc1;
                edt_supp.AutoCompleteCustomSource = acsc2;

                edt_date.Text = (DateTime.Now).ToString();
                btn_edit.Enabled = false;
                btn_delete.Enabled = false;



                saveButtonClicked = false;
            }
            else
            {
                datasells.Columns.Add("اسم المادة");
                datasells.Columns.Add("سعر الوحدة");
                datasells.Columns.Add("الصنف");
                datasells.Columns.Add("الكمية");
                datasells.Columns.Add("الاجمالى");

                dataGridView1.DataSource = datasells;
                dataGridView1.DefaultCellStyle.Font = new Font("cairo", 16);  // يمكنك تعديل نوع وحجم الخط حسب الحاجة
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("cairo", 16, FontStyle.Bold);  // تكبير خط رؤوس الأعمدة
                dataGridView1.RowTemplate.Height = 30;
                listorder = db.tb_order_buy.Where(x => x.sell_id == id).ToList();

                edt_cat.DataSource = db.tb_cat.Select(x => x.cat_name).ToList();
                save.DataSource = db.tb_safe.Select(x => x.safe_name).ToList();
                for (int i = 0; i < listorder.Count; i++)
                {
                    //tb_Ordersell.sell_id = tB_sell.id;
                    datasells.Rows.Add(listorder[i].name_sell,
                        listorder[i].price_sell, listorder[i].name_cat, listorder[i].qt_sell,
                        listorder[i].tprice_sell);

                }
                dataGridView1.DataSource = datasells;
                tb_Supp = db.tb_supp.Where(x => x.supp_name == edt_supp.Text).FirstOrDefault();
                //edt_staybehaver.Text = (tb_Supp.total_price - Convert.ToDouble(txt_totaldata.Text) + Convert.ToDouble(edt_pay.Text)).ToString();
               /* tb_Safe = db.tb_safe.Where(x => x.safe_name == save.Text).FirstOrDefault();
                tb_Safe.safe_count += Convert.ToDouble(edt_pay.Text);
                db.Entry(tb_Safe).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();*/
               
                 oldamount= Convert.ToDouble(edt_pay.Text);
                

                btn_edit.Enabled = false;
                btn_delete.Enabled = false;
                var tb_buy = db.tb_buy.Where(x => x.id == id).FirstOrDefault();
                var tb_supp = db.tb_supp.Where(x => x.id == tb_buy.supp_id).FirstOrDefault();
                curnt = Convert.ToDouble(tb_buy.stay);
                edt_staybehaver.Text = tb_buy.supp_price.ToString();
                edt_date.Text = tb_buy.pur_dat.ToString();
                invice_id.Visible = true;
                invice_id.Text = tb_buy.invocie_id.ToString();
                chack.Text = curnt.ToString();
                txt_id.Text = id.ToString();
                pro_call();


                saveButtonClicked = false;
            }
        }

        private void frm_pur_add_Activated(object sender, EventArgs e)
        {
           
           


        }

     
       
        public List<tb_buy> list_pur;
        private void btn_add_Click_1(object sender, EventArgs e)
        {
            toast toast = new toast();
            dialog dialog = new dialog();

          

           
                // التحقق من أن الحقول الأخرى تحتوي على قيم صالحة
                double buyPrice = Convert.ToDouble(edt_buy.Text);
                double quantity = Convert.ToDouble(txt_qt.Text);
                double payment = Convert.ToDouble(edt_pay.Text);
                double totalData = Convert.ToDouble(txt_totaldata.Text);
                double stayAmount = Convert.ToDouble(edt_stay.Text);
            list_pur = db.tb_buy.ToList();
            if (id == 0)
                {
                  // tb_buy.pur_supp = edt_supp.Text;
                   
                 //  tb_buy.pur_name = edt_name.Text;
                 //   tb_buy.pur_cat = edt_cat.Text;
                    tb_buy.pur_supp = edt_supp.Text;
                    tb_buy.supp_id = tb_Supp.id;
                    tb_buy.pur_dat = DateTime.Now;
                 //   tb_buy.pur_buy = buyPrice;
                    tb_buy.safe = save.Text;
                    tb_buy.pur_qt = quantity;
                    tb_buy.pay = payment;
                    tb_buy.pur_tbuy = stayAmount;
                    tb_buy.supp_price= Convert.ToDouble(edt_staybehaver.Text);
                    tb_buy.total_price = totalData;
                    tb_buy.stay = (Convert.ToDouble(edt_stay.Text)) - Convert.ToDouble(edt_pay.Text);
                    tb_buy.invocie_id= db.tb_buy.Any() ? db.tb_buy.Max(x => x.invocie_id) + 1 : 1;
                main frm_supp_Add = (main)Application.OpenForms["main"];
                if (frm_supp_Add != null)
                {
                    // التحقق من أن la_roll يحتوي على قيمة
                    if (!string.IsNullOrEmpty(frm_supp_Add.la_username.Text))
                    {
                        tb_buy.namecasher = frm_supp_Add.la_username.Text;
                    }
                }
                db.tb_buy.Add(tb_buy);
                //db.SaveChanges();
                   
                    tb_Supp.total_price = tb_buy.stay;
                    db.Entry(tb_Supp).State = System.Data.Entity.EntityState.Modified;
                // db.SaveChanges();
                if (tb_Supp.supp_max <= tb_Supp.total_price)
                {
                    // إنشاء رسالة إشعار تتضمن اسم العميل والتحذير من تجاوز الحد الأقصى
                    string notificationMessage = $"المورد: {tb_Supp.supp_name} تجاوز الحد الأقصى المسموح له (الحد الأقصى: {tb_Supp.supp_max})، الرجاء دفع المبلغ هذا  {tb_Supp.total_price} له.";
                    SendEmailWithHtmlGridData(notificationMessage);
                    // إنشاء الإشعار وتحديد التاريخ
                    notfication.notfication1 = notificationMessage;
                    notfication.CreatedAt = DateTime.Now;

                    // إضافة الإشعار إلى قاعدة البيانات
                    db.Notfications.Add(notfication);
                    db.SaveChanges();
                }
                var tb_Safe = db.tb_safe.Where(x => x.safe_name == save.Text).FirstOrDefault();
                    tb_Safe.safe_count -= payment;
                    db.Entry(tb_Safe).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                main user = (main)Application.OpenForms["main"];
                string casherName = user?.la_username.Text;
                var openSession = db.Sessions.FirstOrDefault(x => x.namecasher == casherName && x.IsClosed == true);
                if (openSession != null)
                {
                    tb_OperationLog.SessionID = openSession.SessionID;
                    tb_OperationLog.OperationType = "اضافة";
                    tb_OperationLog.TableName = "عملية شراء";
                    tb_OperationLog.OldValue = openSession.ClosingAmount;
                    tb_OperationLog.NewValue =Convert.ToDouble(openSession.ClosingAmount- tb_buy.pay);
                    tb_OperationLog.AmountDifference = -tb_buy.pay;
                    db.tb_OperationLog.Add(tb_OperationLog);
                    db.SaveChanges();

                    openSession.ClosingAmount = tb_OperationLog.NewValue;
                    
                    db.SaveChanges();

                }

                     ss();
                    toast.Width = this.Width;
                    toast.txt_caption.Text = "تم إجراء عملية الشراء";
                    toast.Show();
                    
                    saveButtonClicked = true;
                    this.Close();
                }
                else
                {
                    // تعديل عملية شراء موجودة
                    tb_buy = db.tb_buy.Where(x => x.id == id).FirstOrDefault();
                    tb_buy.pur_supp = edt_supp.Text;
                    tb_buy.supp_id = tb_Supp.id;
                  //  tb_buy.pur_name = edt_name.Text;
                  //  tb_buy.pur_cat = edt_cat.Text;
                    tb_buy.pur_dat = Convert.ToDateTime(edt_date.Text);
                  //  tb_buy.pur_buy = buyPrice;
                    tb_buy.safe = save.Text;
                    tb_buy.pur_qt = quantity;
                    tb_buy.pay = payment;
                    tb_buy.pur_tbuy = stayAmount;
                    tb_buy.supp_price = Convert.ToDouble(edt_staybehaver.Text);
                    tb_buy.total_price = totalData;
                    tb_buy.stay = (Convert.ToDouble(edt_stay.Text)) - Convert.ToDouble(edt_pay.Text);
                    tb_buy.invocie_id = Convert.ToInt32(invice_id.Text);
                main frm_supp_Add = (main)Application.OpenForms["main"];
                if (frm_supp_Add != null)
                {
                    // التحقق من أن la_roll يحتوي على قيمة
                    if (!string.IsNullOrEmpty(frm_supp_Add.la_username.Text))
                    {
                        tb_buy.namecasher = frm_supp_Add.la_username.Text;
                    }
                }
                db.Entry(tb_buy).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    tb_Supp = db.tb_supp.Where(x => x.supp_name == edt_supp.Text).FirstOrDefault();
                    prives = Convert.ToDouble(tb_buy.stay);
                    double difference = prives - curnt;
                   
                    tb_Supp.total_price += difference;
                    db.Entry(tb_Supp).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                if (tb_Supp.supp_max <= tb_Supp.total_price)
                {
                    // إنشاء رسالة إشعار تتضمن اسم العميل والتحذير من تجاوز الحد الأقصى
                    string notificationMessage = $"المورد: {tb_Supp.supp_name} تجاوز الحد الأقصى المسموح له (الحد الأقصى: {tb_Supp.supp_max})، الرجاء دفع المبلغ هذا  {tb_Supp.total_price} له.";
                    SendEmailWithHtmlGridData(notificationMessage);
                    // إنشاء الإشعار وتحديد التاريخ
                    notfication.notfication1 = notificationMessage;
                    notfication.CreatedAt = DateTime.Now;

                    // إضافة الإشعار إلى قاعدة البيانات
                    db.Notfications.Add(notfication);
                    db.SaveChanges();
                }
                tb_Safe = db.tb_safe.Where(x => x.safe_name == save.Text).FirstOrDefault();
                    tb_Safe.safe_count -= (tb_buy.pay - oldamount);
                    db.Entry(tb_Safe).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                main user = (main)Application.OpenForms["main"];
                string casherName = user?.la_username.Text;
                var openSession = db.Sessions.FirstOrDefault(x => x.namecasher == casherName && x.IsClosed == true);
                if (openSession != null)
                {
                    tb_OperationLog.SessionID = openSession.SessionID;
                    tb_OperationLog.OperationType = "تعديل";
                    tb_OperationLog.TableName = "عملية شراء";
                    tb_OperationLog.OldValue = openSession.ClosingAmount;
                    tb_OperationLog.NewValue = Convert.ToDouble(openSession.ClosingAmount - (tb_buy.pay - oldamount));
                    tb_OperationLog.AmountDifference = oldamount-tb_buy.pay  ;
                    db.tb_OperationLog.Add(tb_OperationLog);
                    db.SaveChanges();

                    openSession.ClosingAmount = tb_OperationLog.NewValue;

                    db.SaveChanges();

                }
                      ss();
                    toast.Width = this.Width;
                    toast.txt_caption.Text = "تم تعديل عملية الشراء";
                    toast.Show();
                   
                    saveButtonClicked = true;
                    this.Close();
                }
            
        }

        private void txt_totaldata_Click(object sender, EventArgs e)
        {

        }

      
        
        

        private void frm_pur_add_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            list_pur = db.tb_buy.ToList();
            // toast toast = new toast();
            //  dialog dialog = new dialog();
            if (!saveButtonClicked)
            {
                if (id == 0)
                {
                    if (dataGridView1.Rows.Count - 1 == 0)
                    {
                        // this.Close();


                    }
                    else
                    {
                        tb_buy.pur_supp = edt_supp.Text;
                        tb_buy.supp_id = tb_Supp.id;
                    
                        tb_buy.pur_dat = DateTime.Now;
                      //  tb_buy.pur_buy = Convert.ToDouble(edt_buy.Text);
                        tb_buy.safe = save.Text;
                        tb_buy.pur_qt = Convert.ToDouble(txt_qt.Text);
                         // tb_buy.pur_tbuy = Convert.ToDouble(edt_stay.Text);
                        tb_buy.pay = Convert.ToDouble(edt_pay.Text);
                        tb_buy.pur_tbuy = Convert.ToDouble(edt_stay.Text);
                        tb_buy.supp_price = Convert.ToDouble(edt_staybehaver.Text);
                        tb_buy.total_price = Convert.ToDouble(txt_totaldata.Text);
                        tb_buy.stay = (Convert.ToDouble(edt_stay.Text)) - Convert.ToDouble(edt_pay.Text);
                        tb_buy.invocie_id = db.tb_buy.Any() ? db.tb_buy.Max(x => x.invocie_id) + 1 : 1;
                        main frm_supp_Add = (main)Application.OpenForms["main"];
                        if (frm_supp_Add != null)
                        {
                            // التحقق من أن la_roll يحتوي على قيمة
                            if (!string.IsNullOrEmpty(frm_supp_Add.la_username.Text))
                            {
                                tb_buy.namecasher = frm_supp_Add.la_username.Text;
                            }
                        }
                        db.tb_buy.Add(tb_buy);
                        db.SaveChanges();

                        tb_Supp.total_price = tb_buy.stay; 
                        db.Entry(tb_Supp).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        if (tb_Supp.supp_max <= tb_Supp.total_price)
                        {
                            // إنشاء رسالة إشعار تتضمن اسم العميل والتحذير من تجاوز الحد الأقصى
                            string notificationMessage = $"المورد: {tb_Supp.supp_name} تجاوز الحد الأقصى المسموح له (الحد الأقصى: {tb_Supp.supp_max})، الرجاء دفع المبلغ هذا  {tb_Supp.total_price} له.";
                            SendEmailWithHtmlGridData(notificationMessage);
                            // إنشاء الإشعار وتحديد التاريخ
                            notfication.notfication1 = notificationMessage;
                            notfication.CreatedAt = DateTime.Now;

                            // إضافة الإشعار إلى قاعدة البيانات
                            db.Notfications.Add(notfication);
                            db.SaveChanges();
                        }
                        tb_Safe = db.tb_safe.Where(x => x.safe_name == save.Text).FirstOrDefault();
                        tb_Safe.safe_count -= Convert.ToDouble(edt_pay.Text);
                        db.Entry(tb_Safe).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        main user = (main)Application.OpenForms["main"];
                        string casherName = user?.la_username.Text;
                        var openSession = db.Sessions.FirstOrDefault(x => x.namecasher == casherName && x.IsClosed == true);
                        if (openSession != null)
                        {
                            tb_OperationLog.SessionID = openSession.SessionID;
                            tb_OperationLog.OperationType = "اضافة";
                            tb_OperationLog.TableName = "عملية شراء";
                            tb_OperationLog.OldValue = openSession.ClosingAmount;
                            tb_OperationLog.NewValue = Convert.ToDouble(openSession.ClosingAmount - tb_buy.pay);
                            tb_OperationLog.AmountDifference = -tb_buy.pay;
                            db.tb_OperationLog.Add(tb_OperationLog);
                            db.SaveChanges();

                            openSession.ClosingAmount = tb_OperationLog.NewValue;

                            db.SaveChanges();

                        }

                       
                        ss();
                       
                    }
                }
                else
                {

                    tb_buy = db.tb_buy.Where(x => x.id == id).FirstOrDefault();
                    tb_buy.pur_supp = edt_supp.Text;
                    tb_buy.supp_id = tb_Supp.id;

                   // tb_buy.pur_name = edt_name.Text;
                    // tb_buy.pur_type = edt_tybe.Text;
                   // tb_buy.pur_cat = edt_cat.Text;
                  //  tb_buy.pur_supp = edt_supp.Text;
                    tb_buy.pur_dat = Convert.ToDateTime(edt_date.Text);
                 //   tb_buy.pur_buy = Convert.ToDouble(edt_buy.Text);
                    tb_buy.safe = save.Text;
                    tb_buy.pur_qt = Convert.ToDouble(txt_qt.Text);
                   // tb_buy.pur_tbuy = Convert.ToDouble(edt_stay.Text);
                    tb_buy.pay = Convert.ToDouble(edt_pay.Text);
                    tb_buy.pur_tbuy = Convert.ToDouble(edt_stay.Text);
                    tb_buy.supp_price = Convert.ToDouble(edt_staybehaver.Text);
                    tb_buy.total_price = Convert.ToDouble(txt_totaldata.Text);
                    tb_buy.stay = (Convert.ToDouble(edt_stay.Text)) - Convert.ToDouble(edt_pay.Text);
                    tb_buy.invocie_id = Convert.ToInt32(invice_id.Text);
                    main frm_supp_Add = (main)Application.OpenForms["main"];
                    if (frm_supp_Add != null)
                    {
                        // التحقق من أن la_roll يحتوي على قيمة
                        if (!string.IsNullOrEmpty(frm_supp_Add.la_username.Text))
                        {
                            tb_buy.namecasher = frm_supp_Add.la_username.Text;
                        }
                    }
                    db.Entry(tb_buy).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    tb_Supp = db.tb_supp.Where(x => x.supp_name == edt_supp.Text).FirstOrDefault();
                    prives = Convert.ToDouble(tb_buy.stay);
                    double difference = prives - curnt;

                    tb_Supp.total_price += difference;
                    db.Entry(tb_Supp).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    if (tb_Supp.supp_max <= tb_Supp.total_price)
                    {
                        // إنشاء رسالة إشعار تتضمن اسم العميل والتحذير من تجاوز الحد الأقصى
                        string notificationMessage = $"المورد: {tb_Supp.supp_name} تجاوز الحد الأقصى المسموح له (الحد الأقصى: {tb_Supp.supp_max})، الرجاء دفع المبلغ هذا  {tb_Supp.total_price} له.";
                        SendEmailWithHtmlGridData(notificationMessage);
                        // إنشاء الإشعار وتحديد التاريخ
                        notfication.notfication1 = notificationMessage;
                        notfication.CreatedAt = DateTime.Now;

                        // إضافة الإشعار إلى قاعدة البيانات
                        db.Notfications.Add(notfication);
                        db.SaveChanges();
                    }
                    tb_Safe = db.tb_safe.Where(x => x.safe_name == save.Text).FirstOrDefault();
                    tb_Safe.safe_count -= (tb_buy.pay - oldamount);
                    db.Entry(tb_Safe).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    main user = (main)Application.OpenForms["main"];
                    string casherName = user?.la_username.Text;
                    var openSession = db.Sessions.FirstOrDefault(x => x.namecasher == casherName && x.IsClosed == true);
                    if (openSession != null)
                    {
                        tb_OperationLog.SessionID = openSession.SessionID;
                        tb_OperationLog.OperationType = "تعديل";
                        tb_OperationLog.TableName = "عملية شراء";
                        tb_OperationLog.OldValue = openSession.ClosingAmount;
                        tb_OperationLog.NewValue = Convert.ToDouble(openSession.ClosingAmount - (tb_buy.pay - oldamount));
                        tb_OperationLog.AmountDifference = oldamount - tb_buy.pay;
                        db.tb_OperationLog.Add(tb_OperationLog);
                        db.SaveChanges();

                        openSession.ClosingAmount = tb_OperationLog.NewValue;

                        db.SaveChanges();

                    }
                    ss();
                    

                }
            }
        }

       

       

        private void cell(object sender, DataGridViewCellEventArgs e)
        {
            // التأكد من أن الصف المختار صحيح وليس خارج النطاق
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                selectrowindex = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                if (row.Cells[0].Value != null && !string.IsNullOrEmpty(row.Cells[0].Value.ToString()))
                {
                    edt_name.Text = row.Cells[0].Value.ToString();
            edt_buy.Text = row.Cells[1].Value.ToString();
            edt_cat.Text = row.Cells[2].Value.ToString();
            txt_qt.Text = row.Cells[3].Value.ToString();
           
            qts_qt.Text = row.Cells[3].Value.ToString();
          
            btn_edit.Enabled = true;
            btn_delete.Enabled = true;
            btn_add_pur.Enabled = false;
                }
                else
                {
                    // عرض رسالة عند محاولة الوصول إلى خلايا فارغة أو تحتوي على قيم غير صالحة
                    MessageBox.Show("الصف الذي قمت بالنقر عليه يحتوي على بيانات غير صالحة.");
                }
            }
        }

      
      

        private void edt_name_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void edt_cat_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void edt_supp_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_Supp = db.tb_supp.Where(x => x.supp_name == edt_supp.Text).FirstOrDefault();
            edt_staybehaver.Text = tb_Supp.total_price.ToString();
            //edt_stay.Text = tb_Supp.total_price.ToString();
            pro_call();
        }

        private void edt_pay_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_pay.Text))
            {
                // إذا كانت القيمة فارغة، يمكنك تعيين القيمة الافتراضية مرة أخرى
                edt_pay.Text = "0";
                pro_call();
            }
            else
            {
                pro_call();
            }
        }

        private void btn_add_pur_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_name.Text))
            {
                MessageBox.Show("الرجاء اضافة اسم المادة.");
                return;
            }
            else if (Convert.ToDouble(edt_buy.Text)<=0)
            {
                MessageBox.Show("الرجاء اضافة سعر الصنف.");
                return;
            }
            else if (Convert.ToDouble(txt_qt.Text) <= 0)
            {
                MessageBox.Show("الرجاء اضافة كمية.");
                return;
            }


            var tb_cat = db.tb_cat.Where(x => x.cat_name == edt_cat.Text).FirstOrDefault();
            tb_cat.qt += Convert.ToDouble(txt_qt.Text);
            db.Entry(tb_cat).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            // إضافة البيانات إلى DataTable
            DataRow row = datasells.NewRow();
            row[0] = edt_name.Text;
            row[1] = edt_buy.Text;
            row[2] = edt_cat.Text;
            row[3] = txt_qt.Text;
            row[4] = (Convert.ToDouble(txt_qt.Text)) * Convert.ToDouble(edt_buy.Text);
           

            datasells.Rows.Add(row);
            pro_call();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

            // qtn = Convert.ToDouble(txt_qt.Text);
            // qtr = qtp - qtn;
            //  txt_qt.Text = qtr.ToString();
            var tb_cat = db.tb_cat.Where(x => x.cat_name == edt_cat.Text).FirstOrDefault();
            tb_cat.qt -= Convert.ToDouble(txt_qt.Text);
            db.Entry(tb_cat).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            int rowindex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowindex);
            pro_call();
            btn_edit.Enabled = false;
            btn_delete.Enabled = false;
            btn_add_pur.Enabled = true;
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_name.Text))
            {
                MessageBox.Show("الرجاء اضافة اسم المادة.");
                return;
            }
            else if (Convert.ToDouble(edt_buy.Text) <= 0)
            {
                MessageBox.Show("الرجاء اضافة سعر الصنف.");
                return;
            }
            else if (Convert.ToDouble(txt_qt.Text) <= 0)
            {
                MessageBox.Show("الرجاء اضافة كمية.");
                return;
            }

            qtn = Convert.ToDouble(txt_qt.Text);
            qts = Convert.ToDouble(qts_qt.Text);
              qtr = qtp - qts + qtn;
            // txt_qt.Text = qtr.ToString();

            DataGridViewRow newrow = dataGridView1.Rows[selectrowindex];

            newrow.Cells[0].Value = edt_name.Text;
            newrow.Cells[1].Value = edt_buy.Text;
            newrow.Cells[2].Value = edt_cat.Text;
           


            newrow.Cells[3].Value = txt_qt.Text;
            newrow.Cells[4].Value = (Convert.ToDouble(txt_qt.Text)) * Convert.ToDouble(edt_buy.Text);

            var tb_cat = db.tb_cat.Where(x => x.cat_name == edt_cat.Text).FirstOrDefault();
            tb_cat.qt += qtr;
            db.Entry(tb_cat).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();




            pro_call();
            btn_edit.Enabled = false;
            btn_delete.Enabled = false;
            btn_add_pur.Enabled = true;
        }

      
        private void edt_buy_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_buy.Text))
            {
                // إذا كانت القيمة فارغة، يمكنك تعيين القيمة الافتراضية مرة أخرى
            
                    edt_buy.Text = "0";
              
                // edt_cat.Text = tb_stuk.stuk_cat;
               
            }
           
        }

        private void edt_stay_Click(object sender, EventArgs e)
        {
            pro_call();
        }

        private void txt_totaldata_Click_1(object sender, EventArgs e)
        {

        }

        private void txt_qt_EditValueChanged(object sender, EventArgs e)
        {
            pro_call();
        }

        private void save_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void التاريخ_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void edt_staybehaver_Click(object sender, EventArgs e)
        {

        }

        private void txt_totaldata_Click_2(object sender, EventArgs e)
        {

        }

        private void edt_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void edt_staybehaver_Click_1(object sender, EventArgs e)
        {
            pro_call();
        }

        private void edt_tbuy_Click(object sender, EventArgs e)
        {
            pro_call();
        }




        public string GetHtmlFromTextBoxContent(string messageContent)
        {
            // جلب محتوى TextBox
            // يمكنك استخدام ToList() للحصول على جميع البيانات
            // تهيئة المتغير المحتوي على الرسالة

            string html = "<html><head><style>";
            html += "@import url('https://fonts.googleapis.com/css2?family=Cairo:wght@700&display=swap');"; // استيراد خط كايرو
            html += "body { font-family: 'Cairo', sans-serif; background: linear-gradient(to right, #38ef7d, #38ef7d); padding: 20px; color: #38ef7d; }"; // تدرج بين الأخضر الفاتح والأخضر الداكن
            html += ".email-container { background-color: #34495e; padding: 30px; border-radius: 15px; max-width: 700px; margin: auto; box-shadow: 0 4px 15px rgba(0, 0, 0, 0.3); color: #ffffff; }";
            html += "h2 { color: #f39c12; text-align: center; font-size: 28px; margin-bottom: 20px; font-weight: bold; }"; // عنوان بلون برتقالي فاتح
            html += "h3 { color: #ecf0f1; text-align: center; font-size: 20px; margin-bottom: 20px; font-weight: bold; }"; // نص توضيحي بلون أبيض فاتح
            html += ".message-box { background-color: #2c3e50; padding: 25px; border-radius: 10px; text-align: center; box-shadow: inset 0 0 15px rgba(0, 0, 0, 0.3); margin: auto; max-width: 600px; font-size: 20px; font-weight: bold; color: #f1c40f; }"; // صندوق الرسالة مع ظل داخلي ولون أصفر
            html += "footer { text-align: center; font-size: 14px; color: #bdc3c7; margin-top: 20px; padding-top: 10px; border-top: 1px solid #7f8c8d; }"; // فوتر بلون رمادي فاتح
            html += "</style></head><body>";

            // إضافة المحتوى إلى الحاوية
            html += "<div class='email-container'>";
            html += "<h2>EngineeCode for Software</h2>"; // العنوان الرئيسي
            html += $"<h3>تنبيه</h3>"; // النص الثانوي
            html += $"<div class='message-box'><p>{messageContent}</p></div>"; // صندوق الرسالة
            html += "<footer>Thank you for using our services. We appreciate your support!</footer>"; // الفوتر
            html += "</div>"; // إغلاق حاوية البريد
            html += "</body></html>";

            return html; // إرجاع المحتوى
        }
        public void SendEmailWithHtmlGridData(string messageContent)
        {
            string htmlContent = GetHtmlFromTextBoxContent(messageContent); // استخراج البيانات كـ HTML
            if (!string.IsNullOrEmpty(htmlContent)) // تحقق من عدم كون المحتوى فارغًا
            {
                SendEmailWithHtml(htmlContent); // إرسال البريد الإلكتروني مع HTML
            } // إرسال البريد الإلكتروني مع HTML
        }
        public void SendEmailWithHtml(string htmlContent)
        {

            var userEmails = db.tb_user
                 .Where(u => u.user_roll == "مدير") // استبدل حسب الحاجة
                 .Select(u => u.user_mail)
                 .ToList();

            // إضافة البريد الثابت
            //userEmails.Add(Properties.Settings.Default.Email);
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("engineecode12@gmail.com");
                // mail.To.Add(userEmail);
                mail.Subject = "تنبيهات";
                mail.Body = htmlContent;
                mail.IsBodyHtml = true;
                smtpServer.Port = 587;
                smtpServer.Credentials = new NetworkCredential("engineecode12@gmail.com", "shjhvhnebtuisfsg");
                smtpServer.EnableSsl = true; // Enable SSL for security
                foreach (var userEmail in userEmails)
                {
                    mail.To.Clear(); // امسح العناوين السابقة
                    mail.To.Add(userEmail); // أضف عنوان البريد الإلكتروني الحالي
                    smtpServer.Send(mail); // أرسل البريد الإلكتروني
                }



            }
            catch (Exception ex)
            {
               
            }
        }

        private void pro_call()
        {
          
           
            

            double sum = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
            }
            txt_totaldata.Text = sum.ToString();
            double sumall = Convert.ToDouble(txt_totaldata.Text) + Convert.ToDouble(edt_staybehaver.Text);
            edt_stay.Text = sumall.ToString();
          
        }
        public void ss()
        {
            if (id == 0)
            {

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {

                    //report1.
                    tb_Ordersell.sell_id = tb_buy.id;
                    tb_Ordersell.name_sell = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    tb_Ordersell.price_sell = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
                    tb_Ordersell.name_cat = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    tb_Ordersell.qt_sell = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                    tb_Ordersell.tprice_sell = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                   
                    // db.SaveChanges();

                    try
                    {
                        db.tb_order_buy.Add(tb_Ordersell);
                        db.SaveChanges();
                        // tb_Sellorder.id = x += 1;
                    }
                    catch
                    {
                        MessageBox.Show("ghg");

                    }
                }
                // db.SaveChanges();
            }
            else
            {



                db.tb_order_buy.RemoveRange(db.tb_order_buy.Where(x => x.sell_id == id));
                db.SaveChanges();



                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {

                    //report1.
                    tb_Ordersell.sell_id = tb_buy.id;
                    tb_Ordersell.name_sell = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    tb_Ordersell.price_sell = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
                    tb_Ordersell.name_cat = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    tb_Ordersell.qt_sell = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                    tb_Ordersell.tprice_sell = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                  
                   
                    try
                    {
                        db.tb_order_buy.Add(tb_Ordersell);
                        db.SaveChanges();
                       
                    }
                    catch
                    {
                        MessageBox.Show("ghg");

                    }


                    

                }


            }



        }
    }
}
