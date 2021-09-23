using Infrastructure;
using Model.ClassesModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.MaterialModel.Entity
{
   public  class Material: AuditableEntity
    {
        public Material() : base() { }

        public Material(Guid id,
            Classes classes,
            string localization,
            string name,
            bool isActive,
            string dataActive,
            AuditData auditData)
            : base(id, auditData)
        {
            this.Classes = classes;
            this.Localization = localization;
            this.Name = name;
            this.IsActive = isActive;
            this.DataActive = dataActive;            
            this.AuditData = auditData;
        }

        public virtual Classes Classes { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string DataActive { get; set; }
        public virtual string Localization { get; set; }
        public virtual string Name { get; set; }
    }
}
