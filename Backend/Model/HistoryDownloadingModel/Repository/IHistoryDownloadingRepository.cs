using Infrastructure;
using Model.HistoryDownloadingModel.DTO;
using Model.HistoryDownloadingModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.HistoryDownloadingModel.Repository
{
    public interface IHistoryDownloadingRepository : ICrudRepository<HistoryDownloading>
    {
        IList<HistoryDownloading> GetAll();
        IList<HistoryDTO> GetAllDTO();
        IList<HistoryDTO> GetAllWithMaterial(Guid id);
    }
}
