using _1337Corp.PetShopApp.Core.IServices;
using _1337Corp.PetShopApp.Core.Models;
using _1337Corp.PetShopApp.Domain.Services;
using _1337Corp.PetShopApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1337Corp.PetShopApp.UI
{
    public class Menu

    {
        private IPetService _petService;
        private IPetTypeService _typeService;
       


        public Menu(IPetService petService, IPetTypeService typeService)
        {
            _petService = petService;
            _typeService = typeService;
            
        }

        public void Start()
        {
            _typeService.InitData();
            _petService.InitData();
            
            ShowIntroMessage();
            StartLoop();
        }

        private void ShowIntroMessage()
        {
            Console.WriteLine(StringConstants.IntroMessageText);
        }

        private void StartLoop()
        {
            int choice;
            while ((choice = GetMainMeniSelection()) != 0)
            {

                if (choice == 1)
                {
                    ListAllPets();
                }
               
                if (choice == 2)
                {
                    SearchForTypesOfPet();
                }
                
                if (choice == 3)
                {
                    CreatePet();
                }

                if (choice == 4)
                {
                    Update();
                }

                if (choice == 5)
                {
                    DeletePet();
                }

                if (choice == 6)
                {
                    ListCheapestPets();
                }

                if (choice == 7)
                {
                    ReadTypes();
                }

                if (choice == 8)
                {
                    CreateType();
                }

                if (choice == 0)
                {
                    ExitProgram();
                }
                
            }

        }

        private void CreateType()
        {
            ReadTypes();
            Print("What Type do you want to add?");
            var petType = Console.ReadLine();
            var type = new PetType
            {
                Name = petType
            };

            type = _typeService.CreateType(type);
            ReadTypes();
            Print($"Type: '{petType}' was added");


        }

            private void ReadTypes()
        {

            Clear();
            Print("List of all types:");
            
            foreach (var type in _typeService.GetAllTypes())
            {
                Print($"ID: {type.Id} - {type.Name}");

            }

            Print("");
            Print("------------------------------------------");
        }



        private void SearchForTypesOfPet()
        {
            Clear();
            Print(StringConstants.SearchForTypes);
            Print("What animal do you want to search for? use small letters (cat)");
            var TypesSearch = Console.ReadLine();
            Clear();

            foreach (var pet in _petService.GetPetsByType(TypesSearch))
            {
                
                Print($"ID: {pet.Id}, Type: {pet.Type.Name}, Name: {pet.Name}, BirthDate: {pet.BirthDate}, Color: {pet.Color}, Price: {pet.Price}, Sold on: {pet.SoldDate}");
                
                Print("------------------------------------------");
            }
            
            
        }

        private void Update()
        {
            Clear();
            UpdateListAllPets();
            Print("");

            Print(StringConstants.UpdatedEnterPetID);
            var updateId = int.Parse(Console.ReadLine()!);
            var updatePet = _petService.SearchPetById(updateId);

            Print(StringConstants.UpdatedPetName);
            var updatedName = Console.ReadLine();


            Print(StringConstants.UpdatedColor);
            var updatedColor = Console.ReadLine();

            Print(StringConstants.UpdatedSoldDate);
            var updatedSoldDate = Convert.ToDateTime(Console.ReadLine());

            Print(StringConstants.UpdatedPrice);
            var updatedPrice = double.Parse(Console.ReadLine()!);


            _petService.Update(new Pet()
            {

                Id = updatePet.Id,
                Name = updatedName,
                Color = updatedColor,
                SoldDate = updatedSoldDate,
                Price = updatedPrice

            });

            Print($"{updatePet.Name} was updated.");
        }

        private void ListCheapestPets()
        {

            List<Pet> pets = _petService.GetAllPets();
            
            List<Pet> cheapestPets = pets.OrderBy(pet => pet.Price).ToList();

            foreach (var pet in cheapestPets)
            {
                Print("");
                Print($"Id: {pet.Id}");
                Print($"Type: {pet.Type.Name}");
                Print($"Name: {pet.Name}");
                Print($"Color: {pet.Color}");
                Print($"BirthDate: {pet.BirthDate.ToString("dd-MM-yyyy")}");
                Print($"Price: {pet.Price}" + "$");
                Print($"Sold: {pet.SoldDate.ToString("dd-MM-yyyy")}");

                Print("");
                Print("------------------------------------------");
            }
        }

        private void ExitProgram()
        {
            Environment.Exit(0);
        }

        private void DeletePet()
        {
            Clear();
            ListAllPets();
            Console.WriteLine(StringConstants.DeleteEnterPetId);
            var petId = Console.ReadLine();
            int selectionId = int.Parse(petId);

            {
                var deletedPetName = int.Parse(Console.ReadLine()!);
                _petService.Delete(deletedPetName);
                Clear();
                Console.WriteLine($"The pet {deletedPetName} with the ID {petId}, has been deleted.");
            }
        }

        private int GetMainMeniSelection()
        {
            ShowMainMenu();
            var selectionString = Console.ReadLine();
            int selection;
            if (int.TryParse(selectionString, out selection))
            {
                return selection;
            }
            return -1;
        }

        private void PrintNewLine()
        {
            Console.WriteLine("");
        }
        private void Clear()
        {
            Console.Clear();
        }

        private void ShowMainMenu()
        {
            PrintNewLine();
            Print(StringConstants.MenuGuideText);

            PrintNewLine();
            Print(StringConstants.PrintAllPetsListText);
            Print(StringConstants.SearchByPetTypeText);
            Print(StringConstants.CreateNewPetText);
            Print(StringConstants.UpdatePetText);
            Print(StringConstants.DeletePetText);
            Print(StringConstants.CheapestPetsText);
            Print(StringConstants.ShowTypes);
            Print(StringConstants.CreateTypes);

            PrintNewLine();
            Print(StringConstants.ExitPetShopText);

        }
        private void Print(string value)
        {
            Console.WriteLine(value);
        }


        private void ListAllPets()
        {
            Clear();
            Print("List of all your pets");
            Print("");
            var pets = _petService.GetAllPets();


            foreach (var pet in pets)
            {

                Print($"Id: {pet.Id}");
                Print($"Type: {pet.Type.Name}");
                Print($"Name: {pet.Name}");
                Print($"Color: {pet.Color}");
                Print($"BirthDate: {pet.BirthDate.ToString("dd-MM-yyyy")}");
                Print($"Price: {pet.Price}" + "$");
                Print($"Sold: {pet.SoldDate.ToString("dd-MM-yyyy")}");
                Print("------------------------------------------");
            }
        }
        

            private void UpdateListAllPets()
            {
                Clear();
                Print("List of all your pets");
                Print("");
                var pets = _petService.GetAllPets();


                foreach (var pet in pets)
                {

                    Print($"Id: {pet.Id}");
                    Print($"Type: {pet.Type}");
                    Print($"Name: {pet.Name}");
                    Print($"Color: {pet.Color}");
                    Print($"Price: {pet.Price}" + "$");
                    Print($"Sold: {pet.SoldDate.ToString("dd-MM-yyyy")}");

                Print("------------------------------------------");
                }

            }

        private void CreatePet()
        {

            Clear();
            ReadTypes();

            Print(StringConstants.PetTypeText);
            int typeId = int.Parse(Console.ReadLine()!);
            PetType petType = _typeService.GetPetTypeById(typeId);

            
            Clear();
            Print(StringConstants.PetNameText);
            var petName = Console.ReadLine();

            Clear();
            Print(StringConstants.PetColorText);
            var petColor = Console.ReadLine();

            Clear();
            Print(StringConstants.PetBirthDayText);
            var petBirthDate = Console.ReadLine();

            Clear();
            Print(StringConstants.PetPriceText);
            var petPrice = Console.ReadLine();

            Clear();
            Print(StringConstants.PetSoldDateText);
            var petSoldDate = Console.ReadLine();

            var pet = new Pet
            {
                Type = petType,
                Name = petName,
                Color = petColor,
                BirthDate = Convert.ToDateTime(petBirthDate),
                Price = Convert.ToDouble(petPrice),
                SoldDate = Convert.ToDateTime(petSoldDate)

            };

            pet = _petService.Create(pet);

            Clear();
            Print($"Pet With Following Properties Created:");
            Print($"Id: {pet.Id}");
            Print($"Type: {pet.Type.Name}");
            Print($"Name: {pet.Name}");
            Print($"Color: {pet.Color}");
            Print($"BirthDate: {pet.BirthDate.ToString("dd-MM-yyyy")}");
            Print($"Price: {pet.Price}" + "$");
            Print($"Sold: {pet.SoldDate.ToString("dd-MM-yyyy")}");

            Print("");
            Print("------------------------------------------");
        }
    }

}

