using _1337Corp.PetShopApp.Core.Models;
using _1337Corp.PetShopApp.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1337Corp.PetShopApp.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {

        public static List<Owner> _dataOwners = new List<Owner>();
        public static int _ownerId = 2;

        public void InitData()
        {

            Owner morten = new Owner
            {
                Name = "Morten",
                Id = 1
            };
            Owner karsten = new Owner
            {
                Name = "Karsten",
                Id = 2
            };


            _dataOwners.AddRange(new List<Owner> { morten, karsten });
        }

        //public Owner Insert(Owner owner)
        //{
        //    owner.Id = _ownerId++;
        //    _dataOwners.Add(owner);
        //    return owner;
        //}

        //public Owner ReadById(int id)
        //{
        //    return _dataOwners.FirstOrDefault(owner => owner.Id == id);
        //}
        public Owner ReadByName(string name)
        {
            return _dataOwners.FirstOrDefault(owner => owner.Name.ToLower() == name.ToLower());
        }

        //public List<Owner> SelectAll()
        //{
        //    return _dataOwners;
        //}
    }
}