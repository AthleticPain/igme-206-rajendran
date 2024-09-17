using System;

namespace WhileLoopDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int Min = 0;
            const int Max = 10;

            string userInput;

            bool isInputValid;

            int num = -1;
            do
            {
                Console.Write("Enter an even number between {0} - {1}: ",
                    Min,
                    Max);

                userInput = Console.ReadLine();
                isInputValid = int.TryParse(userInput, out num);

                //num = int.Parse(Console.ReadLine());


                // Tell the user what went wrong,
                // only if it's actually wrong
                if ( !isInputValid || num % 2 == 1 || num < Min || num > Max )
                {
                    Console.WriteLine("That is invalid!");
                }
            }
            while (!isInputValid || num % 2 == 1 || num < Min || num > Max);
            Console.WriteLine("You did it!");

            // Print out the even numbers between Min and Max
            // skipping the user's input
            Console.WriteLine("Printing even numbers from {0} to {1} in a loop:",
                Min,
                Max);

            //int count = Min - 2; // Going to increment before the first WriteLine so start below our Min.
            int count = Min; // Going to increment before the first WriteLine so start below our Min.
            while (count <= Max)
            {
                //count += 2; // Alter the loop control variable!

                if (count == num)
                {
                    Console.WriteLine("Skipping your number!");
                }
                else
                {
                    Console.WriteLine(count);
                }

                count += 2; // Alter the loop control variable!

            }
        }
    }
}
