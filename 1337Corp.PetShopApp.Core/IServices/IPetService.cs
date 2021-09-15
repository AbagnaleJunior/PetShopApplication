using _1337Corp.PetShopApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1337Corp.PetShopApp.Core.IServices
{
    public interface IPetService : IInitializableService
    {
        List<Pet> GetAllPets();
        List<Pet> GetPetsByType(PetType petType);
       
        Pet Create(Pet pet);
        string Delete(int petId);
        Pet Update(Pet pet);
        Pet SearchPetById(int id);
        

    }
}
