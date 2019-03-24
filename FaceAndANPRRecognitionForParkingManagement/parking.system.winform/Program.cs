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

            //  check if we need to prepopulate
            if (!db.Registrations.Any())
            {
                var reg = new Registration
                {
                    RegistrationId = "administrator",
                    Fullname = "Administrator"
                };

                var images = new[] {
                    new RegistrationImage
                    {
                        RegistrationImageId = Guid.NewGuid().ToString(),
                        RegistrationImageType = EnumRegistrationImageType.Face,
                        RegistrationId = reg.RegistrationId,
                        Filename = "face_administrator_636887433428456675.bmp",
                    },
                    new RegistrationImage
                    {
                        RegistrationImageId = Guid.NewGuid().ToString(),
                        RegistrationImageType = EnumRegistrationImageType.Face,
                        RegistrationId = reg.RegistrationId,
                        Filename = "face_administrator_636887434176482201.bmp",
                    },
                    new RegistrationImage
                    {
                        RegistrationImageId = Guid.NewGuid().ToString(),
                        RegistrationImageType = EnumRegistrationImageType.Face,
                        RegistrationId = reg.RegistrationId,
                        Filename = "face_administrator_636887434219632288.bmp",
                    },
                    new RegistrationImage
                    {
                        RegistrationImageId = Guid.NewGuid().ToString(),
                        RegistrationImageType = EnumRegistrationImageType.Face,
                        RegistrationId = reg.RegistrationId,
                        Filename = "face_administrator_636887434244201391.bmp",
                    },
                    new RegistrationImage
                    {
                        RegistrationImageId = Guid.NewGuid().ToString(),
                        RegistrationImageType = EnumRegistrationImageType.Face,
                        RegistrationId = reg.RegistrationId,
                        Filename = "face_administrator_636887434455409323.bmp",
                    },
                    new RegistrationImage
                    {
                        RegistrationImageId = Guid.NewGuid().ToString(),
                        RegistrationImageType = EnumRegistrationImageType.Face,
                        RegistrationId = reg.RegistrationId,
                        Filename = "face_administrator_636887438299117359.bmp",
                    },
                    new RegistrationImage
                    {
                        RegistrationImageId = Guid.NewGuid().ToString(),
                        RegistrationImageType = EnumRegistrationImageType.Face,
                        RegistrationId = reg.RegistrationId,
                        Filename = "face_administrator_636887438438272244.bmp",
                    },
                    new RegistrationImage
                    {
                        RegistrationImageId = Guid.NewGuid().ToString(),
                        RegistrationImageType = EnumRegistrationImageType.Face,
                        RegistrationId = reg.RegistrationId,
                        Filename = "face_administrator_636887438488228500.bmp",
                    }
                };

                var parking = new[]
                {
                    new Parking
                    {
                        ParkingId = Guid.NewGuid().ToString(),
                        RegistrationId = reg.RegistrationId, PlateNumber= "1234", DateStart= DateTime.UtcNow, DateEnd = DateTime.UtcNow.AddHours(3)
                    },
                    new Parking
                    {
                        ParkingId = Guid.NewGuid().ToString(),
                        RegistrationId = reg.RegistrationId, PlateNumber= "222", DateStart= DateTime.UtcNow.AddHours(4), DateEnd = DateTime.UtcNow.AddHours(5)
                    }
                };

                db.Registrations.Add(reg);
                db.RegistrationImages.AddRange(images);
                db.Parkings.AddRange(parking);

                db.SaveChanges();

            }
            //db.Database.
            //if (db.Database.CreateIfNotExists())
            //{
            //    db.Database.Initialize(true);
            //}
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmEntry());

            Application.Run(new frmMain());
            //Application.Run(new frmEntry());

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
