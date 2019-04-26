using _04_Challenge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Challenge_Console
{
    class ProgramUI
    {
        private Claim_Repo _newClaimRepo = new Claim_Repo();
        public void Run()
        {
            RunMenu();
            SeedList();
        }

        public void RunMenu()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("What Would You Like To Do?\n" +
                    "1. See All Claims\n" +
                    "2. Take Care Of Next Claim\n" +
                    "3. Enter A New Claim\n" +
                    "4. Exit");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        AddNewClaim();
                        break;
                    case "4":
                        running = false;
                        break;

                }
            }
        }


        public void AddNewClaim()
        {
            Console.Clear();
            Console.WriteLine("What Is The Claim ID?");
            string claimIdAsString = Console.ReadLine();
            int claimId = 0;
            bool correct = IntTest(claimIdAsString);

            if (correct)
            {
                Console.Clear();
                claimId = int.Parse(claimIdAsString);
                Console.WriteLine($"You Have Successfully Set The Claim ID to {claimId}, Press enter to continue.");
                Console.ReadLine();

                Console.Clear();
                Console.WriteLine("What Is The Claim Type? Enter The Number.\n" +
                    "1. Car\n" +
                    "2. Home\n" +
                    "3. Theft");
                string claimTypeAsString = Console.ReadLine();
                bool correct2 = IntTest(claimTypeAsString);

                if (correct2)
                {
                    Console.Clear();
                    ClaimType type = (ClaimType)int.Parse(claimTypeAsString);
                    Console.Clear();
                    Console.WriteLine($"You have successfully set the type of claim to {type}, Press enter to continue.");
                    Console.ReadLine();

                    Console.Clear();
                    Console.WriteLine("What Description Would You Give This Claim?");
                    string description = Console.ReadLine();

                    Console.Clear();
                    Console.WriteLine("You have successfully set the description, Press enter to continue");
                    Console.ReadLine();

                    Console.Clear();
                    Console.WriteLine("What Is The Claim Amount?");
                    string claimAmountAsString = Console.ReadLine();
                    double claimAmount = 0;
                    bool correct3 = DoubleTest(claimIdAsString);

                    if (correct3)
                    {
                        claimAmount = double.Parse(claimAmountAsString);
                        Console.Clear();
                        Console.WriteLine($"You have successfully set the claim amount to {claimAmount}, Press enter to continue.");
                        Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine("Enter The Date Of The Incident. (MM/DD/YY)");
                        string dateAsString = Console.ReadLine();
                        DateTime dateOf = DateTime.Parse(dateAsString);

                        Console.Clear();
                        Console.WriteLine($"You have successfully set the date to {dateOf}, Press enter to continue.");
                        Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine("Enter The Date Of The Claim. (MM/DD/YY)");
                        string dateAsString1 = Console.ReadLine();
                        DateTime dateOf1 = DateTime.Parse(dateAsString1);

                        Console.Clear();
                        Console.WriteLine($"You have successfully set the date to {dateOf1}, Press enter to continue.");
                        Console.ReadLine();

                        TimeSpan span = dateOf1 - dateOf;
                        bool isValidClaim = false;
                        if (span.Days > 30)
                        {
                            isValidClaim = false;
                            Console.Clear();
                            Console.WriteLine("This claim is not valid because it is was not within the 30 day period.");
                            Console.ReadLine();
                        }
                        else
                        {
                            isValidClaim = true;
                            Console.Clear();
                            Console.WriteLine("sdasa");
                            Console.ReadLine();
                        }


                        //Console.Clear();
                        //Console.WriteLine("Is This Claim Valid? (Y/N)");
                        //string isValidAsString = Console.ReadLine();
                        //bool isValid;
                        //switch (isValidAsString)
                        //{
                        //    case "Y":
                        //        isValid = true;
                        //        Console.WriteLine($"You have successfully set the claim to {isValidAsString}");
                        //        break;
                        //    case "y":
                        //        isValid = true;
                        //        Console.WriteLine($"You have successfully set the claim to {isValidAsString}");
                        //        break;
                        //    case "N":
                        //        isValid = false;
                        //        Console.WriteLine($"You have successfully set the claim to {isValidAsString}");
                        //        break;
                        //    case "n":
                        //        isValid = false;
                        //        Console.WriteLine($"You have successfully set the claim to {isValidAsString}");
                        //        break;
                        //    default:
                        //        AddNewClaim();
                        //        isValid = false;
                        //        break;
                        //}
                        Claims newContent = new Claims(claimId, type, description, claimAmount, dateOf, dateOf1, isValidClaim);
                        _newClaimRepo.AddToQueue(newContent);
                    }

                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Please Enter A Valid Claim Amount Number, You Will Be Redirected, Press Enter.");
                        Console.ReadLine();
                        AddNewClaim();
                    }

                }

                else
                {
                    Console.Clear();
                    Console.WriteLine("Please Enter A Valid Claim Type, You Will Be Redirected, Press Enter.");
                    Console.ReadLine();
                    AddNewClaim();
                }

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please Enter A Valid Claim ID, You Will Be Redirected, Press Enter.");
                Console.ReadLine();
                AddNewClaim();
            }
        }

        public void SeeAllClaims()
        {
            Console.Clear();
            Console.WriteLine("What Type Of Claim Would You Like To See? Enter The Number\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            ClaimType claimType = ClaimType.Car;

            string inputType = Console.ReadLine();

            if (inputType == "1")
            {
                claimType = ClaimType.Car;
            }
            if (inputType == "2")
            {
                claimType = ClaimType.Home;
            }
            if (inputType == "3")
            {
                claimType = ClaimType.Theft;
            }

            Console.Clear();
            Queue<Claims> queue = _newClaimRepo.GetContentByEnum(claimType);
            foreach(Claims content in queue)
            {
                Console.WriteLine($"{content.ClaimID}\n{content.CType}\n{content.Description}\n{content.ClaimAmount}\n{content.DateOfIncident}\n{content.DateOfClaim}\n{content.IsValidClaim}");
            }
            Console.ReadLine();

        }

        public void TakeCareOfNextClaim()
        {
            Console.Clear();
            Queue<Claims> newQueue = _newClaimRepo.GetQueue();

            if (newQueue.Count > 0)
            {
                Claims claim = _newClaimRepo.PeekNextInQueue();
                Console.WriteLine($"Here are the details for the next claim to be handled\n{claim.ClaimID}\n{claim.CType}\n{claim.Description}\n{claim.ClaimAmount}\n{claim.DateOfIncident}\n{claim.DateOfClaim}\n");

                Console.WriteLine("Do you want to deal with this claim now? (Y/N)");

                string doTheyAsString = Console.ReadLine();
                bool doThey;
                switch (doTheyAsString)
                {
                    case "Y":
                        doThey = true;
                        _newClaimRepo.RemoveClaimFromQueue();
                        break;
                    case "y":
                        doThey = true;
                        _newClaimRepo.RemoveClaimFromQueue();
                        break;
                    case "N":
                        doThey = false;
                        RunMenu();
                        break;
                    case "n":
                        doThey = false;
                        RunMenu();
                        break;
                }
                Console.ReadLine();
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

        public void SeedList()
        {
            Claims content1 = new Claims(1, ClaimType.Car, "asdf", 200, DateTime.Today, DateTime.Today, true);
            Claims content2 = new Claims(1, ClaimType.Home, "asdf", 250, DateTime.Today, DateTime.Today, false);

            _newClaimRepo.AddToQueue(content1);
            _newClaimRepo.AddToQueue(content2);

        }
    }
}
