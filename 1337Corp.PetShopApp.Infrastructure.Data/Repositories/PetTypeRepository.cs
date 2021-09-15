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

        private static List<PetType> _petTypeTable = new List<PetType>();
        private static int _petTypeId = 7;

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
           
            _petTypeTable.Add(dog);
            _petTypeTable.Add(cat);
            _petTypeTable.Add(owl);
            _petTypeTable.Add(snake);
            _petTypeTable.Add(panda);
            _petTypeTable.Add(turtle);

        }


        public PetType Add(PetType petType)
        {
            petType.Id = _petTypeId++;
            _petTypeTable.Add(petType);
            return petType;
        }

        public List<PetType> ReadPetType()
        {
            return _petTypeTable;
        }

        public PetType ReadById(int id)
        {
            return _petTypeTable.FirstOrDefault(petType => petType.Id == id);
        }

       

        public List<PetType> FindAllTypes()
        {
            return _petTypeTable;
        }


    }
}
