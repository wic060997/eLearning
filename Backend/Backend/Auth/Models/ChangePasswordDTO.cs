using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Auth.Models
{
    public class ChangePasswordDTO
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public string OldPassword { get; set; }
    }
}
