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

namespace el_shabander.pl
{
    public partial class frm_employees_add : Form
    {
        DB_BarbershopEntities db = new DB_BarbershopEntities();
        Employee tb_Employees = new Employee();
        bl.methods methods = new bl.methods();

        // ✅ إضافة المتغيرات الناقصة
        private HikvisionService _hikvision;
        private bool _deviceConnected = false;

        private string DEVICE_IP = Properties.Settings.Default.ip_hik;
        private string DEVICE_USER = Properties.Settings.Default.user_hik;
        private string DEVICE_PASS = Properties.Settings.Default.pass_hik;

        public int id;

        public frm_employees_add()
        {
            InitializeComponent();
        }

        // ✅ تحويل الميثود إلى async
        private async void btn_add_Click(object sender, EventArgs e)
        {
            // ← مش بنعمل dialog و toast هنا - بنعملهم جوه كل حالة
            if (string.IsNullOrWhiteSpace(edt_name.Text))
            {
                dialog dialog = new dialog();
                dialog.Width = this.Width;
                dialog.txt_capthion.Text = "  اسم الموظف مطلوب";
                dialog.Show();
                return;
            }

            if (string.IsNullOrWhiteSpace(edt_typeemp.Text))
            {
                dialog dialog = new dialog();
                dialog.Width = this.Width;
                dialog.txt_capthion.Text = "  المسمى الوظيفي مطلوب";
                dialog.Show();
                return;
            }

            if (string.IsNullOrWhiteSpace(edt_freeday.Text))
            {
                dialog dialog = new dialog();
                dialog.Width = this.Width;
                dialog.txt_capthion.Text = "  نوع الوظيفة مطلوب";
                dialog.Show();
                return;
            }

            try
            {
                if (id == 0)
                {
                    tb_Employees.EmployeeName = edt_name.Text.Trim();
                    tb_Employees.JobTitle = edt_typeemp.Text.Trim();
                    tb_Employees.SalaryType = edt_freeday.Text.Trim();
                    tb_Employees.SalaryValue = string.IsNullOrWhiteSpace(edt_salery.Text) ? 0 : Convert.ToDecimal(edt_salery.Text);
                    tb_Employees.RequiredMonthlyHours = string.IsNullOrWhiteSpace(edt_work_hours.Text) ? 0 : Convert.ToInt32(edt_work_hours.Text);
                    tb_Employees.OvertimeRate = string.IsNullOrWhiteSpace(edt_overtime_rate.Text) ? 0 : Convert.ToDecimal(edt_overtime_rate.Text);
                    tb_Employees.workingdays = Convert.ToInt32(workingdays.Value);
                    tb_Employees.FaceImage = _selectedImageBytes;
                    tb_Employees.EmployeePassword = edt_password.Text.Trim();
                    db.Employees.Add(tb_Employees);
                    db.SaveChanges();

                    await SyncEmployeeToDevice(tb_Employees);

                    // ← toast جديد هنا
                    toast toast = new toast();
                    toast.Width = this.Width;
                    toast.txt_caption.Text = "تم اضافة موظف جديد بنجاح";
                    toast.Show();
                    this.Close();
                }
                else
                {
                    tb_Employees = db.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();

                    if (tb_Employees != null)
                    {
                        tb_Employees.EmployeeName = edt_name.Text.Trim();
                        tb_Employees.JobTitle = edt_typeemp.Text.Trim();
                        tb_Employees.SalaryType = edt_freeday.Text.Trim();
                        tb_Employees.SalaryValue = string.IsNullOrWhiteSpace(edt_salery.Text) ? 0 : Convert.ToDecimal(edt_salery.Text);
                        tb_Employees.RequiredMonthlyHours = string.IsNullOrWhiteSpace(edt_work_hours.Text) ? 0 : Convert.ToInt32(edt_work_hours.Text);
                        tb_Employees.OvertimeRate = string.IsNullOrWhiteSpace(edt_overtime_rate.Text) ? 0 : Convert.ToDecimal(edt_overtime_rate.Text);
                        tb_Employees.workingdays = Convert.ToInt32(workingdays.Value);
                        tb_Employees.FaceImage = _selectedImageBytes;
                        tb_Employees.EmployeePassword = edt_password.Text.Trim();
                        db.Entry(tb_Employees).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        await SyncEmployeeToDevice(tb_Employees);

                        // ← toast جديد هنا
                        toast toast = new toast();
                        toast.Width = this.Width;
                        toast.txt_caption.Text = "تم تعديل بيانات الموظف بنجاح";
                        toast.Show();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // ← dialog جديد هنا
                dialog dialog = new dialog();
                dialog.Width = this.Width;
                dialog.txt_capthion.Text = "حدث خطأ: " + ex.Message;
                dialog.Show();
            }
        }

        private async Task SyncEmployeeToDevice(Employee emp)
        {
            try
            {
                if (emp == null) return;

                if (_hikvision == null)
                    _hikvision = new HikvisionService(DEVICE_IP, DEVICE_USER, DEVICE_PASS);

                bool connected = await _hikvision.TestConnectionAsync();
                if (!connected)
                {
                    MessageBox.Show("تعذر الاتصال بجهاز البصمة", "تنبيه",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ لو مفيش صورة جديدة اتختارت - بس سجّل البيانات بدون صورة
                if (!_newImageSelected)
                {
                    var regOnly = await _hikvision.RegisterEmployeeAsync(
                        emp.EmployeeId, emp.EmployeeName, emp.EmployeePassword ?? "");

                    if (!regOnly.Success)
                        MessageBox.Show($"فشل تسجيل الموظف:\n{regOnly.Message}");

                    return; // ← خلاص، مفيش صورة تترفع
                }

                // ✅ لو في صورة جديدة - احذف المستخدم وأعد إنشاؤه مع الصورة الجديدة
                await _hikvision.DeleteUserFromDeviceAsync(emp.EmployeeId);
                await Task.Delay(500);

                var regResult = await _hikvision.RegisterEmployeeAsync(
                    emp.EmployeeId, emp.EmployeeName, emp.EmployeePassword ?? "");

                if (!regResult.Success)
                {
                    MessageBox.Show($"فشل تسجيل الموظف:\n{regResult.Message}");
                    return;
                }

                // ✅ ارفع الصورة الجديدة بالظبط زي أول مرة
                string tempPath = System.IO.Path.Combine(
                    System.IO.Path.GetTempPath(),
                    $"face_{emp.EmployeeId}.jpg");

                System.IO.File.WriteAllBytes(tempPath, _selectedImageBytes);

                var faceResult = await _hikvision.UploadFaceAsync(emp.EmployeeId, tempPath);

                if (System.IO.File.Exists(tempPath))
                    System.IO.File.Delete(tempPath);

                if (!faceResult.Success)
                    MessageBox.Show($"تحذير: فشل رفع الصورة:\n{faceResult.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ: {ex.Message}");
            }
        }
        // ✅ إصلاح using declarations لـ C# 7.3


        private void edt_salery_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(edt_salery.Text))
            {
                decimal result;
                if (!decimal.TryParse(edt_salery.Text, out result))
                {
                    MessageBox.Show("يرجى إدخال أرقام فقط", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void LoadEmployeeData()
        {
            try
            {
                tb_Employees = db.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();

                if (tb_Employees != null)
                {
                    edt_name.Text = tb_Employees.EmployeeName;
                    edt_typeemp.Text = tb_Employees.JobTitle;
                    edt_freeday.Text = tb_Employees.SalaryType;
                    edt_salery.Text = tb_Employees.SalaryValue.ToString();
                    edt_work_hours.Text = tb_Employees.RequiredMonthlyHours.ToString();
                    edt_overtime_rate.Text = tb_Employees.OvertimeRate.ToString();
                    workingdays.Value = Convert.ToInt32(tb_Employees.workingdays);
                    edt_password.Text = tb_Employees.EmployeePassword ?? "";
                    // ✅ تحميل صورة الموظف لو موجودة
                    if (tb_Employees.FaceImage != null && tb_Employees.FaceImage.Length > 0)
                    {
                        _selectedImageBytes = tb_Employees.FaceImage;
                        using (var ms = new System.IO.MemoryStream(_selectedImageBytes))
                        {
                            // ✅ إصلاح PictureEdit - استخدام Image property مباشرة
                            pic_employee.Image = Image.FromStream(ms);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل البيانات: " + ex.Message);
            }
        }

       
        private void edt_name_TextChanged(object sender, EventArgs e) { }
      

        private void frm_employees_add_Load(object sender, EventArgs e)
        {
            if (id == 0)
            {
                if (edt_typeemp.Items.Count > 0)
                    edt_typeemp.SelectedIndex = 0;

                if (edt_freeday.Items.Count > 0)
                    edt_freeday.SelectedIndex = 0;
            }
            else
            {
                LoadEmployeeData();
            }
        }

        public byte[] FaceImage { get; set; }
        public string FaceImagePath { get; set; }

        private byte[] _selectedImageBytes;
        private byte[] PrepareImageForHikvision(string imagePath)
        {
            using (var original = Image.FromFile(imagePath))
            {
                int targetWidth = 640;
                int targetHeight = 480;

                // ✅ حساب النسبة الصحيحة بدون تشويه
                float ratioX = (float)targetWidth / original.Width;
                float ratioY = (float)targetHeight / original.Height;
                float ratio = Math.Min(ratioX, ratioY);

                int newWidth = (int)(original.Width * ratio);
                int newHeight = (int)(original.Height * ratio);

                // ✅ توسيط الصورة في الكادر
                int offsetX = (targetWidth - newWidth) / 2;
                int offsetY = (targetHeight - newHeight) / 2;

                using (var bitmap = new Bitmap(targetWidth, targetHeight,
                    System.Drawing.Imaging.PixelFormat.Format24bppRgb))
                {
                    using (var g = Graphics.FromImage(bitmap))
                    {
                        g.Clear(Color.White);
                        g.InterpolationMode =
                            System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                        // ✅ رسم الصورة بنسبتها الصحيحة في المنتصف
                        g.DrawImage(original, offsetX, offsetY, newWidth, newHeight);
                    }

                    using (var ms = new System.IO.MemoryStream())
                    {
                        // ✅ JPEG بجودة 90% عشان الوجه يبقى واضح للجهاز
                        var jpegEncoder = System.Drawing.Imaging.ImageCodecInfo
                            .GetImageEncoders()
                            .FirstOrDefault(c => c.FormatID ==
                                System.Drawing.Imaging.ImageFormat.Jpeg.Guid);

                        var encoderParams = new System.Drawing.Imaging.EncoderParameters(1);
                        encoderParams.Param[0] = new System.Drawing.Imaging.EncoderParameter(
                            System.Drawing.Imaging.Encoder.Quality, 90L);

                        bitmap.Save(ms, jpegEncoder, encoderParams);
                        return ms.ToArray();
                    }
                }
            }
        }

        private bool _newImageSelected = false; // ← إضافة جديدة
                                                // ✅ إصلاح using declarations + PictureEdit SizeMode
        private void btn_select_image_Click(object sender, EventArgs e)
        {
            using (var openFile = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png",
                Title = "اختار صورة الموظف"
            })
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // ✅ شيك حجم الصورة قبل أي حاجة
                        long fileSizeKB = new System.IO.FileInfo(openFile.FileName).Length / 1024;
                        if (fileSizeKB > 200)
                        {
                            dialog dialog = new dialog();
                            dialog.Width = this.Width;
                            dialog.txt_capthion.Text = $"حجم الصورة {fileSizeKB} KB - يجب أن يكون أقل من 200 KB";
                            dialog.Show();
                            return;
                        }

                        _selectedImageBytes = PrepareImageForHikvision(openFile.FileName);
                        _newImageSelected = true;

                        using (var ms = new System.IO.MemoryStream(_selectedImageBytes))
                        {
                            pic_employee.Image = Image.FromStream(ms);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("خطأ في معالجة الصورة: " + ex.Message);
                    }
                }
            }
        }
    }
}