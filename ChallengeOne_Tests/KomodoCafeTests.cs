using System;
using System.Collections.Generic;
using ChallengeOne_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeOne_Tests
{
    [TestClass]
    public class KomodoCafeTests
    {
        [TestMethod]
        public void AddFoodToMenu_ShouldGetCorrectBoolean()
        {
            //Arrange
            Menu food = new Menu();
            MenuRepo repo = new MenuRepo();
            //Act
            bool addResult = repo.AddFoodToMenu(food);
            //Assert
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void ViewMenu_ShouldReturnMenu()
        {
            //Arrange
            Menu food = new Menu();
            MenuRepo repo = new MenuRepo();
            repo.AddFoodToMenu(food);
            //Act
            List<Menu> foods = repo.ViewMenu();
            bool menuHasFood = foods.Contains(food);
            //Assert
            Assert.IsTrue(menuHasFood);
        }
        [TestMethod]
        public void GetMealByNumber_ShouldReturnMenu()
        {
            //Arrange
            Menu meal = new Menu();
            MenuRepo repo = new MenuRepo();
            meal = new Menu("Bacon Lovers Delight", 1, "Bacon Stuffed Bacon Cheeseburger served with side of Bacon", "Bacon, Beef, Cheddar Cheese, Kaiser Roll, More Bacon!", 9.49);
            repo.AddFoodToMenu(meal);
            //Act
            Menu searchResult = repo.GetByMealNumber(1);
            //Assert
            Assert.AreEqual(meal, searchResult);
        }

        private MenuRepo _repo;
        private Menu _meal;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuRepo();
            _meal = new Menu("Bacon Lovers Delight", 1, "Bacon Stuffed Bacon Cheeseburger served with side of Bacon", "Bacon, Beef, Cheddar Cheese, Kaiser Roll, More Bacon!", 9.49);
            _repo.AddFoodToMenu(_meal);
        }
        [TestMethod]
        public void DeleteMenuItem_ShouldReturnTrue()
        {
            //Arrange
            Menu meal = _repo.GetByMealNumber(1);
            //Act
            bool removeResult = _repo.DeleteMenuItem(meal.MealNumber);
            //Assert
            Assert.IsTrue(removeResult);
        }
    }
}
