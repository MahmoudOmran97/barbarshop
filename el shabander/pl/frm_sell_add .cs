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
using System.Data.Entity;
using DevExpress.XtraReports.UI;
using System.Collections;
using DevExpress.CodeParser;
using System.IO;
using System.Data.Entity.Validation;
using Microsoft.Reporting.WinForms;
using System.Text.RegularExpressions;

namespace el_shabander.pl
{
    public partial class frm_sell_add : Form
    {
        DB_BarbershopEntities db = new DB_BarbershopEntities();
        tb_appointment tb_appointment = new tb_appointment();
        tb_buy tb_buy = new tb_buy();
        tb_cus tb_cus = new tb_cus();
        bl.send send = new bl.send();
        tb_service tb_service = new tb_service();
        tb_chair tb_chair = new tb_chair();
        tb_order_appointment tb_order_appointment = new tb_order_appointment();
        tb_safe tb_Safe = new tb_safe();
        Notfication notfication = new Notfication();
        bl.methods methods = new bl.methods();
        tb_OperationLog tb_OperationLog = new tb_OperationLog();

        double curnt, prives;
        private bool saveButtonClicked = false;

        public int id;
        public int booking_id = 0; // ← جديد: id الحجز المرتبط

        DataTable datasells = new DataTable();
        int selectrowindex;

