using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ApplicationService : IApplicationService
    {
        private readonly IUnitOfWork unitOfWork;

        public ApplicationService(
          IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork; ;
        }

        public IUnitOfWork GetUnitOfWork()
        {
            return unitOfWork;
        }
    }
}
