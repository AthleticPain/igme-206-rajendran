namespace PE_FileIOwithClasses_AshankRajendran
{
    /// <summary>
    /// Class that stores list of multiple players 
    /// and file details to read and write from
    /// </summary>
    internal class PlayerManager
    {
        //All variables declared here
        string filename;
        List<Player> players;

        //Constructor for this class
        /// <summary>
        /// Default constructor for PlayerManager class
        /// </summary>
        public PlayerManager()
        {
            filename = "../../../players.txt";
            players = new List<Player>();
        }
        
        /// <summary>
        /// Constructor for PlayerManager that accepts custom filename
        /// </summary>
        /// <param name="filename">Full path of file to read and write to</param>
        public PlayerManager(string filename)
        {
            this.filename = filename;
            this.players = new List<Player>();
        }

        /// <summary>
        /// Method to create a new Player object and add it to list of players
        /// </summary>
        /// <param name="name">New player's name</param>
        /// <param name="strength">New player's strength stat</param>
        /// <param name="health">New player's health stat</param>
        public void CreatePlayer(string name, int strength, int health)
        {
            Player newPlayer = new Player(name, strength, health);
            players.Add(newPlayer);
            Console.WriteLine("Added {0} to the list.", name);
        }

        /// <summary>
        /// Method to print each player's details from list of all players
        /// </summary>
        public void Print()
        {
            if (players.Count > 0)
            {
                foreach (Player player in players)
                {
                    Console.WriteLine(player.ToString());
                }
            }
            else
            {
                Console.WriteLine("There are no players yet.");
            }
        }

        /// <summary>
        /// Method to load new players' data from this object's file 
        /// and parse it to players list
        /// </summary>
        public void Load()
        {

            if (players.Count > 0)
            {
                players.Clear();
                StreamReader inputStream = new StreamReader(filename);

                try
                {
                    string line = null;
                    while ((line = inputStream.ReadLine()) != null)
                    {
                        string[] loadedPlayerData = line.Split(',');

                        CreatePlayer(loadedPlayerData[0].Trim(),
                            int.Parse(loadedPlayerData[1].Trim()),
                            int.Parse(loadedPlayerData[2].Trim()));
                    }

                    Console.WriteLine("\nLoaded all data from file.");
                    Console.WriteLine("{0} players created.", players.Count);



                }
                catch (Exception e)
                {
                    Console.WriteLine("Error reading the file: " + e.ToString());
                }

                if (inputStream != null)
                {
                    inputStream.Close();
                }
            }
            else
            {
                Console.WriteLine("There is no player data to load.");
            }
        }

        /// <summary>
        /// Method to save list of all players to this object's filename
        /// </summary>
        public void Save()
        {
            if (players.Count > 0)
            {
                StreamWriter outputStream = null;

                try
                {
                    outputStream = new StreamWriter(filename);

                    foreach (Player player in players)
                    {
                        outputStream.WriteLine("{0},{1},{2}", player.PlayerName, player.Strength, player.Health);
                    }

                    Console.WriteLine("Saved {0} players to file players.txt", players.Count);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error writing to file: " + e.ToString());
                }

                if (outputStream != null)
                {
                    outputStream.Close();
                }
            }
            else
            {
                Console.WriteLine("There is no player yet.");
            }
        }
    }
}
