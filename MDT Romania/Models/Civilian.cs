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
        public string Gender { get; set; }
        public string CitizenId { get; set; }

        public string Job { get; set; } = "Somer";
        public string? Information { get; set; }
        public int ?AddressId { get; set; }
        public virtual Address? Address { get; set; }
        public virtual ICollection<Raport>? Raports { get; set; }
        public virtual ICollection<Vehicle>? Vehicles { get; set; }

        /// poza de profil 
        public byte[]? Photo { get; set; }
        public string? PhotoType { get; set; }

        public string ImageSource()
        {
            if (Photo != null)
            {
                var Base64 = Convert.ToBase64String(Photo);
                string ImgSrc = $"data:{PhotoType};base64:{Base64}";
                return ImgSrc;

            }
            return "~/img/default.png";

        }
        
    }
}
