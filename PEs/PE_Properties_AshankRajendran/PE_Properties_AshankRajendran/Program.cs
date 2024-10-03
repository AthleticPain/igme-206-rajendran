namespace PE_Properties_AshankRajendran
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declare all variables here
            string bookTitle;
            string bookAuthor;
            int bookNumberOfPages;
            string bookCurrentOwner;

            Book book;

            string userAction = "";

            //Print welcome statement
            Console.WriteLine("Welcome to Book Simulator 2024");

            //Prompt user for book details
            Console.Write("\nWhat is the book's title? ");
            Console.ForegroundColor = ConsoleColor.Green;
            bookTitle = Console.ReadLine().Trim();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Who is the book's author? ");
            Console.ForegroundColor = ConsoleColor.Green;
            bookAuthor = Console.ReadLine().Trim();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("How many pages does it have? ");
            Console.ForegroundColor = ConsoleColor.Green;
            bookNumberOfPages = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Who is the book's current owner? ");
            Console.ForegroundColor = ConsoleColor.Green;
            bookCurrentOwner = Console.ReadLine().Trim();
            Console.ForegroundColor = ConsoleColor.White;

            //Initialize a new instance of Book class with these details
            book = new Book(bookTitle, bookAuthor, bookNumberOfPages, bookCurrentOwner);

            //Keep looping until user's input is "done"
            while(userAction != "done")
            {
                Console.Write("\nWhat would you like to do? ");
                Console.ForegroundColor = ConsoleColor.Green;
                userAction = Console.ReadLine().Trim().ToLower();
                Console.ForegroundColor= ConsoleColor.White;

                switch(userAction)
                {
                    case "title":
                        Console.WriteLine("The title is {0}.", book.Title);
                        break;

                    case "author":
                        Console.WriteLine("The author is {0}.", book.Author);
                        break;

                    case "pages":
                        Console.WriteLine("The book has {0} pages.", book.NumberOfPages);
                        break;

                    case "owner":

                        //Ask user if they want to change the owner
                        Console.Write("Would you like to change the owner? (yes/no)? ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        userAction = Console.ReadLine().Trim().ToLower();
                        Console.ForegroundColor= ConsoleColor.White;

                        //If yes, ask for new owners name and update,
                        //Else if no, just print current owners name
                        //Else, print invalid input message
                        if(userAction == "yes")
                        {
                            //Prompt for new owner
                            Console.Write("Who is the new owner? ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            bookCurrentOwner = Console.ReadLine().Trim(); 
                            Console.ForegroundColor = ConsoleColor.White;

                            //Update Owner property
                            book.Owner = bookCurrentOwner;

                            //Print new owner name
                            Console.WriteLine("The new owner is {0}.", book.Owner);
                        }
                        else if(userAction == "no")
                        {
                            Console.WriteLine("Ok. {0} is still the owner.", book.Owner);
                        }
                        else
                        {
                            //Reset userAction to prevent escaping loop in case user types
                            //"done" here
                            userAction = "";
                            Console.WriteLine("Invalid input. Please try again.");
                        }

                        break;

                    case "read":

                        //Increment total times read by one and print new value
                        book.TotalTimesRead++;
                        Console.WriteLine("The total times read is now {0}.", book.TotalTimesRead);
                        break;

                    case "print":
                        book.Print();
                        break;

                    case "done":
                        //While loop will break after this
                        Console.WriteLine("Goodbye.");
                        break;

                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            }
        }
    }
}
