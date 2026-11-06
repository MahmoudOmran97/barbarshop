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
    public partial class frm_queue : Form
    {
        public frm_queue()

        {
            InitializeComponent();
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
                this.DialogResult = DialogResult.OK;
            else
                MessageBox.Show("اختر عميل أولاً");
        }
    }
}
