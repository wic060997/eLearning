using Infrastructure;
using Model.ClassesModel.DTO;
using Model.ClassesModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ClassesModel.IService
{
    public interface IClassesService: IApplicationService
    {
        IList<Classes> GetAll();
        IList<ClassesDTO> GetAllDTO();
        void AddClasses(NewClassesDTO dto);
        IList<ClassesDTO> GetFromLesson(Guid id);
        Classes Get(Guid id);
    }
}
