namespace HW6_CritterFarm
{
    /// <summary>
    /// Child class of critter for Griffin critter type
    /// if irritation level > 25, griffin is angry, if >15, griffin is frustrated, else it is happy
    /// if irritation level > 25, griffin is angry, if >15, griffin is frustrated, else it is happy
    /// </summary>
    internal class Griffin : Critter
    {
        /// <summary>
        /// Constructor for Griffin class for when loading data from file.
        /// Default hunger and boredom values are set to 2.
        /// </summary>
        /// <param name="name">name of the griffin</param>
        public Griffin(string name) : 
            base(name, CritterType.Griffin, 2, 2)
        { }

        /// <summary>
        /// Constructor for Griffin class for when loading data from file.
        /// </summary>
        /// <param name="name">name of the griffin</param>
        /// <param name="hungerLevel">this griffin's hunger level</param>
        /// <param name="boredomLevel">this griffin's boredom level</param>
        public Griffin(string name, int hungerLevel, int boredomLevel) :
            base(name, CritterType.Griffin, hungerLevel, boredomLevel)
        { }

        /// <summary>
        /// Overrides Critter's UpdateMood abstract method
        /// Irritation level is a sum of hunger and boredom levels
        /// If irritation level > 25, this critter is angry
        /// If irritation level > 15, this critter is frustrated
        /// else it is happy
        /// </summary>
        protected override void UpdateMood()
        {
            int irritationLevel = Hunger + Boredom;

            if ( irritationLevel > 25)
            {
                mood = CritterMood.Angry;
            }
            else if (irritationLevel > 15)
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
