using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1337Corp.PetShopApp.UI
{
    public class StringConstants
    {
       
        public static readonly string IntroMessageText = "Welcome to the Pet Shop!";
      
        //Menu
        public const string MenuGuideText = "Type in your choice:";
        public const string PrintAllPetsListText = "1: Show all pets";
        public const string SearchByPetTypeText = "2: Search for types of pet";
        public const string CreateNewPetText = "3: Create a new pet";
        public const string UpdatePetText = "4: Update a pet";
        public const string DeletePetText = "5: Delete pet";
        public const string CheapestPetsText = "6: Sort Petlist by Price (low to high)";
        public const string ShowTypes = "7: Show pet types";
        public const string CreateTypes = "8: Create Type";
        public const string ExitPetShopText = "0: Exit Pet Shop";

        //Create & Update pet
        public const string PetTypeText = "Type? Enter ID";
        public const string PetNameText = "Name?";
        public const string PetOwnerNameText = "Owner?";
        public const string PetColorText = "Color?";
        public const string PetPriceText = "Price? (USD)";
        public const string PetSoldDateText = "Sold when? (dd-mm-yyyy)";
        public const string PetBirthDayText = "Date of birth? (dd-mm-yyyy)";
        
        public const string UpdatedEnterPetID = "Enter ID to update pet";
        public const string UpdatedPetName = "Enter your pets new name:";
        public const string UpdatedPrice = "Enter your pets new price:";
        public const string UpdatedColor = "Enter new color";
        public const string UpdatedSoldDate = "Enter new sold date";
        //Delete pet
        public const string DeleteEnterPetId = "Enter ID to delete pet";


        //Create Type
        public const string ValueCannotBeNullText = "Value cannot be null";
        public const string SearchForTypes = "Find pets available by type..";
    }
}