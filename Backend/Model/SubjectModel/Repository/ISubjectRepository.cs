using Infrastructure;
using Model.SubjectModel.DTO;
using Model.SubjectModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.SubjectModel.Repository
{
    public interface ISubjectRepository : ICrudRepository<Subject>
    {
        IList<Subject> GetAll();
        IList<SubjectDTO> GetAllDTO();
        SubjectDTO GetDTO(Guid id);
    }
}
