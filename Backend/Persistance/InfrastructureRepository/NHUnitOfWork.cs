using Infrastructure;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seterlund.CodeGuard;
using System.Data;

using NH = NHibernate;

namespace Persistance.InfrastructureRepository
{
    public class NHUnitOfWork : IUnitOfWork, IDisposable
    {
        protected readonly ISession session;
        protected ITransaction transaction;

        public ISession Session
        {
            get { return this.session; }
        }

        public NHUnitOfWork(ISession session)
        {
            Guard.That(session).IsNotNull();

            this.session = session;
        }

        public virtual void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            if (this.transaction == null || !transaction.IsActive)
            {
                this.transaction = this.session.BeginTransaction(isolationLevel);
            }
        }

        public virtual void Commit()
        {
            try
            {
                if (this.transaction != null && this.transaction.IsActive)
                    this.transaction.Commit();
            }
            catch (Exception ex)
            {
                this.transaction.Rollback();
                throw ex;
            }
        }

        public virtual void Rollback()
        {
            if (this.transaction != null && this.transaction.IsActive)
            {
                this.session.Flush();
                this.transaction.Rollback();
            }
        }

        public void SetFlushMode(NHibernate.FlushMode mode)
        {
            this.session.FlushMode = (NH.FlushMode)mode;
        }

        public bool IsInTransaction()
        {
            return this.session.GetCurrentTransaction() != null && this.session.GetCurrentTransaction().IsActive;
        }

        public void Flush()
        {
            this.session.Flush();
        }

        public void SetReadOnly(object entity, bool isReadOnly)
        {
            this.session.SetReadOnly(entity, isReadOnly);
        }

        public void Dispose()
        {
            if (this.transaction != null)
            {
                this.transaction.Dispose();
                this.transaction = null;
            }

            //if (this.session != null)
            //{
            //  this.session.Dispose();
            //  session = null;
            //}
        }

        public void Clear()
        {
            this.session.Clear();
        }
    }
}
