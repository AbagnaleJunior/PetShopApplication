using _1337Corp.PetShopApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1337Corp.PetShopApp.Core.IServices
{
    public interface IPetService
    {
        List<Pet> GetAll();
        List<Pet> GetPetsByType(string typesSearch);
        Pet SearchPetById(int id);
        Pet Create(Pet pet);
        Pet Update(Pet pet);
        public void Delete(int petId);
        void InitData();
    }
}
