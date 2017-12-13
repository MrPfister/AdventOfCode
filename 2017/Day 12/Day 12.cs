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
            // Day 12
            List<List<int>> pipes = new List<List<int>>();
            foreach (List<int> values in File.ReadAllLines(@"input.txt").Select(l => l.Replace("<->", ",").Replace(" ", "").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(t => int.Parse(t)).ToList()))
            {
                var existingPipe = pipes.FirstOrDefault(p => p.Contains(values[0]));

                if (existingPipe != null)
                {
                    existingPipe.AddRange(values.GetRange(1, values.Count - 1));
                }
                else
                {
                    pipes.Add(values);
                }
            }

            // Reduce groups.
            while (true)
            {
                int currentProgress = 0;
                bool reductionOccured = false;
                for (int i = currentProgress; i < pipes.Count; i++)
                {
                    for (int j = 0; j < pipes.Count; j++)
                    {
                        if (i != j && pipes.ElementAt(i).Intersect(pipes.ElementAt(j)).ToList().Count > 0)
                        {
                            // There is a crossover
                            pipes[i].AddRange(pipes[j]);
                            pipes[i] = pipes[i].Distinct().ToList();
                            pipes.RemoveAt(j);
                            reductionOccured = true;
                            break;

                        }
                    }

                    if (reductionOccured)
                    {
                        currentProgress = i;
                        break;
                    }
                }


                if (!reductionOccured)
                {
                    break;
                }
            }
            Console.WriteLine("Connections to Pipe 0: " + pipes.First(p => p.Contains(0)).Count());
            Console.WriteLine("Total Groups: " + pipes.Count);
            Console.Read();
        }
    }
}