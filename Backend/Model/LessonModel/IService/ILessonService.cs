using Infrastructure;
using Model.LessonModel.DTO;
using Model.LessonModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.LessonModel.IService
{
     public interface ILessonService : IApplicationService
    {
        IList<Lesson> GetAll();
        IList<LessonDTO> GetAllDTO();
        IList<LessonDTO> GetAllLessonTeacher(Guid id);
        void NewLesson(NewLessonDTO dto);
        IList<LessonTypDTO> GetSubject(Guid id);
        LessonDTO GetLesson(Guid id);
        IList<LessonDTO> GetLessonsFromGroup(Guid id);
        AllLesson GetFilesLesson(Guid id);
        LessonFileDTO GetLessonFiles(Guid id);
    }
}
