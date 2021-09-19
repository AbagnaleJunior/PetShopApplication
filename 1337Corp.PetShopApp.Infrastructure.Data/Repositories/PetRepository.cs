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

        private static List<Pet> _dataPets = new List<Pet>();
        private static int _id = 8;


        public void InitData(IPetTypeRepository typeRepo, IOwnerRepository ownerRepo)
        {   
            _dataPets.AddRange(new Pet[] {

                new Pet()
                {
                    Id = 1,
                    Name = "Fido",
                    Owner = ownerRepo.ReadByName("Morten"),
                    Type = typeRepo.ReadByName("dog"),
                    BirthDate = new DateTime(1988, 09, 26),
                    SoldDate = new DateTime(2005, 05, 17),
                    Color = "Red",
                    Price = 500
                },

                new Pet()
                {
                    Id = 2,
                    Name = "Laban",
                    Owner = ownerRepo.ReadByName("Morten"),
                    Type = typeRepo.ReadByName("cat"),
                    BirthDate = new DateTime(1991, 08, 21),
                    SoldDate = new DateTime(1995, 12, 10),
                    Color = "Blue",
                    Price = 255
                },

                new Pet()
                {
                    Id = 3,
                    Name = "Hedwig",
                    Owner = ownerRepo.ReadByName("Morten"),
                    Type = typeRepo.ReadByName("owl"),
                    BirthDate = new DateTime(2007, 01, 06),
                    SoldDate = new DateTime(2008, 02, 28),
                    Color = "White",
                    Price = 2000
                },

                new Pet()
                {
                    Id = 4,
                    Name = "Nagini",
                    Owner = ownerRepo.ReadByName("Morten"),
                    Type = typeRepo.ReadByName("snake"),
                    BirthDate = new DateTime(1877, 04, 11),
                    SoldDate = new DateTime(2021, 08, 11),
                    Color = "Green",
                    Price = 500000
                },

                new Pet()
                {
                    Id = 5,
                    Name = "Po",
                    Owner = ownerRepo.ReadByName("Morten"),
                    Type = typeRepo.ReadByName("panda"),
                    BirthDate = new DateTime(2006, 10, 20),
                    SoldDate = new DateTime(2015, 11, 03),
                    Color = "Black/White",
                    Price = 300
                },

                new Pet()
                {
                    Id = 6,
                    Name = "Michelangelo",
                    Owner = ownerRepo.ReadByName("Morten"),
                    Type = typeRepo.ReadByName("turtle"),
                    BirthDate = new DateTime(1500, 07, 28),
                    SoldDate = new DateTime(2001, 07, 28),
                    Color = "Green",
                    Price = 10000
                },

                new Pet()
                {
                    Id = 7,
                    Name = "Per",
                    Owner = ownerRepo.ReadByName("Morten"),
                    Type = typeRepo.ReadByName("cat"),
                    BirthDate = new DateTime(1337, 1, 1),
                    SoldDate = new DateTime(2001, 07, 28),
                    Color = "black",
                    Price = 1337
                }
            });
        }

        public List<Pet> SelectAll()
        {
            return _dataPets;
        }

        public Pet ReadById(int id)
        {
            return _dataPets.FirstOrDefault(pet => pet.Id == id);
        }

        public List<Pet> ReadPetsByType(PetType petType)
        {
            return _dataPets.Where(x => x.Type.Id == petType.Id).ToList();
        }

        public Pet Insert(Pet pet)
        {
            pet.Id = _id++;
            _dataPets.Add(pet);
            return pet;
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

        public void Delete(int id)
        {
            Pet pet = ReadById(id);
            if (pet != null)
            {
                _dataPets.Remove(pet);
            }
        }
    }
}
