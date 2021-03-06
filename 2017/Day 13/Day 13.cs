using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            // Day 13
            List<List<int>> day13LUT = File.ReadAllLines(@"input.txt").Select(l => l.Replace(" ", "").Split(':').Select(t => int.Parse(t)).ToList()).ToList();
            Console.WriteLine("Severity: " + day13LUT.Sum(s => (s[0] % (s[1] * 2 - 2) == 0 ? (s[0] * s[1]) : 0)));
            Console.WriteLine("Delay Required = " + Enumerable.Range(0, int.MaxValue).First(d => day13LUT.Sum(s => ((s[0] + d) % (s[1] * 2 - 2) == 0 ? 1 : 0)) == 0));
            Console.Read();
        }
    }
}