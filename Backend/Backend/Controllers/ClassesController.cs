using Microsoft.AspNetCore.Mvc;
using Model.ClassesModel.DTO;
using Model.ClassesModel.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClassesController: Controller
    {
        private IClassesService sevice;

        public ClassesController(
            IClassesService service
            )
        {
            this.sevice = service;
        }

        [HttpPost("NewClasses")]
        public IActionResult NewClasses(NewClassesDTO dto)
        {
            sevice.AddClasses(dto);
            return Ok();
        }
        
        [HttpGet("GetLesson/{id}")]
        public IEnumerable<ClassesDTO> GetClassesFromLesson(Guid id)
        {
            return sevice.GetFromLesson(id);
        }
    }
}
