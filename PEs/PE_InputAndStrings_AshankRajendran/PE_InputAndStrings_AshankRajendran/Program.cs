namespace PE_InputAndStrings_AshankRajendran
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //All user inputs will be stored in these variables
            string userName;
            string userFavoriteColor;
            string userBestFriendName;
            string userFavoriteBand;

            Console.Write("What is your name? ");
            
            //Changes text color to cyan for user input and then back to white
            Console.ForegroundColor = ConsoleColor.Cyan;
            userName = Console.ReadLine();          //Reads user input
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Welcome " + userName + "!");

            Console.Write("What is your favorite color? ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            userFavoriteColor = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("What is your best friend's name? ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            userBestFriendName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("What is your favorite band? ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            userFavoriteBand = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
            Console.WriteLine("Your name is " + 
                userName.Length +                   //Number of letters in user's name
                " letters long");

            //Calculate and print the difference in number of letters between:
            //user's name and best friend's name
            Console.WriteLine("and " +
                (userName.Length - userBestFriendName.Length) +
                " letters longer than " + 
                userBestFriendName + "'s name."
                );

            Console.WriteLine();
            Console.WriteLine("Maybe " + userBestFriendName + 
                " and " + userFavoriteBand +
                " also like the color " + userFavoriteColor + 
                "."
                );

            Console.WriteLine();

            //Take first letter of user's name in uppercase
            //Take first two letters of other input strings in lowercase
            //Concatenate them all and print that as a new name
            Console.WriteLine("Maybe I should just call you " +
                userName.ToUpper()[0] +
                userFavoriteColor.ToLower().Substring(0, 2) +
                userBestFriendName.ToLower().Substring(0, 2) +
                userFavoriteBand.ToLower().Substring(0, 2) +
                "?"
                );
        }
    }
}
