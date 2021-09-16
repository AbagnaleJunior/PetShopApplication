using _1337Corp.PetShopApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1337Corp.PetShopApp.Domain.IRepositories
{
    public interface IPetRepository : IInitializableRepository
    {
        Pet Add(Pet pet);
        List<Pet> ReadAll();
        public void Delete(int petId);
        Pet Update(Pet petUpdate);
        Pet ReadById(int id);
        List<Pet> ReadPetByType(PetType petType);
    }
}
