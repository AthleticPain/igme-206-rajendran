namespace HW6_CritterFarm
{
    /// <summary>
    /// Child of Critter class for Fairy critter type
    /// Fairy has default hunger and boredom values of 0
    /// Fairy's irritation level = 2*hunger level + 3*boredom level
    /// if irritation level > 25 fairy is frustrated, else it is happy. Fairy's are never angry
    /// </summary>
    internal class Fairy : Critter
    {
        /// <summary>
        /// Constructor for Fairy class for when loading data from file.
        /// Default hunger and boredom values are 0.
        /// </summary>
        /// <param name="name">name of the fairy</param>
        public Fairy(string name) : 
            base(name, CritterType.Fairy, 0, 0) 
        { }

        /// <summary>
        /// Constructor for Fairy class for when loading data from file.
        /// </summary>
        /// <param name="name">name of the fairy</param>
        /// <param name="hungerLevel">this fairy's hunger level</param>
        /// <param name="boredomLevel">this fairy's boredom level</param>
        public Fairy(string name, int hungerLevel, int boredomLevel) :
            base(name, CritterType.Fairy, hungerLevel, boredomLevel)
        { }
        
        /// <summary>
        /// Overrides Critter's UpdateMood abstract method
        /// Irritation level = 2*hunger level + 3*boredom level
        /// If irritation level > 25, this critter is frustrated
        /// else it is happy
        /// Fairy's are never angry
        /// </summary>
        protected override void UpdateMood()
        {
            int irritationLevel = 2 * Hunger + 3 * Boredom;

            if ( irritationLevel > 25)
            {
                mood = CritterMood.Frustrated;
            }
            else
            {
                mood = CritterMood.Happy;
            }
        }
    }
}
