using _1337Corp.PetShopApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1337Corp.PetShopApp.Domain.IRepositories
{
    public interface IPetTypeRepository
    {

        PetType Add(PetType petType);

        List<PetType> ListAllPetTypes();
        List<PetType> FindAll();
    }
}
