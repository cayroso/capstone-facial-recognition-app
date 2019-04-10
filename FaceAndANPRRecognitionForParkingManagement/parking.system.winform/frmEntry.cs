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
        private LicensePlateDetector _licensePlateDetector = new LicensePlateDetector(@"C:\Users\ChristopherAyroso\Source\Repos\capstone-facial-recognition-app\FaceAndANPRRecognitionForParkingManagement\parking.system.winform\ocr\tessdata");
        private VideoCapture _captureFace = null;
        private VideoCapture _capturePlate = null;

        bool _capturePause = false;

        Image<Bgr, byte> _faceCopy;

        EigenFaceRecognizer eigenFaceRecognizer;
        List<Image<Gray, byte>> eigenTrainingImages = new List<Image<Gray, byte>>();
        int eigenTrainedImageCounter;
        List<int> eigenIntlabels = new List<int>();
        List<string> eigenlabels = new List<string>();

        List<ImageBox> _faceImages = new List<ImageBox>();

        public frmEntry()
        {


            InitializeComponent();
            TrainEigenFaceRecognizer();

            _faceImages = new List<ImageBox>
            {
                imgBox1, imgBox2, imgBox3, imgBox4,imgBox5, imgBox6
            };


            Application.Idle += new EventHandler(delegate (object sender, EventArgs e)
            {  //run this until application closed (close button click on image viewer)
               //this.imageBox1.Image = _capture.QueryFrame(); //draw the image obtained from camera
               //if (!_capturePause && _capture != null)
               //    ProcessFaceFrame(null, null);

                //if (!_capturePause && _capture2 != null)
                //    ProcessPlateFrame(null, null);


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

        void StreamFaceFrame()
        {
            if (_captureFace == null)
                return;

            if (!_captureFace.IsOpened || _capturePause)
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

            }

            btnCaptureFace.Enabled = _faceCopy != null;

        }

        void StreamPlateFrame()
        {
            if (_capturePlate == null)
                return;

            if (!_capturePlate.IsOpened || _capturePause)
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

        void CaptureFaceFrame()
        {

        }
        void ProcessFaceFrame(object sender, EventArgs arg)
        {
            if (_captureFace == null)
                return;

            if (!_captureFace.IsOpened || _capturePause)
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
            this.imageBox1.Image = imageClone;

            List<Rectangle> faces = new List<Rectangle>();
            List<Rectangle> eyes = new List<Rectangle>();
            long detectionTime;
            DetectFace.Detect(imageClone, @"haarcascades\haarcascade_frontalface_default.xml", @"haarcascades\haarcascade_eye.xml", faces, eyes, out detectionTime);

            //var bitmap = image.ToBitmap();
            //this.imageBox2.Image = null;
            //this.pbFace.Image = null;

            this.btnApproveEntry.Enabled = false;
            foreach (Rectangle face in faces)
            {

                //For EigenFaces
                //else if (comboBoxAlgorithm.Text == "EigenFaces")
                if (eigenFaceRecognizer != null)
                {
                    CvInvoke.cvResetImageROI(imageClone);
                    //image._EqualizeHist();
                    //if (eqHisChecked.Checked == true)
                    {
                        //image._EqualizeHist();
                    }
                    //var result = eigenFaceRecognizer.Predict(imageClone.Convert<Gray, Byte>().Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic));
                    //if (pbFace.Image == null && result.Label != -1)
                    //{
                    //    //image.Draw(eigenlabels[result.Label].ToString(), ref font, new Point(face.X - 2, face.Y - 2), new Bgr(Color.LightGreen));

                    //    //image.Draw(eigenlabels[result.Label].ToString(), new Point(face.X - 2, face.Y - 2), Emgu.CV.CvEnum.FontFace.HersheyTriplex, 1, new Bgr(Color.Green));
                    //    //label6.Text = result.Distance.ToString();

                    //    pbFace.Image = new Bitmap(eigenlabels[result.Label]);


                    //    //  find the registration
                    //    // face_859a36c3-8a5b-4582-bc66-0bbb59b6f03d_636888658866672057.bmp
                    //    var filename = Path.GetFileName(eigenlabels[result.Label]);
                    //    var parts = filename.Split(new[] { '_' });
                    //    var regId = parts[1];

                    //    //  TODO: ADD LOGIC HERE
                    //    var db = new AppDbContext();

                    //    //var reg = db.Registrations.FirstOrDefault(p => p.RegistrationId == regId);

                    //    //if (reg != null)
                    //    //{
                    //    //    _registration = reg;
                    //    //    txtFullname.Text = _registration.Fullname;

                    //    //    //  check if already entered
                    //    //    var currParking = db.Parkings.FirstOrDefault(p => p.DateEnd == null && p.RegistrationId == _registration.RegistrationId);

                    //    //    btnApproveEntry.Enabled = true;
                    //    //    if (currParking != null)
                    //    //    {
                    //    //        btnApproveEntry.Enabled = false;
                    //    //        //MessageBox.Show("Registration is already parked inside!!!", "Parking", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    //        //this.Close();
                    //    //    }
                    //    //}

                    //    //btnApproveEntry.Enabled = reg != null;
                    //}
                }



                CvInvoke.cvResetImageROI(image);
                image.Draw(face, new Bgr(Color.Red), 2);


            }

            foreach (Rectangle eye in eyes)
            {
                CvInvoke.cvResetImageROI(image);
                image.Draw(eye, new Bgr(Color.Blue), 2);
            }

            if (faces.Any() && eyes.Any())
                this.imageBox1.Image = image;

        }

        void ProcessPlateFrame(object sender, EventArgs arg)
        {

            //if (_capturePlate == null)
            //    return;

            //if (!_capturePlate.IsOpened || _capturePause)
            //{
            //    return;
            //}

            //var queryFrame = _capturePlate.QueryFrame();

            //if (queryFrame == null)
            //{
            //    return;
            //}

            //var image = queryFrame.ToImage<Bgr, byte>().Resize(400, 300, Emgu.CV.CvEnum.Inter.Cubic);

            //var imageClone = image.Clone();
            //this.imageBox2.Image = imageClone;


            //processTimeLabel.Text = String.Format("License Plate Recognition time: {0} milli-seconds", watch.Elapsed.TotalMilliseconds);

        }

        private void label1_Click(object sender, EventArgs e)
        {

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

            this.Close();

        }

        private void frmEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
            _captureFace.Pause();
            _captureFace.Stop();
            _captureFace.Dispose();
            _captureFace = null;
        }

        private void imageBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnCaptureFace_Click(object sender, EventArgs e)
        {

            var image = _faceCopy;

            //imgBox1.Image = image;

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

        private void cmbCamera1_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (cmbCamera1.SelectedIndex != cmbCamera2.SelectedIndex)
            {
                if (_captureFace != null)
                {
                    _captureFace.Stop();
                    _captureFace.Dispose();
                }

                _captureFace = new VideoCapture(cmbCamera1.SelectedIndex);
            }
            else
            {

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
    }
}
