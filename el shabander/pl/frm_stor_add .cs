using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using el_shabander.epl;

namespace el_shabander.pl
{
    public partial class frm_stor_add: Form
    {
        DB_BarbershopEntities db = new DB_BarbershopEntities();
        tb_stor tb_Stor = new tb_stor();
        bl.methods methods = new bl.methods();
        tb_safe tb_Safe = new tb_safe();
       // tb_employees tb_Employees = new tb_employees();
        Notfication notfication = new Notfication();
        bl.send send = new bl.send();
        tb_OperationLog tb_OperationLog = new tb_OperationLog();
        DateTime time;
        //pl.frm_supp frm_Cat = new frm_supp();
        public int id;
        public string edt_name_old, edt_type_old;
        public double curnt, prives, safeou;
        public frm_stor_add ()

        {
            InitializeComponent();
        }
        private void ApplyArabicCulture()
        {
            CultureInfo arabicCulture = new CultureInfo("ar-EG");
            Thread.CurrentThread.CurrentCulture = arabicCulture;
            Thread.CurrentThread.CurrentUICulture = arabicCulture;
        }
        private void SetArabicDateFormat(DateTimePicker picker)
        {
            picker.Format = DateTimePickerFormat.Custom;
            picker.CustomFormat = GetArabicFormattedDate(picker.Value);

            // إجبار النصوص على أن تكون باللغة العربية وعدم الانعكاس
            picker.RightToLeft = RightToLeft.No;
            picker.RightToLeftLayout = false;

            // تحديث عند تغيير التاريخ
            picker.ValueChanged += (s, e) =>
            {
                picker.CustomFormat = GetArabicFormattedDate(picker.Value);
            };
        }
        private string GetArabicFormattedDate(DateTime date)
        {
            string[] arabicDays = { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" };
            string[] arabicMonths = { "", "يناير", "فبراير", "مارس", "أبريل", "مايو", "يونيو", "يوليو", "أغسطس", "سبتمبر", "أكتوبر", "نوفمبر", "ديسمبر" };

            string dayName = arabicDays[(int)date.DayOfWeek];
            string monthName = arabicMonths[date.Month];

            return $"{dayName}, {date.Day} {monthName} {date.Year}";
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            toast toast = new toast();
            dialog dialog = new dialog();
          
             if (Convert.ToDouble(edt_spen.Text) <= 0)
            {
                MessageBox.Show("الرجاء ادخال مبلغ اكبر من الصفر.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // الخروج من العملية إذا لم يتم العثور على العميل
            }
            else
            {
                if (id == 0)
                {
                    // pic_cover.Image.Save(methods.ma, System.Drawing.Imaging.ImageFormat.Png);
                //  tb_Stor.stor_empname = edt_name.Text;
                    tb_Stor.stor_type = edt_type.Text;
                    tb_Stor.stor_spen = Convert.ToDouble(edt_spen.Text);

                    time = Convert.ToDateTime(edt_date.Text);
                    tb_Stor.stor_dete = time;
                    tb_Stor.stor_det = edt_dat.Text;
                    tb_Stor.safe_name = edt_safe.Text;
                    main frm_supp_Add = (main)Application.OpenForms["main"];
                    if (frm_supp_Add != null)
                    {
                        // التحقق من أن la_roll يحتوي على قيمة
                        if (!string.IsNullOrEmpty(frm_supp_Add.la_username.Text))
                        {
                            tb_Stor.namecasher = frm_supp_Add.la_username.Text;
                        }
                    }
                    db.tb_stor.Add(tb_Stor);
                    db.SaveChanges();
                    

                    // tb_Safe.id = id;
                    if (edt_safe.Text == tb_Safe.safe_name)
                    {
                        tb_Safe.safe_count = Convert.ToDouble(edt_countsafe.Text) - Convert.ToDouble(edt_spen.Text);
                        // db.tb_safe.Add(tb_Safe);
                        db.Entry(tb_Safe).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    main user = (main)Application.OpenForms["main"];
                    string casherName = user?.la_username.Text;
                    var openSession = db.Sessions.FirstOrDefault(x => x.namecasher == casherName && x.IsClosed == true);
                    if (openSession != null)
                    {
                        tb_OperationLog.SessionID = openSession.SessionID;
                        tb_OperationLog.OperationType = "اضافة";
                        tb_OperationLog.TableName = "عملية مصاريف";
                        tb_OperationLog.OldValue = openSession.ClosingAmount;
                        tb_OperationLog.NewValue = Convert.ToDouble(openSession.ClosingAmount - Convert.ToDouble(edt_spen.Text));
                        tb_OperationLog.AmountDifference = -Convert.ToDouble(edt_spen.Text);
                        db.tb_OperationLog.Add(tb_OperationLog);
                        db.SaveChanges();

                        openSession.ClosingAmount = tb_OperationLog.NewValue;

                        db.SaveChanges();

                    }
                    toast.Width = this.Width;
                    toast.txt_caption.Text = "تم اضافة مصاريف جديد";
                    toast.Show();
                    this.Close();

                }
                else
                {
                    tb_Stor = db.tb_stor.Where(x => x.id == id).FirstOrDefault();
                    tb_Stor.id = id;

                   // tb_Stor.stor_empname = edt_name.Text;
                    tb_Stor.stor_type = edt_type.Text;
                    tb_Stor.stor_spen = Convert.ToDouble(edt_spen.Text);


                    tb_Stor.stor_dete = Convert.ToDateTime(edt_date.Text);
                    tb_Stor.stor_det = edt_dat.Text;
                    tb_Stor.safe_name = edt_safe.Text;
                    main frm_supp_Add = (main)Application.OpenForms["main"];
                    if (frm_supp_Add != null)
                    {
                        // التحقق من أن la_roll يحتوي على قيمة
                        if (!string.IsNullOrEmpty(frm_supp_Add.la_username.Text))
                        {
                            tb_Stor.namecasher = frm_supp_Add.la_username.Text;
                        }
                    }
                  
                    tb_Safe = db.tb_safe.Where(x => x.safe_name == edt_safe.Text).FirstOrDefault();
                    tb_Safe.safe_count += safeou;
                    tb_Safe.safe_count -= Convert.ToDouble(edt_spen.Text);

                    db.Entry(tb_Safe).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    main user = (main)Application.OpenForms["main"];
                    string casherName = user?.la_username.Text;
                    var openSession = db.Sessions.FirstOrDefault(x => x.namecasher == casherName && x.IsClosed == true);
                    if (openSession != null)
                    {
                        tb_OperationLog.SessionID = openSession.SessionID;
                        tb_OperationLog.OperationType = "تعديل";
                        tb_OperationLog.TableName = "عملية مصاريف";
                        tb_OperationLog.OldValue = openSession.ClosingAmount;
                        tb_OperationLog.NewValue = Convert.ToDouble(openSession.ClosingAmount - (Convert.ToDouble(edt_spen.Text)- safeou));
                        tb_OperationLog.AmountDifference = safeou - Convert.ToDouble(edt_spen.Text);
                        db.tb_OperationLog.Add(tb_OperationLog);
                        db.SaveChanges();

                        openSession.ClosingAmount = tb_OperationLog.NewValue;

                        db.SaveChanges();

                    }

                    string notificationMessage = $"لقد قام :  {frm_supp_Add.la_username.Text}   بتعديل مصاريف خارجة باسم الموظف : {tb_Stor.stor_empname} وقيم المبلغ : {tb_Stor.stor_spen}  ";
                    send.SendEmailWithHtmlGridData(notificationMessage);
                    notfication.notfication1 = notificationMessage;
                    notfication.CreatedAt = DateTime.Now;


                    db.Notfications.Add(notfication);
                    db.SaveChanges();
                    toast.txt_caption.Text = "تم تعديل مصاريف جديد";
                    toast.Show();
                    this.Close();
                }

            }
        }

        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void edt_salery_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_spen.Text))
            {
                // إذا كانت القيمة فارغة، يمكنك تعيين القيمة الافتراضية مرة أخرى
                edt_spen.Text = "0";
            }
            if (tb_Safe.safe_count == 0f)
            {
                edt_many.Visible = true;
                edt_countsafe.Visible = false;
                
            }
            else
            {
                edt_countsafe.Visible = true;
                edt_many.Visible = false;
            }
           // edt_countsafe.Text =(Convert.ToDouble(edt_countsafe.Text) - Convert.ToDouble(edt_spen.Text)).ToString();
            sumsaler();
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
            if(id == 0)
            {
                var r1 = db.tb_employees.Select(x => x.emp_name).ToList();
                var r2 = db.tb_safe.Select(x => x.safe_name).ToList();
              //  edt_name.DataSource = r1;
                edt_safe.DataSource = r2;
                AutoCompleteStringCollection acsc1 = new AutoCompleteStringCollection();
                AutoCompleteStringCollection acsc2 = new AutoCompleteStringCollection();
                acsc1.AddRange(r1.ToArray());
                acsc2.AddRange(r2.ToArray());
              //  edt_name.AutoCompleteCustomSource = acsc1;
                edt_safe.AutoCompleteCustomSource = acsc2;
                edt_date.Text = (DateTime.Now).ToString();
               
                edt_type.Text = "اخرى";
            }
            else
            {

                var tb_Stor = db.tb_stor.Where(x => x.id == id).FirstOrDefault();
                // curnt = Convert.ToDouble(tb_Stor.stor_spen);
                safeou = Convert.ToDouble(tb_Stor.stor_spen);
                edt_name_old = tb_Stor.stor_empname;
                edt_type_old = tb_Stor.stor_type;

            }
        }

        private void edt_name_SelectedIndexChanged(object sender, EventArgs e)
        {
           // tb_Employees = db.tb_employees.Where(x => x.emp_name == edt_name.Text).FirstOrDefault();

        }

        private void frm_stor_add_Load(object sender, EventArgs e)
        {

        }

        private void edt_safe_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_Safe = db.tb_safe.Where(x => x.safe_name == edt_safe.Text).FirstOrDefault();
            edt_countsafe.Text = tb_Safe.safe_count.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(edt_many.Visible == true)
            {
                this.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void sumsaler()
        {
           /*storspen = Convert.ToDouble(edt_spen.Text);
            stortotal =Convert.ToDouble(tb_Safe.safe_count);
            storstay = stortotal - storspen;
            tb_Safe.safe_count = storstay;*/
            
        }
    }
}
