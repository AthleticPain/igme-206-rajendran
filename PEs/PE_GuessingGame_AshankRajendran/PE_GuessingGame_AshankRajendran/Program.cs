namespace PE_GuessingGame_AshankRajendran
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declare all variables here
            int randomlyGeneratedNumber;
            int userGuessedNumber = -1;

            //Flag to check if users guess for that turn is valid
            bool isGuessValid = true;

            Random rng = new Random();

            //Generate random integer between 0 and 100 (inclusive)
            randomlyGeneratedNumber = rng.Next(0, 101);

            //Print the correct number
            Console.WriteLine(randomlyGeneratedNumber);

            //For loop to give user 8 tries to guess
            //Two different methods given below

            //******************************************************************
            //Method 1 (Nested Loop Method)
            //******************************************************************

            //First method for the loop (Nested Loop Method)
            for (int turnCount = 0; turnCount < 8; turnCount++)
            {
                //Set flag to true at the start of each iteration
                isGuessValid = false;

                while (isGuessValid == false)
                {
                    Console.Write("\nTurn #{0}: " +
                    "Guess a number between 0 and 100 (inclusive):",
                    turnCount + 1);

                    //Check if input format is valid, returns false if invalid
                    isGuessValid = int.TryParse(Console.ReadLine(), out userGuessedNumber);

                    //If input format is correct but is outside the requested range,
                    //set flag to false
                    if (isGuessValid && (userGuessedNumber < 0 || userGuessedNumber > 100))
                    {
                        isGuessValid = false;
                    }

                    if (isGuessValid == false)
                    {
                        Console.WriteLine("Invalid guess - try again.");
                    }
                }

                if (userGuessedNumber < randomlyGeneratedNumber)
                {
                    Console.WriteLine("Too Low");
                }
                else if (userGuessedNumber > randomlyGeneratedNumber)
                {
                    Console.WriteLine("Too High");
                }
                else
                {
                    Console.WriteLine("Correct!");
                    Console.WriteLine("It took you {0} turns to guess the answer!",
                        turnCount + 1);
                    return;
                }

            }

            //******************************************************************
            //Method 2 (Decrement loop control variable)
            //******************************************************************

            //Alternative Method
            //Decrements the turnCount for invalid input.
            //Esentially restarts the player's turn since
            //turncount gets incremented again at start of loop.
            //Does not require a nested loop.

            /*
            for (int turnCount = 0; turnCount < 8; turnCount++)
            {
                //Set flag to true at the start of each iteration
                isGuessValid = true;

                Console.Write("\nTurn #{0}: " +
                    "Guess a number between 0 and 100 (inclusive):",
                    turnCount + 1);

                //Check if input format is valid, returns false if invalid
                isGuessValid = int.TryParse(Console.ReadLine(), out userGuessedNumber);

                //If input format is correct but is outside the requested range,
                //set flag to false
                if (isGuessValid && (userGuessedNumber < 0 || userGuessedNumber > 100))
                {
                    isGuessValid = false;
                }

                //If guess is invalid, decrement turnCount by one
                //so that user can try his turn again
                //(Because turnCount gets incremented again at start of loop)
                if(isGuessValid == false)
                {
                    turnCount--;
                    Console.WriteLine("Invalid guess - try again.");
                }
                //if guess is valid, tell user if high, low, or correct
                else
                {
                    if (userGuessedNumber < randomlyGeneratedNumber)
                    {
                        Console.WriteLine("Too Low");
                    }
                    else if (userGuessedNumber > randomlyGeneratedNumber)
                    {
                        Console.WriteLine("Too High");
                    }
                    else
                    {
                        Console.WriteLine("Correct!");
                        Console.WriteLine("It took you {0} turns to guess the answer!",
                            turnCount + 1);
                        return;
                    }
                }
            }
            */

            //If user did not guess in time display correct answer
            Console.WriteLine();
            Console.WriteLine("You ran out of turns. The number was {0}.",
                randomlyGeneratedNumber);
        }
    }
}
