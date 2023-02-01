using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book
{
    public class Contact
    {
        public Contact(string firstName, string lastName, string address, string city, string state, string email, int zip, long phoneNum)
        {
            Firstname = firstName;
            Lastname = lastName;
            Address = address;
            City = city;
            State = state;
            Email = email;
            Zip = zip;
        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public long Zip { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
    }
    
}
