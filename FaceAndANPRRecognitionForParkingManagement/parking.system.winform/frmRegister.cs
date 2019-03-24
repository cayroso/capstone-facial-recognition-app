using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using parking.system.winform.code;
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
    public partial class frmRegister : Form
    {
        private VideoCapture _capture = null;

        private List<ImageBox> _imageBoxes = new List<ImageBox>();
        private Image<Bgr, byte> _cleanCopy = null;

        public frmRegister()
        {
            InitializeComponent();

            CameraCapture();

            Application.Idle += new EventHandler(delegate (object sender, EventArgs e)
            {
                ProcessPicture();
            });

            _imageBoxes.Add(imgBox1);
            _imageBoxes.Add(imgBox2);
            _imageBoxes.Add(imgBox3);
            _imageBoxes.Add(imgBox4);
            _imageBoxes.Add(imgBox5);
            _imageBoxes.Add(imgBox6);

            foreach (var pb in _imageBoxes)
            {
                pb.DoubleClick += new EventHandler((o, e) =>
                {
                    pb.Image = null;

                });
            }
        }

        void CameraCapture()
        {
            try
            {
                _capture = new VideoCapture(Emgu.CV.CvEnum.CaptureType.Any);

                //_capture.ImageGrabbed += ProcessFrame2;

            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }
        }

        void ProcessPicture()
        {
            if (_capture == null)
                return;

            var queryFrame = _capture.QueryFrame();

            if (queryFrame == null)
                return;

            var image = queryFrame.ToImage<Bgr, byte>().Resize(400, 300, Emgu.CV.CvEnum.Inter.Cubic);

            var imageClone = image.Clone();
            _cleanCopy = imageClone;

            List<Rectangle> faces = new List<Rectangle>();
            List<Rectangle> eyes = new List<Rectangle>();
            long detectionTime;
            DetectFace.Detect(imageClone, @"haarcascades\haarcascade_frontalface_default.xml", @"haarcascades\haarcascade_eye.xml", faces, eyes, out detectionTime);

            //var bitmap = image.ToBitmap();
            this.imageBox2.Image = null;
            //this.pictureBox1.Image = null;
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

            if (faces.Any() && eyes.Any())
                this.imageBox2.Image = image;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_cleanCopy == null)
            {
                return;
            }

            //TrainEigenFaceRecognizer();

            List<Rectangle> faces = new List<Rectangle>();
            List<Rectangle> eyes = new List<Rectangle>();
            long detectionTime;
            DetectFace.Detect(_cleanCopy, @"haarcascades\haarcascade_frontalface_default.xml", @"haarcascades\haarcascade_eye.xml", faces, eyes, out detectionTime);
            foreach (Rectangle face in faces)
            {

                _cleanCopy.ROI = face;

            }

            foreach (var pb in _imageBoxes)
            {
                if (pb.Image == null)
                {
                    pb.Image = _cleanCopy.Copy().Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic);
                    break;
                }
            }

            //Directory.CreateDirectory("TrainedFaces");
            //image.Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic).ToBitmap().Save("TrainedFaces\\" + DateTime.UtcNow.Ticks.ToString() + ".bmp");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach (var pb in _imageBoxes)
            {
                pb.Image = null;
            }
        }

        private void frmEntry_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            foreach (var pb in this._imageBoxes)
            {
                if (pb.Image == null)
                {
                    MessageBox.Show("Incomplete Face Samples", "Invalid Registration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(txtFullname.Text))
            {
                MessageBox.Show("Please confirm full name", "Invalid Registration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;            
            }


            var registrationId = Guid.NewGuid().ToString();
            var images = new List<RegistrationImage>();

            foreach (var pb in _imageBoxes)
            {
                var image = new Image<Bgr, Byte>(pb.Image.Bitmap);

                var now = DateTime.UtcNow.Ticks.ToString();

                var filename = $"face_{registrationId}_{now}.bmp";

                Directory.CreateDirectory("TrainedFaces");
                image.ToBitmap().Save($@"TrainedFaces\{filename}");

                var regImage = new RegistrationImage
                {
                    RegistrationImageId = Guid.NewGuid().ToString(),
                    RegistrationId = registrationId,
                    RegistrationImageType = EnumRegistrationImageType.Face,
                    Filename = filename,
                };

                images.Add(regImage);
            }
            var registration = new Registration
            {
                RegistrationId = registrationId,
                Fullname = txtFullname.Text,
                Images = images
            };

            var db = new AppDbContext();

            db.Registrations.Add(registration);
            db.RegistrationImages.AddRange(images);

            db.SaveChanges();

            MessageBox.Show("Registration successfull", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void frmEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
            _capture.Pause();
            _capture.Stop();
            
            _capture.Dispose();
        }
    }
}
