using Infrastructure;
using Model.ManagementModel.DTO;
using Model.ManagementModel.Entity;
using Model.ManagementModel.IService;
using Model.ManagementModel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ManagementModel.Service
{
    public class ManagementService : ApplicationService, IManagementService
    {
        private readonly IManagementRepository repository;
        public ManagementService(IUnitOfWork unitOfWork,
            IManagementRepository repository) : base(unitOfWork)
        {
            this.repository = repository;
        }
        public IList<Management> GetAll()
        {
            return repository.GetAll();
        }

        public IList<ManagementDTO> GetAllDTO()
        {
            return repository.GetAllDTO();
        }
    }
}
