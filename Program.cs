using System;
using System.IO;

namespace DiscreteMathLab4_G
{
    class Program
    {
        static StreamReader sr = new StreamReader("part2sets.in");
        static StreamWriter sw = new StreamWriter("part2sets.out");

        static void Main(string[] args)
        {
            string[] parts = sr.ReadLine().Split(' ');
            int n = int.Parse(parts[0]),
                k = int.Parse(parts[1]);
            int[] set = new int[n];
            for (int i = 0; i < n; i++)
                set[i] = i + 1;
            int[][] current = new int[k][];
            for (int i = 0; i<k; i++)
                current[i] = new int[0];
            PartToSets(current, set);
            sw.Close();
        }

        static void PartToSets(int[][] current, int[] set)
        {
            if (set.Length == 0)
            {
                bool complete = true;
                foreach (int[] a in current)
                    complete &= a.Length > 0;
                if (complete)
                {
                    for (int i = 0; i < current.Length; i++)
                    {
                        for (int j = 0; j < current[i].Length; j++)
                            sw.Write(current[i][j] + " ");
                        sw.WriteLine();
                    }
                    sw.WriteLine();
                }
            }
            else
            {
                int number = set[0];
                int[] nextset = new int[set.Length - 1];
                for (int i = 0; i < nextset.Length; i++)
                    nextset[i] = set[i + 1];
                bool firstempty = true;
                for (int j = 0; j < current.Length; j++)
                {
                    if (current[j].Length == 0 && firstempty ||
                        current[j].Length > 0 && current[j][current[j].Length - 1] < number)
                    {
                        int[][] next = new int[current.Length][];
                        for (int k = 0; k < current.Length; k++)
                        {
                            next[k] = new int[current[k].Length];
                            for (int m = 0; m < current[k].Length && k != j; m++)
                            {
                                next[k][m] = current[k][m];
                            }
                        }
                        int[] nextone = new int[current[j].Length + 1];
                        for (int k = 0; k < current[j].Length; k++)
                            nextone[k] = current[j][k];
                        nextone[nextone.Length - 1] = number;
                        next[j] = nextone;
                        PartToSets(next, nextset);
                    }
                    if (current[j].Length == 0) firstempty = false;
                }
            }
        }
    }
}
