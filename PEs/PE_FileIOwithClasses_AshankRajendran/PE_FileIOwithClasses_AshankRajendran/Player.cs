namespace PE_FileIOwithClasses_AshankRajendran
{
    /// <summary>
    /// Class that stores the details of a player
    /// </summary>
    internal class Player
    {
        //All variables declared here
        string playerName;
        int health;
        int strength;

        //All properties defined here
        public string PlayerName
        {
            get
            {
                return playerName;
            }
        }

        public int Health
        {
            get
            {
                return health;
            }
        }

        public int Strength
        {
            get
            {
                return strength;
            }
        }

        /// <summary>
        /// Constructor for player class
        /// </summary>
        /// <param name="playerName">Player's name</param>
        /// <param name="health">Player's health stat</param>
        /// <param name="strength">Player's strength stat</param>
        public Player(string playerName, int strength, int health)
        {
            this.playerName = playerName;
            this.strength = strength;
            this.health = health;
        }

        /// <summary>
        /// Override method to return string of this player's details
        /// </summary>
        /// <returns>string of this player's details</returns>
        public override string ToString()
        {
            return string.Format("Player: {0}. Strength {1}, Health {2}.", 
                playerName, health, strength);
        }
    }
}
