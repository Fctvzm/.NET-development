using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levenshtein_algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            String x, y;
            x = Console.ReadLine();
            y = Console.ReadLine();
            int n = x.Length, m = y.Length;
            int[,] D = new int[n + 1, m + 1];
            int s;

            for (int i = 0; i <= m; i++)
                D[0, i] = i;
            for (int i = 1; i <= n; i++)
                D[i, 0] = i;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (x[i - 1] == y[j - 1]) s = D[i -1, j - 1];
                    else s = D[i - 1, j - 1] + 2;
                    D[i, j] = Math.Min(s, Math.Min(D[i - 1, j] + 1, D[i, j - 1] + 1));
                }
            }
            int ans = D[n, m];
            Console.WriteLine(ans);
            Console.ReadKey();

        }
    }
}
