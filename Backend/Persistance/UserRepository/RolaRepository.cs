using Infrastructure;
using Model.UserModel.DTO;
using Model.UserModel.Entity;
using Model.UserModel.Repository;
using NHibernate.Criterion;
using Persistance.InfrastructureRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.UserRepository
{
    public class RolaRepository : NHCrudRepository<Rola>, IRolaRepository
    {
        public RolaRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public IList<Rola> GetAll()
        {
            return NHUnitOfWork.Session.Query<Rola>().ToList<Rola>();
        }

        public IList<RolaDTO> PobierzListe()
        {
            return NHUnitOfWork.Session.Query<Rola>()
                .Select(x => new RolaDTO()
                {
                    Id = x.Id,
                    Nazwa = x.Nazwa
                }).ToList<RolaDTO>();
        }

        public bool SprawdzCzyRolaIstnieje(string nazwa, Guid? Id = null)
        {
            var criteria = NHUnitOfWork.Session.CreateCriteria<Rola>();
            if (Id != null)
                criteria.Add(Restrictions.Not(Restrictions.Eq(nameof(Rola.Id), Id)));

            criteria.Add(Restrictions.Eq(nameof(Rola.Nazwa), nazwa))
                .SetMaxResults(1);
            return criteria.List().Count > 0;
        }
    }
}
