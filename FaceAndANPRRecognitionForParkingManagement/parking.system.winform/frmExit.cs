using DirectShowLib;
using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using parking.system.winform.code;
using parking.system.winform.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parking.system.winform
{
    public partial class frmExit : Form
    {
        private LicensePlateDetector _licensePlateDetector ;
        private VideoCapture _captureFace = null;
        private VideoCapture _capturePlate = null;

        Image<Bgr, byte> _faceCopy;

        EigenFaceRecognizer eigenFaceRecognizer;
        List<Image<Gray, byte>> eigenTrainingImages = new List<Image<Gray, byte>>();
        int eigenTrainedImageCounter;
        List<int> eigenIntlabels = new List<int>();
        List<string> eigenlabels = new List<string>();


        List<ImageBox> _faceImages = new List<ImageBox>();

        string _parkingId = string.Empty;

        public frmExit()
        {
            InitializeComponent();
            TrainEigenFaceRecognizer();
            _licensePlateDetector = new LicensePlateDetector(@"C:\Users\ChristopherAyroso\Source\Repos\capstone-facial-recognition-app\FaceAndANPRRecognitionForParkingManagement\parking.system.winform\ocr\tessdata");

            _faceImages = new List<ImageBox>
            {
                imgBox1, imgBox2, imgBox3, imgBox4,imgBox5, imgBox6
            };


            Application.Idle += new EventHandler(delegate (object sender, EventArgs e)
            {
                StreamFaceFrame();
                StreamPlateFrame();
            });

            DsDevice[] _SystemCamereas = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);

            var devices = new List<KeyValuePair<int, string>>();
            var devIndex = 0;

            foreach (var cam in _SystemCamereas)
            {
                devices.Add(new KeyValuePair<int, string>(devIndex++, cam.Name));
            }

            if (devices.Count > 0)
            {
                cmbCamera1.Items.Clear();
                cmbCamera1.DataSource = new BindingSource(devices, null);
                cmbCamera1.DisplayMember = "Value";
                cmbCamera1.ValueMember = "Key";

                cmbCamera1.SelectedIndex = 0;
            }

            if (devices.Count > 1)
            {
                cmbCamera2.Items.Clear();
                cmbCamera2.DataSource = new BindingSource(devices, null);
                cmbCamera2.DisplayMember = "Value";
                cmbCamera2.ValueMember = "Key";

                cmbCamera2.SelectedIndex = 1;

                //_capture2 = new VideoCapture(1);

            }
            else
            {
                //  TODO
                //MessageBox.Show("Only 1 camera was detected", "Missing Required Cameras", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            CameraCaptures();
        }


        void StreamFaceFrame()
        {
            if (_captureFace == null)
                return;

            if (!_captureFace.IsOpened)
            {
                return;
            }

            var queryFrame = _captureFace.QueryFrame();

            if (queryFrame == null)
            {
                return;
            }

            var image = queryFrame.ToImage<Bgr, byte>().Resize(400, 300, Emgu.CV.CvEnum.Inter.Cubic);

            var imageClone = image.Clone();
            imageBox1.Image = imageClone;

            List<Rectangle> faces = new List<Rectangle>();
            List<Rectangle> eyes = new List<Rectangle>();
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
                imageBox1.Image = image;

                imageClone.ROI = faces.First();
                _faceCopy = imageClone.Copy().Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic);


                //  check if this copy has matching record in database
                CheckFace(_faceCopy);

            }

            //btnCaptureFace.Enabled = _faceCopy != null;

        }


        void StreamPlateFrame()
        {
            if (_capturePlate == null)
                return;

            if (!_capturePlate.IsOpened)
            {
                return;
            }

            var queryFrame = _capturePlate.QueryFrame();

            if (queryFrame == null)
            {
                return;
            }

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

                        lvwPlates.Items.Add(lvwItem);
                    }
                }
            }

            imageBox2.Image = image;
        }


        void TrainEigenFaceRecognizer()
        {
            try
            {
                string dataDirectory = Directory.GetCurrentDirectory() + "\\TrainedFaces";

                string[] files = Directory.GetFiles(dataDirectory, "*.bmp", SearchOption.AllDirectories);
                eigenTrainedImageCounter = 0;

                if (!files.Any())
                {
                    MessageBox.Show("No files to use for training");
                    return;
                }

                foreach (var file in files)
                {
                    var trainedImage = new Image<Bgr, Byte>(file);
                    trainedImage._EqualizeHist();

                    eigenTrainingImages.Add(trainedImage.Convert<Gray, Byte>());//eigenTrainingImages.Add(trainedImage.Convert<Gray, Byte>());
                    eigenlabels.Add(file);
                    eigenIntlabels.Add(eigenTrainedImageCounter);
                    eigenTrainedImageCounter++;
                    //richTextBox1.Text += fileName(file) + "\n";
                }
                /*
                    //TermCriteria for face recognition with numbers of trained images like maxIteration
                    MCvTermCriteria termCrit = new MCvTermCriteria(eigenTrainedImageCounter, 0.001);

                    //Eigen face recognizer
                    eigenObjRecognizer=new EigenObjectRecognizer(
                      eigenTrainingImages.ToArray(),
                      eigenlabels.ToArray(),
                      3000,
                      ref termCrit);
                 */
                eigenFaceRecognizer = new EigenFaceRecognizer(eigenTrainedImageCounter, 5000);
                eigenFaceRecognizer.Train(eigenTrainingImages.ToArray(), eigenIntlabels.ToArray());

                //eigenFaceRecognizer.Save(dataDirectory + "\\trainedDataEigen.dat");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Nothing in binary database.", "Triained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        void CameraCaptures()
        {
            try
            {
                _captureFace = new VideoCapture(cmbCamera1.SelectedIndex);
                if (cmbCamera2.Items.Count > 0)
                {
                    _capturePlate = new VideoCapture(cmbCamera2.SelectedIndex);
                }
                //_capture.ImageGrabbed += ProcessFrame2;

            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }
        }


        void CheckFace(Image<Bgr, byte> imageFace)
        {
            if (eigenFaceRecognizer != null)
            {
                CvInvoke.cvResetImageROI(imageFace);
                //image._EqualizeHist();
                //if (eqHisChecked.Checked == true)
                {
                    //image._EqualizeHist();
                }
                var result = eigenFaceRecognizer.Predict(imageFace.Convert<Gray, Byte>().Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic));
                if (result.Label != -1)
                {
                    var filename = Path.GetFileName(eigenlabels[result.Label]);
                    var parts = filename.Split(new[] { '_' });
                    var parkingId = parts[1];

                    var db = new AppDbContext();

                    var parking = db.Parkings
                        .FirstOrDefault(p => p.ParkingId == parkingId);

                    if(parking.ParkingId != _parkingId)
                    {
                        _parkingId = parking.ParkingId;
                        _faceImages.ForEach(p => p.Image = null);
                    }

                    parking.FaceImages.ToList().ForEach(p =>
                    {
                        var fname = $@"TrainedFaces\{p.Filename}";// $"face_{parkingId}_{now}.bmp";
                        var image = new Image<Bgr, byte>(new Bitmap(fname));
                        SetFace(image);
                    });

                    var foo = parking;

                    groupBox1.Visible = true;

                    lblPlateNumber.Text = parking.PlateNumber;
                    lblDateEntry.Text = parking.DateStart.ToString();
                }
            }
        }

        private void btnApproveExit_Click(object sender, EventArgs e)
        {

        }


        void SetFace(Image<Bgr, byte> image)
        {
            foreach (var imageBox in _faceImages)
            {
                if (imageBox.Image == null)
                {
                    imageBox.Image = image;
                    return;
                }
            }
        }

        private void btnClearImages_Click(object sender, EventArgs e)
        {
            _faceImages.ForEach(p => p.Image = null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lvwPlates.Items.Clear();
        }

        private void frmExit_FormClosed(object sender, FormClosedEventArgs e)
        {
            _captureFace.Pause();
            _captureFace.Stop();
            _captureFace.Dispose();
            _captureFace = null;

            _capturePlate.Pause();
            _capturePlate.Stop();
            _capturePlate.Dispose();
            _capturePlate = null;

        }
    }
}
