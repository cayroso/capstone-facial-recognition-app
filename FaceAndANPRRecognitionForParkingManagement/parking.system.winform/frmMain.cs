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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            tsbExit.Enabled = false;

            lvwParking.Columns.Add("Name");
            lvwParking.Columns.Add("Plate Number");
            lvwParking.Columns.Add("Date Start");
            lvwParking.Columns.Add("Date End");
            lvwParking.Columns.Add("Duration (hrs)");

            Init();
        }

        private void lvwParking_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            pb1.Image = null;
            tsbExit.Enabled = lvwParking.SelectedItems.Count > 0;
            if (lvwParking.SelectedItems.Count > 0)
            {
                var selected = lvwParking.SelectedItems[0];

                var db = new AppDbContext();

                var parking = selected.Tag as Parking;

                if (parking != null)
                {

                    var images = parking.Registration.Images.Where(p => p.RegistrationImageType == EnumRegistrationImageType.Face).ToList();

                    pb1.Image = new Bitmap($@"TrainedFaces\{images[0].Filename}");
                    pb2.Image = new Bitmap($@"TrainedFaces\{images[1].Filename}");
                    pb3.Image = new Bitmap($@"TrainedFaces\{images[2].Filename}");
                    pb4.Image = new Bitmap($@"TrainedFaces\{images[3].Filename}");
                    pb5.Image = new Bitmap($@"TrainedFaces\{images[4].Filename}");
                    pb6.Image = new Bitmap($@"TrainedFaces\{images[5].Filename}");

                    tsbExit.Enabled = parking.DateEnd == null;
                }


            }
        }

        private void tsbRegister_Click(object sender, EventArgs e)
        {
            var frm = new frmRegister();

            frm.ShowDialog();

            Init();
        }

        private void tsbRegistrations_Click(object sender, EventArgs e)
        {
            var frm = new frmRegistrations();

            frm.ShowDialog();

            Init();
        }


        void Init()
        {
            var db = new AppDbContext();
            var start = DateTime.Now.Date;
            var end = DateTime.Now.Date.AddDays(1).AddMinutes(-1);

            var parking = db.Parkings.Where(p => (p.DateStart >= start && p.DateStart <= end) || p.DateEnd == null)
                .OrderByDescending(p => p.DateStart)
                .ThenByDescending(p => p.DateEnd)
                .ToList();

            lvwParking.Items.Clear();

            foreach (var p in parking)
            {
                var li = new ListViewItem(p.Registration.Fullname);
                li.Tag = p;
                li.SubItems.Add(p.PlateNumber);
                li.SubItems.Add(p.DateStart.ToString());

                if (p.DateEnd == null)
                {
                    li.SubItems.Add("n/a");
                }
                else
                {
                    li.SubItems.Add(p.DateEnd.GetValueOrDefault(DateTime.Now).ToString());
                }

                var duration = (p.DateEnd.GetValueOrDefault(DateTime.Now) - p.DateStart).TotalHours;
                li.SubItems.Add($"{duration.ToString("N2")} hr(s)");

                lvwParking.Items.Add(li);
            }

            lvwParking.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwParking.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void tsbEntry_Click(object sender, EventArgs e)
        {
            var frm = new frmEntry();

            frm.ShowDialog();

            Init();
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {

            if (lvwParking.SelectedItems.Count > 0 && MessageBox.Show("Are you sure?", "Exit Parking", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var parking = lvwParking.SelectedItems[0].Tag as Parking;

                if (parking != null)
                {
                    var db = new AppDbContext();

                    var data = db.Parkings.First(p => p.ParkingId == parking.ParkingId);

                    if (data.DateEnd != null)
                    {
                        MessageBox.Show("Registration already Exited the parking", "Exit Parking", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    data.DateEnd = DateTime.Now;

                    db.SaveChangesAsync();

                    MessageBox.Show("Exit parking successfull", "Exit Parking", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Init();
                }
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            Init();
        }
    }
}