        public frm_sell_add()
        {
            InitializeComponent();

            el_shabander.DB_BarbershopEntities dbContext = new el_shabander.DB_BarbershopEntities();
            dbContext.tb_service.LoadAsync().ContinueWith(loadTask =>
            {
                gridControl1.DataSource = dbContext.tb_service.Local.ToBindingList();
            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void frm_pur_add_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            textBox1.Focus();

            if (id == 0)
            {
                datasells.Columns.Add("اسم المادة");
                datasells.Columns.Add("سعر الوحدة");
                datasells.Columns.Add("الكمية");
                datasells.Columns.Add("اجمالى");
                datasells.Columns.Add("عمود مخفي");
                datasells.Columns.Add("الكمية القديم");
                dataGridView1.DataSource = datasells;
                dataGridView1.Columns["عمود مخفي"].Visible = false;
                dataGridView1.Columns["الكمية القديم"].Visible = false;
                dataGridView1.DefaultCellStyle.Font = new Font("cairo", 16);
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("cairo", 16, FontStyle.Bold);
                dataGridView1.RowTemplate.Height = 30;
                save.DataSource = db.tb_safe.Select(x => x.safe_name).ToList();
                dataGridView1.ReadOnly = true;

                var r1 = db.tb_main.Select(x => x.name_main).ToList();
                edt_name.DataSource = r1;
                AutoCompleteStringCollection acsc1 = new AutoCompleteStringCollection();
                acsc1.AddRange(r1.ToArray());
                edt_name.AutoCompleteCustomSource = acsc1;

                comboBox1.Text = "اجل";
                btn_edit.Enabled = false;
                btn_delete.Enabled = false;
                edt_date.Text = DateTime.Now.ToString();
                saveButtonClicked = false;
                id_invioce.Visible = false;
            }
            else
            {
                save.Enabled = false;
                datasells.Columns.Add("اسم المادة");
                datasells.Columns.Add("سعر الوحدة");
                datasells.Columns.Add("الكمية");
                datasells.Columns.Add("اجمالى");
                datasells.Columns.Add("عمود مخفي");
                datasells.Columns.Add("الكمية القديم");
                dataGridView1.DataSource = datasells;
                dataGridView1.Columns["عمود مخفي"].Visible = false;
                dataGridView1.Columns["الكمية القديم"].Visible = false;
                dataGridView1.DefaultCellStyle.Font = new Font("cairo", 16);
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("cairo", 16, FontStyle.Bold);
                dataGridView1.RowTemplate.Height = 30;

                var r1 = db.tb_main.Select(x => x.name_main).ToList();
                edt_name.DataSource = r1;
                AutoCompleteStringCollection acsc1 = new AutoCompleteStringCollection();
                acsc1.AddRange(r1.ToArray());
                edt_name.AutoCompleteCustomSource = acsc1;

                groupControl2.Enabled = true;
                var r2 = db.tb_chair.Where(x => x.totall_price == 0).Select(x => x.name_chair).ToList();
                dataGridView1.ReadOnly = true;
                edt_table.DataSource = r2;
                AutoCompleteStringCollection acsc2 = new AutoCompleteStringCollection();
                acsc2.AddRange(r2.ToArray());
                edt_table.AutoCompleteCustomSource = acsc2;

                listorder = db.tb_order_appointment.Where(x => x.sell_id == id).ToList();
                for (int i = 0; i < listorder.Count; i++)
                {
                    datasells.Rows.Add(listorder[i].name_sell,
                        listorder[i].price_sell, listorder[i].qt_sell,
                        listorder[i].tprice_sell, listorder[i].newqt, listorder[i].qt_sell);
                }
                dataGridView1.DataSource = datasells;
                comboBox1.Text = "اجل";

                tb_appointment = db.tb_appointment.Where(x => x.id == id).FirstOrDefault();
                id_invioce.Text = tb_appointment.invocie_id.ToString();

                // ← جديد: تحميل اسم العميل
                edt_cusname.Text = tb_appointment.cus_name;
                booking_id = db.tb_booking
    .Where(x => x.cus_name == tb_appointment.cus_name && x.status == "يتخدم")
    .Select(x => x.id)
    .FirstOrDefault();
                btn_edit.Enabled = false;
                btn_delete.Enabled = false;
                id_invioce.Visible = true;
                saveButtonClicked = false;
                pro_call();
            }
        }

        // ========== جديد: اختيار عميل من الطابور ==========
        private void btn_pick_from_queue_Click(object sender, EventArgs e)
        {
            var queue = db.tb_booking
                .Where(x => x.status == "انتظار")
                .OrderBy(x => x.booking_date)
                .ThenBy(x => x.queue_number)
                .ToList();

            if (!queue.Any())
            {
                MessageBox.Show("لا يوجد عملاء في الانتظار", "الطابور",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frm_queue frmQ = new frm_queue();

            frmQ.gridControl1.DataSource = queue.Select(x => new
            {
                id = x.id,
                رقم_الدور = x.queue_number,
                اسم_العميل = x.cus_name,
                الهاتف = x.cus_phone,
                التاريخ = x.booking_date
            }).ToList();

            // إخفاء id ومنع التعديل
            frmQ.gridView1.Columns["id"].Visible = false;
            frmQ.gridView1.OptionsBehavior.Editable = false;

            if (frmQ.ShowDialog() == DialogResult.OK)
            {
                var focusedRow = frmQ.gridView1.GetFocusedRow() as dynamic;
                if (focusedRow == null) return;

                int selectedId = (int)focusedRow.id;
                var selected = queue.FirstOrDefault(x => x.id == selectedId);
                if (selected == null) return;

                edt_cusname.Text = selected.cus_name ?? "";
                booking_id = selected.id;

                var b = db.tb_booking.Find(selected.id);
                if (b != null)
                {
                    b.status = "يتخدم";
                    db.SaveChanges();
                }
            }
        }
        // ========== Helper: إغلاق الحجز بعد الدفع ==========
        private void CloseBooking()
        {
            if (booking_id > 0)
            {
                var b = db.tb_booking.Find(booking_id);
                if (b != null)
                {
                    double amountPaid = 0;
                    double.TryParse(edt_pay.Text, out amountPaid); // ← أأمن من Convert

                    b.status = amountPaid > 0 ? "تم" : "يتخدم";
                    db.Entry(b).State = System.Data.Entity.EntityState.Modified; // ← ضروري
                    db.SaveChanges();
                }
            }
        }

        private void label3_Click(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void edt_sell_TextChanged(object sender, EventArgs e) { pro_call(); }
        private void frm_sell_add_Activated(object sender, EventArgs e) { }
        private void edt_qt_EditValueChanged(object sender, EventArgs e) { }

        private void edt_name_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var _search = edt_name.Text;
            gridControl1.DataSource = db.tb_service.Where(x => x.name_main.Contains(_search)).ToList();
        }

        private void btn_add_Click_1(object sender, EventArgs e)
        {
            var productExists = db.tb_service.Where(p => p.name_product == textBox1.Text).FirstOrDefault();
            if (string.IsNullOrWhiteSpace(edt_sell.Text) || productExists == null) return;

            bool isDuplicate = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == textBox1.Text)
                {
                    row.Cells[2].Value = (Convert.ToDouble(row.Cells[2].Value) + Convert.ToDouble(edt_qt.Text)).ToString();
                    row.Cells[3].Value = (Convert.ToDouble(row.Cells[1].Value) * Convert.ToDouble(row.Cells[2].Value)).ToString();
                    row.Cells[4].Value = (Convert.ToDouble(row.Cells[2].Value) - Convert.ToDouble(row.Cells[5].Value)).ToString();
                    isDuplicate = true;
                    break;
                }
            }

            if (!isDuplicate)
            {
                DataRow newRow = datasells.NewRow();
                newRow[0] = textBox1.Text;
                newRow[1] = edt_sell.Text;
                newRow[2] = edt_qt.Text;
                newRow[3] = Convert.ToDouble(edt_sell.Text) * Convert.ToDouble(edt_qt.Text);
                newRow[4] = edt_qt.Text;
                newRow[5] = 0;
                datasells.Rows.Add(newRow);
            }

            pro_call();
            if (comboBox1.Text == "نقدى") edt_pay.Text = txt_totaldata.Text;
            edt_code.Clear();
            edt_qt.Value = 1;

            var tb_service = db.tb_service.Where(x => x.name_product == textBox1.Text).FirstOrDefault();
            var listorder2 = db.tb_order_cat.Where(x => x.product_id == tb_service.id).ToList();
            foreach (var order in listorder2)
            {
                var tb_cat = db.tb_cat.FirstOrDefault(x => x.cat_name == order.name_cat);
                tb_cat.qt -= (Convert.ToDouble(edt_qt.Text) * tb_service.price);
                db.Entry(tb_cat).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                var Tb_cat = db.tb_cat.FirstOrDefault(c => c.cat_name == tb_cat.cat_name);
                if (Tb_cat != null && Tb_cat.qt < Tb_cat.max_note)
                {
                    string notificationMessage = $"الصنف: {Tb_cat.cat_name} كميته أقل من الحد المسموح ({Tb_cat.max_note}) (الكمية الحالية: {Tb_cat.qt})";
                    send.SendEmailWithHtmlGridData(notificationMessage);
                    notfication.notfication1 = notificationMessage;
                    notfication.CreatedAt = DateTime.Now;
                    db.Notfications.Add(notfication);
                    db.SaveChanges();
                }
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            DataGridViewRow newrow = dataGridView1.Rows[selectrowindex];
            newrow.Cells[0].Value = textBox1.Text;
            newrow.Cells[1].Value = edt_sell.Text;
            newrow.Cells[2].Value = edt_qt.Text;
            newrow.Cells[3].Value = Convert.ToDouble(edt_qt.Text) * Convert.ToDouble(edt_sell.Text);
            newrow.Cells[4].Value = (Convert.ToDouble(newrow.Cells[2].Value) - Convert.ToDouble(newrow.Cells[5].Value)).ToString();

            pro_call();
            btn_edit.Enabled = false;
            btn_delete.Enabled = false;
            btn_add.Enabled = true;
            if (comboBox1.Text == "نقدى") edt_pay.Text = txt_totaldata.Text;

            var tb_service = db.tb_service.Where(x => x.name_product == textBox1.Text).FirstOrDefault();
            var listorder2 = db.tb_order_cat.Where(x => x.product_id == tb_service.id).ToList();
            foreach (var order in listorder2)
            {
                var tb_cat = db.tb_cat.FirstOrDefault(x => x.cat_name == order.name_cat);
                tb_cat.qt -= (Convert.ToDouble(edt_qt.Text) * tb_service.price);
                db.Entry(tb_cat).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                var Tb_cat = db.tb_cat.FirstOrDefault(c => c.cat_name == tb_cat.cat_name);
                if (Tb_cat != null && Tb_cat.qt < Tb_cat.max_note)
                {
                    string msg = $"الصنف: {Tb_cat.cat_name} كميته أقل من الحد المسموح ({Tb_cat.max_note}) (الكمية الحالية: {Tb_cat.qt})";
                    send.SendEmailWithHtmlGridData(msg);
                    notfication.notfication1 = msg;
                    notfication.CreatedAt = DateTime.Now;
                    db.Notfications.Add(notfication);
                    db.SaveChanges();
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowindex);
            pro_call();
            btn_edit.Enabled = false;
            btn_delete.Enabled = false;
            btn_add.Enabled = true;
            if (comboBox1.Text == "نقدى") edt_pay.Text = txt_totaldata.Text;
        }

        private void cell(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                selectrowindex = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                if (row.Cells[0].Value != null && !string.IsNullOrEmpty(row.Cells[0].Value.ToString()))
                {
                    textBox1.Text = row.Cells[0].Value.ToString();
                    edt_sell.Text = row.Cells[1].Value.ToString();
                    edt_qt.Text = row.Cells[2].Value.ToString();

                    var tb_service = db.tb_service.Where(x => x.name_product == textBox1.Text).FirstOrDefault();
                    var listorder2 = db.tb_order_cat.Where(x => x.product_id == tb_service.id).ToList();
                    foreach (var order in listorder2)
                    {
                        var tb_cat = db.tb_cat.FirstOrDefault(x => x.cat_name == order.name_cat);
                        tb_cat.qt += (Convert.ToDouble(edt_qt.Text) * tb_service.price);
                        db.Entry(tb_cat).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    btn_edit.Enabled = true;
                    btn_delete.Enabled = true;
                    btn_add.Enabled = false;
                }
                else
                {
                    MessageBox.Show("الصف الذي قمت بالنقر عليه يحتوي على بيانات غير صالحة.");
                }
            }
        }

        private void edt_cus_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_chair = db.tb_chair.Where(x => x.name_chair == edt_cus.Text).FirstOrDefault();
            pro_call();
        }

        public DataSet da;
        public List<tb_order_appointment> listorder;

        // ========== Helper: حفظ بيانات الفاتورة ==========
        private void SaveAppointmentData(bool isNew)
        {
            if (isNew)
            {
                tb_chair = db.tb_chair.Where(x => x.name_chair == edt_cus.Text).FirstOrDefault();
                tb_appointment.sell_cus = edt_cus.Text;
                tb_appointment.cus_id = tb_chair.id;
                tb_appointment.cus_name = edt_cusname.Text; // ← جديد
                tb_appointment.pay = Convert.ToDouble(edt_pay.Text);
                tb_appointment.sell_tprice = Convert.ToDouble(txt_totaldata.Text);
                tb_appointment.cut = Convert.ToDouble(txt_cut.Text);
                tb_appointment.sell_add = Convert.ToDouble(txt_add.Text);
                tb_appointment.sell_date = DateTime.Now;
                tb_appointment.safe = save.Text;
                tb_appointment.invocie_id = db.tb_appointment.Any() ? db.tb_appointment.Max(x => x.invocie_id) + 1 : 1;
                tb_appointment.app_status = Convert.ToDouble(edt_pay.Text) >= Convert.ToDouble(txt_totaldata.Text)
    ? "مدفوع" : "غير مدفوع";  // ✅ أضف
                tb_appointment.LastModified = DateTime.Now;
                main frm_supp_Add = (main)Application.OpenForms["main"];
                if (frm_supp_Add != null && !string.IsNullOrEmpty(frm_supp_Add.la_username.Text))
                    tb_appointment.namecasher = frm_supp_Add.la_username.Text;

                db.tb_appointment.Add(tb_appointment);
                db.SaveChanges();

                tb_chair.totall_price = tb_appointment.sell_tprice;
                if (tb_appointment.pay == tb_appointment.sell_tprice) tb_chair.totall_price = 0;
                db.Entry(tb_chair).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                tb_Safe = db.tb_safe.Where(x => x.safe_name == save.Text).FirstOrDefault();
                tb_Safe.safe_count += Convert.ToDouble(edt_pay.Text);
                db.Entry(tb_Safe).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                LogOperation("اضافة", Convert.ToDouble(edt_pay.Text));
                ss();
                CloseBooking(); // ← جديد
            }
            else
            {
                tb_appointment = db.tb_appointment.Where(x => x.id == id).FirstOrDefault();
                tb_chair = db.tb_chair.Where(x => x.name_chair == edt_cus.Text).FirstOrDefault();
                double previousPay = Convert.ToDouble(tb_appointment.pay);

                tb_appointment.sell_cus = edt_cus.Text;
                tb_appointment.cus_id = tb_chair.id;
                tb_appointment.cus_name = edt_cusname.Text; // ← جديد
                tb_appointment.pay = Convert.ToDouble(edt_pay.Text);
                tb_appointment.sell_tprice = Convert.ToDouble(txt_totaldata.Text);
                tb_appointment.cut = Convert.ToDouble(txt_cut.Text);
                tb_appointment.sell_add = Convert.ToDouble(txt_add.Text);
                tb_appointment.sell_date = Convert.ToDateTime(edt_date.Text);
                tb_appointment.safe = save.Text;
                tb_appointment.app_status = Convert.ToDouble(edt_pay.Text) >= Convert.ToDouble(txt_totaldata.Text)
    ? "مدفوع" : "غير مدفوع";  // ✅ أضف
                tb_appointment.LastModified = DateTime.Now;
                main frm_supp_Add = (main)Application.OpenForms["main"];
                if (frm_supp_Add != null && !string.IsNullOrEmpty(frm_supp_Add.la_username.Text))
                    tb_appointment.namecasher = frm_supp_Add.la_username.Text;

                db.Entry(tb_appointment).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                prives = Convert.ToDouble(tb_appointment.sell_tprice);
                double difference = prives - curnt;
                tb_chair.totall_price += difference;
                if (tb_appointment.pay == tb_appointment.sell_tprice) tb_chair.totall_price = 0;
                db.Entry(tb_chair).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                tb_Safe = db.tb_safe.Where(x => x.safe_name == save.Text).FirstOrDefault();
                tb_Safe.safe_count += (Convert.ToDouble(edt_pay.Text) - previousPay);
                db.Entry(tb_Safe).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                LogOperation("تعديل", Convert.ToDouble(edt_pay.Text) - previousPay);
                ss();
                CloseBooking(); // ← جديد
            }
        }

        private void LogOperation(string operationType, double amount)
        {
            main user = (main)Application.OpenForms["main"];
            string casherName = user?.la_username.Text;
            var openSession = db.Sessions.FirstOrDefault(x => x.namecasher == casherName && x.IsClosed == true);
            if (openSession != null)
            {
                tb_OperationLog.SessionID = openSession.SessionID;
                tb_OperationLog.OperationType = operationType;
                tb_OperationLog.TableName = "عملية بيع صالة";
                tb_OperationLog.OldValue = openSession.ClosingAmount;
                tb_OperationLog.NewValue = Convert.ToDouble(openSession.ClosingAmount + amount);
                tb_OperationLog.AmountDifference = amount;
                db.tb_OperationLog.Add(tb_OperationLog);
                db.SaveChanges();
                openSession.ClosingAmount = tb_OperationLog.NewValue;
                db.SaveChanges();
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            toast toast = new toast();
            dialog dialog = new dialog();

            if (id == 0)
            {
                if (dataGridView1.Rows.Count - 1 != 0)
                {
                    // في أول btn_save_Click (داخل if id == 0)
                    if (string.IsNullOrWhiteSpace(edt_cusname.Text) || booking_id == 0)
                    {
                        dialog dialog2 = new dialog();
                        dialog2.txt_capthion.Text = "يجب اختيار عميل من الطابور أولاً";
                        dialog2.Show();
                        return;
                    }
                    SaveAppointmentData(true);
                    toast.txt_caption.Text = "تم اضافة عملية بيع";
                    toast.Show();
                    saveButtonClicked = true;
                    this.Close();
                }
                else
                {
                    dialog.txt_capthion.Text = "لا يمكن حفظ فاتورة بدون بيانات";
                    dialog.Show();
                }
            }
            else
            {
                SaveAppointmentData(false);
                toast.txt_caption.Text = "تم تعديل عملية بيع";
                toast.Show();
                saveButtonClicked = true;
                this.Close();
            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            list_sell = db.tb_appointment.ToList();
            dialog dialog = new dialog();

            if (id == 0)
            {
                if (id == 0 && (string.IsNullOrWhiteSpace(edt_cusname.Text) || booking_id == 0))
                {
                    dialog dialog2 = new dialog();
                    dialog2.txt_capthion.Text = "يجب اختيار عميل من الطابور أولاً";
                    dialog2.Show();
                    return;
                }
                if (dataGridView1.Rows.Count - 1 != 0)
                {
                    SaveAppointmentData(true);

                    listorder = db.tb_order_appointment.Where(x => x.sell_id == tb_appointment.id).ToList();
                    da = new DataSet1();
                    da.Tables["tb_order"].Clear();
                    int s = 1;
                    foreach (var order in listorder)
                    {
                        if (tb_service != null)
                            da.Tables["tb_order"].Rows.Add(s++, order.name_sell, order.price_sell, order.qt_sell, order.tprice_sell);
                    }

                    PrintInvoice();
                }
                else
                {
                    dialog.txt_capthion.Text = "لا يمكن حفظ فاتورة بدون بيانات";
                    dialog.Show();
                }
            }
            else
            {
                SaveAppointmentData(false);

                listorder = db.tb_order_appointment.Where(x => x.sell_id == tb_appointment.id).ToList();
                da = new DataSet1();
                da.Tables["tb_order"].Clear();
                int s = 1;
                foreach (var order in listorder)
                {
                    if (tb_service != null)
                        da.Tables["tb_order"].Rows.Add(s++, order.name_sell, order.price_sell, order.qt_sell, order.tprice_sell);
                }

                PrintInvoice();
            }
        }

        private void PrintInvoice()
        {
            var setting = db.AppSettings.FirstOrDefault(y => y.id == 1);
            using (MemoryStream ms = new MemoryStream(setting.logocomp))
            {
                XtraReport4 xtraReport3 = new XtraReport4();
                xtraReport3.totall.Text = txt_totaldata.Text;
                xtraReport3.cut.Text = txt_cut.Text;
                xtraReport3.tax.Text = txt_add.Text;
                xtraReport3.pay.Text = edt_pay.Text;
                xtraReport3.customer.Text = edt_cus.Text;
                // ← جديد: اسم العميل في الفاتورة
                xtraReport3.cusname.Text = edt_cusname.Text;
                xtraReport3.date.Text = tb_appointment.sell_date.Value.ToString("yyyy-MM-dd hh:mm tt");
                xtraReport3.namecompany.Text = setting.namecomp;
                xtraReport3.companyaddress.Text = setting.address;
                xtraReport3.companymob.Text = setting.phonenam;
                xtraReport3.invo_num.Text = tb_appointment.invocie_id.ToString();
                xtraReport3.DataSource = da;
                xtraReport3.DataMember = "tb_order";
                xtraReport3.logo.Image = Image.FromStream(ms);
                xtraReport3.PrinterName = Properties.Settings.Default.invoceprint;

                ReportPrintTool printTool = new ReportPrintTool(xtraReport3);
                saveButtonClicked = true;
                this.Close();
                printTool.AutoShowParametersPanel = false;
                printTool.PrintingSystem.StartPrint += (senderPreview, eventArgsPreview) =>
                {
                    eventArgsPreview.PrintDocument.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(25, 25, 25, 25);
                };

                if (setting.printty == "XP(fast)")
                    printTool.Print();
                else
                {
                    printTool.PreviewForm.Shown += (senderPreview, eventArgsPreview) =>
                    {
                        printTool.PreviewForm.PrintControl.Zoom = 2.5f;
                        printTool.PrintDialog();
                    };
                    printTool.ShowPreview();
                }
            }
        }

        private void frm_sell_add_FormClosing(object sender, FormClosingEventArgs e)
        {
            list_sell = db.tb_appointment.ToList();
            if (!saveButtonClicked)
            {
                try
                {
                    if (id == 0 && (string.IsNullOrWhiteSpace(edt_cusname.Text) || booking_id == 0))
                        return; // لا تحفظ لو مفيش عميل
                    if (id == 0)
                    {
                        if (dataGridView1.Rows.Count - 1 != 0)
                            SaveAppointmentData(true);
                    }
                    else
                    {
                        SaveAppointmentData(false);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

       
        private void PrintKitchen()
        {
            var setting = db.AppSettings.FirstOrDefault(y => y.id == 1);
            XtraReport5 xtraReport3 = new XtraReport5();
            xtraReport3.customer.Text = edt_cus.Text;
            xtraReport3.date.Text = tb_appointment.sell_date.Value.ToString("yyyy-MM-dd hh:mm tt");
            xtraReport3.invo_num.Text = tb_appointment.invocie_id.ToString();
            xtraReport3.DataSource = da;
            xtraReport3.DataMember = "tb_order";
            xtraReport3.PrinterName = Properties.Settings.Default.checkinprint;

            ReportPrintTool printTool = new ReportPrintTool(xtraReport3);
            saveButtonClicked = true;
            this.Close();
            if (setting.printty == "XP(fast)")
                printTool.Print();
            else
            {
                printTool.PreviewForm.Shown += (s, ev) => { printTool.PreviewForm.PrintControl.Zoom = 2.5f; printTool.PrintDialog(); };
                printTool.ShowPreview();
            }
        }

      

        private void PrintBarista()
        {
            var setting = db.AppSettings.FirstOrDefault(y => y.id == 1);
            XtraReport6 xtraReport3 = new XtraReport6();
            xtraReport3.customer.Text = edt_cus.Text;
            xtraReport3.date.Text = tb_appointment.sell_date.Value.ToString("yyyy-MM-dd hh:mm tt");
            xtraReport3.invo_num.Text = tb_appointment.invocie_id.ToString();
            xtraReport3.DataSource = da;
            xtraReport3.DataMember = "tb_order";
            xtraReport3.PrinterName = Properties.Settings.Default.parstaprint;

            ReportPrintTool printTool = new ReportPrintTool(xtraReport3);
            saveButtonClicked = true;
            this.Close();
            if (setting.printty == "XP(fast)")
                printTool.Print();
            else
            {
                printTool.PreviewForm.Shown += (s, ev) => { printTool.PreviewForm.PrintControl.Zoom = 2.5f; printTool.PrintDialog(); };
                printTool.ShowPreview();
            }
        }

        private void txt_cut_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_cut.Text)) txt_cut.Text = "0";
            pro_call();
            if (comboBox1.Text == "نقدى") edt_pay.Text = txt_totaldata.Text;
        }

        private void txt_add_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_add.Text)) txt_add.Text = "0";
            pro_call();
            if (comboBox1.Text == "نقدى") edt_pay.Text = txt_totaldata.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "نقدى") edt_pay.Text = txt_totaldata.Text;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            int idb = Convert.ToInt32(tileView2.GetFocusedRowCellValue("id"));
            tb_service = db.tb_service.Where(x => x.id == idb).FirstOrDefault();
            textBox1.Text = tb_service.name_product.ToString();
            edt_sell.Text = tb_service.cost.ToString();
        }

        private void btn_ChangeTable_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_table.Text)) { MessageBox.Show("لا يوجد مقعد لى التحويل عليها"); return; }
            var opentable = db.tb_chair.Where(x => x.name_chair == edt_table.Text).FirstOrDefault();
            if (opentable == null) { MessageBox.Show("يرجى اختيارمقعد مفتوح من القائمة"); return; }

