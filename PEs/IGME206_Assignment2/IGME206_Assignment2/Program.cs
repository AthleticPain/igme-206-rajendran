using System;

namespace IGME206_Assignment2
{
    /// <summary>
    /// Program
    /// Purpose: To use given calculations in expressions to represent the stats of a videogame character
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            //Print the character's name nd leave a linebreak to seperate name from stats
            Console.WriteLine("Name: Hero McHeroFace");
            Console.WriteLine();

            //Total number of stat points is 50
            //First Stat: Calculate and print character's 'Brawn' stat ie, 20% of total points
            Console.WriteLine(
                0.2 * 50 +                  //Calculation for first stat
                " Brawn");

            //Second Stat: Calculate and print character's 'Brain' stat, ie half of first stat
            Console.WriteLine(
                0.5 * 0.2 * 50 +            // Calculation for second stat
                "  Brain");

            //Third Stat: Print character's 'Beauty' stat as 7
            Console.WriteLine("7  Beauty");

            //Fourth Stat: Calculate and print 'Bravery' stat ie, second stat + third stat - 2
            Console.WriteLine(
                (0.5 * 0.2 * 50) +          //Second stat
                7 -                         //Third stat
                2 +                         //Minus two
                " Bravery");

            //Fifth Stat: Calculate and print 'Benevolence' stat ie, Total points - all the other stat points.
            Console.WriteLine(
                50 -                        //Total Points
                (0.2 * 50) -                //Expression for first stat
                (0.5 * 0.2 * 50) -          //Expression for second stat
                7 -                         //Expression for third stat
                (0.5 * 0.2 * 50 + 7 - 2)    //Expression for fourth stat
                + " Benevolence");

            //Leave a linebreak and print total number of points
            Console.WriteLine();
            Console.WriteLine("TOTAL POINTS: 50");
        }
    }
}
