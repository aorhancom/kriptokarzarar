using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BinanceKarZarar.Models
{
    public class RegisterModel
    {
        [Required]
        [StringLength(3)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(3)]
        public string Password { get; set; }
    }
}
