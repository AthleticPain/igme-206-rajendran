namespace DynamicMenus
{    
    /// <summary>
    /// Inherits core information about the data to manage and behavior
    /// from MenuItem and customizes it to represent a menu choice
    /// to change the color of the foreground text
    /// </summary>
    internal class ChangeColorItem : MenuItem
    {
        ConsoleColor currentColor;
        ConsoleColor[] colorOptions = new ConsoleColor[]
        {
            ConsoleColor.Red,
            ConsoleColor.Green,
            ConsoleColor.Blue,
            ConsoleColor.Yellow,
            ConsoleColor.White,
            ConsoleColor.Gray
        };

        // ~~~ CONSTRUCTORS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public ChangeColorItem(ConsoleColor currentColor)
            : base("COLOR", "Change the color of the text", 
                  "Your currently selected color is: ")
        {
            this.currentColor = currentColor;
        }

        public override void Run()
        {
            //Setup
            string userInput;
            bool isInputANumber = false;
            int newColorIndex;
            bool isInputValid = false;

            Console.WriteLine(actionText + currentColor.ToString());

            Console.WriteLine("/nWhich colore would you like to change to?");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1. Red");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("2. Green");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("3. Blue");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("4. Yellow");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("5. White");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("6. Gray");

            //Loop to accept valid user input
            while (isInputValid == false)
            {
                Console.ForegroundColor = currentColor;
                Console.Write("> ");
                userInput = Console.ReadLine().Trim().ToLower();

                isInputANumber = int.TryParse(userInput, out newColorIndex);

                //Check if userinput is a number and falls within valid range
                //Else check if userinput matches any of the color options by name
                if (isInputANumber 
                    && newColorIndex >= 1 && newColorIndex <= colorOptions.Length)
                {
                    newColorIndex--; //Adjust to follow 0 indexing
                    currentColor = colorOptions[newColorIndex];
                    Console.ForegroundColor = currentColor;
                    isInputValid = true;
                }
                else
                {
                    foreach (ConsoleColor color in colorOptions)
                    {
                        if(userInput == color.ToString().ToLower())
                        {
                            currentColor = color;
                            Console.ForegroundColor = currentColor;
                            isInputValid = true;
                        }
                    }
                }

                if(!isInputValid)
                {
                    Console.WriteLine("Please enter a valid option.");
                }
                else
                {
                    Console.WriteLine("The text color has been changed to {0}.",
                        currentColor.ToString());
                }
            }
        }
    }
}
