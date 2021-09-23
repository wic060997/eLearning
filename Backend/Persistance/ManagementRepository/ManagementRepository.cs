using Infrastructure;
using Model.GroupSModel.DTO;
using Model.ManagementModel.DTO;
using Model.ManagementModel.Entity;
using Model.ManagementModel.Repository;
using Model.SchoolModel.DTO;
using Model.UserModel.DTO;
using Persistance.InfrastructureRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.ManagementRepository
{

    public class ManagementRepository : NHCrudRepository<Management>, IManagementRepository
    {
        public ManagementRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public IList<Management> GetAll()
        {
            return NHUnitOfWork.Session.Query<Management>().ToList<Management>();
        }

        public IList<ManagementDTO> GetAllDTO()
        {
            return NHUnitOfWork.Session.Query<Management>()
                .Select(x => new ManagementDTO()
                {
                    Id = x.Id,
                    user = new UserDTO()
                    {
                        Id = x.user.Id,
                        Login = x.user.Login,
                        ImieNazwisko = x.user.ImieNazwisko,
                        CzyAktywny = x.user.CzyAktywny,
                        Password = x.user.Password,
                        Email = x.user.Email,
                        Rola = new RolaDTO()
                        {
                            Id = x.user.Rola.Id,
                            Nazwa = x.user.Rola.Nazwa
                        },
                        School = new SchoolDTO()
                        {
                            Id = x.user.School.Id,
                            Name = x.user.School.Name,
                            Logo = x.user.School.Logo
                        },
                        NrIndex = x.user.NrIndex,
                        Image = x.user.Image,
                        GroupS = new GroupSDTO()
                    }
                })
            .ToList<ManagementDTO>();
        }
    }
}
