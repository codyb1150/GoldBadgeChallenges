using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _03_Challenge_Repository.Cars_Constructor;

namespace _03_Challenge_Repository
{
    public class Cars_Repository
    {
        private List<Cars> _listOfContent = new List<Cars>();
        

        public void AddToList(Cars content)
        {
            _listOfContent.Add(content);
        }

        public List<Cars> GetList()
        {
            return _listOfContent;
        }

        public List<Cars> GetListByCategories(CarType type)
        {
            List<Cars> _newListCars = new List<Cars>();
            foreach (Cars content in _listOfContent)
            {
                if (content.Car == type)
                {
                    _newListCars.Add(content);
                }
            }
            return _newListCars;
        }

        public void RemovCarFromList(string carVin)
        {
            foreach (Cars content in _listOfContent)
            {
                if (content.CarVIN == carVin)
                {
                    _listOfContent.Remove(content);
                    break;
                }
            }
        }
    }
}
