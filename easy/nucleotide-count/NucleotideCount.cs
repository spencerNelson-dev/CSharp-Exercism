using System;
using System.Collections.Generic;

public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        // Our dictionary to return
        IDictionary<char, int> nCount = new Dictionary<char, int>();
        nCount.Add('A', 0);
        nCount.Add('G', 0);
        nCount.Add('T', 0);
        nCount.Add('C', 0);

        // convert our string to a char array
        var charSequence = sequence.ToCharArray();

        // loop through each char and add to our dictionary
        foreach (char nuc in charSequence)
        {
            // check to see if nuc is a valid char
            // if it is add one
            if (nCount.ContainsKey(nuc))
            {
                nCount[nuc]++;
            }
            else
            {
                throw new ArgumentException();
            }

        }

        return nCount;

    }
}