
using Model.MaterialModel.DTO;
using Model.UserModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.HistoryDownloadingModel.DTO
{
    public class HistoryDTO
    {
        public Guid Id { get; set; }
        public UserDTO User { get; set; }
        public MaterialDTO Material { get; set; }
        public DateTime DataDownloading { get; set; }
    }
}
