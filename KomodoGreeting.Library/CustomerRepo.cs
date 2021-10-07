using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreeting.Library
{
    public class CustomerRepo
    {
        List<Customer> _listOfCustomers = new List<Customer>();
        public void AddToList(Customer c)
        {
            int id = 1000;
            bool loop = true;
            while (loop)
            {
                bool unique = true;
                foreach(Customer customer in _listOfCustomers)
                {
                    if(customer.ID == id) { unique = false; }
                }
                if (unique)
                {
                    c.ID = id;
                    _listOfCustomers.Add(c);
                    loop = false;
                }
                else { id++; }
            }
        }
        public List<Customer> GetList()
        {
            return _listOfCustomers;
        }
        public Customer GetCustomer(int id)
        {
            foreach(Customer customer in _listOfCustomers)
            {
                if(customer.ID == id) { return customer; }
            }
            return null;
        }
        public bool UpdateCustomer(int id, string fName, string lName, Customer.CustomerType type)
        {
            Customer customer = GetCustomer(id);
            if(customer != null)
            {
                customer.FirstName = fName;
                customer.LastName = lName;
                customer.FullName = customer.FirstName + " " + customer.LastName;
                customer.Type = type;
                return true;
            }
            return false;
        }
        public bool RemoveCustomer(int id)
        {
            Customer customer = GetCustomer(id);
            if(customer != null)
            {
                _listOfCustomers.Remove(customer);
                return true;
            }
            return false;
        }
    }
}
