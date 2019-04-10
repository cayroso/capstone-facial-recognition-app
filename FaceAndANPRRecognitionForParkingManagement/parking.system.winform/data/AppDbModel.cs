using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking.system.winform.data
{
    public enum EnumParkingImageType
    {
        Unknown = 0,
        Face = 1,
        Plate = 2,
    }

    public class Parking
    {
        public Parking()
        {
            FaceImages = new List<ParkingFaceImage>();
            PlateImages = new List<ParkingPlateImage>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ParkingId { get; set; }

        public string PlateNumber { get; set; }

        
        public virtual ICollection<ParkingFaceImage> FaceImages { get; set; }

        public virtual ICollection<ParkingPlateImage> PlateImages { get; set; }

        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
    }

    public class ParkingFaceImage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ParkingFaceImageId { get; set; }
        
        public string ParkingId { get; set; }
        public virtual Parking Parking { get; set; }
        
        public string Filename { get; set; }
    }

    public class ParkingPlateImage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ParkingPlateImageId { get; set; }

        public string ParkingId { get; set; }
        public virtual Parking Parking { get; set; }
        
        public string Filename { get; set; }
    }
}
