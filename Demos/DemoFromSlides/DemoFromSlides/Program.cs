namespace DemoFromSlides
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            //// From the slides ...
            //// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            //// Declarations with initial values
            //int x = 2;
            //double price = 1.99;
            //double money = 100;
            //int pizzaSlices = 35;
            //int candy = 75;
            //int students = 58;

            //// Increment x by 5
            //x = x + 5;

            //// Increase the price by 8%
            //price = price * 1.08;

            //// Decrease the available money by the price
            //money = money - price;

            //// Only an eighth of the pizza is left
            //pizzaSlices = pizzaSlices / 8;

            //// How much candy is leftover?
            //candy = candy % students;

            //// Print the final values
            //Console.WriteLine("x: " + x);
            //Console.WriteLine("price: " + price);
            //Console.WriteLine("money: " + money);
            //Console.WriteLine("pizzaSlices: " + pizzaSlices);
            //Console.WriteLine("candy: " + candy);
            //Console.WriteLine("students: " + students);

            // Some variables that will come in handy
            int a = 12;
            int b = 25;
            double c = 5.2517;

            // Remember, each Math method returns a value. We can store
            // that value to a variable:
            int maxNumber = Math.Max(a, b);

            // Or use it as part of a statement
            Console.WriteLine("The bigger number is " + Math.Max(a, b));

            // Other examples of using Math methods (as part of WriteLines here
            // so I can avoid declaring more variables)
            Console.WriteLine("a and b have a difference of " + Math.Abs(a - b));
            Console.WriteLine("c rounded to default precision: " + Math.Round(c));
            Console.WriteLine("c rounded to 2 places: " + Math.Round(c, 2));


            // Remember that even if the result is a whole number, many Math 
            // methods only return doubles.
            // int rounded = Math.Round(c); // won't compile
            int rounded = (int)Math.Round(c); // MUST cast

            // So if we have to cast, why bother with Round() for going to
            // whole numbers?
            Console.WriteLine("Cast 25.98 to an int: " + (int)25.98);
            Console.WriteLine("Round 25.98 to an int: " + (int)Math.Round(25.98));


        }
    }
}
