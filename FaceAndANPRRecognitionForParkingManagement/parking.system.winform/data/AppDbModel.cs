using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking.system.winform.data
{
    public class Registration
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string RegistrationId { get; set; }

        public string Fullname { get; set; }

        public virtual ICollection<RegistrationImage> Images { get; set; }
        public virtual ICollection<Parking> Parkings { get; set; }
    }
    
    public enum EnumRegistrationImageType
    {
        Unknown = 0,
        Face = 1,
        Plate = 2
    }

    public class RegistrationImage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string RegistrationImageId { get; set; }
        
        public string RegistrationId { get; set; }
        public virtual Registration Registration { get; set; }

        public EnumRegistrationImageType RegistrationImageType { get; set; }

        public string Filename { get; set; }
    }

    public class Parking
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ParkingId { get; set; }

        public string RegistrationId { get; set; }
        public virtual Registration Registration { get; set; }

        public string PlateNumber { get; set; }

        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
    }
}
