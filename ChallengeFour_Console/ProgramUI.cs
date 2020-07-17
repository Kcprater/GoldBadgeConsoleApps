using ChallengeFour_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFour_Console
{
    class ProgramUI
    {
        private OutingsRepo _outingsRepo = new OutingsRepo();
        //Method That Runs/Starts App
        public void Run()
        {
            SeedOutings();
            Menu();
        }
        //Menu
        private void Menu()
        {
            bool accounting = true;
            while (accounting)
            {
                Console.Clear();
                //Display our options to user
                Console.WriteLine("Welcome to Komodo's Company Outings Manager!\n\n" +
                    "Select an option from below:\n\n" +
                    "1. View all outings\n" +
                    "2. Add a new outing\n" +
                    "3. View cost for all outings\n" +
                    "4. View cost by outing type\n" +
                    "5. Exit");
                //Get User Input
                string input = Console.ReadLine();
                //Evaluate The Input And Act Accordingly
                switch (input)
                {
                    case "1":
                        //See All Outings
                        ViewAllOutings();
                        break;
                    case "2":
                        //Add New Outing
                        CreateNewOuting();
                        break;
                    case "3":
                        //View Cost For All Outings
                        AllOutingsCost();
                        break;
                    case "4":
                        //View Cost By Event Type
                        CostByType();
                        break;
                    case "5":
                        //Exit
                        Console.WriteLine("Let's go have some fun!\n");
                        accounting = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number (1-5)");
                        break;
                }
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        //Add New Outing
        private void CreateNewOuting()
        {
            Console.Clear();
            Outings newOuting = new Outings();
            //Event Type - ENUM
            Console.WriteLine("Select the type of event:\n\n" +
                "1. Golf \n" +
                "2. Bowling \n" +
                "3. Amusement Park\n" +
                "4. Concert");
            string eventTypeAsString = Console.ReadLine();
            switch (eventTypeAsString)
            {
                case "1":
                    newOuting.TypeOfEvent = EventType.Golf;
                    break;
                case "2":
                    newOuting.TypeOfEvent = EventType.Bowling;
                    break;
                case "3":
                    newOuting.TypeOfEvent = EventType.Amusement_Park;
                    break;
                case "4":
                    newOuting.TypeOfEvent = EventType.Concert;
                    break;
            }
            //Date of Event
            Console.WriteLine("Enter the date of the Event (YYYY,MM,DD):");
            var eventDate = Console.ReadLine();
            newOuting.EventDate = DateTime.Parse(eventDate);
            //Attendance of Event
            Console.WriteLine("Enter the number of people that attended:");
            string attendanceAsString = Console.ReadLine();
            newOuting.PeopleAttended = int.Parse(attendanceAsString);
            //Cost Per Person
            Console.WriteLine("Amount per person to attend event: ");
            string costPPAsString = Console.ReadLine();
            newOuting.CostPerPerson = double.Parse(costPPAsString);

            _outingsRepo.CreateNewOuting(newOuting);
        }
        //View All Events
        private void ViewAllOutings()
        {
            Console.Clear();
            List<Outings> listOfOutings = _outingsRepo.ViewAllOutings();
            foreach (Outings outings in listOfOutings)
            {
                Console.WriteLine
                    (
                    $"Type: {outings.TypeOfEvent} \n" +
                    $"Date: {outings.EventDate}\n" +
                    $"Attendance: {outings.PeopleAttended}\n" +
                    $"Cost Per Person: ${outings.CostPerPerson}\n" +
                    $"Total Cost: ${outings.CostOfAllEvents}\n");
            }
        }
        public void CostByType()
        {
            Console.Clear();
            Console.WriteLine("Select event type to view the cost of that activity for the year:\n\n" +
                    "1. Golf\n" +
                    "2. Bowling\n" +
                    "3. Concert\n" +
                    "4. Amusement Park\n" +
                    "5. Return to Main Menu");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    double golfCost = _outingsRepo.CostOfEvent(EventType.Golf);
                    Console.WriteLine($"The total cost of golf for the year is ${golfCost}.");
                    break;
                case "2":
                    double bowlingCost = _outingsRepo.CostOfEvent(EventType.Bowling);
                    Console.WriteLine($"The total cost of bowling for the year is ${bowlingCost}.");
                    break;
                case "3":
                    double concertCost = _outingsRepo.CostOfEvent(EventType.Concert);
                    Console.WriteLine($"The total cost of concerts for the year is ${concertCost}.");
                    break;
                case "4":
                    double amusementParkCost = _outingsRepo.CostOfEvent(EventType.Amusement_Park);
                    Console.WriteLine($"The total cost of amusement parks for the year is ${amusementParkCost}.");
                    break;
                case "5":
                    Menu();
                    break;
                default:
                    break;
            }
            Console.ReadLine();
            CostByType();
            Console.Clear();
        }
        private void AllOutingsCost()
        {
            double allOutingsCost = 0;
            List<Outings> listOfOutings = _outingsRepo.ViewAllOutings();
            foreach (Outings outings in listOfOutings)
            {
                allOutingsCost += outings.CostOfAllEvents;
            }
            Console.WriteLine($"All events total: ${allOutingsCost}");
            Console.ReadKey();
        }
        private void SeedOutings()
        {
            //Golf
            Outings golfOne = new Outings(EventType.Golf, new DateTime(2019,01,01), 24, 90);
            Outings golfTwo = new Outings(EventType.Golf, new DateTime(2019, 04, 01), 47, 90);
            Outings golfThree = new Outings(EventType.Golf, new DateTime(2019, 07, 01), 31, 90);
            Outings golfFour = new Outings(EventType.Golf, new DateTime(2019, 10, 01), 19, 95);
            //Bowling
            Outings bowlingOne = new Outings(EventType.Bowling, new DateTime(2019, 02, 07), 100, 12);
            Outings bowlingTwo = new Outings(EventType.Bowling, new DateTime(2019, 05, 07), 92, 12);
            Outings bowlingThree = new Outings(EventType.Bowling, new DateTime(2019, 08, 07), 84, 12);
            Outings bowlingFour = new Outings(EventType.Bowling, new DateTime(2019, 11, 07), 87, 12);
            //Amusement Park
            Outings amusementOne = new Outings(EventType.Amusement_Park, new DateTime(2019, 03, 15), 51, 60);
            Outings amusmentTwo = new Outings(EventType.Amusement_Park, new DateTime(2019, 06, 15), 43, 60);
            Outings amusementThree = new Outings(EventType.Amusement_Park, new DateTime(2019, 09, 15), 56, 60);
            Outings amusementFour = new Outings(EventType.Amusement_Park, new DateTime(2019, 12, 15), 49, 60);
            //Concert
            Outings concertOne = new Outings(EventType.Concert, new DateTime(2019, 02, 28), 65, 75);
            Outings concertTwo = new Outings(EventType.Concert, new DateTime(2019, 04, 30), 38, 75);
            Outings concertThree = new Outings(EventType.Concert, new DateTime(2019, 06, 30), 83, 75);
            Outings concertFour = new Outings(EventType.Concert, new DateTime(2019, 08, 31), 61, 75);

            _outingsRepo.CreateNewOuting(golfOne);
            _outingsRepo.CreateNewOuting(golfTwo);
            _outingsRepo.CreateNewOuting(golfThree);
            _outingsRepo.CreateNewOuting(golfFour);
            _outingsRepo.CreateNewOuting(bowlingOne);
            _outingsRepo.CreateNewOuting(bowlingTwo);
            _outingsRepo.CreateNewOuting(bowlingThree);
            _outingsRepo.CreateNewOuting(bowlingFour);
            _outingsRepo.CreateNewOuting(amusementOne);
            _outingsRepo.CreateNewOuting(amusmentTwo);
            _outingsRepo.CreateNewOuting(amusementThree);
            _outingsRepo.CreateNewOuting(amusementFour);
            _outingsRepo.CreateNewOuting(concertOne);
            _outingsRepo.CreateNewOuting(concertTwo);
            _outingsRepo.CreateNewOuting(concertThree);
            _outingsRepo.CreateNewOuting(concertFour);
        }
    }
}