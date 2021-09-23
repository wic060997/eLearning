using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Transactions
{
    public class TransactionInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            if (IsNonTransactionAttribute(invocation.Method))
            {
                invocation.Proceed();
                return;
            }

            IApplicationService service = invocation.InvocationTarget as IApplicationService;
            if (service != null)
            {
                IsolationLevel? isolationLevel = IsTransactionIsolationLevelAttribute(invocation.Method);

                IUnitOfWork unitOfWork = service.GetUnitOfWork();

                // When transaction exists do not create next one!!!

                if (unitOfWork.IsInTransaction())
                {
                    invocation.Proceed();
                    return;
                }

                try
                {
                    if (isolationLevel.HasValue)
                        unitOfWork.BeginTransaction(isolationLevel.Value);
                    else
                        unitOfWork.BeginTransaction();

                    invocation.Proceed();

                    unitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    try
                    {
                        if (unitOfWork != null)
                            unitOfWork.Rollback();
                    }
                    catch
                    {
                        throw new Exception("Transakcja została już wycofana ", ex);
                    }
                    throw;
                }
            }
        }

        private bool IsNonTransactionAttribute(MethodInfo methodInfo)
        {
            object[] attributes = methodInfo.GetCustomAttributes(typeof(NonTransactionAttribute), true);
            return attributes.Any();
        }

        private IsolationLevel? IsTransactionIsolationLevelAttribute(MethodInfo methodInfo)
        {
            IsolationLevel? isolationLevel = null;
            object[] attributes = methodInfo.GetCustomAttributes(typeof(TransactionIsolationLevelAttribute), true);
            if (attributes.Any())
                isolationLevel = ((TransactionIsolationLevelAttribute)attributes.First()).IsolationLevel;
            return isolationLevel;
        }
    }
}
