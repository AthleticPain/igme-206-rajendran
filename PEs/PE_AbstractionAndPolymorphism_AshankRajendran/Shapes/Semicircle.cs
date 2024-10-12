using System;

namespace Abstraction_Polymorphism_Demo.Shapes
{
    internal class Semicircle : Shape
    {
        // Semicircles need a radius
        private double radius;

        // Create a new semicircle using the base constructor to save the type
        public Semicircle(double radius) : base("semicircle")
        {
            this.radius = radius;
        }

        // Implement CalculateArea since we have a radius and can actually
        // do the math here
        public override double CalculateArea()
        {
            return Math.PI * radius * radius / 2;
        }

        // Implement the Area property as well
        public override double Area
        {
            get
            {
                return Math.PI * radius * radius / 2;
            }
        }
    }
}
