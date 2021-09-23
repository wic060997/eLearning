using Microsoft.AspNetCore.Mvc;
using Model.MaterialModel.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaterialController : Controller
    {
        private IMaterialService materialService;

        public MaterialController(
            IMaterialService materialService
            )
        {
            this.materialService = materialService;
        }

        [HttpGet("GetClasses/{id}")]
        public IActionResult GetSubject(Guid id)
        {
            var res =  materialService.GetInfoMaterialFromClasses(id);
            return Ok(res);
        }

        [HttpGet("Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            materialService.Delete(id);
            return Ok();
        }

        [HttpGet("GetFromSchool/{id}")]
        public IActionResult GetFromSchool(Guid id)
        {
            var res = materialService.GetFromSchool(id);
            return Ok(res);
        }
    }
}
