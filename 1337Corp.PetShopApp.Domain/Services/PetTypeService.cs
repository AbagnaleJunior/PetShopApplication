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
        private IPetTypeRepository _typeRepo;
        

        public PetTypeService(IPetTypeRepository typeRepo)
        {
            _typeRepo = typeRepo;
        }

        public void InitData()
        {
            _typeRepo.InitData();
        }

        public PetType GetPetTypeById(int id)
        {
            return _typeRepo.ReadById(id);
        }

        public List<PetType> GetAll()
        {
            return _typeRepo.SelectAll();
        }

        public PetType CreateType(PetType petType)
        {
            return _typeRepo.Insert(petType);
        }


    }
}
