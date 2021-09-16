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

        
        
        public PetTypeService(IPetTypeRepository repo)
        {
            _repo = repo;
        }

        public PetType CreateType(PetType petType)
        {
            return _repo.Create(petType);
        }

        public void InitData()
        {
            _repo.InitData();
        }

        public List<PetType> GetAllTypes()
        {
            return _repo.ReadAllTypes();
        }

        public PetType GetPetTypeById(int id)
        {
            return _repo.ReadById(id);
        }


    }
}
