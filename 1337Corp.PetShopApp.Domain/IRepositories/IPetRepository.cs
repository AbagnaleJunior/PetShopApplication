using _1337Corp.PetShopApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1337Corp.PetShopApp.Domain.IRepositories
{
    public interface IPetRepository
    {

        Pet Add(Pet pet);
        List<Pet> FindAll();
        bool Delete(int petId);
    }
}
