using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking.system.winform.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() :
            base(new SQLiteConnection()
            {
                ConnectionString = new SQLiteConnectionStringBuilder()
                {
                    DataSource = "AppDb.db",
                    ForeignKeys = true
                }.ConnectionString
            }, true)
        {
            //this.Configuration.LazyLoadingEnabled = false;
        }
        
        
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Parking>()
            //    .HasKey(p => p.ParkingId)
            //    ;

            //modelBuilder.Entity<ParkingImage>()
            //    .HasKey(p => p.ParkingImageId)
            //    ;

            modelBuilder.Entity<ParkingFaceImage>()
                .HasRequired(p=> p.Parking)
                .WithMany(p=> p.FaceImages)
                .HasForeignKey(p=> p.ParkingId)                
                ;

            modelBuilder.Entity<ParkingPlateImage>()
                .HasRequired(p => p.Parking)
                .WithMany(p => p.PlateImages)
                .HasForeignKey(p => p.ParkingId)
                ;

            modelBuilder.Entity<Parking>().ToTable("Parking");
            modelBuilder.Entity<ParkingFaceImage>().ToTable("ParkingFaceImage");
            modelBuilder.Entity<ParkingPlateImage>().ToTable("ParkingPlateImage");


        }

        public DbSet<Parking> Parkings { get; set; }
        public DbSet<ParkingFaceImage> ParkingFaceImages { get; set; }
        public DbSet<ParkingPlateImage> ParkingPlateImages { get; set; }
    }

    public static class AppDbInitializer
    {

        public static void Initialize(AppDbContext db)
        {

            //  check if we need to prepopulate
            if (!db.Parkings.Any())
            {

                var parking = new[]
                {
                    new Parking
                    {
                        ParkingId = Guid.NewGuid().ToString(),
                        PlateNumber= "1234", DateStart= DateTime.UtcNow, DateEnd = DateTime.UtcNow.AddHours(3)
                    },
                    new Parking
                    {
                        ParkingId = Guid.NewGuid().ToString(),
                        PlateNumber= "222", DateStart= DateTime.UtcNow.AddHours(4), DateEnd = DateTime.UtcNow.AddHours(5)
                    }
                };


                parking[0].FaceImages = new List<ParkingFaceImage> {
                    new ParkingFaceImage
                    {
                        ParkingFaceImageId = Guid.NewGuid().ToString(), ParkingId = parking[0].ParkingId, Filename="Face1"
                    },
                    //new ParkingImage
                    //{
                    //    ParkingImageId = Guid.NewGuid().ToString(), ParkingId = parking[0].ParkingId, ParkingImageType = EnumParkingImageType.Face, Filename="Face2"
                    //},
                    //new ParkingImage
                    //{
                    //    ParkingImageId = Guid.NewGuid().ToString(), ParkingId = parking[0].ParkingId, ParkingImageType = EnumParkingImageType.Face, Filename="Face3"
                    //},
                };

                db.Parkings.AddRange(parking);
                //db.ParkingImages.AddRange(parkingImages);

                //db.Registrations.Add(reg);
                //db.RegistrationImages.AddRange(images);
                //db.Parkings.AddRange(parking);

                db.SaveChanges();

            }
        }
    }
}
