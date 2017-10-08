using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileSeacher
{
    class Program
    {
        public static bool found = false;
        static void Main(string[] args)
        {
            string [] drives = Environment.GetLogicalDrives();
            string input = Console.ReadLine();

            for (int i = 0; i < drives.Length; i++)
                if (new DriveInfo(drives[i]).IsReady) 
                    Search(new DirectoryInfo(drives[i]), input);

            Console.WriteLine("Search is done");
            if (!found) Console.WriteLine("No such file");
            Console.ReadKey();
        }

        public static void Search(DirectoryInfo dir, string name) {
            foreach (FileSystemInfo FSInfo in dir.GetFileSystemInfos()) {
                try {
                    if (FSInfo is FileInfo && FSInfo.Name.Equals(name))
                    {
                        Console.WriteLine(FSInfo.FullName);
                        found = true;
                    }
                    else if (FSInfo is DirectoryInfo) Search(FSInfo as DirectoryInfo, name);
                }
                catch { continue;}
            }  
        }
    }
}
