using _1337Corp.PetShopApp.Core.IServices;
using _1337Corp.PetShopApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1337Corp.PetShopApp.UI
{
    public class Menu
    {

        private IPetService _service;

        public Menu(IPetService service)
        {
            _service = service;
        }

        public void Start()
        {
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
            while ((choice = GetMainMeniSelection()) !=0)
            {

                if (choice == 1)
                {
                    ListAllPets();
                }

                if (choice == 2)
                {
                    ListAllPets();
                }

                if (choice == 3)
                {
                    CreatePet();
                }

                if (choice == 4)
                {
                    ListAllPets();
                }

                if (choice == 5)
                {
                    DeletePet();
                }

                if (choice == 6)
                {
                    ListAllPets();
                }

                if (choice == 7)
                {
                    ListAllPets();
                }

                if (choice == 0)
                {
                    ExitProgram();
                }
            }

        }

        private void ExitProgram()
        {
            Environment.Exit(0);
        }

        private void DeletePet()
        {
            Console.WriteLine(StringConstants.DeleteEnterPetId);
            var petId = Console.ReadLine();
            int selectionId = Int32.Parse(petId);
            
            {
                var deletedPetName = _service.Delete(selectionId);
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
            Print(StringConstants.SortPetsByPriceText);
            Print(StringConstants.CheapestPetsText);

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
            var pets = _service.GetAllPets();
            foreach (var pet in pets)
            {
                Print("");
                Print($"Id: {pet.Id.Value}");
                Print($"Type: {pet.Type.Name}");
                Print($"Name: {pet.Name}");
                Print($"Color: {pet.Color}");
                Print($"BirthDate: {pet.BirthDate.ToString("dd-MM-yyyy")}");
                Print($"Price: {pet.Price}" + "$");
                Print($"Sold: {pet.SoldDate.ToString("dd-MM-yyyy")}");
            }

            Print("");
            Print("------------------------------------------");
        }

        private void CreatePet()
        {

            Clear();

            Print(StringConstants.PetTypeText);
            PetType newPetType = new PetType(); 
            var petType = Console.ReadLine();
            newPetType.Name = petType;

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
                Type = newPetType,
                Name = petName,
                Color = petColor,
                BirthDate = Convert.ToDateTime(petBirthDate),
                Price = Convert.ToDouble(petPrice),
                SoldDate = Convert.ToDateTime(petSoldDate)

            };

            pet = _service.Create(pet);

            Clear();
            Print($"Pet With Following Properties Created:");
            Print($"Id: {pet.Id.Value}");
            Print($"Type: {pet.Type.Name}");
            Print($"Name: {pet.Name}");
            Print($"Color: {pet.Color}");
            Print($"BirthDate: {pet.BirthDate.ToString("dd-MM-yyyy")}");
            Print($"Price: {pet.Price}" + "$");
            Print($"Sold: {pet.SoldDate.ToString("dd-MM-yyyy")}");

            PrintNewLine();
            PrintNewLine();
            PrintNewLine();
            PrintNewLine();
        }

    }
}
