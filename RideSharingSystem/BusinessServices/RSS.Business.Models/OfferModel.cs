﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSS.Business.Models
{
    public class OfferModel
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
        public int Cost { get; set; }
        [Required]
        public string Status { get; set; }


        [ForeignKey("UserModel")]
        public int UserId { get; set; }
        public virtual UserModel User { get; set; }
    }
}
