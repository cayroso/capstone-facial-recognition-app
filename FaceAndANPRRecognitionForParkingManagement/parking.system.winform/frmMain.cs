using parking.system.winform.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parking.system.winform
{
    public partial class frmMain : Form
    {
        List<PictureBox> pbImages;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lvwParking.Columns.Add("Image");
            lvwParking.Columns.Add("Plate Number");
            lvwParking.Columns.Add("Date Start");
            lvwParking.Columns.Add("Date End");
            lvwParking.Columns.Add("Duration (hrs)");

            lvwParking.View = View.LargeIcon;
            lvwParking.LargeImageList = imageList1;
            imageList1.ImageSize = new Size(128, 128);

            pbImages = new List<PictureBox>
            {
                pb1, pb2, pb3, pb4, pb5, pb6
            };

            Init();

        }

        private void lvwParking_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            pbImages.ForEach(p => p.Image = null);
            
            if (lvwParking.SelectedItems.Count > 0)
            {
                var selected = lvwParking.SelectedItems[0];

                var db = new AppDbContext();

                var parking = selected.Tag as Parking;

                if (parking != null)
                {

                    var images = parking.FaceImages.ToList();

                    for (var i = 0; i < images.Count; i++)
                    {
                        var img = images[i];
                        var filename = $@"TrainedFaces\{img.Filename}";
                        if (File.Exists(filename))
                        {
                            using (var fs = File.Open(filename, FileMode.Open, FileAccess.Read))
                            using (var bmp = new Bitmap(fs))
                            {
                                pbImages[i].Image = new Bitmap(bmp);

                                fs.Close();
                                fs.Dispose();
                                bmp.Dispose();
                            }
                        }
                    }
                    
                    lblStart.Text = parking.DateStart.ToString();
                    lblEnd.Text = parking.DateEnd.ToString();
                    
                    var duration = (parking.DateEnd.GetValueOrDefault(DateTime.Now) - parking.DateStart).TotalHours;

                    lblTotalHours.Text = $"{duration.ToString("N2")} hr(s)";
                }                
            }
        }

        private void tsbRegister_Click(object sender, EventArgs e)
        {
            //var frm = new frmRegister();

            //frm.ShowDialog();

            //Init();
        }

        private void tsbRegistrations_Click(object sender, EventArgs e)
        {
            //var frm = new frmRegistrations();

            //frm.ShowDialog();

            //Init();
        }


        void Init()
        {
            var db = new AppDbContext();
            //var start = DateTime.Now.Date;
            //var end = DateTime.Now.Date.AddDays(1).AddMinutes(-1);

            var parking = db.Parkings.Where(p => p.DateEnd == null)
                .Include(p => p.FaceImages)
                //.Include("PlateImage")
                .OrderByDescending(p => p.DateStart)
                .ThenByDescending(p => p.DateEnd)
                .ToList();

            lvwParking.Items.Clear();
            imageList1.Images.Clear();

            pbImages.ForEach(p =>
            {
                if (p.Image != null)
                    p.Image.Dispose();
                p.Image = null;
            });

            foreach (var p in parking)
            {
                var filename = string.Empty;
                foreach (var img in p.FaceImages.ToList())
                {
                    filename = $@"TrainedFaces\{img.Filename}";

                    if (!imageList1.Images.ContainsKey(filename) && File.Exists(filename))
                    {
                        //var filePath = $@"TrainedFaces\{img.Filename}";
                        using (var fs = File.Open(filename, FileMode.Open, FileAccess.Read))
                        using (var bmp = new Bitmap(fs))
                        {
                            imageList1.Images.Add(filename, bmp);

                            fs.Close();
                            fs.Dispose();
                            bmp.Dispose();                                                        
                        }

                        break;
                    }
                }

                var li = new ListViewItem(p.PlateNumber);
                li.Tag = p;
                //li.SubItems.Add(p.PlateNumber);
                //li.SubItems.Add(p.DateStart.ToString());
                li.ImageKey = filename;

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
            frm.Dispose();

            Init();
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            var frm = new frmExit();
            frm.ShowDialog();
            frm.Dispose();

            Init();
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void lvwParking_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void btnParkingEntry_Click(object sender, EventArgs e)
        {
            var frm = new frmEntry();

            frm.ShowDialog();

            Init();

        }

        private void btnParkingExit_Click(object sender, EventArgs e)
        {
            var frm = new frmExit();

            frm.ShowDialog();

            Init();

        }
    }
}