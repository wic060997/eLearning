using Infrastructure;
using Model.GroupSModel.DTO;
using Model.GroupSModel.Entity;
using Model.GroupSModel.IService;
using Model.GroupSModel.Repository;
using Model.SchoolModel.Entity;
using Model.SchoolModel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.GroupSModel.Service
{

    public class GroupSService : ApplicationService, IGroupSReoisitory
    {
        private readonly IGroupSRepository repository;
        private readonly ISchoolRepository schoolRepository;
        public GroupSService(
            IUnitOfWork unitOfWork,
            IGroupSRepository repository,
            ISchoolRepository schoolRepository
            ) : base(unitOfWork)
        {
            this.repository = repository;
            this.schoolRepository = schoolRepository;
        }

        public void AddGroup(NewGroupDTO dto)
        {
            School school = schoolRepository.Get(dto.school);
            GroupS group = new GroupS(
                Guid.NewGuid(),
                dto.Year,
                dto.Semester,
                dto.Direction,
                dto.Specjalize,
                school,
                new AuditData("system", DateTime.Now)
                );
            repository.Add(group);
        }

        public IList<GroupS> GetAll()
        {
            return repository.GetAll();
        }

        public IList<GroupSDTO> GetAllDTO()
        {
            return repository.GetAllDTO();
        }

        public IList<GroupSDTO> GetAllDTOFromSchool(Guid id)
        {
            return repository.GetAllDTOFromSchool(id);
        }
    }
}
