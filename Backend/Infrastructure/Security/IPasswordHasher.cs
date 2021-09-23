using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Security
{
    public interface IPasswordHasher
    {
        string Hash(string password);

        string Hash(string login, string password);
    }
}
