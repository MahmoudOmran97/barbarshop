using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace el_shabander.pl
{
    public partial class frm_notification_view : Form
    {
        public frm_notification_view(string notificationText)
        {
            InitializeComponent();
            txtDetails.Text = notificationText;
        }
    }
}
