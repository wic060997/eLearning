﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TransactionAttribute : System.Attribute
    {
        public TransactionAttribute()
        {
            IsolationLevel = IsolationLevel.ReadCommitted;
        }

        public TransactionAttribute(IsolationLevel isolationLevel)
        {
            this.IsolationLevel = isolationLevel;
        }

        public IsolationLevel IsolationLevel { get; set; }
    }
}
