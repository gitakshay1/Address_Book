using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book
{
    public class FileIO
    {
        private string filePath = @"C:\Users\aksha\Assignments\Address_Book\Address Book\Records.txt";
        public void WriteToFile(Dictionary<string, Contact> addressbook)
        {
            using StreamWriter writer = new StreamWriter(filePath, true);
            foreach (KeyValuePair<string, Contact>  item in addressbook)
            {
                writer.WriteLine(item.Value.Firstname);
                writer.WriteLine(item.Value.Lastname);
                writer.WriteLine(item.Value.Address);
                writer.WriteLine(item.Value.City);
                writer.WriteLine(item.Value.State);
                writer.WriteLine(item.Value.Zip);
                writer.WriteLine(item.Value.Email);
                writer.WriteLine(item.Value.Phone);

            }
            Console.WriteLine("\nSuccessfully added to Text file.");
            writer.Close();
        }
        public void ReadFromFile()
        {
            Console.WriteLine("Below are Contents of Text File");
            string lines = File.ReadAllText(filePath);
            Console.WriteLine(lines);
        }
    }
}
