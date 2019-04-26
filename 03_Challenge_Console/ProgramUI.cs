using _03_Challenge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _03_Challenge_Repository.Cars_Constructor;

namespace _03_Challenge_Console
{
    public class ProgramUI
    {
        private Cars_Repository _newCarRepo = new Cars_Repository();

        public void Run()
        {
            RunMenu();
        }

        public void RunMenu()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("What would you like to do? Enter the number.\n" +
                    "1. Add A Car\n" +
                    "2. Remove A Car\n" +
                    "3. Update A Car\n" +
                    "4. View All Cars In A Category\n" +
                    "5. Exit");
                string input = Console.ReadLine();
                switch (input)
                {

                    case "1":
                        AddToList();
                        break;
                    case "2":
                        RemoveCarFromList();
                        break;
                    case "3":
                        UpdateACar();
                        break;
                    case "4":
                        ViewCarByCategory();
                        break;
                    case "5":
                        running = false;
                        break;
                }
            }
        }

        public void AddToList()
        {
            Console.Clear();
            Console.WriteLine("What Category Would You Like This Car To Be In? Enter The Number\n" +
                "1. Gas\n" +
                "2. Electric\n" +
                "3. Hybrid");
            string carTypeAsString = Console.ReadLine();
            int carType = 0;
            bool correct = IntTest(carTypeAsString);

            if (correct && carType <= 4)
            {
                Console.Clear();
                carType = int.Parse(carTypeAsString);
                CarType type = (CarType)int.Parse(carTypeAsString);
                Console.Clear();
                Console.WriteLine($"You successfully set the type of car to {type}! Press enter to continue.");
                Console.ReadLine();

                Console.Clear();
                Console.WriteLine("What Is The Mileage On This Car?");
                string mileageAsString = Console.ReadLine();
                double mileageCar = 0;
                bool correct2 = DoubleTest(mileageAsString);

                if (correct2)
                {
                    mileageCar = double.Parse(mileageAsString);
                    Console.Clear();
                    Console.WriteLine($"You have successfully set the mileage of the car to {mileageCar}! Press enter to continue.");
                    Console.ReadLine();

                    Console.Clear();
                    Console.WriteLine("What Is This Cars Miles Per Gallon?");
                    string mpgAsString = Console.ReadLine();
                    double mpg = 0;
                    bool correct3 = DoubleTest(mpgAsString);

                    if (correct3)
                    {
                        mpg = double.Parse(mpgAsString);
                        Console.Clear();
                        Console.WriteLine($"You have successfully set the miles per gallon to {mpg}! Press enter to continue.");
                        Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine("What is the Make Of The Car (Company)?");
                        string carMake = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine($"You have successfully set the car make to {carMake}! Press enter to continue.");
                        Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine("What Is The Model Of The Car?");
                        string carModel = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine($"You have successfully set the car model to {carModel}! Press enter to continue");
                        Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine("What Is This Cars Wrecks Per Month?");
                        string carWrecksAsString = Console.ReadLine();
                        double carWrecks = 0;
                        bool correct4 = DoubleTest(carWrecksAsString);

                        if (correct4)
                        {
                            carWrecks = double.Parse(carWrecksAsString);
                            Console.Clear();
                            Console.WriteLine($"You have successfully set the car wrecks to {carWrecks}! Press enter to continue.");
                            Console.ReadLine();

                            Console.Clear();
                            Console.WriteLine("What is the Car VIN?");
                            string carVin = Console.ReadLine();

                            Console.Clear();
                            Console.WriteLine($"You have successfully set the car's VIN to {carVin}");
                            Console.ReadLine();

                            Cars newContent = new Cars(type, mileageCar, mpg, carMake, carModel, carWrecks, carVin);
                            _newCarRepo.AddToList(newContent);

                        }

                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Please Enter A Valid Car Wreck Count. You will be redirected, press enter");
                            Console.ReadLine();
                            AddToList();
                        }

                    }

                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Please Enter A Valid MPG. You will be redirected, press enter.");
                        Console.ReadLine();
                        AddToList();
                    }

                }

                else
                {
                    Console.Clear();
                    Console.WriteLine("Please Enter A Mileage Number. You will be redirected, press enter.");
                    Console.ReadLine();
                    AddToList();
                }
            }

            else
            {
                Console.Clear();
                Console.WriteLine("Please Enter A Valid Car Type. You will be redirected, press enter.");
                Console.ReadLine();
                AddToList();
            }
        }

        public void RemoveCarFromList()
        {
            Console.Clear();
            Console.WriteLine("Please Enter The Cars VIN That You Would Like To Remove.");
            string input = Console.ReadLine();

            _newCarRepo.RemovCarFromList(input);

            Console.Clear();
            Console.WriteLine("You have successfully removed this car from the list.");
            Console.ReadLine();

        }

        public void ViewCarByCategory()
        {
            Console.Clear();
            Console.WriteLine("Enter The Number Of The Category You Would Like View A List Of.\n" +
                "1. Gas\n" +
                "2. Electric\n" +
                "3. Hybrid");

            CarType carType = CarType.Gas;

            string inputType = Console.ReadLine();

            if (inputType == "1")
            {
                carType = CarType.Gas;
            }
            else if (inputType == "2")
            {
                carType = CarType.Electric;
            }
            else if (inputType == "3")
            {
                carType = CarType.Hybrid;
            }

            Console.Clear();
            List<Cars> list = _newCarRepo.GetListByCategories(carType);
            foreach (Cars content in list)
            {
                Console.WriteLine($"{content.Car}\n{content.Milage}\n{content.MilesPerGallon}\n{content.CarModel}\n{content.CarMake}\n{content.WrecksPerMonth}\n {content.CarVIN}");
            }
            Console.ReadLine();
        }

        public void UpdateACar()
        {
            Cars newCars = new Cars();

            Console.WriteLine("Enter the car's VIN That You Would Like To Edit.");
            string carVin = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Which Part Of This Car Would You Like To Update?\n" +
                "1. Mileage\n" +
                "2. Wrecks Per Month\n" +
                "3. Model\n" +
                "4. Make");
            int editSelection = int.Parse(Console.ReadLine());

            switch (editSelection)
            {
                case 1:
                    foreach (Cars car in _newCarRepo.GetList())
                    {
                        if (car.CarVIN == carVin)
                        {
                            Console.WriteLine("What would you like the new mileage to be?");
                            car.Milage = double.Parse(Console.ReadLine());
                            break;
                        }
                    }
                    break;
                case 2:
                    foreach (Cars car in _newCarRepo.GetList())
                    {
                        if (car.CarVIN == carVin)
                        {
                            Console.WriteLine("What would you like the new wrecks per month to be?");
                            car.WrecksPerMonth = double.Parse(Console.ReadLine());
                            break;
                        }
                    }
                    break;
                case 3:
                    foreach (Cars car in _newCarRepo.GetList())
                    {
                        if (car.CarVIN == carVin)
                        {
                            Console.WriteLine("What would you like the new model to be?");
                            car.CarModel = Console.ReadLine();
                            break;
                        }
                    }
                    break;
                case 4:
                    foreach (Cars car in _newCarRepo.GetList())
                    {
                        if (car.CarVIN == carVin)
                        {
                            Console.WriteLine("What would you like the new make to be?");
                            car.CarMake = Console.ReadLine();
                            break;
                        }
                    }
                    break;
            }

        }

        public bool IntTest(string a)
        {
            bool correct;
            int number;

            correct = int.TryParse(a, out number);

            return correct;
        }

        public bool DoubleTest(string a)
        {
            bool correct;
            double number;

            correct = double.TryParse(a, out number);

            return correct;
        }
    }
}
