using Model.MaterialModel.DTO;
using Model.UserModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.HistoryDownloadingModel.DTO
{
    public class HistoryMaterialDTO
    {
        public Guid Id { get; set; }
        public string DataDownloading { get; set; }
        public MaterialFileDTO material { get; set; }
        public UserStudentDTO user { get; set; }
    }
}
