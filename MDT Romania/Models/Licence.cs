using System.ComponentModel.DataAnnotations;

namespace MDT_Romania.Models
{
    public class Licence
    {
        [Key]
        public int Id { get; set; }
        public string subcateg { get; set; }

        public DateTime Date { get; set; }
        
        public  string PermitNumber { get; set; }
        public string Relesedby { get; set; }
        public int LicenceType { get; set; } //-> driver =0 flying =1 weapon =2 
        public int CivilianId { get; set; }
        public Civilian? Civilian { get; set; }

    }
}
