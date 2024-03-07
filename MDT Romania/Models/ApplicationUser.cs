using Microsoft.AspNetCore.Identity;

namespace MDT_Romania.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string ?FirstName { get; set; }
        public string ?LastName { get; set; }
        public virtual ICollection <Raport>? Raports {  get; set; } 
        public virtual ICollection <BOLO>? BOLOs { get; set; }

    }
}
