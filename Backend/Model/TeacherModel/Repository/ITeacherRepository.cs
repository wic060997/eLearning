using Infrastructure;
using Model.TeacherModel.DTO;
using Model.TeacherModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.TeacherModel.Repository
{
    public interface ITeacherRepository : ICrudRepository<Teacher>
    {
        IList<Teacher> GetAll();
        IList<TeacherDTO> GetAllDTO();
        TeacherDTO GetTeacher(Guid id);
        TeacherDTO GetTeacherFromUser(Guid id);
        IList<TeacherDTO> GetTeachersFromSchool(Guid id);
    }
}
