using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MDT_Romania.Models
{
    public class CrimeRaport
    {
        public int RaportId { get; set; }
        
        public int CrimeId { get; set; }
        public virtual Crime ?Crime { get; set; }
        public virtual Raport ?Raport { get; set; }
    }
}
