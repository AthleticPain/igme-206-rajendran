﻿// ------------------------------------------------------------------
// DO NOT MODIFY ANY CODE IN THIS FILE EXCEPT:
// - To implement file loading & saving
// - To change the critter types available
// ------------------------------------------------------------------
using System.IO;
using System.Xml.Linq;

namespace HW6_CritterFarm
{
    /// <summary>
    /// Manager class for managing list of critters and associated methods
    /// This class is responsible for maintaining a list of all critters on the farm and the current active critter
    /// It provides acces to the names of the active critter
    /// It is responsible for setting up new critters for a new farm
    /// Can save and load critters to and from file
    /// Manages the overall interactions with each critter
    /// Randomly calls Phoenix's burn method 10% of the time
    /// </summary>
    class CritterManager
    {
        // ----------------------------------------------------------------------
        // Fields
        // ----------------------------------------------------------------------

        /// <summary>
        /// List to hold all of the critters by leveraging polymorphism
        /// </summary>
        private List<Critter> critterList;

        /// <summary>
        /// Reference to the current active critter
        /// </summary>
        private Critter activeCritter;

        /// <summary>
        /// The filename to use when loading/saving critters
        /// </summary>
        private string filename;

        /// <summary>
        /// Generator for any pseuod-random numbers needed
        /// </summary>
        private Random rng = new Random();

        // ----------------------------------------------------------------------
        // Properties
        // ----------------------------------------------------------------------

        /// <summary>
        /// Return the NAME of the current active critter or return null if
        /// one isn't active
        /// </summary>
        public String ActiveCritter
        {
            get
            {
                if (activeCritter != null)
                {
                    return activeCritter.Name;
                }
                else
                {
                    return null!; // The ! tells the compiler to ignore warnings about a possible null value.
                }
            }
        }

        // ----------------------------------------------------------------------
        // Default Constructor
        // ----------------------------------------------------------------------

        /// <summary>
        /// Default constructor to initialize the list and active critter
        /// </summary>
        public CritterManager(string filename)
        {
            critterList = new List<Critter>();
            activeCritter = null!; // The ! tells the compiler to ignore warnings about a possible null value.
            this.filename = filename;
        }

        // ---------------------------------------------------------------------------------------------------------------
        // Critter setup via user input
        // ---------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Initial setup of critters. 
        /// Prompts a user for a number of critters, then their names,
        /// then adds newly instantiated critters to the critter list.
        /// All critters start with 0 hunger and 0 boredom.
        /// 
        /// THIS METHOD IS DONE FOR YOU so that you have examples of how to TryParse an enum type and
        /// use a switch statement with enums. You'll have to do both yourself when loading from a file!
        /// </summary>
        public void SetupCritters()
        {
            // Ask user for number of critters and their names
            int numberCritters = SmartConsole.GetValidNumericInput(
                "How many critters should your farm contain (1-5)?",
                1, 5);

            // Gather information about critter names from user,
            //   then create new Critter into the list
            for (int i = 0; i < numberCritters; i++)
            {
                string name = SmartConsole.GetPromptedInput("\nEnter critter " + (i + 1) + " name:");
                string typeString = SmartConsole.GetPromptedInput("What type of critter is " + name +
                    " (Griffin, Fairy or Phoenix)?");
                CritterType type = CritterType.Griffin;

                // Enums work with a TryParse too! :)
                while (!Enum.TryParse<CritterType>(typeString, true, out type) // true as the middle param tells TryParse to ignore case
                    || !Enum.IsDefined(typeof(CritterType), type))
                // TryParse accepts ints that aren't actually valid for this
                // enum. Using IsDefined checks them before allowing the loop
                // to proceed.
                {
                    SmartConsole.PrintWarning("Sorry, I don't know how to take care of a " + typeString + ".\n");
                    typeString = SmartConsole.GetPromptedInput("What type of critter is " + name +
                        " (Griffin, Fairy or Phoenix)?");
                }

                // Create the correct type of critter

                // The switch statement cases and constructor calls below need to match YOUR critter types
                switch (type)
                {
                    case CritterType.Griffin:
                        critterList.Add(new Griffin(name));
                        break;

                    case CritterType.Fairy:
                        critterList.Add(new Fairy(name));
                        break;

                    case CritterType.Phoenix:
                        critterList.Add(new Phoenix(name));
                        break;

                    default:
                        // shouldn't happen
                        SmartConsole.PrintError(String.Format("Not sure how to create {0} with a type of {1}", name, typeString));
                        i--; // Didn't actually add a critter so go back 1 with our lcv and try again.
                        break;
                }
            }
        }

