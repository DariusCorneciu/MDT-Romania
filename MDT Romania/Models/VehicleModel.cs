using System.ComponentModel.DataAnnotations;

namespace MDT_Romania.Models
{
    public class VehicleModel
    {
        [Key]
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string ModelType { get; set; }

        public virtual ICollection<Vehicle>? Vehicles { get; set; }

    }
}
