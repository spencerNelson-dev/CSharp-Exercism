using System;

public static class Leap
{
    public static bool IsLeapYear(int year)
    {
        var isLeap = false;

        // check if divisible by 4
        if (year % 4 == 0)
        {
            isLeap = true;

            // except if divisible by 100
            if (year % 100 == 0)
            {
                isLeap = false;

                // unless divisible by 400
                if(year % 400 == 0) {

                    isLeap = true;
                }
            }
        }

        return isLeap;

    }
}

/*
```text
on every year that is evenly divisible by 4
  except every year that is evenly divisible by 100
    unless the year is also evenly divisible by 400
```
 */
