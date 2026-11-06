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
using Microsoft.Reporting.WinForms;
namespace el_shabander.pl
{
    public partial class frm_employee_absent : Form
    {
        DB_BarbershopEntities db = new DB_BarbershopEntities();
        public int id;

        public frm_employee_absent()
        {
            InitializeComponent();
        }

        private void frm_stor_add_Activated(object sender, EventArgs e)
        {
        }

        private void frm_stor_add_Load(object sender, EventArgs e)
        {
            LoadAttendanceData();
        }

        private void LoadAttendanceData()
        {
            try
            {
                var attendance = db.Attendances.FirstOrDefault(x => x.AttendanceId == id);

                if (attendance != null)
                {
                    // عرض البيانات
                    NameEmployee.Text = attendance.NameEmployee ?? "";
                    Status.Text = attendance.Status ?? "";
                    WorkedHours.Text = attendance.WorkedHours?.ToString("0.00") ?? "0";
                    OvertimeHours.Text = attendance.OvertimeHours?.ToString("0.00") ?? "0";
                    AttendDate.Text = attendance.AttendDate?.ToString("dd/MM/yyyy") ?? "";

                    // وقت الحضور
                    if (attendance.CheckIn.HasValue)
                    {
                        TimeSpan checkIn = attendance.CheckIn.Value;
                        CheckIn.Text = DateTime.Today.Add(checkIn).ToString("hh:mm:ss tt");
                    }
                    else
                    {
                        CheckIn.Text = "لم يتم التسجيل";
                    }

                    // وقت الانصراف
                    if (attendance.CheckOut.HasValue)
                    {
                        TimeSpan checkOut = attendance.CheckOut.Value;
                        CheckOut.Text = DateTime.Today.Add(checkOut).ToString("hh:mm:ss tt");
                    }
                    else
                    {
                        CheckOut.Text = "لم يتم التسجيل";
                    }

                    // تغيير لون المربع حسب الحالة
                    SetStatusColor(attendance.Status);

                    // جعل الحقول للقراءة فقط
                    NameEmployee.ReadOnly = true;
                    Status.ReadOnly = true;
                    WorkedHours.ReadOnly = true;
                    OvertimeHours.ReadOnly = true;
                    AttendDate.ReadOnly = true;
                    CheckIn.ReadOnly = true;
                    CheckOut.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("لم يتم العثور على بيانات الحضور", "تنبيه",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل البيانات: " + ex.Message,
                                "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // دالة لتغيير لون المربع حسب الحالة
        private void SetStatusColor(string status)
        {
            if (string.IsNullOrEmpty(status))
            {
                panel_status.BackColor = Color.Gray;
                return;
            }

            status = status.Trim();

            if (status == "حاضر")
            {
                panel_status.BackColor = Color.LightGreen;
            }
            else if (status == "غائب")
            {
                panel_status.BackColor = Color.Red;
            }
            else if (status == "إجازة")
            {
                panel_status.BackColor = Color.Orange;
            }
            else
            {
                panel_status.BackColor = Color.Gray;
            }
        }
    }
}