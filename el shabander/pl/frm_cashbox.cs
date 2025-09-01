using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using el_shabander.epl;
using DevExpress.XtraGrid.Views.Grid;
namespace el_shabander.pl
{
    public partial class frm_cashbox : Form
    {
        DB_restoraintEntities db = new DB_restoraintEntities();
       
        Session session = new Session();
        bl.methods methods = new bl.methods();
        toast toast = new toast();
        tb_user tb_User = new tb_user();
        int id;
        public frm_cashbox()
        {
            InitializeComponent();







            
            el_shabander.DB_restoraintEntities dbContext = new el_shabander.DB_restoraintEntities();
            // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
            dbContext.Sessions.LoadAsync().ContinueWith(loadTask =>
            {
    // Bind data to control when loading complete
    gridControl1.DataSource = dbContext.Sessions.Local.ToBindingList();
            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
            gridView1.OptionsBehavior.Editable = false;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            var idValue = gridView1.GetFocusedRowCellValue("SessionID");
            if (idValue == null)
            {
                MessageBox.Show("لم يتم اختيار صف صحيح.");
                return;
            }

            int id = Convert.ToInt32(idValue);

            var session = db.Sessions.FirstOrDefault(x => x.SessionID == id);
            if (session == null)
            {
                MessageBox.Show($"لا يوجد جلسة بالرقم: {id}");
                return;
            }

            pl.frm_detalscashbox frm_supp_Add = new pl.frm_detalscashbox();
            frm_supp_Add.id = session.SessionID;
            frm_supp_Add.updata_data();
            frm_supp_Add.Show();

        }

        private void btn_updata_Click(object sender, EventArgs e)
        {
            updata_data();
        }

       

        public void updata_data()
        {
            db = new DB_restoraintEntities();
            main frm_supp_Add = (main)Application.OpenForms["main"];
            string casherName = frm_supp_Add?.la_username.Text;
            List<Session> data = db.Sessions.Where(x=>x.namecasher== frm_supp_Add.la_username.Text).ToList();
            
            data.Reverse();
            gridControl1.DataSource = data;
            var r2 = db.tb_user.Select(x => x.user_name).ToList();
            edt_namecasher.DataSource = r2;
            AutoCompleteStringCollection acsc2 = new AutoCompleteStringCollection();
            acsc2.AddRange(r2.ToArray());
            edt_namecasher.AutoCompleteCustomSource = acsc2;
            ApplyArabicCulture();

            // ضبط DateTimePicker
            SetArabicDateFormat(edt_from);
            bool hasOpenSession = data.Any(x => x.IsClosed == true);

            // لو كل الجلسات مغلقة (مافيش جلسة مفتوحة)
            if (hasOpenSession)
            {
                btn_open.Appearance.BackColor = Color.Red;
                btn_open.Appearance.ForeColor = Color.White;
                var openSession = db.Sessions.FirstOrDefault(x => x.namecasher == casherName && x.IsClosed == true);
                edt_add.Text = openSession.OpeningAmount.ToString();
                btn_open.Text = "قفل";
                edt_add.Enabled = false;
            }
            else
            {
                btn_open.Appearance.BackColor = Color.Green;
                btn_open.Appearance.ForeColor = Color.White;
                edt_add.Text = "0";
                btn_open.Text = "فتح"; // أو أي نص تاني حسب حالته
                edt_add.Enabled = true;
            }

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

        // دالة لتنسيق التاريخ يدويًا باللغة العربية
        private string GetArabicFormattedDate(DateTime date)
        {
            string[] arabicDays = { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" };
            string[] arabicMonths = { "", "يناير", "فبراير", "مارس", "أبريل", "مايو", "يونيو", "يوليو", "أغسطس", "سبتمبر", "أكتوبر", "نوفمبر", "ديسمبر" };

            string dayName = arabicDays[(int)date.DayOfWeek];
            string monthName = arabicMonths[date.Month];

            return $"{dayName}, {date.Day} {monthName} {date.Year}";
        }

       

        private void gridControl1_Click(object sender, EventArgs e)
        {
           
        }

        private void frm_safe_as_Load(object sender, EventArgs e)
        {
            timer1.Start();
           

        }

        private void frm_safe_as_Activated(object sender, EventArgs e)
        {
           
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            toast toast = new toast();
            dialog dialog = new dialog();

            main frm_supp_Add = (main)Application.OpenForms["main"];
            string casherName = frm_supp_Add?.la_username.Text;

            if (string.IsNullOrEmpty(casherName))
            {
                MessageBox.Show("يرجى تسجيل الدخول أولاً");
                return;
            }

            // نبحث إذا فيه جلسة مفتوحة لهذا الكاشر
            var openSession = db.Sessions.FirstOrDefault(x => x.namecasher == casherName && x.IsClosed == true);

            if (openSession == null)
            {
                // مفيش جلسة مفتوحة - نفتح جلسة جديدة
                session.StartTime = DateTime.Now;
                session.EndTime = null;
                session.IsClosed = true;
                session.OpeningAmount = Convert.ToDouble(edt_add.Text);
                session.ClosingAmount = Convert.ToDouble(edt_add.Text);
                session.namecasher = casherName;

                db.Sessions.Add(session);
                db.SaveChanges();

                toast.txt_caption.Text = "تم فتح الكاش بوكس";
               
            }
            else
            {
                // فيه جلسة مفتوحة - نغلقها
                openSession.EndTime = DateTime.Now;
                openSession.IsClosed = false; // عكس الفتح حسب منطقك
                db.SaveChanges();

                toast.txt_caption.Text = "تم غلق الكاش بوكس";
                
            }

            toast.Width = this.Width;
            toast.Show();

            // تحديث البيانات في الجريد
            updata_data();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            time.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        }
        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0)
            {
                var session = view.GetRow(e.RowHandle) as Session;
                if (session != null)
                {
                    if (session.EndTime != null) // الجلسة مقفولة
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                    }
                    else // الجلسة مفتوحة
                    {
                        e.Appearance.BackColor = Color.Green;
                        e.Appearance.ForeColor = Color.White;
                    }
                }
            }
        }

        private void edt_add_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_add.Text))
            {
                // إذا كانت القيمة فارغة، يمكنك تعيين القيمة الافتراضية مرة أخرى
                edt_add.Text = "0";
            }
        }

        private void btn_serchcasher_Click(object sender, EventArgs e)
        {
            var search = edt_namecasher.Text;
            List<Session> data = db.Sessions.Where(x => x.namecasher == search) .ToList();
            data.Reverse();
            gridControl1.DataSource = data;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var _search = edt_from.Value.Date;
            main frm_supp_Add = (main)Application.OpenForms["main"];
            string casherName = frm_supp_Add?.la_username.Text;
            List<Session> data = db.Sessions.Where(x => DbFunctions.TruncateTime(x.StartTime) == _search&&x.namecasher==casherName).ToList();
            data.Reverse();
            gridControl1.DataSource = data;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            btn_add_Click(sender, e);
        }
    }
}
