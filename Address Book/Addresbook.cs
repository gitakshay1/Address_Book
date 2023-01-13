using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book
{
    public class Addresbook
    {
        ArrayList arrayList = new ArrayList();
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
            arrayList.Add(Contact);
        }
        public void DisplayContact()
        {
            Console.WriteLine("*****Contact****");
            foreach (Contact records in arrayList)
            {
                Console.WriteLine("First Name -" + records.Firstname);
                Console.WriteLine("Last Name -" + records.Lastname);
                Console.WriteLine("Address -" + records.Address);
                Console.WriteLine("City -" + records.City);
                Console.WriteLine("State -" + records.State);
                Console.WriteLine("Zip -" + records.Zip);
                Console.WriteLine("Phone Number -" + records.Phone);
                Console.WriteLine("Email -" + records.Email);
            }
        }
        public void EditContact()
        {
            Console.WriteLine("To Edit contact enter contact firstname");
            string name = Console.ReadLine();
            foreach (Contact record in arrayList)
            {
                if (record.Firstname == name)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(name + " is exist");
                    Console.ResetColor();
                    Console.WriteLine("To edit details Enter " + "\n1.LastName\n2.Address\n3.City\n4.State\n5.Zip\n6.PhoneNumber\n7.Email");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter new lastname");
                            string newLastname = Console.ReadLine();
                            record.Lastname = newLastname;
                            break;
                        case 2:
                            Console.WriteLine("Enter New Address ");
                            string newAddress = Console.ReadLine();
                            record.Address = newAddress;
                            break;
                        case 3:
                            Console.WriteLine("Enter New City ");
                            string newCity = Console.ReadLine();
                            record.City = newCity;
                            break;
                        case 4:
                            Console.WriteLine("Enter New State ");
                            string newState = Console.ReadLine();
                            record.State = newState;
                            break;
                        case 5:
                            Console.WriteLine("Enter New Zip ");
                            long newZip = Convert.ToInt64(Console.ReadLine());
                            record.Zip = newZip;
                            break;
                        case 6:
                            Console.WriteLine("Enter New PhoneNumber ");
                            long newPhone = Convert.ToInt64(Console.ReadLine());
                            record.Phone = newPhone;
                            break;
                        case 7:
                            Console.WriteLine("Enter New Email ");
                            string newEmail = Console.ReadLine();
                            record.Email = newEmail;
                            break;

                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Name does not exist");
                    Console.ResetColor();
                }
            }
           
        }
        public void DeleteContact()
        {
            Console.WriteLine("Enter Name to delete contact");
            string name= Console.ReadLine();
            foreach(Contact record in arrayList)
            {
                if(record.Firstname==name)
                {
                    arrayList.Remove(record);
                    Console.WriteLine("Contact delete succesfully");
                }
                
            }
        }
    }
}
