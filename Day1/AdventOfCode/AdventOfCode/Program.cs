using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

List<int> firstGroup = new List<int>();
List<int> secondGroup = new List<int>();

try 
{
    string[] lines = File.ReadAllLines(@$"C:\Users\johns\Documents\Projects\Day1\AdventOfCode\AdventOfCode\input.txt");

    foreach (string line in lines)
    {
        var values = line.Split("   ");

        firstGroup.Add(Convert.ToInt32(values[0].Trim()));
        secondGroup.Add(Convert.ToInt32(values[1].Trim()));
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Didn't work... you suck! {ex.Message}");
}

if (firstGroup.Count > 0)
{
    firstGroup.Sort();
    secondGroup.Sort();

    var sum = 0;

    for (int i = 0; i < firstGroup.Count; i++)
    {
        sum += Math.Abs(firstGroup[i] - secondGroup[i]);
    }

    Console.WriteLine($"Total value = {sum}.");

    List<int> valueScore = new List<int>();

    // Get the similarity score
    foreach (int val in firstGroup) 
    {        
        var count = secondGroup.Count(x => x == val);
        valueScore.Add(val * count);
    }

    Console.WriteLine($"The similarity score is {valueScore.Sum()}");
}