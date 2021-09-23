using Infrastructure;
using Model.HistoryDownloadingModel.DTO;
using Model.HistoryDownloadingModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.HistoryDownloadingModel.IService
{
    public interface IHistoryDownloadingService : IApplicationService
    {
        IList<HistoryDownloading> GetAll();
        IList<HistoryDTO> GetAllDTO();
        void AddNewHistory(Guid userId,Guid materialId);
        List<HistoryMaterialDTO> getHistoryMaterial(Guid id);
    }
}
