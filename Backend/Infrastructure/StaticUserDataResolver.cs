using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class StaticUserDataResolver : IUserDataResolver
    {
        private Guid? userId;
        private string userName;

        public StaticUserDataResolver(string userName)
        {
            this.userName = userName;
        }

        public StaticUserDataResolver(Guid? userId, string userName)
        {
            this.userId = userId;
            this.userName = userName;
        }

        public string GetCurrentUser()
        {
            if (userName != null)
                return userName;
            else
                throw new NullReferenceException();
        }

        public Guid GetCurrentUserId()
        {
            if (userId.HasValue)
                return userId.Value;
            else
                throw new NullReferenceException();
        }
    }
}
