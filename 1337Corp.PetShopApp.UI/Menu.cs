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
        private IOwnerService _ownerService;

        public Menu(IPetService petService, IPetTypeService typeService, IOwnerService ownerService)
        {
            _petService = petService;
            _typeService = typeService;
            _ownerService = ownerService;
        }

        public void Start()
        {
            _ownerService.InitData();
            _typeService.InitData();
            _petService.InitData();
            
            ShowIntroMessage();
            StartLoopMenu();
        }

        private void ShowIntroMessage()
        {
            Console.WriteLine(StringConstants.IntroMessageText);
        }
        // MAIN MENU
        private void StartLoopMenu()
        {
            Print(StringConstants.MenuMainMenuText);
            ShowMainMenu();
            int choice;
            while ((choice = GetSelection()) != 0)
            {
                if (choice == 1)
                {
                    PetsMenu();
                }

                if (choice == 2)
                {
                    TypeMenu();
                }

                if (choice == 3)

                {
                    OwnersMenu();
                }
               
                if (choice == 0)
                {
                    ExitProgram();
                }
            }
        }

        //MENU : PETS
        private void PetsMenu()
        {
            Clear();
            PetsMenuText();

            int choice;
            while ((choice = GetSelection()) != 0)
            {
                
                if (choice == 1)
                {
                    ListAllPets();
                    PetsMenuText();
                }

                if (choice == 2)
                {
                    ListCheapestPets();
                    PetsMenuText();
                }

                if (choice == 3)
                {
                    CreatePet();
                    PetsMenuText();
                }

                if (choice == 4)
                {
                    Update();
                    PetsMenuText();
                }

                if (choice == 5)
                {
                    DeletePet();
                    PetsMenuText();
                }

                if (choice == 9)
                {
                    Clear();
                    StartLoopMenu();
                }
            }
        }
        private void PetsMenuText()
        {
            Print("PETS");
            Print(StringConstants.PrintAllPetsListText);
            Print(StringConstants.CheapestPetsText);
            PrintNewLine();
            Print(StringConstants.CreateNewPetText);
            Print(StringConstants.UpdatePetText);
            Print(StringConstants.DeletePetText);
            PrintNewLine();
            Print(StringConstants.MainMenu);
        }

        //PET: CRUD
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

            ReadOwners();
            Print(StringConstants.PetOwnerNameText);
            int ownerId = int.Parse(Console.ReadLine()!);
            Owner petOwnerName = _ownerService.GetOwnerById(ownerId);
            Clear();

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
                Owner = petOwnerName,
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
            Print($"Owner: {pet.Owner.Name}");
            Print($"Color: {pet.Color}");
            Print($"BirthDate: {pet.BirthDate.ToString("dd-MM-yyyy")}");
            Print($"Price: {pet.Price}" + "$");
            Print($"Sold: {pet.SoldDate.ToString("dd-MM-yyyy")}");

            Print("");
            Print("------------------------------------------");
        }

        private void Update()
        {
            Clear();
            UpdateListAllPets();
            Print("");

            Print(StringConstants.UpdatedEnterPetID);
            var updateId = int.Parse(Console.ReadLine()!);
            var updatePet = _petService.SearchPetById(updateId);

            Clear();
            Print(StringConstants.UpdatedPetName);
            var updatedName = Console.ReadLine();

            ReadOwners();
            Print(StringConstants.UpdatedEnterOwnerId);
            int ownerId = int.Parse(Console.ReadLine()!);
            Owner updatePetOwner = _ownerService.GetOwnerById(ownerId);

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
                Owner = updatePetOwner,
                Color = updatedColor,
                SoldDate = updatedSoldDate,
                Price = updatedPrice
            });

            Print($"{updatePet.Name} was updated.");
        }

        private void DeletePet()
        {
            Clear();
            ListAllPets();

            Console.WriteLine(StringConstants.DeleteEnterPetId);

            var petId = Console.ReadLine();
            int selectionId = int.Parse(petId);

            {
                _petService.Delete(selectionId);
                Clear();
                Console.WriteLine($"Pet with ID '{petId}', has been deleted.");
            }
        }

        private void ListAllPets()
        {
            Clear();
            Print("List of all your pets");
            Print("");
            var pets = _petService.GetAll();

            foreach (var pet in pets)
            {
                Print($"Id: {pet.Id}");
                Print($"Type: {pet.Type.Name}");
                Print($"Owner: {pet.Owner.Name}");
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
            var pets = _petService.GetAll();

            foreach (var pet in pets)
            {
                Print($"Id: {pet.Id}");
                Print($"Type: {pet.Type.Name}");
                Print($"Owner: {pet.Owner.Name}");
                Print($"Name: {pet.Name}");
                Print($"Color: {pet.Color}");
                Print($"BirthDate: {pet.BirthDate.ToString("dd-MM-yyyy")}");
                Print($"Price: {pet.Price}" + "$");
                Print($"Sold: {pet.SoldDate.ToString("dd-MM-yyyy")}");
                Print("------------------------------------------");
            }
        }

        //MENU : OWNERS
        private void OwnersMenu()
        {
            Clear();
            OwnersMenuText();

            int choice;
            while ((choice = GetSelection()) != 0)
            {
                if (choice == 1)
                {
                    ReadOwners();
                    OwnersMenuText();
                }

                if (choice == 2)
                {
                    CreateOwner();
                    OwnersMenuText();
                }

                if (choice == 3)
                {
                    UpdateOwner();
                    OwnersMenuText();
                }

                if (choice == 4)

                {
                    DeleteOwner();
                    OwnersMenuText();
                }

                if (choice == 9)
                {
                    Clear();
                    StartLoopMenu();
                }
            }
        }

        private void OwnersMenuText()
        {
            Print("OWNERS");
            Print(StringConstants.PrintAllOwnersListText);
            PrintNewLine();
            Print(StringConstants.CreateNewOwnerText);
            Print(StringConstants.UpdateOwnerText);
            Print(StringConstants.DeleteOwnerText);
            PrintNewLine();
            Print(StringConstants.MainMenu);
            PrintNewLine();
        }
        private void ReadOwners()
        {
            Clear();
            Print("List of all owners:");
            PrintNewLine();

            foreach (var owner in _ownerService.GetAll())
            {
                Print($"ID: {owner.Id} - {owner.Name}");
            }
            Print("");
            Print("------------------------------------------");
            PrintNewLine();
        }

        private void CreateOwner()
        {
            Clear();
            Print("Type the new owners name");
            var ownerName = Console.ReadLine();
            var owner = new Owner
            {
                Name = ownerName
            };

            owner = _ownerService.CreateOwner(owner);
            ReadOwners();
            Print($"Owner: '{ownerName}' was added");
        }

        private void UpdateOwner()
        {
            throw new NotImplementedException();
        }

        private void DeleteOwner()
        {
            Clear();
            ReadOwners();

            Console.WriteLine(StringConstants.DeleteEnterPetId);

            var ownerId = Console.ReadLine();
            int selectionId = int.Parse(ownerId);

            {
                _ownerService.Delete(selectionId);
                Clear();
                Console.WriteLine($"Owner with ID '{ownerId}', has been deleted.");
            }
        }

        //MENU: TYPE
        private void TypeMenu()
        {
            Clear();
            Print("TYPES");
            TypeMenuText();

            
            int choice;
            while ((choice = GetSelection()) != 0)
            {

                if (choice == 1)
                {
                    ReadTypes();
                    TypeMenuText();
                }

                if (choice == 2)
                {
                    SearchForTypesOfPet();
                    TypeMenuText();
                }

                if (choice == 3)
                {
                    CreateType();
                    TypeMenuText();
                }
                if (choice == 9)
                {
                    Clear();
                    StartLoopMenu();
                }
            } 
        }

        private void TypeMenuText()
        {
            
            Print(StringConstants.ShowTypes);
            Print(StringConstants.SearchByPetTypeText);
            Print(StringConstants.CreateTypes);
            PrintNewLine();
            Print(StringConstants.MainMenu);
        }

        private void ReadTypes()
        {

            Clear();
            Print("List of all types:");

            foreach (var type in _typeService.GetAll())
            {
                Print($"ID: {type.Id} - {type.Name}");
            }
            Print("");
            Print("------------------------------------------");
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

        private void SearchForTypesOfPet()
        {
            Clear();
            Print(StringConstants.SearchForTypes);
            Print("What animal do you want to search for? use small letters (cat)");
            PrintNewLine();
            var TypesSearch = Console.ReadLine();
            Clear();

            foreach (var pet in _petService.GetPetsByType(TypesSearch))
            {
                Print($"ID: {pet.Id}, Type: {pet.Type.Name}, Name: {pet.Name}, BirthDate: {pet.BirthDate.ToString("dd-MM-yyyy")}, Color: {pet.Color}, Price: {pet.Price}, Sold on: {pet.SoldDate.ToString("dd-MM-yyyy")}");

                Print("------------------------------------------");
            }
        }

        private void ListCheapestPets()
        {
            List<Pet> pets = _petService.GetAll();
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
        
        //use-alot-functions made into methods
        private int GetSelection()
        {
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
        private void ExitProgram()
        {
            Environment.Exit(0);
        }
        private void ShowMainMenu()
        {
            PrintNewLine();
            Print(StringConstants.MenuGuideText);
            PrintNewLine();
            Print(StringConstants.MenuPets);
            Print(StringConstants.MenuTypes);
            Print(StringConstants.MenuOwners);
            PrintNewLine();
            Print(StringConstants.ExitPetShopText);
        }

        private void Print(string value)
        {
            Console.WriteLine(value);
        }

    }

}

