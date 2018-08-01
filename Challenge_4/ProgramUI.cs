using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    class ProgramUI
    {
        private BadgeRepository _repo = new BadgeRepository();
        private bool continueToLoop = true;

        public void Run()
        {
            SeedData();

            RunStartMenu();
        }

        private void SeedData()
        {
            string badgeID1 = "12345";
            string badgeID2 = "22345";

            var doors = new List<string>();
            doors.Add("A1");
            doors.Add("A5");

            _repo.CreateBadge(badgeID1, doors);
            _repo.CreateBadge(badgeID2, doors);
        }

        private void RunStartMenu()
        {
            ShowStartMenu();
            
            while (continueToLoop)
            {
                int choice = UserChoice();

                switch (choice)
                {
                    case 1:
                        AddBadge();
                        break;
                    case 2:
                        //EditBadge();
                        break;
                    case 3:
                        GetBadges(_repo.GetBadges());
                        break;
                    case 4:
                        continueToLoop = false;
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

            Console.WriteLine("Komodo Security \n" +
                "1. Add a badge \n" +
                "2. Edit a badge \n" +
                "3. List all badges \n" +
                "4. Exit program");
        }

        private int UserChoice()
        {
            int choice = Int16.Parse(Console.ReadLine());
            return choice;
        }

        private void AddBadge()
        {
            Console.WriteLine("What is the badge number?");
            string badgeID = Console.ReadLine();

            var doors = new List<string>();

            while (continueToLoop)
            {
                Console.WriteLine("Add a door:");
                string door = Console.ReadLine();
                doors.Add(door);

                Console.WriteLine("Add another door? (y/n)");
                string answer = Console.ReadLine();

                if (answer != "y")
                    RunStartMenu();
            }
        }

        private void GetBadges(Dictionary<string, List<string>> badges)
        {
            foreach(var badge in badges)
            {
                Console.WriteLine($"Badge Number: {badge.Key}\t Door Access: {badge.Value.ToString()}");
            }
        }
    }
}
