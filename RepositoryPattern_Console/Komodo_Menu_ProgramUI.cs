using Komodo_Menu_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Menu_Console
{
    public class Komodo_Menu_ProgramUI
    {
        private bool _isRunning = true;

        private readonly Menu_Content_Repository _repo = new Menu_Content_Repository();

        public void Start()
        {
            //Seeds data into our app.
            SeedContentList();

            //Run Menu method
            RunMenu();
        }

        private void RunMenu()
        {
            while (_isRunning)
            {
                string userInput = GetMenuSelection();
                OpenMenuItem(userInput);
            }
        }

        private string GetMenuSelection()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Komodo Cafe! We look forward to serving you. Please Choose from the menu below.\n" +
                            "Select Menu Item:\n" +
                            "1. Show The Entire Menu\n" +
                            "2. Find A Specfic Item By Name\n" +
                            "3. Add An Item\n" +
                            "4. Update Existing Item Description\n" +
                            "5. Remove An Item\n" +
                            "6. Exit\n");

            string userInput = Console.ReadLine();
            return userInput;
        }

        private void OpenMenuItem(string userInput)
        {
            Console.Clear();

            switch (userInput)
            {
                case "1":
                    //Show all menu
                    DisplayEnitreMenu();
                    break;
                case "2":
                    //Display item by title
                    DisplayContentByItem();
                    break;
                case "3":
                    //Add new item
                    AddAnItem();
                    break;
                case "4":
                    //Update item description
                    UpdateExistingDescription();
                    break;
                case "5":
                    //Delete some content
                    DeleteContent();
                    break;
                case "6":
                    //Exit
                    _isRunning = false;
                    return;
                default:
                    Console.WriteLine("I'm sorry we dont offer that. Please press any button to return to the main menu.");
                    GetMenuSelection();
                    return;
            }

        }

        private void DisplayEnitreMenu()
        {
            List<Menu_Content> listOfContent = _repo.GetAllMenuContent();

            foreach (Menu_Content content in listOfContent)
            {
                DisplayContent(content);
            }

            PressAnyKeyToReturnToMainMenu();
        }

        private void DisplayContentByItem()
        {
            Console.Write("Enter a title: ");
            string drink = Console.ReadLine();

            Menu_Content content = _repo.GetContentByDrink(drink);

            if (content != null)
            {
                DisplayContent(content);

                PressAnyKeyToReturnToMainMenu();
            }
            else
            {
                Console.WriteLine("Invalid Selection. Press any key to return to main menu.");
                GetMenuSelection();
            }
        }
      
        private void DisplayContent(Menu_Content content)
        {
            Console.WriteLine($"Item: {content.Drink}\n" +
                                $"Description: {content.Description}\n" +
                                $"Price: {content.Price}\n" +
                                $"Ingredient List: {content.Ingredient}\n");
        }

        private void AddAnItem()
        {
            Console.Clear();
            Console.WriteLine("Enter an item: ");
            string drink = Console.ReadLine();

            Console.WriteLine("Enter a description: ");
            string description = Console.ReadLine();

            Console.WriteLine("Enter a price: ");
            int releaseYear = int.Parse(Console.ReadLine());

            IngrediemtType ingredient = GetIngredients();

            Menu_Content content = new Menu_Content(drink, description, releaseYear, ingredient);

            _repo.AddContentToMenu(content);

            PressAnyKeyToReturnToMainMenu();
        }

        private IngrediemtType GetIngredients()
        {
            Console.WriteLine("Select an ingredient list:\n" +
                            "1. Esspresso / Milk / Flavorin / Steamed\n" +
                            "2. Coffee / Water\n" +
                            "3. Esspresso / Water\n" +
                            "4. Milk / Flavor / Espresso\n" +
                            "5. Steamed Milk\n");

            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        return IngrediemtType.Latte;
                    case "2":
                        return IngrediemtType.Coffee;
                    case "3":
                        return IngrediemtType.Americano;
                    case "4":
                        return IngrediemtType.Machiato;
                    case "5":
                        return IngrediemtType.Misto;
                }
            }
        }

        private void UpdateExistingDescription()
        {
            Console.WriteLine("Enter item to be edited: ");
            string drink = Console.ReadLine();

            Console.WriteLine("Enter new description.");
            string description = Console.ReadLine();

            _repo.UpdateDrinkByDescription(drink, description);

            PressAnyKeyToReturnToMainMenu();
        }

        private void DeleteContent()
        {
            Console.WriteLine("Enter title to be deleted: ");

            _repo.DeleteContentByItem(Console.ReadLine());

            PressAnyKeyToReturnToMainMenu();
        }

        public void PressAnyKeyToReturnToMainMenu()
        {
            Console.WriteLine("Press any key to return to Main Menu.");
            Console.ReadKey();
            RunMenu();
        }

        //Seed Content
        private void SeedContentList()
        {
            Menu_Content latte = new Menu_Content("Latte", "A velvity mixtrue of espresso and steamed milk.", 4, IngrediemtType.Latte);
            Menu_Content blackCoffee = new Menu_Content("Black Coffee", "Just water and drip coffee.", 2, IngrediemtType.Coffee);
            Menu_Content americano = new Menu_Content("Americano", "Hot water and esspresso, purely divine.", 3, IngrediemtType.Americano);
            Menu_Content machiato = new Menu_Content("Machiato", "Flavor, esspresso, steamed milk with a carmel drizzle.... In that order.", 5, IngrediemtType.Machiato);
            Menu_Content misto = new Menu_Content("Misto", "Steamed milk with flavor, for the kids.", 2, IngrediemtType.Misto);

            _repo.AddContentToMenu(latte);
            _repo.AddContentToMenu(blackCoffee);
            _repo.AddContentToMenu(americano);
            _repo.AddContentToMenu(machiato);
            _repo.AddContentToMenu(misto);
        }
    }
}
