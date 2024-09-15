namespace PE_InputAndParsin_AshankRajendran
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string playerName;

            int totalHoursPlayed;

            //Coordinates for Point One
            int xCoordinatePointOne;
            int yCoordinatePointOne;

            //Coordinates for Point Two
            int xCoordinatePointTwo;
            int yCoordinatePointTwo;

            double numberA;
            double numberB;
            double angleDegrees;
            double angleRadians;

            //variable for storing whole number result of sum of number A and number B
            int wholeNumberResult;

            //variable for storing result of distance between Point One and Point Two
            double distance;

            //variable for holding user's input
            string userInputString;

            //Addition and Casting
            Console.WriteLine("--- ADDITION ---");

            //Read user input for numberA and numberB and parse it to double
            Console.Write("What is the first number? ");
            userInputString = Console.ReadLine();
            numberA = double.Parse(userInputString);
            Console.Write("What is the second number? ");
            userInputString = Console.ReadLine();
            numberB = double.Parse(userInputString);

            Console.WriteLine(numberA + " + " + numberB + " = " + (numberA + numberB));
            Console.WriteLine("Now I'll add just the whole number parts.");

            wholeNumberResult = (int)numberA + (int)numberB;
            Console.WriteLine((int)numberA + " + " + (int)numberB + " = " + wholeNumberResult);

            //Division and Modulus
            Console.WriteLine();
            Console.WriteLine("--- DIVISION and MODULUS ---");
            
            //Read user input for playerName and totalHoursPlayed
            Console.Write("What is the player's name? ");
            playerName = Console.ReadLine();
            Console.Write("How many hours have they logged? ");
            userInputString = Console.ReadLine();
            totalHoursPlayed = int.Parse(userInputString);

            Console.WriteLine(
                playerName + " has played a game for " + 
                totalHoursPlayed + " hours."
                );
            Console.WriteLine(
                "They have played for " +
                (totalHoursPlayed / 24) + //Number of days played
                " days and " +
                (totalHoursPlayed % 24) + //Number of remainder hours
                " hours."
                );

            //Sine and Cosine
            Console.WriteLine();
            Console.WriteLine("--- SINE and COSINE ---");

            //Read user input for angleDegrees and calculate subsequent angleRadians
            Console.Write("Enter an angle in degrees: ");
            userInputString = Console.ReadLine();
            angleDegrees = double.Parse(userInputString);
            angleRadians = angleDegrees * Math.PI / 180;

            Console.WriteLine(angleDegrees + " degrees is " + angleRadians + " radians.");
            Console.WriteLine("The sine is " + Math.Sin(angleRadians));
            Console.WriteLine("The cosine is " + Math.Cos(angleRadians));

            //Distance
            Console.WriteLine();
            Console.WriteLine("--- DISTANCE and ROUNDING ---");

            //Read x and y coordinates for both points
            Console.Write("Enter Point 1 X: ");
            userInputString = Console.ReadLine();
            xCoordinatePointOne = int.Parse(userInputString);
            Console.Write("Enter Point 1 Y: ");
            userInputString = Console.ReadLine();
            yCoordinatePointOne = int.Parse(userInputString);
            Console.Write("Enter Point 2 X: ");
            userInputString = Console.ReadLine();
            xCoordinatePointTwo = int.Parse(userInputString);
            Console.Write("Enter Point 2 Y: ");
            userInputString = Console.ReadLine();
            yCoordinatePointTwo = int.Parse(userInputString);

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
            Console.WriteLine(
                "The distance is " + distance + ", which is approximately " +
                Math.Round(distance) +
                " units, or " +
                Math.Round(distance, 3) +        //Rounding to 3 decimal points
                " to be more precise."
                );
        }
    }
}
