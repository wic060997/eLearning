using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Auth.Models
{
    public class AuthenticateRequest
    {
        [Required]
        public string login { get; set; }

        [Required]
        public string password { get; set; }
    }
}
