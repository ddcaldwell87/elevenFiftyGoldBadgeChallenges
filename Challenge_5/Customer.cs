using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_5
{
    public class Customer
    {
        public Customer()
        {

        }
        public Customer(string f, string l, string t)
        {
            FirstName = f;
            LastName = l;
            Type = t;
        }

        private string _message;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; }
        public string Message
        {
            get
            {
                if (Type == "Current")
                    _message = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                if (Type == "Past")
                    _message = "It's been a long time since we've heard from you, we want you back";
                if (Type == "Potential")
                    _message = "We currently have the lowest rates on Helicopter Insurance!";
                return _message;
            }
            set{}
        }
    }
}
