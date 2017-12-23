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
            long rowStartNumber = CalculatePrefixSum(10000000) + 1;
            long rowEndNummber = CalculatePrefixSum(10000001);

            Console.WriteLine(Math.Log(rowEndNummber, 2));
        }

        static long CalculatePrefixSum(long n)
        {
            long prefixSum = 0;

            for (long i = 0; i <= n; i++)
            {
                prefixSum += i;
            }
            return prefixSum;
        }
    }
}
