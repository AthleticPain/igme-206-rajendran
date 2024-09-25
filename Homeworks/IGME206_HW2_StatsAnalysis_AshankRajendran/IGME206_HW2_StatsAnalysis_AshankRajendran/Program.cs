namespace IGME206_HW2_StatsAnalysis_AshankRajendran
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declare all variables here

            //Player's stats
            string player1Name;
            string player2Name;
            
            int player1GamesPlayed;
            int player2GamesPlayed;
            
            int player1GamesWon;
            int player2GamesWon;
            
            int player1GamesLost;
            int player2GamesLost;

            double player1WinRate;
            double player2WinRate;

            int player1AverageTime;
            int player2AverageTime;
            
            double player1TotalTimePlayed;
            double player2TotalTimePlayed;

            bool isPlayer1StatsValid = true;
            bool isPlayer2StatsValid = true;

            //Prompts for player one here
            Console.WriteLine("=========== STATS ANALYZER ===========\n");

            //Ask all player one stats
            Console.Write("Enter the name for Player 1: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            player1Name = Console.ReadLine().Trim();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter the number of games {0} played: ", player1Name);
            Console.ForegroundColor = ConsoleColor.Cyan;
            player1GamesPlayed = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter the number of games {0} won: ", player1Name);
            Console.ForegroundColor = ConsoleColor.Cyan;
            player1GamesWon = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter the number of games {0} lost: ", player1Name);
            Console.ForegroundColor = ConsoleColor.Cyan;
            player1GamesLost = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter the total time played by {0} in hours: ", player1Name);
            Console.ForegroundColor = ConsoleColor.Cyan;
            player1TotalTimePlayed = double.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            //Check player one responses
            //Check if player name string is not empty
            if(player1Name.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Invalid name for player 1");
                isPlayer1StatsValid = false;
            }

            //Check if any stats are negative
            if(player1GamesPlayed < 0 
                || player1GamesWon < 0
                || player1GamesLost < 0
                || player1TotalTimePlayed < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Games & total play time " +
                    "must be non-negative numbers!");
                isPlayer1StatsValid = false;
            }

            //Check if games won + games lost = total games played
            if(player1GamesPlayed != player1GamesWon + player1GamesLost)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: The number of games won and lost " +
                    "does not match the total number of games played!");
                isPlayer1StatsValid = false;
            }

            //Check if games played and total time is equal to 0
            if(player1GamesPlayed == 0 || player1TotalTimePlayed == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: No stats to calculate for a " +
                    "player with zero games or no play time!!");
                isPlayer1StatsValid = false;
            }
            Console.WriteLine();

            //if any error in input, end program here
            if (!isPlayer1StatsValid)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cannot continue with analysis. Goodbye.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            //Prompts for player two here

            //Ask all player two stats
            Console.Write("Enter the name for Player 2: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            player2Name = Console.ReadLine().Trim();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter the number of games {0} played: ", player2Name);
            Console.ForegroundColor = ConsoleColor.Cyan;
            player2GamesPlayed = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter the number of games {0} won: ", player2Name);
            Console.ForegroundColor = ConsoleColor.Cyan;
            player2GamesWon = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter the number of games {0} lost: ", player2Name);
            Console.ForegroundColor = ConsoleColor.Cyan;
            player2GamesLost = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter the total time played by {0} in hours: ", player2Name);
            Console.ForegroundColor = ConsoleColor.Cyan;
            player2TotalTimePlayed = double.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            //Check player two responses
            //Check if player name string is not empty
            if (player2Name.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Invalid name for player 2");
                isPlayer2StatsValid = false;
            }

            //Check if any stats are negative
            if (player2GamesPlayed < 0
                || player2GamesWon < 0
                || player2GamesLost < 0
                || player2TotalTimePlayed < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Games & total play time " +
                    "must be non-negative numbers!");
                isPlayer2StatsValid = false;
            }

            //Check if games won + games lost = total games played
            if (player2GamesPlayed != player2GamesWon + player2GamesLost)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: The number of games won and lost " +
                    "does not match the total number of games played!");
                isPlayer2StatsValid = false;
            }

            //Check if games played and total time is equal to 0
            if (player2GamesPlayed == 0 || player2TotalTimePlayed == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: No stats to calculate for a " +
                    "player with zero games or no play time!!");
                isPlayer2StatsValid = false;
            }

            //if any error in input, end program here
            if (!isPlayer2StatsValid)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cannot continue with analysis. Goodbye.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            Console.WriteLine();

            //Calculate average time and win ratio
            player1AverageTime = (int)(60 * player1TotalTimePlayed / player1GamesPlayed);
            player1WinRate = (double)player1GamesWon / (double)player1GamesPlayed;

            player2AverageTime = (int)(60 * player2TotalTimePlayed / player2GamesPlayed);
            player2WinRate = (double)player2GamesWon / (double)player2GamesPlayed;

            //Print out table of stats
            Console.WriteLine("Summary Table:");
            Console.WriteLine("\t\t\t{0}\t\t{1}", 
                player1Name, player2Name);

            Console.WriteLine("\tGames Played\t{0}\t\t{1}", 
                player1GamesPlayed, player2GamesPlayed);

            Console.WriteLine("\tGames Won\t{0}\t\t{1}", 
                player1GamesWon, player2GamesWon);

            Console.WriteLine("\tGames Lost\t{0}\t\t{1}", 
                player1GamesLost, player2GamesLost);

            Console.WriteLine("\tTotal Time (h)\t{0:f1}\t\t{1:f1}", 
                player1TotalTimePlayed, player2TotalTimePlayed);

            Console.WriteLine("\tWin Rate\t{0:p3}\t\t{1:p3}", 
                player1WinRate, player2WinRate);

            Console.WriteLine("\tAvg Time (m)\t{0}\t\t{1}", 
                player1AverageTime, player2AverageTime);

            Console.WriteLine();

            //Compare stats and declare winner
            if(player1WinRate > player2WinRate)
            {
                Console.WriteLine("{0} has a better win rate!", player1Name);
            }
            else if(player1WinRate < player2WinRate)
            {
                Console.WriteLine("{0} has a better win rate!", player2Name);
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }
        }
    }
}
