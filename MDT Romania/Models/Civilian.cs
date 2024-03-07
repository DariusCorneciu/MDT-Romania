using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDT_Romania.Models
{
    
    public class Civilian
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }


        public string Job { get; set; } = "Somer";
        public string? Information { get; set; }

        public int AddressId { get; set; }
        public virtual Address? Address { get; set; }
        public virtual ICollection<Raport>? Raports { get; set;}
        public virtual ICollection<Vehicle>? Vehicles { get; set; }
    }
}
