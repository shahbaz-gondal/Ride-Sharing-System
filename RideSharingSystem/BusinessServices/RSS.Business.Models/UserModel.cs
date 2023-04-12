using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSS.Business.Models
{
    public class UserModel
    {
        public UserModel()
        {
            Offers = new List<OfferModel>();
            Requests = new List<RequestModel>();
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
        public List<OfferModel> Offers { get; set; }
        public List<RequestModel> Requests { get; set; }
    }
}
