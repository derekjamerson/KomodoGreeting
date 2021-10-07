using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreeting.Library
{
    public class Customer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public CustomerType Type { get; set; }
        public enum CustomerType
        {
            Past = 1,
            Current,
            Potential
        }
        public Customer(string first, string last, CustomerType type)
        {
            FirstName = first;
            LastName = last;
            FullName = FirstName + " " + LastName;
            Type = type;
        }
    }
}
