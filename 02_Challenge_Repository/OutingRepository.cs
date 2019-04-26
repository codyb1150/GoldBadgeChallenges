using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _02_Challenge_Repository.OutingContrustor;

namespace _02_Challenge_Repository
{
    public class OutingRepository
    {
        private List<Outing> _listOfContent = new List<Outing>();

        public void AddToList(Outing content)
        {
            _listOfContent.Add(content);
        }

        public List<Outing> GetOutingList()
        {
            return _listOfContent;
        }
        public void RemoveOutingFromList(EventType eventt)
        {
            foreach (Outing content in _listOfContent)
            {
                if (content.Eventt == eventt)
                {
                    _listOfContent.Remove(content);
                    break;
                }
            }
        }

        public void AddToList(OutingContrustor newContent)
        {
            throw new NotImplementedException();
        }

        public double CombinedTotalForOuting(EventType outingType)
        {
            double total = 0;
            foreach (Outing outing in _listOfContent)
            {
                if (outing.Eventt == outingType)
                {
                    total += outing.TotalCostForEvent;
                }
            }
            return total;
        }

        public double TotalForAllOutings(EventType Golf, EventType bowling, EventType amusementPark, EventType concert)
        {
            double total = 0;
            foreach (Outing outing in _listOfContent)
            {
                total += outing.TotalCostForEvent;
            }
            return total;
        }

    }
}
