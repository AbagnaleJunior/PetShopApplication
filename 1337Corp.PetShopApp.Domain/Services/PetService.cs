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

        public void InitData()
        {
            _repo.InitData();
        }
      
        public Pet Create(Pet pet)
        {
            return _repo.Add(pet);
        }

        public void Delete(int petId)
        {
            _repo.Delete(petId);
        }

        public List<Pet> GetAllPets()
        {
            return _repo.ReadAll();
        }

        public Pet Update(Pet updatePet)
        {
            return _repo.Update(updatePet);
        }
        

        public List<Pet> GetPetsByType(string typesSearch)
        {
            var list = _repo.ReadAll();
            var resultList = list.Where(pet => pet.Type.Name == typesSearch);

            return resultList.ToList();
        }


        public Pet SearchPetById(int id)
        {
            return _repo.ReadById(id);
        }
       

    }
}
