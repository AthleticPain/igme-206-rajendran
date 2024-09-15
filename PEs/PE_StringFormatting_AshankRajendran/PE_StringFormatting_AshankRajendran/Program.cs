using System.Text;

namespace PE_StringFormatting_AshankRajendran
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declare all the variables here

            const string StatusUpdateTemplate = "{0}, you now have {1} health and {2:c} remaining.";

            string name;
            string title;
            string nameWithTitle;
            int health = 100;
            double walletBalance;
            string action;
            int actionHealthRequirement;
            string item;
            double itemCost;

            //Read user input for name, title and wallet balance
            Console.Write("What is your name brave adventurer? ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("What is your title? ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            title = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("How much money are you carrying? $");
            Console.ForegroundColor = ConsoleColor.Cyan;
            walletBalance = double.Parse(Console.ReadLine()); //Parse string to double
            Console.ForegroundColor = ConsoleColor.White;

            //Combine name and title and assign it to nameWithTitle
            nameWithTitle = String.Format("{0} the {1}", name, title);
            Console.WriteLine("Welcome {0}!", nameWithTitle);

            //Read user input for action and actionHealthRequirement
            Console.WriteLine();
            Console.Write("What do you want to do next? ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            action = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("How much health does it take to do this? ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            actionHealthRequirement = int.Parse(Console.ReadLine()); //Parse string to int
            Console.ForegroundColor = ConsoleColor.White;

            //Subtract actionHealthRequirement from health
            health -= actionHealthRequirement;

            //Print action results
            Console.WriteLine();
            Console.WriteLine("Okay, let's see you {0}!", action);
            Console.WriteLine(StatusUpdateTemplate, nameWithTitle, health, walletBalance);
            
            //Read user input for item and itemCost
            Console.WriteLine();
            Console.Write("What do you want to buy? ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            item = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("How much does it normally cost? $");
            Console.ForegroundColor = ConsoleColor.Cyan;

            //Parse input string to double and markup the value by 10%
            itemCost = double.Parse(Console.ReadLine()) *1.1; 
            Console.ForegroundColor = ConsoleColor.White;

            //Subtract item cost from total wallet balance
            walletBalance -= itemCost;

            //Print action results with currency up to 3 decimal places
            Console.WriteLine();
            Console.WriteLine("You bought {0} for {1:c3}!", item, itemCost);

            //Print status update
            Console.WriteLine(StatusUpdateTemplate, nameWithTitle, health, walletBalance);
        }
    }
}
