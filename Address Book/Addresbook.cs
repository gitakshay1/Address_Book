using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Address_Book
{
    public class Addresbook
    {
        private Dictionary<string, Contact> addressbook = new Dictionary<string, Contact>();
        private Dictionary<string, Addresbook> addressBookDictionary = new Dictionary<string, Addresbook>();
        private Dictionary<Contact, string> cityDictionary = new Dictionary<Contact, string>();
        private Dictionary<Contact, string> stateDictionary = new Dictionary<Contact, string>();

        public void CreateContact(string firstName, string lastName, string address, string city, string state, string email, int zip, long phoneNum, string BookName)
        {
            Contact contact = new Contact(firstName, lastName, address, city, state, email, zip, phoneNum);

            addressBookDictionary[BookName].addressbook.Add(contact.Firstname, contact);
            Console.WriteLine("Added Succesfully");

        }
        public void DisplayContact()
        {
            Console.WriteLine("*****Contact****");
            foreach (KeyValuePair<string,Contact> item in addressbook)
            {
                Console.WriteLine("First Name -" + item.Value.Firstname);
                Console.WriteLine("Last Name -" + item.Value.Lastname);
                Console.WriteLine("Address -" + item.Value.Address);
                Console.WriteLine("City -" + item.Value.City);
                Console.WriteLine("State -" + item.Value.State);
                Console.WriteLine("Zip -" + item.Value.Zip);
                Console.WriteLine("Phone Number -" + item.Value.Phone);
                Console.WriteLine("Email -" + item.Value.Email);
            }
        }
        public void ViewContact()
        {
            Console.WriteLine("Enter Name for view contact");
            string name = Console.ReadLine();
            foreach (KeyValuePair<string, Contact> item in addressbook)
            {
                if (item.Key.Equals(name))
                {
                    Console.WriteLine("First Name : " + item.Value.Firstname);
                    Console.WriteLine("Last Name : " + item.Value.Lastname);
                    Console.WriteLine("Address : " + item.Value.Address);
                    Console.WriteLine("City : " + item.Value.City);
                    Console.WriteLine("State : " + item.Value.State);
                    Console.WriteLine("Email : " + item.Value.Email);
                    Console.WriteLine("Zip : " + item.Value.Zip);
                    Console.WriteLine("Phone Number : " + item.Value.Phone + "\n");
                }
            }
        }
        public void EditContact()
        {
            Console.WriteLine("To Edit contact enter contact firstname");
            string name = Console.ReadLine();
            foreach (KeyValuePair<string, Contact> item in addressbook)
            {
                if (item.Value.Firstname == name)
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
                            item.Value.Lastname = newLastname;
                            break;
                        case 2:
                            Console.WriteLine("Enter New Address ");
                            string newAddress = Console.ReadLine();
                            item.Value.Address = newAddress;
                            break;
                        case 3:
                            Console.WriteLine("Enter New City ");
                            string newCity = Console.ReadLine();
                            item.Value.City = newCity;
                            break;
                        case 4:
                            Console.WriteLine("Enter New State ");
                            string newState = Console.ReadLine();
                            item.Value.State = newState;
                            break;
                        case 5:
                            Console.WriteLine("Enter New Zip ");
                            long newZip = Convert.ToInt64(Console.ReadLine());
                            item.Value.Zip = newZip;
                            break;
                        case 6:
                            Console.WriteLine("Enter New PhoneNumber ");
                            long newPhone = Convert.ToInt64(Console.ReadLine());
                            item.Value.Phone = newPhone;
                            break;
                        case 7:
                            Console.WriteLine("Enter New Email ");
                            string newEmail = Console.ReadLine();
                            item.Value.Email = newEmail;
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
            if (addressbook.ContainsKey(name))
            {
                addressbook.Remove(name);
                Console.WriteLine("\nContact Deleted Succesfully..\n");
            }
            else
            {
                Console.WriteLine("\nContact Not Found, Try Again..\n");
            }
        }
        public void AddAddressBook(string bookName)
        {
            Addresbook addressBook = new Addresbook();
            addressBookDictionary.Add(bookName, addressBook);
            Console.WriteLine("AddressBook Created.");
        }
        public Dictionary<string, Addresbook> GetaddressBook()
        {
            return addressBookDictionary;
        }
        public List<Contact> GetListOfDictionaryKeys(string bookName)
        {
            List<Contact> contacts = new List<Contact>();
            foreach (var value in addressBookDictionary[bookName].addressbook.Values)
            {
                contacts.Add(value);
            }
            return contacts;
        }
        public bool CheckDuplicateEntry(Contact check, string bookName)
        {
            List<Contact> contacts = GetListOfDictionaryKeys(bookName);
            if (contacts.Any(b => b.Equals(check)))
            {
                Console.WriteLine("Name Already Exist");
                return true;
            }
            return false;
        }
        public List<Contact> GetListOfDictctionaryKeys2(Dictionary<string, Contact> d)
        {
            List<Contact> book = new List<Contact>();
            foreach (var value in d.Values)
            {
                book.Add(value);
            }
            return book;
        }
        public void searchCity()
        {
            Console.WriteLine("Enter City name");
            string CityName=Console.ReadLine();
            foreach (Addresbook addressbookobj in addressBookDictionary.Values)
            {
                List<Contact> contactList = GetListOfDictctionaryKeys2(addressbookobj.addressbook);
                foreach (Contact contact in contactList.FindAll(c => c.City.Equals(CityName)).ToList())
                {
                    Console.WriteLine(contact.ToString());
                }
            }
        }
        public void SearchPersonByState()
        {
            Console.WriteLine("Enter State name");
            string StateName = Console.ReadLine();
            foreach (Addresbook addressbookobj in addressBookDictionary.Values)
            {
                List<Contact> contactList = GetListOfDictctionaryKeys2(addressbookobj.addressbook);
                foreach (Contact contact in contactList.FindAll(c => c.State.Equals(StateName)).ToList())
                {
                    Console.WriteLine(contact.ToString());
                }
            }
        }
        public void CountbyCity()
        {
            Console.WriteLine(" Enter city ");
            string CityName = Console.ReadLine();
            int count = 0;
            foreach (Addresbook addressbookobj in addressBookDictionary.Values)
            {
                List<Contact> contactList = GetListOfDictctionaryKeys2(addressbookobj.addressbook);
                foreach (Contact contact in contactList.FindAll(c => c.City.Equals(CityName)).ToList())
                {
                    count++;
                }
            }
            Console.WriteLine(count + " person are in " + CityName);
        }
        public void CountbyState()
        {
            Console.WriteLine(" Enter state ");
            string stateName = Console.ReadLine();
            int count = 0;
            foreach (Addresbook addressbookobj in addressBookDictionary.Values)
            {
                List<Contact> contactList = GetListOfDictctionaryKeys2(addressbookobj.addressbook);
                foreach (Contact contact in contactList.FindAll(c => c.City.Equals(stateName)).ToList())
                {
                    count++;
                }
            }
            Console.WriteLine(count + " person are in " + stateName);
        }
        public void SortByName()
        {
            foreach (Addresbook addressBookobj in addressBookDictionary.Values)
            {
                List<string> list = addressBookobj.addressbook.Keys.ToList();
                list.Sort();
                foreach (string name in list)
                {
                    Console.WriteLine(addressBookobj.addressbook[name].ToString());
                }
            }
        }
        public void CreateCityDictionary()
        {
            foreach (Addresbook addressBookObj in addressBookDictionary.Values)
            {
                foreach (Contact contact in addressBookObj.addressbook.Values)
                {
                    addressBookObj.cityDictionary.Add(contact, contact.City);
                }
            }
        }

        public void CreateStateDictionary()
        {
            foreach (Addresbook addressBookObj in addressBookDictionary.Values)
            {
                foreach (Contact contact in addressBookObj.addressbook.Values)
                {
                    addressBookObj.stateDictionary.Add(contact, contact.State);
                }
            }
        }
        public void SortByCity()
        {
            CreateCityDictionary();
            Dictionary<string, Contact> inverseCityDictionary = new Dictionary<string, Contact>();
            foreach (Addresbook obj in addressBookDictionary.Values)
            {
                foreach (Contact contact in obj.cityDictionary.Keys)
                {
                    inverseCityDictionary.TryAdd(contact.City, contact);
                }
            }
            List<string> list = inverseCityDictionary.Keys.ToList();
            list.Sort();
            foreach (string city in list)
            {
                Console.WriteLine(inverseCityDictionary[city].ToString());
            }
        }

        public void SortByState()
        {
            CreateStateDictionary();
            Dictionary<string, Contact> inverseStateDictionary = new Dictionary<string, Contact>();
            foreach (Addresbook obj in addressBookDictionary.Values)
            {
                foreach (Contact contact in obj.stateDictionary.Keys)
                {
                    inverseStateDictionary.TryAdd(contact.State, contact);
                }
            }
            List<string> list = inverseStateDictionary.Keys.ToList();
            list.Sort();
            foreach (string state in list)
            {
                Console.WriteLine(inverseStateDictionary[state].ToString());
            }
        }

        public void SortByZip()
        {
            SortedList<int, Contact> sortedbyCity = new SortedList<int, Contact>();
            foreach (Addresbook addressBookobj in addressBookDictionary.Values)
            {
                foreach (Contact contact in addressBookobj.addressbook.Values)
                {
                    sortedbyCity.Add((int)contact.Zip, contact);
                }
            }
            foreach (var item in sortedbyCity)
            {
                Console.WriteLine(item.Value.ToString());
            }
        }
    }
}
