using _1337Corp.PetShopApp.Core.IServices;
using _1337Corp.PetShopApp.Core.Models;
using _1337Corp.PetShopApp.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1337Corp.PetShopApp.Domain.Services
{
    public class PetService : IPetService
    {
        private IPetRepository _repo;

        public PetService(IPetRepository repo)
        {
            _repo = repo;
        }


        public Pet Create(Pet pet)
        {
            return _repo.Add(pet);
        }

        public string Delete(int petId)
        {
            return _repo.Delete(petId);
        }

        public List<Pet> GetAllPets()
        {
            return _repo.FindAll();
        }

        public List<Pet> GetPetsByType()
        {
            throw new NotImplementedException();
        }

        public void UpdatePetBirthDate(int idToUpdate, DateTime newPetBirthDate)
        {
            throw new NotImplementedException();
        }

        public void UpdatePetColor(int idToUpdate, string newPetColoer)
        {
            throw new NotImplementedException();
        }

        public void UpdatePetName(int idToUpdate, string newPetName)
        {
            throw new NotImplementedException();
        }

        public void UpdatePetPrice(int idToUpdate, double newPetPrice)
        {
            throw new NotImplementedException();
        }

        public void UpdatePetSoldDate(int idToUpdate, DateTime newPetSoldDate)
        {
            throw new NotImplementedException();
        }

        public void UpdatePetType(int idToUpdate, string newPetType)
        {
            throw new NotImplementedException();
        }
    }
}
