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
            Console.WriteLine("Hello world!");
        }

        static HashSet<double> getPrimeBooleans(int n)
        {
            HashSet<int> NoPrime = new HashSet<int>();

            long count = 0;

            for (int x = 2; x < n; x++)
            {
                for (int y = x * 2; y < n; y = y + x)
                {
                    if (!NoPrime.Contains(y))
                    {
                        NoPrime.Add(y);
                    }
                }

                for (int z = 2; z < n; z++)
                {
                    if (!NoPrime.Contains(z))
                    {
                        Console.WriteLine(z);
                        count = count + z;
                    }
                }
                Console.WriteLine("Sum is: " + count);
            }

        }
    }
}
