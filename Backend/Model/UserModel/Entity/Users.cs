using Infrastructure;
using Model.GroupSModel.Entity;
using Model.SchoolModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.UserModel.Entity
{
    public class Users : AuditableEntity
    {
        public Users() : base() { }

        public Users(Guid id,
            string login,
            string haslo,
            string imieNazwisko,
            bool czyAktywny,
            string email,
            Rola rola,
            AuditData auditData,
            GroupS group,
            School school,
            int index,
            string image)
            : base(id, auditData)
        {
            this.Login = login;
            this.Password = haslo;
            this.ImieNazwisko = imieNazwisko;
            this.CzyAktywny = czyAktywny;
            this.Email = email;
            this.Rola = rola;
            this.AuditData = auditData;
            this.Image = image;
            this.GroupS = group;
            this.School = school;
            this.NrIndex = index;
        }

        public Users(
            Guid id,
            string login,
            string haslo,
            string imieNazwisko,
            bool czyAktywny,
            string email,
            Rola rola,
            School school,
            AuditData auditData
            ) : base(id, auditData)
        {
            this.Login = login;
            this.Password = haslo;
            this.ImieNazwisko = imieNazwisko;
            this.CzyAktywny = czyAktywny;
            this.Email = email;
            this.Rola = rola;
            this.AuditData = auditData;
            this.School = school;
        }

        public virtual string Login { get; set; }
        public virtual string Password { get; set; }
        public virtual string ImieNazwisko { get; set; }
        public virtual bool CzyAktywny { get; set; }
        public virtual string Email { get; set; }
        public virtual Rola Rola { get; set; }
        public virtual string Image { get; set; }
        public virtual GroupS GroupS { get; set; }
        public virtual School School { get; set; }
        public virtual int NrIndex { get; set; }
    }
}
