using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bees
{
    class Program
    {
        static int bees_count;
        static int size;
        static volatile int honeysize = 0;
        static Random rn = new Random();
        static Thread bear_thread = new Thread(new ThreadStart(bear));
        static Semaphore mutex;

        static void bee(object i)
        {
            Console.WriteLine(i + " bee is waiting");
            mutex.WaitOne();
            Console.WriteLine(i + " bee is adding a new portion of honey");
            Thread.Sleep(rn.Next(1, 3) * 1000);
            
            honeysize++;
            if (honeysize == size)
            {
                Console.WriteLine(i + " bee woke up bear");
                bear_thread.Start();
                bear_thread.Join();
            }
            Console.WriteLine(i + "bee fly away");
            mutex.Release();
        }

        static void bear()
        {
            //Thread.Sleep(1000);
            Console.WriteLine("bear ate all honey");
            honeysize = 0;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter bees count:");
            bees_count =Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter size of honey size:");
            size = Int32.Parse(Console.ReadLine());
            mutex = new Semaphore(1, 1);

            for (int i = 1; i <= bees_count; i++)
            {
                new Thread(bee).Start(i);
            }

            Console.ReadKey();
        }

        
    }
}
