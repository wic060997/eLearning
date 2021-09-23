using Infrastructure;
using Model.GroupSModel.DTO;
using Model.SchoolModel.DTO;
using Model.TeacherModel.DTO;
using Model.TeacherModel.Entity;
using Model.TeacherModel.Repository;
using Model.UserModel.DTO;
using Persistance.InfrastructureRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.TeacherRepository
{
    public class TeacherRepository : NHCrudRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public IList<Teacher> GetAll()
        {
            return NHUnitOfWork.Session.Query<Teacher>().ToList<Teacher>();
        }

        public IList<TeacherDTO> GetAllDTO()
        {
            return NHUnitOfWork.Session.Query<Teacher>()
                .Select(x => new TeacherDTO()
                {
                    Id = x.Id,
                    user = new UserDTO()
                    {
                        Id = x.Users.Id,
                        Login = x.Users.Login,
                        ImieNazwisko = x.Users.ImieNazwisko,
                        CzyAktywny = x.Users.CzyAktywny,
                        Password = x.Users.Password,
                        Email = x.Users.Email,
                        Rola = new RolaDTO()
                        {
                            Id = x.Users.Rola.Id,
                            Nazwa = x.Users.Rola.Nazwa
                        },
                        School = new SchoolDTO()
                        {
                            Id = x.Users.School.Id,
                            Name = x.Users.School.Name,
                            Logo = x.Users.School.Logo
                        },
                        NrIndex = x.Users.NrIndex,
                        Image = x.Users.Image,
                        GroupS = new GroupSDTO(),
                    },
                    Specjalize = x.Specjalize
                })
            .ToList<TeacherDTO>();
        }

        public TeacherDTO GetTeacher(Guid id)
        {
            return  NHUnitOfWork.Session.Query<Teacher>()
                .Where(x => x.Id == id)
                .Select(x => new TeacherDTO()
                {
                    Id = x.Id,
                    user = new UserDTO()
                    {
                        Id = x.Users.Id,
                        Login = x.Users.Login,
                        ImieNazwisko = x.Users.ImieNazwisko,
                        CzyAktywny = x.Users.CzyAktywny,
                        Password = x.Users.Password,
                        Email = x.Users.Email,
                        Rola = new RolaDTO()
                        {
                            Id = x.Users.Rola.Id,
                            Nazwa = x.Users.Rola.Nazwa
                        },
                        School = new SchoolDTO()
                        {
                            Id = x.Users.School.Id,
                            Name = x.Users.School.Name,
                            Logo = x.Users.School.Logo
                        },
                        NrIndex = x.Users.NrIndex,
                        Image = x.Users.Image,
                        
                    },
                    Specjalize = x.Specjalize
                })
                .FirstOrDefault();

            
        }

        public TeacherDTO GetTeacherFromUser(Guid id)
        {
            return NHUnitOfWork.Session.Query<Teacher>()
                .Where(x => x.Users.Id == id)
                .Select(x => new TeacherDTO()
                {
                    Id = x.Id,
                    user = new UserDTO()
                    {
                        Id = x.Users.Id,
                        Login = x.Users.Login,
                        ImieNazwisko = x.Users.ImieNazwisko,
                        CzyAktywny = x.Users.CzyAktywny,
                        Password = x.Users.Password,
                        Email = x.Users.Email,
                        Rola = new RolaDTO()
                        {
                            Id = x.Users.Rola.Id,
                            Nazwa = x.Users.Rola.Nazwa
                        },
                        School = new SchoolDTO()
                        {
                            Id = x.Users.School.Id,
                            Name = x.Users.School.Name,
                            Logo = x.Users.School.Logo
                        },
                        NrIndex = x.Users.NrIndex,
                        Image = x.Users.Image,
                        GroupS = new GroupSDTO(),
                    },
                    Specjalize = x.Specjalize
                })
                .FirstOrDefault();
        }

        public IList<TeacherDTO> GetTeachersFromSchool(Guid id)
        {
            return NHUnitOfWork.Session.Query<Teacher>()
                .Where(x=>x.Users.School.Id==id)
                .Select(x => new TeacherDTO()
                {
                    Id = x.Id,
                    user = new UserDTO()
                    {
                        Id = x.Users.Id,
                        Login = x.Users.Login,
                        ImieNazwisko = x.Users.ImieNazwisko,
                        CzyAktywny = x.Users.CzyAktywny,
                        Password = x.Users.Password,
                        Email = x.Users.Email,
                        Rola = new RolaDTO()
                        {
                            Id = x.Users.Rola.Id,
                            Nazwa = x.Users.Rola.Nazwa
                        },
                        School = new SchoolDTO()
                        {
                            Id = x.Users.School.Id,
                            Name = x.Users.School.Name,
                            Logo = x.Users.School.Logo
                        },
                        NrIndex = x.Users.NrIndex,
                        Image = x.Users.Image,
                        GroupS = new GroupSDTO(),
                    },
                    Specjalize = x.Specjalize
                })
            .ToList<TeacherDTO>();
        }
    }
}
