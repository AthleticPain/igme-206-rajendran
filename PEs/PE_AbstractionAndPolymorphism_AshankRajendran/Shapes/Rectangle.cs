using System;

namespace Abstraction_Polymorphism_Demo.Shapes
{
    internal class Rectangle : Shape
    {
        // Rectangeles need a length and width
        private double length;
        private double width;

        // Create a new rectangle using the base constructor to save the type
        public Rectangle(double length, double width) : base("rectangle")
        {
            this.length = length;
            this.width = width;
        }

        // Implement CalculateArea since we have a length and width and can actually
        // do the math here
        public override double CalculateArea()
        {
            return length * width;
        }

        // Implement the Area property as well
        public override double Area
        {
            get
            {
                return length * width;
            }
        }
    }
}
