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
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parking.system.winform
{
    public partial class frmEntry : Form
    {
        //private LicensePlateDetector _licensePlateDetector = new LicensePlateDetector(@"C:\Users\ChristopherAyroso\Source\Repos\capstone-facial-recognition-app\FaceAndANPRRecognitionForParkingManagement\parking.system.winform\ocr\tessdata");
        private LicensePlateDetector _licensePlateDetector = new LicensePlateDetector(@"ocr\tessdata");
        private VideoCapture _captureFace = null;
        private VideoCapture _capturePlate = null;

        Image<Bgr, byte> _faceCopy;

        EigenFaceRecognizer eigenFaceRecognizer;
        List<Image<Gray, byte>> eigenTrainingImages = new List<Image<Gray, byte>>();
        int eigenTrainedImageCounter;
        List<int> eigenIntlabels = new List<int>();
        List<string> eigenlabels = new List<string>();

        List<ImageBox> _faceImages = new List<ImageBox>();

        bool _getFace = true;

        Timer _timer = new Timer();

        public frmEntry()
        {
            InitializeComponent();
        }


        private void frmEntry_Load(object sender, EventArgs e)
        {

            //TrainEigenFaceRecognizer();

            _faceImages = new List<ImageBox>
            {
                imgBox1, imgBox2, imgBox3, imgBox4,imgBox5, imgBox6
            };

            _faceImages.ForEach(p => p.DoubleClick += imgBox_DoubleClick);
            
            CameraCaptures();
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
                    Image<Gray, Byte> TrainedImage = new Image<Gray, Byte>(file);
                    //if (eqHisChecked.Checked == true)
                    {
                        TrainedImage._EqualizeHist();
                    }
                    eigenTrainingImages.Add(TrainedImage.Convert<Gray, Byte>());
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
                MessageBox.Show("Nothing in binary database, please add at least a face(Simply train the prototype with the Add Face Button).", "Triained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        void CameraCaptures()
        {
            try
            {
                var camera1 =int.Parse(ConfigurationManager.AppSettings["camera1"]);
                _captureFace = new VideoCapture(camera1);
                _captureFace.ImageGrabbed += _captureFace_ImageGrabbed;
                _captureFace.Start();

                var camera2 = int.Parse(ConfigurationManager.AppSettings["camera2"]);
                _capturePlate = new VideoCapture(camera2);
                _capturePlate.ImageGrabbed += _capturePlate_ImageGrabbed;
                _capturePlate.Start();
            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }
        }

        private void _capturePlate_ImageGrabbed(object sender, EventArgs e)
        {
            if (_capturePlate == null || !_capturePlate.IsOpened)
                return;

            Mat queryFrame = new Mat();

            _capturePlate.Read(queryFrame);

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

        private void _captureFace_ImageGrabbed(object sender, EventArgs e)
        {
            if (_captureFace == null || !_captureFace.IsOpened)
                return;

            var queryFrame = new Mat();

            _captureFace.Read(queryFrame);

            try
            {
                var image = queryFrame.ToImage<Bgr, byte>().Resize(400, 300, Emgu.CV.CvEnum.Inter.Cubic);
                var imageClone = image.Clone();

                this.Invoke(new Action(() => imageBox1.Image = imageClone));

                var faces = new List<Rectangle>();
                var eyes = new List<Rectangle>();
                long detectionTime;

                DetectFace.Detect(imageClone, @"haarcascades\haarcascade_frontalface_default.xml", @"haarcascades\haarcascade_eye.xml", faces, eyes, out detectionTime);

                foreach (var face in faces)
                {
                    CvInvoke.cvResetImageROI(image);

                    image.Draw(face, new Bgr(Color.Red), 2);
                }

                foreach (var eye in eyes)
                {
                    CvInvoke.cvResetImageROI(image);
                    image.Draw(eye, new Bgr(Color.Blue), 2);
                }

                if (faces.Any() && eyes.Count == 2)
                {
                    Invoke(new Action(() => imageBox1.Image = image));

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
        
        private void btnApproveEntry_Click(object sender, EventArgs e)
        {
            foreach (var img in _faceImages)
            {
                if (img.Image == null)
                {
                    MessageBox.Show("Complete the faces", "Missing Face Image Capture", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(txtPlate.Text))
            {
                MessageBox.Show("Complete the plate number", "Missing Plate Number Capture", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var parkingId = NewId();

            var faceImages = _faceImages.Select(p => new ParkingFaceImage
            {
                ParkingFaceImageId = NewId(),
                ParkingId = parkingId,
                Filename = SaveFaceImage(parkingId, p)
            }).ToList();

            var parking = new Parking
            {
                ParkingId = parkingId,
                PlateNumber = txtPlate.Text,
                FaceImages = faceImages,
                DateStart = DateTime.Now
            };

            var db = new AppDbContext();

            db.Parkings.Add(parking);

            db.SaveChanges();

            MessageBox.Show("Parking Entry Approved", "Enter Parking", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void frmEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
            _captureFace.ImageGrabbed -= _captureFace_ImageGrabbed;
            _captureFace.Pause();
            _captureFace.Stop();
            _captureFace.Dispose();
            _captureFace = null;

            _capturePlate.ImageGrabbed -= _capturePlate_ImageGrabbed;
            _capturePlate.Pause();
            _capturePlate.Stop();
            _capturePlate.Dispose();
            _capturePlate = null;
            
            _faceImages.ForEach(p =>
            {
                p.Dispose();
            });
        }
        
        private void btnCaptureFace_Click(object sender, EventArgs e)
        {

            var image = _faceCopy;
            
            SetFaceBox(image);
        }

        void SetFaceBox(Image<Bgr, byte> image)
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
        
        private static string NewId()
        {
            return Guid.NewGuid().ToString().ToLower();
        }

        private static string SaveFaceImage(string parkingId, ImageBox imageBox)
        {
            var image = new Image<Bgr, Byte>(imageBox.Image.Bitmap);

            var now = DateTime.UtcNow.Ticks.ToString();

            var filename = $"face_{parkingId}_{now}.bmp";

            Directory.CreateDirectory("TrainedFaces");
            image.ToBitmap().Save($@"TrainedFaces\{filename}");

            return filename;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //listBox1.Items.Clear();
            //txtPlate.Clear();

            lvwPlates.Items.Clear();
        }

        private void lvwPlates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwPlates.SelectedItems.Count > 0)
            {
                var item = lvwPlates.SelectedItems[0];

                txtPlate.Text = item.Text;
            }
        }
        
        private void imgBox_DoubleClick(object sender, EventArgs e)
        {
            if (sender is ImageBox imgBox)
                imgBox.Image = null;
        }
    }
}
