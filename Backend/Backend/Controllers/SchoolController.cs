using Microsoft.AspNetCore.Mvc;
using Model.SchoolModel.DTO;
using Model.SchoolModel.IService;
using Model.UserModel.DTO;
using Model.UserModel.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchoolController : Controller
    {
        private ISchoolService service;
        private IUserService userService;

        public SchoolController(ISchoolService rolaService, IUserService userService)
        {
            this.service = rolaService;
            this.userService = userService;
        }

        [HttpGet]
        public IEnumerable<SchoolDTO> GetAll()
        {
            return service.GetAllDTO();
        }

        [HttpPost("New")]
        public IActionResult NewSchool(NewSchoolDTO dto)
        {
            Guid id = service.NewSchool(dto);
            if (id == null)
            {
                return new NoContentResult();
            }
            else
            {
                UserDTO user = new UserDTO()
                {
                    Id = Guid.NewGuid(),
                    Login = dto.Login,
                    ImieNazwisko = dto.ImieNazwisko,
                    CzyAktywny = true,
                    Password = dto.Password,
                    Email = dto.email
                };
                userService.AddAdministration(user, id);
            }
            return Ok();
        }
    }
}
