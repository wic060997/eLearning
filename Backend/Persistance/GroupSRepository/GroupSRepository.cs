using Infrastructure;
using Model.GroupSModel.DTO;
using Model.GroupSModel.Entity;
using Model.GroupSModel.Repository;
using Persistance.InfrastructureRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.GroupSRepository
{
    public class GroupSRepository : NHCrudRepository<GroupS>, IGroupSRepository
    {
        public GroupSRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public IList<GroupS> GetAll()
        {
            return NHUnitOfWork.Session.Query<GroupS>().ToList<GroupS>();
        }

        public IList<GroupSDTO> GetAllDTO()
        {
            return NHUnitOfWork.Session.Query<GroupS>()
                .Select(x => new GroupSDTO()
                {
                    Id = x.Id,
                    Year = x.Year,
                    Semester = x.Semester,
                    Direction = x.Direction,
                    Specjalize=x.Specjalize
                })
            .ToList<GroupSDTO>();
        }

        public IList<GroupSDTO> GetAllDTOFromSchool(Guid id)
        {
            return NHUnitOfWork.Session.Query<GroupS>()
                .Where(x=>x.School.Id==id)
                .Select(x => new GroupSDTO()
                {
                    Id = x.Id,
                    Year = x.Year,
                    Semester = x.Semester,
                    Direction = x.Direction,
                    Specjalize = x.Specjalize
                })
            .ToList<GroupSDTO>();
        }
    }
}
