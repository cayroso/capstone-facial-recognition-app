using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parking.system.winform
{
    public partial class frmSplash : Form
    {
        Timer _timer = new Timer();
        int timeCount = 0;

        public frmSplash()
        {
            InitializeComponent();

            _timer.Interval = 1000;
            _timer.Tick += _timer_Tick;
            _timer.Enabled = true;
        }

        private void _timer_Tick(object sender, EventArgs e)
        {

            if (timeCount > 2)
            {
                //var frmMain = new frmMain();
                //frmMain.Show();

                this.Close();
            }
            timeCount++;
            //throw new NotImplementedException();
        }
    }
}
