using System;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        int hammingDistance = 0;

        // empty strings
        if(firstStrand.Length == 0 && secondStrand.Length == 0)
        {
            hammingDistance = 0;
        } 
        // strings of different lengths
        else if (firstStrand.Length != secondStrand.Length)
        {
            throw new ArgumentException();
        }
        // main hamming distance calculation
        else
        {
            for(int index = 0; index < firstStrand.Length; index++)
            {
                if(firstStrand[index] != secondStrand[index])
                {
                    hammingDistance++;
                }
            }
        }

        return hammingDistance;
    }
}