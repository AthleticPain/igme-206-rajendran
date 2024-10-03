namespace PE_Magic8Ball_AshankRajendran
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declare all variables for this scope here
            string userChoice = "";

            //Print welcome statement
            Console.WriteLine("Welcome to Sassy 8 Ball Simulator!");

            //Ask user for owner name
            Console.Write("\nWho owns this Sassy 8 Ball? ");
            Console.ForegroundColor = ConsoleColor.Blue;

            //Create a MagicEightBall object with given input owner name
            MagicEightBall eightBall = new MagicEightBall(Console.ReadLine().Trim());
            Console.ForegroundColor = ConsoleColor.White;

            //While loop to keep asking user for a choice
            while (userChoice != "quit")
            {
                //Ask user to input their choice
                Console.WriteLine("\nWhat would you like to do?");
                Console.Write("You can 'shake' the ball, " +
                    "get a 'report', " +
                    "or 'quit': ");
                
                Console.ForegroundColor = ConsoleColor.Blue;
                userChoice = Console.ReadLine().Trim().ToLower();
                Console.ForegroundColor = ConsoleColor.White;

                //Switch statement for what to do depending on userChoice
                switch(userChoice)
                {
                    case "shake":

                        //Prompt user for their question
                        Console.Write("What is your question? ");
                        Console.ForegroundColor= ConsoleColor.Blue;
                        Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.Write("The Sassy 8 Ball says: ");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(eightBall.ShakeBall());
                        Console.ForegroundColor = ConsoleColor.White;

                        break;
                    
                    case "report":
                        Console.WriteLine(eightBall.Report());
                        break;

                    case "quit":
                        //Loop ends after this
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }

        }
    }
}
