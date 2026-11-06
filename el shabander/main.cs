using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using static DevExpress.Utils.Drawing.Helpers.NativeMethods;
using Timer = System.Windows.Forms.Timer;
using System.Media;
using DevExpress.LookAndFeel;
using System.Data.Entity;

namespace el_shabander
{
    public partial class main : Form
    {
        pl.frm_cat frm_Cat = new pl.frm_cat();
        pl.frm_supp frm_supp = new pl.frm_supp();
        pl.frm_home frm_home =new pl.frm_home();
        pl.frm_pur frm_Pur = new pl.frm_pur();
        pl.frm_cus frm_cus = new pl.frm_cus();
        pl.frm_cus_out frm_cus_out = new pl.frm_cus_out();
        pl.frm_sell frm_sell = new pl.frm_sell();
        pl.frm_report frm_report = new pl.frm_report();
        pl.frm_user frm_user = new pl.frm_user();
        pl.frm_stuk frm_stuk = new pl.frm_stuk();
        pl.frm_stor frm_Stor = new pl.frm_stor();
        pl.frm_safe_as frm_safe_as= new pl.frm_safe_as();
        pl.frm_shift_motion frm_Shift_Motion = new pl.frm_shift_motion();
        pl.frm_cashbox cashbox = new pl.frm_cashbox();
        pl.frm_booking frm_booking = new pl.frm_booking();
        pl.Attendanceemp Attendanceemp = new pl.Attendanceemp();
        pl.frm_Salaries frm_Salaries = new pl.frm_Salaries();
        private  DateTime trialStartDate;
        private Timer notificationTimer;
        pl.frm_employees frm_Employees = new pl.frm_employees();
        tb_user tB_user = new tb_user();
        int lastNotificationId = 0;
        // pl.frm_login login = new pl.frm_login();
        DB_BarbershopEntities db = new DB_BarbershopEntities();
        private System.Timers.Timer emailTimer;
        private readonly ApiSyncService _syncService = new ApiSyncService();
        private DateTime _lastSyncTime = DateTime.Now.AddMinutes(-11);
        private System.Threading.Timer _syncTimer;
        public main()
        {
            InitializeComponent();

            // Update the user state to "Closed" when the application starts

            // trialStartDate = DateTime.Now;

           
            CheckUserStatesAtStartup();
            emailTimer = new System.Timers.Timer(Properties.Settings.Default.EmailInterval * 60 * 60 * 1000); // 3 ساعات بالمللي ثانية
            emailTimer.Elapsed += OnTimedEvent;
            emailTimer.AutoReset = true; // إعادة تعيين المؤقت تلقائيًا
            emailTimer.Enabled = true;

            notificationTimer = new Timer();
            notificationTimer.Interval = 3000; // كل 5 ثوانٍ
            notificationTimer.Tick += NotificationTimer_Tick;
            notificationTimer.Start();

        }
        // ========== Helper: حسابات tb_booking ==========
        private void LoadBookingStats()
        {
            DateTime today = DateTime.Today;

            // عدد العملاء الفريدين (بدون تكرار برقم التليفون)
            int uniqueCustomers = db.tb_booking
                .Select(x => x.cus_phone)
                .Distinct()
                .Count();

            // حجوزات اليوم - انتظار
            int todayWaiting = db.tb_booking
                .Count(x => DbFunctions.TruncateTime(x.booking_date) == today
                         && x.status == "انتظار");

            // حجوزات اليوم - تم
            int todayDone = db.tb_booking
                .Count(x => DbFunctions.TruncateTime(x.booking_date) == today
                         && x.status == "تم");

            // ========== tileItem1 ==========
            frm_home.tileItem1.Frames[2].Elements[1].Text = uniqueCustomers.ToString();

            // ========== tileItem2 - الانتظار/تم اليوم ==========
            frm_home.tileItem2.Frames[2].Elements[2].Text = $"{todayWaiting}";
            frm_home.tileItem2.Frames[2].Elements[5].Text = $"{todayDone}";

            // ========== tileItem6 ==========
            frm_home.tileItem6.Frames[3].Elements[2].Text = $"{todayWaiting}";
            frm_home.tileItem6.Frames[3].Elements[4].Text = $"{todayDone}";

            // ========== tileItem10 ==========
            frm_home.tileItem10.Frames[0].Elements[2].Text = uniqueCustomers.ToString();

            // ========== tileItem4 ==========
            frm_home.tileItem4.Frames[3].Elements[2].Text = $"{todayWaiting}";
            frm_home.tileItem4.Frames[3].Elements[5].Text = $"{todayDone}";

            // ========== tileItem7 ==========
            frm_home.tileItem7.Frames[2].Elements[2].Text = uniqueCustomers.ToString();
        }
        private void main_Load(object sender, EventArgs e)
        {
            pn_cont.Controls.Clear();
            pn_cont.Controls.Add(frm_home.tileControl1);

            frm_home.tileItem1.Frames[0].Elements[1].Text = db.tb_supp.Count().ToString();
            frm_home.tileItem1.Frames[1].Elements[1].Text = db.tb_employees.Count().ToString();

            frm_home.tileItem2.Frames[0].Elements[2].Text = db.tb_chair.Where(x => x.totall_price > 0).Count().ToString();
            frm_home.tileItem2.Frames[0].Elements[5].Text = db.tb_chair.Where(x => x.totall_price == 0).Count().ToString();
            frm_home.tileItem2.Frames[1].Elements[2].Text = db.tb_buy.Count().ToString();
            frm_home.tileItem2.Frames[3].Elements[2].Text = db.tb_cat.Count().ToString();

            frm_home.tileItem6.Frames[2].Elements[2].Text = db.tb_buy.Count().ToString();
            frm_home.tileItem6.Frames[0].Elements[2].Text = db.tb_chair.Where(x => x.totall_price > 0).Count().ToString();
            frm_home.tileItem6.Frames[0].Elements[4].Text = db.tb_chair.Where(x => x.totall_price == 0).Count().ToString();
            frm_home.tileItem6.Frames[1].Elements[2].Text = db.tb_cat.Count().ToString();

            frm_home.tileItem10.Frames[1].Elements[2].Text = db.tb_supp.Count().ToString();
            frm_home.tileItem10.Frames[2].Elements[2].Text = db.tb_employees.Count().ToString();

            frm_home.tileItem4.Frames[2].Elements[2].Text = db.tb_buy.Count().ToString();
            frm_home.tileItem4.Frames[1].Elements[2].Text = db.tb_chair.Where(x => x.totall_price > 0).Count().ToString();
            frm_home.tileItem4.Frames[1].Elements[5].Text = db.tb_chair.Where(x => x.totall_price == 0).Count().ToString();
            frm_home.tileItem4.Frames[0].Elements[2].Text = db.tb_cat.Count().ToString();

            frm_home.tileItem7.Frames[1].Elements[2].Text = db.tb_supp.Count().ToString();
            frm_home.tileItem7.Frames[0].Elements[2].Text = db.tb_employees.Count().ToString();

            // ← استدعاء الدالة الجديدة
            LoadBookingStats();

            // ابدأ التايمر - كل 10 دقايق يبعت للسيرفر
            _syncTimer = new System.Threading.Timer(
                async _ => await SyncAllDataAsync(),
                null,
                TimeSpan.FromMinutes(1),   // استنى دقيقة الأول عشان البرنامج يقوم
                TimeSpan.FromMinutes(1)   // كرر كل 10 دقايق
            );

            lb_titelpage.Text = " EngineeCode ";
            StoreSerialNumber();

            if (la_roll.Text=="مدير")
            {
               
               
            }
            else
            {
                cashbox.btn_serchcasher.Visible = false;
                cashbox.edt_namecasher.Visible = false;
                frm_Cat.btn_edit.Enabled = false;
                frm_Cat.btn_delete.Enabled = false;
                simpleButton13.Visible = false;
                simpleButton2.Visible = false;
                btn_employees.Visible = false;
                frm_report.tileItem8.Visible = false;
                Attendanceemp.btn_close.Enabled = false;
                Attendanceemp.btn_open.Enabled = false;
                frm_Salaries.gridControl_Salaries.Enabled = false;
                frm_Salaries.groupControl2.Enabled = false;

            }

            if (Properties.Settings.Default.isfirestopen == true)
            {
                Properties.Settings.Default.TrialStartDate = DateTime.Now;
                Properties.Settings.Default.isfirestopen = false;
                Properties.Settings.Default.Save();
            }
            trialStartDate = Properties.Settings.Default.TrialStartDate;
            CheckTrialExpiration(trialStartDate, la_trile);

        }

