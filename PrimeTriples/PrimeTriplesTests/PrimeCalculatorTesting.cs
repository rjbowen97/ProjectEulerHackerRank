﻿using System;
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
            Assert.AreEqual(-2, PrimeCalculatorUtilities.Modulo(10, -3));
            Assert.AreEqual(-3, PrimeCalculatorUtilities.Modulo(12, -5));
            Assert.AreEqual(15, PrimeCalculatorUtilities.Modulo(-4, 19));
            Assert.AreEqual(0, PrimeCalculatorUtilities.Modulo(7, 7));
            Assert.AreEqual(1, PrimeCalculatorUtilities.Modulo(1, 4));
        }

        [TestMethod]
        public void PowerModuloTesting()
        {
            Assert.AreEqual(60, PrimeCalculatorUtilities.PowerModulo(500, 400, 134));
            Assert.AreEqual(109, PrimeCalculatorUtilities.PowerModulo(29, 2, 122));
            Assert.AreEqual(1, PrimeCalculatorUtilities. PowerModulo(57, 80, 8));
        }

        [TestMethod]
        public void IsBaseTwoStrongProbablePrimeTesting()
        {
            Assert.IsTrue(BaseTwoStrongProbablePrimeCalculator.IsBaseTwoStrongProbablePrime(5));
            Assert.IsTrue(BaseTwoStrongProbablePrimeCalculator.IsBaseTwoStrongProbablePrime(19));
            Assert.IsTrue(BaseTwoStrongProbablePrimeCalculator.IsBaseTwoStrongProbablePrime(197));
            Assert.IsTrue(BaseTwoStrongProbablePrimeCalculator.IsBaseTwoStrongProbablePrime(2047)); //Strong psuedoprime in base 2, actually composite

            Assert.IsFalse(BaseTwoStrongProbablePrimeCalculator.IsBaseTwoStrongProbablePrime(10));
            Assert.IsFalse(BaseTwoStrongProbablePrimeCalculator.IsBaseTwoStrongProbablePrime(1000));
            Assert.IsFalse(BaseTwoStrongProbablePrimeCalculator.IsBaseTwoStrongProbablePrime(54));
            Assert.IsFalse(BaseTwoStrongProbablePrimeCalculator.IsBaseTwoStrongProbablePrime(98));
        }

        [TestMethod]
        public void JacobiSymbolTesting()
        {
            Assert.AreEqual(-1, LucasStrongProbablePrimeCalculator.CalculateJacobiSymbol(3, 5));
            Assert.AreEqual(-1, LucasStrongProbablePrimeCalculator.CalculateJacobiSymbol(3, 17));
            Assert.AreEqual(0, LucasStrongProbablePrimeCalculator.CalculateJacobiSymbol(0, 9));
            Assert.AreEqual(1, LucasStrongProbablePrimeCalculator.CalculateJacobiSymbol(0, 1));
            Assert.AreEqual(1, LucasStrongProbablePrimeCalculator.CalculateJacobiSymbol(15, 17));
        }

        [TestMethod]
        public void GenerateStrongLucasProbablePrimeParameterTesting()
        {
            Assert.AreEqual(13, LucasStrongProbablePrimeCalculator.GenerateStrongLucasProbablePrimeParameter(11));
        }

        [TestMethod]
        public void CalculateDeltaTesting()
        {
            Assert.AreEqual(20, LucasStrongProbablePrimeCalculator.CalculateDelta(19, 13));
        }

        [TestMethod]
        public void FactorDeltaInto_d_TwoToThe_sTesting()
        {
            Tuple<long, long> testTuple1 = LucasStrongProbablePrimeCalculator.FactorDeltaInto_d_TwoToThe_s(20);

            Assert.AreEqual(5, testTuple1.Item1);
            Assert.AreEqual(2, testTuple1.Item2);
        }
    }
}
