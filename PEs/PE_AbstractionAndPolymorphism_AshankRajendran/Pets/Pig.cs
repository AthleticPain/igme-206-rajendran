using System;

namespace Abstraction_Polymorphism_Demo.Pets
{
    internal class Pig : Pet
    {
        // The parameterized Pig constructor just needs to
        // pass the parameters plus it's fixed type to the 
        // parent constructor
        public Pig(string name, DateTime birthday)
            : base(name, birthday, "pig")
        {
        }

        // We also want to override Speak so that this Pig can talk!
        public override void Speak()
        {
            Console.WriteLine(this.Name + " says OINK.");
        }
    }
}
