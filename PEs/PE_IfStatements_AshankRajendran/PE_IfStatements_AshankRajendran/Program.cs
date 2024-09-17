namespace PE_IfStatements_AshankRajendran
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declare all variables here
            string userResponse;

            //List of all acceptable user responses stored as variables
            string acceptableUserResponse1 = "loot";
            string acceptableUserResponse2 = "raiders";
            string acceptableUserResponse3 = "food";

            //Introduce the setting to the player
            Console.WriteLine("You wander the wasteland " +
                "with your trusty canine companion, 'Dogmeat'.");

            //Read the user's input
            Console.Write("What does Dogmeat sense? ");
            Console.ForegroundColor = ConsoleColor.Green;
            userResponse = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            //Trim the text and make sure it's all lowercase
            userResponse = userResponse.Trim().ToLower();

            //Scenario 1
            if (userResponse == acceptableUserResponse1)
            {
                Console.WriteLine("Dogmeat runs excitedly towards the loot " +
                    "and barks at you to grab your attention.");
            }
            //Scenario 2
            else if (userResponse == acceptableUserResponse2)
            {
                Console.Write("Are the raiders aware of your presence? ");
                Console.ForegroundColor = ConsoleColor.Green;
                userResponse = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                userResponse = userResponse.Trim().ToLower(); //Trim and lowercase

                //Nested scenario
                if (userResponse == "yes")
                {
                    Console.WriteLine("Brave Dogmeat rushes fiercly " +
                        "towards the enemy to bite them.");
                }
                else if (userResponse == "no")
                {
                    Console.WriteLine("Dogmeat adopts a crouched, hunting stance, " +
                        "ready to attack the enemy whenever you strike.");
                }
                else
                {
                    Console.WriteLine("Dogmeat is not sure how to respond to that, " +
                        "but he rushes down the enemy anyway.");
                }
            }
            //Scenario 3
            else if (userResponse == acceptableUserResponse3)
            {
                Console.Write("Is Dogmeat at full HP? ");
                Console.ForegroundColor = ConsoleColor.Green;
                userResponse = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                userResponse = userResponse.Trim().ToLower(); //Trim and lowercase

                //Nested scenario
                if (userResponse == "yes")
                {
                    Console.WriteLine("Dogmeat is not hungry right now, " +
                        "although he would appreciate it if you stored " +
                        "the food in your inventory for later.");
                }
                else if (userResponse == "no")
                {
                    Console.WriteLine("Dogmeat runs over to the food and devours it, " +
                        "recovering some HP.");
                }
                else
                {
                    Console.WriteLine("Dogmeat is not sure how to respond to that. " +
                        "He decides to eat the food anyway.");
                }
            }
            //Unexpected Scenario
            else
            {
                Console.WriteLine("Dogmeat tilts his head and gives you a puzzled look.");
            }
        }
    }
}
