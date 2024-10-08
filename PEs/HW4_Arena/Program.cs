/***
 * Ashank Rajendran
 * 
 * HW 4 - The Arena
 * Write-up: https://docs.google.com/document/d/15Rl0oXwNXdGze8p5HcrZ8n4y78oiubW5pbkJei2YTPI/edit?usp=sharing
 *
 * Primary upgrades:
 *  1. 
 *  2.
 *  
 * Optional extra upgrades:
 *  3.
 *  4.
 *  
 * Known Bugs:
 * 
 * Other notes:
 * 
 */
namespace HW4_Arena
{
    /// <summary>
    /// Primary class for the console app. Main() will be run on program launch. Other helper methods are
    /// also defined that Main() will need. It's your job to finish them!
    /// 
    /// Do NOT change anything except where explicitly marked with a TODO comment!
    /// See the comments through this program AND read the assignment write-up for details.
    /// </summary>
    internal class Program
    {
        // *** These constants are defined for you to make your code more readable AND help ensure it works
        //     with the code given to you. Do NOT change these!

        // Constants for the tile types
        private const char Empty = ' ';
        private const char Wall = '#';
        private const char Enemy = 'E';
        private const char Player = '@';
        private const char PlayerStart = '0';
        private const char Exit = '1';

        // Constants for directions
        private const char Up = 'w';
        private const char Down = 's';
        private const char Left = 'a';
        private const char Right = 'd';

        // Player stat indices
        private const int Strength = 0;
        private const int Dexterity = 1;
        private const int Constitution = 2;
        private const int Health = 3;

        // Possible fight outcomes
        private const int Win = 0;
        private const int Lose = 1;
        private const int Run = 2;
        private const int Draw = 3;

        // *** Other constants
        // TODO: It's okay to tweak these numbers a bit to balance your game and/or add new ones.
        // (But don't delete what is here. Main needs some of them!)
        const int EnemySpacing = 6;
        const int MaxPoints = 10;
        const int HealthMult = 5;
        const int DamageMult = 5;
        const int EnemyAttack = 5;
        const int EnemyMaxHealth = 50;

        /// <summary>
        /// DO NOT CHANGE ANY CODE IN MAIN!!!
        /// 
        /// But it's definitely worth reading it to get an understanding of 
        /// how/when your methods will be called.
        /// 
        /// AND it's okay to *temporarily* comment out chunks of code until 
        /// you're ready for them to run to make it easier to test other things.
        /// </summary>
        static void Main(string[] args)
        {
            // ** SETUP **
            // Player's name
            string name;

            // Stats - to make it easier to pass these around between methods, all 4 stats are
            // in a single array with elements in the order [Strength, Dexterity, Constitution, Health]
            // Constants are defined above to help with this.
            int[] stats = new int[4];

            // Define the variable to refer to the final arena
            char[,] arena;

            // Track the player's location as [row, col] (NOT x, y)
            int[] playerLoc = { 1, 1 };

            // Is the game still running?
            bool stillPlaying = true;

            // How many enemies are left?
            int numEnemies;

            // ** GET PLAYER STATS & BUILD ARENA **
            // Welcome & get stats 
            name = GetPlayerInfo(stats);

            // Build & print the Arena
            arena = BuildArena(out numEnemies);

            // ** GAME LOOP **
            while (stillPlaying)
            {
                // ** PRINT EVERYTHING **

                // Clear the console and then print the arena
                Console.Clear();
                PrintArena(arena, playerLoc);
                Console.WriteLine(
                    $"\n{name}, your stats are: " +
                    $"Strength {stats[Strength]}, " +
                    $"Dexterity {stats[Dexterity]}, " +
                    $"Constitution {stats[Constitution]}, " +
                    $"Health {stats[Health]}");

                // ** DETECT MOVEMENT **

                // Get the desired direction
                char direction = SmartConsole.GetPromptedChoice(
                        $"\n Where would you like to go? {Up}/{Left}/{Down}/{Right} >",
                        new char[] { Up, Left, Down, Right });
                Console.WriteLine();

                // Figure out what is there, but don't move yet
                int[] nextLoc = { playerLoc[0], playerLoc[1] };
                switch (direction)
                {
                    case Up:
                        nextLoc[0]--; // row--
                        break;

                    case Down:
                        nextLoc[0]++; // row++
                        break;

                    case Left:
                        nextLoc[1]--; // col --
                        break;

                    case Right:
                        nextLoc[1]++; // col ++
                        break;
                }

                // ** TAKE ACTION **
                // Act based on what is in the next location (row, col)
                switch (arena[nextLoc[0], nextLoc[1]])
                {
                    // Do nothing. We're stuck.
                    case Wall:
                        Console.WriteLine("\n You can't go there...");
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        break;

                    // Move to that spot
                    case Empty:
                        playerLoc = nextLoc;
                        break;

                    // Launch a new fight and determine how to proceed based on the result
                    case Enemy:
                        switch (Fight(stats))
                        {
                            // Take over the enemy's spot if we win
                            case Win:
                                playerLoc = nextLoc;
                                arena[playerLoc[0], playerLoc[1]] = Empty;
                                numEnemies--;
                                break;

                            // A loss or draw is game over
                            case Lose:
                            case Draw:
                                stillPlaying = false;
                                break;

                            // Run back to the start and regain half health
                            case Run:
                                Console.WriteLine("You retreat to the starting area of the arena to heal up.");
                                playerLoc = new int[] { 1, 1 };
                                stats[Health] += (stats[Constitution] * HealthMult) / 2;
                                stats[Health] = Math.Clamp(stats[Health], 0, stats[Constitution] * HealthMult); // cap at max health
                                break;
                        }
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        break;

                    case Exit:
                        if (numEnemies > 0)
                        {
                            Console.WriteLine("You must defeat all enemies before you can escape.");
                        }
                        else
                        {
                            Console.WriteLine("You made it to the exit! Congratulations!");
                            stillPlaying = false;
                        }
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        break;
                }
            }

        }

