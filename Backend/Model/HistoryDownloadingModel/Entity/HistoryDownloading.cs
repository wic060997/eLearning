using Infrastructure;
using Model.MaterialModel.Entity;
using Model.UserModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.HistoryDownloadingModel.Entity
{
    public class HistoryDownloading : AuditableEntity
    {
        public HistoryDownloading() : base() { }

        public HistoryDownloading(Guid id,
            Users users,
            Material material,
            DateTime data,
            AuditData auditData)
            : base(id, auditData)
        {
            this.Users = users;
            this.Material = material;
            this.DataDownloading = data;
            this.AuditData = auditData;
        }

        public virtual Users Users { get; set; }
        public virtual Material Material { get; set; }
        public virtual DateTime DataDownloading { get; set; }
    }
}
