using System;
using System.Collections.Generic;
using System.Linq;

public enum Color { Red, Green, Ivory, Yellow, Blue }
public enum Nationality { Englishman, Spaniard, Ukranian, Japanese, Norwegian }
public enum Pet { Dog, Snails, Fox, Horse, Zebra }
public enum Drink { Coffee, Tea, Milk, OrangeJuice, Water }
public enum Smoke { OldGold, Kools, Chesterfields, LuckyStrike, Parliaments }

public static class ZebraPuzzle
{
    static List<int[]> solutionArray = Solver();

    public static Nationality DrinksWater()
    {
        foreach (var row in solutionArray)
        {
            Console.WriteLine($"({row[0]},{row[1]},{row[2]},{row[3]},{row[4]})");
        }
        Console.WriteLine("******");

        var IndexOfWater = solutionArray[3].ToList().IndexOf((int)Drink.Water);

        return (Nationality)solutionArray[1][IndexOfWater];
    }

    public static Nationality OwnsZebra()
    {
        var IndexOfZebra = solutionArray[2].ToList().IndexOf((int)Pet.Zebra);

        return (Nationality)solutionArray[1][IndexOfZebra];
    }

    public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
    {
        if (length == 1) return list.Select(t => new T[] { t });

        return GetPermutations(list, length - 1)
            .SelectMany(t => list.Where(e => !t.Contains(e)),
                (t1, t2) => t1.Concat(new T[] { t2 }));
    }

    public static List<int[]> Solver()
    {
        int[] houses = { 0, 1, 2, 3, 4 };

        var permutationOfHouses = GetPermutations(houses, houses.Length);

        List<int[]> solution = new List<int[]>();

        foreach (var houseColors in permutationOfHouses)
        {
            var colorList = houseColors.ToList();

            // 6 Green house is right of the ivory
            if (!HouseIsToTheRight(colorList.IndexOf((int)Color.Ivory), colorList.IndexOf((int)Color.Green)))
            {
                continue;
            }

            foreach (var houseNations in permutationOfHouses)
            {
                var nationList = houseNations.ToList();

                // 2. Englishman in Red house
                if (colorList.IndexOf((int)Color.Red) != nationList.IndexOf((int)Nationality.Englishman))
                {
                    continue;
                }
                // 10. Norwegian lives in the first house
                if (nationList.IndexOf((int)Nationality.Norwegian) != 0)
                {
                    continue;
                }
                // 15. Norwegian lives next to blue house
                if (!HouseIsNextTo(nationList.IndexOf((int)Nationality.Norwegian), colorList.IndexOf((int)Color.Blue)))
                {
                    continue;
                }

                foreach (var housePets in permutationOfHouses)
                {
                    var petList = housePets.ToList();

                    // 3. Spaniard owns the dog
                    if (nationList.IndexOf((int)Nationality.Spaniard) != petList.IndexOf((int)Pet.Dog))
                    {
                        continue;
                    }

                    foreach (var houseDrinks in permutationOfHouses)
                    {
                        var drinkList = houseDrinks.ToList();

                        // 4. Coffee in the green house
                        if (drinkList.IndexOf((int)Drink.Coffee) != colorList.IndexOf((int)Color.Green))
                        {
                            continue;
                        }
                        // 5. Ukrainian drinks tea
                        if (nationList.IndexOf((int)Nationality.Ukranian) != drinkList.IndexOf((int)Drink.Tea))
                        {
                            continue;
                        }
                        // 9. Milk is drunk in the middle house
                        if (drinkList.IndexOf((int)Drink.Milk) != 2)
                        {
                            continue;
                        }

                        foreach (var houseSmokes in permutationOfHouses)
                        {
                            var smokeList = houseSmokes.ToList();

                            // 7. Old Gold smoker owns snailes
                            if (smokeList.IndexOf((int)Smoke.OldGold) != petList.IndexOf((int)Pet.Snails))
                            {
                                continue;
                            }
                            // 8. Kools are smoked in the yellow house
                            if (smokeList.IndexOf((int)Smoke.Kools) != colorList.IndexOf((int)Color.Yellow))
                            {
                                continue;
                            }
                            // 11. Man who smokes chesterfields lives next to house with fox
                            if (!HouseIsNextTo(smokeList.IndexOf((int)Smoke.Chesterfields), petList.IndexOf((int)Pet.Fox)))
                            {
                                continue;
                            }
                            // 12. Kools are smoked next to the horse
                            if (!HouseIsNextTo(smokeList.IndexOf((int)Smoke.Kools), petList.IndexOf((int)Pet.Horse)))
                            {
                                continue;
                            }
                            // 13. LuckyStrike smoker drinks orange juice
                            if (smokeList.IndexOf((int)Smoke.LuckyStrike) != drinkList.IndexOf((int)Drink.OrangeJuice))
                            {
                                continue;
                            }
                            // 14. Japanese smokes parlaments
                            if (nationList.IndexOf((int)Nationality.Japanese) != smokeList.IndexOf((int)Smoke.Parliaments))
                            {
                                continue;
                            }

                            solution.Add(houseColors.ToArray());
                            solution.Add(houseNations.ToArray());
                            solution.Add(housePets.ToArray());
                            solution.Add(houseDrinks.ToArray());
                            solution.Add(houseSmokes.ToArray());
                        }
                    }
                }
            }
        }

        return solution;
    }

    public static bool HouseIsToTheRight(int house1, int house2)
    {
        if (house2 - house1 == 1)
        {
            return true;
        }

        return false;
    }

    public static bool HouseIsNextTo(int house1, int house2)
    {
        if (Math.Abs(house1 - house2) == 1)
        {
            return true;
        }

        return false;
    }

}