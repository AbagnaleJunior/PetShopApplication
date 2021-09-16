using _1337Corp.PetShopApp.Core.Models;
using _1337Corp.PetShopApp.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1337Corp.PetShopApp.Infrastructure.Data
{
    public class PetRepository : IPetRepository
    {
        private static List<PetType> _types = new List<PetType>();
        private static List<Pet> _pets = new List<Pet>();
        private static int _id = 7;
        

        public void InitData()
        {
            //INITIATING PETTYPES
            PetType dog = new PetType
            {
                Name = "dog",
                Id = 1
            };
            PetType cat = new PetType
            {
                Name = "cat",
                Id = 2
            };
            PetType owl = new PetType
            {
                Name = "owl",
                Id = 3
            };
            PetType snake = new PetType
            {
                Name = "snake",
                Id = 4
            };
            PetType panda = new PetType
            {
                Name = "panda",
                Id = 5
            };
            PetType turtle = new PetType
            {
                Name = "turtle",
                Id = 6
            };
            PetType beetle = new PetType
            {
                Name = "beetle",
                Id = 7
            };

            _types.AddRange(new List<PetType> { dog, cat, owl, snake, panda, turtle, beetle });

            //INITIATES PETS
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
            Pet pet7 = new Pet()
            {
                Id = 7,
                Name = "Per",
                Type = cat,
                BirthDate = new DateTime(1337, 1, 1),
                SoldDate = new DateTime(2001, 07, 28),
                Color = "black",
                Price = 1337
            };

            _pets.Add(pet1);
            _pets.Add(pet2);
            _pets.Add(pet3);
            _pets.Add(pet4);
            _pets.Add(pet5);
            _pets.Add(pet6);
            _pets.Add(pet7);
        }

        public Pet Add(Pet pet)
        {
            pet.Id = _id++;
            _pets.Add(pet);
            return pet;
        }

        public void Delete(int id)
        {
            Pet pet = GetPetById(id);
            if (pet != null)
            {
                _pets.Remove(pet);
            }
        }

        public Pet GetPetById(int id)
        {
            Pet pet = null;
            for (int i = 0; i < _pets.Count; i++)
            {
                if (_pets[i].Id == id)
                {
                    pet = _pets[i];
                }
            }
            return pet;
        }

        public List<Pet> ReadAll()
        {
            return _pets;
        }

        public Pet Update(Pet petUpdate)
        {
            var pet = ReadById(petUpdate.Id);
            if (pet == null) return null;
            pet.Name = petUpdate.Name;
            pet.Price = petUpdate.Price;
            pet.Color = petUpdate.Color;
            pet.SoldDate = petUpdate.SoldDate;

            return pet;
        }

        public Pet ReadById(int id)
        {
            return _pets.FirstOrDefault(pet => pet.Id == id);
        }

        public List<Pet> ReadPetByType(PetType petType)
        {
            throw new NotImplementedException();
        }
       
    }
}