        private async Task SyncAllDataAsync()
        {
            var syncFrom = Properties.Settings.Default.LastSyncTime;
            if (syncFrom == DateTime.MinValue)
                syncFrom = DateTime.Now.AddMinutes(-11);
            try
            {
                using (var dbSync = new DB_BarbershopEntities())
                {
                    var today = DateTime.Today;



                    var appointments = dbSync.tb_appointment
                 .Where(x => x.invocie_id.HasValue && x.LastModified >= syncFrom)
                 .ToList();

                    if (appointments.Any())
                        await _syncService.SyncAppointmentsAsync(appointments);


                    var allAttendance = dbSync.Attendances
    .Where(x => x.AttendDate.HasValue && x.EmployeeId.HasValue)
    .ToList();

                    if (allAttendance.Any())
                        await _syncService.SyncAttendanceAsync(allAttendance);


                  

                    // ✅ بعت كل الـ IDs الموجودة محلياً — مش بس اليوم
                    var allLocalInvoiceIds = dbSync.tb_appointment
                        .Where(x => x.invocie_id.HasValue)
                        .Select(x => x.invocie_id.Value)
                        .ToList();

                    var allLocalAttendanceIds = dbSync.Attendances
                        .Where(x => x.EmployeeId.HasValue)
                        .Select(x => x.EmployeeId.Value)
                        .Distinct()
                        .ToList();

                    await _syncService.SyncDeletedAppointmentsAsync(allLocalInvoiceIds);
                    await _syncService.SyncDeletedAttendanceAsync(allLocalAttendanceIds);
                }

                if (DateTime.Now.Hour == 0 && DateTime.Now.Minute < 3)
                    await _syncService.CleanupOldDataAsync();
                _lastSyncTime = DateTime.Now;
                Properties.Settings.Default.LastSyncTime = _lastSyncTime;
                Properties.Settings.Default.Save();
                this.Invoke((Action)(() =>
                {
                    lb_titelpage.Text = $"آخر مزامنة: {DateTime.Now:hh:mm tt}";
                  
                }));
            }
            catch (Exception ex)
            {
                this.Invoke((Action)(() =>
                {
                    lb_titelpage.Text = $"❌ خطأ: {ex.Message}";
                }));
            }
        }
        private void NotificationTimer_Tick(object sender, EventArgs e)
        {
            CheckForNewNotifications();
        }
        private void CheckForNewNotifications()
        {
            using (var dbNew = new DB_BarbershopEntities()) // يفضل context جديد عشان البيانات تكون فريش
            {
                // هات الإشعارات اللي الـ ID بتاعها أكبر من آخر واحد شفناه
                var newNotifications = dbNew.Notfications
                                            .Where(n => n.id > lastNotificationId)
                                            .ToList();

                if (newNotifications.Count > 0)
                {
                    // 1. تحديث آخر ID عشان المرة الجاية ما يكررش نفس الإشعارات
                    lastNotificationId = newNotifications.Max(n => n.id);
                    foreach (var notif in newNotifications)
                    {
                        _ = _syncService.SendNotificationAsync(notif.notfication1);
                    }
                    // 2. تحديث العداد (نزود عدد الإشعارات الجديدة اللي جت فعلاً)
                    int currentCount = 0;
                    int.TryParse(lblNotificationCount.Text, out currentCount);

                    lblNotificationCount.Text = (currentCount + newNotifications.Count).ToString();
                    lblNotificationCount.Visible = true;

                    // 3. تشغيل الصوت
                    PlayNotificationSound();
                }
            }
        }
        private void PlayNotificationSound()
        {
            try
            {
                // قم بتحميل ملف الصوت من مسار المشروع أو من مسار محدد
                SoundPlayer player = new SoundPlayer(@"sound\notification.wav");

                // تشغيل الصوت
                player.Play();
            }
            catch (Exception ex)
            {
                // في حالة حدوث خطأ، يمكنك عرض رسالة أو تجاهلها
                MessageBox.Show("حدث خطأ أثناء محاولة تشغيل الصوت: " + ex.Message);
            }
        }
        private void pn_cont_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        

       

