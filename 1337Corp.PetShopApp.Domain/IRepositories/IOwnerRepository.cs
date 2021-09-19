using _1337Corp.PetShopApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1337Corp.PetShopApp.Domain.IRepositories
{
    public interface IOwnerRepository
    {

        //Owner Insert(Owner owner);
        List<Owner> SelectAll();
        Owner ReadById(int id);
        Owner ReadByName(string name);
        void InitData();
    }
}
