namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create the writer
            StreamWriter writer =
                new StreamWriter("../../../filename.txt");

            // Write some data
            writer.Write("Hello ");
            writer.WriteLine("there!");
            writer.WriteLine("Another line");
            Console.WriteLine(Path.GetFullPath("../../../filename.txt"));

            // Close the stream, which closes the file.
            // NOTE: Data isn't written until stream is closed!
            writer.Close();


            //string[] words = new string[5];
            //foreach (string word in words)
            //{
            //    Console.WriteLine(word);
            //    //Console.WriteLine(word.Length);
            //}

            //bool[] boolValues = new bool[5];
            //foreach (bool value in boolValues)
            //{
            //    Console.WriteLine(value);
            //}

            //char[] chars = new char[5];
            //foreach(char value in chars)
            //{
            //    Console.WriteLine(value);
            //}

            //int[] numbers = new int[10];
            //Console.WriteLine(numbers[90]);     //index out of range error
        }
    }
}
