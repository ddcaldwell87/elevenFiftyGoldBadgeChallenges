using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge_1
{
    class ProgramUI
    {
        private MenuRepository _menuRepo = new MenuRepository();

        public void Run()
        {
            CreateSeedMenu();

            RunStartMenu();
        }

        private void CreateSeedMenu()
        {
            List<string> ingsList = new List<string>();
            ingsList.Add("patty");
            ingsList.Add("buns");

            Menu item1 = new Menu(1, "Hamburger", "A patty between two buns", ingsList, 8.75m);
            Menu item2 = new Menu(2, "Cheeseburger", "A patty between two buns", ingsList, 9.75m);
            Menu item3 = new Menu(3, "Turkey Burger", "A patty between two buns", ingsList, 10.75m);

            _menuRepo.AddItemToMenu(item1);
            _menuRepo.AddItemToMenu(item2);
            _menuRepo.AddItemToMenu(item3);
        }

        private void RunStartMenu()
        {
            ShowStartMenu();

            bool runProgram = true;
            
            while (runProgram)
            {
                int choice = GetMenuChoice();

                switch (choice)
                {
                    case 1:
                        AddItemToMenu();
                        break;
                    case 2:
                        DeleteItemFromMenu();
                        break;
                    case 3:
                        GetMenu();
                        break;
                    case 4:
                        GetItemDetails();
                        break;
                    case 5:
                        runProgram = false;
                        break;
                    default:
                        Console.WriteLine("Please pick a valid menu choice.");
                        Thread.Sleep(2000);
                        RunStartMenu();
                        break;
                }
            }
        }

        private void ShowStartMenu()
        {
            Console.Clear();

            Console.WriteLine("Komodo Cafe Management Software \n" +
                "1. Add item to menu. \n" +
                "2. Delete item from menu. \n" +
                "3. View entire menu. \n" +
                "4. Get meal details. \n" +
                "5. Exit Program.");
        }

        private int GetMenuChoice()
        {
            Console.WriteLine("Please choice a menu choice.");
            string userChoice = Console.ReadLine();
            int choice = Int32.Parse(userChoice);

            return choice;
        }

        private void AddItemToMenu()
        {
            Console.Clear();

            Console.WriteLine("What is the name of the item you would like to add?");
            string mealName = Console.ReadLine();

            Console.WriteLine("What menu number do you want to put this at?");
            string mealNum = Console.ReadLine();
            int mealNumAsInt = int.Parse(mealNum);

            Console.WriteLine("Enter a description of this menu item.");
            string desc = Console.ReadLine();

            var ings = AddItemToIngsList();
            
            Console.WriteLine("Please enter the price for this item.");
            string price = Console.ReadLine();
            decimal priceAsDecimal = decimal.Parse(price);

            Menu itemAdded = new Menu(mealNumAsInt, mealName, desc, ings, priceAsDecimal);
            _menuRepo.AddItemToMenu(itemAdded);

            Console.WriteLine("Item successfully added to menu.");
            Thread.Sleep(3000);
            RunStartMenu();

        }

        private List<string> AddItemToIngsList()
        {
            Console.WriteLine("Enter a list of ingredients for this item.");

            var ingList = new List<string>();

            string resume = "";

            while (resume != "n")
            {
                Console.WriteLine("Enter an ingredient:");
                string ingItem = Console.ReadLine();

                ingList.Add(ingItem);

                Console.WriteLine("Add another ingredient? (y/n)");
                resume = Console.ReadLine();
            }
            return ingList;
        }

        private void DeleteItemFromMenu()
        {
            Console.Clear();

            Console.WriteLine("What item would you like to remove from the menu?");
            var mealName = Console.ReadLine();
            var selectedItem = _menuRepo.FindMenuItem(mealName);

            _menuRepo.DeleteItemFromMenu(selectedItem);

            Console.WriteLine("Item deleted successfully.");
            Thread.Sleep(3000);
            RunStartMenu();
        }

        private void GetItemDetails()
        {
            Console.Clear();

            Console.WriteLine("What item would you like to see?");
            var item = Console.ReadLine();
            var selectedItem = _menuRepo.FindMenuItem(item);

            Console.WriteLine($"Meal Number: {selectedItem.MealNum} \n" +
                $"Meal Name: {selectedItem.MealName} \n" +
                $"Meal Description: {selectedItem.Desc} \n" +
                $"Meal Ingredients: {selectedItem.Ingredients} \n" +
                $"Meal Price: {selectedItem.Price}");

            ReturnToMenu();
        }

        private void GetMenu()
        {
            Console.Clear();

            var menu = _menuRepo.GetMenu();

            foreach(var item in menu)
            {
                Console.WriteLine(item.MealName);
            }

            ReturnToMenu();
        }

        private void ReturnToMenu()
        {
            Console.WriteLine("1. Go back to menu.");
            int choice = GetMenuChoice();
            if (choice == 1)
                RunStartMenu();
        }
    }
}
