// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AocDay2 
{
    public class Program 
    {
        public static void Main(string[] args) 
        {
            List<string> lines = File.ReadAllLines(@"../../../input.txt").ToList();

            int safeReps = 0;

            // Get lines 
            foreach (string report in lines)
            {
                var levels = report.Split(" "); 
                var unsafeLevels = 0;
                var prevLvl = Convert.ToInt16(levels[0]);
                var i = 1; 
                bool ignore = false;
                
                while (i < levels.Length && unsafeLevels < 2)
                {       
                    var currLvl = Convert.ToInt16(levels[i]);
                    var nextLvl = i < levels.Length - 1 ? Convert.ToInt16(levels[i + 1]) : currLvl;
                    int amount = Math.Abs(currLvl - prevLvl);
                    ignore = false;
                    
                    var currInc = currLvl > prevLvl;
                    var nextInc = currLvl < nextLvl;

                    if (amount > 3 || amount == 0 || currInc != nextInc)
                    {
                        unsafeLevels++;
                        ignore = unsafeLevels < 2;
                    }

                    if (!ignore)
                        prevLvl = currLvl;

                    i++;
                }      

                if (unsafeLevels <= 1)
                    safeReps++;          
            }

            Console.WriteLine($"The safe reports are: {safeReps}.");
        }
    }
}