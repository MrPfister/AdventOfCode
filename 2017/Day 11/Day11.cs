using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static List<List<int>> ulam = new List<List<int>>();

        static void Main(string[] args)
        {
            // Day 11
            List<string> traversed = new List<string>();

            // Direct opposites
            Dictionary<string, string> opposites = new Dictionary<string, string>();
            opposites.Add("n", "s");
            opposites.Add("ne", "sw");
            opposites.Add("nw", "se");
            opposites.Add("s", "n");
            opposites.Add("se", "nw");
            opposites.Add("sw", "ne");

            // Reductions
            List<Tuple<string, string, string>> reductions = new List<Tuple<string, string, string>>();
            reductions.Add(new Tuple<string, string, string>("ne", "nw", "n"));
            reductions.Add(new Tuple<string, string, string>("se", "sw", "s"));
            reductions.Add(new Tuple<string, string, string>("n", "se", "ne"));
            reductions.Add(new Tuple<string, string, string>("n", "sw", "nw"));
            reductions.Add(new Tuple<string, string, string>("s", "ne", "se"));
            reductions.Add(new Tuple<string, string, string>("s", "nw", "sw"));

            int maxDist = 0;
            foreach (string token in File.ReadAllText(@"input.txt").Replace("\n", "").Split(','))
            {
                // Remove direct opposites
                if (!traversed.Remove(opposites[token]))
                {
                    traversed.Add(token);
                }

                // Perform reductions
                bool updated = true;
                while (updated)
                {
                    updated = false;
                    foreach (var t in reductions)
                    {
                        if (traversed.Contains(t.Item1) && traversed.Contains(t.Item2))
                        {
                            traversed.Remove(t.Item1);
                            traversed.Remove(t.Item2);
                            traversed.Add(t.Item3);
                            updated = true;
                        }
                    }
                }

                maxDist = Math.Max(maxDist, traversed.Count);
            }

            Console.WriteLine("Total: " + traversed.Count);
            Console.WriteLine("Max: " + maxDist);
            Console.Read();

        }
    }
}