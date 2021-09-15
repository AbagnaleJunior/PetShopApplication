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
    public class PetTypeService : IPetTypeService
    {
        private IPetTypeRepository _repo;

        
        
        public PetTypeService(IPetTypeRepository petTypeRepo)
        {
            _repo = petTypeRepo;
        }

        public PetType Create(PetType petType)
        {
            return _repo.Add(petType);
        }

        public void InitData()
        {
            _repo.InitData();
        }

        public List<PetType> GetAllTypes()
        {
            return _repo.FindAllTypes();
        }

        public PetType GetPetTypeById(int id)
        {
            return _repo.ReadById(id);
        }

        public PetType CreatePetType(PetType petType)
        {
            return _repo.Add(petType);
        }

    }
}
