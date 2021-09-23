using Infrastructure;
using Model.GroupSModel.DTO;
using Model.GroupSModel.Entity;
using Model.LessonModel.DTO;
using Model.LessonModel.Entity;
using Model.LessonModel.Repository;
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

namespace Persistance.LessonRepository
{
    public class LessonRepository : NHCrudRepository<Lesson>, ILessonRepository
    {
        public LessonRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public IList<Lesson> GetAll()
        {
            return NHUnitOfWork.Session.Query<Lesson>().ToList<Lesson>();
        }

        public IList<LessonDTO> GetAllDTO()
        {
            return NHUnitOfWork.Session.Query<Lesson>()
                .Select(x => new LessonDTO()
                {
                    Id = x.Id,
                    GroupS = new GroupSDTO()
                    {
                        Id = x.GroupS.Id,
                        Year = x.GroupS.Year,
                        Semester = x.GroupS.Semester,
                        Direction = x.GroupS.Direction,
                        Specjalize = x.GroupS.Specjalize
                    },
                    Teacher = new TeacherDTO()
                    {
                        Id = x.Teacher.Id,
                        user = new UserDTO()
                        {
                            Id = x.Teacher.Users.Id,
                            Login = x.Teacher.Users.Login,
                            ImieNazwisko = x.Teacher.Users.ImieNazwisko,
                            CzyAktywny = x.Teacher.Users.CzyAktywny,
                            Password = x.Teacher.Users.Password,
                            Email = x.Teacher.Users.Email,
                            Rola = new RolaDTO()
                            {
                                Id = x.Teacher.Users.Rola.Id,
                                Nazwa = x.Teacher.Users.Rola.Nazwa
                            },
                            School = new SchoolDTO()
                            {
                                Id = x.Teacher.Users.School.Id,
                                Name = x.Teacher.Users.School.Name,
                                Logo = x.Teacher.Users.School.Logo
                            },
                            NrIndex = x.Teacher.Users.NrIndex,
                            Image = x.Teacher.Users.Image,
                            GroupS = new GroupSDTO(),
                        },
                        Specjalize = x.Teacher.Specjalize
                    },
                    Subject = new SubjectDTO()
                    {
                        Id = x.Subject.Id,
                        Name = x.Subject.Name
                    },
                    TypLesson = x.TypLesson,
                    Time = x.Time
                })
            .ToList<LessonDTO>();
        }

        public IList<LessonTypDTO> GetAllLessonSubject(Guid id)
        {
            return NHUnitOfWork.Session.Query<Lesson>()
                .Where(x => x.Subject.Id==id)
                .Select(x => new LessonTypDTO()
                {
                    Id = x.Id,
                    GroupS = new GroupSDTO()
                    {
                        Id = x.GroupS.Id,
                        Year = x.GroupS.Year,
                        Semester = x.GroupS.Semester,
                        Direction = x.GroupS.Direction,
                        Specjalize = x.GroupS.Specjalize
                    },
                    Teacher = new TeacherDTO()
                    {
                        Id = x.Teacher.Id,
                        user = new UserDTO()
                        {
                            Id = x.Teacher.Users.Id,
                            Login = x.Teacher.Users.Login,
                            ImieNazwisko = x.Teacher.Users.ImieNazwisko,
                            CzyAktywny = x.Teacher.Users.CzyAktywny,
                            Password = x.Teacher.Users.Password,
                            Email = x.Teacher.Users.Email,
                            Rola = new RolaDTO()
                            {
                                Id = x.Teacher.Users.Rola.Id,
                                Nazwa = x.Teacher.Users.Rola.Nazwa
                            },
                            School = new SchoolDTO()
                            {
                                Id = x.Teacher.Users.School.Id,
                                Name = x.Teacher.Users.School.Name,
                                Logo = x.Teacher.Users.School.Logo
                            },
                            NrIndex = x.Teacher.Users.NrIndex,
                            Image = x.Teacher.Users.Image,
                            GroupS = new GroupSDTO(),
                        },
                        Specjalize = x.Teacher.Specjalize
                    },
                    Subject = new SubjectDTO()
                    {
                        Id = x.Subject.Id,
                        Name = x.Subject.Name
                    },
                    TypLesson = GetTypeName(x.TypLesson),
                    Time = x.Time
                })
            .ToList<LessonTypDTO>();
        }

