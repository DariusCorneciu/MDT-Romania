using System.ComponentModel.DataAnnotations;

namespace MDT_Romania.Models
{
    public class BOLO
    {
        [Key]
        public int Id { get; set; }
        public DateTime LastSeen { get; set; }
        public string Description { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }

        public int VehicleId { get; set; }
        public virtual Vehicle? Vehicle { get; set; }
    }
}
