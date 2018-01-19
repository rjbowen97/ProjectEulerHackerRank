using System;
using System.Collections.Generic;


//Look into using structs instead of classes in this
namespace PrimeTriples
{
    class PrimeTriplesMain
    {
        static void Main(string[] args)
        {
            TriangleRow triangleRow = new TriangleRow(100);
            Console.WriteLine(triangleRow.ToString());
        }
    }

    public static class PrimeCalculator
    {
        public static bool RunBailliePSWPrimalityTest(long n)
        {
            //Check here if n is a perfect square

            //Run trial division on n using primes 2 through 1000

            if (!BaseTwoStrongProbablePrimeCalculator.IsBaseTwoStrongProbablePrime(n))
                return false;

            LucasStrongProbablePrimeCalculator.IsStrongLucasProbablePrime(n);

            return true;
        }
    }

    public static class LucasStrongProbablePrimeCalculator
    {
        public static bool IsStrongLucasProbablePrime(long n)
        {
            long D = GenerateStrongLucasProbablePrimeParameter(n);

            long delta = CalculateDelta(n, D);

            Tuple<long, long> d_And_s = FactorDeltaInto_d_TwoToThe_s(delta);

            long d = d_And_s.Item1;
            long s = d_And_s.Item2;

            long P = 1;
            long Q = (1 - D) / 4;
            GenerateULucasNumberAtTargetIndex(D, P, Q, d);

            return false;
        }

        public static long CalculateDelta(long n, long D)
        {
            return n - CalculateJacobiSymbol(D, n);
        }

        public static Tuple<long, long> FactorDeltaInto_d_TwoToThe_s(long delta) //Item1 = d; Item2 = s
        {
            long d = delta;
            long s = 0;

            for (long testS = 0; testS < Math.Log(delta, 2); testS++) //O(log(n))
            {
                for (long testD = 1; testD < delta; testD += 2) //O(n) (check to see what limit must be here)
                {
                    if (delta == Math.Pow(2, testS) * testD) //delta = d*2^s
                    {
                        d = testD;
                        s = testS;
                    }
                }
            }

            return new Tuple<long, long>(d, s);
        }

        public static long GenerateULucasNumberAtTargetIndex(long D, long P, long Q, long targetIndex)
        {

            KeyValuePair<long, long> UCurrent = new KeyValuePair<long, long>(0, 0);
            KeyValuePair<long, long> UNext = new KeyValuePair<long, long>(1, 1);
            KeyValuePair<long, long> VCurrent = new KeyValuePair<long, long>(0, 2);
            KeyValuePair<long, long> VNext = new KeyValuePair<long, long>(1, P);

            string targetIndexInBinary = Convert.ToString(targetIndex, 2);
            char[] targetIndexBitArray = targetIndexInBinary.ToCharArray();
            Array.Reverse(targetIndexBitArray);

            while (UCurrent.Key != targetIndex)
            {

            }

            return 0;
        }

        public static KeyValuePair<long, long> DoubleU(KeyValuePair<long, long> UCurrentN, KeyValuePair<long, long> VCurrentN)
        {
            long indexToReturn = UCurrentN.Key * 2;

            long valueAtIndexToReturn = UCurrentN.Value * VCurrentN.Value;

            return new KeyValuePair<long, long>(indexToReturn, valueAtIndexToReturn);
        }

        public static long U_doubled_plus_one(long UCurrentN, long VCurrentN, long n, long Q)
        {
            long UOne = 1;
            long U_n_plus_one = 1;

            long U_two_n_plus_one = (U_n_plus_one * VCurrentN) - ((long)Math.Pow(Q, n));

            return 0;
        }

        public static long a(long n, long P, long D)
        {
            return (long)(0.5 * (P + Math.Sqrt(D)));
        }

        public static long b(long n, long P, long D)
        {
            return (long)(0.5 * (P - Math.Sqrt(D)));
        }

        public static long GenerateStrongLucasProbablePrimeParameter(long n)
        {
            bool nextNumberIsNegative = true;
            long D = 5;
            while (CalculateJacobiSymbol(D, n) != -1)
            {
                if (nextNumberIsNegative)
                {
                    D = -1 * (Math.Abs(D) + 2);
                    nextNumberIsNegative = !nextNumberIsNegative;
                }

                else
                {
                    D = (Math.Abs(D) + 2);
                    nextNumberIsNegative = !nextNumberIsNegative;
                }
            }

            return D;
        }

