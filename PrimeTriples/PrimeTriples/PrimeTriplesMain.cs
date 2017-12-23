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
            Console.WriteLine(CalculatePrefixSum(10000000));

        }
        
        static Int64 CalculatePrefixSum(Int64 n)
        {
            Int64 prefixSum = 0;

            for (Int64 i = 0; i <= n; i++)
            {
                prefixSum += i;
            }
            return prefixSum;
        }

    }
}
