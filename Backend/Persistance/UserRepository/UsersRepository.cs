using Infrastructure;
using Model.GroupSModel.DTO;
using Model.SchoolModel.DTO;
using Model.UserModel.DTO;
using Model.UserModel.Entity;
using Model.UserModel.Repository;
using NHibernate.Criterion;
using Persistance.InfrastructureRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.UserRepository
{

    public class UsersRepository : NHCrudRepository<Users>, IUserRepository
    {
        public UsersRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public IList<Users> GetAll()
        {
            return NHUnitOfWork.Session.Query<Users>().ToList();
        }

        public IList<UserDTO> GetAllDTO()
        {
            var list = NHUnitOfWork.Session.Query<Users>().ToList();

            return NHUnitOfWork.Session.Query<Users>()
                .Select(x => new UserDTO()
                {
                    Id = x.Id,
                    ImieNazwisko = x.ImieNazwisko,
                    Password = x.Password,
                    Email = x.Email,
                    Login = x.Login,
                    CzyAktywny = x.CzyAktywny,
                    Rola = new RolaDTO { Id = x.Rola.Id, Nazwa = x.Rola.Nazwa },
                    School = x.School.Id == null ? new SchoolDTO() : new SchoolDTO { Id = x.School.Id, Name = x.School.Name, Logo = x.School.Logo },
                    NrIndex = x.NrIndex,
                    Image = x.Image,
                    GroupS = x.GroupS.Id == null ? new GroupSDTO() : new GroupSDTO() { Id = x.GroupS.Id, Year = x.GroupS.Year, Semester = x.GroupS.Semester, Direction = x.GroupS.Direction, Specjalize = x.GroupS.Specjalize, }
                })
                .ToList<UserDTO>();
        }

        public Users GetByLogin(string login)
        {
            return NHUnitOfWork.Session.CreateCriteria<Users>()
                .Add(Expression.Eq(nameof(Users.Login), login))
                .UniqueResult<Users>();
        }

        public IList<UserStudentDTO> GetStudentsFromGroup(Guid id)
        {
            return NHUnitOfWork.Session.Query<Users>()
                .Where(x => x.GroupS.Id == id)
                 .Select(x => new UserStudentDTO()
                 {
                     Id = x.Id,
                     ImieNazwisko = x.ImieNazwisko,
                     Email = x.Email,
                     Login = x.Login,
                     NrIndex = x.NrIndex
                 })
                .ToList<UserStudentDTO>();
        }

        public IList<UserDTO> getUserSchool(Guid id)
        {
            return NHUnitOfWork.Session.Query<Users>()
                .Where(x => x.School.Id == id && x.Rola.Nazwa != "ADMINISTRATION")
                 .Select(x => new UserDTO()
                 {
                     Id = x.Id,
                     ImieNazwisko = x.ImieNazwisko,
                     Password = x.Password,
                     Email = x.Email,
                     Login = x.Login,
                     CzyAktywny = x.CzyAktywny,
                     Rola = new RolaDTO { Id = x.Rola.Id, Nazwa = x.Rola.Nazwa },
                     GroupS = x.GroupS.Id == null ? new GroupSDTO() : new GroupSDTO() { Id = x.GroupS.Id, Year = x.GroupS.Year, Semester = x.GroupS.Semester, Direction = x.GroupS.Direction, Specjalize = x.GroupS.Specjalize, }
                 })
                .ToList<UserDTO>();
        }

        public IList<Users> PobierzListeUzytkownikowByRola(string rola)
        {
            return NHUnitOfWork.Session.Query<Users>()
                .Where(x => x.Rola.Nazwa == rola && x.CzyAktywny == true)
                .ToList();
        }

        public IList<UserDTO> PobierzLiteKlientow()
        {
            return NHUnitOfWork.Session.Query<Users>()
                .Where(x => x.Rola.Nazwa == "Client")
                 .Select(x => new UserDTO()
                 {
                     Id = x.Id,
                     ImieNazwisko = x.ImieNazwisko,
                     Password = x.Password,
                     Email = x.Email,
                     Login = x.Login,
                     CzyAktywny = x.CzyAktywny,
                     Rola = new RolaDTO { Id = x.Rola.Id, Nazwa = x.Rola.Nazwa },
                 })
                .ToList<UserDTO>();
        }

        public IList<UserDTO> PobierzLitePracownikow()
        {
            return NHUnitOfWork.Session.Query<Users>()
                .Where(x => x.Rola.Nazwa != "Klient")
                .Select(x => new UserDTO()
                {
                    Id = x.Id,
                    ImieNazwisko = x.ImieNazwisko,
                    Password = x.Password,
                    Email = x.Email,
                    Login = x.Login,
                    CzyAktywny = x.CzyAktywny,
                    Rola = new RolaDTO { Id = x.Rola.Id, Nazwa = x.Rola.Nazwa },
                })
                .ToList<UserDTO>();
        }

        public bool SprawdzCzyLoginIstnieje(string login, Guid? Id = null)
        {
            var criteria = NHUnitOfWork.Session.CreateCriteria<Users>();
            if (Id != null)
                criteria.Add(Restrictions.Not(Restrictions.Eq(nameof(Users.Id), Id)));

            criteria.Add(Restrictions.Eq(nameof(Users.Login), login))
                .SetMaxResults(1);
            return criteria.List().Count > 0;
        }
    }
}
