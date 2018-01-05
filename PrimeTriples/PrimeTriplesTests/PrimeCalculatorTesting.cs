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
            Assert.AreEqual(0, PrimeCalculator.Modulo(10, 2));
            Assert.AreEqual(2, PrimeCalculator.Modulo(12, 5));
            Assert.AreEqual(4, PrimeCalculator.Modulo(4, 19));
            Assert.AreEqual(0, PrimeCalculator.Modulo(7, 7));
            Assert.AreEqual(1, PrimeCalculator.Modulo(1, 4));
        }

        [TestMethod]
        public void IsBaseTwoStrongProbablePrimeTesting()
        {
            //Assert.IsTrue(PrimeCalculator.IsBaseTwoStrongProbablePrime(5));
            //Assert.IsTrue(PrimeCalculator.IsBaseTwoStrongProbablePrime(19));
            //Assert.IsTrue(PrimeCalculator.IsBaseTwoStrongProbablePrime(197));
            //Assert.IsTrue(PrimeCalculator.IsBaseTwoStrongProbablePrime(2047)); //Strong psuedoprime in base 2, actually composite

            //Assert.IsFalse(PrimeCalculator.IsBaseTwoStrongProbablePrime(10));
            //Assert.IsFalse(PrimeCalculator.IsBaseTwoStrongProbablePrime(1000));
            //Assert.IsFalse(PrimeCalculator.IsBaseTwoStrongProbablePrime(54));
            //Assert.IsFalse(PrimeCalculator.IsBaseTwoStrongProbablePrime(98));
        }

        [TestMethod]
        public void PowerModuloTesting()
        {
            PrimeCalculator.PowerModulo(500,117,19);
        }
    }
}
