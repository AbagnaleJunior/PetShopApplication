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
    public class OwnerService : IOwnerService
    {
        private IOwnerRepository _ownerRepo;

        public OwnerService(IOwnerRepository ownerRepo)
        {
            _ownerRepo = ownerRepo;
        }

        public void InitData()
        {
            _ownerRepo.InitData();
        }

        public Owner GetOwnerById(int id)
        {
            return _ownerRepo.ReadById(id);
        }

        public List<Owner> GetAll()
        {
            return _ownerRepo.SelectAll();
        }

        //public Owner CreateOwner(Owner owner)
        //{
        //    return _ownerRepo.Insert(owner);
        //}
    }
}
