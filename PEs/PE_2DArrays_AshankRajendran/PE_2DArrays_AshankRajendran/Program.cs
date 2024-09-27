using System.Data;

namespace PE_2DArrays_AshankRajendran
{
    internal class Program
    {
        /// <summary>
        /// Method written by Ashank
        /// Sequentially populate a 2D array
        /// starting from startNum
        /// </summary>
        /// <param name="array">The 2D array to populate</param>
        /// <param name="startNum">The starting value for the sequence</param>
        public static void Fill2DArray(int[,] array, int startNum)
        {
            for (int row = 0; row < array.GetLength(0); row++)
            {
                for(int col = 0; col < array.GetLength(1); col++)
                {
                    array[row, col] = startNum;
                    startNum++;
                }
            }
        }

        /// <summary>
        /// Method written by Ashank
        /// Print all elements of 2D array to a nicely formatted table
        /// </summary>
        /// <param name="array">The 2D array to print the values of</param>
        public static void Print2DArray(int[,] array)
        {
            //First print the column headers
            Console.Write("\t");
            for(int col = 0; col<array.GetLength(1); col++)
            {
                Console.Write("Col {0}\t", (col + 1));
            }
            Console.WriteLine();

            //Then print the array values along with row headers
            for (int row = 0; row < array.GetLength(0); row++)
            {
                Console.Write("Row {0}:\t", (row + 1)); //Print row header
                for (int col = 0; col < array.GetLength(1); col++)
                {
                    Console.Write("{0}\t",array[row, col]);
                }
                Console.WriteLine();  //Move cursor to next line (next row)
            }
        }

        static void Main(string[] args)
        {
            // Initialize a 2D array of 2 x 4 elements with sequential values
            int[,] integerArray = new int[2, 4];
            Fill2DArray(integerArray, 5);

            // Print values of the array
            Print2DArray(integerArray);
        }
    }
}
