using _1337Corp.PetShopApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1337Corp.PetShopApp.Domain.IRepositories
{
    public interface IPetRepository
    {
        Pet Insert(Pet pet);
        List<Pet> SelectAll();
        Pet ReadById(int id);
        List<Pet> ReadPetsByType(PetType petType);
        Pet Update(Pet petUpdate);
        public void Delete(int petId);
        void InitData(IPetTypeRepository typeRepo, IOwnerRepository ownerRepo);

    }
}
