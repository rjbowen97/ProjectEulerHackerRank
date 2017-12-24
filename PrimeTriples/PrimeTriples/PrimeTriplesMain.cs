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
            ulong rowStartNumber = CalculatePrefixSum(10000000) + 1;
            ulong rowEndNummber = CalculatePrefixSum(10000001);
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
