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
            // Day 8
            int largestRegisterEver = 0;
            Dictionary<string, int> registers = new Dictionary<string, int>();
            foreach (string registerInput in File.ReadAllLines(@"input.txt"))
            {
                string[] info = registerInput.Split(' ');
                int queryVal = registers.ContainsKey(info[4]) ? registers[info[4]] : 0;

                if ((info[5] == ">") ? (queryVal > int.Parse(info[6])) :
                    (info[5] == ">=") ? (queryVal >= int.Parse(info[6])) :
                    (info[5] == "<") ? (queryVal < int.Parse(info[6])) :
                    (info[5] == "<=") ? (queryVal <= int.Parse(info[6])) :
                    (info[5] == "!=") ? (queryVal != int.Parse(info[6])) :
                    (info[5] == "==") ? (queryVal == int.Parse(info[6])) :
                    false)
                {
                    registers[info[0]] = ((registers.ContainsKey(info[0])) ? registers[info[0]] : 0) + ((info[1] == "inc") ? int.Parse(info[2]) : -int.Parse(info[2]));
                    largestRegisterEver = Math.Max(largestRegisterEver, registers[info[0]]);
                }
            }

            // Find the largest registers
            Console.WriteLine("Largest: " + registers.Max(r => r.Value));
            Console.WriteLine("Largest Ever: " + largestRegisterEver);
            Console.Read();
        }
    }
}