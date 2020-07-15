using ChallengeTwo_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo_Console
{
    class ProgramUI
    {
        private ClaimsRepo _claimsRepo = new ClaimsRepo();
        //Method That Runs/Starts App
        public void Run()
        {
            SeedClaims();
            Menu();
        }
        //Menu Agent Sees
        private void Menu()
        {
            bool adjustingClaims = true;
            while (adjustingClaims)
            {
                //Console.Clear(); // may need may not??????????????
                //Display our options to user
                Console.WriteLine("Choose a menu item:\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit ");

                //Get User Input
                string input = Console.ReadLine();

                //Evaluate The Input And Act Accordingly
                switch (input)
                {
                    case "1":
                        //See all claims
                        ViewClaims();
                        break;
                    //case "2":
                    //    //Take care of next claim
                    //    TakeCareOfNextClaim();//not sure what to do here yet
                    //    break;
                    case "3":
                        //Delete Menu Item
                        AddNewClaim();
                        break;
                    case "4":
                        //Exit
                        Console.WriteLine("Goodbye!");
                        adjustingClaims = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        //Add New Claim
        private void AddNewClaim()
        {
            Console.Clear();
            Claims newClaim = new Claims();

            //Claim ID
            Console.WriteLine("Enter the claim id:");
            string claimIDAsString = Console.ReadLine();
            newClaim.ClaimID = int.Parse(claimIDAsString);

            //Claim Type - ENUM
            Console.WriteLine("Select the claim type: \n" +
                "1. Car \n" +
                "2. Home \n" +
                "3. Theft");
            string claimTypeAsString = Console.ReadLine();
            switch (claimTypeAsString)
            {
                case "1":
                    newClaim.ClaimType = ClaimType.Car;
                    break;
                case "2":
                    newClaim.ClaimType = ClaimType.Home;
                    break;
                case "3":
                    newClaim.ClaimType = ClaimType.Theft;
                    break;
            }

            //Description
            Console.WriteLine("Enter a claim description:");
            newClaim.Description = Console.ReadLine();

            //Damage Amount
            Console.WriteLine("Amount of damge: ");
            string claimAmountAsString = Console.ReadLine();
            newClaim.ClaimAmount = double.Parse(claimIDAsString);

            //Date of Accident
            Console.WriteLine("Date of accident (YYYY,MM,DD):");
            var incidentDate = Console.ReadLine();
            newClaim.DateOfIncident = DateTime.Parse(incidentDate);

            //Date of Claim
            Console.WriteLine("Enter the date the claim was filed (YYYY,MM,DD)");
            var claimDate = Console.ReadLine();
            newClaim.DateOfClaim = DateTime.Parse(claimDate);


            _claimsRepo.AddNewClaim(newClaim);

        }
        //View All Claims
        private void ViewClaims()
        {
            Console.Clear();
            List<Claims> listOfClaims = _claimsRepo.ViewClaims().ToList();
            foreach (Claims claim in listOfClaims)
            {
                Console.WriteLine
                    ($"ClaimID: {claim.ClaimID}\n" +
                    $"Type: {claim.ClaimType} \n" +
                    $"Description: {claim.Description}\n" +
                    $"Amount: ${claim.ClaimAmount}\n" +
                    $"DateOfIncident: {claim.DateOfIncident}\n" +
                    $"DateOfClaim: {claim.DateOfClaim}\n" +
                    $"IsValid: {claim.IsValid}\n \n \n" +
                    "Do you want to deal with this claim now (y/n)?");
                //Console.ReadKey();
            }
        }

        //delete menu item
        //public void DeleteMenuItem()
        //{
        //    var fullMenu = _menuRepo.ViewMenu();

        //    //get menu item to remove
        //    Console.WriteLine("which item to remove");
        //    foreach (Menu item in fullMenu)
        //    {
        //        Console.WriteLine($"{item.MealNumber}){item.MealName}");
        //    }
        //    Console.WriteLine("enter number");

        //    var mealNum = int.Parse(Console.ReadLine());

        //    //Call Delete

        //    bool wasDeleted = _menuRepo.DeleteMenuItem(mealNum);

        //    //if deleted say so
        //    //otherwise say it could not be deleted
        //    if (wasDeleted)
        //    {
        //        Console.WriteLine("The menu item was successfully removed");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Menu item could not be deleted");
        //    }

        //}
        //seed method
        private void SeedClaims()
        {
            Claims claimOne = new Claims(3, ClaimType.Car, "Car accident on 465", 3456.78d, new DateTime (2019, 04, 23), new DateTime (2020, 02, 11));
            Claims claimTwo = new Claims(45, ClaimType.Home, "House Fire", 50000.00d, new DateTime (2020, 07, 10), new DateTime (2020, 07, 15));
            Claims claimThree = new Claims(3, ClaimType.Theft, "TV was stolen", 674.38d, new DateTime (2016,12,10), new DateTime (2017,01,02));

            _claimsRepo.AddNewClaim(claimOne);
            _claimsRepo.AddNewClaim(claimTwo);
            _claimsRepo.AddNewClaim(claimThree);
        }
    }
}
