using Infrastructure;
using Model.ManagementModel.DTO;
using Model.ManagementModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ManagementModel.IService
{
    public interface IManagementService : IApplicationService
    {
        IList<Management> GetAll();
        IList<ManagementDTO> GetAllDTO();
    }
}
