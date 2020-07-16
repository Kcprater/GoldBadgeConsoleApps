using ChallengeTwo_Repository;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
                //Display our options to user
                Console.WriteLine("Welcome to Komodo's Claims Department!\n" +
                    "Select an option from below:\n\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit");

                //Get User Input
                string input = Console.ReadLine();

                //Evaluate The Input And Act Accordingly
                switch (input)
                {
                    case "1":
                        //See All Claims (Seeded 3 just for Demonstration)
                        ViewClaims();
                        break;
                    case "2":
                        //View Next Claim To Take Care Of
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        //Add A New Claim
                        AddNewClaim();
                        break;
                    case "4":
                        //Exit
                        Console.WriteLine("Done for the day already?\n");
                        adjustingClaims = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number (1-4)");
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
            Console.WriteLine("Enter description for claim:");
            newClaim.Description = Console.ReadLine();

            //Damage Amount
            Console.WriteLine("Amount of damage: ");
            string claimAmountAsString = Console.ReadLine();
            newClaim.ClaimAmount = double.Parse(claimIDAsString);

            //Date of Accident
            Console.WriteLine("Enter the date the accident occurred (YYYY,MM,DD):");
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
                    $"IsValid: {claim.IsValid}\n \n");
                //Console.ReadKey();
            }
        }
        public void TakeCareOfNextClaim()
        {
            Console.Clear();
            var nextClaim = _claimsRepo.TakeCareOfNextClaim();
            Console.WriteLine(
                    $"Details for next claim: \n" +
                    $"ClaimID: {nextClaim.ClaimID}\n" +
                    $"Type: {nextClaim.ClaimType} \n" +
                    $"Description: {nextClaim.Description}\n" +
                    $"Amount: ${nextClaim.ClaimAmount}\n" +
                    $"DateOfIncident: {nextClaim.DateOfIncident}\n" +
                    $"DateOfClaim: {nextClaim.DateOfClaim}\n" +
                    $"IsValid: {nextClaim.IsValid}\n" +
                    "Would you like to deal with this claim now (y/n)?");
            string input = Console.ReadLine();
            if (input == "y" || input == "Y")
            {
                _claimsRepo.RemoveClaim();
                Console.Clear();
                Menu();
            }
            else if (input == "n" || input == "N")
            {
                Console.Clear();
                Menu();
            }
            else
            {
                Console.WriteLine("Please try again and enter a valid option (y/n).");
            }
            Console.Clear();
        }
            //Seed Claims List
            private void SeedClaims()
        {
            Claims claimOne = new Claims(3, ClaimType.Car, "Truck slide down boat dock - Complete Loss.", 53456.78d, new DateTime (2019, 04, 23), new DateTime (2020, 02, 11));
            Claims claimTwo = new Claims(45, ClaimType.Home, "Fire - Started by wood burning kit igniting drapes.", 50000.00d, new DateTime (2020, 07, 10), new DateTime (2020, 07, 15));
            Claims claimThree = new Claims(3, ClaimType.Theft, "Broken Window. TV was stolen.", 674.38d, new DateTime (2016,12,10), new DateTime (2017,01,02));

            _claimsRepo.AddNewClaim(claimOne);
            _claimsRepo.AddNewClaim(claimTwo);
            _claimsRepo.AddNewClaim(claimThree);
        }
    }
}
