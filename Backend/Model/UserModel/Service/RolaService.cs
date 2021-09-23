using Infrastructure;
using Model.UserModel.DTO;
using Model.UserModel.Entity;
using Model.UserModel.IService;
using Model.UserModel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.UserModel.Service
{
    public class RolaService : ApplicationService, IRolaService
    {
        private readonly IRolaRepository rolaRepository;
        public RolaService(IUnitOfWork unitOfWork,
            IRolaRepository rolaRepository) : base(unitOfWork)
        {
            this.rolaRepository = rolaRepository;
        }

        public IList<Rola> GetAll()
        {
            return rolaRepository.GetAll();
        }

        public IList<RolaDTO> PobierzListeRol()
        {
            return rolaRepository.PobierzListe();
        }
    }
}
