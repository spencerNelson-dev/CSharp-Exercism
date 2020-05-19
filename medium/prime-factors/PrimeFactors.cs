using System;
using System.Collections.Generic;

public static class PrimeFactors
{
    public static long[] Factors(long number)
    {
        List<long> output = new List<long>();

        if(number != 1)
        {
            // we start at two and work our way
            // through all the integers
            long factor = 2;

            while(number > 1)
            {
                while(number % factor == 0)
                {
                    output.Add(factor);

                    number /= factor;
                }

                // we can increase the factor by one here because,
                // even if we do check a non-prime factor we can be
                // sure that it will not factor into the number because
                // the smaller primes have been factored out.
                factor++;
            }
        }

        return output.ToArray();
    }
}