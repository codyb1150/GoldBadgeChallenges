using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge_Repository
{
    public enum EventType
    {
        Golf = 1,
        Bowling,
        AmusementPark,
        Concert
    }
    public class OutingContrustor
    {
        public class Outing
        {
            public EventType Eventt { get; set; }
            public int NumberAttended { get; set; }
            public DateTime Date { get; set; }
            public double CostPerPerson { get; set; }
            public double TotalCostForEvent { get; set; }
            

            public Outing() { }

            public Outing(EventType eventt, int numberAttended, DateTime date, double costPerPerson, double totalCostForEvent)
            {
                Eventt = eventt;
                NumberAttended = numberAttended;
                Date = date;
                CostPerPerson = costPerPerson;
                TotalCostForEvent = totalCostForEvent;
            }
        }
    }
}



