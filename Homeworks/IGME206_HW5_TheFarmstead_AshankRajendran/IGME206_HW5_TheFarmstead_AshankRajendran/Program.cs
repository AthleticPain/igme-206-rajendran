/***
 * Ashank Rajendran
 * 
 * HW 5 - The Farmstead
 * Write-up: https://docs.google.com/document/d/1xnF9pZIhLC-PW3OAOktW15VzMtAktTZWnHEsuQSDBpQ/edit?usp=sharing
***/

using HW5_FarmingSim;

namespace IGME206_HW5_TheFarmstead_AshankRajendran
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //****************************
            //Variables
            //****************************

            Farm myFarm;
            int numberOfCropTypes;
            Crop[] availableCrops;

            string newCropName;
            double newCropCost;
            int newCropGrowthTime;

            string newFarmName;
            int newFarmNumberOfAvailablePlots;
            double newFarmStartingMoney;
            double newFarmDailyMaintenanceCost;

            int usersChoice = -1;

            Console.WriteLine("Welcome to Farmstead, your virtual farming adventure!");
            Console.WriteLine("Start your farming journey by defining the crops available " +
                "and naming your farm.");
            numberOfCropTypes = SmartConsole.GetValidNumericInput(
                "\nHow many crops do you want to define? ", 1, 5);

            availableCrops = new Crop[numberOfCropTypes];

            for (int i = 0; i < numberOfCropTypes; i++)
            {
                Console.WriteLine("\nDefine crop type #{0}", i + 1);
                newCropName = SmartConsole.GetPromptedInput("Name: ");
                newCropCost = SmartConsole.GetValidNumericInput("Cost: ", 1.0, 500.0);
                newCropGrowthTime = SmartConsole.GetValidNumericInput(
                    "Days until harvest: ", 1, 10);

                availableCrops[i] = new Crop(newCropName, newCropCost, newCropGrowthTime);
            }

            newFarmName = SmartConsole.GetPromptedInput(
                "\nPlease name your farm: ");
            newFarmNumberOfAvailablePlots = SmartConsole.GetValidNumericInput(
                "\nHow many fields are available for planting? ", 1, 5);
            newFarmStartingMoney = SmartConsole.GetValidNumericInput(
                "\nHow much money are you starting with? ", 1.0, 1000.0);
            newFarmDailyMaintenanceCost = SmartConsole.GetValidNumericInput(
                "\nWhat is the daily maintenance cost? ", 1.0, 50.0);

            myFarm = new Farm(newFarmName, availableCrops, newFarmNumberOfAvailablePlots,
                newFarmStartingMoney, newFarmDailyMaintenanceCost);

            Console.WriteLine("\n*** {0}, ready for a fruitful season! ***", myFarm.FarmName);

            //Main game loop
            while (myFarm.CurrentMoney > 0)
            {
                Console.WriteLine("\nDay {0} at {1} with {2:c} on hand.",
                    myFarm.DaysPassed + 1, myFarm.FarmName, myFarm.CurrentMoney);
                Console.WriteLine("We have {0:c} potential earnings from the fields ready to harvest.",
                    myFarm.PotentialEarnings);
                myFarm.BuildFieldList();

                Console.WriteLine("\n1. Plant Crops");
                Console.WriteLine("2. Harvest and sell produce");
                Console.WriteLine("3. Do nothing today");
                Console.WriteLine("4. Quit");

                usersChoice = SmartConsole.GetValidNumericInput("> ", 1, 4);

                switch (usersChoice)
                {
                    case 1:
                        myFarm.Plant();
                        break;
                    case 2:
                        myFarm.Harvest();
                        break;
                    case 3:
                        Console.WriteLine("You did nothing today.");
                        break;
                    case 4:
                        myFarm.DayPassed();
                        SmartConsole.PrintSuccess(
                            string.Format("\nYou quit with {0:c} in the bank!", 
                            myFarm.CurrentMoney));
                        return;
                }

                myFarm.DayPassed();
            }

            SmartConsole.PrintError(string.Format("\n{0} ran out of money!", myFarm.FarmName));
        }
    }
}