        public IList<LessonDTO> GetAllLessonTeacher(Guid id)
        {
            return NHUnitOfWork.Session.Query<Lesson>()
                .Where(x => x.Teacher.Id == id)
                .Select(x => new LessonDTO()
                {
                    Id = x.Id,
                    GroupS = new GroupSDTO()
                    {
                        Id = x.GroupS.Id,
                        Year = x.GroupS.Year,
                        Semester = x.GroupS.Semester,
                        Direction = x.GroupS.Direction,
                        Specjalize = x.GroupS.Specjalize
                    },
                    Teacher = new TeacherDTO()
                    {
                        Id = x.Teacher.Id,
                        user = new UserDTO()
                        {
                            Id = x.Teacher.Users.Id,
                            Login = x.Teacher.Users.Login,
                            ImieNazwisko = x.Teacher.Users.ImieNazwisko,
                            CzyAktywny = x.Teacher.Users.CzyAktywny,
                            Password = x.Teacher.Users.Password,
                            Email = x.Teacher.Users.Email,
                            Rola = new RolaDTO()
                            {
                                Id = x.Teacher.Users.Rola.Id,
                                Nazwa = x.Teacher.Users.Rola.Nazwa
                            },
                            School = new SchoolDTO()
                            {
                                Id = x.Teacher.Users.School.Id,
                                Name = x.Teacher.Users.School.Name,
                                Logo = x.Teacher.Users.School.Logo
                            },
                            NrIndex = x.Teacher.Users.NrIndex,
                            Image = x.Teacher.Users.Image,
                            GroupS = new GroupSDTO(),
                        },
                        Specjalize = x.Teacher.Specjalize
                    },
                    Subject = new SubjectDTO()
                    {
                        Id = x.Subject.Id,
                        Name = x.Subject.Name
                    },
                    TypLesson = x.TypLesson,
                    Time = x.Time
                })
            .ToList<LessonDTO>();
        }

        public LessonDTO GetLesson(Guid id)
        {
            return NHUnitOfWork.Session.Query<Lesson>()
                .Where(x => x.Id == id)
                .Select(x => new LessonDTO()
                {
                    Id = x.Id,
                    GroupS = new GroupSDTO()
                    {
                        Id = x.GroupS.Id,
                        Year = x.GroupS.Year,
                        Semester = x.GroupS.Semester,
                        Direction = x.GroupS.Direction,
                        Specjalize = x.GroupS.Specjalize
                    },
                    Teacher = new TeacherDTO()
                    {
                        Id = x.Teacher.Id,
                        user = new UserDTO()
                        {
                            Id = x.Teacher.Users.Id,
                            Login = x.Teacher.Users.Login,
                            ImieNazwisko = x.Teacher.Users.ImieNazwisko,
                            CzyAktywny = x.Teacher.Users.CzyAktywny,
                            Password = x.Teacher.Users.Password,
                            Email = x.Teacher.Users.Email,
                            Rola = new RolaDTO()
                            {
                                Id = x.Teacher.Users.Rola.Id,
                                Nazwa = x.Teacher.Users.Rola.Nazwa
                            },
                            School = new SchoolDTO()
                            {
                                Id = x.Teacher.Users.School.Id,
                                Name = x.Teacher.Users.School.Name,
                                Logo = x.Teacher.Users.School.Logo
                            },
                            NrIndex = x.Teacher.Users.NrIndex,
                            Image = x.Teacher.Users.Image,
                            GroupS = new GroupSDTO(),
                        },
                        Specjalize = x.Teacher.Specjalize
                    },
                    Subject = new SubjectDTO()
                    {
                        Id = x.Subject.Id,
                        Name = x.Subject.Name
                    },
                    TypLesson = x.TypLesson,
                    Time = x.Time
                })
            .FirstOrDefault();
        }

