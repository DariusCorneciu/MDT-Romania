using System.ComponentModel.DataAnnotations;

namespace MDT_Romania.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Crime> ?Crimes { get; set; }
    }
}
