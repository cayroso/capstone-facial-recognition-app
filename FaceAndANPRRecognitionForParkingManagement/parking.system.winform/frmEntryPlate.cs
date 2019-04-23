using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parking.system.winform
{
    public partial class frmEntryPlate : Form
    {
        private VideoCapture _capture = null;

        public string PlateNumber { get; set; }

        public frmEntryPlate()
        {
            InitializeComponent();

            var cameraIndex = int.Parse(ConfigurationManager.AppSettings["camera2"]);
            _capture = new VideoCapture(cameraIndex);
            _capture.ImageGrabbed += _capture_ImageGrabbed;
            _capture.Start();
        }


        private void _capture_ImageGrabbed(object sender, EventArgs e)
        {
            if (_capture == null || !_capture.IsOpened)
                return;

            Mat queryFrame = new Mat();

            _capture.Retrieve(queryFrame, 1);

            if (queryFrame == null)
            {
                return;
            }

            try
            {
                var image = queryFrame.ToImage<Bgr, byte>().Resize(400, 300, Emgu.CV.CvEnum.Inter.Cubic);

                if (lvwPlates.Items.Count <= 0)
                {
                    var apnr = new openalprnet.AlprNet("au", "", "");
                    apnr.TopN = 5;
                    var loaded = apnr.IsLoaded();
                    var bitmap = image.ToBitmap();
                    var result = apnr.Recognize(bitmap);

                    if (result.Plates.Any())
                    {
                        var firstPlate = result.Plates.First();

                        lvwPlates.Items.Clear();

                        foreach (var item in firstPlate.TopNPlates)
                        {
                            var str = $"{item.Characters} - {item.OverallConfidence.ToString("N2")}%";

                            var lvwItem = new ListViewItem
                            {
                                Text = item.Characters
                            };

                            lvwItem.SubItems.Add(item.OverallConfidence.ToString("N2"));
                            
                            this.Invoke(new Action(() => lvwPlates.Items.Add(lvwItem)));
                        }
                    }
                }

                this.Invoke(new Action(() => imageBox2.Image = image));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lvwPlates.Items.Clear();
        }

        private void frmEntryPlate_FormClosing(object sender, FormClosingEventArgs e)
        {
            _capture.Pause();
            _capture.Stop();
            _capture.Dispose();
        }

        private void lvwPlates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwPlates.SelectedItems.Count > 0)
            {
                var item = lvwPlates.SelectedItems[0];
                PlateNumber = item.Text;
                txtPlate.Text = item.Text;
            }
        }
    }
}
