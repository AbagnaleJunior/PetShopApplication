using _1337Corp.PetShopApp.Core.Models;
using _1337Corp.PetShopApp.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1337Corp.PetShopApp.Infrastructure.Data
{
    public class PetShopRepository : IPetRepository, IPetTypeRepository
    {
        private static List<Pet> _petTable = new List<Pet>();
        private static List<PetType> _petTypeTable = new List<PetType>();
       
        private static int _id = 1;
        public Pet Add(Pet pet)
        {
            pet.Id = _id++;
            _petTable.Add(pet);
            return pet;
        }

        public bool Delete(int id)
        {
            Pet p = GetPetById(id);
            if (p != null)
            {
                _petTable.Remove(p);
                return true;
            }

            return false;
        }

        public Pet GetPetById(int? id)
        {
            Pet p = null;
            for (int i = 0; i < _petTable.Count; i++)
            {
                if (_petTable[i].Id == id)
                {
                    p = _petTable[i];
                }
            }

            return p;
        }


        public List<Pet> FindAll()
        {
            return _petTable;
        }

        public List<PetType> FindAllTypes()
        {
            return _petTypeTable;
        }

        public PetType Add(PetType petType)
        {
            throw new NotImplementedException();
        }

        public List<PetType> ListAllPetTypes()
        {
            throw new NotImplementedException();
        }

        List<PetType> IPetTypeRepository.FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
