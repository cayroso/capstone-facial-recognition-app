using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using parking.system.winform.code;
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
    public partial class Form1 : Form
    {
        //MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);

        private VideoCapture _capture = null;
        bool _capturePause = false;

        EigenFaceRecognizer eigenFaceRecognizer;
        List<Image<Gray, byte>> eigenTrainingImages = new List<Image<Gray, byte>>();
        int eigenTrainedImageCounter;
        List<int> eigenIntlabels = new List<int>();
        List<string> eigenlabels = new List<string>();

        public Form1()
        {
            InitializeComponent();
            TrainEigenFaceRecognizer();
            CameraCapture();

            Application.Idle += new EventHandler(delegate (object sender, EventArgs e)
            {  //run this until application closed (close button click on image viewer)
               //this.imageBox1.Image = _capture.QueryFrame(); //draw the image obtained from camera
                if (!_capturePause && _capture!=null)
                    ProcessFrame2(null, null);
            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void TrainEigenFaceRecognizer()
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

        private void button1_Click(object sender, EventArgs e)
        {
            //TrainEigenFaceRecognizer();
            Image<Bgr, Byte> image = new Image<Bgr, Byte>(this.imageBox1.Image.Bitmap); ;// _capture.QueryFrame().ToImage<Bgr, Byte>().Resize(400, 300, Emgu.CV.CvEnum.Inter.Cubic);
            List<Rectangle> faces = new List<Rectangle>();
            List<Rectangle> eyes = new List<Rectangle>();
            long detectionTime;
            DetectFace.Detect(image, @"haarcascades\haarcascade_frontalface_default.xml", @"haarcascades\haarcascade_eye.xml", faces, eyes, out detectionTime);
            foreach (Rectangle face in faces)
            {

                image.ROI = face;

            }
            Directory.CreateDirectory("TrainedFaces");
            image.Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic).ToBitmap().Save("TrainedFaces\\" + DateTime.UtcNow.Ticks.ToString() + ".bmp");
        }

        //string fileName(string file)
        //{
        //    string[] fileArr = file.Split('\\');
        //    var fileName = fileArr[fileArr.Length - 1].Split(comboBoxSplitChar.Text.ToCharArray()[0])[0];
        //    return fileName;
        //}

        //string fileNameforExtract(string file)
        //{
        //    string[] fileArr = file.Split('\\');
        //    var fileName = fileArr[fileArr.Length - 1];
        //    return fileName;
        //}

        private void CameraCapture()
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
            //Image<Bgr, byte> image;

            //OpenFileDialog Openfile = new OpenFileDialog();
            //if (Openfile.ShowDialog() == DialogResult.OK)
            //{
            //    image = new Image<Bgr, byte>(Openfile.FileName);

            //}
            //else
            //{
            var queryFrame = _capture.QueryFrame();

            if (queryFrame == null)
            {
                return;
            }

            var image = queryFrame.ToImage<Bgr, byte>().Resize(400, 300, Emgu.CV.CvEnum.Inter.Cubic);
            //}
            var imageClone = image.Clone();
            this.imageBox1.Image = imageClone;

            List<Rectangle> faces = new List<Rectangle>();
            List<Rectangle> eyes = new List<Rectangle>();
            long detectionTime;
            DetectFace.Detect(imageClone, @"haarcascades\haarcascade_frontalface_default.xml", @"haarcascades\haarcascade_eye.xml", faces, eyes, out detectionTime);

            //var bitmap = image.ToBitmap();
            //this.imageBox2.Image = null;
            this.pictureBox1.Image = null;
            foreach (Rectangle face in faces)
            {
                //Image ROI selected as each face in image 
                // if (workCorruptedImages.Checked == true)
                {
                    //image.ROI = face;
                }
                //if (faceRecog.Checked == true)
                {
                    //now program apply selected algorithm if recognition has started

                    //For SURF Algorithm
                    //if (comboBoxAlgorithm.Text == "SURF Feature Extractor")
                    //{
                    //    string dataDirectory = Directory.GetCurrentDirectory() + "\\TrainedFaces";
                    //    string[] files = Directory.GetFiles(dataDirectory, "*.jpg", SearchOption.AllDirectories);

                    //    foreach (var file in files)
                    //    {
                    //        richTextBox1.Text += file.ToString();
                    //        long recpoints;
                    //        Image<Bgr, Byte> sampleImage = new Image<Bgr, Byte>(file);
                    //        secondImageBox.Image = sampleImage;
                    //        using (Image<Gray, Byte> modelImage = sampleImage.Convert<Gray, Byte>())
                    //        using (Image<Gray, Byte> observedImage = image.Convert<Gray, Byte>())
                    //        {
                    //            Image<Bgr, byte> result = SurfRecognizer.Draw(modelImage, observedImage, out recpoints);
                    //            //captureImageBox.Image = observedImage;
                    //            if (recpoints > 10)
                    //            {
                    //                MCvFont f = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_COMPLEX, 1.0, 1.0);
                    //                result.Draw("Person Recognited, Welcome", ref f, new Point(40, 40), new Bgr(0, 255, 0));
                    //                ImageViewer.Show(result, String.Format(" {0} Points Recognited", recpoints));
                    //            }
                    //        }
                    //    }


                    //}
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

                            pictureBox1.Image = new Bitmap(eigenlabels[result.Label].ToString());
                        }
                    }
                    //For FisherFaces
                    //else if (comboBoxAlgorithm.Text == "FisherFaces")
                    //{
                    //    CvInvoke.cvResetImageROI(image);
                    //    if (eqHisChecked.Checked == true)
                    //    {
                    //        image._EqualizeHist();
                    //    }
                    //    var result = fisherFaceRecognizer.Predict(image.Convert<Gray, Byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC));
                    //    if (result.Label != -1)
                    //    {
                    //        image.Draw(fisherlabels[result.Label].ToString(), ref font, new Point(face.X - 2, face.Y - 2), new Bgr(Color.LightGreen));
                    //        label6.Text = result.Distance.ToString();
                    //    }

                    //}

                    //For LBPH
                    //else if (comboBoxAlgorithm.Text == "LBPHFaces")
                    //{
                    //    if (eqHisChecked.Checked == true)
                    //    {
                    //        image._EqualizeHist();
                    //    }
                    //    var result = lbphFaceRecognizer.Predict(image.Convert<Gray, Byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC));
                    //    if (result.Label != -1)
                    //    {
                    //        CvInvoke.cvResetImageROI(image);
                    //        image.Draw(lbphlabels[result.Label].ToString(), ref font, new Point(face.X - 2, face.Y - 2), new Bgr(Color.LightGreen));
                    //        label6.Text = result.Distance.ToString();
                    //        label7.Text = lbphlabels[result.Label].ToString();
                    //    }

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
                this.imageBox2.Image = image;

        }

        void ProcessPicture()
        {
            if (_capture == null)
                return;

            OpenFileDialog Openfile = new OpenFileDialog();

            if (Openfile.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var image = new Image<Bgr, byte>(Openfile.FileName).Resize(400, 300, Emgu.CV.CvEnum.Inter.Cubic);
            //}
            var imageClone = image.Clone();
            this.imageBox1.Image = imageClone;

            List<Rectangle> faces = new List<Rectangle>();
            List<Rectangle> eyes = new List<Rectangle>();
            long detectionTime;
            DetectFace.Detect(imageClone, @"haarcascades\haarcascade_frontalface_default.xml", @"haarcascades\haarcascade_eye.xml", faces, eyes, out detectionTime);

            //var bitmap = image.ToBitmap();
            this.imageBox2.Image = null;
            this.pictureBox1.Image = null;
            foreach (Rectangle face in faces)
            {
                //Image ROI selected as each face in image 
                // if (workCorruptedImages.Checked == true)
                {
                    //image.ROI = face;
                }
                //if (faceRecog.Checked == true)
                {
                    //now program apply selected algorithm if recognition has started

                    //For SURF Algorithm
                    //if (comboBoxAlgorithm.Text == "SURF Feature Extractor")
                    //{
                    //    string dataDirectory = Directory.GetCurrentDirectory() + "\\TrainedFaces";
                    //    string[] files = Directory.GetFiles(dataDirectory, "*.jpg", SearchOption.AllDirectories);

                    //    foreach (var file in files)
                    //    {
                    //        richTextBox1.Text += file.ToString();
                    //        long recpoints;
                    //        Image<Bgr, Byte> sampleImage = new Image<Bgr, Byte>(file);
                    //        secondImageBox.Image = sampleImage;
                    //        using (Image<Gray, Byte> modelImage = sampleImage.Convert<Gray, Byte>())
                    //        using (Image<Gray, Byte> observedImage = image.Convert<Gray, Byte>())
                    //        {
                    //            Image<Bgr, byte> result = SurfRecognizer.Draw(modelImage, observedImage, out recpoints);
                    //            //captureImageBox.Image = observedImage;
                    //            if (recpoints > 10)
                    //            {
                    //                MCvFont f = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_COMPLEX, 1.0, 1.0);
                    //                result.Draw("Person Recognited, Welcome", ref f, new Point(40, 40), new Bgr(0, 255, 0));
                    //                ImageViewer.Show(result, String.Format(" {0} Points Recognited", recpoints));
                    //            }
                    //        }
                    //    }


                    //}
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

                            pictureBox1.Image = new Bitmap(eigenlabels[result.Label].ToString());
                        }
                    }
                    //For FisherFaces
                    //else if (comboBoxAlgorithm.Text == "FisherFaces")
                    //{
                    //    CvInvoke.cvResetImageROI(image);
                    //    if (eqHisChecked.Checked == true)
                    //    {
                    //        image._EqualizeHist();
                    //    }
                    //    var result = fisherFaceRecognizer.Predict(image.Convert<Gray, Byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC));
                    //    if (result.Label != -1)
                    //    {
                    //        image.Draw(fisherlabels[result.Label].ToString(), ref font, new Point(face.X - 2, face.Y - 2), new Bgr(Color.LightGreen));
                    //        label6.Text = result.Distance.ToString();
                    //    }

                    //}

                    //For LBPH
                    //else if (comboBoxAlgorithm.Text == "LBPHFaces")
                    //{
                    //    if (eqHisChecked.Checked == true)
                    //    {
                    //        image._EqualizeHist();
                    //    }
                    //    var result = lbphFaceRecognizer.Predict(image.Convert<Gray, Byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC));
                    //    if (result.Label != -1)
                    //    {
                    //        CvInvoke.cvResetImageROI(image);
                    //        image.Draw(lbphlabels[result.Label].ToString(), ref font, new Point(face.X - 2, face.Y - 2), new Bgr(Color.LightGreen));
                    //        label6.Text = result.Distance.ToString();
                    //        label7.Text = lbphlabels[result.Label].ToString();
                    //    }

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
                this.imageBox2.Image = image;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            _capture.Stop();
            this.ProcessPicture();
        }

        private void btnEntry_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            _capturePause = true;
            _capture.Dispose();
            _capture = null;

            //_capture.Pause();

            //var frm = new frmRegister();

            //frm.ShowDialog();

            _capturePause = false;
            _capture = new VideoCapture();
            //_capture.Start();
        }
    }
}
