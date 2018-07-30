using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge_3
{
    class ProgramUI
    {
        private OutingRepository _repo = new OutingRepository();
        private bool continueToRunMenu = true;

        public void Run()
        {
            SeedData();

            RunStartMenu();
        }

        private void SeedData()
        {
            Outing event1 = new Outing("Bowling", 4, DateTime.Now, 19.99m, 19.99m * 4); // 79.96
            Outing event2 = new Outing("Bowling", 3, DateTime.Now, 19.99m, 19.99m * 3); //59.97
            Outing event3 = new Outing("Golf", 2, DateTime.Now, 39.99m, 39.99m * 2); //79.98
            Outing event4 = new Outing("Concert", 6, DateTime.Now, 49.99m, 49.99m * 6); // 299.94

            OutingRepository repo = new OutingRepository();

            _repo.AddOuting(event1);
            _repo.AddOuting(event2);
            _repo.AddOuting(event3);
            _repo.AddOuting(event4);
        }

        private void RunStartMenu()
        {
            ShowStartMenu();

            while (continueToRunMenu)
            {
                int choice = UserChoice();

                switch (choice)
                {
                    case 1:
                        AddEvent();
                        break;
                    case 2:
                        GetEvents();
                        break;
                    case 3:
                        CostsMenu();
                        break;
                    case 4:
                        continueToRunMenu = false;
                        break;
                    default:
                        RunStartMenu();
                        break;
                }
            }
        }

        private void ShowStartMenu()
        {
            Console.Clear();

            Console.WriteLine("Komodo Outings \n" +
                "1. Add an event \n" +
                "2. List all events \n" +
                "3. Costs \n" +
                "4. Exit Program");
        }

        private int UserChoice()
        {
            string input = Console.ReadLine();
            int choice = Int16.Parse(input);
            return choice;
        }

        private void AddEvent()
        {
            Console.WriteLine("Type of event?");
            string type = Console.ReadLine();

            Console.WriteLine("Number of attendees?");
            int numOfAttendees = UserChoice();

            Console.WriteLine("Cost per person?");
            decimal costPerPerson = Decimal.Parse(Console.ReadLine());

            Outing newEvent = new Outing(type, numOfAttendees, DateTime.Now.Date, costPerPerson, costPerPerson * numOfAttendees);
            _repo.AddOuting(newEvent);

            Console.WriteLine("Event added successfully!");
            Thread.Sleep(2000);
            ContinueOrExit();
        }

        private void GetEvents()
        {
            Console.Clear();

            var outings = _repo.GetOutings();

            foreach(Outing outing in outings)
            {
                Console.WriteLine($"Type: {outing.Type} \n" +
                    $"Attendees: {outing.NumOfAttendees} \n" +
                    $"Date: {outing.Date.Date} \n" +
                    $"Cost per Person: {outing.CostPerPerson} \n" +
                    $"Cost of event: {outing.CostofEvent} \n");
            }

            ContinueOrExit();    
        }

        private void ContinueOrExit()
        {
            Console.WriteLine("1. Back to menu \n" +
                "2. Exit Program");

            int choice = UserChoice();

            switch (choice)
            {
                case 1:
                    RunStartMenu();
                    break;
                case 2:
                    continueToRunMenu = false;
                    break;
            }
        }

        private void CostsMenu()
        {
            Console.Clear();

            Console.WriteLine("1. Cost of all outings. \n" +
                "2. Cost of outings by type \n" +
                "3. Back to main menu \n" +
                "4. Exit program");

            int choice = UserChoice();

            switch (choice)
            {
                case 1:
                    CostOfAllOutings();
                    break;
                case 2:
                    CostOfOutingsByType();
                    break;
                case 3:
                    RunStartMenu();
                    break;
                case 4:
                    continueToRunMenu = false;
                    break;
            }
        }

        private void CostOfAllOutings()
        {
            Console.Clear();

            var outingList = _repo.GetOutings();

            Console.WriteLine(_repo.CostAllOutings(outingList));

            ContinueOrExit();
        }

        private void CostOfOutingsByType()
        {
            Console.Clear();

            var outingList = _repo.GetOutings();

            Console.WriteLine("Type of event?");
            string type = Console.ReadLine();

            Console.WriteLine(_repo.CostByType(type));

            ContinueOrExit();
        }
    }
}
