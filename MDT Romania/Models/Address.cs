using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDT_Romania.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
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
