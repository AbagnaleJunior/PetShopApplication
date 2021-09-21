using _1337Corp.PetShopApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1337Corp.PetShopApp.Core.IServices
{
    public interface IOwnerService
    {
        List<Owner> GetAll();
        Owner CreateOwner(Owner owner);
        void InitData();
        Owner GetOwnerById(int id);
        public void Delete(int ownerId);
    }
}
