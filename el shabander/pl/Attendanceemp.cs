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
using el_shabander.epl;
using System.Globalization;
using System.Threading;
using DevExpress.XtraGrid.Views.Grid;

namespace el_shabander.pl
{
    public partial class Attendanceemp : Form
    {
        DB_BarbershopEntities db = new DB_BarbershopEntities();
        // tb_user tb_user = new tb_user();
       // tb_employees tb_Employees = new tb_employees();
        bl.methods methods = new bl.methods();
        // أضف دول جنب باقي المتغيرات الموجودة
        private HikvisionService _hikvision;
        private bool _deviceConnected = false;

        // بيانات الجهاز — غيّرها لبيانات جهازك
        private string DEVICE_IP = Properties.Settings.Default.ip_hik;
        private  string DEVICE_USER = Properties.Settings.Default.user_hik;
        private string DEVICE_PASS = Properties.Settings.Default.pass_hik;
        Attendance attendance = new Attendance();
        // int id;
        public Attendanceemp()
        {
            InitializeComponent();


        
        }
        public void updata_data()
        {
            LoadData();
            LoadEmployees();

            ApplyArabicCulture();

            SetArabicDateFormat(edt_day_serch);
            edt_dateserc.Format = DateTimePickerFormat.Custom;
            edt_dateserc.CustomFormat = "dd/MM/yyyy hh:mm:ss tt"; // التاريخ والوقت
            edt_dateserc.ShowUpDown = true;
            timer1.Start();
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








        private void btn_close_Click(object sender, EventArgs e)
        {
            toast toast = new toast();
            dialog dialog = new dialog();
            try
            {
                if (edt_employee.SelectedValue == null)
                {
                    dialog.Width = this.Width;
                    dialog.txt_capthion.Text = "  يرجى اختيار موظف";
                    dialog.Show();
                    return;
                }

                int employeeId = Convert.ToInt32(edt_employee.SelectedValue);
                DateTime selectedDateTime = edt_dateserc.Value;
                DateTime today = selectedDateTime.Date;
                TimeSpan selectedTime = selectedDateTime.TimeOfDay;

                // ← أولاً: دور في نفس اليوم
                var todayAttendance = db.Attendances
                    .FirstOrDefault(x => x.EmployeeId == employeeId &&
                                        DbFunctions.TruncateTime(x.AttendDate) == today &&
                                        x.CheckOut == null);

                // ← لو مش لاقيه، دور في اليوم السابق
                if (todayAttendance == null)
                {
                    DateTime previousDate = today.AddDays(-1);
                    todayAttendance = db.Attendances
                        .FirstOrDefault(x => x.EmployeeId == employeeId &&
                                            DbFunctions.TruncateTime(x.AttendDate) == previousDate &&
                                            x.CheckOut == null);
                }

                if (todayAttendance == null)
                {
                    dialog.Width = this.Width;
                    dialog.txt_capthion.Text = "  تم تسجيل الخروج من قبل او لم يتم تسجيل الدخول";
                    dialog.Show();
                    return;
                }

                todayAttendance.CheckOut = selectedTime;

                TimeSpan checkIn = todayAttendance.CheckIn ?? TimeSpan.Zero;
                double totalHours;

                // ← لو الخروج في يوم تاني
                if (selectedTime < checkIn)
                    totalHours = (TimeSpan.FromHours(24) - checkIn + selectedTime).TotalHours;
                else
                    totalHours = (selectedTime - checkIn).TotalHours;

                var employee = db.Employees.FirstOrDefault(x => x.EmployeeId == employeeId);

                double dailyRequiredHours = 8;
                if (employee != null && employee.RequiredMonthlyHours.HasValue &&
                    employee.RequiredMonthlyHours.Value > 0)
                {
                    dailyRequiredHours = (double)employee.RequiredMonthlyHours.Value
                                         / (double)employee.workingdays.Value;
                }

                if (totalHours <= dailyRequiredHours)
                {
                    todayAttendance.WorkedHours = (decimal)Math.Round(totalHours, 2);
                    todayAttendance.OvertimeHours = 0;
                }
                else
                {
                    todayAttendance.WorkedHours = (decimal)Math.Round(dailyRequiredHours, 2);
                    todayAttendance.OvertimeHours = (decimal)Math.Round(
                        totalHours - dailyRequiredHours, 2);
                }

                db.Entry(todayAttendance).State = EntityState.Modified;
                db.SaveChanges();

                toast.Width = this.Width;
                toast.txt_caption.Text = "تم تسجيل الانصراف بنجاح";
                toast.Show();

                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                dialog dialog2 = new dialog();
                dialog2.Width = this.Width;
                dialog2.txt_capthion.Text = "حدث خطأ: " + ex.Message;
                dialog2.Show();
            }
        }

        private void btn_absent_Click(object sender, EventArgs e)
        {
            toast toast = new toast();
            dialog dialog = new dialog();
            try
            {
                if (edt_employee.SelectedValue == null)
                {
                    dialog.Width = this.Width;
                    dialog.txt_capthion.Text = "  يرجى اختيار موظف";
                    dialog.Show();
                    return;
                }

                int employeeId = Convert.ToInt32(edt_employee.SelectedValue);
                string employeeName = edt_employee.Text;
                DateTime selectedDate = edt_dateserc.Value.Date;

                // التحقق من وجود سجل لنفس الموظف في نفس اليوم
                var existingAttendance = db.Attendances
                    .FirstOrDefault(x => x.EmployeeId == employeeId &&
                                        DbFunctions.TruncateTime(x.AttendDate) == selectedDate);

                if (existingAttendance != null)
                {
                    dialog.Width = this.Width;
                    dialog.txt_capthion.Text = "  يوجد سجل لهذا الموظف في هذا التاريخ";
                    dialog.Show();
                    return;
                }

                // تسجيل غياب مع التاريخ المحدد
                attendance = new Attendance();
                attendance.EmployeeId = employeeId;
                attendance.NameEmployee = employeeName;
                attendance.AttendDate = selectedDate; // حفظ التاريخ المحدد
                attendance.CheckIn = null;
                attendance.CheckOut = null;
                attendance.Status = "غائب"; // غائب
                attendance.WorkedHours = 0;
                attendance.OvertimeHours = 0;

                db.Attendances.Add(attendance);
                db.SaveChanges();

                // عرض رسالة مع التاريخ
                string message = $"تم تسجيل غياب {employeeName}بتاريخ: {selectedDate:dd/MM/yyyy}";

                toast.Width = this.Width;
                toast.txt_caption.Text = message;
                toast.Show();

                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                dialog.Width = this.Width;
                dialog.txt_capthion.Text = "حدث خطأ: " + ex.Message;
                dialog.Show();
            }
        }

        // تسجيل إجازة
        private void btn_leave_Click(object sender, EventArgs e)
        {
            toast toast = new toast();
            dialog dialog = new dialog();
            try
            {
                if (edt_employee.SelectedValue == null)
                {
                    dialog.Width = this.Width;
                    dialog.txt_capthion.Text = "  يرجى اختيار موظف";
                    dialog.Show();
                    return;
                }

                int employeeId = Convert.ToInt32(edt_employee.SelectedValue);
                string employeeName = edt_employee.Text;
                DateTime selectedDate = edt_dateserc.Value.Date;

                // التحقق من وجود سجل لنفس الموظف في نفس اليوم
                var existingAttendance = db.Attendances
                    .FirstOrDefault(x => x.EmployeeId == employeeId &&
                                        DbFunctions.TruncateTime(x.AttendDate) == selectedDate);

                if (existingAttendance != null)
                {
                    dialog.Width = this.Width;
                    dialog.txt_capthion.Text = "  يوجد سجل لهذا الموظف في هذا التاريخ";
                    dialog.Show();
                    return;
                }

                // تسجيل إجازة مع التاريخ المحدد
                attendance = new Attendance();
                attendance.EmployeeId = employeeId;
                attendance.NameEmployee = employeeName;
                attendance.AttendDate = selectedDate; // حفظ التاريخ المحدد
                attendance.CheckIn = null;
                attendance.CheckOut = null;
                attendance.Status = "إجازة"; // إجازة
                attendance.WorkedHours = 0;
                attendance.OvertimeHours = 0;

                db.Attendances.Add(attendance);
                db.SaveChanges();

                // عرض رسالة مع التاريخ
                string message = $"تم تسجيل إجازة {employeeName}\nبتاريخ: {selectedDate:dd/MM/yyyy}";

                toast.Width = this.Width;
                toast.txt_caption.Text = message;
                toast.Show();

                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                dialog.Width = this.Width;
                dialog.txt_capthion.Text = "حدث خطأ: " + ex.Message;
                dialog.Show();
            }
        }

        private void btn_search_employee_Click(object sender, EventArgs e)
        {
            try
            {
                if (edt_employee.SelectedValue == null)
                {
                    LoadData();
                    return;
                }

                int employeeId = Convert.ToInt32(edt_employee.SelectedValue);

                var attendanceData = db.Attendances
                    .Where(x => x.EmployeeId == employeeId)
                    .OrderByDescending(x => x.AttendDate)
                    .ThenByDescending(x => x.CheckIn)
                    .Select(x => new
                    {
                        x.AttendanceId,
                        x.EmployeeId,
                        x.NameEmployee,
                        x.AttendDate,
                        x.CheckIn,
                        x.CheckOut,
                        x.Status,
                        x.WorkedHours,
                        x.OvertimeHours
                    })
                    .ToList();

                gridControl1.DataSource = attendanceData;
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء البحث: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_in_Click(object sender, EventArgs e)
        {
            var idValue = gridView1.GetFocusedRowCellValue("AttendanceId");
            if (idValue == null)
            {
                MessageBox.Show("لم يتم اختيار صف صحيح.");
                return;
            }

            int id = Convert.ToInt32(idValue);

            var session = db.Attendances.FirstOrDefault(x => x.AttendanceId == id);
            if (session == null)
            {
                MessageBox.Show($"لا يوجد جلسة بالرقم: {id}");
                return;
            }

            pl.frm_employee_absent frm_supp_Add = new pl.frm_employee_absent();
            frm_supp_Add.id = session.AttendanceId;

            frm_supp_Add.Show();
        }

        private void btn_updata_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            toast toast = new toast();
            dialog dialog = new dialog();
            try
            {
                if (edt_employee.SelectedValue == null)
                {
                    dialog.Width = this.Width;
                    dialog.txt_capthion.Text = "  يرجى اختيار موظف";
                    dialog.Show();
                    return;
                }

                int employeeId = Convert.ToInt32(edt_employee.SelectedValue);
                string employeeName = edt_employee.Text;
                DateTime selectedDateTime = edt_dateserc.Value;
                DateTime today = selectedDateTime.Date;
                TimeSpan selectedTime = selectedDateTime.TimeOfDay;
                // التحقق من وجود سجل حضور لنفس الموظف في نفس اليوم
                var existingAttendance = db.Attendances
                    .FirstOrDefault(x => x.EmployeeId == employeeId &&
                                        DbFunctions.TruncateTime(x.AttendDate) == today);

                if (existingAttendance != null)
                {
                    dialog.Width = this.Width;
                    dialog.txt_capthion.Text = "  تم تسجيل حضور هذا الموظف اليوم من قبل";
                    dialog.Show();
                    return;
                }

                // تسجيل حضور جديد
                attendance = new Attendance();
                attendance.EmployeeId = employeeId;
                attendance.NameEmployee = employeeName;
                attendance.AttendDate = today;
                attendance.CheckIn = selectedTime;
                attendance.CheckOut = null; // لم ينصرف بعد
                attendance.Status = "حاضر"; // حاضر
                attendance.WorkedHours = 0;
                attendance.OvertimeHours = 0;

                db.Attendances.Add(attendance);
                db.SaveChanges();

                toast.Width = this.Width;
                toast.txt_caption.Text = "تم تسجيل الحضور بنجاح";
                toast.Show();

                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                dialog.Width = this.Width;
                dialog.txt_capthion.Text = "حدث خطأ: " + ex.Message;
                dialog.Show();
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var _search = edt_day_serch.Value.Date;

            List<Attendance> data = db.Attendances.Where(x => DbFunctions.TruncateTime(x.AttendDate) == _search).ToList();
            data.Reverse();
            gridControl1.DataSource = data;
        }



        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            btn_in_Click(sender, e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            edt_date.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        }
        private void gridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string status = view.GetRowCellValue(e.RowHandle, "Status")?.ToString();

                if (!string.IsNullOrEmpty(status))
                {
                    if (status == "حاضر") // حاضر
                    {
                        e.Appearance.BackColor = Color.LightGreen;
                        e.Appearance.ForeColor = Color.Black;
                    }
                    else if (status == "غائب") // غائب
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                    }
                    else if (status == "إجازة") // إجازة
                    {
                        e.Appearance.BackColor = Color.Orange;
                        e.Appearance.ForeColor = Color.White;
                    }
                }
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void ClearFields()
        {
            edt_employee.SelectedIndex = -1;
            edt_dateserc.Value = DateTime.Now;
        }
        private void LoadEmployees()
        {
            try
            {
                var employees = db.Employees
                    .Select(x => new { x.EmployeeId, x.EmployeeName })
                    .ToList();

                edt_employee.DataSource = employees;
                edt_employee.DisplayMember = "EmployeeName";
                edt_employee.ValueMember = "EmployeeId";

                // إعداد AutoComplete
                AutoCompleteStringCollection acsc = new AutoCompleteStringCollection();
                acsc.AddRange(employees.Select(x => x.EmployeeName).ToArray());
                edt_employee.AutoCompleteCustomSource = acsc;
                edt_employee.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                edt_employee.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل الموظفين: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frm_cashbox_Load(object sender, EventArgs e)
        {


        }
        public void LoadData()
        {
            try
            {
                db = new DB_BarbershopEntities();

                // جلب بيانات الحضور مع اسم الموظف
                var attendanceData = db.Attendances
                    .OrderByDescending(x => x.AttendDate)
                    .ThenByDescending(x => x.CheckIn)
                    .Select(x => new
                    {
                        x.AttendanceId,
                        x.EmployeeId,
                        x.NameEmployee,
                        x.AttendDate,
                        x.CheckIn,
                        x.CheckOut,
                        x.Status,
                        x.WorkedHours,
                        x.OvertimeHours
                    })
                    .ToList();

                gridControl1.DataSource = attendanceData;


            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            toast toast = new toast();

            try
            {
                // التحقق من اختيار صف
                var idValue = gridView1.GetFocusedRowCellValue("AttendanceId");
                if (idValue == null)
                {
                    MessageBox.Show("يرجى اختيار سجل للحذف", "تنبيه",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int attendanceId = Convert.ToInt32(idValue);

                // جلب اسم الموظف للعرض في رسالة التأكيد
                string employeeName = gridView1.GetFocusedRowCellValue("NameEmployee")?.ToString() ?? "غير معروف";
                DateTime? attendDate = gridView1.GetFocusedRowCellValue("AttendDate") as DateTime?;
                string dateStr = attendDate?.ToString("dd/MM/yyyy") ?? "";

                // رسالة تأكيد الحذف
                DialogResult result = MessageBox.Show(
                    $"هل أنت متأكد من حذف سجل الحضور لـ {employeeName}\nبتاريخ: {dateStr}؟",
                    "تأكيد الحذف",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2
                );

                if (result == DialogResult.Yes)
                {
                    // البحث عن السجل في قاعدة البيانات
                    var attendance = db.Attendances.FirstOrDefault(x => x.AttendanceId == attendanceId);

                    if (attendance == null)
                    {
                        MessageBox.Show("لم يتم العثور على السجل", "خطأ",
                                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // حذف السجل
                    db.Attendances.Remove(attendance);
                    db.SaveChanges();

                    // عرض رسالة نجاح
                    toast.Width = this.Width;
                    toast.txt_caption.Text = "تم حذف السجل بنجاح";
                    toast.Show();

                    // تحديث البيانات
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء الحذف: " + ex.Message, "خطأ",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btn_connect_device_Click(object sender, EventArgs e)
        {
            try
            {
                btn_connect_device.Enabled = false;
                lbl_device_status.Text = "⏳ جاري الاتصال...";
                lbl_device_status.ForeColor = Color.Orange;

                _hikvision = new HikvisionService(DEVICE_IP, DEVICE_USER, DEVICE_PASS);
                _deviceConnected = await _hikvision.TestConnectionAsync();

                if (_deviceConnected)
                {
                    lbl_device_status.Text = "🟢 الجهاز متصل";
                    lbl_device_status.ForeColor = Color.Green;

                    // تفعيل أزرار الجهاز
                    btn_fetch_device.Enabled = true;
                   
                }
                else
                {
                    lbl_device_status.Text = "🔴 فشل الاتصال";
                    lbl_device_status.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                lbl_device_status.Text = "🔴 خطأ في الاتصال";
                lbl_device_status.ForeColor = Color.Red;
                MessageBox.Show("خطأ: " + ex.Message);
            }
            finally
            {
                btn_connect_device.Enabled = true;
            }
        }

        private async void btn_fetch_device_Click(object sender, EventArgs e)
        {
            if (!_deviceConnected) { MessageBox.Show("يرجى الاتصال بالجهاز أولاً"); return; }

            try
            {
                btn_fetch_device.Enabled = false;
                lbl_device_status.Text = "⏳ جاري جلب البيانات...";

                db = new DB_BarbershopEntities();

                int savedCheckIn = 0, savedCheckOut = 0, skipped = 0;

                // ← جيب آخر تاريخ موجود في الـ DB مع مراعاة إنه Nullable
                DateTime lastDate = db.Attendances.Any()
                    ? db.Attendances.Max(x => x.AttendDate).Value   // ← .Value عشان DateTime?
                    : DateTime.Today.AddDays(-90);

                DateTime from = lastDate.AddDays(-30);
                DateTime to = DateTime.Now;

                var (logs, rawResponse) = await _hikvision.GetAttendanceLogsAsync(from, to);

                if (logs == null || !logs.Any())
                {
                    MessageBox.Show($"لا توجد سجلات\n{rawResponse}");
                    return;
                }

                var sortedLogs = logs.OrderBy(x => x.EventTime).ToList();

                var allEmployees = db.Employees.ToList();

                var allAttendances = db.Attendances
                    .Where(x => x.AttendDate >= from && x.AttendDate <= to)
                    .ToList();

                // ══════════════════════════════
                // خطوة 1: CheckIn
                // ══════════════════════════════
                foreach (var log in sortedLogs.Where(x => x.EventType == "CheckIn"))
                {
                    var employee = allEmployees.FirstOrDefault(x => x.EmployeeId == log.EmployeeId);
                    if (employee == null) continue;

                    DateTime logDate = log.EventTime.Date;
                    TimeSpan logTime = log.EventTime.TimeOfDay;
                    DateTime previousDate = logDate.AddDays(-1);

                    var existingToday = allAttendances
                        .FirstOrDefault(x => x.EmployeeId == log.EmployeeId &&
                                             x.AttendDate.HasValue &&
                                             x.AttendDate.Value.Date == logDate);

                    var existingPrevious = allAttendances
                        .FirstOrDefault(x => x.EmployeeId == log.EmployeeId &&
                                             x.AttendDate.HasValue &&
                                             x.AttendDate.Value.Date == previousDate &&
                                             x.CheckOut == null);

                    // ← لو في سجل اليوم ده بالفعل → تجاهل تماماً
                    if (existingToday != null)
                    {
                        skipped++;
                        continue;
                    }

                    // ← لو في سجل من اليوم السابق بدون checkout → تجاهل
                    if (existingPrevious != null)
                    {
                        skipped++;
                        continue;
                    }

                    // ← مفيش سجل خالص → ضيف جديد
                    // ← مفيش سجل خالص → ضيف جديد
                    var newAttendance = new Attendance
                    {
                        EmployeeId = employee.EmployeeId,
                        NameEmployee = employee.EmployeeName,
                        AttendDate = logDate,
                        CheckIn = logTime,
                        CheckOut = null,
                        Status = "حاضر",
                        WorkedHours = 0,
                        OvertimeHours = 0
                    };
                    db.Attendances.Add(newAttendance);
                    allAttendances.Add(newAttendance); // ← أضفه للـ list فوراً
                    savedCheckIn++;
                }

                // ← Save الأول هنا
                db.SaveChanges();

                // ← reload الـ attendances من الـ DB بعد الـ Save
                db = new DB_BarbershopEntities();
                allAttendances = db.Attendances
                    .Where(x => x.AttendDate >= from && x.AttendDate <= to)
                    .ToList();

                // ══════════════════════════════
                // خطوة 2: CheckOut
                // ══════════════════════════════
                foreach (var log in sortedLogs.Where(x => x.EventType == "CheckOut"))
                {
                    var employee = allEmployees.FirstOrDefault(x => x.EmployeeId == log.EmployeeId);
                    if (employee == null) continue;

                    DateTime logDate = log.EventTime.Date;
                    TimeSpan logTime = log.EventTime.TimeOfDay;
                    DateTime previousDate = logDate.AddDays(-1);

                    var existing = allAttendances
                        .FirstOrDefault(x => x.EmployeeId == log.EmployeeId &&
                                             x.AttendDate.HasValue &&
                                             x.AttendDate.Value.Date == logDate &&
                                             x.CheckOut == null)
                        ?? allAttendances
                            .FirstOrDefault(x => x.EmployeeId == log.EmployeeId &&
                                                 x.AttendDate.HasValue &&
                                                 x.AttendDate.Value.Date == previousDate &&
                                                 x.CheckOut == null);

                    if (existing == null) continue;

                    existing.CheckOut = logTime;
                    existing.NameEmployee = employee.EmployeeName;
                    existing.Status = "حاضر";

                    TimeSpan checkIn = existing.CheckIn ?? TimeSpan.Zero;
                    double totalHours = logTime < checkIn
                        ? (TimeSpan.FromHours(24) - checkIn + logTime).TotalHours
                        : (logTime - checkIn).TotalHours;

                    double dailyRequired = 8;
                    if (employee.RequiredMonthlyHours.HasValue &&
                        employee.workingdays.HasValue &&
                        employee.workingdays.Value > 0)
                        dailyRequired = (double)employee.RequiredMonthlyHours.Value
                                        / employee.workingdays.Value;

                    existing.WorkedHours = (decimal)Math.Round(Math.Min(totalHours, dailyRequired), 2);
                    existing.OvertimeHours = totalHours > dailyRequired
                        ? (decimal)Math.Round(totalHours - dailyRequired, 2) : 0;

                    db.Entry(existing).State = EntityState.Modified;
                    savedCheckOut++;
                }

                db.SaveChanges();

                lbl_device_status.Text = "🟢 تمت المزامنة بنجاح";
                LoadData();

                MessageBox.Show(
                    $"✅ تمت المزامنة بنجاح\n\n" +
                    $"📥 CheckIn جديد: {savedCheckIn}\n" +
                    $"📤 CheckOut محدّث: {savedCheckOut}\n" +
                    $"⏭️ سجلات موجودة مسبقاً: {skipped}",
                    "نتيجة المزامنة",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                lbl_device_status.Text = "🔴 حدث خطأ";
                MessageBox.Show("خطأ: " + ex.Message + "\n" + ex.InnerException?.Message,
                                "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btn_fetch_device.Enabled = true;
            }
        }


    }
}
