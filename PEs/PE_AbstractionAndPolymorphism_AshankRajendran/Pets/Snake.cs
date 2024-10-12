using System;

namespace Abstraction_Polymorphism_Demo.Pets
{
    class Snake : Pet
    {        
        // The parameterized Snake constructor just needs to
        // pass the parameters plus it's fixed type to the 
        // parent constructor
        public Snake(string name, DateTime birthday)
            : base(name, birthday, "snake")
        {
        }

        // We also want to override Speak so that this Snake can talk!
        public override void Speak()
        {
            Console.WriteLine(this.Name + " says HISS.");
        }
    }
}
