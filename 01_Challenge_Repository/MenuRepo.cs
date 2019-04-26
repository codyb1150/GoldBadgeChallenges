using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _01_Challenge_Repository.Menu;

namespace _01_Challenge_Repository
{
    public class MenuRepo
    {
        private List<Menu> _listOfContent = new List<Menu>();
        
        public void AddToList(Menu content)
        {
            _listOfContent.Add(content);
        }

        public List<Menu> GetMealList()
        {
            return _listOfContent;
        }

        public void RemoveMealFromList(int mealNumber)
        {
            foreach (Menu content in _listOfContent)
            {
                if (content.MealNumber == mealNumber)
                {
                    _listOfContent.Remove(content);
                    break;
                }
            }
        }
    }
}
