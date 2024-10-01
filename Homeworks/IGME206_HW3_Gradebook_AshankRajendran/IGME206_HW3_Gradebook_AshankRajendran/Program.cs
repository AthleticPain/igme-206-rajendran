namespace IGME206_HW3_Gradebook_AshankRajendran
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Flag to check if any user input is valid
            bool isInputValid = false;

            //Declare all variables here
            int numberOfGrades = 0;

            string[] assignmentNames;
            double[] assignmentGrades;

            double totalGradeScore = 0;
            double gradeAverage;

            int replacementGradeIndex = -1;
            double replacementGradeValue = 0;

            double highestGrade;
            double lowestGrade;

            int numberOfAboveAverageGrades = 0;

            bool arrayHasDuplicateGrades = false;

            //*********************************
            //Activity 1
            //*********************************

            //Ask user for number of grades
            Console.Write("How many assignments are you saving? ");
            while (isInputValid == false)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                isInputValid = int.TryParse(Console.ReadLine(), out numberOfGrades);
                Console.ForegroundColor = ConsoleColor.White;

                //If input parsed correctly, check if it is 0 or negative
                if (isInputValid && numberOfGrades <= 0)
                {
                    isInputValid = false;
                }

                //If the user input is invalid, display error message
                //Loop will continue
                if(isInputValid == false)
                {
                    Console.Write("That is not a valid number. Enter the number of assignments: ");
                }
            }

            //Print statement to confirm number of assignments
            Console.WriteLine("You are saving {0} assignments.", numberOfGrades);

            //Initialize arrays to the given size
            assignmentNames = new string[numberOfGrades];
            assignmentGrades = new double[numberOfGrades];

            //Use a loop to prompt user for
            //assignment name and grade
            for(int i=0; i<numberOfGrades; i++)
            {
                //Get assignment name
                Console.Write("\nEnter the name for assignment #{0}: ", i + 1);
                Console.ForegroundColor = ConsoleColor.Cyan;
                assignmentNames[i] = Console.ReadLine().Trim();
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("Enter the grade for {0}: ", assignmentNames[i]);

                isInputValid = false; //Set flag to false

                while(isInputValid == false)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    isInputValid = double.TryParse(Console.ReadLine(), out assignmentGrades[i]);
                    Console.ForegroundColor = ConsoleColor.White;

                    //If input is parsed correctly, check if value is within correct range
                    if(isInputValid && (assignmentGrades[i] < 0 || assignmentGrades[i] > 100))
                    {
                        isInputValid = false;
                    }

                    if(isInputValid == false)
                    {
                        Console.Write("Grade must be between 0 and 100. Enter grade: ");
                    }
                }
            }

            //Confirm that all grades are entered
            Console.WriteLine("\nAll grades are entered!");

            //*********************************
            //Activity 2
            //*********************************

            Console.WriteLine("\nGrade Report: ");
            
            //Loop to print a list of all the assignments and grades
            //Using the same loop to calculate total grade score
            for(int i=0; i<numberOfGrades; i++)
            {
                Console.WriteLine("  {0}. {1}: {2}", 
                    i + 1, assignmentNames[i], assignmentGrades[i]);

                totalGradeScore += assignmentGrades[i];
            }

            //Calculate grade average from totalGradeScore
            gradeAverage = totalGradeScore/ numberOfGrades;

            Console.WriteLine("------------------------------------");
            Console.WriteLine("Average: {0:F2}", gradeAverage);

            //*********************************
            //Activity 3
            //*********************************

            //Loop to get correct input for grade number to replace

            isInputValid = false; //set flag to false
            Console.WriteLine();

            while (isInputValid == false)
            {
                //Prompt user for grade number to replace
                Console.Write("Which number grade do you want to replace? ");

                Console.ForegroundColor = ConsoleColor.Cyan;
                isInputValid = int.TryParse(Console.ReadLine(), out replacementGradeIndex);
                Console.ForegroundColor = ConsoleColor.White;

                //If parsing was succesful, check if number is within correct range
                if(isInputValid && (replacementGradeIndex < 1 || replacementGradeIndex > numberOfGrades))
                {
                    isInputValid = false;
                }

                //If input is not valid, display error message
                if(isInputValid == false)
                {
                    Console.WriteLine("Index must be a number between 1 and {0}. " +
                        "Try again.", numberOfGrades);
                }
                //Else (if input is valid), decrement index by 1 to match 0 indexing
                else
                {
                    replacementGradeIndex -= 1;
                }
            }

            //Loop to get correct input for valid replacement grade

            Console.Write("\nWhat is the new grade for {0}? ", 
                assignmentNames[replacementGradeIndex]);

            isInputValid = false; //set flag to false

            while(isInputValid == false)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                isInputValid = double.TryParse(Console.ReadLine(), out replacementGradeValue);
                Console.ForegroundColor = ConsoleColor.White;

                //If parsing successful,
                //check if new grade value is in correct range
                if(isInputValid && (replacementGradeValue < 0 || replacementGradeValue > 100))
                {
                    isInputValid = false;
                }

                //If input is not valid display error message
                if(isInputValid == false)
                {
                    Console.Write("Grade must be between 0 and 100. Enter grade: ");
                }
            }

            //Replace the correct grade
            assignmentGrades[replacementGradeIndex] = replacementGradeValue;

            //Print confirmation statement
            Console.WriteLine("\nReplacing the grade at index {0} with {1}",
                replacementGradeIndex + 1,
                replacementGradeValue);

            //*********************************
            //Activity 4
            //*********************************

            totalGradeScore = 0; //reset the value to 0

            Console.WriteLine("\nFinal Grade Report: ");

            //Loop to print a list of all the assignments and grades
            //Using the same loop to calculate total grade score
            for (int i = 0; i < numberOfGrades; i++)
            {
                Console.WriteLine("  {0}. {1}: {2}",
                    i + 1, assignmentNames[i], assignmentGrades[i]);

                totalGradeScore += assignmentGrades[i];
            }

            //Calculate new grade average from new totalGradeScore value
            gradeAverage = totalGradeScore / numberOfGrades;

            Console.WriteLine("------------------------------------");
            Console.WriteLine("Final Average: {0:F2}", gradeAverage);

            //*********************************
            //Activity 5
            //*********************************

            //Initialize highestGrade and lowestGrade to
            //first element of assignmentGrades array
            highestGrade = assignmentGrades[0];
            lowestGrade = assignmentGrades[0];


            //loop to find highest and lowest grades
            //using same loop to find
            //number of above average grades
            for (int i = 0; i < numberOfGrades; i++)
            {
                //if current grade is above average
                //increment numberOfAboveAverageGrades by 1
                if (assignmentGrades[i] > gradeAverage)
                {
                    numberOfAboveAverageGrades++;
                }

                //if current grade is greater than current highestGrade value
                //replace old value with this value
                if (assignmentGrades[i] > highestGrade)
                {
                    highestGrade = assignmentGrades[i];
                }

                //if current grade is lower than current lowestGrade value
                //replace old value with this value
                if (assignmentGrades[i] < lowestGrade)
                {
                    lowestGrade = assignmentGrades[i];
                }
            }

            //loop to check if there are any duplicate grades
            for (int i = 0; i < numberOfGrades - 1; i++)
            {
                for (int j = i + 1; j < numberOfGrades; j++)
                {
                    if (assignmentGrades[i] == assignmentGrades[j])
                    {
                        arrayHasDuplicateGrades = true;
                    }
                }
            }

            //Print out analysis summary
            Console.WriteLine("\n{0} grades are above average.", 
                numberOfAboveAverageGrades);

            Console.WriteLine("\nThe highest grade is {0}.\n" +
                "The lowest grade is {1}.",
                highestGrade,
                lowestGrade);

            if (arrayHasDuplicateGrades)
            {
                Console.WriteLine("\nA grade appears more than once " +
                    "in this set of grades.");
            }
            else
            {
                Console.WriteLine("\nAll grades are unique.");
            }

        }
    }
}
