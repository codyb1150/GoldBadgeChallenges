using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Challenge_Repository
{
    public enum CarType
    {
        Gas = 1,
        Electric,
        Hybrid
    }
    public class Cars_Constructor
    {

        public class Cars
        {

            public CarType Car { get; set; }
            public double Milage { get; set; }
            public double MilesPerGallon { get; set; }
            public string CarModel { get; set; }
            public string CarMake { get; set; }
            public double WrecksPerMonth { get; set; }
            public string CarVIN { get; set; }

            public Cars () { }
            public Cars (CarType car, double mileage, double milesPerGallon, string carModel, string carMake, double wrecksPerMonth, string carVin)
            {
                Car = car;
                CarMake = carMake;
                CarModel = carModel;
                Milage = mileage;
                MilesPerGallon = milesPerGallon;
                WrecksPerMonth = wrecksPerMonth;
                CarVIN = carVin;
            }
        }
    }
}
