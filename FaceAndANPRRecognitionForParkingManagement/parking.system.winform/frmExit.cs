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
        private LicensePlateDetector _licensePlateDetector = new LicensePlateDetector(@"ocr\tessdata");
        private EigenFaceRecognizer eigenFaceRecognizer;

        private VideoCapture _captureFace = null;
        private VideoCapture _capturePlate = null;

        private Image<Bgr, byte> _faceCopy;

        List<Image<Gray, byte>> eigenTrainingImages = new List<Image<Gray, byte>>();
        int eigenTrainedImageCounter;
        List<int> eigenIntlabels = new List<int>();
        List<string> eigenlabels = new List<string>();


        List<ImageBox> _faceImages = new List<ImageBox>();

        string _parkingId = string.Empty;
        public Parking Parking { get; set; }

        public frmExit()
        {
            InitializeComponent();
        }

        private void frmExit_Load(object sender, EventArgs e)
        {
            TrainEigenFaceRecognizer();

            _faceImages = new List<ImageBox>
            {
                imgBox1, imgBox2, imgBox3, imgBox4,imgBox5, imgBox6
            };

            CameraCaptures();
        }

        void TrainEigenFaceRecognizer()
        {
            try
            {
                var db = new AppDbContext();

                var faces = db.ParkingFaceImages.Where(p => p.Parking.DateEnd == null).ToList();

                string dataDirectory = Directory.GetCurrentDirectory() + "\\TrainedFaces";

                string[] files = Directory.GetFiles(dataDirectory, "*.bmp", SearchOption.AllDirectories);
                eigenTrainedImageCounter = 0;

                files = faces.Select(p => Path.Combine(dataDirectory, p.Filename)).ToArray();

                if (!files.Any())
                {
                    MessageBox.Show("No files to use for training");
                    return;
                }

                foreach (var file in files)
                {
                    using (var fs = File.Open(file, FileMode.Open, FileAccess.Read))
                    using (var bmp = new Bitmap(fs))
                    {
                        var trainedImage = new Image<Bgr, Byte>(bmp);
                        trainedImage._EqualizeHist();

                        eigenTrainingImages.Add(trainedImage.Convert<Gray, Byte>());//eigenTrainingImages.Add(trainedImage.Convert<Gray, Byte>());

                        fs.Close();
                        fs.Dispose();
                        bmp.Dispose();
                    }

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
                eigenFaceRecognizer = new EigenFaceRecognizer(eigenTrainedImageCounter);//, 5000);
                eigenFaceRecognizer.Train(eigenTrainingImages.ToArray(), eigenIntlabels.ToArray());

                //eigenFaceRecognizer.Save(dataDirectory + "\\trainedDataEigen.dat");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Nothing in binary database.", "Trained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        void CameraCaptures()
        {
            try
            {
                var camera1 = int.Parse(ConfigurationManager.AppSettings["camera1"]);
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

            var queryFrame = new Mat();

            try
            {
                _capturePlate.Read(queryFrame);

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

                            Invoke(new Action(() => lvwPlates.Items.Add(lvwItem)));
                        }
                    }
                }

                Invoke(new Action(() => imageBox2.Image = image));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }
            finally
            {
                if (queryFrame != null)
                    queryFrame.Dispose();
            }
        }

        private void _captureFace_ImageGrabbed(object sender, EventArgs e)
        {
            if (_captureFace == null || !_captureFace.IsOpened)
                return;

            var queryFrame = new Mat();

            try
            {
                _captureFace.Read(queryFrame);

                if (queryFrame == null)
                {
                    return;
                }


                var image = queryFrame.ToImage<Bgr, byte>().Resize(400, 300, Emgu.CV.CvEnum.Inter.Cubic);
                var imageClone = image.Clone();

                Invoke(new Action(() => imageBox1.Image = imageClone));

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
                    Invoke(new Action(() => imageBox1.Image = image));

                    imageClone.ROI = faces.First();
                    _faceCopy = imageClone.Copy().Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic);

                    //  check if this copy has matching record in database
                    CheckFace(_faceCopy);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }
            finally
            {
                if (queryFrame != null)
                    queryFrame.Dispose();
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

                var result = eigenFaceRecognizer.Predict(imageFace.Convert<Gray, Byte>());//.Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic));

                if (result.Label != -1)
                {
                    var filename = Path.GetFileName(eigenlabels[result.Label]);
                    var parts = filename.Split(new[] { '_' });
                    var parkingId = parts[1];

                    var db = new AppDbContext();

                    var parking = db.Parkings
                        .FirstOrDefault(p => p.ParkingId == parkingId);

                    if (parking.ParkingId != _parkingId)
                    {
                        _parkingId = parking.ParkingId;

                        Invoke(new Action(() =>
                        {
                            _faceImages.ForEach(p =>
                            {
                                if (p.Image != null)
                                    p.Image.Dispose();
                                p.Image = null;
                            });
                        }));

                    }

                    parking.FaceImages.ToList().ForEach(p =>
                    {
                        var fname = $@"TrainedFaces\{p.Filename}";// $"face_{parkingId}_{now}.bmp";
                        using (var fs = File.Open(fname, FileMode.Open, FileAccess.Read))
                        using (var bmp = new Bitmap(fs))
                        {
                            var image = new Image<Bgr, byte>(bmp);
                            Invoke(new Action(() => SetFace(image)));

                            fs.Close();
                            fs.Dispose();
                            bmp.Dispose();
                        }

                    });

                    this.Parking = parking;

                    Invoke(new Action(() =>
                    {
                        groupBox1.Visible = true;
                        lblPlateNumber.Text = parking.PlateNumber;
                        lblDateEntry.Text = parking.DateStart.ToString();
                    }));

                }
            }
        }

        private void btnApproveExit_Click(object sender, EventArgs e)
        {
            if (this.Parking != null)
            {
                //  delete all related files
                var images = this.Parking.FaceImages.ToList();

                images.ForEach(img =>
                {
                    var filePath = $@"TrainedFaces\{img.Filename}";
                    File.Delete(filePath);
                });

                var db = new AppDbContext();

                var parking = db.Parkings.FirstOrDefault(p => p.ParkingId == Parking.ParkingId);

                if (parking != null)
                {
                    parking.DateEnd = DateTime.Now;

                    db.SaveChanges();

                    MessageBox.Show("Parking Exit approved!", "Exit Parking", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Parking Entry not Found", "Exit Parking", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            this.Parking = null;
            lblPlateNumber.Text = string.Empty;
            lblDateEntry.Text = string.Empty;
        }

        private void frmExit_FormClosing(object sender, FormClosingEventArgs e)
        {
            _captureFace.ImageGrabbed -= _captureFace_ImageGrabbed;
            //_captureFace.Pause();
            _captureFace.Stop();
            _captureFace.Dispose();
            //_captureFace = null;

            _capturePlate.ImageGrabbed -= _capturePlate_ImageGrabbed;
            //_capturePlate.Pause();
            _capturePlate.Stop();
            _capturePlate.Dispose();
            //_capturePlate = null;

            _faceImages.ForEach(p => p.Dispose());

            _licensePlateDetector.Dispose();
            eigenFaceRecognizer.Dispose();

            if (_faceCopy != null)
                _faceCopy.Dispose();
            eigenTrainingImages.ForEach(p => p.Dispose());
        }

    }
}
