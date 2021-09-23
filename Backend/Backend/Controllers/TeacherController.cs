using Microsoft.AspNetCore.Mvc;
using Model.TeacherModel.DTO;
using Model.TeacherModel.Entity;
using Model.TeacherModel.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeacherController: Controller
    {
        private ITeacherService teacherService;

        public TeacherController(
            ITeacherService teacherService
            )
        {
            this.teacherService = teacherService;
        }

        [HttpGet]
        public IEnumerable<TeacherDTO> GetAll()
        {
            return teacherService.GetAllDTO();
        }

        [HttpGet("{id}")]
        public TeacherDTO Get(Guid id)
        {
            return teacherService.GetTeacher(id);
        }

        [HttpPost("NewTeacher")]
        public IActionResult NewTeacher(NewTeacherDTO dto)
        {
            teacherService.NewTeacher(dto);
            return Ok();
        }

        [HttpGet("TeachersSchool/{id}")]
        public IEnumerable<TeacherDTO> GetTeacherFromSchool(Guid id)
        {
            return teacherService.GetTeachersFromSchool(id);
        }

        [HttpGet("GetInfoTeacher/{id}")]
        public IActionResult GetInfoteacher(Guid id)
        {
            var result = teacherService.GetTeacherInformation(id);
            return Ok(result);
        }
    }
}
