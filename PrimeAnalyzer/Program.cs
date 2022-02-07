using System;

namespace PrimeAnalyzer
{
    class Program
    {
        /// <summary>
        /// Called when the program is started.
        /// </summary>
        /// <param name="args">
        /// Command line arguments. If specified, then interpreted as a number
        /// that defines how many numbers are computed.
        /// </param>
        private static void Main(string[] args)
        {
            PrimeFactorDisassembler disassembler = new();

            int end = 1000;
            if (args.Length != 0)
            {
                end = int.Parse(args[0]);
            }

            for (int i = 0; i < end; ++i)
            {
                Console.Write(i + " is");

                var primeFactors = disassembler.ComputePrimeFactors(i);
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
    }
}
