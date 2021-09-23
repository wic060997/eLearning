using Infrastructure;
using Model.SchoolModel.DTO;
using Model.SchoolModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.SchoolModel.Repository
{
    public interface ISchoolRepository : ICrudRepository<School>
    {
        IList<School> GetAll();
        IList<SchoolDTO> GetAllDTO();
        School GetSchool(Guid id);
    }
}
