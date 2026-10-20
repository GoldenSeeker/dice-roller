using System;
using System.Collections.Generic;   // needed for List<int>

class Program
{
    static void Main()
    {
        Console.WriteLine("DICE ROLLER");

        List<int> history = new List<int>();   // empty list of totals
        Random rng = new Random();

        while (true)
        {
            // ask how many dice and sides
            Console.Write("How many dice? ");
            int numDice = int.Parse(Console.ReadLine());

            Console.Write("How many sides per die? ");
            int numSides = int.Parse(Console.ReadLine());

            //roll them
            List<int> rolls = new List<int>();
            int total = 0;

            for (int i = 0; i < numDice; i++)
            {
                int roll = rng.Next(1, numSides + 1);   // +1 because upper bound is excluded
                rolls.Add(roll);
                total = total + roll;
            }

            // show result
            Console.Write("Rolls: ");
            foreach (int r in rolls)
            {
                Console.Write(r + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Total: " + total);

            // remember it
            history.Add(total);

            // ask again?
            Console.Write("Roll again? (yes / no): ");
            string answer = Console.ReadLine().Trim().ToLower();
            if (answer != "yes")
                break;
        }

        //stats at the end
        Console.WriteLine("\n STATS");
        Console.WriteLine("Number of rolls: " + history.Count);

        Console.Write("All totals: ");
        foreach (int v in history)
        {
            Console.Write(v + " ");
        }
        Console.WriteLine();

        int totalSum = 0;
        int highest = history[0];
        int lowest = history[0];

        foreach (int value in history)
        {
            totalSum = totalSum + value;
            if (value > highest) highest = value;
            if (value < lowest) lowest = value;
        }

        double average = (double)totalSum / history.Count;
        Console.WriteLine("Average: " + average);
        Console.WriteLine("Highest: " + highest);
        Console.WriteLine("Lowest: " + lowest);
    }
}