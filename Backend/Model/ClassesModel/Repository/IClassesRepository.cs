using Infrastructure;
using Model.ClassesModel.DTO;
using Model.ClassesModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ClassesModel.Repository
{
    public interface IClassesRepository:ICrudRepository<Classes>
    {
        IList<Classes> GetAll();
        IList<ClassesDTO> GetAllDTO();
        IList<ClassesDTO> GetFromLesson(Guid id);
    }
}
