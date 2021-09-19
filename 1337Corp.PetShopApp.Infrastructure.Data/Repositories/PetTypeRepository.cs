using _1337Corp.PetShopApp.Core.Models;
using _1337Corp.PetShopApp.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1337Corp.PetShopApp.Infrastructure.Data
{
    public class PetTypeRepository : IPetTypeRepository
    {

        public static List<PetType> _dataTypes = new List<PetType>();
        public static int _petTypeId = 8;

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
            PetType beetle = new PetType
            {
                Name = "Beetle",
                Id = 7
            };

            _dataTypes.AddRange(new List<PetType> { dog, cat, owl, snake, panda, turtle, beetle });
        }

        public PetType Insert(PetType petType)
        {
            petType.Id = _petTypeId++;
            _dataTypes.Add(petType);
            return petType;
        }

        public PetType ReadById(int id)
        {
            return _dataTypes.FirstOrDefault(petType => petType.Id == id);
        }
        public PetType ReadByName(string name)
        {
            return _dataTypes.FirstOrDefault(petType => petType.Name.ToLower() == name.ToLower());
        }

        public List<PetType> SelectAll()
        {
            return _dataTypes;
        }
    }
}
