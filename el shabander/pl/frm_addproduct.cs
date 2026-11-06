using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using el_shabander.epl;
using ZXing;

namespace el_shabander.pl
{
    public partial class frm_addproduct : Form
    {
        DB_BarbershopEntities db = new DB_BarbershopEntities();
        tb_service tb_service = new tb_service();
        bl.methods methods = new bl.methods();
        DataTable datasells = new DataTable();
        //pl.frm_supp frm_Cat = new frm_supp();
        public int id;
        int selectrowindex;
        public frm_addproduct()

        {
            InitializeComponent();
        }
        private void ShowDialogMessage(string message)
        {
            dialog dialog = new dialog
            {
                Width = this.Width
            };
            dialog.txt_capthion.Text = message;
            dialog.Show();
        }
        private string GenerateUniqueCode()
        {
            Random random = new Random();
            string code;
            bool isUnique;

            do
            {
                code = random.Next(10000000, 99999999).ToString();
                isUnique = !db.tb_service.Any(x => x.code == code); // التحقق من أن الكود غير مكرر
            }
            while (!isUnique);

            return code;
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            toast toast = new toast();
            dialog dialog = new dialog();
            if (string.IsNullOrEmpty(edt_name.Text))
            {

                ShowDialogMessage("اسم الخدمة مطلوب");
              
                return;
            }

            // التحقق من وجود name_main و name_cat في قاعدة البيانات
            bool isMainExists = db.tb_main.Any(x => x.name_main == edt_supp.Text);
           

            if (!isMainExists)
            {

                ShowDialogMessage("اسم القائمه غير موجود");
                
                return;
            }
            if (dataGridView1.Rows.Count - 1 == 0)
            {


                ShowDialogMessage("الرجاء اضافة اصناف");
               
                return;
            }

            // إضافة أو تعديل الخدمة
            if (id == 0)
            {
               
                tb_service.name_product = edt_name.Text;
                tb_service.name_main = edt_supp.Text;
                tb_service.name_cat = edt_cat.Text;
                tb_service.pro_image = bl.methods.convert_byte(pic_cover.Image);
                tb_service.price = Convert.ToDouble(edt_sales.Text);
                tb_service.cost = Convert.ToDouble(edt_max.Text);
               // tb_service.type_product = edt_type.Text;
                tb_service.barcode_img= bl.methods.convert_byte(pictureEdit1.Image);
                tb_service.code = string.IsNullOrWhiteSpace(edt_code.Text) ? GenerateUniqueCode() : edt_code.Text;
                db.tb_service.Add(tb_service);
                db.SaveChanges();
                ss();
                toast.Width = this.Width;
                toast.txt_caption.Text = "تم إضافة خدمة جديد";
                toast.Show();
                this.Close();
            }
            else
            {
                tb_service = db.tb_service.Where(x => x.id == id).FirstOrDefault();
               
                tb_service.name_product = edt_name.Text;
                tb_service.name_main = edt_supp.Text;
                tb_service.name_cat = edt_cat.Text;
                tb_service.pro_image = bl.methods.convert_byte(pic_cover.Image);
                tb_service.price = Convert.ToDouble(edt_sales.Text);
                tb_service.cost = Convert.ToDouble(edt_max.Text);
               // tb_service.type_product = edt_type.Text;
                tb_service.barcode_img = bl.methods.convert_byte(pictureEdit1.Image);
                tb_service.code = string.IsNullOrWhiteSpace(edt_code.Text) ? GenerateUniqueCode() : edt_code.Text;
                db.Entry(tb_service).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                ss();
                toast.Width = this.Width;
                toast.txt_caption.Text = "تم تعديل الخدمة بنجاح";
                toast.Show();
                this.Close();
            }
        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void edt_sales_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_sales.Text))
            {
                // إذا كانت القيمة فارغة، يمكنك تعيين القيمة الافتراضية مرة أخرى
                edt_sales.Text = "1";
            }
        }

        private void edt_max_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_max.Text))
            {
                // إذا كانت القيمة فارغة، يمكنك تعيين القيمة الافتراضية مرة أخرى
                edt_max.Text = "0";
            }
        }

        private void frm_addproduct_Activated(object sender, EventArgs e)
        {


        }
        private void btnAddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select an Image",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",  // أنواع الصور المدعومة
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)  // مجلد الصور الافتراضي
            };

            // إظهار نافذة اختيار الملفات والتحقق إذا كان المستخدم قد اختار صورة
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // تحميل الصورة المختارة في PictureEdit
                pic_cover.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void frm_addproduct_Load(object sender, EventArgs e)
        {
            datasells.Columns.Add("اسم الصنف");
            datasells.Columns.Add("التكلفة");
            datasells.Columns.Add("الوحدة");
            dataGridView1.DataSource = datasells;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DefaultCellStyle.Font = new Font("cairo", 13);  // يمكنك تعديل نوع وحجم الخط حسب الحاجة
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("cairo", 12, FontStyle.Bold);  // تكبير خط رؤوس الأعمدة
            dataGridView1.DefaultCellStyle.ForeColor = Color.Red;
            dataGridView1.ReadOnly = true;
            btn_edit.Enabled = false;
            btn_delete.Enabled = false;
            if (id == 0)
            {
                var r2 = db.tb_main.Select(x => x.name_main).ToList();


                edt_supp.DataSource = r2;

                // AutoCompleteStringCollection acsc1 = new AutoCompleteStringCollection();
                AutoCompleteStringCollection acsc2 = new AutoCompleteStringCollection();


                acsc2.AddRange(r2.ToArray());

                // edt_name.AutoCompleteCustomSource = acsc1;
                edt_supp.AutoCompleteCustomSource = acsc2;
                var r3 = db.tb_cat.Select(x => x.cat_name).ToList();


                edt_cat.DataSource = r3;

                // AutoCompleteStringCollection acsc1 = new AutoCompleteStringCollection();
                AutoCompleteStringCollection acsc3 = new AutoCompleteStringCollection();


                acsc3.AddRange(r3.ToArray());

                // edt_name.AutoCompleteCustomSource = acsc1;
                edt_cat.AutoCompleteCustomSource = acsc3;
               
                printcode.Visible = false;


            }else
            {

                var r3 = db.tb_cat.Select(x => x.cat_name).ToList();


                edt_cat.DataSource = r3;

                // AutoCompleteStringCollection acsc1 = new AutoCompleteStringCollection();
                AutoCompleteStringCollection acsc3 = new AutoCompleteStringCollection();


                acsc3.AddRange(r3.ToArray());

                // edt_name.AutoCompleteCustomSource = acsc1;
                edt_cat.AutoCompleteCustomSource = acsc3;
                var listorder = db.tb_order_cat.Where(x => x.product_id == id).ToList();
                for (int i = 0; i < listorder.Count; i++)
                {
                    //tb_Ordersell.sell_id = tB_sell.id;
                    datasells.Rows.Add(listorder[i].name_cat,
                        listorder[i].qt_cat, listorder[i].weight);

                }
                printcode.Visible = true;
            }
        }

        private void btn_addcat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_cat.Text) || edt_sales == null)
            {
                MessageBox.Show("الرجاء ادخال اسم الصنف");
            }
            else
            {
                bool isDuplicate = false;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == edt_cat.Text)
                    {
                        // إذا كانت القيمة موجودة، قم بتحديث الكمية والسعر الإجمالي
                        MessageBox.Show("الرجاء ادخال اسم صنف جديد");
                        isDuplicate = true;
                        break;
                    }
                }

                if (!isDuplicate)
                {
                    var tb_cats = db.tb_cat.Where(x => x.cat_name == edt_cat.Text).FirstOrDefault();
                    if (tb_cats != null) { 
                    DataRow newRow = datasells.NewRow();
                    newRow[0] = edt_cat.Text;
                    newRow[1] = edt_sales.Text;
                    
                    newRow[2] = tb_cats.unit;

                    datasells.Rows.Add(newRow);

                    }else
                    {
                        MessageBox.Show("الرجاءاضافى صنف فى الاصناف اولا ");
                    }
                }

               
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            DataGridViewRow newrow = dataGridView1.Rows[selectrowindex];

            newrow.Cells[0].Value = edt_cat.Text;
            newrow.Cells[1].Value = edt_sales.Text;
            var tb_cats = db.tb_cat.Where(x => x.cat_name == edt_cat.Text).FirstOrDefault();
            newrow.Cells[2].Value = tb_cats.unit;
            btn_edit.Enabled = false;
            btn_delete.Enabled = false;
            btn_addcat.Enabled = true;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowindex);
            btn_edit.Enabled = false;
            btn_delete.Enabled = false;
            btn_addcat.Enabled = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                selectrowindex = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                if (row.Cells[0].Value != null && !string.IsNullOrEmpty(row.Cells[0].Value.ToString()))
                {

                    edt_cat.Text = row.Cells[0].Value.ToString();
                    edt_sales.Text = row.Cells[1].Value.ToString();


                    

                    btn_edit.Enabled = true;
                    btn_delete.Enabled = true;
                    btn_addcat.Enabled = false;
                }
                else
                {
                    // عرض رسالة عند محاولة الوصول إلى خلايا فارغة أو تحتوي على قيم غير صالحة
                    MessageBox.Show("الصف الذي قمت بالنقر عليه يحتوي على بيانات غير صالحة.");
                }
            }
        }
        public void ss()
        {
            if (id == 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    // إنشاء كائن جديد من tb_order_appointment لكل صف
                    var tb_order_cat = new tb_order_cat
                    {
                        product_id = tb_service.id,
                        name_cat= dataGridView1.Rows[i].Cells[0].Value.ToString(),
                        qt_cat= Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value),

                        weight = dataGridView1.Rows[i].Cells[2].Value.ToString(),
                       
                        //  total_earnings = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value)
                    };

                    try
                    {
                        db.tb_order_cat.Add(tb_order_cat);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                // حذف الفواتير القديمة المرتبطة بهذا المعرف


                // جلب السجلات المطابقة من tb_order_appointment
                var ordersToRemove = db.tb_order_cat.Where(x => x.product_id == id).ToList();

                // تحقق من وجود السجلات قبل الحذف
                if (ordersToRemove.Any())
                {
                    db.tb_order_cat.RemoveRange(ordersToRemove);
                    db.SaveChanges();
                    // MessageBox.Show("Records removed successfully.");
                }



                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    // إنشاء كائن جديد من tb_order_appointment لكل صف
                    var tb_order_cat = new tb_order_cat
                    {
                        product_id = tb_service.id,
                        name_cat = dataGridView1.Rows[i].Cells[0].Value.ToString(),
                        qt_cat = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value),

                        weight = dataGridView1.Rows[i].Cells[2].Value.ToString(),

                        //  total_earnings = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value)
                    };

                    try
                    {
                        db.tb_order_cat.Add(tb_order_cat);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void btn_createcode_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            string code;
            bool isUnique;

            do
            {
                code = random.Next(10000000, 99999999).ToString();
                isUnique = !db.tb_service.Any(x => x.code == code); // التحقق من أن الكود غير مكرر
            }
            while (!isUnique);

            edt_code.Text = code;
        }

        private void edt_code_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_code.Text))
            {
                ShowDialogMessage("الرجاءادخال كود");
            }
            else
            {
                GenerateQRAndBarcodeSideBySide(edt_code.Text);
            }
        }
        private void GenerateQRAndBarcodeSideBySide(string text)
        {
            // 1. إنشاء QR Code
            BarcodeWriter qrWriter = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = 200,  // ارتفاع QR Code
                    Width = 200   // عرض QR Code
                }
            };
            Bitmap qrCodeImage = qrWriter.Write(text);

            // 2. إنشاء Barcode (Code 128)
            BarcodeWriter barcodeWriter = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128,
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = 180,  // نفس ارتفاع QR Code
                    Width = 500    // عرض Barcode
                }
            };
            Bitmap barcodeImage = barcodeWriter.Write(text);

            // 3. دمج QR Code و Barcode جنبًا إلى جنب
            int width = qrCodeImage.Width + barcodeImage.Width + 10; // إجمالي العرض مع مسافة صغيرة
            int height = Math.Max(qrCodeImage.Height, barcodeImage.Height); // الارتفاع هو الأكبر بين الصورتين

            Bitmap combinedImage = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(combinedImage))
            {
                g.Clear(Color.White);  // خلفية بيضاء

                // رسم QR Code على اليسار
                g.DrawImage(qrCodeImage, 0, (height - qrCodeImage.Height) / 2);

                // رسم Barcode على اليمين
                g.DrawImage(barcodeImage, qrCodeImage.Width + 10, (height - barcodeImage.Height) / 2);
            }

            // عرض الصورة المدمجة في PictureBox
            pictureEdit1.Image = combinedImage;

            // حفظ الصورة (اختياري)
            combinedImage.Save("QR_and_Barcode_SideBySide.png");
        }

        private void printcode_Click(object sender, EventArgs e)
        {
            var setting = db.AppSettings.FirstOrDefault(s => s.id == 1);
            if (setting.printcod == "50mmx25mm")
            {
                XtraReport1 report = new XtraReport1();

                // بيانات عادية
                report.productName.Text =edt_name.Text;
                report.price.Text = edt_max.Text;
                report.company.Text = setting.namecomp;

                // الصورة
                report.barcodeImage.Image = pictureEdit1.Image;  // ✅ بدل ImageSource استخدم Image عادي
                
                report.barcodeImage.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
                ReportPrintTool printTool = new ReportPrintTool(report);
                this.Close();
                printTool.ShowPreviewDialog();
               
            }
            else
            {
                XtraReport2 report = new XtraReport2();

                // بيانات عادية
                report.productName.Text = edt_name.Text;
                report.price.Text = edt_max.Text;
                report.company.Text = setting.namecomp;

                // الصورة
                report.barcodeImage.Image = pictureEdit1.Image;  // ✅ بدل ImageSource استخدم Image عادي
                report.barcodeImage.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;  // عشان تتظبط بالحجم المطلوب

                ReportPrintTool printTool = new ReportPrintTool(report);
                this.Close();
                printTool.ShowPreviewDialog();
               
            }
            
        }
    }
}
