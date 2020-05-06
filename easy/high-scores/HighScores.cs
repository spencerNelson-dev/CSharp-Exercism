using System;
using System.Collections.Generic;
using System.Linq;

public class HighScores
{
    private List<int> SCORES { get; set; }

    public HighScores(List<int> list)
    {
        this.SCORES = list;
    }

    public List<int> Scores()
    {
        return SCORES;
    }

    public int Latest()
    {
        return SCORES[SCORES.Count - 1];
    }

    public int PersonalBest()
    {
        return SCORES.Max();
    }

    public List<int> PersonalTopThree()
    {
        return SCORES.OrderByDescending(x => x).Take(3).ToList();
    }
}