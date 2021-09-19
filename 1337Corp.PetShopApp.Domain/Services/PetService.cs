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
        private IPetRepository _petRepo;
        private IPetTypeRepository _typeRepo;
        private IOwnerRepository _ownerRepo;

        public PetService(IPetRepository repo, IPetTypeRepository typeRepo, IOwnerRepository ownerRepo)
        {
            _petRepo = repo;
            _typeRepo = typeRepo;
            _ownerRepo = ownerRepo;
        }

        public void InitData()
        {
            
            _petRepo.InitData(_typeRepo, _ownerRepo);
            
        }

        public Pet Create(Pet pet)
        {
            return _petRepo.Insert(pet);
        }

        public void Delete(int petId)
        {
            _petRepo.Delete(petId);
        }

        public List<Pet> GetAll()
        {
            return _petRepo.SelectAll();
        }

        public Pet Update(Pet updatePet)
        {
            return _petRepo.Update(updatePet);
        }

        public List<Pet> GetPetsByType(string typesSearch)
        {
            var list = _petRepo.SelectAll();
            return list.Where(pet => pet.Type.Name.ToLower() == typesSearch.ToLower()).ToList();
        }

        public Pet SearchPetById(int id)
        {
            return _petRepo.ReadById(id);
        }



    }
}
