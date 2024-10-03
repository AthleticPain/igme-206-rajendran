using System;

namespace PE_ArrayOfObjects_AshankRajendran
{
    internal class Card
    {
        private int value;
        private string suit;

        //Method to print the card value and suit
        public void Print()
        {
            string cardName = "";

            //Set card name depending on value
            //If value is 1, 11, 12 or 13
            //set it to that specific values name (Ace, Jack, Queen or King)
            //Else set card name to be same as value
            if(value == 1)
            {
                cardName = "Ace";
            }
            else if(value == 11)
            {
                cardName = "Jack";
            }
            else if (value == 12)
            {
                cardName = "Queen";
            }
            else if (value == 13)
            {
                cardName = "King";
            }
            else
            {
                cardName = "" + value;

                //Alternative method to set name
                //cardName = value.ToString();
            }

            Console.WriteLine(cardName + " of " + suit);
        }

        //Constructor for this class
        //initializes value and suit
        public Card(int value, string suit)
        {
            this.value = value;
            this.suit = suit;
        }
    }
}
