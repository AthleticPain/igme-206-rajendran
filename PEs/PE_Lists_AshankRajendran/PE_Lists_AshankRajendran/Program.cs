namespace PE_Lists_AshankRajendran
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declare all variables here
            Random rng = new Random();
            Player player1;
            Player player2;
            Player playerToStealFrom;

            string userInput = "";

            int indexToStealFrom;
            string newlyStolenItem;
            List<string> stolenItems = new List<string>();

            //Prompt user for both player's name &
            //initialize player objects using that name
            Console.Write("Enter Player 1's name: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            player1 = new Player(Console.ReadLine().Trim());
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter Player 2's name: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            player2 = new Player(Console.ReadLine().Trim());
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();

            //Loop to prompt user for 5 items
            for (int i = 0; i < 5; i++)
            {
                //Prompt user for an item
                Console.Write("Enter an item: ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                userInput = Console.ReadLine().Trim().ToLower();
                Console.ForegroundColor = ConsoleColor.White;
                //Get random double from range 0 to 1
                //If greater than 0.5 add to player 1's inventory
                //Else add to player 2's inventory
                if (rng.NextDouble() > 0.5)
                {
                    player1.AddToInventory(userInput);
                }
                else
                {
                    player2.AddToInventory(userInput);
                }
            }

            userInput = ""; //reset value

            //Loop to get user's input
            //Keep loooping while user's input is not "quit"
            while (userInput != "quit")
            {
                Console.Write("\nEnter a command (print, steal, or quit) " +
                    "or an item: ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                userInput = Console.ReadLine().Trim().ToLower();
                Console.ForegroundColor = ConsoleColor.White;

                switch (userInput)
                {
                    case "print":
                        //Print both player's inventories
                        player1.PrintInventory();
                        player2.PrintInventory();
                        break;

                    case "steal":

                        //Ask which player user would like to steal from
                        Console.Write("Which player would you like to steal from (1 or 2)? ");
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        userInput = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;

                        if (int.Parse(userInput) == 1)
                        {
                            playerToStealFrom = player1;
                        }
                        //Assuming user always enters 1 or 2
                        //Else statement assumes if input was not 1 then input must be 2
                        else
                        {
                            playerToStealFrom = player2;
                        }

                        //Ask for item number to steal from
                        Console.Write("Which item # would you like to steal from {0}? ",
                                playerToStealFrom.PlayerName);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        indexToStealFrom = int.Parse(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.White;

                        //Get stolen item from GetItemInSlot() 
                        newlyStolenItem = playerToStealFrom.GetItemInSlot(indexToStealFrom);

                        //if returned value is not null, add to stolenItems list
                        //else print invalid # message
                        if (newlyStolenItem != null)
                        {
                            Console.WriteLine("{0} stolen from slot {1} in {2}'s inventory!",
                                newlyStolenItem,
                                indexToStealFrom,
                                playerToStealFrom.PlayerName);

                            stolenItems.Add(newlyStolenItem);
                        }
                        else
                        {
                            Console.WriteLine("{0} was not a valid item #!", indexToStealFrom);
                        }

                        break;

                    case "quit":
                        //Loop exits after this
                        Console.WriteLine("\nYou stole {0} items:", stolenItems.Count);

                        foreach (string item in stolenItems)
                        {
                            Console.WriteLine("\t"+item);
                        }
                        break;

                    default:

                        //Randomly determine which player's inventory to add item to
                        if (rng.NextDouble() > 0.5)
                        {
                            player1.AddToInventory(userInput);
                        }
                        else
                        {
                            player2.AddToInventory(userInput);
                        }

                        break;
                }
            }
        }
    }
}
