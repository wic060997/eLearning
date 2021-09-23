using Infrastructure;
using Model.GroupSModel.DTO;
using Model.GroupSModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.GroupSModel.IService
{
    public interface IGroupSReoisitory : IApplicationService
    {
        IList<GroupS> GetAll();
        IList<GroupSDTO> GetAllDTO();
        void AddGroup(NewGroupDTO dto);
        IList<GroupSDTO> GetAllDTOFromSchool(Guid id);
    }
}
