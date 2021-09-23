using Infrastructure;
using Model.UserModel.DTO;
using Model.UserModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.UserModel.Repository
{
    public interface IUserRepository : ICrudRepository<Users>
    {
        Users GetByLogin(string login);
        IList<UserDTO> PobierzLiteKlientow();
        IList<UserDTO> PobierzLitePracownikow();
        IList<UserDTO> GetAllDTO();
        IList<Users> GetAll();

        IList<Users> PobierzListeUzytkownikowByRola(string rola);

        bool SprawdzCzyLoginIstnieje(string login, Guid? id = null);

        IList<UserDTO> getUserSchool(Guid id);

        IList<UserStudentDTO> GetStudentsFromGroup(Guid id);

    }
}
