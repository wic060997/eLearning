using Infrastructure;
using Model.ClassesModel.DTO;
using Model.ClassesModel.Entity;
using Model.ClassesModel.Repository;
using Model.GroupSModel.DTO;
using Model.LessonModel.DTO;
using Model.SchoolModel.DTO;
using Model.SubjectModel.DTO;
using Model.TeacherModel.DTO;
using Model.UserModel.DTO;
using Persistance.InfrastructureRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.ClassesRepository
{
    public class ClassesRepository : NHCrudRepository<Classes>, IClassesRepository
    {
        public ClassesRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public IList<Classes> GetAll()
        {
            return NHUnitOfWork.Session.Query<Classes>().ToList<Classes>();
        }

        public IList<ClassesDTO> GetAllDTO()
        {
            return NHUnitOfWork.Session.Query<Classes>()
                .Select(x => new ClassesDTO()
                {
                    Id = x.Id,
                    Lesson = new LessonDTO()
                    {
                        Id = x.Lesson.Id,
                        GroupS = new GroupSDTO()
                        {
                            Id = x.Lesson.GroupS.Id,
                            Year = x.Lesson.GroupS.Year,
                            Semester = x.Lesson.GroupS.Semester,
                            Direction = x.Lesson.GroupS.Direction,
                            Specjalize = x.Lesson.GroupS.Specjalize
                        },
                        Teacher = new TeacherDTO()
                        {
                            Id = x.Lesson.Teacher.Id,
                            user = new UserDTO()
                            {
                                Id = x.Lesson.Teacher.Users.Id,
                                Login = x.Lesson.Teacher.Users.Login,
                                ImieNazwisko = x.Lesson.Teacher.Users.ImieNazwisko,
                                CzyAktywny = x.Lesson.Teacher.Users.CzyAktywny,
                                Password = x.Lesson.Teacher.Users.Password,
                                Email = x.Lesson.Teacher.Users.Email,
                                Rola = new RolaDTO()
                                {
                                    Id = x.Lesson.Teacher.Users.Rola.Id,
                                    Nazwa = x.Lesson.Teacher.Users.Rola.Nazwa
                                },
                                School = new SchoolDTO()
                                {
                                    Id = x.Lesson.Teacher.Users.School.Id,
                                    Name = x.Lesson.Teacher.Users.School.Name,
                                    Logo = x.Lesson.Teacher.Users.School.Logo
                                },
                                NrIndex = x.Lesson.Teacher.Users.NrIndex,
                                Image = x.Lesson.Teacher.Users.Image,
                                GroupS = new GroupSDTO(),
                            },
                            Specjalize = x.Lesson.Teacher.Specjalize,
                        },
                        Subject = new SubjectDTO()
                        {
                            Id = x.Lesson.Subject.Id,
                            Name = x.Lesson.Subject.Name,
                        },
                        TypLesson = x.Lesson.TypLesson,
                        Time = x.Lesson.Time
                    },
                    Theme = x.Theme,
                    DataClasses = x.DataClasses,
                })
            .ToList<ClassesDTO>();
        }

        public IList<ClassesDTO> GetFromLesson(Guid id)
        {
            return NHUnitOfWork.Session.Query<Classes>()
                .Where(x=>x.Lesson.Id==id)
                .Select(x => new ClassesDTO()
                {
                    Id = x.Id,
                    Lesson = new LessonDTO()
                    {
                        Id = x.Lesson.Id,
                        GroupS = new GroupSDTO()
                        {
                            Id = x.Lesson.GroupS.Id,
                            Year = x.Lesson.GroupS.Year,
                            Semester = x.Lesson.GroupS.Semester,
                            Direction = x.Lesson.GroupS.Direction,
                            Specjalize = x.Lesson.GroupS.Specjalize
                        },
                        Teacher = new TeacherDTO()
                        {
                            Id = x.Lesson.Teacher.Id,
                            user = new UserDTO()
                            {
                                Id = x.Lesson.Teacher.Users.Id,
                                Login = x.Lesson.Teacher.Users.Login,
                                ImieNazwisko = x.Lesson.Teacher.Users.ImieNazwisko,
                                CzyAktywny = x.Lesson.Teacher.Users.CzyAktywny,
                                Password = x.Lesson.Teacher.Users.Password,
                                Email = x.Lesson.Teacher.Users.Email,
                                Rola = new RolaDTO()
                                {
                                    Id = x.Lesson.Teacher.Users.Rola.Id,
                                    Nazwa = x.Lesson.Teacher.Users.Rola.Nazwa
                                },
                                School = new SchoolDTO()
                                {
                                    Id = x.Lesson.Teacher.Users.School.Id,
                                    Name = x.Lesson.Teacher.Users.School.Name,
                                    Logo = x.Lesson.Teacher.Users.School.Logo
                                },
                                NrIndex = x.Lesson.Teacher.Users.NrIndex,
                                Image = x.Lesson.Teacher.Users.Image,
                                GroupS = new GroupSDTO(),
                            },
                            Specjalize = x.Lesson.Teacher.Specjalize,
                        },
                        Subject = new SubjectDTO()
                        {
                            Id = x.Lesson.Subject.Id,
                            Name = x.Lesson.Subject.Name,
                        },
                        TypLesson = x.Lesson.TypLesson,
                        Time = x.Lesson.Time
                    },
                    Theme = x.Theme,
                    DataClasses = x.DataClasses,
                })
            .ToList<ClassesDTO>();
        }
    }
}
