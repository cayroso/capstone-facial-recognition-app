using Emgu.CV;
using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace face.anpr.winform
{
    public partial class Form1 : Form
    {
        private readonly CascadeClassifier cascade = new CascadeClassifier(@"Data/haarcascade_frontalface_alt_tree.xml");
        //DispatcherTimer timer;

        public Form1()
        {
            InitializeComponent();

            ImageViewer viewer = new ImageViewer(); //create an image viewer
            var capture = new VideoCapture(); //create a camera captue
            Application.Idle += new EventHandler(delegate (object sender, EventArgs e)
            {  //run this until application closed (close button click on image viewer)
                viewer.Image = capture.QueryFrame(); //draw the image obtained from camera
            });
            viewer.ShowDialog(); //show the image viewer

            //timer = new DispatcherTimer();
            //timer.Tick += new EventHandler(timer_Tick);
            //timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            //timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            //Image<Bgr, Byte> currentFrame = capture.QueryFrame();

            //if (currentFrame != null)
            //{
            //    Image<Gray, Byte> grayFrame = currentFrame.Convert<Gray, Byte>();

            //    var detectedFaces = grayFrame.DetectHaarCascade(haarCascade)[0];

            //    foreach (var face in detectedFaces)
            //        currentFrame.Draw(face.rect, new Bgr(0, double.MaxValue, 0), 3);

            //    image1.Source = ToBitmapSource(currentFrame);
            //}

        }
    }
}
