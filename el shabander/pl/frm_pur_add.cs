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
    public partial class frm_pur_add : Form
    {
        DB_BarbershopEntities db = new DB_BarbershopEntities();

        tb_buy tb_buy = new tb_buy();
        tb_supp tb_Supp = new tb_supp();
        tb_safe tb_Safe = new tb_safe();
        DataTable datasells = new DataTable();
        double qtp, qtn, qtr, qts;
        Notfication notfication = new Notfication();
        int selectrowindex;
        double curnt, prives;
        tb_OperationLog tb_OperationLog = new tb_OperationLog();
        double oldamount = 0;
        private bool saveButtonClicked = false;
        public int id;
        public List<tb_order_buy> listorder;
        public List<tb_buy> list_pur;

        public frm_pur_add()
        {
            InitializeComponent();
        }

        private void InitializeDataTable()
        {
            datasells.Columns.Add("اسم المادة");
            datasells.Columns.Add("سعر الوحدة");
            datasells.Columns.Add("الصنف");
            datasells.Columns.Add("الكمية");
            datasells.Columns.Add("الاجمالى");

            dataGridView1.DataSource = datasells;
            dataGridView1.DefaultCellStyle.Font = new Font("cairo", 16);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("cairo", 16, FontStyle.Bold);
            dataGridView1.RowTemplate.Height = 30;
        }

        private void frm_pur_add_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeDataTable();

            edt_cat.DataSource = db.tb_cat.Select(x => x.cat_name).ToList();
            save.DataSource = db.tb_safe.Select(x => x.safe_name).ToList();

            var r2 = db.tb_supp.Select(x => x.supp_name).ToList();
            edt_supp.DataSource = r2;

            AutoCompleteStringCollection acsc2 = new AutoCompleteStringCollection();
            acsc2.AddRange(r2.ToArray());
            edt_supp.AutoCompleteCustomSource = acsc2;

            btn_edit.Enabled = false;
            btn_delete.Enabled = false;

            if (id == 0)
            {
                edt_date.Text = DateTime.Now.ToString();
            }
            else
            {
                // تحميل بيانات الفاتورة الموجودة
                listorder = db.tb_order_buy.Where(x => x.sell_id == id).ToList();

                for (int i = 0; i < listorder.Count; i++)
                {
                    datasells.Rows.Add(
                        listorder[i].name_sell,
                        listorder[i].price_sell,
                        listorder[i].name_cat,
                        listorder[i].qt_sell,
                        listorder[i].tprice_sell);
                }

                var tb_buyLoaded = db.tb_buy.Where(x => x.id == id).FirstOrDefault();
                if (tb_buyLoaded != null)
                {
                    var tb_suppLoaded = db.tb_supp.Where(x => x.id == tb_buyLoaded.supp_id).FirstOrDefault();
                    curnt = Convert.ToDouble(tb_buyLoaded.stay);
                    edt_staybehaver.Text = tb_buyLoaded.supp_price.ToString();
                    edt_date.Text = tb_buyLoaded.pur_dat.ToString();
                    invice_id.Visible = true;
                    invice_id.Text = tb_buyLoaded.invocie_id.ToString();
                    chack.Text = curnt.ToString();
                    txt_id.Text = id.ToString();
                    oldamount = Convert.ToDouble(edt_pay.Text);
                }

                pro_call();
            }

            saveButtonClicked = false;
        }

        private void frm_pur_add_Activated(object sender, EventArgs e)
        {
        }

        private void btn_add_Click_1(object sender, EventArgs e)
        {
            try
            {
                // ======= التحقق من وجود عناصر في الفاتورة =======
                if (datasells.Rows.Count == 0)
                {
                    MessageBox.Show("لا يمكن حفظ فاتورة فارغة. الرجاء إضافة صنف واحد على الأقل.",
                        "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ======= التحقق من القيم =======
                if (!double.TryParse(edt_pay.Text, out double payment))
                {
                    MessageBox.Show("الرجاء إدخال قيمة صحيحة للمبلغ المدفوع.");
                    return;
                }

                if (!double.TryParse(txt_totaldata.Text, out double totalData))
                {
                    MessageBox.Show("حدث خطأ في حساب الإجمالي.");
                    return;
                }

                if (!double.TryParse(edt_stay.Text, out double stayAmount))
                {
                    MessageBox.Show("حدث خطأ في حساب الإجمالي مع الرصيد.");
                    return;
                }

                if (!double.TryParse(txt_qt.Text, out double quantity))
                {
                    MessageBox.Show("الرجاء إدخال كمية صحيحة.");
                    return;
                }

                toast toast = new toast();
                list_pur = db.tb_buy.ToList();

                if (id == 0)
                {
                    tb_buy.pur_supp = edt_supp.Text;
                    tb_buy.supp_id = tb_Supp.id;
                    tb_buy.pur_dat = DateTime.Now;
                    tb_buy.safe = save.Text;
                    tb_buy.pur_qt = quantity;
                    tb_buy.pay = payment;
                    tb_buy.pur_tbuy = stayAmount;
                    tb_buy.supp_price = Convert.ToDouble(edt_staybehaver.Text);
                    tb_buy.total_price = totalData;
                    tb_buy.stay = stayAmount - payment;
                    tb_buy.invocie_id = db.tb_buy.Any() ? db.tb_buy.Max(x => x.invocie_id) + 1 : 1;

                    main frm_main = (main)Application.OpenForms["main"];
                    if (frm_main != null && !string.IsNullOrEmpty(frm_main.la_username.Text))
                    {
                        tb_buy.namecasher = frm_main.la_username.Text;
                    }

                    db.tb_buy.Add(tb_buy);
                    db.SaveChanges();

                    tb_Supp.total_price = tb_buy.stay;
                    db.Entry(tb_Supp).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    CheckSupplierLimit();

                    var tb_SafeRecord = db.tb_safe.Where(x => x.safe_name == save.Text).FirstOrDefault();
                    if (tb_SafeRecord != null)
                    {
                        tb_SafeRecord.safe_count -= payment;
                        db.Entry(tb_SafeRecord).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    LogOperation("اضافة", "عملية شراء", -Convert.ToDouble(tb_buy.pay));

                    ss();

                    toast.Width = this.Width;
                    toast.txt_caption.Text = "تم إجراء عملية الشراء";
                    toast.Show();

                    saveButtonClicked = true;
                    this.Close();
                }
                else
                {
                    tb_buy = db.tb_buy.Where(x => x.id == id).FirstOrDefault();
                    tb_buy.pur_supp = edt_supp.Text;
                    tb_buy.supp_id = tb_Supp.id;
                    tb_buy.pur_dat = Convert.ToDateTime(edt_date.Text);
                    tb_buy.safe = save.Text;
                    tb_buy.pur_qt = quantity;
                    tb_buy.pay = payment;
                    tb_buy.pur_tbuy = stayAmount;
                    tb_buy.supp_price = Convert.ToDouble(edt_staybehaver.Text);
                    tb_buy.total_price = totalData;
                    tb_buy.stay = stayAmount - payment;
                    tb_buy.invocie_id = Convert.ToInt32(invice_id.Text);

                    main frm_main = (main)Application.OpenForms["main"];
                    if (frm_main != null && !string.IsNullOrEmpty(frm_main.la_username.Text))
                    {
                        tb_buy.namecasher = frm_main.la_username.Text;
                    }

                    db.Entry(tb_buy).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    tb_Supp = db.tb_supp.Where(x => x.supp_name == edt_supp.Text).FirstOrDefault();
                    prives = Convert.ToDouble(tb_buy.stay);
                    double difference = prives - curnt;
                    tb_Supp.total_price += difference;
                    db.Entry(tb_Supp).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    CheckSupplierLimit();

                    var tb_SafeRecord = db.tb_safe.Where(x => x.safe_name == save.Text).FirstOrDefault();
                    if (tb_SafeRecord != null)
                    {
                        tb_SafeRecord.safe_count -= (tb_buy.pay - oldamount);
                        db.Entry(tb_SafeRecord).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    LogOperation("تعديل", "عملية شراء", oldamount - Convert.ToDouble(tb_buy.pay));

                    ss();

                    toast.Width = this.Width;
                    toast.txt_caption.Text = "تم تعديل عملية الشراء";
                    toast.Show();

                    saveButtonClicked = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء الحفظ: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======= دالة مساعدة للتحقق من حد المورد =======
        private void CheckSupplierLimit()
        {
            if (tb_Supp != null && tb_Supp.supp_max <= tb_Supp.total_price)
            {
                string notificationMessage = $"المورد: {tb_Supp.supp_name} تجاوز الحد الأقصى المسموح له (الحد الأقصى: {tb_Supp.supp_max})، الرجاء دفع المبلغ هذا {tb_Supp.total_price} له.";
                SendEmailWithHtmlGridData(notificationMessage);

                notfication = new Notfication();
                notfication.notfication1 = notificationMessage;
                notfication.CreatedAt = DateTime.Now;
                db.Notfications.Add(notfication);
                db.SaveChanges();
            }
        }

        // ======= دالة مساعدة لتسجيل العمليات =======
        private void LogOperation(string operationType, string tableName, double amountDiff)
        {
            main user = (main)Application.OpenForms["main"];
            string casherName = user?.la_username.Text;
            var openSession = db.Sessions.FirstOrDefault(x => x.namecasher == casherName && x.IsClosed == true);
            if (openSession != null)
            {
                double currentClosing = openSession.ClosingAmount ?? 0;

                var log = new tb_OperationLog();
                log.SessionID = openSession.SessionID;
                log.OperationType = operationType;
                log.TableName = tableName;
                log.OldValue = currentClosing;
                log.NewValue = currentClosing + amountDiff;
                log.AmountDifference = amountDiff;
                db.tb_OperationLog.Add(log);
                db.SaveChanges();

                openSession.ClosingAmount = log.NewValue;
                db.SaveChanges();
            }
        }

        private void frm_pur_add_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            // لو الحفظ اتعمل بالفعل، مش محتاجين نعمل حاجة
            if (saveButtonClicked) return;

            // لو مفيش صفوف في الـ Grid، مش محتاجين نحفظ
            if (datasells.Rows.Count == 0) return;

            try
            {
                list_pur = db.tb_buy.ToList();

                if (id == 0)
                {
                    tb_buy.pur_supp = edt_supp.Text;
                    tb_buy.supp_id = tb_Supp.id;
                    tb_buy.pur_dat = DateTime.Now;
                    tb_buy.safe = save.Text;
                    tb_buy.pur_qt = Convert.ToDouble(txt_qt.Text);
                    tb_buy.pay = Convert.ToDouble(edt_pay.Text);
                    tb_buy.pur_tbuy = Convert.ToDouble(edt_stay.Text);
                    tb_buy.supp_price = Convert.ToDouble(edt_staybehaver.Text);
                    tb_buy.total_price = Convert.ToDouble(txt_totaldata.Text);
                    tb_buy.stay = Convert.ToDouble(edt_stay.Text) - Convert.ToDouble(edt_pay.Text);
                    tb_buy.invocie_id = db.tb_buy.Any() ? db.tb_buy.Max(x => x.invocie_id) + 1 : 1;

                    main frm_main = (main)Application.OpenForms["main"];
                    if (frm_main != null && !string.IsNullOrEmpty(frm_main.la_username.Text))
                        tb_buy.namecasher = frm_main.la_username.Text;

                    db.tb_buy.Add(tb_buy);
                    db.SaveChanges();

                    tb_Supp.total_price = tb_buy.stay;
                    db.Entry(tb_Supp).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    CheckSupplierLimit();

                    var tb_SafeRecord = db.tb_safe.Where(x => x.safe_name == save.Text).FirstOrDefault();
                    if (tb_SafeRecord != null)
                    {
                        tb_SafeRecord.safe_count -= Convert.ToDouble(edt_pay.Text);
                        db.Entry(tb_SafeRecord).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    LogOperation("اضافة", "عملية شراء", -Convert.ToDouble(tb_buy.pay));
                    ss();
                }
                else
                {
                    tb_buy = db.tb_buy.Where(x => x.id == id).FirstOrDefault();
                    tb_buy.pur_supp = edt_supp.Text;
                    tb_buy.supp_id = tb_Supp.id;
                    tb_buy.pur_dat = Convert.ToDateTime(edt_date.Text);
                    tb_buy.safe = save.Text;
                    tb_buy.pur_qt = Convert.ToDouble(txt_qt.Text);
                    tb_buy.pay = Convert.ToDouble(edt_pay.Text);
                    tb_buy.pur_tbuy = Convert.ToDouble(edt_stay.Text);
                    tb_buy.supp_price = Convert.ToDouble(edt_staybehaver.Text);
                    tb_buy.total_price = Convert.ToDouble(txt_totaldata.Text);
                    tb_buy.stay = Convert.ToDouble(edt_stay.Text) - Convert.ToDouble(edt_pay.Text);
                    tb_buy.invocie_id = Convert.ToInt32(invice_id.Text);

                    main frm_main = (main)Application.OpenForms["main"];
                    if (frm_main != null && !string.IsNullOrEmpty(frm_main.la_username.Text))
                        tb_buy.namecasher = frm_main.la_username.Text;

                    db.Entry(tb_buy).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    tb_Supp = db.tb_supp.Where(x => x.supp_name == edt_supp.Text).FirstOrDefault();
                    prives = Convert.ToDouble(tb_buy.stay);
                    double difference = prives - curnt;
                    tb_Supp.total_price += difference;
                    db.Entry(tb_Supp).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    CheckSupplierLimit();

                    var tb_SafeRecord = db.tb_safe.Where(x => x.safe_name == save.Text).FirstOrDefault();
                    if (tb_SafeRecord != null)
                    {
                        tb_SafeRecord.safe_count -= (tb_buy.pay - oldamount);
                        db.Entry(tb_SafeRecord).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    LogOperation("تعديل", "عملية شراء", oldamount - Convert.ToDouble( tb_buy.pay));
                    ss();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء الإغلاق: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cell(object sender, DataGridViewCellEventArgs e)
        {
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

                    // ======= حفظ الكمية الأصلية للصف المحدد =======
                    qtp = Convert.ToDouble(row.Cells[3].Value.ToString());

                    btn_edit.Enabled = true;
                    btn_delete.Enabled = true;
                    btn_add_pur.Enabled = false;
                }
                else
                {
                    MessageBox.Show("الصف الذي قمت بالنقر عليه يحتوي على بيانات غير صالحة.");
                }
            }
        }

        private void edt_supp_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_Supp = db.tb_supp.Where(x => x.supp_name == edt_supp.Text).FirstOrDefault();
            if (tb_Supp != null)
            {
                edt_staybehaver.Text = tb_Supp.total_price.ToString();
            }
            pro_call();
        }

        private void edt_pay_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_pay.Text))
            {
                edt_pay.Text = "0";
            }
            pro_call();
        }

        private void btn_add_pur_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_name.Text))
            {
                MessageBox.Show("الرجاء اضافة اسم المادة.");
                return;
            }

            if (!double.TryParse(edt_buy.Text, out double buyPrice) || buyPrice <= 0)
            {
                MessageBox.Show("الرجاء اضافة سعر الصنف.");
                return;
            }

            if (!double.TryParse(txt_qt.Text, out double qtValue) || qtValue <= 0)
            {
                MessageBox.Show("الرجاء اضافة كمية.");
                return;
            }

            var tb_cat = db.tb_cat.Where(x => x.cat_name == edt_cat.Text).FirstOrDefault();
            if (tb_cat != null)
            {
                tb_cat.qt += qtValue;
                db.Entry(tb_cat).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            DataRow row = datasells.NewRow();
            row[0] = edt_name.Text;
            row[1] = edt_buy.Text;
            row[2] = edt_cat.Text;
            row[3] = txt_qt.Text;
            row[4] = qtValue * buyPrice;
            datasells.Rows.Add(row);

            pro_call();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var tb_cat = db.tb_cat.Where(x => x.cat_name == edt_cat.Text).FirstOrDefault();
            if (tb_cat != null)
            {
                tb_cat.qt -= Convert.ToDouble(txt_qt.Text);
                db.Entry(tb_cat).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

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

            if (!double.TryParse(edt_buy.Text, out double buyPrice) || buyPrice <= 0)
            {
                MessageBox.Show("الرجاء اضافة سعر الصنف.");
                return;
            }

            if (!double.TryParse(txt_qt.Text, out double qtValue) || qtValue <= 0)
            {
                MessageBox.Show("الرجاء اضافة كمية.");
                return;
            }

            qtn = qtValue;
            qts = Convert.ToDouble(qts_qt.Text);
            // ======= الفرق بين الكمية الجديدة والقديمة لتحديث المخزون =======
            qtr = qtn - qts;

            DataGridViewRow newrow = dataGridView1.Rows[selectrowindex];
            newrow.Cells[0].Value = edt_name.Text;
            newrow.Cells[1].Value = edt_buy.Text;
            newrow.Cells[2].Value = edt_cat.Text;
            newrow.Cells[3].Value = txt_qt.Text;
            newrow.Cells[4].Value = qtValue * buyPrice;

            var tb_cat = db.tb_cat.Where(x => x.cat_name == edt_cat.Text).FirstOrDefault();
            if (tb_cat != null)
            {
                tb_cat.qt += qtr;
                db.Entry(tb_cat).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            pro_call();
            btn_edit.Enabled = false;
            btn_delete.Enabled = false;
            btn_add_pur.Enabled = true;
        }

        private void edt_buy_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_buy.Text))
            {
                edt_buy.Text = "0";
            }
        }

        private void edt_stay_Click(object sender, EventArgs e)
        {
            pro_call();
        }

        private void txt_qt_EditValueChanged(object sender, EventArgs e)
        {
            pro_call();
        }

        private void edt_staybehaver_Click_1(object sender, EventArgs e)
        {
            pro_call();
        }

        private void edt_tbuy_Click(object sender, EventArgs e)
        {
            pro_call();
        }

        private void save_SelectedIndexChanged(object sender, EventArgs e) { }
        private void edt_name_SelectedIndexChanged(object sender, EventArgs e) { }
        private void edt_cat_SelectedIndexChanged_1(object sender, EventArgs e) { }
        private void txt_totaldata_Click(object sender, EventArgs e) { }
        private void label19_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void التاريخ_Click(object sender, EventArgs e) { }
        private void edt_name_TextChanged(object sender, EventArgs e) { }
        private void txt_totaldata_Click_1(object sender, EventArgs e) { }
        private void txt_totaldata_Click_2(object sender, EventArgs e) { }
        private void edt_staybehaver_Click(object sender, EventArgs e) { }

        public string GetHtmlFromTextBoxContent(string messageContent)
        {
            string html = "<html><head><style>";
            html += "@import url('https://fonts.googleapis.com/css2?family=Cairo:wght@700&display=swap');";
            html += "body { font-family: 'Cairo', sans-serif; background: linear-gradient(to right, #38ef7d, #38ef7d); padding: 20px; color: #38ef7d; }";
            html += ".email-container { background-color: #34495e; padding: 30px; border-radius: 15px; max-width: 700px; margin: auto; box-shadow: 0 4px 15px rgba(0, 0, 0, 0.3); color: #ffffff; }";
            html += "h2 { color: #f39c12; text-align: center; font-size: 28px; margin-bottom: 20px; font-weight: bold; }";
            html += "h3 { color: #ecf0f1; text-align: center; font-size: 20px; margin-bottom: 20px; font-weight: bold; }";
            html += ".message-box { background-color: #2c3e50; padding: 25px; border-radius: 10px; text-align: center; box-shadow: inset 0 0 15px rgba(0, 0, 0, 0.3); margin: auto; max-width: 600px; font-size: 20px; font-weight: bold; color: #f1c40f; }";
            html += "footer { text-align: center; font-size: 14px; color: #bdc3c7; margin-top: 20px; padding-top: 10px; border-top: 1px solid #7f8c8d; }";
            html += "</style></head><body>";
            html += "<div class='email-container'>";
            html += "<h2>EngineeCode for Software</h2>";
            html += $"<h3>تنبيه</h3>";
            html += $"<div class='message-box'><p>{messageContent}</p></div>";
            html += "<footer>Thank you for using our services. We appreciate your support!</footer>";
            html += "</div>";
            html += "</body></html>";
            return html;
        }

        public void SendEmailWithHtmlGridData(string messageContent)
        {
            string htmlContent = GetHtmlFromTextBoxContent(messageContent);
            if (!string.IsNullOrEmpty(htmlContent))
            {
                SendEmailWithHtml(htmlContent);
            }
        }

        public void SendEmailWithHtml(string htmlContent)
        {
            var userEmails = db.tb_user
                .Where(u => u.user_roll == "مدير")
                .Select(u => u.user_mail)
                .ToList();

            try
            {
                // ======= تنبيه أمني: انقل الـ credentials لـ App.config =======
                string emailFrom = System.Configuration.ConfigurationManager.AppSettings["EmailFrom"] ?? "engineecode12@gmail.com";
                string emailPass = System.Configuration.ConfigurationManager.AppSettings["EmailPass"] ?? "";

                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(emailFrom);
                mail.Subject = "تنبيهات";
                mail.Body = htmlContent;
                mail.IsBodyHtml = true;
                smtpServer.Port = 587;
                smtpServer.Credentials = new NetworkCredential(emailFrom, emailPass);
                smtpServer.EnableSsl = true;

                foreach (var userEmail in userEmails)
                {
                    mail.To.Clear();
                    mail.To.Add(userEmail);
                    smtpServer.Send(mail);
                }
            }
            catch (Exception ex)
            {
                // يمكن تسجيل الخطأ في ملف log
                System.Diagnostics.Debug.WriteLine("Email Error: " + ex.Message);
            }
        }

        private void pro_call()
        {
            double sum = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[4].Value != null)
                    sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
            }
            txt_totaldata.Text = sum.ToString();

            double staybehaverVal = 0;
            double.TryParse(edt_staybehaver.Text, out staybehaverVal);
            double sumall = sum + staybehaverVal;
            edt_stay.Text = sumall.ToString();
        }

        public void ss()
        {
            if (id == 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    // ======= FIX: إنشاء object جديد في كل iteration =======
                    tb_order_buy order = new tb_order_buy();
                    order.sell_id = tb_buy.id;
                    order.name_sell = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    order.price_sell = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
                    order.name_cat = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    order.qt_sell = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                    order.tprice_sell = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);

                    try
                    {
                        db.tb_order_buy.Add(order);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("خطأ في حفظ الصنف: " + ex.Message);
                    }
                }
            }
            else
            {
                db.tb_order_buy.RemoveRange(db.tb_order_buy.Where(x => x.sell_id == id));
                db.SaveChanges();

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    // ======= FIX: إنشاء object جديد في كل iteration =======
                    tb_order_buy order = new tb_order_buy();
                    order.sell_id = tb_buy.id;
                    order.name_sell = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    order.price_sell = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
                    order.name_cat = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    order.qt_sell = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                    order.tprice_sell = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);

                    try
                    {
                        db.tb_order_buy.Add(order);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("خطأ في حفظ الصنف: " + ex.Message);
                    }
                }
            }
        }
    }
}