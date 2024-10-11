namespace PE_FileIOwithClasses_AshankRajendran
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declare all variables here
            string userResponse = "";
            string newPlayerName = "";
            int newPlayerStrength = 0;
            int newPlayerHealth = 0;

            PlayerManager playerManager = new PlayerManager();

            //Loop to get and process player input
            while (userResponse != "quit")
            {
                //Prompt for user's response and read input
                Console.Write("\nCreate. Print. Save. Load. Quit. >> ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                userResponse = Console.ReadLine().Trim().ToLower();
                Console.ForegroundColor = ConsoleColor.White;

                //Switch statement for user's action
                switch (userResponse)
                {
                    case "create":

                        //Prompt user for new player's details
                        Console.Write("What is the player's name? ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        newPlayerName = Console.ReadLine().Trim();
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.Write("Player's strength? ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        newPlayerStrength = int.Parse(Console.ReadLine().Trim());
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.Write("Player's health? ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        newPlayerHealth =int.Parse(Console.ReadLine().Trim());
                        Console.ForegroundColor = ConsoleColor.White;

                        playerManager.CreatePlayer(
                            newPlayerName, newPlayerStrength, newPlayerHealth);
                        break;

                    case "print":

                        playerManager.Print();
                        break;

                    case "save":
                        playerManager.Save();
                        break;

                    case "load":
                        playerManager.Load();
                        break;

                    case "quit":
                        Console.WriteLine("Goodbye!");
                        break;
                }
            }
        }
    }
}
