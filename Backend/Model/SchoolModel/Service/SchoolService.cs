using Infrastructure;
using Model.SchoolModel.DTO;
using Model.SchoolModel.Entity;
using Model.SchoolModel.IService;
using Model.SchoolModel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.SchoolModel.Service
{
    public class SchoolService : ApplicationService, ISchoolService
    {
        private readonly ISchoolRepository repository;
        public SchoolService(IUnitOfWork unitOfWork,
            ISchoolRepository repository) : base(unitOfWork)
        {
            this.repository = repository;
        }
        public IList<School> GetAll()
        {
            return repository.GetAll();
        }

        public IList<SchoolDTO> GetAllDTO()
        {
            return repository.GetAllDTO();
        }

        public School GetSchool(Guid id)
        {
            return repository.GetSchool(id);
        }

        public Guid NewSchool(NewSchoolDTO dto)
        {
            School school = new School(
                 Guid.NewGuid(),
                dto.Name,
                null,
                new AuditData("system", DateTime.Now)
            );

            school.Validate();
            Guid id = repository.Add(school);
            return id;
        }
    }
}
