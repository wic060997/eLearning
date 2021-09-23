using Infrastructure;
using Model.MaterialModel.DTO;
using Model.MaterialModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.MaterialModel.Repository
{
    public interface IMaterialRepository : ICrudRepository<Material>
    {
        IList<Material> GetAll();
        IList<MaterialDTO> GetAllDTO();
        IList<MaterialDTO> GetAllFromClasses(Guid id);
        MaterialDTO GetDTO(Guid id);
        IList<MaterialInfoDTO> GetInfoMaterialFromClasses(Guid id);
        IList<Material> GetAllFileGroup(Guid id);
        IList<MaterialDTO> GetFromSchool(Guid id);
        List<MaterialFileDTO> getMaterialClas(Guid id);
        IList<Material> GetAllNieaktywne();
    }
}
