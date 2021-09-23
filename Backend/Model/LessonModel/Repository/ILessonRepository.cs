using Infrastructure;
using Model.LessonModel.DTO;
using Model.LessonModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.LessonModel.Repository
{

    public interface ILessonRepository : ICrudRepository<Lesson>
    {
        IList<Lesson> GetAll();
        IList<LessonDTO> GetAllDTO();
        IList<LessonDTO> GetAllLessonTeacher(Guid id);
        IList<LessonTypDTO> GetAllLessonSubject(Guid id);
        IList<LessonTypDTO> GetSubject(Guid id);
        LessonDTO GetLesson(Guid id);
        IList<LessonDTO> GetLessonsFromGroup(Guid id);
    }
}
