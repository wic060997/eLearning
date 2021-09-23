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
    public interface IRolaRepository : ICrudRepository<Rola>
    {
        IList<RolaDTO> PobierzListe();

        bool SprawdzCzyRolaIstnieje(string nazwa, Guid? id = null);

        IList<Rola> GetAll();
    }
}
