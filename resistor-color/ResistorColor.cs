using System;

public static class ResistorColor
{
    public static int ColorCode(string color)
    {
        int colorIndex = 0;
        var colors = Colors();

       for(int index = 0; index < colors.Length; index++){

           if(colors[index] == color){
               colorIndex = index;
           }
       }

       return colorIndex;
    }

    public static string[] Colors()
    {
        return new[] { "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white" };
    }
}

/*
- Black: 0
- Brown: 1
- Red: 2
- Orange: 3
- Yellow: 4
- Green: 5
- Blue: 6
- Violet: 7
- Grey: 8
- White: 9 
*/