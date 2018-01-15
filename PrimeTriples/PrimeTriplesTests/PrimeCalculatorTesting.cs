using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeTriples;

namespace PrimeTriplesTests
{
    [TestClass]
    public class PrimeCalculatorTesting
    {
        [TestMethod]
        public void ModuloTesting()
        {
            Assert.AreEqual(-2, PrimeCalculator.Modulo(10, -3));
            Assert.AreEqual(-3, PrimeCalculator.Modulo(12, -5));
            Assert.AreEqual(15, PrimeCalculator.Modulo(-4, 19));
            Assert.AreEqual(0, PrimeCalculator.Modulo(7, 7));
            Assert.AreEqual(1, PrimeCalculator.Modulo(1, 4));
        }

        [TestMethod]
        public void IsBaseTwoStrongProbablePrimeTesting()
        {
            Assert.IsTrue(PrimeCalculator.IsBaseTwoStrongProbablePrime(5));
            Assert.IsTrue(PrimeCalculator.IsBaseTwoStrongProbablePrime(19));
            Assert.IsTrue(PrimeCalculator.IsBaseTwoStrongProbablePrime(197));
            Assert.IsTrue(PrimeCalculator.IsBaseTwoStrongProbablePrime(2047)); //Strong psuedoprime in base 2, actually composite

            Assert.IsFalse(PrimeCalculator.IsBaseTwoStrongProbablePrime(10));
            Assert.IsFalse(PrimeCalculator.IsBaseTwoStrongProbablePrime(1000));
            Assert.IsFalse(PrimeCalculator.IsBaseTwoStrongProbablePrime(54));
            Assert.IsFalse(PrimeCalculator.IsBaseTwoStrongProbablePrime(98));
        }

        [TestMethod]
        public void PowerModuloTesting()
        {
            Assert.AreEqual(60, PrimeCalculator.PowerModulo(500, 400, 134));
            Assert.AreEqual(109, PrimeCalculator.PowerModulo(29, 2, 122));
            Assert.AreEqual(1, PrimeCalculator. PowerModulo(57, 80, 8));
        }

        [TestMethod]
        public void JacobiSymbolTesting()
        {
            Assert.AreEqual(-1, PrimeCalculator.CalculateJacobiSymbol(3, 5));
            Assert.AreEqual(-1, PrimeCalculator.CalculateJacobiSymbol(3, 17));
            Assert.AreEqual(0, PrimeCalculator.CalculateJacobiSymbol(0, 9));
            Assert.AreEqual(1, PrimeCalculator.CalculateJacobiSymbol(0, 1));
            Assert.AreEqual(1, PrimeCalculator.CalculateJacobiSymbol(15, 17));
        }

        [TestMethod]
        public void GenerateStrongLucasProbablePrimeParameterTesting()
        {
            Assert.AreEqual(13, PrimeCalculator.GenerateStrongLucasProbablePrimeParameter(11));
        }

        [TestMethod]
        public void CalculateDeltaTesting()
        {
            Assert.AreEqual(20, PrimeCalculator.CalculateDelta(19, 13));
        }

        [TestMethod]
        public void FactorDeltaInto_d_TwoToThe_sTesting()
        {
            Tuple<long, long> testTuple1 = PrimeCalculator.FactorDeltaInto_d_TwoToThe_s(20);

            Assert.AreEqual(5, testTuple1.Item1);
            Assert.AreEqual(2, testTuple1.Item2);
        }
    }
}
