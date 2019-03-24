using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Structure;
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
    public partial class frmEntry : Form
    {
        Registration _registration = null;

        private VideoCapture _capture = null;
        bool _capturePause = false;

        EigenFaceRecognizer eigenFaceRecognizer;
        List<Image<Gray, byte>> eigenTrainingImages = new List<Image<Gray, byte>>();
        int eigenTrainedImageCounter;
        List<int> eigenIntlabels = new List<int>();
        List<string> eigenlabels = new List<string>();

        public frmEntry()
        {
            InitializeComponent();
            TrainEigenFaceRecognizer();
            CameraCapture();

            Application.Idle += new EventHandler(delegate (object sender, EventArgs e)
            {  //run this until application closed (close button click on image viewer)
               //this.imageBox1.Image = _capture.QueryFrame(); //draw the image obtained from camera
                if (!_capturePause && _capture != null)
                    ProcessFrame2(null, null);
            });
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
                    Image<Bgr, Byte> TrainedImage = new Image<Bgr, Byte>(file);
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

        void CameraCapture()
        {
            try
            {
                _capture = new VideoCapture();

                //_capture.ImageGrabbed += ProcessFrame2;

            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }
        }

        void ProcessFrame2(object sender, EventArgs arg)
        {
            
            if (_capture == null)
                return;

            if (!_capture.IsOpened || _capturePause)
            {
                return;
            }

            var queryFrame = _capture.QueryFrame();

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
            this.pictureBox1.Image = null;
            this.txtFullname.Text = string.Empty;
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
                    var result = eigenFaceRecognizer.Predict(imageClone.Convert<Gray, Byte>().Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic));
                    if (result.Label != -1)
                    {
                        //image.Draw(eigenlabels[result.Label].ToString(), ref font, new Point(face.X - 2, face.Y - 2), new Bgr(Color.LightGreen));

                        //image.Draw(eigenlabels[result.Label].ToString(), new Point(face.X - 2, face.Y - 2), Emgu.CV.CvEnum.FontFace.HersheyTriplex, 1, new Bgr(Color.Green));
                        //label6.Text = result.Distance.ToString();

                        pictureBox1.Image = new Bitmap(eigenlabels[result.Label]);

                        //  find the registration
                        // face_859a36c3-8a5b-4582-bc66-0bbb59b6f03d_636888658866672057.bmp
                        var filename = Path.GetFileName(eigenlabels[result.Label]);
                        var parts = filename.Split(new[] { '_' });
                        var regId = parts[1];

                        var db = new AppDbContext();

                        var reg = db.Registrations.FirstOrDefault(p => p.RegistrationId == regId);

                        if (reg != null)
                        {
                            _registration = reg;
                            txtFullname.Text = _registration.Fullname;

                            //  check if already entered
                            var currParking = db.Parkings.FirstOrDefault(p => p.DateEnd == null && p.RegistrationId == _registration.RegistrationId);
                            
                            if(currParking != null)
                            {
                                MessageBox.Show("Registration is already parked inside!!!", "Parking", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.Close();
                            }
                        }
                        
                        btnApproveEntry.Enabled = reg != null;
                    }
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnApproveEntry_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPlate.Text))
            {
                MessageBox.Show("Missing Plate Number", "Approve Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_registration == null)
            {
                MessageBox.Show("Invalid Registration", "Approve Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var parking = new Parking
            {
                ParkingId = Guid.NewGuid().ToString(),
                RegistrationId = _registration.RegistrationId,
                PlateNumber = txtPlate.Text,
                DateStart = DateTime.Now,
                DateEnd = null
            };

            var db = new AppDbContext();

            db.Parkings.Add(parking);

            db.SaveChanges();

            MessageBox.Show("Parking Entry successfull", "Approve Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void frmEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
            _capture.Pause();
            _capture.Stop();
            _capture.Dispose();
            _capture = null;
        }
    }
}
