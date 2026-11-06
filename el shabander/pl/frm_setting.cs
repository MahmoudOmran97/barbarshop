using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace el_shabander.pl
{
    public partial class frm_setting : Form
    {
        public frm_setting()
        {
            InitializeComponent();
            this.FormClosing += frm_setting_FormClosing;
        }

        private void btn_save_Click_1(object sender, EventArgs e)
        {
            try
            {
                // حفظ الإعدادات
                Properties.Settings.Default.nameuser = txt_nameserver.Text;
                Properties.Settings.Default.databasename = txt_data.Text;
                Properties.Settings.Default.password = txt_password.Text;
                Properties.Settings.Default.servername = txt_server.Text;
                Properties.Settings.Default.checkbox = checkBox1.Checked;
                Properties.Settings.Default.Save();

                MessageBox.Show("تم الحفظ بنجاح", "تاكيد");

                // بناء سلسلة الاتصال
                var qu = "\"";
                var constr = new StringBuilder();
                constr.Append(@"metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient;provider connection string=")
                      .Append(qu)
                      .Append("data source=")
                      .Append(Properties.Settings.Default.servername)
                      .Append(",1433;initial catalog=")
                      .Append(Properties.Settings.Default.databasename)
                      .Append(";user id=")
                      .Append(Properties.Settings.Default.nameuser)
                      .Append(";password=")
                      .Append(Properties.Settings.Default.password)
                      .Append(";MultipleActiveResultSets=True;App=EntityFramework")
                      .Append(qu)
                      .Append(";");

                // تحديث سلسلة الاتصال في ملف التكوين
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connectionStringSettings = config.ConnectionStrings.ConnectionStrings["DB_BarbershopEntities"];
                if (connectionStringSettings != null)
                {
                    connectionStringSettings.ConnectionString = constr.ToString();
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("connectionStrings");
                    var stral = connectionStringSettings.ConnectionString;
                    MessageBox.Show(stral);
                }
                else
                {
                    MessageBox.Show("لم يتم العثور على سلسلة الاتصال المحددة.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // إعادة تشغيل التطبيق
                Application.Restart();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء حفظ الإعدادات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frm_setting_Load(object sender, EventArgs e)
        {
            txt_nameserver.Text = Properties.Settings.Default.nameuser;
            txt_data.Text = Properties.Settings.Default.databasename;
            txt_password.Text = Properties.Settings.Default.password;
            txt_server.Text = Properties.Settings.Default.servername;
            checkBox1.Checked = Properties.Settings.Default.checkbox;
        }

        private void frm_setting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Environment.Exit(0);
            }
        }
    }
}
