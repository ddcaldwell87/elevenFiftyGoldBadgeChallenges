using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge_5
{
    class ProgramUI
    {
        private CustomerRepository _repo = new CustomerRepository();
        private bool _continueLoop = true;

        public void Run()
        {
            SeedData();

            RunStartMenu();
        }

        private void SeedData()
        {
            Customer customer1 = new Customer("David", "Caldwell", "Current");
            Console.WriteLine(customer1.Message);
            Customer customer2 = new Customer
            {
                FirstName = "John",
                LastName = "Smith",
                Type = "Potential"
            };

            _repo.AddCustomer(customer1);
            _repo.AddCustomer(customer2);
        }

        private void RunStartMenu()
        {
            ShowStartMenu();

            while (_continueLoop)
            {
                int choice = UserChoice();

                switch (choice)
                {
                    case 1:
                        AddCustomer();
                        break;
                    case 2:
                        ListCustomers();
                        break;
                    case 3:
                        UpdateCustomer();
                        break;
                    case 4:
                        RemoveCustomer();
                        break;
                    case 5:
                        _continueLoop = false;
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

            Console.WriteLine("Komodo Insurance \n" +
                "1. Add Customer \n" +
                "2. List Customers \n" +
                "3. Update Customer \n" +
                "4. Remove Customer \n" +
                "5. Exit Program");
        }

        private int UserChoice()
        {
            int choice = Int16.Parse(Console.ReadLine());
            return choice;
        }

        private void AddCustomer()
        {
            Console.WriteLine("First Name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Last Name: ");
            string lastName = Console.ReadLine();

            Console.WriteLine("Current/Past/Potential?");
            string type = Console.ReadLine();

            Customer newCustomer = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                Type = type
            };

            _repo.AddCustomer(newCustomer);

            Console.WriteLine("Customer added successfully!");
            Thread.Sleep(2000);
            RunStartMenu();
        }

        private void ListCustomers()
        {
            List<Customer> customers = _repo.GetCustomers();

            foreach (var customer in customers)
            {
                Console.WriteLine("Customer \n" +
                    $"First Name: {customer.FirstName} \n" +
                    $"Last Name: {customer.LastName} \n" +
                    $"Type: {customer.Type} \n" +
                    $"Message: {customer.Message} \n");
            }

            Console.WriteLine("1. Back to menu");
            int choice = UserChoice();
            if (choice == 1)
                RunStartMenu();
        }

        private void UpdateCustomer()
        {
            Customer foundCustomer = FindCustomerByName();

            Console.WriteLine("Edit first name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Edit last name:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Current/Past/Potential");
            string type = Console.ReadLine();

            foundCustomer.FirstName = firstName;
            foundCustomer.LastName = lastName;
            foundCustomer.Type = type;

            Console.WriteLine("Customer edited succesfully");
            Thread.Sleep(2000);
            RunStartMenu();
        }

        private void RemoveCustomer()
        {
            Customer foundCustomer = FindCustomerByName();

            _repo.RemoveCustomer(foundCustomer);

            Console.WriteLine("Customer removed successfully");
            Thread.Sleep(2000);
            RunStartMenu();
        }

        private Customer FindCustomerByName()
        {
            Console.WriteLine("First name of customer");
            string firstName = Console.ReadLine();

            Console.WriteLine("Last name of customer");
            string lastName = Console.ReadLine();

            Customer foundCustomer = new Customer();

            var customers = _repo.GetCustomers();

            foreach(var customer in customers)
            {
                if (firstName == customer.FirstName && lastName == customer.LastName)
                {
                    foundCustomer = customer;
                }
            }
            return foundCustomer;
        }
    }
}
