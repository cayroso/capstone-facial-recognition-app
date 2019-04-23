using DirectShowLib;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using parking.system.winform.code;
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
    public partial class frmEntryFace : Form
    {
        private VideoCapture _capture = null;
        private Image<Bgr, byte> _faceCopy;

        public List<ImageBox> FaceImages { get; set; }

        public frmEntryFace()
        {
            InitializeComponent();

            FaceImages = new List<ImageBox>
            {
                imgBox1, imgBox2, imgBox3, imgBox4,imgBox5, imgBox6
            };

            FaceImages.ForEach(p => p.DoubleClick += imgBox_DoubleClick);

            var cameraIndex = int.Parse(ConfigurationManager.AppSettings["camera1"]);
            _capture = new VideoCapture(cameraIndex);
            _capture.ImageGrabbed += _capture_ImageGrabbed;
            _capture.Start();
        }

        private void _capture_ImageGrabbed(object sender, EventArgs e)
        {
            if (_capture == null || !_capture.IsOpened)
                return;

            var queryFrame = new Mat();

            _capture.Read(queryFrame);
            
            try
            {
                var image = queryFrame.ToImage<Bgr, byte>().Resize(400, 300, Emgu.CV.CvEnum.Inter.Cubic);
                var imageClone = image.Clone();

                this.Invoke(new Action(() => imageBox1.Image = imageClone));

                var faces = new List<Rectangle>();
                var eyes = new List<Rectangle>();
                long detectionTime;

                DetectFace.Detect(imageClone, @"haarcascades\haarcascade_frontalface_default.xml", @"haarcascades\haarcascade_eye.xml", faces, eyes, out detectionTime);

                foreach (Rectangle face in faces)
                {
                    CvInvoke.cvResetImageROI(image);

                    image.Draw(face, new Bgr(Color.Red), 2);
                }

                foreach (Rectangle eye in eyes)
                {
                    CvInvoke.cvResetImageROI(image);
                    image.Draw(eye, new Bgr(Color.Blue), 2);
                }

                if (faces.Any() && eyes.Count == 2)
                {
                    //image.ROI = faces.First();
                    this.Invoke(new Action(() => imageBox1.Image = image));

                    imageClone.ROI = faces.First();
                    _faceCopy = imageClone.Copy().Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic);

                }

                this.Invoke(new Action(() => btnCaptureFace.Enabled = _faceCopy != null));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }
        }

        void SetFaceBox()
        {
            foreach (var imageBox in FaceImages)
            {
                if (imageBox.Image == null && btnCaptureFace.Enabled)
                {
                    imageBox.Image = _faceCopy;
                    return;
                }
            }
        }

        private void btnCaptureFace_Click(object sender, EventArgs e)
        {
            SetFaceBox();
        }

        private void frmEntryFace_FormClosing(object sender, FormClosingEventArgs e)
        {
            _capture.ImageGrabbed -= _capture_ImageGrabbed;
            _capture.Pause();
            _capture.Stop();
            _capture.Dispose();
            _capture = null;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            foreach (var imgBox in FaceImages)
            {
                if (imgBox.Image == null)
                {
                    MessageBox.Show("Incomplete face samples.");
                    return;
                }
            }

            this.Close();
        }

        private void imgBox_DoubleClick(object sender, EventArgs e)
        {
            if (sender is ImageBox imgBox)
                imgBox.Image = null;
        }
    }
}
