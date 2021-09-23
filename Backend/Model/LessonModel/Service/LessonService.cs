using Infrastructure;
using Model.ClassesModel.DTO;
using Model.ClassesModel.Repository;
using Model.GroupSModel.Entity;
using Model.GroupSModel.IService;
using Model.GroupSModel.Repository;
using Model.LessonModel.DTO;
using Model.LessonModel.Entity;
using Model.LessonModel.IService;
using Model.LessonModel.Repository;
using Model.MaterialModel.Repository;
using Model.SubjectModel.DTO;
using Model.SubjectModel.Entity;
using Model.SubjectModel.Repository;
using Model.TeacherModel.DTO;
using Model.TeacherModel.Entity;
using Model.TeacherModel.IService;
using Model.TeacherModel.Repository;
using Model.UserModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.LessonModel.Service
{

    public class LessonService : ApplicationService, ILessonService
    {
        private readonly ILessonRepository repository;
        private readonly ISubjectRepository subjectRepository;
        private readonly IGroupSRepository groupSReoisitory;
        private readonly ITeacherRepository teacherRepository;
        private readonly IClassesRepository classesRepository;
        private readonly IMaterialRepository materialRepository;

        public LessonService(
            IUnitOfWork unitOfWork,
            ILessonRepository repository,
            ISubjectRepository subjectRepository,
            IGroupSRepository groupSReoisitory,
            ITeacherRepository teacherRepository,
            IClassesRepository classesRepository,
            IMaterialRepository materialRepository
            ) : base(unitOfWork)
        {
            this.repository = repository;
            this.subjectRepository = subjectRepository;
            this.groupSReoisitory = groupSReoisitory;
            this.teacherRepository = teacherRepository;
            this.classesRepository = classesRepository;
            this.materialRepository = materialRepository;
        }
        public IList<Lesson> GetAll()
        {
            return repository.GetAll();
        }

        public IList<LessonDTO> GetAllDTO()
        {
            return repository.GetAllDTO();
        }

        public IList<LessonDTO> GetAllLessonTeacher(Guid id)
        {
            return repository.GetAllLessonTeacher(id);
        }

        public AllLesson GetFilesLesson(Guid id)
        {
            throw new NotImplementedException();
        }

        public LessonDTO GetLesson(Guid id)
        {
            return repository.GetLesson(id);
        }

        public LessonFileDTO GetLessonFiles(Guid id)
        {
            Lesson lesson = repository.Get(id);
            TeacherDTO teacher = teacherRepository.GetTeacher(lesson.Teacher.Id);

            LessonFileDTO lessonFile = new LessonFileDTO();
            lessonFile.Id = lesson.Id;

            lessonFile.teacherInfo = new TeacherInfoDTO();
            lessonFile.teacherInfo.Id = teacher.Id;
            lessonFile.teacherInfo.Specjalize = teacher.Specjalize;
            lessonFile.teacherInfo.user = new UserTeacherDTO()
            {
                Id = teacher.user.Id,
                Login = teacher.user.Login,
                ImieNazwisko = teacher.user.ImieNazwisko,
                Email = teacher.user.Email
            };

            lessonFile.subjectStudent = new SubjectStudentDTO();
            lessonFile.subjectStudent.Id = lesson.Subject.Id;
            lessonFile.subjectStudent.Name = lesson.Subject.Name;

            lessonFile.typLesson = GetTypeName(lesson.TypLesson);
            lessonFile.time = lesson.Time;

            IList<ClassesDTO> classes = classesRepository.GetFromLesson(id);
            if (classes != null)
            {
                lessonFile.classes = new List<ClassesFileDTO>();

                foreach(var clas in classes)
                {
                    ClassesFileDTO dto = new ClassesFileDTO();
                    dto.Id = clas.Id;
                    dto.DataClasses = clas.DataClasses.ToString("dd - MM - yyyy");
                    dto.Theme = clas.Theme;
                    dto.materials = materialRepository.getMaterialClas(clas.Id);

                    lessonFile.classes.Add(dto);
                }
            }

            return lessonFile;
        }

        public IList<LessonDTO> GetLessonsFromGroup(Guid id)
        {
            return repository.GetLessonsFromGroup(id);
        }

        public IList<LessonDTO> GetSubject(Guid id)
        {
            throw new NotImplementedException();
        }

        public void NewLesson(NewLessonDTO dto)
        {
            Subject subject = subjectRepository.Get(dto.Subject);
            GroupS group = groupSReoisitory.Get(dto.Group);
            Teacher teacher = teacherRepository.Get(dto.Teacher);
            
            Lesson lesson = new Lesson(Guid.NewGuid(), group, teacher, subject, dto.Typ, dto.Time, new AuditData("system", DateTime.Now));
            repository.Add(lesson);
        }

        IList<LessonTypDTO> ILessonService.GetSubject(Guid id)
        {
            return repository.GetSubject(id);
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
