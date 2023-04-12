using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace RSS.Data.Models
{
    public class User
    {
        public User()
        {
            Offers = new List<Offer>();
            Requests = new List<Request>();
        }
        
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string CNIC { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public List<Offer> Offers { get; set; }
        public List<Request> Requests { get; set; }

    }
}
