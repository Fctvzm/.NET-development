using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab2_1
{
    class Program
    {
        public static void ShowDirectory (DirectoryInfo dir)
        {
            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach(DirectoryInfo d in dirs)
            {
                Console.WriteLine(d.Name);
            }
            foreach (DirectoryInfo d in dirs)
            {
                ShowDirectory(d);
            }
        }
        static void Main(string[] args)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Асем Зайткалиева");
                ShowDirectory(dir);
                Console.ReadKey();
            }
            catch (Exception)
            {
            }
            Console.ReadKey();
        }
    }
}
