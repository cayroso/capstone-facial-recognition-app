using Emgu.CV;
using Emgu.CV.Cuda;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using parking.system.winform.code;
using parking.system.winform.data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parking.system.winform
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            var db = new AppDbContext();

            const string sql = @"
create table if not exists Parking(
    ParkingId varchar(32) not null
    , PlateNumber varchar(32) not null

    , DateStart datetime not null
    , DateEnd datetime null
);

create table if not exists ParkingFaceImage(
    ParkingFaceImageId varchar(32) not null
    , ParkingId varchar(32) not null
    , Filename varchar(500) not null
);

create table if not exists ParkingPlateImage(
    ParkingPlateImageId varchar(32) not null
    , ParkingId varchar(32) not null
    , Filename varchar(500) not null
);
";
            
            db.Database.ExecuteSqlCommand(sql);

            //  SEED DATA
            //AppDbInitializer.Initialize(db);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new frmSplash());

            //Application.Run(new frmEntryPlate());
            Application.Run(new frmMain());
            //Application.Run(new frmExit());

            //Run();
        }

        static void Run()
        {
            IImage image;

            //Read the files as an 8-bit Bgr image  
            //var file = @"C:\Users\ChristopherAyroso\Desktop\lena.jpg";
            var file = @"C:\Users\ChristopherAyroso\Pictures\test.jpg";
            image = new UMat(file, ImreadModes.Color); //UMat version
                                                       //image = new Mat("lena.jpg", ImreadModes.Color); //CPU version

            long detectionTime;
            List<Rectangle> faces = new List<Rectangle>();
            List<Rectangle> eyes = new List<Rectangle>();

            DetectFace.Detect(
              image, @"haarcascades\haarcascade_frontalface_default.xml", @"haarcascades\haarcascade_eye.xml",
              faces, eyes,
              out detectionTime);

            foreach (Rectangle face in faces)
                CvInvoke.Rectangle(image, face, new Bgr(Color.Red).MCvScalar, 2);
            foreach (Rectangle eye in eyes)
                CvInvoke.Rectangle(image, eye, new Bgr(Color.Blue).MCvScalar, 2);

            //display the image 
            using (InputArray iaImage = image.GetInputArray())
                ImageViewer.Show(image, String.Format(
                   "Completed face and eye detection using {0} in {1} milliseconds",
                   (iaImage.Kind == InputArray.Type.CudaGpuMat && CudaInvoke.HasCuda) ? "CUDA" :
                   (iaImage.IsUMat && CvInvoke.UseOpenCL) ? "OpenCL"
                   : "CPU",
                   detectionTime));
        }
    }
}
