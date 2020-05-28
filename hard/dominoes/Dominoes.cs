using System;
using System.Collections.Generic;
using System.Linq;

public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        var result = false;

        var dominoesList = dominoes.ToList();

        // if no dominos
        if (!dominoes.Any())
        {
            return true;
        }

        // if one domino
        if (dominoes.Count() == 1)
        {
            if (dominoes.ElementAt(0).Item1 == dominoes.ElementAt(0).Item2)
            {
                return true;
            }
        }

        var chain = new List<(int, int)>();

        // add the first domino to our chain
        chain.Add(dominoesList.ElementAt(0));

        // remove that element from our dominoes list
        dominoesList.RemoveAt(0);

        // loop throuh our domino list
        for (var i = 0; i < dominoes.Count() - 1; i++)
        {
            // find the index of the domino that the left number matches
            // the left number of the first domino in the chain
            var nextDomIdex = dominoesList.FindIndex(dom => dom.Item1 == chain[0].Item1);

            // if no such domino exists
            if (nextDomIdex < 0)
            {
                // find the index of the domino that the right number matches
                // the left number of the first domino in the chain
                nextDomIdex = dominoesList.FindIndex(dom => dom.Item2 == chain[0].Item1);
            }
            // if the left side matches the right
            else
            {

                // flip the domino and add it to our chain
                var nextDom = dominoesList[nextDomIdex];
                var flipDom = (nextDom.Item2, nextDom.Item1);

                chain.Insert(0, flipDom);

                dominoesList.RemoveAt(nextDomIdex);

                continue;
            }

            // if no matching numbers are found in the remaining
            // dominoes then return false, as no chain can be made
            if (nextDomIdex < 0)
            {
                return false;
            }
            // if the right number of next domino
            // matches left number of first domino
            else
            {
                var nextDom = dominoesList[nextDomIdex];
                chain.Insert(0, nextDom);

                dominoesList.RemoveAt(nextDomIdex);

            }
        }

        // check if our chain's first and last numbers match
        if (chain.ElementAt(0).Item1 == chain.Last().Item2)
        {
            result = true;
        }

        return result;
    }
}