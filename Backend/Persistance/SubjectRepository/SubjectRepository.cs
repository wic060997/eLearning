using Infrastructure;
using Model.SchoolModel.DTO;
using Model.SchoolModel.Entity;
using Model.SubjectModel.DTO;
using Model.SubjectModel.Entity;
using Model.SubjectModel.Repository;
using Persistance.InfrastructureRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.SubjectRepository
{
    public class SubjectRepository : NHCrudRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public IList<Subject> GetAll()
        {
            return NHUnitOfWork.Session.Query<Subject>().ToList<Subject>();
        }

        public IList<SubjectDTO> GetAllDTO()
        {
            return NHUnitOfWork.Session.Query<Subject>()
                .Select(x => new SubjectDTO()
                {
                    Id = x.Id,
                    Name = x.Name,
                    School = new SchoolDTO()
                    {
                        Id=x.School.Id,
                        Name=x.School.Name,
                        Logo=x.School.Logo
                    }
                })
            .ToList<SubjectDTO>();
        }

        public SubjectDTO GetDTO(Guid id)
        {
            return NHUnitOfWork.Session.Query<Subject>()
                .Where(x => x.School.Id == id)
                .Select(x => new SubjectDTO()
                {
                    Id = x.Id,
                    Name = x.Name,
                    School = new SchoolDTO()
                    {
                        Id = x.School.Id,
                        Name = x.School.Name,
                        Logo = x.School.Logo
                    }
                }).FirstOrDefault();
        }
    }
}
