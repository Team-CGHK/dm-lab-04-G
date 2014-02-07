using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;

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
            List<int>[] obj = new List<int>[k];
            for (int i = 0; i < obj.Length; i++)
                obj[i] = new List<int>();
            PartToSets(obj, set, 0);
            sw.Close();
        }

        //the recursion is based on set: on depth 'i' we add i-th item in set to subsets, which are appropriate to add the number to
        static void PartToSets(List<int>[] subsets, int[] set, int depth)
        {
            if (depth == set.Length)
            {
                if (subsets.All(x => x.Any()))
                {
                    foreach (List<int> subset in subsets)
                    {
                        foreach (int number in subset)
                            sw.Write(number + " ");
                        sw.WriteLine();
                    }
                    sw.WriteLine();
                }
                return;
            }
            int numberToAdd = set[depth];
            foreach (List<int> subset in subsets)
            {
                subset.Add(numberToAdd);
                PartToSets(subsets, set, depth + 1);
                subset.RemoveAt(subset.Count - 1);
                if (subset.Count == 0) break;
            }
        }
    }
}
