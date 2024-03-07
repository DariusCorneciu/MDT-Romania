using System.ComponentModel.DataAnnotations;

namespace MDT_Romania.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LicensePlate { get; set; }
        public int CivilianId { get; set; }
        public virtual Civilian? Civilian { get; set; }
        public int VehicleModelId { get; set; }
        public virtual VehicleModel? Model { get; set; }


    }
}
