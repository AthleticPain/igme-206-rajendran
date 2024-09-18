namespace PE_Loops_AshankRajendran
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declare variables here
            int loopControlVariable;

            int boxWidth;
            int boxHeight;

            //**********************************
            //Part 1
            //**********************************

            //While loop to print 0 to 5
            loopControlVariable = 0;    //set variable to 0;
            while (loopControlVariable <= 5)
            {
                Console.WriteLine(loopControlVariable);
                loopControlVariable++;  //increment variable
            }

            //Do-while loop to print 100 to 95
            Console.WriteLine();
            loopControlVariable = 100;  //set variable to 100
            do
            {
                Console.WriteLine(loopControlVariable);
                loopControlVariable--;  //Decrement variable
            }
            while (loopControlVariable >= 95);

            //For loop to print multiples of 5 to 25
            Console.WriteLine();
            for(loopControlVariable=0; loopControlVariable <= 25; loopControlVariable += 5)
            {
                Console.WriteLine(loopControlVariable);
            }

            //**********************************
            //Part 2
            //**********************************

            //Prompt to ask user for dimensions of box
            Console.Write("Enter a width: ");
            boxWidth = int.Parse(Console.ReadLine());
            Console.Write("Enter a height: ");
            boxHeight = int.Parse(Console.ReadLine());

            //for loop to print solid box
            for (int i = 0; i < boxHeight; i++)
            {
                for(int j = 0; j < boxWidth; j++)
                {
                    Console.Write('o');     //print character in each column
                }
                Console.WriteLine();        //move cursor to next row at end of column
            }

            Console.WriteLine();            //line break

            //for loop to print box border
            for (int i = 0; i < boxHeight; i++)
            {
                for (int j = 0; j < boxWidth; j++)
                {
                    //if we are not on a border coordinate, print a space
                    //else(if we are on a border coordinate) print a character
                    if (i > 0 && i < boxHeight - 1 && j > 0 && j < boxWidth - 1)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("o");
                    }
                }
                Console.WriteLine();        //move cursor to next row at end of column
            }
        }
    }
}