        /// <summary>
        /// Given a reference to the player's current stats, launch a new fight
        /// </summary>
        /// <param name="stats">A reference to an int[] containing [Strength, Dexterity, Constitution, Health]</param>
        /// <returns>The result of the fight using an int code. See the constants at the top of Program.cs</returns>
        private static int Fight(int[] stats)
        {
            // TODO: Implement the Fight method
            // ~~~~ YOUR CODE STARTS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            int enemyHealth = EnemyMaxHealth;
            int playerDamage = 0;
            int enemyDamage = 0;

            string userResponse = "";

            //Print battle start message
            Console.WriteLine("An angry goat attacks you!");

            //Loop for battle
            //Loop continues until player runs or either player or enemy reaches <= 0 hp
            while (true)
            {
                Console.WriteLine("\nYour current health is {0}, the goat's health is {1}",
                    stats[Health],
                    enemyHealth);

                userResponse = SmartConsole.GetPromptedInput("What would you like to do? Attack/Run >");
                userResponse = userResponse.ToLower();

                switch (userResponse)
                {
                    case "attack":
                        //Calculate player and enemy damage
                        playerDamage = stats[Strength] * DamageMult;
                        enemyDamage = EnemyAttack - stats[Dexterity];

                        //If enemy damage is negative set it to 0
                        if (enemyDamage < 0)
                        {
                            enemyDamage = 0;
                        }

                        //Update player and enemy health and inform user
                        enemyHealth -= playerDamage;
                        stats[Health] -= enemyDamage;

                        Console.WriteLine("You swing at the goat doing {0} damage.", playerDamage);
                        Console.WriteLine("The goat charges at you for {0} damage!", enemyDamage);

                        break;

                    case "run":
                        return Run;

                    default:
                        Console.WriteLine("Command not recognized! Oh no! LOOK OUT!!");
                        enemyDamage = EnemyAttack - stats[Dexterity];

                        //If enemy damage is negative set it to 0
                        if (enemyDamage < 0)
                        {
                            enemyDamage = 0;
                        }

                        //Update player and enemy health and inform user
                        enemyHealth -= playerDamage;
                        Console.WriteLine("The goat charges at you for {0} damage!", enemyDamage);
                        break;
                }

                if (enemyHealth <= 0 && stats[Health] > 0)
                {
                    //Win message
                    Console.WriteLine("\nYou have defeated the beast! Congratulations!");
                    return Win;
                }
                else if (stats[Health] <= 0 && enemyHealth > 0)
                {
                    Console.WriteLine("\nYour wound are too much, the goat wins this time.");
                    return Lose;
                }
                else if(enemyHealth <= 0 && stats[Health] <= 0)
                {
                    Console.WriteLine("\nYou defeat the goat with your last breath.");
                    return Draw;
                }
            }
            // ~~~~ YOUR CODE STOPS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }

        /// <summary>
        /// Get the player's name & stats. Stats are loaded into the provided array and
        /// the name is returned.
        /// </summary>
        /// <param name="statsArray">A reference int[4] array that this method will put data into</param>
        /// <returns>The player's name</returns>
        private static string GetPlayerInfo(int[] statsArray)
        {
            // TODO: Implement the GetPlayerInfo method
            // ~~~~ YOUR CODE STARTS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            string playerName;
            playerName = SmartConsole.GetPromptedInput("Welcome, please enter your name: >");

            Console.WriteLine("\nHello {0}, I'll need a bit more information from you " +
                "before we can start." +
                "\nYou have 10 points to build your character and three attributes to " +
                "allocate them to.", playerName);

            int remainingStatPoints = MaxPoints;
            statsArray[Strength] = SmartConsole.GetValidIntegerInput(
                "\nHow many points would you like to allocate to Strength? >",
                1, remainingStatPoints - 2);

            remainingStatPoints -= statsArray[Strength];
            Console.WriteLine("You have {0} points remaining.", remainingStatPoints);

            statsArray[Dexterity] = SmartConsole.GetValidIntegerInput(
                "\nHow many points would you like to allocate to Dexterity? >",
                1, remainingStatPoints - 1);

            remainingStatPoints -= statsArray[Dexterity];
            Console.WriteLine("You have {0} points remaining.", remainingStatPoints);

            statsArray[Constitution] = SmartConsole.GetValidIntegerInput(
                "\nHow many points would you like to allocate to Constitution? >",
                1, remainingStatPoints);

            remainingStatPoints -= statsArray[Constitution];
            Console.WriteLine("You left {0} points unused.", remainingStatPoints);

            //Set player health to 5 times constitution stat
            statsArray[Health] = statsArray[Constitution] * HealthMult;

            return playerName; // replace this. it's just so the starter code compiles.
                               // ~~~~ YOUR CODE STOPS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }

        /// <summary>
        /// Given a reference to a 2d array variable (that will be null to start):
        /// - Prompt for the desired size and initialize the array
        /// - Put walls along all borders
        /// - Evenly space enemies every few tiles (vert & hor)
        /// - Put empty cells everywhere else
        /// - Place the player start in the top left
        /// - Place an exit in the bottom right
        /// </summary>
        /// <param name="numEnemies">An out param to store the total number of enemies created</param>
        /// <returns>A reference to the final 2d arena</returns>
        private static char[,] BuildArena(out int numEnemies)
        {
            // Start by setting numEnemies to 0. Increment this whenever you create
            // an enemy and the out param will work just fine. :)
            numEnemies = 0;

            // TODO: Implement the BuildArena method
            // ~~~~ YOUR CODE STARTS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            int arenaHeight;
            int arenaWidth;

            arenaWidth = SmartConsole.GetValidIntegerInput("\nHow wide should the arena be? " +
                "(Enter a value from 10 to 50) >", 10, 50);
            arenaHeight = SmartConsole.GetValidIntegerInput("How tall should the arena be? " +
                "(Enter a value from 10 to 50) >", 10, 50);

            char[,] arena = new char[arenaHeight, arenaWidth];

            //Loop through arena array and
            //set all border positions to Wall constant and Empty for rest
            for (int i = 0; i < arenaHeight; i++)
            {
                for (int j = 0; j < arenaWidth; j++)
                {
                    if (i == 0 || i == arenaHeight - 1 || j == 0 || j == arenaWidth - 1)
                    {
                        arena[i, j] = Wall;
                    }
                    else if( i % EnemySpacing == 0 && j % EnemySpacing == 0)
                    {
                        //Spawn enemy every 6 spaces vertically and horizontally
                        //and increment numEnemies
                        arena[i, j] = Enemy;
                        numEnemies++;
                    }
                    else
                    {
                        arena[i, j] = Empty;
                    }
                }
            }

            //Set top left as PlayerStart and bottom right as Exit
            arena[1, 1] = PlayerStart;
            arena[arenaHeight - 2, arenaWidth - 2] = Exit;
            // ~~~~ YOUR CODE STOPS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            // All done
            return arena;
        }

        /// <summary>
        /// Given a reference to a 2d arena and the player's current location, 
        /// print every character using the correct colors.
        /// </summary>
        /// <param name="arena">A reference to the arena to print. This could be ANY size.</param>
        /// <param name="playerLoc">The player's location in a 1d array with element [row, col]</param>
        private static void PrintArena(char[,] arena, int[] playerLoc)
        {
            // TODO: Implement the PrintArena method
            // ~~~~ YOUR CODE STARTS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            for (int i = 0; i < arena.GetLength(0); i++)
            {
                for (int j = 0; j < arena.GetLength(1); j++)
                {
                    if (i == playerLoc[0] && j == playerLoc[1])
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(Player);
                    }
                    else
                    {
                        switch (arena[i, j])
                        {
                            case Wall:
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                break;
                            case Enemy:
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                            case PlayerStart:
                            case Exit:
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                break;
                        }
                        Console.Write(arena[i, j]);
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }
            // ~~~~ YOUR CODE STOPS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }
    }
}