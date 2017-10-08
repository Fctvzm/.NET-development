using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable hash = new Hashtable();
            ListDictionary list = new ListDictionary();
            HybridDictionary hybrid = new HybridDictionary();
            for (int i = 0 ; i < 10; i++)
            {
                hash.Add(i, i);
                list.Add(i, i);
                hybrid.Add(i, i);
            }

            double h = 0, l = 0, hyb = 0;
            for (int i = 0; i < 100; i++)
            {
                
                Stopwatch watch = Stopwatch.StartNew();
                foreach (DictionaryEntry entry in hash) { }
                watch.Stop();
                h += watch.ElapsedTicks;

                watch = Stopwatch.StartNew();
                foreach (DictionaryEntry entry in list) { }
                watch.Stop();
                l += watch.ElapsedTicks;

                watch = Stopwatch.StartNew();
                foreach (DictionaryEntry entry in hybrid) { }
                watch.Stop();
                hyb += watch.ElapsedTicks;
            }

            Console.WriteLine("Hash {0}", h/100);
            Console.WriteLine("List {0}", l/100);
            Console.WriteLine("Hybrid {0}", hyb/100);
            Console.ReadKey();

        }

    }
}
