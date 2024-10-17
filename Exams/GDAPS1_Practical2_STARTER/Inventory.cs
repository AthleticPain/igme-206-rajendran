//****************************************************************
// DO NOT modify anything in this file *EXCEPT* where marked
// explicitly with TODO comments!
//****************************************************************
namespace GDAPS1_Practical2
{
    /// <summary>
    /// A standalone class to hold Item object instances
    /// </summary>
    class Inventory
    {
        // NO additional fields are permitted.
        private List<Item> items = new List<Item>();

        /// <summary>
        /// Return the number of items within the
        /// inventory's list. Nothing can be changed.
        /// </summary>
        public int NumberItems
        {
            get
            {
                return items.Count;
            }
        }

        /// <summary>
        /// Add an item to the list of items
        /// </summary>
        /// <param name="itemToAdd">The object of type Item which is to be added to the list</param>
        public void AddItem(Item itemToAdd)
        {
            items.Add(itemToAdd);
        }

        /// <summary>
        /// Prints a summary of each item in the list of items. 
        /// Also provides number of items in list 
        /// and total weight of all items and total damage of all weapons
        /// </summary>
        public void PrintSummary()
        {
            //Print item count summary
            Console.WriteLine("The inventory currently has {0} item(s):", NumberItems);

            //Foreach loop to print details of each item in list
            foreach (Item item in items)
            {
                Console.WriteLine("\t" + item.ToString());
            }

            Console.WriteLine("Total weight: " + CalculateTotalWeight());
            Console.WriteLine("Total damage from weapon(s): " + CalculateTotalDamage());
        }


        /// <summary>
        /// Calculates the total weight of all items in items list
        /// </summary>
        /// <returns>Total weight of all items as a double</returns>
        private double CalculateTotalWeight()
        {
            double total = 0;

            //Loop through each item and add its weight to total
            foreach (Item item in items)
            {
                total += item.Weight;
            }
            return total;
        }

        /// <summary>
        /// Calculates the total damage of all items in list that are weapons
        /// </summary>
        /// <returns>Total damage of all weapons as a double</returns>
        private double CalculateTotalDamage()
        {
            double total = 0;

            //Loop through each item in list
            //if item is a weapon then add it's damage to total
            foreach (Item item in items)
            {
                if (item is Weapon)
                {
                    total += ((Weapon)item).Damage; //Downcasting
                }
            }
            return total;
        }

        /// <summary>
        /// Loads items from a file line by line
        /// </summary>
        public void LoadItems(string filename)
        {
            StreamReader input = null;

            try
            {
                input = new StreamReader(filename);
                string line = null;
                while ((line = input.ReadLine()) != null)
                {
                    //Use split method of string class to seperate line into array of strings
                    string[] dataLoadedFromLine = line.Trim().ToLower().Split('~');

                    //Check if first element in array is weapon or food
                    //and call constructor accordingly and add to list
                    if (dataLoadedFromLine[0] == "weapon")
                    {
                        //Parse according to expected data type
                        Weapon newWeapon = new Weapon(dataLoadedFromLine[1], int.Parse(dataLoadedFromLine[2]), double.Parse(dataLoadedFromLine[3]));
                        AddItem(newWeapon);
                    }
                    else if (dataLoadedFromLine[0] == "food")
                    {
                        //Parse according to expected data type
                        Food newFood = new Food(dataLoadedFromLine[1], int.Parse(dataLoadedFromLine[2]), double.Parse(dataLoadedFromLine[3]));
                        AddItem(newFood);
                    }

                }
            }
            catch(Exception e) 
            {
                Console.Write("uh oh: " + e.Message);
                Console.WriteLine();
            }

            if (input != null)
            {
                input.Close();
            }
        }

        /// <summary>
        /// Complete the LightenLoad method to drop heavy items
        /// </summary>
        public void LightenLoad()
        {
        }
    }
}
