using Microsoft.AspNetCore.Mvc;
using Model.LessonModel.DTO;
using Model.LessonModel.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LessonController: Controller
    {
        private ILessonService lessonService;

        public LessonController(
            ILessonService lessonService
            )
        {
            this.lessonService = lessonService;
        }

        [HttpPost("New")]
        public IActionResult NewLesson(NewLessonDTO dto)
        {
            lessonService.NewLesson(dto);
            return Ok();
        }
        [HttpGet("GetSubject/{id}")]
        public IActionResult GetSubject(Guid id)
        {
            var result =  lessonService.GetSubject(id);
            return Ok(result);
        }

        [HttpGet("GetLesson/{id}")]
        public IActionResult GetLesson(Guid id)
        {
            var result = lessonService.GetLesson(id);
            return Ok(result);
        }

        [HttpGet("GetFilesLesson/{id}")]
        public IActionResult GetFilesLesson(Guid id)
        {
            var res = lessonService.GetLessonFiles(id);
            return Ok(res);
        }

        [HttpGet("GetInfoLessons/{id}")]
        public IActionResult GetInfoLesson(Guid id)
        {
            var res = lessonService.GetLessonFiles(id);

            return Ok(res);
        }
    }
}
