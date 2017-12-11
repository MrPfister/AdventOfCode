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
            // Day 6
            int[] memorybank = new int[] { 11, 11, 13, 7, 0, 15, 5, 5, 4, 4, 1, 1, 7, 1, 15, 11 }; // Input

            List<int> hashes = new List<int>();
            int hashforthewin = 1562633079; // Note: Hash code from the final looped value
            int start = 0;

            hashes.Add(GetStringList(memorybank).GetHashCode());

            int iterations = 0;
            while (true)
            {
                iterations++;
                // Find the largest in the list
                int largest = memorybank.Max();

                // Find the first position with it
                int location = 0;
                for (int i = 0; i < memorybank.Length; i++)
                {
                    if (memorybank[i] == largest)
                    {
                        location = i;
                        break;
                    }
                }

                memorybank[location] = 0;
                location++;

                // Redistribute
                for (int i = 0; i < largest; i++)
                {
                    memorybank[(location + i) % memorybank.Length]++;
                }

                // Create new hashcode
                int newhash = GetStringList(memorybank).GetHashCode();

                if (hashes.Contains(newhash))
                {
                    // Loop encountered.
                    Console.WriteLine("Hash: " + newhash); // Stored in hashforthewin
                    break;
                }
                else
                {
                    hashes.Add(newhash);
                    if (newhash == hashforthewin)
                    {
                        start = iterations;
                    }
                }
            }

            Console.WriteLine(iterations);
            Console.WriteLine(iterations - start);
            Console.Read();
        }
    }
}