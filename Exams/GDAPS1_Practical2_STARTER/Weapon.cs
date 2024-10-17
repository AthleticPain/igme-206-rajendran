//****************************************************************
// DO NOT modify anything in this file *EXCEPT* where marked
// explicitly with TODO comments!
//****************************************************************
namespace GDAPS1_Practical2
{
    /// <summary>
    /// Inherits from item and adds data & behavior specific for weapons
    /// </summary>
    class Weapon : Item
    {
        // NO additional fields or properties are permitted.
        private double weight;
        private int damage;

        /// <summary>
        /// Return how much damage this weapon can do
        /// </summary>
        public int Damage { get { return damage; } }


        /// <summary>
        /// Property to get weight of weapon
        /// </summary>
        public override double Weight
        {
            get { return weight; }
        }

        /// <summary>
        /// Constructor for Weapon Class
        /// </summary>
        /// <param name="weaponName">The name of this weapon</param>
        /// <param name="damage">The damage value of this weapon</param>
        /// <param name="weight">The weight of this weapon</param>
        public Weapon(string weaponName, int damage, double weight)
            : base(weaponName)
        {
            this.damage = damage;
            this.weight = weight;
        }

        /// <summary>
        /// Gives a summary of the weapon along with the weight of the weapon
        /// </summary>
        /// <returns>A string with weapon name, weight and damage values</returns>
        public override string ToString()
        {
            return base.ToString() + string.Format(", {0}", Weight);
        }
    }
}
