//****************************************************************
// DO NOT modify anything in this file *EXCEPT* where marked
// explicitly with TODO comments!
//****************************************************************
namespace GDAPS1_Practical2
{
    /// <summary>
    /// Inherits from item and adds data & behavior specific for foods
    /// </summary>
    class Food : Item
    {
        // NO additional fields are permitted.
        private int numServings;
        private double lbsPerServing;

        /// <summary>
        /// Returns total weight of the food item 
        /// (Number of servings * weight of food per serving)
        /// </summary>
        public override double Weight
        {
            get
            {
                return numServings * lbsPerServing;
            }
        }

        /// <summary>
        /// Parameterized constructor for Food class
        /// </summary>
        /// <param name="name">Name of the food item</param>
        /// <param name="numServings">Number of servings in this item</param>
        /// <param name="lbsPerServing">Weight per serving of this food item</param>
        public Food(string name, int numServings, double lbsPerServing)
            : base(name)
        {
            this.numServings = numServings;
            this.lbsPerServing = lbsPerServing;
        }

        /// <summary>
        /// Eats a serving of food
        /// </summary>
        public void Eat()
        {
            if (numServings > 0)
            {
                Console.WriteLine("Mmmm I ate a serving of " + this.Name);
                numServings--;
            }
            else
            {
                Console.WriteLine(":( There's no " + Name + " left to eat.");
            }
        }

        /// <summary>
        /// Provides name and weight of the item as well as number of servings in this food item
        /// </summary>
        /// <returns>String containing food name, food weight, and number of servings available</returns>
        public override string ToString()
        {
            return base.ToString() + string.Format(" and has {0} servings", numServings);
        }

    }
}
