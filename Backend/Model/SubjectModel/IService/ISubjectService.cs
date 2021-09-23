using Infrastructure;
using Model.SubjectModel.DTO;
using Model.SubjectModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.SubjectModel.IService
{
    public interface ISubjectService : IApplicationService
    {
        IList<Subject> GetAll();
        IList<SubjectDTO> GetAllDTO();
        Guid NewSubject(NewSubjectDTO dto);
        List<SubjectDTO> GetAllToSchool(Guid id);
        SubjectInfoDTO GetInfoSubject(Guid id);
    }
}
