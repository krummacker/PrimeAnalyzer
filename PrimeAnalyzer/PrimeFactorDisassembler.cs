using System.Collections.Generic;

namespace PrimeAnalyzer
{
    /// <summary>
    /// A PrimeFactorDisassembler can split up numbers into primes.
    /// </summary>
    public class PrimeFactorDisassembler
    {
        /// <summary>
        /// A constant for a list of int with no elements.
        /// </summary>
        private static readonly List<int> EmptyList = new();

        /// <summary>
        /// Creates a PrimeFactorDisassembler.
        /// </summary>
        public PrimeFactorDisassembler()
        {
        }

        /// <summary>
        /// For n>1, returns the list of prime numbers which, multiplied with
        /// each other, result in n. For n<=1, returns the empty list.
        /// </summary>
        /// <param name="n">The number to split into prime factors.</param>
        public List<int> ComputePrimeFactors(int n)
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
