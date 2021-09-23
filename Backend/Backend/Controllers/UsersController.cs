using Backend.Auth.Models;
using Backend.Auth.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.GroupSModel.DTO;
using Model.LessonModel.DTO;
using Model.LessonModel.IService;
using Model.SchoolModel.DTO;
using Model.SubjectModel.DTO;
using Model.TeacherModel.DTO;
using Model.TeacherModel.IService;
using Model.UserModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private ILessonService lessonService;
        private ITeacherService teacherService;

        public UsersController(
            IUserService userService,
            ILessonService lessonService,
            ITeacherService teacherService
            )
        {
            _userService = userService;
            this.lessonService = lessonService;
            this.teacherService = teacherService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [HttpPost("register")]
        public IActionResult SignUp(RegistrationRequest model)
        {
            var response = _userService.Registration(model);

            if (response == null)
                return BadRequest(new { message = "Error register!!!" });

            return Ok(response);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("Brak id skladnika do usunięcia");

            _userService.Delete(id);

            return new NoContentResult();
        }


        [HttpGet("get/{id}")]
        public UserDTO Get(Guid id)
        {
            var user = _userService.GetDTOById(id);

            return user;
        }

        [HttpGet("getSchool/{id}")]
        public IActionResult GetSchool(Guid id)
        {
            var users = _userService.GetUsersToSchool(id);
            List<UserStaticDTO> userStatic = new List<UserStaticDTO>();
            foreach (var elem in users)
            {
                UserStaticDTO add = new UserStaticDTO();
                add.Id = elem.Id;
                add.ImieNazwisko = elem.ImieNazwisko;
                add.Login = elem.Login;
                add.Email = elem.Email;
                add.Rola = elem.Rola;

                if (elem.Rola.Nazwa == "STUDENT")
                {
                    add.NrIndex = elem.NrIndex;
                    add.Group = elem.GroupS;
                }
                if (elem.Rola.Nazwa == "TEACHER")
                {
                    TeacherDTO teacher = teacherService.GetTeacherFromUser(elem.Id);
                    add.Specjalize = teacher.Specjalize;

                    IList<LessonDTO> lesson = lessonService.GetAllLessonTeacher(teacher.Id);
                    foreach (var e in lesson)
                    {
                        if (add.SubjectStatic != null)
                        {
                            if (add.SubjectStatic.Exists(x => x.Name == e.Subject.Name) == false)
                            {
                                SubjectStaticDTO newSubject = new SubjectStaticDTO();
                                newSubject.Id = e.Subject.Id;
                                newSubject.Name = e.Subject.Name;
                                newSubject.types = new List<TypeLessonStaticDTO>();

                                TypeLessonStaticDTO newTyp = new TypeLessonStaticDTO();
                                newTyp.Name = GetTypeName(e.TypLesson);
                                newTyp.LessonStatic = new List<LessonStaticDTO>();

                                LessonStaticDTO newLesson = new LessonStaticDTO();
                                newLesson.Id = e.Id;
                                newLesson.Time = e.Time;
                                newLesson.GroupStatic = new GroupStaticDTO();
                                newLesson.GroupStatic.Id = e.GroupS.Id;
                                newLesson.GroupStatic.Year = e.GroupS.Year;
                                newLesson.GroupStatic.Semester = e.GroupS.Semester;
                                newLesson.GroupStatic.Direction = e.GroupS.Direction;
                                newLesson.GroupStatic.Specjalize = e.GroupS.Specjalize;
                                newLesson.GroupStatic.UserStudent = _userService.GetStudentsFromGroup(e.GroupS.Id);

                                newTyp.LessonStatic.Add(newLesson);
                                newSubject.types.Add(newTyp);
                                add.SubjectStatic.Add(newSubject);
                            }
                            else
                            {
                                SubjectStaticDTO s = add.SubjectStatic.Where(x => x.Id == e.Subject.Id).FirstOrDefault();
                                add.SubjectStatic.Remove(s);

                                if (s.types.Exists(x => x.Name == GetTypeName(e.TypLesson)) == false)
                                {
                                    TypeLessonStaticDTO newTyp = new TypeLessonStaticDTO();
                                    newTyp.Name = GetTypeName(e.TypLesson);
                                    newTyp.LessonStatic = new List<LessonStaticDTO>();

                                    LessonStaticDTO newLesson = new LessonStaticDTO();
                                    newLesson.Id = e.Id;
                                    newLesson.Time = e.Time;
                                    newLesson.GroupStatic = new GroupStaticDTO();
                                    newLesson.GroupStatic.Id = e.GroupS.Id;
                                    newLesson.GroupStatic.Year = e.GroupS.Year;
                                    newLesson.GroupStatic.Semester = e.GroupS.Semester;
                                    newLesson.GroupStatic.Direction = e.GroupS.Direction;
                                    newLesson.GroupStatic.Specjalize = e.GroupS.Specjalize;
                                    newLesson.GroupStatic.UserStudent = _userService.GetStudentsFromGroup(e.GroupS.Id);

                                    newTyp.LessonStatic.Add(newLesson);
                                    s.types.Add(newTyp);
                                }
                                else
                                {
                                    TypeLessonStaticDTO type = s.types.Where(x => x.Name == GetTypeName(e.TypLesson)).FirstOrDefault();
                                    s.types.Remove(type);
                                    if (type.LessonStatic.Exists(x => x.Id == e.Id) == false)
                                    {
                                        LessonStaticDTO newLesson = new LessonStaticDTO();
                                        newLesson.Id = e.Id;
                                        newLesson.Time = e.Time;
                                        newLesson.GroupStatic = new GroupStaticDTO();
                                        newLesson.GroupStatic.Id = e.GroupS.Id;
                                        newLesson.GroupStatic.Year = e.GroupS.Year;
                                        newLesson.GroupStatic.Semester = e.GroupS.Semester;
                                        newLesson.GroupStatic.Direction = e.GroupS.Direction;
                                        newLesson.GroupStatic.Specjalize = e.GroupS.Specjalize;
                                        newLesson.GroupStatic.UserStudent = _userService.GetStudentsFromGroup(e.GroupS.Id);

                                        type.LessonStatic.Add(newLesson);
                                    }
                                    s.types.Add(type);
                                }
                                add.SubjectStatic.Add(s);
                            }
                        }
                        else
                        {
                            add.SubjectStatic = new List<SubjectStaticDTO>();

                            SubjectStaticDTO s = new SubjectStaticDTO();
                            s.types = new List<TypeLessonStaticDTO>();

                            TypeLessonStaticDTO newTyp = new TypeLessonStaticDTO();
                            newTyp.LessonStatic = new List<LessonStaticDTO>();
                            newTyp.Name = GetTypeName(e.TypLesson);

                            LessonStaticDTO newLesson = new LessonStaticDTO();
                            newLesson.Id = e.Id;
                            newLesson.Time = e.Time;
                            newLesson.GroupStatic = new GroupStaticDTO();
                            newLesson.GroupStatic.Id = e.GroupS.Id;
                            newLesson.GroupStatic.Year = e.GroupS.Year;
                            newLesson.GroupStatic.Semester = e.GroupS.Semester;
                            newLesson.GroupStatic.Direction = e.GroupS.Direction;
                            newLesson.GroupStatic.Specjalize = e.GroupS.Specjalize;
                            newLesson.GroupStatic.UserStudent = _userService.GetStudentsFromGroup(e.GroupS.Id);

                            
                            newTyp.LessonStatic.Add(newLesson);

                            
                            s.types.Add(newTyp);

                            add.SubjectStatic.Add(s);
                        }

                    }
                }
                userStatic.Add(add);
            }

            SchoolUsersStatic res = new SchoolUsersStatic();
            res.Users = userStatic;

            return Ok(res);
        }

        public GroupStaticDTO GetGroup(GroupSDTO dto)
        {
            GroupStaticDTO newGroup = new GroupStaticDTO();
            newGroup.Id = dto.Id;
            newGroup.Direction = dto.Direction;
            newGroup.Semester = dto.Semester;
            newGroup.Specjalize = dto.Specjalize;
            newGroup.Year = dto.Year;

            List<UserStudentDTO> students = _userService.GetStudentsFromGroup(dto.Id);

            return newGroup;
        }

        [Authorize]
        [HttpPut("ChangePassword")]
        public ActionResult ChangePassword([FromBody] ChangePasswordDTO model)
        {
            return Ok();
        }

        public string GetTypeName(int typ)
        {
            if (typ == 0)
            {
                return "Wyklad";
            }
            if (typ == 1)
            {
                return "Ćwiczenia";
            }
            if (typ == 2)
            {
                return "Projekt";
            }
            return null;
        }

        [HttpPost("NewStudent")]
        public IActionResult NewStudent(NewStudentDTO dto)
        {
            _userService.NewStudent(dto);
            return Ok();
        }

        [HttpGet("getGroup/{id}")]
        public IActionResult GetUsersFromSchool(Guid id)
        {
            var result = _userService.GetStudentsFromGroup(id);
            return Ok(result);
        }

        [HttpGet("getStudent/{id}")]
        public IActionResult GetStudent(Guid id)
        {
            var res = _userService.GetStudent(id);
            return Ok(res);
        }
    }
}
