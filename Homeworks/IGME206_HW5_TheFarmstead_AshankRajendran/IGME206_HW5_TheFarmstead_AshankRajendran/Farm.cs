using HW5_FarmingSim;

namespace IGME206_HW5_TheFarmstead_AshankRajendran
{
    internal class Farm
    {
        //****************************
        //All Variables
        //****************************
        private string farmName;
        private double currentMoney;
        private double dailyMaintenanceCost;
        private Crop[] availableCrops;
        private Crop[] currentCrops;
        private int daysPassed;
        private Random rng;

        //****************************
        //Properties
        //****************************
        public string FarmName
        {
            get { return farmName; }
        }

        public int DaysPassed
        {
            get { return daysPassed; }
        }

        public double CurrentMoney
        {
            get { return currentMoney; }
        }

        public double PotentialEarnings
        {
            get
            {
                double potentialEarnings = 0;

                foreach (Crop crop in currentCrops)
                {
                    if (crop != null)
                    {
                        if (crop.CanHarvest)
                        {
                            potentialEarnings += crop.SellingPrice;
                        }
                    }
                }

                return potentialEarnings;
            }
        }

        //****************************
        //Constructors
        //****************************

        public Farm(string farmName, Crop[] availableCrops, int numberOfPlotsAvailable,
            double startingMoney, double dailyMaintenanceCost)
        {
            this.farmName = farmName;
            this.availableCrops = availableCrops;
            currentCrops = new Crop[numberOfPlotsAvailable];
            currentMoney = startingMoney;
            this.dailyMaintenanceCost = dailyMaintenanceCost;
            rng = new Random();
        }

        //****************************
        //Methods
        //****************************

        public void DayPassed()
        {
            daysPassed++;
            currentMoney -= dailyMaintenanceCost;

            //Determine weather even with rng
            double randomValueForWeatherEvent = rng.NextDouble();

            if (randomValueForWeatherEvent < 0.05)
            {
                SmartConsole.PrintError("Blight has struck the farm!" +
                    "\nAll our crops are dead! :(");

                for (int i = 0; i < currentCrops.Length; i++)
                {
                    currentCrops[i] = null;
                }
            }
            else if (randomValueForWeatherEvent < 0.25)
            {
                SmartConsole.PrintWarning("It rained. Nothing grew today." +
                    "\nHopefully Tomorrow will be better");
            }
            else
            {
                foreach (Crop crop in currentCrops)
                {
                    if (crop != null)
                    {
                        crop.DayPassed();
                    }
                }
            }
        }

        public void Plant()
        {
            bool isAnyFieldAvailable = false;
            int indexOfFirstAvailableField = -1;

            //Check if any field is available to plant on
            //Store index of first available field
            for (int i = 0; i < currentCrops.Length; i++)
            {
                if (currentCrops[i] == null)
                {
                    isAnyFieldAvailable = true;
                    indexOfFirstAvailableField = i;
                    break;
                }
            }

            Console.WriteLine();
            if (!isAnyFieldAvailable)
            {
                SmartConsole.PrintError("Unable to plant something right now. " +
                    "Harvest something first.");
                return;
            }
            else
            {
                //Prompt player for which crop to plant
                Console.WriteLine("Select a crop to plant:");
                for (int i = 0; i < availableCrops.Length; i++)
                {
                    Console.WriteLine("   {0}. {1}  (Cost: {2:c})",
                        i + 1, availableCrops[i].CropName, availableCrops[i].Cost);
                }

                int userChoice = SmartConsole.GetValidNumericInput("> ", 1, availableCrops.Length);
                userChoice--; //Decrement to fit zero indexing

                //Check if player has enough money to plant crop
                if (currentMoney < availableCrops[userChoice].Cost)
                {
                    SmartConsole.PrintError("You cannot afford to plant this crop.");
                    return;
                }
                else
                {
                    Crop newCrop = new Crop(availableCrops[userChoice]);
                    currentCrops[indexOfFirstAvailableField] = newCrop;
                    currentMoney -= newCrop.Cost;

                    SmartConsole.PrintSuccess(string.Format("{0} planted in field {1}.",
                        newCrop.CropName, indexOfFirstAvailableField + 1));
                }
            }
        }

        public void Harvest()
        {
            bool isAnyCropPlanted = false;

            //Check if any crop has been planted
            foreach (Crop crop in currentCrops)
            {
                if (crop != null)
                {
                    isAnyCropPlanted = true;
                    break;
                }
            }

            Console.WriteLine();

            if (!isAnyCropPlanted)
            {
                SmartConsole.PrintError("You have to plant something first!");
                return;
            }
            else
            {
                Console.WriteLine("Which field would you like to harvest?");
                BuildFieldList();
                int userChoice = SmartConsole.GetValidNumericInput("> ", 1, currentCrops.Length);
                userChoice--; //Decrement to fit zero indexing

                //Check if user's chosen field is harvestable or empty
                if (currentCrops[userChoice] == null)
                {
                    SmartConsole.PrintError(
                        string.Format("You have to plant something in field {0} first!",
                        userChoice + 1));
                    return;
                }
                else
                {
                    if (!currentCrops[userChoice].CanHarvest)
                    {
                        SmartConsole.PrintError("This crop is not ready to harvest yet!");
                    }
                    else
                    {
                        currentMoney += currentCrops[userChoice].SellingPrice;
                        SmartConsole.PrintSuccess(
                            string.Format("{0} has been sold for {1:c}.",
                            currentCrops[userChoice].CropName,
                            currentCrops[userChoice].SellingPrice));
                        currentCrops[userChoice] = null;
                    }
                }
            }
        }

        public void PrintStatus()
        {
            Console.WriteLine("Status of {0}:", farmName);
            Console.WriteLine("Day number: {0}\nCurrent Money: {1:c}",
                daysPassed, currentMoney);
            Console.WriteLine("Status of all fields:");
            BuildFieldList();
            Console.WriteLine("Potential earnings: " + PotentialEarnings);
        }

        public void BuildFieldList()
        {
            for (int i = 0; i < currentCrops.Length; i++)
            {
                Console.Write(" - Field {0}: ", i + 1);
                if (currentCrops[i] == null)
                {
                    //TODO Check ToString() method for null crop;
                    Console.WriteLine("Empty");
                }
                else
                {
                    Console.WriteLine(currentCrops[i].ToString());
                }
            }
        }
    }
}
