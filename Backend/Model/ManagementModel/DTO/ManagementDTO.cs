using Model.UserModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ManagementModel.DTO
{
    public class ManagementDTO
    {
        public Guid Id { get; set; }
        public UserDTO user { get; set; }
    }
}
