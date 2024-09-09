using System;

namespace PE_DataTypesAndVariables_AshankRajendran
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declare and initialize all the variables necessary for the character's stats

            //Character Name
            string characterName = "Edgy AntiHero";

            //Maximum number of starting stat points
            const float maximumStartingPoints = 50; 

            //First stat, 23% of total starting stat points
            float destructiveness = maximumStartingPoints * 0.23f; 

            //Second stat, half the value of first stat
            float dexterity = destructiveness / 2; 

            //Third stat, value set to 7
            float discernment = 7; 

            //Fourth stat, sum of second and third stat minus 2
            float determination = dexterity + discernment - 2; 
            
            //Last stat, all remaining stat points go to this stat
            float debonair = maximumStartingPoints - (destructiveness + dexterity + discernment + determination);

            //Sum of all the individual stat points
            float totalStatPoints = destructiveness + dexterity + discernment + determination + debonair; 
            
            //Print character's name, relevant stats and total points
            Console.WriteLine("Character Name: " + characterName);
            Console.WriteLine();

            Console.WriteLine("Destructiveness: " + destructiveness);
            Console.WriteLine("Dexterity: " + dexterity);
            Console.WriteLine("Discernment: " + discernment);
            Console.WriteLine("Determination: " + determination);
            Console.WriteLine("Debonair: " + debonair);

            Console.WriteLine();
            Console.WriteLine("Total Points: " + totalStatPoints);


        }
    }
}
