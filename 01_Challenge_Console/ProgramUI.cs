using _01_Challenge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Challenge_Console
{
    public class ProgramUI
    {
        private MenuRepo _newMenuRepo = new MenuRepo();
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
                Console.WriteLine("What would you like do to?\n" +
                    "1. Add A New Meal\n" +
                    "2. Delete A Meal\n" +
                    "3. See the Menu");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateMenuItem();
                        break;
                    case "2":
                        DeleteMenuItem();
                        break;
                    case "3":
                        SeeEveryItem();
                        break;
                }
            }

        }
        private void CreateMenuItem()
        {
            Console.Clear();
            Console.WriteLine("What would you like the meal number to be?");
            string mealNumberAsString = Console.ReadLine();
            int numberOfMeal = 0;
            bool correct = IntTest(mealNumberAsString);


            if (correct)
            {
                numberOfMeal = int.Parse(mealNumberAsString);
                Console.WriteLine("You have succesfully added a meal number");
                

            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
                Console.ReadLine();
                CreateMenuItem();
            }

            Console.Clear();
            Console.WriteLine("What would you like the meal name to be?");
            string mealName = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("How would you like to describe the meal?");
            string mealDescription = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("What are the main ingredients in this meal?");
            string mainIngredients = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("What would you like the price to be on this meal?");
            string priceAsString = Console.ReadLine();
            double price = 0;
            bool correct1 = IntTest(priceAsString);

            if (correct1)
            {

                price = double.Parse(priceAsString);
                Console.WriteLine("You have succesfully set the  meal price");

            }
            else
            {
                Console.WriteLine("Please enter a valid price.");
            }
            Console.ReadLine();

            Menu newContent = new Menu(numberOfMeal, mealName, mealDescription, mainIngredients, price);

            _newMenuRepo.AddToList(newContent);


        }

        private void DeleteMenuItem()
        {
            Console.Clear();
            Console.WriteLine("Enter the number of the meal you would like to remove");
            string numberOfMealAsString = Console.ReadLine();
            int numberOfMeal;
            bool correct = IntTest(numberOfMealAsString);


            if (correct)
            {
                numberOfMeal = int.Parse(numberOfMealAsString);
                Console.WriteLine($"You have succesfully removed a meal number {numberOfMeal}");
                _newMenuRepo.RemoveMealFromList(numberOfMeal);

            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
                Console.ReadLine();
                DeleteMenuItem();
            }
            Console.ReadLine();



        }

        private void SeeEveryItem()
        {
            Console.Clear();
            List<Menu> list = _newMenuRepo.GetMealList();
            foreach (Menu content in list)
            {
                Console.WriteLine($"{content.MealNumber}\n {content.MealName}\n {content.Description}\n {content.Ingredients}\n {content.Price}");
            }
            Console.ReadLine();
        }
        public bool IntTest(string a)
        {

            bool correct;
            int number;

            correct = int.TryParse(a, out number);

            return correct;
        }
    }
}
