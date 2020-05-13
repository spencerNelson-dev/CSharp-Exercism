using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

public class Robot
{
    public string Name;

    public Robot()
    {
        this.Name = MakeRobotName();
    }

    public void Reset()
    {
        this.Name = MakeRobotName();
    }

    private string MakeRobotName()
    {

        // defined the building blocks of our robot name
        var LetterChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        var NumberChars = "1234567890";

        // use random to get random names
        Random random = new Random();

        string name = "";

        do
        {
            // build the letter portion of the name
            var letters = new string(Enumerable.Repeat(LetterChars, 2)
                  .Select(s => s[random.Next(s.Length)]).ToArray());

            // build the number portion of the name
            var numbers = new string(Enumerable.Repeat(NumberChars, 3)
                  .Select(s => s[random.Next(s.Length)]).ToArray());

            name = letters + numbers;
            
        } while (RobotNames.UsedNames.Contains(name));

        RobotNames.UsedNames.Add(name);

        return name;
    }
}

public class RobotNames
{
    public static List<string> UsedNames = new List<string>();
}