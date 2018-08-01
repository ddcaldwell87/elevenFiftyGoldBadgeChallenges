using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_5
{
    public class CustomerRepository
    {
        private List<Customer> _customerList = new List<Customer>();

        public List<Customer> GetCustomers()
        {
            return _customerList;
        }

        public void AddCustomer(Customer customer)
        {
            _customerList.Add(customer);
        }

        public void RemoveCustomer(Customer customer)
        {
            _customerList.Remove(customer);
        }

        public Customer FindCustomerByName(string firstName, string lastName)
        {
            var foundCustomer = new Customer();

            foreach(var customer in _customerList)
            {
                if (firstName == customer.FirstName && lastName == customer.LastName)
                {
                    foundCustomer = customer;
                    break;
                }
            }

            return foundCustomer;
        }
    }
}
