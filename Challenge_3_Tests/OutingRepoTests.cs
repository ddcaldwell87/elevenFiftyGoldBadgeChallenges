using System;
using Challenge_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_3_Tests
{
    [TestClass]
    public class OutingRepoTests
    {
        [TestMethod]
        public void OutingRepo_GetOutings_ShouldReturnAList()
        {
            //-- Arrange
            Outing event1 = new Outing();
            Outing event2 = new Outing();
            Outing event3 = new Outing();

            OutingRepository repo = new OutingRepository();

            repo.AddOuting(event1);
            repo.AddOuting(event2);
            repo.AddOuting(event3);

            var list = repo.GetOutings(); // Tested Method

            //-- Act
            int actual = list.Count;
            int expected = 3;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OutingRepo_AddOuting_AddItemToList()
        {
            //-- Arrange
            Outing event1 = new Outing();
            Outing event2 = new Outing();
            Outing event3 = new Outing();

            OutingRepository repo = new OutingRepository();

            repo.AddOuting(event1); // Tested method
            repo.AddOuting(event2);
            repo.AddOuting(event3);

            var list = repo.GetOutings();

            //-- Act
            int actual = list.Count;
            int expected = 3;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OutingRepo_CostAllOutings_ShouldReturnTotalCostOfAllOutings()
        {
            //-- Arrange
            Outing event1 = new Outing("Bowling", 4, DateTime.Now, 19.99m, 19.99m * 4); // 79.96
            Outing event2 = new Outing("Golf", 2, DateTime.Now, 39.99m, 39.99m * 2); //79.98
            Outing event3 = new Outing("Concert", 6, DateTime.Now, 49.99m, 49.99m * 6); // 299.94

            OutingRepository repo = new OutingRepository();

            repo.AddOuting(event1);
            repo.AddOuting(event2);
            repo.AddOuting(event3);

            var outingList = repo.GetOutings();

            //-- Act
            decimal actual = repo.CostAllOutings(outingList); // Tested method
            decimal expected = event1.CostofEvent + event2.CostofEvent + event3.CostofEvent;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OutingRepo_CostByType_ShouldReturnTotalCostByEventType()
        {
            //-- Arrange
            Outing event1 = new Outing("Bowling", 4, DateTime.Now, 19.99m, 19.99m * 4); // 79.96
            Outing event2 = new Outing("Bowling", 3, DateTime.Now, 19.99m, 19.99m * 3); //59.97
            Outing event3 = new Outing("Golf", 2, DateTime.Now, 39.99m, 39.99m * 2); //79.98
            Outing event4 = new Outing("Concert", 6, DateTime.Now, 49.99m, 49.99m * 6); // 299.94

            OutingRepository repo = new OutingRepository();

            repo.AddOuting(event1);
            repo.AddOuting(event2);
            repo.AddOuting(event3);
            repo.AddOuting(event4);

            var outingList = repo.GetOutings();

            //-- Act
            decimal actual = repo.CostByType("Bowling");
            decimal expected = event1.CostofEvent + event2.CostofEvent;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
