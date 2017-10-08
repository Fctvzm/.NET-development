using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0) Console.BackgroundColor = ConsoleColor.White;
                else Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("I am a cool boy");

            }
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Yeaa red");
            Console.ReadKey();
        }
    }
}
