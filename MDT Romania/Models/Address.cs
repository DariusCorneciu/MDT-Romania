using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDT_Romania.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="You have to select a county")]
        public string County { get; set; }
        [Required(ErrorMessage = "You have to select a city")]
        public string City { get; set; }
        [Required(ErrorMessage = "The street is mandatory")]
        public string Street { get; set; }
        [Required(ErrorMessage = "The number is mandatory")]
        public int Number { get; set; }
        public string ?AddressLine {  get; set; }

        public virtual ICollection<Civilian>? Civilian { get; set;}
       
        public string ShowAddres()
        {
            if (AddressLine != null)
            {
            return County+", "+City+", str."+Street+", nr."+Number+", "+AddressLine;
            }

            return County + ", " + City + ", str." + Street + ", nr." + Number;

        }
    }
}
