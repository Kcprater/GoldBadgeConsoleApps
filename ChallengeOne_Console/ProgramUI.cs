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
        private MenuRepo _menuRepo = new MenuRepo();
        //Method That Starts The App
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
                //Display Our Options To The User
                Console.WriteLine(
                    "Welcome To Komodo Cafe!\n\n" +
                    "Select a menu option to continue:\n" +
                    "1. Add New Menu items\n" +
                    "2. View Menu\n" +
                    "3. Delete Menu Item\n" +
                    "4. Exit ");

                //Get User Input
                string input = Console.ReadLine();

                //Evaulate Input & Act Accordingly
                switch (input)
                {
                    case "1":
                        //Create New Menu Item
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
                Console.WriteLine("Press any key to close menu!");
                Console.ReadKey();
                Console.Clear();
            }
        }
        //Create New Menu Items
        private void AddFoodToMenu()
        {
            Console.Clear();
            Menu newMenu = new Menu();

            //Meal Name
            Console.WriteLine("What should we call this meal?");
            newMenu.MealName = Console.ReadLine();

            //Meal Number
            Console.WriteLine("Assign meal a number");
            string mealNumberAsString = Console.ReadLine();
            newMenu.MealNumber = int.Parse(mealNumberAsString);

            //Description
            Console.WriteLine("What is in this meal?");
            newMenu.Description = Console.ReadLine();

            //Ingredients
            Console.WriteLine("But what is this made of?");
            newMenu.Ingredients = Console.ReadLine();

            //Price
            Console.WriteLine("How much is this going to cost?");
            string priceAsString = Console.ReadLine();
            newMenu.Price = double.Parse(priceAsString);

            _menuRepo.AddFoodToMenu(newMenu);

        }
        //View All Menu Items That Are Saved (Currently only seeded items below)
        private void ViewMenu()
        {
            Console.Clear();
            List<Menu> listofMenu = _menuRepo.ViewMenu();
            foreach(Menu menu in listofMenu)
            {
                Console.WriteLine(
                    $"Meal Number: {menu.MealNumber}\n" +
                    $"Meal Name: {menu.MealName}\n" +
                    $"Description: {menu.Description}\n" +
                    $"Ingredients: {menu.Ingredients}\n" +
                    $"Price: ${menu.Price}\n");
            }
        }

        //Delete Menu Item
        public void DeleteMenuItem()
        {
            var fullMenu = _menuRepo.ViewMenu();
            
            //get menu item to remove
            Console.WriteLine("Which meal would you like to remove?");
            foreach (Menu item in fullMenu)
            {
                Console.WriteLine($"{item.MealNumber}){item.MealName}");
            }
            Console.WriteLine("Enter which meal to throw out!");

            var mealNum = int.Parse(Console.ReadLine());

            //Call Delete

            bool wasDeleted =_menuRepo.DeleteMenuItem(mealNum);

            if (wasDeleted)
            {
                Console.WriteLine("Let's go ahead and 86 this from the menu!");
            }
            else
            {
                Console.WriteLine("Something went wrong. Try again.");
            }

        }
        //seed method
        private void SeedMenu()
        {
            Menu itemOne = new Menu("Bacon Lovers Delight", 1, "Bacon Stuffed Bacon Cheeseburger served with side of Bacon", "Bacon, Beef, Cheddar Cheese, Kaiser Roll, More Bacon!", 9.49);
            Menu itemTwo = new Menu("Veggie Pizza", 2, "Our Homemade Dough Topped with all of our veggies", "Pizza Dough, Sauce, Three Cheese Blend, Onions, Green Peppers, Olives, Mushrooms, Banana Peppers", 12.99);
            Menu itemThree = new Menu("Chicago Bills HotDog", 3, "Jumbo Chicago HotDog served with waffle fries", "What ever hotdogs are made from and the fries are made from potatos", 7.19);

            _menuRepo.AddFoodToMenu(itemOne);
            _menuRepo.AddFoodToMenu(itemTwo);
            _menuRepo.AddFoodToMenu(itemThree);
        }
    }
}
