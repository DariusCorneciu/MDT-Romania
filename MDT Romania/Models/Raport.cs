using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace MDT_Romania.Models
{
    public class Raport
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Type { get; set; } /// 0->amenda 1->dosar penal 2->mandat
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public int CivilianId { get; set; }
        public virtual Civilian? Civilian { get; set; }
        // relatii
        public string ?UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }

        public virtual ICollection<CrimeRaport>? CrimeRaports { get; set; }

    }
}
