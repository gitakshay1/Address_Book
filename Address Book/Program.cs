using System;
namespace Address_Book
{
    public class Program
    {
        static void Main(string[] args)
        {
            Addresbook book = new Addresbook();
            string bookName = "default";
            int choice = 1;
            while (choice!=0)
            {
                Console.WriteLine("1.Create Contact\n2 Display Contact\n3 Edit Contact\n4 Delete Contact\n5 Search Contact by name" +
                    "\n6 Create new address book\n7 Search contats by City/State\n0 exit app");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter FirstName");
                        string FirstName = Console.ReadLine();
                        Console.WriteLine("Enter LastName");
                        string LastName = Console.ReadLine();
                        Contact contact = new Contact(FirstName, LastName, null, null, null, null, 0, 0);
                        if (book.CheckDuplicateEntry(contact, bookName))
                        {
                            break;
                        }
                        Console.WriteLine("Enter Address");
                        string Address = Console.ReadLine();
                        Console.WriteLine("Enter City");
                        string City = Console.ReadLine();
                        Console.WriteLine("Enter State");
                        string State = Console.ReadLine();
                        Console.WriteLine("Enter Zip");
                        int Zip = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Eamil");
                        string Email = Console.ReadLine();
                        Console.WriteLine("Enter PhoneNumber");
                        long PhoneNum = Convert.ToInt64(Console.ReadLine());
                        book.CreateContact(FirstName, LastName, Address, City, State, Email, Zip, PhoneNum, bookName);
                        break;
                       
                        
                    case 2:
                        book.DisplayContact(); 
                        break;
                    case 3:
                        book.EditContact();
                        break;
                    case 4:
                        book.DeleteContact();
                        break;
                    case 5:
                        book.ViewContact();
                        break;
                    case 6:
                        Console.WriteLine("Enter Name For New AddressBook");
                        string newAddressBook = Console.ReadLine();
                        book.AddAddressBook(newAddressBook);
                        Console.WriteLine("Would you like to Switch to " + newAddressBook);
                        Console.WriteLine("1.Yes \n2.No");
                        int c = Convert.ToInt32(Console.ReadLine());
                        if (c == 1)
                        {
                            bookName = newAddressBook;
                        }
                        break;
                    case 7:
                        Console.WriteLine("Would You Like To \n1.Search by city \n2.Search by state");
                        int opt = Convert.ToInt32(Console.ReadLine());
                        switch (opt)
                        {
                            case 1:
                               
                                book.searchCity();
                                break;
                            case 2:
                                
                                book.SearchPersonByState();
                                break;
                            default:
                                Console.WriteLine("Invalid Input.Enter 1 or 2");
                                break;
                        }
                        break;
                    case 0:
                        Console.WriteLine("Thank you for using app");
                        break;
                }

            }

        }
    }
}
