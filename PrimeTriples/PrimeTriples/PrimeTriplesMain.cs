using System;
using System.Collections.Generic;

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
        public static long Modulo(long a, long b)
        {
            return a - b * ((long) Math.Floor((Convert.ToDouble(a) / Convert.ToDouble(b))));
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
                {
                    totalMultipliedMod *= powerMods[bitIndex];
                }
            }

            long result = Modulo(totalMultipliedMod, c);

            return result;
        }

        public static bool RunBailliePSWPrimalityTest(long n)
        {

            //Check here if n is a perfect square

            //Run trial division on n using primes 2 through 1000

            if (!IsBaseTwoStrongProbablePrime(n))
            {
                return false;
            }

            long D = GenerateStrongLucasProbablePrimeParameter(n);
            IsStrongLucasProbablePrime(D);


            return true;
        }

        public static bool IsStrongLucasProbablePrime(long D)
        {
            GenerateLucasSequencesUandV(D);

            return false;
        }

        //Item1 = U; Item2 = V
        public static Tuple<Dictionary<long, long>, Dictionary<long, long>> GenerateLucasSequencesUandV(long D) //this can probably be optimized more
        {
            Dictionary<long, long> U = new Dictionary<long, long>();
            Dictionary<long, long> V = new Dictionary<long, long>();

            return null;
        }

        public static long a(long n, long P, long D)
        {
            return (long) (0.5 * (P + Math.Sqrt(D)));
        }

        public static long b(long n, long P, long D)
        {
            return (long) (0.5 * (P - Math.Sqrt(D)));
        }

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

            if (PowerModulo(2, d, n) == PowerModulo(1, 1, n)) //O(1) //Look into using bitwise AND for this moduloing of 2
            {
                return true;
            }

            for (long r = 0; r < s; r++) //O(s - 1) == O(log(n))
            {
                long power =  d * (long) Math.Pow(2, r);
                if (PowerModulo(2, power, n) == PowerModulo(-1, 1, n))
                {
                    return true;
                }
            }
            return false;
        }

        public static long GenerateStrongLucasProbablePrimeParameter(long n)
        {
            long D = 5;
            while (CalculateJacobiSymbol(D, n) != -1)
            {
                if (D > 0)
                {
                    D = -1 * (D + 2);
                }

                else
                {
                    D = -1 * (D - 2);
                }
            }

            return D;
        }

        public static long CalculateJacobiSymbol(long a, long b)
        {
            if (b <= 0 || (Modulo(b, 2)) == 0)
            {
                return 0;
            }
            long j = 1;
            if (a < 0)
            {
                a = -a;
                if (Modulo(b, 4) == 3)
                {
                    j = -j;
                }
            }

            while (a != 0)
            {
                while ((Modulo(a, 2) == 0))
                {
                    a = a / 2;
                    if ((Modulo(b, 8)) == 3 || (Modulo(b, 8)) == 5)
                    {
                        j = -j;
                    }
                }

                long temp = a;
                a = b;
                b = temp;

                if ((Modulo(a, 4)) == 3 && (Modulo(b, 4)) == 3) j = -j;
                a = Modulo(a, b);
            }
            if (b == 1)
            {
                return (j);
            }
            else
            {
                return (0);
            }
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

    public ulong GetRowEndNumber(ulong n) //O(n)
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
