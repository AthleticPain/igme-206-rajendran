namespace HW6_CritterFarm
{
    /// <summary>
    /// Child of Critter class for the phoenix critter type
    /// By default phoenix's inital hunger and boredom values are high. Default mood is angry.
    /// Phoenix's irritation level is a sum of it's hunger and boredom values.
    /// If irritation level > 10, phoenix is angry, if >5 phoenix is frustrated, else it is happy.
    /// Has a unique burn method which resets hunger and boredom values to 0.
    /// </summary>
    internal class Phoenix : Critter
    {
        /// <summary>
        /// Constructor for Phoenix class. Accepts only name. Default hunger and boredom values are 10.
        /// </summary>
        /// <param name="name">Name of the phoenix</param>
        public Phoenix(string name) : 
            base(name, CritterType.Phoenix, 10, 10)
        { }

        /// <summary>
        /// Constructor for Phoenix class for when loading data from file.
        /// </summary>
        /// <param name="name">name of the phoenix</param>
        /// <param name="hungerLevel">this phoenix's hunger level</param>
        /// <param name="boredomLevel">this phoenix's boredom level</param>
        public Phoenix(string name, int hungerLevel, int boredomLevel) :
            base(name, CritterType.Phoenix, hungerLevel, boredomLevel) 
        { }

        /// <summary>
        /// Overrides Critter's UpdateMood abstract method
        /// Irritation level is a sum of hunger and boredom levels
        /// If irritation level > 10, this critter is angry
        /// If irritation level > 5, this critter is frustrated
        /// else it is happy
        /// </summary>
        protected override void UpdateMood()
        {
            int irritationLevel = Hunger + Boredom;

            if (irritationLevel > 10)
            {
                mood = CritterMood.Angry;
            }
            else if(irritationLevel > 5)
            {
                mood = CritterMood.Frustrated;
            }    
            else
            {
                mood = CritterMood.Happy;
            }
        }

        /// <summary>
        /// Method unique to Phoenix critter. Burns the phoenix and resets hunger and boredom levels back to 0.
        /// </summary>
        public void Burn()
        {
            Console.WriteLine("{0} immolates and turns to ash. " +
                "{0} is reborn anew from the ashes.\n" +
                "Hunger and Boredom values are set to 0.",
                name);
            Hunger = 0;
            Boredom = 0;

            UpdateMood();
        }
    }
}
