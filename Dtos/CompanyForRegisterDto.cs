using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Dtos
{
    public class CompanyForRegisterDto
    {
        [Required]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify a password between 4 and 8 characters")]
        public string Password { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }
    }
}
