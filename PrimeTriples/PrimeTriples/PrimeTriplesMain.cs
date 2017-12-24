using System;
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
            ulong rowStartNumber = GetRowStartNumber(10000000);
            ulong rowEndNummber = GetRowEndNumber(10000001);
        }

        static ulong GetRowStartNumber(ulong n)
        {
            return CalculatePrefixSum(n) + 1;
        }

        static ulong GetRowEndNumber(ulong n)
        {
            return CalculatePrefixSum(n + 1);
        }

        static ulong CalculatePrefixSum(ulong n)
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
