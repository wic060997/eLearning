using Infrastructure;
using Model.HistoryDownloadingModel.Repository;
using Model.MaterialModel.DTO;
using Model.MaterialModel.Entity;
using Model.MaterialModel.IService;
using Model.MaterialModel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.MaterialModel.Service
{
    public class MaterialService : ApplicationService, IMaterialService
    {
        private readonly IMaterialRepository repository;
        private readonly IHistoryDownloadingRepository historyDownloading;

        public MaterialService(
            IUnitOfWork unitOfWork,
            IMaterialRepository repository,
            IHistoryDownloadingRepository historyDownloading
            ) : base(unitOfWork)
        {
            this.repository = repository;
            this.historyDownloading = historyDownloading;
        }

        public void ActiveMaterials()
        {
            IList<Material> materials = repository.GetAllNieaktywne();
            DateTime now = DateTime.Now;
            foreach(var mat in materials)
            {
                DateTime dat = Convert.ToDateTime(mat.DataActive);
                if (dat < now)
                {
                    mat.IsActive = true;
                    repository.Update(mat);
                }
            }
        }

        public void AddNew(Material material)
        {
            repository.Add(material);
        }

        public void Delete(Guid id)
        {
            var downloading = historyDownloading.GetAllWithMaterial(id);
            if(downloading != null)
            {
                foreach(var dow in downloading)
                {
                    historyDownloading.Delete(dow.Id);
                }
            }

            repository.Delete(id);

        }

        public MaterialDTO Get(Guid id)
        {
            return repository.GetDTO(id);
        }

        public IList<Material> GetAll()
        {
            return repository.GetAll();
        }

        public IList<MaterialDTO> GetAllDTO()
        {
            return repository.GetAllDTO();
        }

        public IList<MaterialDTO> GetAllFromClasses(Guid id)
        {
            return repository.GetAllFromClasses(id);
        }

        public IList<MaterialDTO> GetFromSchool(Guid id)
        {
            return repository.GetFromSchool(id);
        }

        public IList<MaterialInfoDTO> GetInfoMaterialFromClasses(Guid id)
        {
            return repository.GetInfoMaterialFromClasses(id);
        }

        public Material getTest()
        {
            return repository.Get(new Guid("86B00467-61DE-4DC3-8BCF-0070AA0C406D"));
        }
    }
}
