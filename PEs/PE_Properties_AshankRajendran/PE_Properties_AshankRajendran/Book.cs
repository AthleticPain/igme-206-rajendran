namespace PE_Properties_AshankRajendran
{
    internal class Book
    {
        //Declare all variables here

        private string title;
        private string author;
        private int numberOfPages;
        private string owner;
        private int totalTimesRead;

        //Define all properties here
        public string Title
        {
            //get only
            get
            {
                return title;
            }
        }

        public string Author
        {
            //get only
            get
            {
                return author;
            }
        }

        public int NumberOfPages
        {
            //get only
            get
            {
                return numberOfPages;
            }
        }

        public string Owner
        {
            get
            {
                return owner;
            }

            set
            {
                //Only set value if string is not empty ot null
                if (value != "" && value != null)
                {
                    owner = value;
                }

                //Alternative method
                /*if(string.IsNullOrEmpty(value))
                {
                    owner = value;
                }*/
            }
        }

        public int TotalTimesRead
        {
            get
            {
                return totalTimesRead;
            }

            set
            {
                //Only set value if it is greater than current value
                if(value > totalTimesRead)
                {
                    totalTimesRead = value;
                }
            }
        }

        //Method to print all of this book's information
        public void Print()
        {
            Console.WriteLine("{0} by {1} has {2} pages." +
                "It is owned by {3} and has been read {4} times.",
                title,
                author,
                numberOfPages,
                owner,
                totalTimesRead);
        }

        //Constructor for this class
        public Book(string title, string author, int numberOfPages, string owner)
        {
            this.title = title;
            this.author = author;
            this.numberOfPages = numberOfPages;
            this.owner = owner;
            TotalTimesRead = 0;
        }
    }
}
