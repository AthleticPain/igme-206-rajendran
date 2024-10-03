using System;

namespace PE_ArrayOfObjects_AshankRajendran
{
    internal class Deck
    {
        private Random rng;
        private Card[] cards; //Array of Cards

        //Method to print entire deck of cards to screen
        public void Print()
        {
            Console.WriteLine("Your deck:");
            for (int i = 0; i < cards.Length; i++)
            {
                Console.Write(" - ");
                cards[i].Print();
            }
        }

        //Method to deal a given number of cards randomly
        public void Deal(int amount)
        {
            Console.WriteLine("Your hand:");

            for(int i =0; i < amount; i++)
            {
                //random index is next random integer from range 0 to 51 (size of deck)
                //Call print statement of card that has that index
                Console.Write(" - ");
                cards[rng.Next(0, cards.Length)].Print();
            }
        }

        //Constructor for this class
        public Deck()
        {
            //Initialize instance of Random class
            rng = new Random();

            //Initialize array of cards
            cards = new Card[52];

            //Loop to assign value to each Card object in array
            //For each suit, assign the 13 values in a nested loop
            for(int i =0; i < 4; i++)
            {
                string suitName = "";

                //Set suitName based on current iteration number
                switch(i)
                {
                    case 0:
                        suitName = "Hearts";
                        break;
                    case 1:
                        suitName = "Spades";
                        break;
                    case 2:
                        suitName = "Diamonds";
                        break;
                    case 3:
                        suitName = "Clubs";
                        break;
                }

                //Nested loop to initialize 13 cards of current suit
                for(int j = 0; j < 13; j++)
                {
                    //Call constructor for this card object
                    //Index of array will be i * 13 + j
                    cards[j + i * 13] = new Card(j + 1, suitName);
                }
            }
        }
    }
}
