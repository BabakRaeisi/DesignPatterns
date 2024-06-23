using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.Decorator
{
    /*The Decorator Pattern is a structural design pattern that allows behavior to be added to 
      individual objects, either statically or dynamically, without affecting the behavior of
      other objects from the same class. This pattern is typically used to adhere to the Open/Closed 
      Principle, which states that software entities should be open for extension but closed for modification.

Here's how you can implement the Decorator Pattern in C#:

Component Interface: Defines the interface for objects that can have responsibilities added to them.

Concrete Component: The class to which additional responsibilities can be attached.

Decorator: Maintains a reference to a Component object and defines an interface that
    conforms to the Component's interface.

Concrete Decorators: Extend the functionality of the component by adding responsibilities.
Here's an example implementation:

Step 1: Define the Component Interface*/
    public interface ICoffee
    {
        string GetDescription();
        double GetCost();
    }
    /*Step 2: Create a Concrete Component*/
    public class SimpleCoffee : ICoffee
    {
        public string GetDescription()
        {
            return "Simple coffee";
        }

        public double GetCost()
        {
            return 5.0;
        }
    }
    /*Step 3: Create a Decorator*/
    public abstract class CoffeeDecorator : ICoffee
    {
        protected ICoffee _coffee;

        public CoffeeDecorator(ICoffee coffee)
        {
            _coffee = coffee;
        }

        public virtual string GetDescription()
        {
            return _coffee.GetDescription();
        }

        public virtual double GetCost()
        {
            return _coffee.GetCost();
        }
    }
    /*Step 4: Create Concrete Decorators*/
    public class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription()
        {
            return _coffee.GetDescription() + ", milk";
        }

        public override double GetCost()
        {
            return _coffee.GetCost() + 1.5;
        }
    }

    public class SugarDecorator : CoffeeDecorator
    {
        public SugarDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription()
        {
            return _coffee.GetDescription() + ", sugar";
        }

        public override double GetCost()
        {
            return _coffee.GetCost() + 0.5;
        }
    }
    /*Step 5: Using the Decorators*/
    class Program
    {
        static void Main()
        {
            ICoffee coffee = new SimpleCoffee();
            Console.WriteLine($"{coffee.GetDescription()} costs {coffee.GetCost()}");

            coffee = new MilkDecorator(coffee);
            Console.WriteLine($"{coffee.GetDescription()} costs {coffee.GetCost()}");

            coffee = new SugarDecorator(coffee);
            Console.WriteLine($"{coffee.GetDescription()} costs {coffee.GetCost()}");
        }
    }
    /*Simple coffee costs 5
    Simple coffee, milk costs 6.5
    Simple coffee, milk, sugar costs 7
    */

    /*In this example:

    The ICoffee interface defines the methods for getting a description and cost of the coffee.
    SimpleCoffee is a concrete component that implements the ICoffee interface.
    CoffeeDecorator is an abstract class that implements ICoffee and has a reference to an ICoffee object.
    MilkDecorator and SugarDecorator are concrete decorators that extend the functionality of the coffee by adding milk and sugar respectively.
    This approach allows you to dynamically add new functionalities to objects without altering their structure.*/
}
