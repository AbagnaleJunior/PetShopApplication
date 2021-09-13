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
        private string deletedPet;

        private static int _id = 7;

        public void InitData()
        {
            PetType dog = new PetType
            {
                Name = "Dog",
                Id = 1
            };
            PetType cat = new PetType
            {
                Name = "Cat",
                Id = 2
            };
            PetType owl = new PetType
            {
                Name = "Owl",
                Id = 3
            };
            PetType snake = new PetType
            {
                Name = "Snake",
                Id = 4
            };
            PetType panda = new PetType
            {
                Name = "Panda",
                Id = 5
            };
            PetType turtle = new PetType
            {
                Name = "Turtle",
                Id = 6
            };
            Pet pet1 = new Pet()
            {
                Id = 1,
                Name = "Fido",
                Type = dog,
                BirthDate = new DateTime(1988, 09, 26),
                SoldDate = new DateTime(2005, 05, 17),
                Color = "Red",
                Price = 500
            };
            Pet pet2 = new Pet()
            {
                Id = 2,
                Name = "Laban",
                Type = cat,
                BirthDate = new DateTime(1991, 08, 21),
                SoldDate = new DateTime(1995, 12, 10),
                Color = "Blue",
                Price = 255
            };
            Pet pet3 = new Pet()
            {
                Id = 3,
                Name = "Hedwig",
                Type = owl,
                BirthDate = new DateTime(2007, 01, 06),
                SoldDate = new DateTime(2008, 02, 28),
                Color = "White",
                Price = 2000
            };
            Pet pet4 = new Pet()
            {
                Id = 4,
                Name = "Nagini",
                Type = snake,
                BirthDate = new DateTime(1877, 04, 11),
                SoldDate = new DateTime(2021, 08, 11),
                Color = "Green",
                Price = 500000
            };
            Pet pet5 = new Pet()
            {
                Id = 5,
                Name = "Po",
                Type = panda,
                BirthDate = new DateTime(2006, 10, 20),
                SoldDate = new DateTime(2015, 11, 03),
                Color = "Black/White",
                Price = 300
            };
            Pet pet6 = new Pet()
            {
                Id = 6,
                Name = "Michelangelo",
                Type = turtle,
                BirthDate = new DateTime(1500, 07, 28),
                SoldDate = new DateTime(2001, 07, 28),
                Color = "Green",
                Price = 10000
            };
            _petTable.Add(pet1);
            _petTable.Add(pet2);
            _petTable.Add(pet3);
            _petTable.Add(pet4);
            _petTable.Add(pet5);
            _petTable.Add(pet6);
        }
        public Pet Add(Pet pet)
        {
            pet.Id = _id++;
            _petTable.Add(pet);
            return pet;
        }

        public string Delete(int id)
        {
            Pet pet = GetPetById(id);
            if (id == pet.Id)
            {
                _petTable.Remove(pet);
                deletedPet = pet.Name;
            }
            return deletedPet;
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
