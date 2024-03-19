using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace MDT_Romania.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        public string Color { get; set; }
        public string LicensePlate { get; set; }
        public int CivilianId { get; set; }
        public virtual Civilian? Civilian { get; set; }
        public int VehicleModelId { get; set; }
        public virtual VehicleModel? Model { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem>? VehicleModels {  get; set; }

    }
}
