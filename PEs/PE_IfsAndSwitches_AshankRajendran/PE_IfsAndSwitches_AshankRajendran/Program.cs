namespace PE_IfsAndSwitches_AshankRajendran
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declare all variables here

            //Question 1 Variables
            double userAnswerQ1;

            //Question 2 Variables
            int number1;
            int number2;
            int number3;

            //Question 3 Variables
            string userAnswerQ3;

            //Question 1 Code
            //Prompt user for answer and read input
            Console.Write("What is 4*6? ");
            Console.ForegroundColor = ConsoleColor.Red;
            userAnswerQ1 = double.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            if(userAnswerQ1 == 24)
            {
                Console.WriteLine("That's Correct!");
            }
            else
            {
                Console.WriteLine("Nope :(");
            }

            //Question 2 Code

            //Prompt user input and read the 3 input numbers
            Console.WriteLine();
            Console.WriteLine("Enter any 3 integer numbers in *ascending* order:");

            //First answer
            Console.Write("1: ");
            Console.ForegroundColor = ConsoleColor.Red;
            number1 = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            //Second answer
            Console.Write("2: ");
            Console.ForegroundColor = ConsoleColor.Red;
            number2 = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            //Third answer
            Console.Write("3: ");
            Console.ForegroundColor = ConsoleColor.Red;
            number3 = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            if(number2 > number1 && number3 > number2)
            {
                Console.WriteLine("That's correct!");
            }
            else if(number2 < number1 && number3 < number2)
            {
                Console.WriteLine("That's backwards!");
            }
            else
            {
                Console.WriteLine("What?!");
            }


            //Question 3 Code

            //"Print question and options
            Console.WriteLine();
            Console.WriteLine("The capital of Uzbekistan is...");
            Console.WriteLine("\ta. Istanbul");
            Console.WriteLine("\tb. Tashkent");
            Console.WriteLine("\tc. Yerevan");
            Console.WriteLine("\td. Baku");
            Console.WriteLine("\te. Rabat");

            //Read user input
            Console.Write("> ");
            Console.ForegroundColor = ConsoleColor.Red;
            userAnswerQ3 = Console.ReadLine().Trim().ToLower();
            Console.ForegroundColor = ConsoleColor.White;

            //check if user typed the correct option letter
            //OR directly typed the correct option
            switch(userAnswerQ3)
            {
                //Correct cases
                case "b":
                case "tashkent":
                    Console.WriteLine("Correct!");
                    break;

                //Incorrect cases
                case "istanbul":
                case "yerevan":
                case "baku":
                case "rabat":
                case "a":
                case "c":
                case "d":
                case "e":
                    Console.WriteLine("Sorry, that's incorrect." +
                        "\nThe capital of Uzbekistan is " +
                        "Tashkent.");
                    break;

                //Default case
                default:
                    Console.WriteLine("That wasn't even an option!");
                    break;
            }

        }
    }
}
