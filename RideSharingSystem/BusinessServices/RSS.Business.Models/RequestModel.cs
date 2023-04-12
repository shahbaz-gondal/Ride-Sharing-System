using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RSS.Business.Models
{
    public class RequestModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FromCity { get; set; } = string.Empty;
        [Required]
        public string ToCity { get; set; } = string.Empty;
        [Required]
        public DateTime DepartureDateTime { get; set; }
        [Required]
        public int Fare { get; set; }
        [Required]
        public string Status { get; set; }


        [ForeignKey("UserModel")]
        public int UserId { get; set; }
        public virtual UserModel User { get; set; }
    }
}