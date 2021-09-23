using Infrastructure;
using Model.GroupSModel.DTO;
using Model.GroupSModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.GroupSModel.Repository
{
    public interface IGroupSRepository : ICrudRepository<GroupS>
    {
        IList<GroupS> GetAll();
        IList<GroupSDTO> GetAllDTO();
        IList<GroupSDTO> GetAllDTOFromSchool(Guid id);
    }
}
