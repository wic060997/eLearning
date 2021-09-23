using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IRepository
    {
        TEntity CreateProxy<TEntity>(Guid id)
          where TEntity : Entity;
    }
}
