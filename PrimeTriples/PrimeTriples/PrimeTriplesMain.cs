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
            TriangleRow triangleRow = new TriangleRow(10000000);
            Console.WriteLine(triangleRow.ToString());
        }
    }

    class TriangleRow
    {
        ulong startNumber;
        ulong endNumber;

        public TriangleRow(ulong n)
        {
            startNumber = GetRowStartNumber(n);
            endNumber = GetRowEndNumber(n);
        }

        public override string ToString()
        {
            return "startNumber: " + startNumber + "\nendNumber " + endNumber;
        }

        private ulong GetRowStartNumber(ulong n)
        {
            return CalculatePrefixSum(n) + 1;
        }

        private ulong GetRowEndNumber(ulong n)
        {
            return CalculatePrefixSum(n + 1);
        }

        private ulong CalculatePrefixSum(ulong n)
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
