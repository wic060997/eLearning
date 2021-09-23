
using Microsoft.AspNetCore.Mvc;
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
    public class RolaController:Controller
    {
        private IRolaService service;

        public RolaController(IRolaService rolaService)
        {
            this.service = rolaService;
        }

        [HttpGet]
        public IEnumerable<RolaDTO> GetAll()
        {
            return service.PobierzListeRol();
        }

        
    }
}
