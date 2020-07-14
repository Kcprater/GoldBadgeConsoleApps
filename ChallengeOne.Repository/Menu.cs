using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne_Repository
{
    //public enum MealNumber
    //{
    //    MealOne,
    //    MealTwo,
    //    MealThree,
    //}
    public class Menu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; } //might need to be a enum
        public double Price { get; set; }
        public Menu() { }
        public Menu(string mealName, int mealNumber, string description, string ingredients, double price)
        {
            MealName = mealName;
            MealNumber = mealNumber;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