        private void btn_collaps_Click(object sender, EventArgs e)
        {
            if (pn_navbar.Width == 250)
            {
                pn_navbar.Width = 50;
                pn_titelnavbar.Visible = false;
               pn_headernavbar.Height = 150;
            }
            else
            {
                pn_navbar.Width = 250;
                pn_titelnavbar.Visible = true;
                pn_headernavbar.Height = 200;
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            pn_cont.Controls.Clear();
            pn_cont.Controls.Add(frm_home.tileControl1);
            db = new DB_BarbershopEntities();

            frm_home.tileItem1.Frames[0].Elements[1].Text = db.tb_supp.Count().ToString();
            frm_home.tileItem1.Frames[1].Elements[1].Text = db.tb_employees.Count().ToString();

            frm_home.tileItem2.Frames[0].Elements[2].Text = db.tb_chair.Where(x => x.totall_price > 0).Count().ToString();
            frm_home.tileItem2.Frames[0].Elements[5].Text = db.tb_chair.Where(x => x.totall_price == 0).Count().ToString();
            frm_home.tileItem2.Frames[1].Elements[2].Text = db.tb_buy.Count().ToString();
            frm_home.tileItem2.Frames[3].Elements[2].Text = db.tb_cat.Count().ToString();

            frm_home.tileItem6.Frames[2].Elements[2].Text = db.tb_buy.Count().ToString();
            frm_home.tileItem6.Frames[0].Elements[2].Text = db.tb_chair.Where(x => x.totall_price > 0).Count().ToString();
            frm_home.tileItem6.Frames[0].Elements[4].Text = db.tb_chair.Where(x => x.totall_price == 0).Count().ToString();
            frm_home.tileItem6.Frames[1].Elements[2].Text = db.tb_cat.Count().ToString();

            frm_home.tileItem10.Frames[1].Elements[2].Text = db.tb_supp.Count().ToString();
            frm_home.tileItem10.Frames[2].Elements[2].Text = db.tb_employees.Count().ToString();

            frm_home.tileItem4.Frames[2].Elements[2].Text = db.tb_buy.Count().ToString();
            frm_home.tileItem4.Frames[1].Elements[2].Text = db.tb_chair.Where(x => x.totall_price > 0).Count().ToString();
            frm_home.tileItem4.Frames[1].Elements[5].Text = db.tb_chair.Where(x => x.totall_price == 0).Count().ToString();
            frm_home.tileItem4.Frames[0].Elements[2].Text = db.tb_cat.Count().ToString();

            frm_home.tileItem7.Frames[1].Elements[2].Text = db.tb_supp.Count().ToString();
            frm_home.tileItem7.Frames[0].Elements[2].Text = db.tb_employees.Count().ToString();

            // ← استدعاء الدالة الجديدة
            LoadBookingStats();

           
            lb_titelpage.Text = " EngineeCode ";
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            pn_cont.Controls.Clear();
            pn_cont.Controls.Add(frm_Cat.pn_cat);
            db = new DB_BarbershopEntities();
            frm_Cat.updata_data();
            lb_titelpage.Text = "الاصناف";
           frm_Cat.gridControl1.DataSource = db.tb_cat.ToList();
        
        }

        private void pn_topbar_Paint(object sender, PaintEventArgs e)
        {

        }
       
        private void btn_close_Click_1(object sender, EventArgs e)
        {
            UpdateUserState("مغلق");

            Application.Exit();
           

        }

        private void btn_max_Click_1(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void btn_min_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btn_supp_Click(object sender, EventArgs e)
        {
            pn_cont.Controls.Clear();
            pn_cont.Controls.Add(frm_supp.pn_cat);
            db = new DB_BarbershopEntities();
            frm_supp.updata_data();
            lb_titelpage.Text = "الموردين";
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            pn_cont.Controls.Clear();
            pn_cont.Controls.Add(frm_Pur.pn_cat);
            db = new DB_BarbershopEntities();
            frm_Pur.updata_data();
            lb_titelpage.Text = "المشتريات";
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            pn_cont.Controls.Clear();
            pn_cont.Controls.Add(frm_cus.pn_cat);
            db = new DB_BarbershopEntities();
            frm_cus.updata_data();
            lb_titelpage.Text = "الصاله";
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            pn_cont.Controls.Clear();
            pn_cont.Controls.Add(frm_booking.pn_cat);
            db = new DB_BarbershopEntities();
            frm_booking.updata_data();
            lb_titelpage.Text = "الحجز";
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            pn_cont.Controls.Clear();
            pn_cont.Controls.Add(frm_report.tileControl1);
            db = new DB_BarbershopEntities();
            lb_titelpage.Text = "التقارير";
         
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            pn_cont.Controls.Clear();
            pn_cont.Controls.Add(frm_user.pn_cat);
            db = new DB_BarbershopEntities();
            frm_user.updata_data();
            lb_titelpage.Text = "المستخدمين";
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            pl.frm_settingpro frm_settingpro = new pl.frm_settingpro();
            frm_settingpro.Show();
          
           
        }
       
        private void btn_logout_Click(object sender, EventArgs e)
        {
            pl.frm_login login = new pl.frm_login();
           
            UpdateUserState("مغلق");

            Application.Restart();

        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            pn_cont.Controls.Clear();
            pn_cont.Controls.Add(frm_stuk.pn_cat);
            db = new DB_BarbershopEntities();
            frm_stuk.updata_data();
            lb_titelpage.Text = "الخدمات";
        }
      //  public  List<tb_sell_takeway> list_sellpop;
        public List<tb_appointment> list_sell;
        public List<tb_buy> list_pur;
        public List<tb_supp> list_supp;
        public List<tb_cus> list_cus;
        public List<tb_cat> list_cat;
        private void main_Activated(object sender, EventArgs e)
        {
             list_cat = db.tb_cat.ToList();
            UpdateUserState("مفتوح");
           

        }

        private void btn_employees_Click(object sender, EventArgs e)
        {
            pn_cont.Controls.Clear();
            pn_cont.Controls.Add(frm_Employees.pn_cat);
            db = new DB_BarbershopEntities();
            frm_Employees.updata_data();
            lb_titelpage.Text = "الموظفين";
        }

        private void btn_stor_Click(object sender, EventArgs e)
        {
            pn_cont.Controls.Clear();
            pn_cont.Controls.Add(frm_Stor.pn_cat);
            db = new DB_BarbershopEntities();
            frm_Stor.updata_data();
            lb_titelpage.Text = "المصاريف";
        }

        public tb_user CurrentUser { get; set; }
        private void UpdateUserState(string state)
        {
            try
            {
                if (CurrentUser != null)
                {
                    // نستخدم dbContext جديد لضمان وصول الحالة حتى لو الـ context الرئيسي فيه مشكلة
                    using (var dbContext = new DB_BarbershopEntities())
                    {
                        var user = dbContext.tb_user.Find(CurrentUser.id);
                        if (user != null)
                        {
                            user.user_state = state;
                            dbContext.SaveChanges();
                        }
                    }
                }
            }
            catch { /* تجاهل الخطأ لضمان إغلاق البرنامج بسلاسة */ }
        }
        private void CheckUserStatesAtStartup()
        {
            try
            {
                lastNotificationId = db.Notfications.Max(n => (int?)n.id) ?? 0;
                // ----------------------------

                bool hasUsers = db.tb_user.Any();
                if (!hasUsers)
                {
                    // إذا لم يتم العثور على مستخدم بحالة "مفتوح"
                    pl.frm_user_add frm_Setting = new pl.frm_user_add();
                    frm_Setting.ShowDialog();
                }

                if (Properties.Settings.Default.darkmode == true)
                {
                    UserLookAndFeel.Default.SetSkinStyle("Office 2019 Black");

                    pn_headernavbar.BackColor = Color.Black;
                    pn_topbar.BackColor = Color.Black;
                    flowLayoutPanel1.BackColor = Color.Black;
                }
                else
                {

                    pn_headernavbar.BackColor = Color.FromArgb(64, 64, 64);
                    pn_topbar.BackColor = Color.FromArgb(64, 64, 64);
                    flowLayoutPanel1.BackColor = Color.FromArgb(64, 64, 64);
                    UserLookAndFeel.Default.SetSkinStyle("Office 2019 Colorful");

                }
               
            }
            catch (Exception ex)
            {
               
                MessageBox.Show($"حدث خطأ: {ex.Message}\n\nسيتم فتح نافذة الإعدادات لإعادة التحقق من الاتصال بقاعدة البيانات.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

               
                pl.frm_setting frm_Setting = new pl.frm_setting();
                frm_Setting.ShowDialog();
            }
        }
        public static string GetSerialNumber()
        {
            try
            {
                // الحصول على سيريال نمبر للجهاز
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS");
                foreach (ManagementObject obj in searcher.Get())
                {
                    return obj["SerialNumber"].ToString();
                   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting serial number: " + ex.Message);
            }
            return null;
        }
        private  void CheckTrialExpiration(DateTime trialStartDate, Label label)
        {
            // هنا يمكنك تنفيذ منطق لفحص فترة التجربة باستخدام السيريال نمبر وتاريخ بدء الفترة التجريبية
            // هذا مجرد مثال بسيط على كيفية الفحص
            // DateTime trialStartDate = DateTime.Parse("2024-05-17");
           
            DateTime currentDate = DateTime.Now;
          //  trialStartDate = currentDateTime.AddMinutes(2);
            TimeSpan trialPeriod = currentDate - trialStartDate;
           
            
            int trialDays = 7; // 7 أيام
            string currentSerial = Properties.Settings.Default.serail;

            string licenseKey = Encrypt(currentSerial, "omran");

            if (Properties.Settings.Default.license == licenseKey)
            {
                label.Text = "مفعل";
            }
            else
            {
                if (trialPeriod.TotalDays > trialDays)
                {
                    // يمكنك هنا تنفيذ الإجراءات اللازمة عند انتهاء فترة التجربة
                    MessageBox.Show("انتهت فترة التجربة.");

                    simpleButton13.Enabled = false;
                    simpleButton6.Enabled = true;
                    btn_employees.Enabled = false;
                    btn_stor.Enabled = false;
                    simpleButton1.Enabled = false;
                    simpleButton12.Enabled = false;
                    simpleButton11.Enabled = false;
                    simpleButton10.Enabled = false;
                    simpleButton9.Enabled = false;
                    btn_supp.Enabled = false;
                    simpleButton7.Enabled = false;
                    // simpleButton6.Enabled = false;
                   

                    label.Text = "انتهت الفترة التجريبية";
                }
                else
                {

                    // حساب الأيام المتبقية
                    int remainingDays = (int)(trialDays - trialPeriod.TotalDays);
                    // تحديث النص في الليبل
                    label.Text = $"الأيام المتبقية: {remainingDays} يوم";

                }
                
            }
        }
        private void StoreSerialNumber()
        {
            string serialNumber = GetSerialNumber();
            if (!string.IsNullOrEmpty(serialNumber))
            {
                if (Properties.Settings.Default.serail != serialNumber)
                {
                    Properties.Settings.Default.serail = serialNumber;
                    Properties.Settings.Default.Save();
                }
            }
            else
            {
                MessageBox.Show("خطأ في الحصول على السيريال نمبر.");
            }
        }
        private string Encrypt(string input, string key)
        {
            // تحويل النص إلى مصفوفة بايت
            byte[] data = Encoding.UTF8.GetBytes(input);

            // تحويل المفتاح إلى مصفوفة بايت
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);

            // التشفير باستخدام مفتاح السري
            for (int i = 0; i < data.Length; i++)
            {
                data[i] ^= keyBytes[i % keyBytes.Length];
            }

            // تحويل المصفوفة المشفرة إلى سلسلة نصية
            return Convert.ToBase64String(data);
        }
        private void btn_note_Click(object sender, EventArgs e)
        {


            lblNotificationCount.Visible = false;
            lblNotificationCount.Text = "0";

            // التحقق مما إذا كان نموذج الإشعارات مفتوحًا بالفعل
            foreach (Form form in Application.OpenForms)
            {
                if (form is epl.notifaction)
                {
                    // إذا كان النموذج مفتوحًا، قم بإغلاقه
                    form.Close();
                    return; // الخروج من الدالة
                }
            }

            // إنشاء نموذج الإشعارات
            epl.notifaction notificationForm = new epl.notifaction();
            notificationForm.updata_data();

            // تعيين موقع النموذج ليظهر تحت الزر وفي منتصفه
            notificationForm.StartPosition = FormStartPosition.Manual;

            // الحصول على موقع الزر وحجم النموذج
            Point buttonLocation = btn_note.PointToScreen(Point.Empty); // تحويل موقع الزر إلى إحداثيات الشاشة
            int formWidth = notificationForm.Width;
            int buttonWidth = btn_note.Width;

            // حساب الموقع الجديد للنموذج بحيث يكون في منتصف الزر من الأسفل
            int newX = buttonLocation.X + (buttonWidth / 2) - (formWidth / 2);
            int newY = buttonLocation.Y + btn_note.Height;

            // تعيين موقع النموذج الجديد
            notificationForm.Location = new Point(newX, newY);

            // تعيين خاصية RightToLeft للنموذج
            notificationForm.RightToLeft = RightToLeft.Yes;

            // عرض النموذج
            notificationForm.Show();
            lastNotificationId = db.Notfications.Max(n => (int?)n.id) ?? 0;
        }
        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateUserState("مغلق");
            _syncTimer?.Dispose();

        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            pl.frm_settingpro settingpro = new pl.frm_settingpro();
                settingpro.ExecuteSendEmailLogic();


        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            pn_cont.Controls.Clear();
            pn_cont.Controls.Add(frm_safe_as.pn_cat);
            db = new DB_BarbershopEntities();
            frm_safe_as.updata_data();
            lb_titelpage.Text = "الخزينة";
        }

        private void simpleButton3_Click_1(object sender, EventArgs e)
        {
            pn_cont.Controls.Clear();
            pn_cont.Controls.Add(frm_Shift_Motion.pn_cat);
            db = new DB_BarbershopEntities();
            frm_Shift_Motion.updata_data();
            lb_titelpage.Text = "تسليم وردية";
        }

        private void whats_Click(object sender, EventArgs e)
        {
            pl.frm_whats frm_settingpro = new pl.frm_whats();
            frm_settingpro.Show();
        }

        private void simpleButton4_Click_1(object sender, EventArgs e)
        {
            pn_cont.Controls.Clear();
            pn_cont.Controls.Add(cashbox.pn_cat);
            db = new DB_BarbershopEntities();
            cashbox.updata_data();
            lb_titelpage.Text = "الكاش بوكس";

        }
        bool dragging = false;
        Point dragCursorPoint;
        Point dragFormPoint;
        private void pn_topbar_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void pn_topbar_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void pn_topbar_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void simpleButton6_Click_1(object sender, EventArgs e)
        {
            pn_cont.Controls.Clear();
            pn_cont.Controls.Add(Attendanceemp.pn_cat);
            db = new DB_BarbershopEntities();
            Attendanceemp.updata_data();
            lb_titelpage.Text = "الحضور والانصراف";
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            pn_cont.Controls.Clear();
            pn_cont.Controls.Add(frm_Salaries.pn_cat);
            db = new DB_BarbershopEntities();
            frm_Salaries.updata_data();
            lb_titelpage.Text = "المرتبات";
        }
    }
   
}
