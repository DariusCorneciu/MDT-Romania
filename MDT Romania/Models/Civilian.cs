using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDT_Romania.Models
{
    
    public class Civilian
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is mandatory")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is mandatory")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "D.O.B is mandatory")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Gender is mandatory")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "CitizenId is mandatory")]
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


        [NotMapped]
        public IEnumerable<SelectListItem>? SelectAddress { get; set; }


        public string ImageSource()
        {
            if (Photo != null)
            {
                var Base64 = Convert.ToBase64String(Photo);
                string ImgSrc = $"data:{PhotoType};base64,{Base64}";
                return ImgSrc;

            }
            return "/img/default.jpg";

        }

        public bool ActiveWarrant()
        {
            if (Raports == null) { return false; }

            if (Raports.Where(i => i.Type == 2).Count() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
