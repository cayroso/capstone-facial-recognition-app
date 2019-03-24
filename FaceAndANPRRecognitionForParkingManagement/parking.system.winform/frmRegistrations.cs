using parking.system.winform.data;
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
    public partial class frmRegistrations : Form
    {
        public frmRegistrations()
        {
            InitializeComponent();
        }

        private void frmRegistrations_Load(object sender, EventArgs e)
        {
            var db = new AppDbContext();

            var regs = db.Registrations.ToList();

            lvwRegistrations.Columns.Add("Name");
            //lvwRegistrations.Columns.Add("Plate Number");
            //lvwRegistrations.Columns.Add("Date Start");
            //lvwRegistrations.Columns.Add("Date End");
            foreach (var r in regs)
            {
                var li = new ListViewItem(r.Fullname);
                li.Tag = r.RegistrationId;
                //li.SubItems.Add(r.Fullname);
                lvwRegistrations.Items.Add(li);
            }

            lvwRegistrations.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwRegistrations.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void lvwRegistrations_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = null;

            if (lvwRegistrations.SelectedItems.Count > 0)
            {
                var selected = lvwRegistrations.SelectedItems[0];

                var db = new AppDbContext();

                var reg = db.Registrations.FirstOrDefault(p => p.RegistrationId == selected.Tag.ToString());

                if (reg != null)
                {

                    var img = reg.Images.OrderBy(p => p.Filename)
                        .FirstOrDefault(p => p.RegistrationImageType == EnumRegistrationImageType.Face);

                    var filename = $@"TrainedFaces\{img.Filename}";
                    pictureBox1.Image = new Bitmap(filename);
                }

            }
        }
    }
}
