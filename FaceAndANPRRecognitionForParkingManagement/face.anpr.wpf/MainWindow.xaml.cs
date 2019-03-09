using Emgu.CV;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private VideoCapture capture;
        private readonly CascadeClassifier cascade = new CascadeClassifier(@"Data/haarcascade_frontalface_alt_tree.xml");
        DispatcherTimer timer;


        private Tesseract _ocr;

        public MainWindow()
        {
            InitializeComponent();


            //create OCR engine
            //_ocr = new Tesseract(System.AppDomain.CurrentDomain.BaseDirectory + @"\Data\\", "eng", OcrEngineMode.Default);
            //_ocr.Init("", "eng", OcrEngineMode.TesseractLstmCombined);
            //_ocr.SetVariable("tessedit_char_whitelist", "ABCDEFGHIJKLMNOPQRSTUVWXYZ-1234567890");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            capture = new VideoCapture();
            
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer.Start();
        }

        void DetectPlateNumber(Image<Bgr,byte> currentFrame)
        {
            var imgInput = currentFrame.Clone();

            Image<Gray, byte> imgout = imgInput.Convert<Gray, byte>().Not().ThresholdBinary(new Gray(50), new Gray(255));

            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            Mat hier = new Mat();

            CvInvoke.FindContours(imgout, contours, hier, Emgu.CV.CvEnum.RetrType.External, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);
            //show = true;
            if (contours.Size > 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    var rect = CvInvoke.BoundingRectangle(contours[i]);
                    imgInput.ROI = rect;

                    //img = imgInput.Copy().Bitmap;
                    //imgInput.ROI = Rectangle.Empty;
                    //this.Invalidate();

                    //await Task.Delay(500);
                }
                //show = false;
            }
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

                    this.image1.Source = bitmapImage;

                }
            }

        }


    }
}
