using NHibernate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Rozpoczyna transakcję
        /// </summary>
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

        /// <summary>
        /// Zatwierdza transakcję
        /// </summary>
        void Commit();

        /// <summary>
        /// Zwraca informację czy jest transakcja
        /// </summary>
        /// <returns>True oznacza transakcję</returns>
        bool IsInTransaction();

        /// <summary>
        /// Ustawia tryb flushowania sesji (zgodne z NHibernate)
        /// </summary>
        /// <param name="mode">Tryb flushowania (zgodny z NHibernate)</param>
        void SetFlushMode(FlushMode mode);

        /// <summary>
        /// Flushuje sesję
        /// </summary>
        void Flush();

        /// <summary>
        /// Ustawia encję jako tylko do odczytu
        /// </summary>
        /// <param name="entity">Encja</param>
        /// <param name="isReadOnly">Czy tylko do odczytu</param>
        void SetReadOnly(object entity, bool isReadOnly);

        /// <summary>
        /// Wycofuje transakcję
        /// </summary>
        void Rollback();

        void Clear();
    }
}
