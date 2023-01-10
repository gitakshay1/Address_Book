using System;
namespace Address_Book
{
    public class Program
    {
        static void Main(string[] args)
        {
            Addresbook book = new Addresbook();
            book.CreateContact();

            while (true)
            {
                Console.WriteLine("1.Create Contact");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        book.CreateContact();
                        break;
                    
                }

            }
        }
    }
}