        public IList<LessonDTO> GetLessonsFromGroup(Guid id)
        {
            return NHUnitOfWork.Session.Query<Lesson>()
                .Where(x => x.GroupS.Id==id)
                .Select(x => new LessonDTO()
                {
                    Id = x.Id,
                    GroupS = new GroupSDTO()
                    {
                        Id = x.GroupS.Id,
                        Year = x.GroupS.Year,
                        Semester = x.GroupS.Semester,
                        Direction = x.GroupS.Direction,
                        Specjalize = x.GroupS.Specjalize
                    },
                    Teacher = new TeacherDTO()
                    {
                        Id = x.Teacher.Id,
                        user = new UserDTO()
                        {
                            Id = x.Teacher.Users.Id,
                            Login = x.Teacher.Users.Login,
                            ImieNazwisko = x.Teacher.Users.ImieNazwisko,
                            CzyAktywny = x.Teacher.Users.CzyAktywny,
                            Password = x.Teacher.Users.Password,
                            Email = x.Teacher.Users.Email,
                            Rola = new RolaDTO()
                            {
                                Id = x.Teacher.Users.Rola.Id,
                                Nazwa = x.Teacher.Users.Rola.Nazwa
                            },
                            School = new SchoolDTO()
                            {
                                Id = x.Teacher.Users.School.Id,
                                Name = x.Teacher.Users.School.Name,
                                Logo = x.Teacher.Users.School.Logo
                            },
                            NrIndex = x.Teacher.Users.NrIndex,
                            Image = x.Teacher.Users.Image,
                            GroupS = new GroupSDTO(),
                        },
                        Specjalize = x.Teacher.Specjalize
                    },
                    Subject = new SubjectDTO()
                    {
                        Id = x.Subject.Id,
                        Name = x.Subject.Name
                    },
                    TypLesson = x.TypLesson,
                    Time = x.Time
                })
            .ToList<LessonDTO>();
        }

        public IList<LessonTypDTO> GetSubject(Guid id)
        {
            return NHUnitOfWork.Session.Query<Lesson>()
                .Where(x => x.Subject.Id == id)
                .OrderBy(x=>x.TypLesson)
                .Select(x => new LessonTypDTO()
                {
                    Id = x.Id,
                    GroupS = new GroupSDTO()
                    {
                        Id = x.GroupS.Id,
                        Year = x.GroupS.Year,
                        Semester = x.GroupS.Semester,
                        Direction = x.GroupS.Direction,
                        Specjalize = x.GroupS.Specjalize
                    },
                    Teacher = new TeacherDTO()
                    {
                        Id = x.Teacher.Id,
                        user = new UserDTO()
                        {
                            Id = x.Teacher.Users.Id,
                            Login = x.Teacher.Users.Login,
                            ImieNazwisko = x.Teacher.Users.ImieNazwisko,
                            CzyAktywny = x.Teacher.Users.CzyAktywny,
                            Password = x.Teacher.Users.Password,
                            Email = x.Teacher.Users.Email,
                            Rola = new RolaDTO()
                            {
                                Id = x.Teacher.Users.Rola.Id,
                                Nazwa = x.Teacher.Users.Rola.Nazwa
                            },
                            School = new SchoolDTO()
                            {
                                Id = x.Teacher.Users.School.Id,
                                Name = x.Teacher.Users.School.Name,
                                Logo = x.Teacher.Users.School.Logo
                            },
                            NrIndex = x.Teacher.Users.NrIndex,
                            Image = x.Teacher.Users.Image,
                            GroupS = new GroupSDTO(),
                        },
                        Specjalize = x.Teacher.Specjalize
                    },
                    Subject = new SubjectDTO()
                    {
                        Id = x.Subject.Id,
                        Name = x.Subject.Name
                    },
                    TypLesson = GetTypeName(x.TypLesson),
                    Time = x.Time
                })
            .ToList<LessonTypDTO>();
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
    }
}
