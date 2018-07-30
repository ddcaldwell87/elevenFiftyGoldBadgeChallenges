using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Outing event1 = new Outing("Bowling", 4, DateTime.Now, 19.99m, 19.99m * 4); // 79.96
            Outing event2 = new Outing("Golf", 2, DateTime.Now, 39.99m, 39.99m * 2); //79.98
            Outing event3 = new Outing("Concert", 6, DateTime.Now, 49.99m, 49.99m * 6); // 299.94

            OutingRepository repo = new OutingRepository();

            repo.AddOuting(event1);
            repo.AddOuting(event2);
            repo.AddOuting(event3);

            var outingList = repo.GetOutings();

            decimal actual = repo.CostAllOutings(outingList);
        }
    }
}
