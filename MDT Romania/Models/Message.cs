using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace MDT_Romania.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        public string Text { get; set; }
        public DateTime Data { get; set; }
        public string ?UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