            tb_chair = db.tb_chair.Where(x => x.name_chair == edt_cus.Text).FirstOrDefault();
            tb_chair.totall_price = 0;
            db.Entry(tb_chair).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            edt_cus.Text = edt_table.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var _search = textBox1.Text;
                var results = db.tb_service
                    .Where(x => x.name_product.Contains(_search) || x.name_product.StartsWith(_search + " ") || x.name_product.EndsWith(" " + _search))
                    .ToList();
                gridControl1.DataSource = results;
            }
            catch { }
        }

        private bool isSpacePressed = false;
        private void frm_sell_add_KeyDown(object sender, KeyEventArgs e)
        {
            string keyPressed = e.KeyCode.ToString().ToLower();
            if (keyPressed == "space") { isSpacePressed = true; }
            else if (((keyPressed == "p" || keyPressed == "ب") && isSpacePressed) || e.KeyCode == Keys.F2)
            { btn_print.PerformClick(); isSpacePressed = false; }
            else if (e.KeyCode == Keys.F1)
            { btn_save.PerformClick(); isSpacePressed = false; }
           
        }

       

        private void edt_code_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var tb_service = db.tb_service.Where(x => x.code == edt_code.Text).FirstOrDefault();
                if (tb_service != null)
                {
                    textBox1.Text = tb_service.name_product.ToString();
                    edt_sell.Text = tb_service.cost.ToString();
                    edt_qt.Value = 1;
                    btn_add_Click_1(this, EventArgs.Empty);
                }
            }
            catch { }
        }

        private void edt_pay_TextChanged(object sender, EventArgs e)
        {
            pro_call();
            if (string.IsNullOrWhiteSpace(edt_pay.Text)) edt_pay.Text = "0";
        }

        private void txt_total_TextChanged(object sender, EventArgs e) { pro_call(); }
        private void edt_sell_TextChanged_1(object sender, EventArgs e) { }
        private void edt_table_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txt_id_Click(object sender, EventArgs e) { }

        public List<tb_appointment> list_sell;
        public int CurrentInvoiceIndex { get; set; }
        public List<tb_appointment> Invoices { get; set; }

        public void ss()
        {
            if (id == 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    var order = new tb_order_appointment
                    {
                        sell_id = tb_appointment.id,
                        name_sell = dataGridView1.Rows[i].Cells[0].Value.ToString(),
                        price_sell = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value),
                        qt_sell = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value),
                        tprice_sell = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value),
                        newqt = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value)
                    };
                    try { db.tb_order_appointment.Add(order); db.SaveChanges(); }
                    catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
                }
            }
            else
            {
                var ordersToRemove = db.tb_order_appointment.Where(x => x.sell_id == id).ToList();
                if (ordersToRemove.Any()) { db.tb_order_appointment.RemoveRange(ordersToRemove); db.SaveChanges(); }

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    var order = new tb_order_appointment
                    {
                        sell_id = tb_appointment.id,
                        name_sell = dataGridView1.Rows[i].Cells[0].Value.ToString(),
                        price_sell = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value),
                        qt_sell = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value),
                        tprice_sell = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value),
                        newqt = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value)
                    };
                    try { db.tb_order_appointment.Add(order); db.SaveChanges(); }
                    catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
                }
            }
        }

        private void pro_call()
        {
            double sum = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);

            tot_buy.Text = "0";
            totall_buy.Text = sum.ToString();
            txt_totaldata.Text = (sum + Convert.ToDouble(txt_add.Text) - Convert.ToDouble(txt_cut.Text)).ToString();
        }
    }
}