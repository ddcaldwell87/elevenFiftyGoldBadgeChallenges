using System;
using System.Collections.Generic;
using Challenge_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_4_Tests
{
    [TestClass]
    public class BadgeRepoTests
    {
        [TestMethod]
        public void Repo_GetBadges_ShouldReturnADictionary()
        {
            //-- Arrange
            BadgeRepository repo = new BadgeRepository();

            string badgeID1 = "12345";
            string badgeID2 = "22345";

            var doors = new List<string>();
            doors.Add("A1");
            doors.Add("A5");

            var badges = repo.GetBadges(); // Tested method

            //-- Act
            repo.CreateBadge(badgeID1, doors);
            repo.CreateBadge(badgeID2, doors);

            int actual = badges.Count;
            int expected = 2;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Repo_CreateBadge_ShouldAddNewBadgeToDictionary()
        {
            //-- Arrange
            BadgeRepository repo = new BadgeRepository();

            string badgeID1 = "12345";
            string badgeID2 = "22345";

            var doors = new List<string>();
            doors.Add("A1");
            doors.Add("A5");

            var badges = repo.GetBadges();

            //-- Act
            repo.CreateBadge(badgeID1, doors); // Tested method
            repo.CreateBadge(badgeID2, doors); // Tested method

            int actual = badges.Count;
            int expected = 2;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
