using Infrastructure;
using Model.UserModel.DTO;
using Model.UserModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.UserModel.IService
{
    public interface IRolaService : IApplicationService
    {
        IList<RolaDTO> PobierzListeRol();
        IList<Rola> GetAll();
    }
}
