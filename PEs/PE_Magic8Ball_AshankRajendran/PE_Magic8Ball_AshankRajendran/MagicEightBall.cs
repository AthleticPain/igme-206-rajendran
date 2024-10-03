using System;

namespace PE_Magic8Ball_AshankRajendran
{
    internal class MagicEightBall
    {
        //Declare all variables for this scope
        string owner;
        int timesShaken;
        string[] potentialResponses;
        Random randomObject;

        //Method to return random response from potentialResponses
        //Also increments timesShaken
        public string ShakeBall()
        {
            timesShaken++;

            //Get a random index value
            int randomIndex = randomObject.Next(0, potentialResponses.Length);
            return potentialResponses[randomIndex];
        }

        //Method to return a statement about the number of times
        //the eight ball has been shaken
        public string Report()
        {
            if(timesShaken == 0)
            {
                return owner + " has not shaken the ball yet.";
            }
            else if(timesShaken >= 1 && timesShaken <= 3)
            {
                return string.Format("{0} has shaken the ball {1} times.",
                    owner,
                    timesShaken);
            }
            else //If timesShaken > 4
            {
                return string.Format("{0} has shaken the ball {1} times. " +
                    "That's a lot of questions!",
                    owner,
                    timesShaken);
            }

        }

        //Constructor to initialize instance of this class
        public MagicEightBall(string ownerName) 
        { 
            this.owner = ownerName;
            timesShaken = 0;
            potentialResponses = new string[]
            {
                //Positive Responses
                "Yes, Nostradamus predicted it would be so.",
                "You can bet your life savings on it!",
                "Yes, but only if you take decisive action right now!",
                "Yes, although there may be an unexpected twist.",
                "Yes, it was foretold in ancient prophecies.",
                "Much like death and taxes, it is certain.",

                //Neutral Responses
                "I think you know the answer to that already.",
                "I am not at liberty to divulge this information.",
                "The movie 'Shrek' may have the answer you seek.",
                "If I told you the answer, it may drastically change the course of the future.",
                "Trust me buddy, you don't wanna know the answer to that.",
                "You want the truth? You can't handle the truth!",

                //Negative Responses
                "That ain't happening.",
                "I have personally taken steps to ensure that the answer to this is 'No'.",
                "Never in a million years.",
                "No, and I mean no. Don't ask me this again.",
                "Thank you for expressing your interest in this. " +
                "Unfortunately, my answer this time will have to be 'No'.",
                "For your own good, the answer is 'No'."
            };

            randomObject = new Random();
        }
    }
}
