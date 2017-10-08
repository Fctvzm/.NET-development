using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManager
{
    class Program
    {
        static int end = 31;
        static public void write(ConsoleColor color, string name, bool newline) {
            Console.ForegroundColor = color;
            if (newline) Console.WriteLine(" " + name);
            else Console.Write(" " + name);
        }

        static public void infromation (FileSystemInfo[] files, int index)
        {
            Console.SetCursorPosition(1, 33);
            write(ConsoleColor.Yellow, "Path: ", false);
            write(ConsoleColor.White, files[index].FullName, false);
            Console.SetCursorPosition(1, 34);
            write(ConsoleColor.Yellow, "Created: ", false);
            write(ConsoleColor.White, File.GetCreationTime(files[index].FullName).ToString(), false);
            Console.SetCursorPosition(1, 35);
            write(ConsoleColor.Yellow, "Last modified: ", false);
            write(ConsoleColor.White, File.GetLastWriteTime(files[index].FullName).ToString(), false);

        }
        static  public void PutMarker(FileSystemInfo[] files, int index, ConsoleColor color)
        {
            Console.SetCursorPosition(0, index % end);
            Console.BackgroundColor = color;
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, index % end);
            if (files[index] is DirectoryInfo)
            {
                write(ConsoleColor.Green, "[+]", false);
                write(ConsoleColor.White, files[index].Name, true);
            }
            else write(ConsoleColor.White, files[index].Name, true);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 0);
        }
        static public void ShortCuts (ConsoleColor color, string name)
        {
            Console.BackgroundColor = color;  
            Console.Write(name);
        }
        static public void ListDirsAndFiles(FileSystemInfo[] files, int index, bool changed, int pre_index) {
            if (changed)
            {
                int i = (index < end) ? 0 : (index / end) * end;
                Console.SetCursorPosition(0, 0);
                Console.Clear();
                foreach (FileSystemInfo FSInfo in files)
                {
                    if (i < (index + end) && i < files.Length)
                    {
                        if (i == index) PutMarker(files, index, ConsoleColor.Red);
                        else PutMarker(files, i, ConsoleColor.Black);
                        i++;
                    }
                    else break;
                }
                Console.SetCursorPosition(1, end);
                if (files.Length > index + end) Console.WriteLine("...");
                Console.SetCursorPosition(1, 37);
                ShortCuts(ConsoleColor.Black, new string(' ', 3));
                ShortCuts(ConsoleColor.Blue, "F1 - Help");
                ShortCuts(ConsoleColor.Black, new string(' ', 7));
                ShortCuts(ConsoleColor.Blue, "F2 - MkDir");
                ShortCuts(ConsoleColor.Black, new string(' ', 7));
                ShortCuts(ConsoleColor.Blue, "F3 - MkFile");
                ShortCuts(ConsoleColor.Black, new string(' ', 7));
                ShortCuts(ConsoleColor.Blue, "F4 - Remove");
                Console.BackgroundColor = ConsoleColor.Black;
                infromation(files, index);
                Console.SetCursorPosition(0, 0);
            }
            else
            {
                if (pre_index >= 0 && pre_index < files.Length) PutMarker(files, pre_index, ConsoleColor.Black);
                PutMarker(files, index, ConsoleColor.Red);
                infromation(files, index);

            }
        }

        public static void MkDirAndFile (string path, bool dir)
        {
            string s;
            Console.SetCursorPosition(20, 31);
            Console.CursorVisible = true;
            if (dir)
            {
                write(ConsoleColor.Green, "Enter the name of folder", false);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(21, 32);
                s = Console.ReadLine();
                path = Path.Combine(path, s);
                Directory.CreateDirectory(path);
            }
            else
            {
                write(ConsoleColor.Cyan, "Enter the name of file", false);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(21, 32);
                s = Console.ReadLine();
                path = Path.Combine(path, s);
                using (File.Create(path));
            }
            Console.CursorVisible = false;
        }

        static void Main(string[] args)
        {

            string [] drives = Environment.GetLogicalDrives();
            FileSystemInfo[] cur = new FileSystemInfo[drives.Length];

            for (int i = 0; i < drives.Length; i++)
                cur[i] = new DirectoryInfo(drives[i]);

            Stack<Pair> parent = new Stack<Pair>();
            int index = 0, pre_index = 0, parent_index;
            bool changed;
            ListDirsAndFiles(cur, index, true, pre_index);
            Console.CursorVisible = false;
            Console.SetWindowSize(75, 39);
            ConsoleKeyInfo pressed = new ConsoleKeyInfo();
            string path = "";
            DirectoryInfo dir;

            while (pressed.Key != ConsoleKey.Escape)
            {
                changed = false;
                switch (pressed.Key) {
                    case ConsoleKey.UpArrow:
                        if (index > 0)
                        {
                            index--;
                            pre_index = index + 1;
                        }
                        else
                        {
                            index = cur.Length - 1;
                            pre_index = 0;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (index + 1 < cur.Length)
                        {
                            index++;
                            pre_index = index - 1;
                        }
                        else
                        {
                            index = 0;
                            pre_index = cur.Length - 1;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (cur[index] is DirectoryInfo)
                        {
                            changed = true;
                            try
                            {
                                parent.Push(new Pair(index, cur, cur[index].FullName));
                                dir = cur[index] as DirectoryInfo;
                                cur = dir.GetFileSystemInfos();
                                index = 0;
                            }
                            catch (Exception)
                            {
                                Console.SetCursorPosition(1, cur.Length);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Access denied");
                                Console.ReadKey();
                                Pair p = parent.Pop();
                                cur = p.files;
                                index = p.index;
                                break;
                            }
                        }
                        else if (Path.GetExtension(cur[index].FullName) == ".jpg" ||
                            Path.GetExtension(cur[index].FullName) == ".png" ||
                            Path.GetExtension(cur[index].FullName) == ".gif")
                        {
                            Coloring.ConsoleWriteImage(new Bitmap(cur[index].FullName));
                            Console.ReadKey();
                            changed = true;
                        }
                        else System.Diagnostics.Process.Start(cur[index].FullName);
                        break;
                    case ConsoleKey.LeftArrow:
                        if (parent.Count > 0) {
                            changed = true;
                            Pair p = parent.Pop();
                            cur = p.files;
                            index = p.index;
                        }
                        break;
                    case ConsoleKey.F2:
                        path = parent.Peek().fileName;
                        MkDirAndFile(path, true);
                        parent_index = parent.Peek().index;
                        dir = parent.Peek().files[parent_index] as DirectoryInfo;
                        cur = dir.GetFileSystemInfos();
                        changed = true;
                        break;
                    case ConsoleKey.F3:
                        path = parent.Peek().fileName;
                        MkDirAndFile(path, false);
                        parent_index = parent.Peek().index;
                        dir = parent.Peek().files[parent_index] as DirectoryInfo;
                        cur = dir.GetFileSystemInfos();
                        changed = true;
                        break;
                    case ConsoleKey.F4:
                        path = cur[index].FullName;
                        parent_index = parent.Peek().index;
                        if (cur[index] is FileInfo)
                        {
                            try{File.Delete(path);}
                            catch (IOException) {}
                        }
                        else
                        {
                            try { Directory.Delete(path, true); }
                            catch { }
                        }
                        dir = parent.Peek().files[parent_index] as DirectoryInfo;
                        cur = dir.GetFileSystemInfos();
                        changed = true;
                        break;
                    case ConsoleKey.F1:
                        Console.Clear();
                        Console.SetCursorPosition(30, 20);
                        write(ConsoleColor.Yellow, "Hello", false);
                        Console.SetCursorPosition(15, 21);
                        write(ConsoleColor.Blue, "This ", false);
                        write(ConsoleColor.White, "is ", false);
                        write(ConsoleColor.Cyan, "a ", false);
                        write(ConsoleColor.Red, "very ", false);
                        write(ConsoleColor.DarkYellow, "simple ", false);
                        write(ConsoleColor.Magenta, "file ", false);
                        write(ConsoleColor.DarkGreen, "manager ", false);
                        Console.ReadKey();
                        changed = true;
                        break;
                }
                if (index%end == 0)
                {
                    if (index != 0) changed = true;
                    if (pre_index == cur.Length - 1 && index == 0 && cur.Length > end) changed = true;
                }
                if ((index == cur.Length -1 || pre_index == end) && cur.Length > end)
                {
                    changed = true;
                }
                ListDirsAndFiles(cur, index, changed, pre_index);
                pressed = Console.ReadKey();
            }
        }
    }
}
