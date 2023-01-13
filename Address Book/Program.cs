using System;
namespace Address_Book
{
    public class Program
    {
        static void Main(string[] args)
        {
            Addresbook book = new Addresbook();
            while (true)
            {
                Console.WriteLine("1.Create Contact\n2 Display Contact\n3 Edit Contact\n4 Delete Contact");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        book.CreateContact();
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

                }

            }


        }
    }
}
