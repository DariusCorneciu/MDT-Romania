using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDT_Romania.Models
{
    public class Raport
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Type { get; set; } /// 1->dosar penal 2->mandat
        [Required(ErrorMessage ="Title is mandatory, Example: Name | Best Charge | Gravity")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is mandatory. Ask your self: What happend? How many people? We have witnesses?")]
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public int CivilianId { get; set; }
        public virtual Civilian? Civilian { get; set; }
        // relatii
        public string ?UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }

        public virtual ICollection<CrimeRaport>? CrimeRaports { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem>? SelectCivilian { get; set; } = new List<SelectListItem>();

       public bool Expired()
        {
            
            if(Type == 2 && DateTime.Now > Date.AddDays(30))
            {
                return true;
            }
            return false;
        }

    }
}
