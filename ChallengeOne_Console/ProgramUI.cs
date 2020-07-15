using ChallengeOne_Repository;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne_Console
{
    class ProgramUI
    {
        private MenuRepo _menuRepo = new MenuRepo(); //may need to change all instances to _menuContent for example
        //Method that runs/starts the app
        public void Run()
        {
            SeedMenu();
            Menu();
        }
        //Menu 
        private void Menu()
        {
            bool stillLooking = true;
            while (stillLooking)
            {
                //Display our options to user
                Console.WriteLine("Select a menu option:\n" +
                    "1. Add New Menu items\n" +
                    "2. View Menu\n" +
                    "3. Delete Menu Item\n" +
                    "4. Exit ");

                //get the users input
                string input = Console.ReadLine();

                //evaluate the input and act accordingly
                switch (input)
                {
                    case "1":
                        //Create new menu item
                        AddFoodToMenu();
                        break;
                    case "2":
                        //View Menu
                        ViewMenu();
                        break;
                    case "3":
                        //Delete Menu Item
                        DeleteMenuItem();
                        break;
                    case "4":
                        //Exit
                        Console.WriteLine("Order up!");
                        stillLooking = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        //Create  new menu items
        private void AddFoodToMenu()
        {
            Console.Clear();
            Menu newMenu = new Menu();

            //Meal Name
            Console.WriteLine("Enter name for meal");
            newMenu.MealName = Console.ReadLine();

            //Meal Number
            Console.WriteLine("Assign meal a number");
            string mealNumberAsString = Console.ReadLine();
            newMenu.MealNumber = int.Parse(mealNumberAsString);

            //Description
            Console.WriteLine("What is in this meal?");
            newMenu.Description = Console.ReadLine();

            //Ingredients
            Console.WriteLine("whats this made of?");
            newMenu.Ingredients = Console.ReadLine();

            //Price
            Console.WriteLine("How much is this going to cost?");
            string priceAsString = Console.ReadLine();
            newMenu.Price = double.Parse(priceAsString);

            _menuRepo.AddFoodToMenu(newMenu);

        }
        //view all menu that is saved
        private void ViewMenu()
        {
            Console.Clear();
            List<Menu> listofMenu = _menuRepo.ViewMenu();
            foreach(Menu menu in listofMenu)
            {
                Console.WriteLine($"Meal Number: {menu.MealNumber}\n" +
                    $"Meal Name: {menu.MealName}\n" +
                    $"Description: {menu.Description}\n" +
                    $"Ingredients: {menu.Ingredients}\n" +
                    $"Price: ${menu.Price}");
            }
        }

        //delete menu item
        public void DeleteMenuItem()
        {
            var fullMenu = _menuRepo.ViewMenu();
            
            //get menu item to remove
            Console.WriteLine("which item to remove");
            foreach (Menu item in fullMenu)
            {
                Console.WriteLine($"{item.MealNumber}){item.MealName}");
            }
            Console.WriteLine("enter number");

            var mealNum = int.Parse(Console.ReadLine());

            //Call Delete

            bool wasDeleted =_menuRepo.DeleteMenuItem(mealNum);

            //if deleted say so
            //otherwise say it could not be deleted
            if (wasDeleted)
            {
                Console.WriteLine("The menu item was successfully removed");
            }
            else
            {
                Console.WriteLine("Menu item could not be deleted");
            }

        }
        //seed method
        private void SeedMenu()
        {
            Menu itemOne = new Menu("Bacon Lovers Delight", 1, "Bacon Stuffed Bacon Cheeseburger served with side of Bacon", "Bacon, Beef, Cheddar Cheese, Kaiser Roll, More Bacon!", 9.49);
            Menu itemTwo = new Menu("Veggie Pizza", 2, "Our Homemade Dough Topped with all of our veggies", "Pizza Dough, Sauce, Cheese Blend, Onions, Green Peppers, Olives, Mushrooms, Banana Peppers", 12.99);

            _menuRepo.AddFoodToMenu(itemOne);
            _menuRepo.AddFoodToMenu(itemTwo);
        }
    }
}
