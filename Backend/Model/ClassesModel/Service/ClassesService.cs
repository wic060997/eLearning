using Infrastructure;
using Model.ClassesModel.DTO;
using Model.ClassesModel.Entity;
using Model.ClassesModel.IService;
using Model.ClassesModel.Repository;
using Model.LessonModel.Entity;
using Model.LessonModel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ClassesModel.Service
{
    public class ClassesService : ApplicationService, IClassesService
    {
        private readonly IClassesRepository repository;
        private readonly ILessonRepository lessonRepository;

        public ClassesService(
            IUnitOfWork unitOfWork,
            IClassesRepository repository,
            ILessonRepository lessonRepository
            ) : base(unitOfWork)
        {
            this.repository = repository;
            this.lessonRepository = lessonRepository;
        }

        public void AddClasses(NewClassesDTO dto)
        {
            Lesson lesson = lessonRepository.Get(dto.LessonId);
            Classes classes = new Classes(Guid.NewGuid(), lesson, dto.Theme, dto.DataClasses, new AuditData("system", DateTime.Now));
            repository.Add(classes);
        }

        public Classes Get(Guid id)
        {
            return repository.Get(id);
        }

        public IList<Classes> GetAll()
        {
            return repository.GetAll();
        }

        public IList<ClassesDTO> GetAllDTO()
        {
            return repository.GetAllDTO();
        }

        public IList<ClassesDTO> GetFromLesson(Guid id)
        {
            return repository.GetFromLesson(id);
        }
    }
}
