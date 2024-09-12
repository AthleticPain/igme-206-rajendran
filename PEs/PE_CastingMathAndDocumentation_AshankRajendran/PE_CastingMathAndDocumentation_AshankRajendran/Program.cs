namespace PE_CastingMathAndDocumentation_AshankRajendran
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string playerName = "Einstein";

            int totalHoursPlayed = 274;

            //Coordinates for Point One
            int xCoordinatePointOne = -13;
            int yCoordinatePointOne = 51;

            //Coordinates for Point Two
            int xCoordinatePointTwo = 17;
            int yCoordinatePointTwo = 28;

            double numberA = 7.9;
            double numberB = 2.25;
            double angleDegrees = 60;
            
            //Using formula to convert degrees to radian
            double angleRadians = angleDegrees * Math.PI / 180;     

            //variable for storing whole number result of sum of number A and number B
            int wholeNumberResult;

            //variable for storing result of distance between Point One and Point Two
            double distance;

            //Addition and Casting
            Console.WriteLine("--- ADDITION ---");
            Console.WriteLine("Number A: " + numberA);
            Console.WriteLine("Number B: " + numberB);
            Console.WriteLine(numberA + " + " + numberB + " = " + (numberA + numberB));
            Console.WriteLine("Now I'll add just the whole number parts.");

            wholeNumberResult = (int)numberA + (int)numberB;
            Console.WriteLine((int)numberA + " + " + (int)numberB + " = " + wholeNumberResult);

            //Division and Modulus
            Console.WriteLine();
            Console.WriteLine("--- DIVISION and MODULUS ---");
            Console.WriteLine(playerName + " has played a game for " + totalHoursPlayed + " hours.");
            Console.WriteLine("They have played for " + 
                (totalHoursPlayed / 24) + //Number of days played
                " days and " + 
                (totalHoursPlayed % 24) + //Number of remainder hours
                " hours.");

            //Sine and Cosine
            Console.WriteLine();
            Console.WriteLine("--- SINE and COSINE ---");
            Console.WriteLine(angleDegrees + " degrees is " + angleRadians + " radians.");
            Console.WriteLine("The sine is " + Math.Sin(angleRadians));
            Console.WriteLine("The cosine is " + Math.Cos(angleRadians));

            //Distance
            Console.WriteLine();
            Console.WriteLine("--- DISTANCE ---");

            Console.WriteLine("Point One: (" + xCoordinatePointOne + "," + yCoordinatePointOne + ")");
            Console.WriteLine("Point Two: (" + xCoordinatePointTwo + "," + yCoordinatePointTwo + ")");

            //Calculation of distance between Point One and Point Two
            //Using coordinate distance formula
            distance = Math.Sqrt(
                Math.Pow((xCoordinatePointTwo - xCoordinatePointOne), 2) +      //(x2 - x1)^2
                Math.Pow((yCoordinatePointTwo - yCoordinatePointOne), 2)        //(y2 - y1)^2   
                );
            Console.WriteLine("The distance between these points is " + distance);

            //Rounding
            Console.WriteLine();
            Console.WriteLine("--- ROUNDING ---");
            Console.WriteLine("The distance is " +  distance + ", which is approximately " +
                Math.Round(distance) +      
                " units, or " +
                Math.Round(distance,3) +        //Rounding to 3 decimal points
                " to be more precise."
                );


            //Optional Section

            string gameName = "Halo Infinite";

            //Base price of game in dollars
            double baseGameCost = 60;

            double salesTax = 0.08875;     //8.875% in decimal notation

            //Calculation of game price post tax
            double gameCostAfterTax = Math.Round(baseGameCost + baseGameCost * salesTax, 2);

            double numberC = 7.9;
            double numberD = 2.25;

            //Tax Calculation
            Console.WriteLine();
            Console.WriteLine("--- TAX CALCULATION ---");
            Console.WriteLine(gameName + " will cost $" + baseGameCost);
            Console.WriteLine("That price with NY sales tax is $" + gameCostAfterTax);
            Console.WriteLine("The dollar portion is " + Math.Round(gameCostAfterTax));
            Console.WriteLine("The cents portion is " + (gameCostAfterTax % 1));

            //Comparison
            Console.WriteLine();
            Console.WriteLine("--- COMPARISON ---");
            Console.WriteLine("Let's compare 2 numbers: " + numberC + " and " + numberD);
            Console.WriteLine(Math.Max(numberC, numberD) + " is the larger value.");

        }
    }
}
