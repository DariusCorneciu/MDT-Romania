using System.ComponentModel.DataAnnotations;

namespace MDT_Romania.Models
{
    public class Crime
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string? Description { get; set; }
        public int Fine {  get; set; }
        public int Jail { get; set; }

        public int ?CategoryId { get; set; }
        public Category ?Category { get; set; }
        public virtual ICollection<CrimeRaport>? CrimeRaports { get; set; }

    }
}
