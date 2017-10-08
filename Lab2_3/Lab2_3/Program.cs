using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_3
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> Myfriends = new List<string>();
            Myfriends.Add("Aisha");
            Myfriends.Add("Assem");
            Myfriends.Add("Adi");
            Myfriends.Add("Nurai");
            FileStream data = new FileStream(@"C:\Users\Асем Зайткалиева\Downloads\data.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(data);
            for(int i = 0; i < Myfriends.Count - 1; i++)
            {
                sw.Write(Myfriends[i] + ',');
            }
            sw.Write(Myfriends[Myfriends.Count - 1] + '.');

            StreamReader sr = new StreamReader(data);
            char[] delim = { ',', '.' };
            string[] str = sr.ReadToEnd().Split(delim);
            for(int i = 0; i < str.Length - 1; i++)
            {
                Console.WriteLine('-' + str[i]);
            }
            Console.ReadKey();

            List<string> NewFriends = new List<string>();
            NewFriends.Add("Zhanaru");
            NewFriends.Add("Murkin");
            NewFriends.Add("Almara");

            /*for (int i = 0; i < NewFriends.Count - 1; i++)
            {
                sw.Write(NewFriends[i] + ',');
            }
            sw.Write(NewFriends[NewFriends.Count - 1] + '.');*/
            


        }
    }
}
