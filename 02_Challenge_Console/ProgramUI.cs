using _02_Challenge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _02_Challenge_Repository.OutingContrustor;

namespace _02_Challenge_Console
{
    class ProgramUI
    {
        private OutingRepository _newOutingRepo = new OutingRepository();
        public void Run()
        {
            RunMenu();
        }

        public void RunMenu()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("What would you like to do?\n" +
                    "1. Add An Outing\n" +
                    "2. Display A List Of All Outings\n" +
                    "3. See Combined Cost For All Outings\n" +
                    "4. Outing Costs By Type\n" +
                    "5. Exit");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddToList();
                        break;
                    case "2":
                        ViewAllOutings();
                        break;
                    case "3":
                        SeeTotalForAllOutings();
                        break;
                    case "4":
                        SeeCombinedCostAnOutingType();
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
            Console.WriteLine("Enter The Number Of The Event Type.\n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert");
            string eventTypeAsString = Console.ReadLine();
            int eventt = 0;
            bool correct = IntTest(eventTypeAsString);

            if (correct && eventt <= 4)
            {
                Console.Clear();
                eventt = int.Parse(eventTypeAsString);
                EventType type = (EventType)int.Parse(eventTypeAsString);
                Console.WriteLine($"You have successfully set the event type to {type}.");
                Console.ReadLine();

                Console.Clear();
                Console.WriteLine("How many people attended?");
                string numberAttendedAsString = Console.ReadLine();
                int numberAttended = 0;
                bool correctTwo = IntTest(numberAttendedAsString);
                if (correctTwo)
                {
                    numberAttended = int.Parse(numberAttendedAsString);
                    Console.Clear();
                    Console.WriteLine($"You have successfully set the number of attendees to {numberAttended}");
                    Console.ReadLine();

                    Console.Clear();
                    Console.WriteLine("What was the month of the event?");
                    string monthAsString = Console.ReadLine();
                    int month = 0;
                    bool correctThree = IntTest(monthAsString);
                    if (correctThree)
                    {
                        month = int.Parse(monthAsString);
                        Console.Clear();
                        Console.WriteLine($"Succesfully set the month to {month}");
                        Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine("What was the day of the event?");
                        string dayAsString = Console.ReadLine();
                        int day = 0;
                        bool correctFour = IntTest(dayAsString);
                        if (correctFour)
                        {
                            day = int.Parse(dayAsString);
                            Console.Clear();
                            Console.WriteLine($"Succesfully set the day to {day}");
                            Console.ReadLine();

                            Console.Clear();
                            Console.WriteLine("What is the year?");
                            string yearAsString = Console.ReadLine();
                            int year = 0;
                            bool correctFive = IntTest(yearAsString);
                            if (correctFive)
                            {
                                year = int.Parse(yearAsString);
                                Console.Clear();
                                DateTime newDate = new DateTime(year, month, day);
                                Console.WriteLine($"Succesfully set the date {month}/{day}/{year}");
                                Console.ReadLine();

                                Console.Clear();
                                Console.WriteLine("What is the cost per person?");
                                string costAsString = Console.ReadLine();
                                double cost = 0;
                                bool correctSix = IntTest(costAsString);

                                if (correctSix)
                                {
                                    cost = double.Parse(costAsString);
                                    Console.Clear();
                                    Console.WriteLine($"You have successfully set the cost per person to {cost}");
                                    Console.Clear();
                                    Console.WriteLine("What is the total cost for the event?");
                                    string totalAsString = Console.ReadLine();
                                    double total = 0;
                                    bool correctSeven = IntTest(totalAsString);

                                    if (correctSeven)
                                    {
                                        total = double.Parse(totalAsString);
                                        Console.Clear();
                                        Console.WriteLine($"You have successfully set the total cost to {total}");
                                        Console.ReadLine();

                                        Outing newContent = new Outing(type, numberAttended, newDate, cost, total);
                                        _newOutingRepo.AddToList(newContent);
                                    }

                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Please enter a cost.");
                                        Console.ReadLine();
                                        AddToList();
                                    }


                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Please enter a valid date.");
                                    Console.ReadLine();
                                    AddToList();
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Please enter a valid date.");
                                Console.ReadLine();
                                AddToList();
                            }

                        }

                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Please enter a valid date.");
                            Console.ReadLine();
                            AddToList();
                        }
                    }

                    else
                    {

                        Console.Clear();
                        Console.WriteLine("Please enter a valid date.");
                        Console.ReadLine();
                        AddToList();
                    }
                }

                else
                {
                    Console.Clear();
                    Console.WriteLine("Please enter the number of the attendees.");
                    Console.ReadLine();
                    AddToList();
                }
            }

            else
            {
                Console.Clear();
                Console.WriteLine("Please enter the number of the event type");
                Console.ReadLine();
                AddToList();
            }
        }

        public void ViewAllOutings()
        {
            Console.Clear();
            List<Outing> list = _newOutingRepo.GetOutingList();
            foreach (Outing content in list)
            {

                Console.WriteLine($"{content.Eventt}\n {content.NumberAttended}\n {content.Date}\n {content.CostPerPerson}\n {content.TotalCostForEvent}");

            }
            Console.ReadLine();
        }

        public void SeeCombinedCostAnOutingType()
        {
            Console.Clear();
            Console.WriteLine("Which outing would you like to see the totals for?\n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert");
            string whichOuting = Console.ReadLine();

            switch (whichOuting)
            {

                case "1":
                    double outingTotalForEvent1 = _newOutingRepo.CombinedTotalForOuting(EventType.Golf);
                    Console.WriteLine($"Here are the totals for all Golf Outings: {outingTotalForEvent1}");
                    Console.ReadLine();
                    break;
                case "2":
                    double outingTotalForEvent2 = _newOutingRepo.CombinedTotalForOuting(EventType.Bowling);
                    Console.WriteLine($"Here are the totals for all Bowling Outings: {outingTotalForEvent2}");
                    break;
                case "3":
                    double outingTotalForEvent3 = _newOutingRepo.CombinedTotalForOuting(EventType.AmusementPark);
                    Console.WriteLine($"Here are the totals for all Amusement Park Outings: {outingTotalForEvent3}");
                    break;
                case "4":
                    double outingTotalForEvent4 = _newOutingRepo.CombinedTotalForOuting(EventType.Concert);
                    Console.WriteLine($"Here are the totals for all Concert Outings{outingTotalForEvent4}");
                    break;
            }
        }

        public void SeeTotalForAllOutings()
        {
            Console.Clear();
            double total = _newOutingRepo.TotalForAllOutings(EventType.Golf, EventType.Bowling, EventType.AmusementPark, EventType.Concert);
            Console.Clear();
            Console.WriteLine($"The total costs for all outings are {total}");
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
