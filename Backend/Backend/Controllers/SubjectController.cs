using Microsoft.AspNetCore.Mvc;
using Model.SubjectModel.DTO;
using Model.SubjectModel.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubjectController:Controller
    {
        private ISubjectService subjectService;
        public SubjectController(
            ISubjectService subjectService
            )
        {
            this.subjectService = subjectService;
        }

        [HttpPost]
        public IActionResult NewSubject(NewSubjectDTO dto)
        {
            Guid id = subjectService.NewSubject(dto);
            if (id != null)
            {
                return Ok();
                
            }
            return new NoContentResult();
        }

        [HttpGet("school/{id}")]
        public IActionResult GetallToSchool(Guid id)
        {
            var subject = subjectService.GetAllToSchool(id);
                return Ok(subject);
        }

        [HttpGet("{id}")]
        public IActionResult GetSubject(Guid id)
        {
            var result = subjectService.GetInfoSubject(id);
            return Ok(result);
        }
    }
}
