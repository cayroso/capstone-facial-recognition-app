using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Util;
using face.anpr.wpf.Code;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
//using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace face.anpr.wpf
{
    class ParkingEntry
    {
        public string Name { get; set; }
        public string PlateNumber { get; set; }
        public DateTime DateEntry { get; set; }
        public DateTime? DateExit { get; set; }

        public TimeSpan DateDiff
        {
            get
            {
                return (DateExit.GetValueOrDefault(DateTime.Now) - DateEntry);
            }
        }

        public double TotalHours
        {
            get { return DateDiff.TotalHours; }
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly LicensePlateDetector _licensePlateDetector;
        private VideoCapture capture;
        private readonly CascadeClassifier cascade = new CascadeClassifier(@"Data/haarcascade_frontalface_alt_tree.xml");
        DispatcherTimer timer;


        private Tesseract _ocr;

        public MainWindow()
        {
            InitializeComponent();

            for (var i = 1; i < 15; i++)
            {
                ListView1.Items.Add(new ParkingEntry { Name = $"Person #{i}", PlateNumber = $"Plate #{i}", DateEntry = DateTime.Now, DateExit = DateTime.Now.AddHours(i) });

            }

            var path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var folder = System.IO.Path.Combine(path, "tessdata");
            _licensePlateDetector = new LicensePlateDetector(folder);

            Mat m = new Mat(@"C:\Users\cayent\Desktop\ImageTest\222.jpg");
            UMat um = m.GetUMat(AccessType.ReadWrite);
            this.ImagePlate.Image = um;
            //ProcessImage(m);
            _ocr = new Tesseract(folder, "eng", OcrEngineMode.TesseractLstmCombined, "ABCDEFGHIJKLMNOPQRSTUVWXYZ 1234567890");
            _ocr.SetVariable("tessedit_char_whitelist", "ABCDEFGHIJKLMNOPQRSTUVWXYZ-1234567890");


            //create OCR engine
            //_ocr = new Tesseract(System.AppDomain.CurrentDomain.BaseDirectory + @"\Data\\", "eng", OcrEngineMode.TesseractLstmCombined);
            //_ocr.Init("", "eng", OcrEngineMode.TesseractLstmCombined);
            //_ocr.SetVariable("tessedit_char_whitelist", "ABCDEFGHIJKLMNOPQRSTUVWXYZ-1234567890");

            _ocr.SetImage(m);
            _ocr.Recognize();
            
            var text1 = _ocr.GetBoxText();
            var text2 = _ocr.GetCharacters();
            var text3 = _ocr.GetHOCRText();
            //var text4 = _ocr.GetOsdText(1);
            var text5 = _ocr.GetTSVText();
            var text6 = _ocr.GetUNLVText();
            var text7 = _ocr.GetUTF8Text();
            Plate.Text = text7;
        }

        private void CommonCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            capture = new VideoCapture();

            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            //timer.Start();
        }

        private void ProcessImage(IInputOutputArray image)
        {
            Stopwatch watch = Stopwatch.StartNew(); // time the detection process

            List<IInputOutputArray> licensePlateImagesList = new List<IInputOutputArray>();
            List<IInputOutputArray> filteredLicensePlateImagesList = new List<IInputOutputArray>();
            List<RotatedRect> licenseBoxList = new List<RotatedRect>();

            var found = new List<string>();

            for (double rWidth = 1; rWidth < 12; rWidth += 0.2)
            {
                for (double rHeight = 1; rHeight < 12; rHeight += 0.2)
                {
                    List<string> words1 = _licensePlateDetector.DetectLicensePlate(
               image,
               licensePlateImagesList,
               filteredLicensePlateImagesList,
               licenseBoxList, rWidth, rHeight);

                    if (words1.Any())
                    {
                        var f = $"FOUND: {rWidth}-{rHeight} = {string.Concat(words1)}";

                        found.Add(f);

                        Console.WriteLine(f);
                    }
                    else
                    {
                        //Console.WriteLine($"FAILED: {rWidth}-{rHeight}");
                    }
                }
            }
            List<string> words = new List<string>();
            //List<string> words = _licensePlateDetector.DetectLicensePlate(
            //   image,
            //   licensePlateImagesList,
            //   filteredLicensePlateImagesList,
            //   licenseBoxList, 6, 12);

            watch.Stop(); //stop the timer
            //processTimeLabel.Text = String.Format("License Plate Recognition time: {0} milli-seconds", watch.Elapsed.TotalMilliseconds);

            //panel1.Controls.Clear();
            System.Drawing.Point startPoint = new System.Drawing.Point(10, 10);
            for (int i = 0; i < words.Count; i++)
            {
                Mat dest = new Mat();
                CvInvoke.VConcat(licensePlateImagesList[i], filteredLicensePlateImagesList[i], dest);
                AddLabelAndImage(
                   ref startPoint,
                   String.Format("License: {0}", words[i]),
                   dest);
                PointF[] verticesF = licenseBoxList[i].GetVertices();
                System.Drawing.Point[] vertices = Array.ConvertAll(verticesF, System.Drawing.Point.Round);
                using (VectorOfPoint pts = new VectorOfPoint(vertices))
                    CvInvoke.Polylines(image, pts, true, new Bgr(System.Drawing.Color.Red).MCvScalar, 2);

            }

        }

        private void AddLabelAndImage(ref System.Drawing.Point startPoint, String labelText, IImage image)
        {
            //Label label = new Label();
            //panel1.Controls.Add(label);
            //label.Text = labelText;
            //label.Width = 100;
            //label.Height = 30;
            //label.Location = startPoint;
            //startPoint.Y += label.Height;

            //ImageBox box = new ImageBox();
            //panel1.Controls.Add(box);
            //box.ClientSize = image.Size;
            //box.Image = image;
            //box.Location = startPoint;
            //startPoint.Y += box.Height + 10;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            var currentFrame = capture.QueryFrame().ToImage<Bgr, byte>();

            if (currentFrame != null)
            {

                //DetectPlateNumber(currentFrame);
                var grayFrame = currentFrame.Convert<Gray, byte>();


                var detectedFaces = cascade.DetectMultiScale(grayFrame, 1.1, 0, System.Drawing.Size.Empty);

                if (detectedFaces.Count() > 0)
                {
                    Console.WriteLine($"Detected: {detectedFaces.Count()}");
                }

                foreach (var face in detectedFaces)
                    currentFrame.Draw(face, new Bgr(255, 0, 0), 3);

                // this.image1.Source =  new BitmapImage( currentFrame.ToBitmap();

                var bitmap = currentFrame.ToBitmap();

                using (var memory = new MemoryStream())
                {
                    bitmap.Save(memory, ImageFormat.Png);
                    memory.Position = 0;



                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = memory;
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();

                    //this.ImageFace.Source = bitmapImage;

                }
            }

        }


    }
}
