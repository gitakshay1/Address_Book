using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book
{
    public class Addresbook
    {
        public void CreateContact()
        {
            Contact Contact = new Contact();
            Console.WriteLine("Enter FirstName");
            Contact.Firstname = Console.ReadLine();
            Console.WriteLine("Enter LastName");
            Contact.Lastname = Console.ReadLine();
            Console.WriteLine("Enter Address");
            Contact.Address = Console.ReadLine();
            Console.WriteLine("Enter City");
            Contact.City = Console.ReadLine();
            Console.WriteLine("Enter State");
            Contact.State = Console.ReadLine();
            Console.WriteLine("Enter Zip");
            Contact.Zip = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter PhoneNumber");
            Contact.Phone = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter MailId");
            Contact.Email = Console.ReadLine();

        }
    }
}
