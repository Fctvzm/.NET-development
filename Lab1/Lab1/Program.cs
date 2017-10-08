using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person("Assem", "Zaitkaliyeva", 18, Person.Genders.Female);
            Manager m = new Manager("Assem", "Zaitkaliyeva", 18, Person.Genders.Female, "87555488", "Tole bi");
            Console.WriteLine(m);
            Console.ReadKey();
        }
    }
}
