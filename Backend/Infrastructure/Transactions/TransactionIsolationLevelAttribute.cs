using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Transactions
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TransactionIsolationLevelAttribute : Attribute
    {
        public TransactionIsolationLevelAttribute()
        {
            IsolationLevel = IsolationLevel.ReadCommitted;
        }

        public TransactionIsolationLevelAttribute(IsolationLevel isolationLevel)
        {
            this.IsolationLevel = isolationLevel;
        }

        public IsolationLevel IsolationLevel { get; set; }
    }
}
