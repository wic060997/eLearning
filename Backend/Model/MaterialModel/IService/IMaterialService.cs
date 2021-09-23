using Infrastructure;
using Model.MaterialModel.DTO;
using Model.MaterialModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.MaterialModel.IService
{
    public interface IMaterialService : IApplicationService
    {
        IList<Material> GetAll();
        IList<MaterialDTO> GetAllDTO();
        void AddNew(Material material);
        IList<MaterialDTO> GetAllFromClasses(Guid id);
        MaterialDTO Get(Guid id);
        IList<MaterialInfoDTO> GetInfoMaterialFromClasses(Guid id);
        Material getTest();
        void Delete(Guid id);
        IList<MaterialDTO> GetFromSchool(Guid id);
        void ActiveMaterials();
    }
}
