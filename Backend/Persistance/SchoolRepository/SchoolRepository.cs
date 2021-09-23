using Infrastructure;
using Model.SchoolModel.DTO;
using Model.SchoolModel.Entity;
using Model.SchoolModel.Repository;
using Persistance.InfrastructureRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.SchoolRepository
{
    public class SchoolRepository : NHCrudRepository<School>, ISchoolRepository
    {
        public SchoolRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public IList<School> GetAll()
        {
            return NHUnitOfWork.Session.Query<School>().ToList();
        }

        public IList<SchoolDTO> GetAllDTO()
        {
            return NHUnitOfWork.Session.Query<School>()
                .Select(x => new SchoolDTO()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Logo = x.Logo
                })
            .ToList<SchoolDTO>();
        }

        public School GetSchool(Guid id)
        {
            return NHUnitOfWork.Session.Query<School>()
                .Where(x => x.Id == id)
                .Select(x => new School(x.Id, x.Name, new AuditData("system", DateTime.Now)))
                .FirstOrDefault();
        }
    }
}
