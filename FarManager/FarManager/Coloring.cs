using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FarManager
{
    class Coloring
    {
        public static Color FromColor(ConsoleColor c)
        {
            int[] cColors = {   0x000000, //Black = 0
                        0x000080, //DarkBlue = 1
                        0x008000, //DarkGreen = 2
                        0x008080, //DarkCyan = 3
                        0x800000, //DarkRed = 4
                        0x800080, //DarkMagenta = 5
                        0x808000, //DarkYellow = 6
                        0xC0C0C0, //Gray = 7
                        0x808080, //DarkGray = 8
                        0x0000FF, //Blue = 9
                        0x00FF00, //Green = 10
                        0x00FFFF, //Cyan = 11
                        0xFF0000, //Red = 12
                        0xFF00FF, //Magenta = 13
                        0xFFFF00, //Yellow = 14
                        0xFFFFFF  //White = 15
                    };
            return Color.FromArgb(cColors[(int)c]);
        }

        static ConsoleColor coloring(Color CValue)
        {
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            double min = Double.MaxValue;
            ConsoleColor ansColor = new ConsoleColor();
            foreach (var color in colors)
            {
                Color cur = FromColor(color);
                double ans = Math.Sqrt(Math.Pow((cur.R - CValue.R), 2.0) +
                    Math.Pow((cur.G - CValue.G), 2.0) + Math.Pow((cur.B - CValue.B), 2.0));
                if (min > ans)
                {
                    ansColor = color;
                    min = ans;
                }
            }
            return ansColor;
        }

        public static void ConsoleWriteImage(Bitmap bmpSrc)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            int sMax = 39;
            decimal percent = Math.Min(decimal.Divide(sMax, bmpSrc.Width), decimal.Divide(sMax, bmpSrc.Height));
            Size resSize = new Size((int)(bmpSrc.Width * percent), (int)(bmpSrc.Height * percent));
            Bitmap bmpMax = new Bitmap(bmpSrc, resSize.Width * 2, resSize.Height * 2);

            for (int i = 0; i < resSize.Height; i++)
            {
                for (int j = 0; j < resSize.Width; j++)
                {
                    Console.ForegroundColor = (ConsoleColor)coloring(bmpMax.GetPixel(j * 2, i * 2));
                    Console.BackgroundColor = (ConsoleColor)coloring(bmpMax.GetPixel(j * 2, i * 2 + 1));
                    Console.Write("▀");

                    Console.ForegroundColor = (ConsoleColor)coloring(bmpMax.GetPixel(j * 2 + 1, i * 2));
                    Console.BackgroundColor = (ConsoleColor)coloring(bmpMax.GetPixel(j * 2 + 1, i * 2 + 1));
                    Console.Write("▀");
                }
                Console.WriteLine();
            }
            Console.SetCursorPosition(0, 0);
            Console.ResetColor();
        }
    }
}