        // ---------------------------------------------------------------------------------------------------------------
        // Critter file loading and saving
        // ---------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Loads critter data from a file
        /// If there are no saved critters, calls SetupCritters() to allow user to
        /// enter their own critters.
        /// If file data exists, populates critterList with critters built from
        /// the file's data.
        /// </summary>
        public void LoadCrittersFromFile()
        {
            // ********************************
            // File name: critters.txt
            // File structure (sample line):
            // type|name|hunger #|boredom #
            // ********************************

            critterList.Clear();
            StreamReader fileReader = null;

            try
            {
                fileReader = new StreamReader(filename);

                string line = null;
                while ((line = fileReader.ReadLine()) != null)
                {
                    string[] lineData = line.Split('|');
                    bool isTypeValid = Enum.TryParse(typeof(CritterType), lineData[0], out object? newCritterType);

                    if (!isTypeValid)
                    {
                        SmartConsole.PrintWarning(string.Format(
                            "{0}'s are not supported yet. Skipping this line: {1}",
                            lineData[0], line));
                        continue;
                    }

                    int newCritterHunger = 0;
                    int newCritterBoredom = 0;

                    bool isDataValid =
                        int.TryParse(lineData[2], out newCritterHunger) && int.TryParse(lineData[3], out newCritterBoredom);

                    if (!isDataValid)
                    {
                        SmartConsole.PrintWarning(string.Format(
                            "Corrupt data. Skipping this line: {0}",
                            line));
                        continue;
                    }

                    //Construct new critter based on type
                    switch (newCritterType)
                    {
                        case CritterType.Griffin:
                            Griffin newGriffin = new Griffin(lineData[1], newCritterHunger, newCritterBoredom);
                            critterList.Add(newGriffin);
                            break;
                        case CritterType.Fairy:
                            Fairy newFairy = new Fairy(lineData[1], newCritterHunger, newCritterBoredom);
                            critterList.Add(newFairy);
                            break;
                        case CritterType.Phoenix:
                            Phoenix newPhoenix = new Phoenix(lineData[1], newCritterHunger, newCritterBoredom);
                            critterList.Add(newPhoenix);
                            break;
                        default:
                            // shouldn't happen
                            SmartConsole.PrintError(String.Format(
                                "Not sure how to create {0} with a type of {1}", lineData[1], lineData[0]));
                            break;
                    }

                }

            }
            catch (Exception e)
            {
                if (!File.Exists(filename))
                {
                    SmartConsole.PrintError("Critter save file doesn't exist or can't be opened.\n" +
                        "You'll need to set up a new critter farm.");
                    SetupCritters();
                }
                else
                {
                    SmartConsole.PrintError("Unexpected error while loading: " + e.Message);
                }
            }

            if (fileReader != null)
            {
                fileReader.Close();
            }

            if (critterList.Count == 0)
            {
                SmartConsole.PrintWarning("No critters in save file.\n" +
                "You'll need to set up a new critter farm.");
                SetupCritters();
                return;
            }
        }


        /// <summary>
        /// Saves critter data to a file.
        /// If there are no saved critters, writes "No critters saved."
        /// If critters do exist, writes their data to the file.
        /// </summary>
        public void SaveCrittersToFile()
        {
            // ********************************
            // File name: critters.txt
            // File structure (sample line):
            // type|name|hunger #|boredom #
            // ********************************

            if (critterList.Count == 0)
            {
                Console.WriteLine("No critters in list.");
                return;
            }

            StreamWriter fileWriter = null;

            try
            {
                fileWriter = new StreamWriter(filename);

                foreach (Critter critter in critterList)
                {
                    fileWriter.WriteLine("{0}|{1}|{2}|{3}",
                        critter.Type, critter.Name, critter.Hunger, critter.Boredom);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error saving: " + e.Message);
            }

            if (fileWriter != null)
            {
                fileWriter.Close();
            }
        }

        // ---------------------------------------------------------------------------------------------------------------
        // Critter Control Methods
        // ---------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Sets the active critter to one of the critters in the critter list.
        /// </summary>
        /// <param name="critterName">Name of critter to set the active critter to</param>
        /// <returns>Whether this operation was successful</returns>
        public bool ChooseCritter(string critterName)
        {
            // Determine if the Critter exists in the list
            // And set it as active
            activeCritter = null!; // The ! tells the compiler to ignore warnings about a possible null value.
            for (int i = 0; i < critterList.Count; i++)
            {
                if (critterList[i].Name == critterName)
                {
                    activeCritter = critterList[i];
                }
            }

            // Let Main know whether this was successful
            return activeCritter != null;
        }

        /// <summary>
        /// Retrieves a list of the names of all current critters
        /// </summary>
        /// <returns>List of names of all critters</returns>
        public List<string> GetCritterNames()
        {
            List<string> critterNames = new List<string>();
            for (int i = 0; i < critterList.Count; i++)
            {
                critterNames.Add(critterList[i].Name);
            }
            return critterNames;
        }

        // ---------------------------------------------------------------------------------------------------------------
        // Critter Actions
        // ---------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Feeds the active critter 4 units of food.
        /// </summary>
        public void FeedCritter()
        {
            if (activeCritter == null)
            {
                return;
            }

            Console.WriteLine("Feeding your critter...");
            activeCritter.Eat();
        }


        /// <summary>
        /// Plays with the active critter for 4 fun units.
        /// </summary>
        public void PlayWithCritter()
        {
            if (activeCritter == null)
            {
                return;
            }

            Console.WriteLine("Playing with your critter...");
            activeCritter.Play();
        }


        /// <summary>
        /// Talks with the active critter.
        /// </summary>
        public void TalkToCritter()
        {
            if (activeCritter == null)
            {
                return;
            }

            Console.WriteLine("Talking to your critter...");
            activeCritter.Talk();
        }


        /// <summary>
        /// Simulates time passing for every critter for every "round" of user actions.
        /// </summary>
        public void TimePassing()
        {
            foreach (Critter c in critterList)
            {
                c.PassTime();

                //10% Chance for phoenix to burn
                if (c is Phoenix)
                {
                    if (rng.NextDouble() < 0.10)
                    {
                        ((Phoenix)c).Burn();
                    }
                }
            }
        }

        /// <summary>
        /// Prints critter data about every critter in the list.
        /// Helpful for testing. 
        /// </summary>
        public void PrintCritters()
        {
            // Get string representation of every Critter in the list
            for (int i = 0; i < critterList.Count; i++)
            {
                Console.WriteLine("{0} ({2}): {1}",
                    i + 1,
                    critterList[i],
                    critterList[i].Type);
            }
        }
    }
}
