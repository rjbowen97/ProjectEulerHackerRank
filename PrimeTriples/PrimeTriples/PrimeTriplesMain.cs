using System;

namespace PrimeTriples
{
    class PrimeTriplesMain
    {
        static void Main(string[] args)
        {
            TriangleRow triangleRow = new TriangleRow(100);
            Console.WriteLine(triangleRow.ToString());

            Console.WriteLine(PrimeCalculator.IsBaseTwoStrongProbablePrime(2047));
        }
    }

    static class PrimeCalculator
    {
        //Uses a strong probable prime test with base two
        public static bool IsBaseTwoStrongProbablePrime(double n)
        {
            double s = 0;
            double d = n;

            for (double testS = 0; testS < Math.Log(n, 2); testS++) //O(log(n))
            {
                for (double testD = 1; testD < n; testD += 2) //O(n) (check to see what limit must be here)
                {
                    if (n - 1 == Math.Pow(2, testS) * testD) //n = d*2^s + 1
                    {
                        s = testS;
                        d = testD;
                    }
                }
            }

            if ((Modulo(Math.Pow(2, d) - 1, n) == 0)) //O(1)
            {
                return true;
            }

            for (double r = 0; r < s; r++) //O(s - 1) == O(log(n))
            {
                if (Modulo((Math.Pow(2, d * Math.Pow(2, r)) + 1), n) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        static double Modulo(double a, double b)
        {
            return a - b * Math.Floor(a / b);
        }

        static bool IsStrongLucasProbablePrime(double n)
        {
            double D = 5;
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
        }

        static double CalculateJacobiSymbol(double a, double b)
        {
            if (b <= 0 || (Modulo(b, 2)) == 0)
            {
                return 0;
            }
            double j = 1;
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

                double temp = a;
                a = b;
                b = temp;

                if ((Modulo(a, 4)) == 3 && (Modulo(b, 4)) == 3) j = -j;
                a = Modulo(a,b);
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

    private ulong GetRowStartNumber(ulong n) //O(n)
    {
        return CalculatePrefixSum(n) + 1;
    }

    private ulong GetRowEndNumber(ulong n) //O(n)
    {
        return CalculatePrefixSum(n + 1);
    }

    private ulong CalculatePrefixSum(ulong n) //O(n)
    {
        ulong prefixSum = 0;

        for (ulong i = 0; i <= n; i++)
        {
            prefixSum += i;
        }
        return prefixSum;
    }
}
