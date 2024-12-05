// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

List<string> lines = File.ReadAllLines(@$"C:\Users\johns\Documents\AdventOfCode\Day2\AoCDay2\input.txt").ToList();

int safeReps = 0;
int unsafeReps = 0;

// Get lines 
foreach (string report in lines)
{
    var levels = report.Split(" "); 
    var unsafeLevels = 0;
    var increases = new bool[levels.Length - 1]; 
    var prevLvl = Convert.ToInt16(levels[0]);
    var i = 1; 
    
          
    while (i < levels.Length)
    {       
        var currLvl = Convert.ToInt16(levels[i]);
        int amount = Math.Abs(currLvl - prevLvl);
        
        increases[i - 1] = currLvl > prevLvl;
        
        if (amount > 3 || amount == 0)
            unsafeLevels++;    

        i++;
        prevLvl = currLvl; 
    }    

    var increased = increases.Count(x => x);
    var decreased = increases.Count(x => !x);

    if (unsafeLevels > 1 || (increased > 1 && decreased > 1))    
        unsafeReps++;    
    else
        safeReps++;    
}

Console.WriteLine($"The safe levels are: {safeReps}. The unsafe levels are {unsafeReps}");
