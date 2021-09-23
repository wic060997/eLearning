using Infrastructure;
using Model.HistoryDownloadingModel.DTO;
using Model.HistoryDownloadingModel.Entity;
using Model.HistoryDownloadingModel.IService;
using Model.HistoryDownloadingModel.Repository;
using Model.MaterialModel.DTO;
using Model.MaterialModel.Entity;
using Model.MaterialModel.Repository;
using Model.UserModel.DTO;
using Model.UserModel.Entity;
using Model.UserModel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.HistoryDownloadingModel.Service
{

    public class HistoryDownloadingService : ApplicationService, IHistoryDownloadingService
    {
        private readonly IHistoryDownloadingRepository repository;
        private readonly IMaterialRepository materialRepository;
        private readonly IUserRepository userRepository;

        public HistoryDownloadingService(
            IUnitOfWork unitOfWork,
            IHistoryDownloadingRepository repository,
            IMaterialRepository materialRepository,
            IUserRepository userRepository
            ) : base(unitOfWork)
        {
            this.repository = repository;
            this.materialRepository = materialRepository;
            this.userRepository = userRepository;
        }

        public void AddNewHistory(Guid userId, Guid materialId)
        {
            Material material = materialRepository.Get(materialId);
            Users users = userRepository.Get(userId);

            HistoryDownloading historyDownloading = new HistoryDownloading(Guid.NewGuid(), users, material, DateTime.Now, new AuditData("system", DateTime.Now));
            repository.Add(historyDownloading);
        }

        public IList<HistoryDownloading> GetAll()
        {
            return repository.GetAll();
        }

        public IList<HistoryDTO> GetAllDTO()
        {
            return repository.GetAllDTO();
        }

        public List<HistoryMaterialDTO> getHistoryMaterial(Guid id)
        {
            List<HistoryMaterialDTO> list = new List<HistoryMaterialDTO>();

            var historyDTO = repository.GetAllWithMaterial(id);

            if(historyDTO != null)
            {
                foreach(var his in historyDTO)
                {
                    HistoryMaterialDTO dto = new HistoryMaterialDTO();

                    dto.Id = his.Id;
                    dto.DataDownloading = his.DataDownloading.ToString("dd - MM - yyyy");
                    dto.material = new MaterialFileDTO()
                    {
                        Id = his.Material.Id,
                        DataActive = his.Material.DataActive,
                        Localization = his.Material.Localization,
                        Name = his.Material.Name,
                        IsActive = his.Material.IsActive
                    };

                    dto.user = new UserStudentDTO()
                    {
                        Id = his.User.Id,
                        ImieNazwisko = his.User.ImieNazwisko,
                        Email = his.User.Email,
                        Login = his.User.Login,
                        NrIndex = his.User.NrIndex
                    };

                    list.Add(dto);
                }
            }

            return list;
        }
    }
}
