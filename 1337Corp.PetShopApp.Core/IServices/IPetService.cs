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
        List<Pet> GetPetsByType();
        List<PetType> GetPetTypes();
        Pet Create(Pet pet);
        string Delete(int petId);
        void UpdatePetName(int idToUpdate, string newPetName);
        void UpdatePetType(int idToUpdate, string newPetType);
        void UpdatePetBirthDate(int idToUpdate, DateTime newPetBirthDate);
        void UpdatePetSoldDate(int idToUpdate, DateTime newPetSoldDate);
        void UpdatePetColor(int idToUpdate, string newPetColoer);
        void UpdatePetPrice(int idToUpdate, double newPetPrice);
        

    }
}
