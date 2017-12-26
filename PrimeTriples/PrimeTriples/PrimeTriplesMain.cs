﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeTriples
{
    class PrimeTriplesMain
    {
        static void Main(string[] args)
        {
            TriangleRow triangleRow = new TriangleRow(100);
            Console.WriteLine(triangleRow.ToString());

            Console.WriteLine(PrimeCalculator.IsStrongProbablePrime(2047));
        }
    }

    static class PrimeCalculator
    {
        //Uses a strong probable prime test with base two
        public static bool IsStrongProbablePrime(int n)
        {
            int s = 0;
            int d = n;

            for (int testS = 0; testS < Math.Log(n, 2); testS++) //O(log(n))
            {
                for (int testD = 1; testD < n; testD += 2) //O(n) (check to see what limit must be here)
                {
                    if (n - 1 == Math.Pow(2,testS) * testD) //n = d*2^s + 1
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

            for (int r = 0; r < s; r++) //O(s - 1) == O(log(n))
            {
                if (Modulo((Math.Pow(2, d*Math.Pow(2,r)) + 1), n) == 0)
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

}
