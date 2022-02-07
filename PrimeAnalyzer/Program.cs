using System;
using System.Collections.Generic;

namespace PrimeAnalyzer
{
    class Program
    {
        private static void Main()
        {
            for (int i = 2; i < 1000; ++i)
            {
                Console.Write(i + " is");
                if (!IsPrime(i))
                {
                    Console.Write(" not");
                }
                Console.Write(" a prime number.");
                if (!IsPrime(i))
                {
                    Console.Write(" Its prime factors are: ");

                    List<int> primeFactors = ComputePrimeFactors(i);

                    for (int j = 0; j < primeFactors.Count - 1; ++j)
                    {
                        Console.Write(primeFactors[j]);
                        Console.Write(", ");
                    }
                    Console.Write(primeFactors[^1]);
                }
                Console.WriteLine();
            }
        }

        private static List<int> ComputePrimeFactors(int n)
        {
            List<int> result = new();

            if (IsPrime(n))
            {
                // If n is a prime then return n itself
                result.Add(n);
            }
            else
            {
                // Otherwise find the smallest prime factor
                for (int i = 2; i < n; ++i)
                {
                    if (n % i == 0)
                    {
                        // no remainder means that i is the smallest factor
                        result.Add(i);

                        // divide the number by this smallest factor and recurse
                        result.AddRange(ComputePrimeFactors(n / i));

                        break;
                    }
                }
            }
            return result;
        }

        private static bool IsPrime(int n)
        {
            // by definition primes must always be greater than 1
            if (n < 2)
            {
                return false;
            }

            for (int i = 2; i < n; ++i)
            {
                if (n % i == 0)
                {
                    // no remainder means that this is not a prime
                    return false;
                }
            }

            // the if above was never true, hence this must be a prime
            return true;
        }
    }
}
