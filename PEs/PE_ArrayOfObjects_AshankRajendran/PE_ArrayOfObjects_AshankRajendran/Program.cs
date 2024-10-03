namespace PE_ArrayOfObjects_AshankRajendran
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Initialize instance of deck class
            Deck deck = new Deck();
            int numberOfCardsToDeal;

            //Print all the cards in the deck
            deck.Print();

            //Ask user for number of cards to be dealt
            Console.Write("\nEnter a number of cards to deal (1-52): ");
            
            Console.ForegroundColor = ConsoleColor.Cyan;
            numberOfCardsToDeal = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            //Deal the given number of cards using Deck class's Deal() method
            Console.WriteLine();
            deck.Deal(numberOfCardsToDeal);
        }
    }
}
