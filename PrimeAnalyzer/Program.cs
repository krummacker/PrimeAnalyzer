using System;

namespace PrimeAnalyzer
{
    class Program
    {
        /// <summary>
        /// Called when the program is started.
        /// </summary>
        /// <param name="args">
        /// Command line arguments. If specified, then interpreted as numbers
        /// that define in which interval numbers are computed.
        /// </param>
        private static void Main(string[] args)
        {
            PrimeFactorDisassembler disassembler = new();

            int start = 0;
            int end = 1000;
            if (args.Length == 2)
            {
                start = int.Parse(args[0]);
                end = int.Parse(args[1]);
            }

            int begin = DateTime.Now.Millisecond;

            for (int i = start; i < end; ++i)
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

            int finish = DateTime.Now.Millisecond;
            Console.WriteLine();
            Console.WriteLine("Runime in milliseconds: " + (finish - begin));
        }
    }
}
