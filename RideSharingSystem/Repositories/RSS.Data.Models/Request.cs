using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RSS.Data.Models
{
    public class Request
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FromCity { get; set; } = string.Empty;
        [Required]
        public string ToCity { get; set;} = string.Empty;
        [Required]
        public DateTime DepartureDateTime { get; set; }
        [Required]
        public int Fare { get; set; }
        [Required]
        public string Status { get; set; }


        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}