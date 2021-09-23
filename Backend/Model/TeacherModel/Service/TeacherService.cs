using Infrastructure;
using Model.GroupSModel.DTO;
using Model.LessonModel.DTO;
using Model.LessonModel.Repository;
using Model.SubjectModel.DTO;
using Model.TeacherModel.DTO;
using Model.TeacherModel.Entity;
using Model.TeacherModel.IService;
using Model.TeacherModel.Repository;
using Model.UserModel.Entity;
using Model.UserModel.IService;
using Model.UserModel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.TeacherModel.Service
{
    public class TeacherService : ApplicationService, ITeacherService
    {
        private readonly ITeacherRepository repository;
        private readonly IUserRepository userRepository;
        private readonly IRolaRepository rolaRepository;
        private readonly ILessonRepository lessonRepository;
        private IUserService _userService;

        public TeacherService(
            IUnitOfWork unitOfWork,
            ITeacherRepository repository,
            IUserRepository userRepository,
            IRolaRepository rolaRepository,
            IUserService userService,
            ILessonRepository lessonRepository
            ) : base(unitOfWork)
        {
            this.repository = repository;
            this.userRepository = userRepository;
            this.rolaRepository = rolaRepository;
            this.lessonRepository = lessonRepository;
            _userService = userService;
        }
        public IList<Teacher> GetAll()
        {
            return repository.GetAll();
        }

        public IList<TeacherDTO> GetAllDTO()
        {
            return repository.GetAllDTO();
        }

        public TeacherDTO GetTeacher(Guid id)
        {
            return repository.GetTeacher(id);
        }

        public void NewTeacher(NewTeacherDTO dto)
        {
            Users users = userRepository.Get(dto.IdUser);
            Rola r = rolaRepository.Get(Guid.Parse("BC01F1AC-2389-4CFD-9D68-CA28FCB72C2F"));

            users.Rola = r;
            userRepository.Update(users);

            AddTeacher(dto);


        }

        public void AddTeacher(NewTeacherDTO dto)
        {
            Users usera = userRepository.Get(dto.IdUser);
            Teacher teacher = new Teacher(
                Guid.NewGuid(),
                usera,
                dto.specjalize,
                new AuditData("system", DateTime.Now)
                );

            repository.Add(teacher);
        }

        public TeacherDTO GetTeacherFromUser(Guid id)
        {
            return repository.GetTeacherFromUser(id);
        }

        public IList<TeacherDTO> GetTeachersFromSchool(Guid id)
        {
            return repository.GetTeachersFromSchool(id);
        }

        public TeacherInformationDTO GetTeacherInformation(Guid id)
        {
            TeacherDTO teacher = repository.GetTeacherFromUser(id);
            IList<LessonDTO> lessons = lessonRepository.GetAllLessonTeacher(teacher.Id);
            TeacherInformationDTO dto = new TeacherInformationDTO();
            
            dto.Id = teacher.Id;
            dto.Specjalize = teacher.Specjalize;
            dto.User = teacher.user;
            dto.subject = new List<SubjectStaticDTO>();

            foreach(LessonDTO lesson in lessons)
            {
                if (dto.subject == null)
                {
                    SubjectStaticDTO subject = new SubjectStaticDTO();
                    subject.Id = lesson.Subject.Id;
                    subject.Name = lesson.Subject.Name;
                    subject.types = new List<TypeLessonStaticDTO>();

                    TypeLessonStaticDTO type = new TypeLessonStaticDTO();
                    type.Name = GetTypeName(lesson.TypLesson);
                    type.LessonStatic = new List<LessonStaticDTO>();

                    LessonStaticDTO les = new LessonStaticDTO();
                    les.Id = lesson.Id;
                    les.Time = lesson.Time;
                    les.GroupStatic = new GroupStaticDTO();
                    les.GroupStatic.Id = lesson.GroupS.Id;
                    les.GroupStatic.Direction = lesson.GroupS.Direction;
                    les.GroupStatic.Specjalize = lesson.GroupS.Specjalize;
                    les.GroupStatic.Year = lesson.GroupS.Year;
                    les.GroupStatic.Semester = lesson.GroupS.Semester;
                    les.GroupStatic.UserStudent = _userService.GetStudentsFromGroup(lesson.GroupS.Id);


                    type.LessonStatic.Add(les);
                    subject.types.Add(type);
                    dto.subject.Add(subject);
                }
                else
                {
                    if (dto.subject.Exists(x => x.Id == lesson.Subject.Id) == false)
                    {
                        SubjectStaticDTO subject = new SubjectStaticDTO();
                        subject.Id = lesson.Subject.Id;
                        subject.Name = lesson.Subject.Name;
                        subject.types = new List<TypeLessonStaticDTO>();

                        TypeLessonStaticDTO type = new TypeLessonStaticDTO();
                        type.Name = GetTypeName(lesson.TypLesson);
                        type.LessonStatic = new List<LessonStaticDTO>();

                        LessonStaticDTO les = new LessonStaticDTO();
                        les.Id = lesson.Id;
                        les.Time = lesson.Time;
                        les.GroupStatic = new GroupStaticDTO();
                        les.GroupStatic.Id = lesson.GroupS.Id;
                        les.GroupStatic.Direction = lesson.GroupS.Direction;
                        les.GroupStatic.Specjalize = lesson.GroupS.Specjalize;
                        les.GroupStatic.Year = lesson.GroupS.Year;
                        les.GroupStatic.Semester = lesson.GroupS.Semester;
                        les.GroupStatic.UserStudent = _userService.GetStudentsFromGroup(lesson.GroupS.Id);

                        type.LessonStatic.Add(les);
                        subject.types.Add(type);
                        dto.subject.Add(subject);
                    }
                    else
                    {
                        SubjectStaticDTO subject = dto.subject.Where(x => x.Id == lesson.Subject.Id).FirstOrDefault();
                        dto.subject.Remove(subject);

                        if (subject.types.Exists(x => x.Name == GetTypeName(lesson.TypLesson)) == false)
                        {
                            TypeLessonStaticDTO type = new TypeLessonStaticDTO();
                            type.Name = GetTypeName(lesson.TypLesson);
                            type.LessonStatic = new List<LessonStaticDTO>();

                            LessonStaticDTO les = new LessonStaticDTO();
                            les.Id = lesson.Id;
                            les.Time = lesson.Time;
                            les.GroupStatic = new GroupStaticDTO();
                            les.GroupStatic.Id = lesson.GroupS.Id;
                            les.GroupStatic.Direction = lesson.GroupS.Direction;
                            les.GroupStatic.Specjalize = lesson.GroupS.Specjalize;
                            les.GroupStatic.Year = lesson.GroupS.Year;
                            les.GroupStatic.Semester = lesson.GroupS.Semester;
                            les.GroupStatic.UserStudent = _userService.GetStudentsFromGroup(lesson.GroupS.Id);

                            type.LessonStatic.Add(les);
                            subject.types.Add(type);
                        }
                        else
                        {
                            TypeLessonStaticDTO type = subject.types.Where(x => x.Name == GetTypeName(lesson.TypLesson)).FirstOrDefault();
                            subject.types.Remove(type);

                            if (type.LessonStatic.Exists(x => x.Id == lesson.Id) == false)
                            {
                                LessonStaticDTO les = new LessonStaticDTO();
                                les.Id = lesson.Id;
                                les.Time = lesson.Time;
                                les.GroupStatic = new GroupStaticDTO();
                                les.GroupStatic.Id = lesson.GroupS.Id;
                                les.GroupStatic.Direction = lesson.GroupS.Direction;
                                les.GroupStatic.Specjalize = lesson.GroupS.Specjalize;
                                les.GroupStatic.Year = lesson.GroupS.Year;
                                les.GroupStatic.Semester = lesson.GroupS.Semester;
                                les.GroupStatic.UserStudent = _userService.GetStudentsFromGroup(lesson.GroupS.Id);

                                type.LessonStatic.Add(les);
                            }

                            subject.types.Add(type);
                        }

                        dto.subject.Add(subject);
                    }
                }
            }

            return dto;
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
