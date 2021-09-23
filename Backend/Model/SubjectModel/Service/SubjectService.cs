using Infrastructure;
using Model.GroupSModel.DTO;
using Model.LessonModel.DTO;
using Model.LessonModel.Repository;
using Model.SchoolModel.Entity;
using Model.SchoolModel.Repository;
using Model.SubjectModel.DTO;
using Model.SubjectModel.Entity;
using Model.SubjectModel.IService;
using Model.SubjectModel.Repository;
using Model.TeacherModel.DTO;
using Model.TeacherModel.IService;
using Model.UserModel.DTO;
using Model.UserModel.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.SubjectModel.Service
{
    public class SubjectService : ApplicationService, ISubjectService
    {
        private readonly ISubjectRepository repository;
        private readonly ISchoolRepository schoolRepositry;
        private readonly ILessonRepository lessonRepository;
        private readonly ITeacherService teacherService;
        private readonly IUserService userService;

        public SubjectService(IUnitOfWork unitOfWork,
            ISubjectRepository repository,
            ISchoolRepository schoolRepository,
            ILessonRepository lessonRepository,
            ITeacherService teacherService,
            IUserService userService
            ) : base(unitOfWork)
        {
            this.repository = repository;
            this.schoolRepositry = schoolRepository;
            this.lessonRepository = lessonRepository;
            this.teacherService = teacherService;
            this.userService = userService;
        }
        public IList<Subject> GetAll()
        {
            return repository.GetAll();
        }

        public IList<SubjectDTO> GetAllDTO()
        {
            return repository.GetAllDTO();
        }

        public List<SubjectDTO> GetAllToSchool(Guid id)
        {
            IList<SubjectDTO> list = repository.GetAllDTO();
            return list.Where(x => x.School.Id == id).ToList();
        }

        public SubjectInfoDTO GetInfoSubject(Guid id)
        {
            SubjectInfoDTO dto = new SubjectInfoDTO();

            SubjectDTO subject = repository.GetDTO(id);
            IList<LessonTypDTO> lessons = lessonRepository.GetAllLessonSubject(id);

            dto.Id = subject.Id;
            dto.Name = subject.Name;
            dto.School = subject.School;
            foreach (var less in lessons)
            {
                if (dto.Typs.Exists(t => t.Name == less.TypLesson) == false)
                {
                    TypeLessonDTO type = new TypeLessonDTO();
                    type.Name = less.TypLesson;

                    LessonInfoDTO newLesson = new LessonInfoDTO();
                    newLesson.id = less.Id;
                    newLesson.Time = less.Time;

                    TeacherDTO teacher = teacherService.GetTeacher(less.Teacher.Id);
                    TeacherInfoDTO teacherInfo = new TeacherInfoDTO();
                    teacherInfo.Id = teacher.Id;
                    teacherInfo.Specjalize = teacher.Specjalize;
                    teacherInfo.user = new UserTeacherDTO()
                    {
                        Id = teacher.user.Id,
                        Login = teacher.user.Login,
                        ImieNazwisko = teacher.user.ImieNazwisko,
                        Email = teacher.user.Email
                    };
                    newLesson.Teacher = teacherInfo;

                    GroupStaticDTO newGroup = new GroupStaticDTO();
                    newGroup.Id = less.GroupS.Id;
                    newGroup.Direction = less.GroupS.Direction;
                    newGroup.Semester = less.GroupS.Semester;
                    newGroup.Specjalize = less.GroupS.Specjalize;
                    newGroup.Year = less.GroupS.Year;
                    newGroup.UserStudent = userService.GetStudentsFromGroup(less.GroupS.Id);

                    newLesson.GroupStatic=newGroup;
                    type.LessonInfo.Add(newLesson);
                    dto.Typs.Add(type);
                }
                else
                {
                    TypeLessonDTO type = dto.Typs.Where(x => x.Name == less.TypLesson).FirstOrDefault();
                    dto.Typs.Remove(type);

                    if (type.LessonInfo.Exists(x => x.id == less.Id) == false)
                    {
                        LessonInfoDTO newLesson = new LessonInfoDTO();
                        newLesson.id = less.Id;
                        newLesson.Time = less.Time;

                        TeacherDTO teacher = teacherService.GetTeacher(less.Teacher.Id);
                        TeacherInfoDTO teacherInfo = new TeacherInfoDTO();
                        teacherInfo.Id = teacher.Id;
                        teacherInfo.Specjalize = teacher.Specjalize;
                        teacherInfo.user = new UserTeacherDTO()
                        {
                            Id = teacher.user.Id,
                            Login = teacher.user.Login,
                            ImieNazwisko = teacher.user.ImieNazwisko,
                            Email = teacher.user.Email
                        };
                        newLesson.Teacher = teacherInfo;

                        GroupStaticDTO newGroup = new GroupStaticDTO();
                        newGroup.Id = less.GroupS.Id;
                        newGroup.Direction = less.GroupS.Direction;
                        newGroup.Semester = less.GroupS.Semester;
                        newGroup.Specjalize = less.GroupS.Specjalize;
                        newGroup.Year = less.GroupS.Year;
                        newGroup.UserStudent = userService.GetStudentsFromGroup(less.GroupS.Id);

                        newLesson.GroupStatic=newGroup;
                        type.LessonInfo.Add(newLesson);
                    }
                    dto.Typs.Add(type);
                }
            }


            return dto;
        }

        public Guid NewSubject(NewSubjectDTO dto)
        {
            School school = schoolRepositry.Get(dto.School);
            Subject subject = new Subject(Guid.NewGuid(), dto.Name, school, new AuditData("system", DateTime.Now));

            return repository.Add(subject);
        }

    }
}
