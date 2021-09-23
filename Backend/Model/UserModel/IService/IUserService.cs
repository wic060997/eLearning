using Infrastructure;
using Model.UserModel.DTO;
using Model.UserModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Model.UserModel.IService
{
    public interface IUserService : IApplicationService
    {
        [Transaction] ClaimsIdentity Login(string login, string password);
        Guid DodajUzytkownika(UserDTO dto, string userName);
        void EdytujUzytkownika(UserDTO dto, string userName);
        void UsunUzytkownika(Guid id);
        void AktywujUzytkownika(string login, string userName);
        void DezaktywujUzytkownika(string login, string userName);
        void ChangePassword(Guid id, string haslo, string nowehaslo, string nowehaslo2);
        IList<UserDTO> PobierzListeUzytkownikowByRola(string rola);
        IList<UserDTO> PobietrzListeKlientow();
        IList<UserDTO> PobietrzListePracownikow();
        UserDTO PobierzUzytkownika(Guid id);
        bool SprawdzCzyLoginIstnieje(string login, Guid id);
        IList<UserDTO> getAllDTO();
        IList<Users> getAll();
        Guid AddUser(Users users);
        Guid AddAdministration(UserDTO dto,Guid school);
        IList<UserDTO> getUserSchool(Guid id);
        List<UserStudentDTO> GetStudentsFromGroup(Guid id);
        void NewStudent(NewStudentDTO dto);
        StudentDTO GetStudent(Guid id);
    }
}