        public static long CalculateJacobiSymbol(long a, long b)
        {
            if (b <= 0 || (PrimeCalculatorUtilities.Modulo(b, 2)) == 0)
                return 0;

            long j = 1;
            if (a < 0)
            {
                a = -a;
                if (PrimeCalculatorUtilities.Modulo(b, 4) == 3)
                    j = -j;
            }

            while (a != 0)
            {
                while ((PrimeCalculatorUtilities.Modulo(a, 2) == 0))
                {
                    a = a / 2;
                    if ((PrimeCalculatorUtilities.Modulo(b, 8)) == 3 || (PrimeCalculatorUtilities.Modulo(b, 8)) == 5)
                        j = -j;
                }

                long temp = a;
                a = b;
                b = temp;

                if ((PrimeCalculatorUtilities.Modulo(a, 4)) == 3 && (PrimeCalculatorUtilities.Modulo(b, 4)) == 3)
                    j = -j;

                a = PrimeCalculatorUtilities.Modulo(a, b);
            }

            if (b == 1)
                return (j);
            else
                return (0);
        }
    }


    public static class BaseTwoStrongProbablePrimeCalculator
    {
        //Uses a strong probable prime test with base two
        public static bool IsBaseTwoStrongProbablePrime(long n)
        {
            long s = 0;
            long d = n;

            for (long testS = 0; testS < Math.Log(n, 2); testS++) //O(log(n))
            {
                for (long testD = 1; testD < n; testD += 2) //O(n) (check to see what limit must be here)
                {
                    if (n - 1 == Math.Pow(2, testS) * testD) //n = d*2^s + 1
                    {
                        s = testS;
                        d = testD;
                    }
                }
            }

            if (PrimeCalculatorUtilities.PowerModulo(2, d, n) == PrimeCalculatorUtilities.PowerModulo(1, 1, n)) //O(log n)
            {
                return true;
            }

            for (long r = 0; r < s; r++) //O(s - 1) == O(log(n))
            {
                long power = d * (long)Math.Pow(2, r);
                if (PrimeCalculatorUtilities.PowerModulo(2, power, n) == PrimeCalculatorUtilities.PowerModulo(-1, 1, n))
                    return true;
            }
            return false;
        }
    }

    public static class PrimeCalculatorUtilities
    {
        public static long Modulo(long a, long b)
        {
            return a - b * ((long)Math.Floor((Convert.ToDouble(a) / Convert.ToDouble(b))));
        }

        public static long PowerModulo(long a, long b, long c)
        {
            string bBinaryString = Convert.ToString(b, 2);
            char[] bitArray = bBinaryString.ToCharArray();

            long[] powerMods = new long[bitArray.Length];

            powerMods[0] = Modulo(a, c);

            for (int currentPowerModsIndex = 1; currentPowerModsIndex < powerMods.Length; currentPowerModsIndex++)
            {
                powerMods[currentPowerModsIndex] = Modulo(powerMods[currentPowerModsIndex - 1] * powerMods[currentPowerModsIndex - 1], c);
            }

            Array.Reverse(powerMods); //O(n)

            long totalMultipliedMod = 1;
            for (int bitIndex = 0; bitIndex < bitArray.Length; bitIndex++) //O(n)
            {
                if (bitArray[bitIndex] == '1')
                    totalMultipliedMod *= powerMods[bitIndex];
            }

            long result = Modulo(totalMultipliedMod, c);

            return result;
        }
    }
}

class TriangleRow
{
    ulong startNumber;
    ulong endNumber;

    public override string ToString()
    {
        return "startNumber: " + startNumber + "\nendNumber " + endNumber;
    }

    public TriangleRow(ulong n) //O(2n) == O(n)
    {
        startNumber = GetRowStartNumber(n);
        endNumber = GetRowEndNumber(n);
    }

    public ulong GetRowStartNumber(ulong n) //O(n)
    {
        return CalculatePrefixSum(n) + 1;
    }

    public ulong GetRowEndNumber(ulong n) //O(n) just use the rowstartnumber and add for efficiency
    {
        return CalculatePrefixSum(n + 1);
    }

    public ulong CalculatePrefixSum(ulong n) //O(n)
    {
        ulong prefixSum = 0;

        for (ulong i = 0; i <= n; i++)
        {
            prefixSum += i;
        }
        return prefixSum;
    }
}
