using System;
using System.Collections.Generic;

namespace PrimeAnalyzer
{
    class Program
    {
        /// <summary>a constant for a list of int with no elements</summary>
        private static readonly List<int> EmptyList = new();

        /// <summary>Called when the program is started.</summary>
        /// <param name="args">Command line arguments. If specified, then
        /// interpreted as a number that defines how many numbers are computed.
        /// </param>
        private static void Main(string[] args)
        {
            int end = 1000;
            if (args.Length != 0)
            {
                end = int.Parse(args[0]);
            }

            for (int i = 0; i < end; ++i)
            {
                Console.Write(i + " is");

                var primeFactors = ComputePrimeFactors(i);
                switch (primeFactors.Count)
                {
                    case 0:
                        Console.Write(" not a prime number (by definition).");
                        break;
                    case 1:
                        Console.Write(" a prime number.");
                        break;
                    default:
                        Console.Write(" not a prime number.");
                        Console.Write(" Its prime factors are: ");
                        for (int j = 0; j < primeFactors.Count - 1; ++j)
                        {
                            Console.Write(primeFactors[j]);
                            Console.Write(", ");
                        }
                        Console.Write(primeFactors[^1]);
                        break;
                }
                Console.WriteLine();
            }
        }

        /// <summary>For n>1, returns the list of prime numbers which,
        /// multiplied with each other, result in n. For n<=1, returns the
        /// empty list.</summary>
        /// <param name="n">The number to split into prime factors.</param>
        private static List<int> ComputePrimeFactors(int n)
        {
            if (n <= 1)
            {
                return EmptyList;
            }

            List<int> result = new();
            for (int i = 2; i < n; ++i)
            {
                if (n % i == 0)
                {
                    result.Add(i);
                    result.AddRange(ComputePrimeFactors(n / i));
                    return result;
                }
            }

            // if we iterated through the loop until this point then
            // n is already a prime
            result.Add(n);

            return result;
        }
    }
}
