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
using DevExpress.XtraReports.UI;

namespace el_shabander.pl
{
    public partial class frm_Salaries : Form
    {
        DB_BarbershopEntities db = new DB_BarbershopEntities();
        Attendance attendance = new Attendance();
        bl.methods methods = new bl.methods();
        int id;
        // int id;
        public frm_Salaries()
        {
            InitializeComponent();




          
        }
        public void updata_data()
        {
            var employees = db.Employees.Select(emp => new
            {
                emp.EmployeeId,
                emp.EmployeeName
            }).ToList();

            comboBox_Employee_Salary.DataSource = employees;
            comboBox_Employee_Salary.DisplayMember = "EmployeeName";
            comboBox_Employee_Salary.ValueMember = "EmployeeId";

            comboBox_Employee_Advances.DataSource = employees.ToList();
            comboBox_Employee_Advances.DisplayMember = "EmployeeName";
            comboBox_Employee_Advances.ValueMember = "EmployeeId";
            ApplyArabicCulture();

            SetArabicDateFormat(dateTimePicker_Advances);
            SetArabicDateFormat(dateTimePicker_Salary);

            var save = db.tb_safe.Select(dd => new
            {
                dd.id,
                dd.safe_name
            }).ToList();
            save1.DataSource = save;
            save1.DisplayMember = "safe_name";
            save1.ValueMember = "id";
            save2.DataSource = save;
            save2.DisplayMember = "safe_name";
            save2.ValueMember = "id";
            var company1 = db.AppSettings.Select(dd => new
            {
                dd.id,
                dd.namecomp
            }).ToList();
            var company2 = db.AppSettings.Select(dd => new
            {
                dd.id,
                dd.namecomp
            }).ToList();
            namecompany1.DataSource = company1;
            namecompany1.DisplayMember = "namecomp";
            namecompany1.ValueMember = "id";
            namecompany2.DataSource = company2;
            namecompany2.DisplayMember = "namecomp";
            namecompany2.ValueMember = "id";

            // تحديث بيانات السلف
            var advancesData = db.Advances
                .Select(a => new
                {
                    a.AdvanceId,
                    a.NameEmployee,
                    a.AdvanceDate,
                    a.Month,
                    a.Year,
                    a.Amount,
                    a.IsSettled,
                    a.safename,
                    a.name_company,
                    a.safeid
                }).ToList();

            gridControl_Advances.DataSource = advancesData;

            // تحديث بيانات المرتبات
            var salariesData = db.Salaries
                .Select(s => new
                {
                    s.SalaryId,
                    s.NameEmployee,
                    s.Month,
                    s.Year,
                    s.BaseSalary,
                    s.TotalWorkedHours,
                    s.OvertimeAmount,
                    s.AdvancesAmount,
                    s.FinalSalary,
                    s.IsPaid,
                    s.safename,
                    s.name_company,
                    s.safeid
                }).ToList();

            gridControl_Salaries.DataSource = salariesData;


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
            picker.RightToLeft = System.Windows.Forms.RightToLeft.No;
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
        private void frm_cashbox_Load(object sender, EventArgs e)
        {
            // تحميل البيانات
            updata_data();
        }

        // ============================
        // إضافة سلفة جديدة
        // ============================
        private void btn_add_Advances_Click(object sender, EventArgs e)
        {
            try
            {

                int employeeId = Convert.ToInt32(comboBox_Employee_Advances.SelectedValue);
                DateTime salaryDate = dateTimePicker_Advances.Value;
                int month = salaryDate.Month;
                int year = salaryDate.Year;

                // التحقق من عدم وجود مرتب مدفوع لنفس الموظف في نفس الشهر
                var existingSalary = db.Salaries
                    .FirstOrDefault(s => s.EmployeeId == employeeId &&
                                       s.Month == month &&
                                       s.Year == year);

                if (existingSalary != null)
                {
                    MessageBox.Show("يوجد مرتب مسجل بالفعل لهذا الموظف في هذا الشهر", "تنبيه",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // التحقق الأول: هل السلفة متسوية؟



                if (comboBox_Employee_Advances.SelectedValue == null)
                {
                    MessageBox.Show("من فضلك اختر موظف", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(txt_Amount_Advances.Text) || Convert.ToDecimal(txt_Amount_Advances.Text) <= 0)
                {
                    MessageBox.Show("من فضلك أدخل مبلغ السلفة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DateTime advanceDate = dateTimePicker_Advances.Value;
                decimal amount = Convert.ToDecimal(txt_Amount_Advances.Text);

                var employee = db.Employees.Find(employeeId);

                if (employee == null)
                {
                    MessageBox.Show("الموظف غير موجود", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // إنشاء سجل المرتب
                int safeId = Convert.ToInt32(save1.SelectedValue);
                var safa = db.tb_safe.Find(safeId);
                Advance newAdvance = new Advance
                {
                    EmployeeId = employeeId,
                    AdvanceDate = advanceDate,
                    Month = advanceDate.Month,
                    Year = advanceDate.Year,
                    Amount = amount,
                    IsSettled = false,
                    NameEmployee = employee.EmployeeName,
                    name_company = namecompany2.Text,
                    safeid = safeId,
                    safename = safa.safe_name
                };

                db.Advances.Add(newAdvance);
                var safe = db.tb_safe.FirstOrDefault(b => b.safe_name == save1.Text);
                safe.safe_count -= Convert.ToDouble(amount);
                db.SaveChanges();

                MessageBox.Show("تم إضافة السلفة بنجاح", "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // تنظيف الحقول
                txt_Amount_Advances.Text = "0";
                comboBox_Employee_Advances.SelectedIndex = -1;

                updata_data();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================
        // عرض السلف
        // ============================
        // أضف هذا الكود في ملف Salaries.cs

        // ============================
        // عرض تقرير السلفة
        // ============================
        private void btn_show_Advances_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRow = gridView_Advances.GetFocusedRow() as dynamic;

                if (selectedRow == null)
                {
                    MessageBox.Show("من فضلك اختر سلفة لطباعة التقرير", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    updata_data();
                    return;
                }

                int advanceId = selectedRow.AdvanceId;
                ShowAdvanceReport(advanceId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في عرض التقرير: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================
        // عرض تقرير السلفة
        // ============================
        private void ShowAdvanceReport(int advanceId)
        {
            try
            {
                // جلب بيانات السلفة
                var advance = db.Advances.Find(advanceId);
                if (advance == null)
                {
                    MessageBox.Show("السلفة غير موجودة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // إنشاء DataTable للتقرير
                DataTable dt = new DataTable();
                dt.TableName = "AdvanceReport";

                // إضافة الأعمدة
                dt.Columns.Add("EmployeeName", typeof(string));
                dt.Columns.Add("Amount", typeof(string));
                dt.Columns.Add("AdvanceDate", typeof(string));
                dt.Columns.Add("Month", typeof(string));
                dt.Columns.Add("Year", typeof(string));

                // إضافة الصف
                DataRow row = dt.NewRow();
                row["EmployeeName"] = advance.NameEmployee ?? "غير محدد";
                row["Amount"] = (advance.Amount ?? 0).ToString("N2");
                row["AdvanceDate"] = advance.AdvanceDate?.ToString("dd/MM/yyyy") ?? "غير محدد";
                row["Month"] = (advance.Month ?? 0).ToString();
                row["Year"] = (advance.Year ?? 0).ToString();
                dt.Rows.Add(row);

                // إنشاء التقرير
                rpt_Advance_Report report = new rpt_Advance_Report();
                report.DataSource = dt;

                // عرض التقرير
                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ في إنشاء التقرير:\n\n" +
                    ex.Message + "\n\n" +
                    "التفاصيل: " + ex.StackTrace,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================
        // حذف سلفة - مع التحقق المحسّن
        // ============================
        private void btn_delete_Advances_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRow = gridView_Advances.GetFocusedRow() as dynamic;

                if (selectedRow == null)
                {
                    MessageBox.Show("من فضلك اختر سلفة للحذف", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int advanceId = selectedRow.AdvanceId;

                // جلب السلفة من قاعدة البيانات
                var advance = db.Advances.Find(advanceId);

                if (advance == null)
                {
                    MessageBox.Show("السلفة غير موجودة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // التحقق الأول: هل السلفة متسوية؟
                if (advance.IsSettled == true)
                {
                    // التحقق الثاني: هل المرتب اللي اتخصمت منه السلفة مدفوع؟
                    var relatedSalary = db.Salaries
                        .Where(s => s.EmployeeId == advance.EmployeeId &&
                                   s.Month == advance.Month &&
                                   s.Year == advance.Year)
                        .FirstOrDefault();

                    if (relatedSalary != null && relatedSalary.IsPaid == true)
                    {
                        MessageBox.Show(
                            "لا يمكن حذف هذه السلفة!\n\n" +
                            "السبب: تم خصم هذه السلفة من مرتب مدفوع\n" +
                            $"الموظف: {advance.NameEmployee}\n" +
                            $"الشهر: {advance.Month}/{advance.Year}\n" +
                            $"المبلغ: {advance.Amount:N2} جنيه",
                            "تنبيه - عملية غير مسموحة",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }
                }

                var result = MessageBox.Show(
                    $"هل أنت متأكد من حذف هذه السلفة؟\n\n" +
                    $"الموظف: {advance.NameEmployee}\n" +
                    $"المبلغ: {advance.Amount:N2} جنيه\n" +
                    $"التاريخ: {advance.AdvanceDate:dd/MM/yyyy}",
                    "تأكيد الحذف",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    db.Advances.Remove(advance);
                    var safe = db.tb_safe.FirstOrDefault(b => b.safe_name == save1.Text);
                    safe.safe_count += Convert.ToDouble(advance.Amount);
                    db.SaveChanges();

                    MessageBox.Show("تم حذف السلفة بنجاح", "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    updata_data();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================
        // حساب وإضافة مرتب
        // ============================
        private void btn_add_Salaries_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_Employee_Salary.SelectedValue == null)
                {
                    MessageBox.Show("من فضلك اختر موظف", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int employeeId = Convert.ToInt32(comboBox_Employee_Salary.SelectedValue);
                DateTime salaryDate = dateTimePicker_Salary.Value;
                int month = salaryDate.Month;
                int year = salaryDate.Year;

                // التحقق من عدم وجود مرتب مدفوع لنفس الموظف في نفس الشهر
                var existingSalary = db.Salaries
                    .FirstOrDefault(s => s.EmployeeId == employeeId &&
                                       s.Month == month &&
                                       s.Year == year);

                if (existingSalary != null)
                {
                    MessageBox.Show("يوجد مرتب مسجل بالفعل لهذا الموظف في هذا الشهر", "تنبيه",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // جلب بيانات الموظف
                var employee = db.Employees.Find(employeeId);

                if (employee == null)
                {
                    MessageBox.Show("الموظف غير موجود", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // حساب بداية ونهاية الشهر
                DateTime startDate = new DateTime(year, month, 1);
                DateTime endDate = startDate.AddMonths(1).AddDays(-1);

                // جلب سجلات الحضور للموظف في الشهر المحدد
                var attendanceRecords = db.Attendances
                    .Where(a => a.EmployeeId == employeeId &&
                               a.AttendDate >= startDate &&
                               a.AttendDate <= endDate)
                    .ToList();

                // حساب إجمالي ساعات العمل والساعات الإضافية
                decimal totalWorkedHours = attendanceRecords.Sum(a => a.WorkedHours ?? 0);
                decimal totalOvertimeHours = attendanceRecords.Sum(a => a.OvertimeHours ?? 0);

                // حساب المرتب الأساسي
                decimal baseSalary = 0;
                decimal hourlyRate = 0;

                if (employee.SalaryType == "شهري" || employee.SalaryType == "Monthly")
                {
                    // المرتب الشهري - تقسيم المرتب على الساعات المطلوبة وضربها في الساعات الفعلية
                    decimal monthlySalary = employee.SalaryValue ?? 0;
                    int requiredHours = employee.RequiredMonthlyHours ?? 176; // الافتراضي 176 ساعة

                    if (requiredHours > 0)
                    {
                        hourlyRate = monthlySalary / requiredHours;
                        baseSalary = totalWorkedHours * hourlyRate;
                    }
                    else
                    {
                        baseSalary = monthlySalary; // في حالة عدم وجود ساعات مطلوبة، يتم إعطاء المرتب كاملاً
                    }
                }
                else if (employee.SalaryType == "بالساعة" || employee.SalaryType == "Hourly")
                {
                    // المرتب بالساعة
                    hourlyRate = employee.SalaryValue ?? 0;
                    baseSalary = totalWorkedHours * hourlyRate;
                }
                else if (employee.SalaryType == "يومي" || employee.SalaryType == "Daily")
                {
                    // المرتب اليومي
                    int workedDays = attendanceRecords.Count(a => a.Status == "حاضر" || a.Status == "Present");
                    decimal dailyRate = employee.SalaryValue ?? 0;
                    baseSalary = workedDays * dailyRate;
                }

                // حساب مبلغ الساعات الإضافية
                decimal overtimeAmount = totalOvertimeHours * (employee.OvertimeRate ?? 0);

                // حساب مجموع السلف غير المسددة في نفس الشهر
                decimal advancesAmount = db.Advances
                    .Where(a => a.EmployeeId == employeeId &&
                               a.Month == month &&
                               a.Year == year &&
                               a.IsSettled == false)
                    .Sum(a => (decimal?)a.Amount) ?? 0;

                // حساب المرتب النهائي
                decimal finalSalary = baseSalary + overtimeAmount - advancesAmount;

                // حساب عدد أيام العمل
                int workedDaysCount = attendanceRecords.Count(a => a.Status == "حاضر" || a.Status == "Present");
                // var company = db.AppSettings.FirstOrDefault(s => s.isActive == true);
                // إنشاء سجل المرتب
                int safeId = Convert.ToInt32(save1.SelectedValue);
                var safa = db.tb_safe.Find(safeId);
                Salary newSalary = new Salary
                {
                    EmployeeId = employeeId,
                    Month = month,
                    Year = year,
                    IsPaid = true,
                    TotalWorkedHours = totalWorkedHours,
                    BaseSalary = baseSalary,
                    OvertimeAmount = overtimeAmount,
                    AdvancesAmount = advancesAmount,
                    FinalSalary = finalSalary,
                    NameEmployee = employee.EmployeeName,
                    name_company = namecompany1.Text,
                    safeid = safeId,
                    safename = safa.safe_name,
                    Salariesdate = DateTime.Now


                };

                db.Salaries.Add(newSalary);

                // تحديث حالة السلف إلى مسددة
                var advances = db.Advances
                    .Where(a => a.EmployeeId == employeeId &&
                               a.Month == month &&
                               a.Year == year &&
                               a.IsSettled == false)
                    .ToList();

                foreach (var advance in advances)
                {
                    advance.IsSettled = true;
                }
                var safe = db.tb_safe.FirstOrDefault(b => b.safe_name == save1.Text);
                safe.safe_count -= Convert.ToDouble(finalSalary);

                db.SaveChanges();

                // عرض تفاصيل المرتب
                string details = $"تفاصيل المرتب:\n\n" +
                               $"الموظف: {employee.EmployeeName}\n" +
                               $"الشهر: {month}/{year}\n" +
                               $"عدد أيام العمل: {workedDaysCount}\n" +
                               $"ساعات العمل: {totalWorkedHours}\n" +
                               $"الساعات الإضافية: {totalOvertimeHours}\n" +
                               $"المرتب الأساسي: {baseSalary:N2} جنيه\n" +
                               $"مبلغ الإضافي: {overtimeAmount:N2} جنيه\n" +
                               $"السلف المخصومة: {advancesAmount:N2} جنيه\n" +
                               $"المرتب النهائي: {finalSalary:N2} جنيه";

                MessageBox.Show(details, "تم حساب المرتب بنجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

                comboBox_Employee_Salary.SelectedIndex = -1;
                updata_data();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================
        // عرض المرتبات وطباعة التقرير في DevExpress
        // ============================
        private void btn_show_Salaries_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRow = gridView_Salaries.GetFocusedRow() as dynamic;

                if (selectedRow == null)
                {
                    MessageBox.Show("من فضلك اختر مرتب لطباعة التقرير", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    updata_data();
                    return;
                }

                int salaryId = selectedRow.SalaryId;
                ShowSalaryReport(salaryId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في عرض التقرير: " + ex.Message + "\n\nStack Trace: " + ex.StackTrace,
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================
        // عرض تقرير المرتب - مبسط ومحسّن
        // ============================
        private void ShowSalaryReport(int salaryId)
        {
            try
            {
                // جلب بيانات المرتب
                var salary = db.Salaries.Find(salaryId);
                if (salary == null)
                {
                    MessageBox.Show("المرتب غير موجود", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // جلب بيانات الموظف
                var employee = db.Employees.Find(salary.EmployeeId);
                if (employee == null)
                {
                    MessageBox.Show("بيانات الموظف غير موجودة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // حساب بداية ونهاية الشهر
                int month = salary.Month ?? DateTime.Now.Month;
                int year = salary.Year ?? DateTime.Now.Year;
                DateTime startDate = new DateTime(year, month, 1);
                DateTime endDate = startDate.AddMonths(1).AddDays(-1);

                // جلب سجلات الحضور
                var attendanceRecords = db.Attendances
                    .Where(a => a.EmployeeId == salary.EmployeeId &&
                               a.AttendDate >= startDate &&
                               a.AttendDate <= endDate)
                    .ToList();

                int workedDays = attendanceRecords.Count(a => a.Status == "حاضر" || a.Status == "Present");
                decimal overtimeHours = attendanceRecords.Sum(a => a.OvertimeHours ?? 0);

                // إنشاء DataTable للتقرير
                DataTable dt = new DataTable();
                dt.TableName = "SalaryReport";

                // إضافة الأعمدة
                dt.Columns.Add("EmployeeName", typeof(string));
                dt.Columns.Add("JobTitle", typeof(string));
                dt.Columns.Add("Month", typeof(string));
                dt.Columns.Add("Year", typeof(string));
                dt.Columns.Add("WorkedDays", typeof(string));
                dt.Columns.Add("TotalWorkedHours", typeof(string));
                dt.Columns.Add("OvertimeHours", typeof(string));
                dt.Columns.Add("BaseSalary", typeof(string));
                dt.Columns.Add("OvertimeAmount", typeof(string));
                dt.Columns.Add("AdvancesAmount", typeof(string));
                dt.Columns.Add("FinalSalary", typeof(string));
                dt.Columns.Add("PrintDate", typeof(string));

                // إضافة الصف
                DataRow row = dt.NewRow();
                row["EmployeeName"] = salary.NameEmployee ?? "غير محدد";
                row["JobTitle"] = employee.JobTitle ?? "غير محدد";
                row["Month"] = month.ToString();
                row["Year"] = year.ToString();
                row["WorkedDays"] = workedDays.ToString();
                row["TotalWorkedHours"] = (salary.TotalWorkedHours ?? 0).ToString("N2");
                row["OvertimeHours"] = overtimeHours.ToString("N2");
                row["BaseSalary"] = (salary.BaseSalary ?? 0).ToString("N2");
                row["OvertimeAmount"] = (salary.OvertimeAmount ?? 0).ToString("N2");
                row["AdvancesAmount"] = (salary.AdvancesAmount ?? 0).ToString("N2");
                row["FinalSalary"] = (salary.FinalSalary ?? 0).ToString("N2");
                row["PrintDate"] = salary.Salariesdate.HasValue
                    ? salary.Salariesdate.Value.ToString("dd/MM/yyyy")
                    : "";
                dt.Rows.Add(row);

                // إنشاء التقرير
                rpt_Salary_Report report = new rpt_Salary_Report();
                report.DataSource = dt;

                // عرض التقرير
                report.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ في إنشاء التقرير:\n\n" +
                    ex.Message + "\n\n" +
                    "التفاصيل: " + ex.StackTrace,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================
        // حذف مرتب
        // ============================
        private void btn_delete_Salaries_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRow = gridView_Salaries.GetFocusedRow() as dynamic;

                if (selectedRow == null)
                {
                    MessageBox.Show("من فضلك اختر مرتب للحذف", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int salaryId = selectedRow.SalaryId;
                var salary = db.Salaries.Find(salaryId);

                if (salary == null)
                {
                    MessageBox.Show("المرتب غير موجود", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                var result = MessageBox.Show("هل أنت متأكد من حذف هذا المرتب؟\nسيتم إلغاء تسوية السلف المرتبطة به.",
                    "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // إلغاء تسوية السلف
                    var advances = db.Advances
                        .Where(a => a.EmployeeId == salary.EmployeeId &&
                                   a.Month == salary.Month &&
                                   a.Year == salary.Year &&
                                   a.IsSettled == true)
                        .ToList();

                    foreach (var advance in advances)
                    {
                        advance.IsSettled = false;
                    }

                    db.Salaries.Remove(salary);

                    var safe = db.tb_safe.FirstOrDefault(b => b.safe_name == save1.Text);
                    safe.safe_count += Convert.ToDouble(salary.FinalSalary);
                    db.SaveChanges();

                    MessageBox.Show("تم حذف المرتب بنجاح", "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    updata_data();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================
        // دوال مساعدة إضافية
        // ============================

        // تحديث حالة الدفع للمرتب
        public void MarkSalaryAsPaid(int salaryId)
        {
            try
            {
                var salary = db.Salaries.Find(salaryId);
                if (salary != null)
                {
                    salary.IsPaid = true;
                    db.SaveChanges();
                    MessageBox.Show("تم تحديث حالة المرتب إلى مدفوع", "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    updata_data();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
