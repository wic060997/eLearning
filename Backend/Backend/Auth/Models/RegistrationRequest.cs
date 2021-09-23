using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Auth.Models
{
    public class RegistrationRequest
    {
        [Required]
        public string login { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public string imieNazwisko { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public Guid school { get; set; }
    }
}
