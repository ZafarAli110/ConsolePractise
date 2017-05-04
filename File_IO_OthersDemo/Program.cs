using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_IO_OthersDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Loading Settings");
            MySettings settings = MySettings.Load();

            Console.WriteLine($"MyNum : {settings.MyNumber}");
            Console.WriteLine($"MyString : {settings.MyString}");

            Console.WriteLine();
            Console.WriteLine("Updating Settings and Saving File.");

            settings.MyNumber++;
            settings.MyString = DateTime.Now.ToString();

            settings.Save();

            Console.WriteLine("Done");
        }
    }
}
