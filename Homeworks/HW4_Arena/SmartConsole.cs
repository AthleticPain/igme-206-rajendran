namespace HW4_Arena
{
    /// <summary>
    /// Class to hold static helper methods related to prompting for 
    /// and parsing, validating, and returning user responses.
    /// 
    /// Do NOT change anything except where explicitly marked with a TODO comment!
    /// See the comments through this program AND read the assignment write-up for details.
    /// </summary>
    internal class SmartConsole
    {
        /// <summary>
        /// Helper method to prompt the user to enter a number. If their
        /// response isn't a valid int or isn't in the desired range, reprompt
        /// </summary>
        /// <param name="prompt">The string to use in the initial prompt</param>
        /// <param name="min">The minimum accepted value (inclusive)</param>
        /// <param name="max">The maximum accepted value (inclusive)</param>
        /// <returns>The final, valid, user-entered value.</returns>
        public static int GetValidIntegerInput(string prompt, int min, int max)
        {
            // TODO: Implement the GetValidIntegerInput method (you should be able to get this from your PE)
            // ~~~~ YOUR CODE STARTS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            
            //store users response here and return this value
            int integerResponse = min;

            //flag to check if given response is valid
            bool isResponseValid = false;

            // Always print in white
            Console.ForegroundColor = ConsoleColor.White;

            // Print the prompt
            Console.Write(prompt + " ");

            while (!isResponseValid)
            {
                // Switch color and get user input (trim too)
                Console.ForegroundColor = ConsoleColor.Cyan;
                isResponseValid = int.TryParse(Console.ReadLine().Trim(), out integerResponse);
                Console.ForegroundColor = ConsoleColor.White;

                //If input is parsed correctly, check if it lies outside acceptable range
                //Set isResponseValid to false if it is out of range
                if (isResponseValid && (integerResponse < min || integerResponse > max))
                {
                    isResponseValid = false;
                }

                //Prompt for user to re enter their input
                if (!isResponseValid)
                {
                    Console.Write("Please enter a valid whole number between {0} and {1}: ", min, max);
                }
            }

            return integerResponse;
            // ~~~~ YOUR CODE STOPS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }

        /// <summary>
        /// Given a reference to an array of possible choices, keep prompting
        /// the user until they enter a valid option
        /// NOTE: Validation assumes lower case choices!
        /// DO NOT TOUCH THIS METHOD!
        /// </summary>
        /// <param name="prompt">The prompt to use</param>
        /// <param name="choices">The valid options</param>
        /// <returns>The final valid choice</returns>
        public static char GetPromptedChoice(string prompt, char[] choices)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(prompt + " ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            char result = Console.ReadKey().KeyChar; // Get JUST 1 character
            Console.ForegroundColor = ConsoleColor.White;

            // We haven't taught using Predicates in parameters. There are ways to implement
            // this with what you've learned so far, but I didn't feel like making you worry about
            // anything not related to exceptions or TryParse for this PE.
            // https://learn.microsoft.com/en-us/dotnet/api/system.array.exists?view=net-7.0
            while (!Array.Exists(choices, element => element == result))
            {
                Console.WriteLine("\nCommand not recognized.\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\n"+prompt + " ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                result = char.ToLower(Console.ReadKey().KeyChar); // Get JUST 1 character
                Console.ForegroundColor = ConsoleColor.White;
            }
            return result;
        }

        /// <summary>
        /// Input helper written by Prof. Mesh
        /// Uses the given string to prompt the user for input and set
        /// the color to cyan while they type.
        /// DO NOT TOUCH THIS METHOD!
        /// </summary>
        /// <param name="prompt">What to print before waiting for input</param>
        /// <returns>A trimmed version of what the user entered</returns>
        public static string GetPromptedInput(string prompt)
        {
            // Always print in white
            Console.ForegroundColor = ConsoleColor.White;

            // Print the prompt
            Console.Write(prompt + " ");

            // Switch color and get user input (trim too)
            Console.ForegroundColor = ConsoleColor.Cyan;
            string response = Console.ReadLine().Trim();

            // Switch back to white and then return response.
            Console.ForegroundColor = ConsoleColor.White;
            return response;
        }

    }
}
