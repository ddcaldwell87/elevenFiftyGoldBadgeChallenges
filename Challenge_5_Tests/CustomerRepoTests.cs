using System;
using Challenge_5;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_5_Tests
{
    [TestClass]
    public class CustomerRepoTests
    {
        [TestMethod]
        public void Repo_GetCustomer_AddCustomer_ShouldAddToList()
        {
            //-- Arrange
            CustomerRepository _repo = new CustomerRepository();

            Customer customer1 = new Customer
            {
                FirstName = "David",
                LastName = "Caldwell",
                Type = "Current"
            };
            Customer customer2 = new Customer
            {
                FirstName = "John",
                LastName = "Smith",
                Type = "Potential"
            };

            var list = _repo.GetCustomers();

            //-- Act
            _repo.AddCustomer(customer1);
            _repo.AddCustomer(customer2);

            int actual = list.Count;
            int expected = 2;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Repo_RemoveCustomer_ShouldRemoveObjectFromList()
        {
            //-- Arrange
            CustomerRepository _repo = new CustomerRepository();

            Customer customer1 = new Customer
            {
                FirstName = "David",
                LastName = "Caldwell",
                Type = "Current"
            };
            Customer customer2 = new Customer
            {
                FirstName = "John",
                LastName = "Smith",
                Type = "Potential"
            };

            _repo.AddCustomer(customer1);
            _repo.AddCustomer(customer2);

            var list = _repo.GetCustomers();

            //-- Act
            _repo.RemoveCustomer(customer1);
            int actual = list.Count;
            int expected = 1;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
