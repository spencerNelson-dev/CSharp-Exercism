using System;

public static class Gigasecond
{
    public static DateTime Add(DateTime moment)
    {
        var GIGASEC = Math.Pow(10, 9);

        return moment.AddSeconds(GIGASEC);
    }
}