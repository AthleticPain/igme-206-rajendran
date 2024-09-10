namespace DebuggingTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Give me some input: ");
            //String name = Console.ReadLine();
            //Console.WriteLine("The input that was given: "+name);

            //float howManyFit = 100 / name.Length;
            //Console.WriteLine("How many fit: "+howManyFit);

            Console.WriteLine("About to test input and parsing: \n");
            Console.Write("Enter your name: ");
            
            string name;
            name = Console.ReadLine();
            
            Console.WriteLine("Hello, \"" + name + "\"!");

            Console.WriteLine("The first two letters of your name are: " + name.Substring(0, 2));

            //Testing what PadLeft() does
            Console.WriteLine("This is what PadLeft() does: " + name.PadLeft(7, '@'));

            //Testing Replace()
            Console.WriteLine("This is what Replace() does: " + name.ToLower().Replace('a', 'e'));

            //Testing Remove()
            Console.WriteLine("This is what Remove() does: " + name.Remove(0, 2));
        }
    }
}
