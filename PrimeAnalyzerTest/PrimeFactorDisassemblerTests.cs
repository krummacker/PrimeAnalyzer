// Copyright (c) Dirk Krummacker

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeAnalyzer;
using System.Linq;

namespace PrimeAnalyzerTest
{
    [TestClass]
    public class PrimeFactorDisassemblerTest
    {
        [TestMethod]
        public void ComputePrimeFactors_WithNonPrime_ComputesValidFactors()
        {
            // Arrange
            int nonPrime = 8;
            List<int> expected = new() { 2, 2, 2 };
            PrimeFactorDisassembler disassembler = new();

            // Act
            List<int> actual = disassembler.ComputePrimeFactors(nonPrime);

            // Assert
            bool equal = expected.SequenceEqual(actual);
            Assert.IsTrue(equal, "non-prime not computed correctly");
        }

        [TestMethod]
        public void ComputePrimeFactors_WithPrime_ComputesOnlySelf()
        {
            // Arrange
            int prime = 499;
            List<int> expected = new() { 499 };
            PrimeFactorDisassembler disassembler = new();

            // Act
            List<int> actual = disassembler.ComputePrimeFactors(prime);

            // Assert
            bool equal = expected.SequenceEqual(actual);
            Assert.IsTrue(equal, "prime not computed correctly");
        }

        [TestMethod]
        public void ComputePrimeFactors_With1_ComputesEmptyList()
        {
            // Arrange
            int one = 1;
            List<int> expected = new() { };
            PrimeFactorDisassembler disassembler = new();

            // Act
            List<int> actual = disassembler.ComputePrimeFactors(one);

            // Assert
            bool equal = expected.SequenceEqual(actual);
            Assert.IsTrue(equal, "1 not computed to empty list");
        }

        [TestMethod]
        public void ComputePrimeFactors_WithNegativeNumber_ComputesEmptyList()
        {
            // Arrange
            int negativeNumber = -10;
            List<int> expected = new() { };
            PrimeFactorDisassembler disassembler = new();

            // Act
            List<int> actual = disassembler.ComputePrimeFactors(negativeNumber);

            // Assert
            bool equal = expected.SequenceEqual(actual);
            Assert.IsTrue(equal, "negative number not computed to empty list");
        }
    }
}
