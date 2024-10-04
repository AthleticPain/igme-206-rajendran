namespace PE_Lists_AshankRajendran
{
    internal class Player
    {
        //Declare all variables here
        private string playerName;
        private List<string> inventory;

        //Property to get player's name
        public string PlayerName
        {
            get
            {
                return playerName;
            }
        }

        //Method to add a new entry to inventory list
        public void AddToInventory(string item)
        {
            inventory.Add(item);
            Console.WriteLine("Item '{0}' added to {1}'s inventory.", item, playerName);
        }

        //Method to remove item from inventory and return it
        public string GetItemInSlot(int index)
        {
            //Return null if index is out of acceptable range
            if(index < 0 || index >= inventory.Count)
            {
                return null;
            }
            else
            {
                //Store item in temporary variable local to this scope
                string stolenItem = inventory[index];
                inventory.RemoveAt(index);

                return stolenItem;
            }
        }

        //Method to print current inventory
        public void PrintInventory()
        {
            Console.WriteLine("\n{0}'s inventory:", playerName);
            foreach(string item in inventory)
            {
                Console.WriteLine("\t - " +  item); 
            }
        }

        //Constructor for this class
        public Player(string playerName)
        {
            //Set player name
            this.playerName = playerName;

            //Initialize list
            inventory = new List<string>();
        }
    }
}
