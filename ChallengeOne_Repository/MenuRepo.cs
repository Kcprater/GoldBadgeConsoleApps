using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne_Repository
{
    public class MenuRepo
    {
        private List<Menu> _menuContent = new List<Menu>();

        //Add menu item
        public bool AddFoodToMenu(Menu menu)
        {
            int startingCount = _menuContent.Count;
            _menuContent.Add(menu);
            bool wasAdded = (_menuContent.Count > startingCount) ? true : false;
            return wasAdded;
        }
        //Get Full Menu
        public List<Menu> ViewMenu()
        {
            return _menuContent;
        }

        //Get By Meal Number
        public Menu GetByMealNumber(int mealNum)
        {
            foreach(Menu item in _menuContent)
            {
                if (item.MealNumber == mealNum)
                {
                    return item;
                }
            }
            return null;
        }
        //Delete Menu Item
        public bool DeleteMenuItem(int mealNum)
        {
            var existingItem = GetByMealNumber(mealNum);
            return _menuContent.Remove(existingItem);
        }
    }
}
