using Infrastructure;
using Seterlund.CodeGuard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.InfrastructureRepository
{
    public abstract class NHRepository : IRepository
    {
        protected readonly NHUnitOfWork unitOfWork;
        public NHUnitOfWork NHUnitOfWork { get { return unitOfWork; } }

        public NHRepository(IUnitOfWork unitOfWork)
        {
            Guard.That(unitOfWork).IsNotNull();

            this.unitOfWork = unitOfWork as NHUnitOfWork;
            Guard.That(this.unitOfWork).IsNotNull();
        }

        public TEntity CreateProxy<TEntity>(Guid id) where TEntity : Entity
        {
            Guard.That(id).IsNotEmpty();

            return this.NHUnitOfWork.Session.Load<TEntity>(id);
        }
    }
}
