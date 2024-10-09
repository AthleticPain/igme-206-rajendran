/***
 * Ashank Rajendran
 * 
 * HW 4 - The Arena
 * Write-up: https://docs.google.com/document/d/15Rl0oXwNXdGze8p5HcrZ8n4y78oiubW5pbkJei2YTPI/edit?usp=sharing
 *
 * Primary upgrades:
 *  1. Combat Randomness
 *  2. Additional Combat Options
 *  
 * Optional extra upgrades:
 *  3. Enemy Customization
 *  4. Additional Exit Conditions
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
        private const char Key = 'K';

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

            // Has the player picked up the key yet?
            bool hasKey = false;

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
                    
                    //Set hasKey to true, move player to new location
                    //and update the new location to Empty
                    case Key:
                        hasKey = true;
                        playerLoc = nextLoc;
                        arena[playerLoc[0], playerLoc[1]] = Empty;
                        break;

                    case Exit:
                        if (numEnemies > 0)
                        {
                            Console.WriteLine("You must defeat all enemies before you can escape.");
                        }
                        else if(!hasKey)
                        {
                            Console.WriteLine("You must pick up the key to unlock the exit.");
                        }
                        else
                        {
                            Console.WriteLine("You unlocked the exit! Congratulations!");
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
            // ~~~~ YOUR CODE STARTS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            //Random class to generate random numbers
            Random rng = new Random();
            int hitChance;

            //Flag for powered up attack
            bool isPlayerCharged = false;

            //Multiplier for charged attack
            const float ChargedAttackModifier = 2.5f;

            //Flag for defensive state
            bool isDefending = false;

            string userResponse = "";

            //Array of enemy names and titles
            string[] enemyNames = new string[]
            {
                "Adonis",
                "Brahma",
                "Dakaar",
                "Eraas",
                "Feyant",
                "Gimble",
                "Kraang",
                "Loief",
                "Ong",
                "Pthalamus",
                "Radyne",
                "Silderon",
                "Tyron",
                "Vank",
                "Zerrik"
            };
            string[] enemyTitles = new string[]
            {
                "Arrogant",
                "Barbaric",
                "Crafty",
                "Depraved",
                "Eerie",
                "Fanatical",
                "Giant",
                "Hideous",
                "Imperious",
                "Jerk",
                "Kingslayer",
                "Lunatic",
                "Maleficent",
                "Nefarious",
                "Odiferous",
                "Pyromaniac",
                "Questionable",
                "Ravenous",
                "Seditious",
                "Tyrant",
                "Umbral",
                "Vile",
                "Wicked"
            };

            float[] enemyHealthMultipliers = new float[]
            {
                0.5f,
                0.75f,
                1f,
                1.1f,
                1.25f,
                1.5f
            };

            //Enemy stats
            //Generate enemy health by multiplying it with one of the multipliers
            int enemyHealth = 
                (int)(EnemyMaxHealth * 
                enemyHealthMultipliers[rng.Next(enemyHealthMultipliers.Length)]);

            int enemyDamage = 0;
            int enemyDexterity = 20;

            //int to store player damage
            int playerDamage = 0;

            //Generate unique enemy name
            string uniqueEnemyName = string.Format("{0} the {1}",
                enemyNames[rng.Next(enemyNames.Length)],
                enemyTitles[rng.Next(enemyTitles.Length)]
                );

            //Print battle start message
            Console.WriteLine("\n{0} attacks you!", uniqueEnemyName);

            //Main Loop for battle
            //Loop continues until player runs or either player or enemy reaches <= 0 hp
            while (true)
            {
                Console.WriteLine("\nYour current health is {0}, {1}'s health is {2}.",
                    stats[Health],
                    uniqueEnemyName,
                    enemyHealth);

                Console.WriteLine("\nPlayer Actions:\n" +
                    "Attack\n" +
                    "Charge (Do nothing this turn, but next attack does 2.5x damage)\n" +
                    "Defend (Reduce incoming damage by 5 points for one turn)\n" +
                    "Run");
                userResponse = SmartConsole.GetPromptedInput("\nWhat would you like to do? >");
                userResponse = userResponse.ToLower();

                switch (userResponse)
                {
                    case "attack":

                        //Get random integer to determine player's hit success chance
                        hitChance = rng.Next(1, 101);

                        //If hitChance > enemyDexterity, attack lands, else it misses
                        if(hitChance > enemyDexterity)
                        {
                            //Calculate player minimum damage
                            playerDamage = stats[Strength] * DamageMult;

                            //If player is charged up, add 2.5x modifier and cast to int
                            //And set charged flag to false
                            if (isPlayerCharged)
                            {
                                isPlayerCharged = false;
                                playerDamage = (int)(playerDamage * ChargedAttackModifier);

                                //Add a random attack modifier of plus or minus 5
                                playerDamage += rng.Next(-5, 6);

                                //Update enemyHealth and print damage statement
                                enemyHealth -= playerDamage;
                                Console.WriteLine("You strike with a powerful slash! You do {0} damage.",
                                    playerDamage);
                            }
                            else
                            {
                                //Add a random attack modifier of plus or minus 5
                                playerDamage += rng.Next(-5, 6);

                                //Update enemyHealth and print damage statement
                                enemyHealth -= playerDamage;
                                Console.WriteLine("You swing at {0} doing {1} damage.", 
                                    uniqueEnemyName, playerDamage);
                            }
                        }
                        else
                        {
                            Console.WriteLine("You swing at {0}, but your attack misses.",
                                uniqueEnemyName);

                            //If player was charged up, remove the charge
                            if(isPlayerCharged)
                            {
                                isPlayerCharged = false;
                            }
                        }

                        break;

                    case "charge":

                        //Check if player is already charged up
                        //Set flag to true if player is not charged up
                        //Else print message informing player that they are already charged
                        if(!isPlayerCharged)
                        {
                            Console.WriteLine("You start to charge up a powerful attack...");
                            isPlayerCharged = true;
                        }
                        else
                        {
                            Console.WriteLine("You are already charged up!");
                        }
                        break;

                    case "defend":
                        //Print message and set defensive state flag to true
                        Console.WriteLine("You adopt a defensive stance.");
                        isDefending = true;
                        break;

                    case "run":
                        return Run;

                    default:
                        Console.WriteLine("Command not recognized! Oh no! LOOK OUT!!");
                        break;
                }

                //Enemy's attack
                //Get random integer to determine enemy's hit success chance
                hitChance = rng.Next(1, 101);

                //If hitChance > player's dexterity, attack lands, else it misses
                if (hitChance > stats[Dexterity])
                {
                    //Calculate enemy's minimum damage
                    enemyDamage = EnemyAttack - stats[Dexterity];

                    //Add a random attack modifier of plus or minus 3
                    enemyDamage += rng.Next(-3, 4);

                    //If player is defending, reduce damage by 5
                    if (isDefending)
                    {
                        enemyDamage -= 5;
                        isDefending = false;
                    }

                    //If enemy damage is negative set it to 0
                    if (enemyDamage < 0)
                    {
                        enemyDamage = 0;
                    }

                    //Update player health and inform user
                    stats[Health] -= enemyDamage;
                    Console.WriteLine("{0} strikes you for {1} damage!",
                        uniqueEnemyName, enemyDamage);
                }
                else
                {
                    Console.WriteLine("{0} charges at you, but you dodge the attack!", 
                        uniqueEnemyName);
                }

                //Check if fight is over (Win/Lose/Draw), and exit
                if (enemyHealth <= 0 && stats[Health] > 0)
                {
                    //Win message
                    Console.WriteLine("\nYou have defeated {0}! Congratulations!", uniqueEnemyName);
                    return Win;
                }
                else if (stats[Health] <= 0 && enemyHealth > 0)
                {
                    Console.WriteLine("\nYour wound are too much, {0} wins this time.", uniqueEnemyName);
                    return Lose;
                }
                else if(enemyHealth <= 0 && stats[Health] <= 0)
                {
                    Console.WriteLine("\nYou defeat {0} with your last breath.", uniqueEnemyName);
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

            // ~~~~ YOUR CODE STARTS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            int arenaHeight;
            int arenaWidth;

            //Random number gnerator for placing the key
            Random rng = new Random();

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

            //Place key in a random location on the map's center
            arena[rng.Next(2, arenaHeight-3), rng.Next(2, arenaWidth-3)] = Key;

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
                            case Key:
                                 Console.ForegroundColor = ConsoleColor.Yellow;
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