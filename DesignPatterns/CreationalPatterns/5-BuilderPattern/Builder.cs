using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.BuilderPattern
{
    /*The Builder pattern is a creational design pattern that allows you to construct complex objects step by step.
     It separates the construction of a complex object from its representation, enabling the same construction process
     to create different representations.

 Here is an example of the Builder pattern in C#:

 Example: Building a House

 Product Class: This represents the complex object being constructed.

 Builder Interface: This defines the steps to build the product.

 Concrete Builder: This implements the steps defined in the builder interface.

 Director: This constructs the product using the builder interface.

 Client: This uses the Director and a Concrete Builder to construct the product.*/

    /*Step 1: Define the Product Class*/
    public class House
    {
        public string Foundation { get; set; }
        public string Structure { get; set; }
        public string Roof { get; set; }
        public string Interior { get; set; }

        public override string ToString()
        {
            return $"House with {Foundation} foundation, {Structure} structure, {Roof} roof, and {Interior} interior.";
        }
    }
    /* Step 2: Define the Builder Interface*/
    public interface IHouseBuilder
    {
        void BuildFoundation();
        void BuildStructure();
        void BuildRoof();
        void BuildInterior();
        House GetHouse();
    }
    /*Step 3: Implement the Concrete Builder*/
    public class ConcreteHouseBuilder : IHouseBuilder
    {
        private House _house = new House();

        public void BuildFoundation()
        {
            _house.Foundation = "Concrete, brick, and stone";
            Console.WriteLine("Foundation completed.");
        }

        public void BuildStructure()
        {
            _house.Structure = "Wood and brick";
            Console.WriteLine("Structure completed.");
        }

        public void BuildRoof()
        {
            _house.Roof = "Concrete and tiles";
            Console.WriteLine("Roof completed.");
        }

        public void BuildInterior()
        {
            _house.Interior = "Drywall and paint";
            Console.WriteLine("Interior completed.");
        }

        public House GetHouse()
        {
            return _house;
        }
    }
    /*Step 4: Define the Director*/
    public class ConstructionDirector
    {
        private readonly IHouseBuilder _houseBuilder;

        public ConstructionDirector(IHouseBuilder houseBuilder)
        {
            _houseBuilder = houseBuilder;
        }

        public void ConstructHouse()
        {
            _houseBuilder.BuildFoundation();
            _houseBuilder.BuildStructure();
            _houseBuilder.BuildRoof();
            _houseBuilder.BuildInterior();
        }
    }
    /*Step 5: Client Code*/
    class Program
    {
        static void Main(string[] args)
        {
            IHouseBuilder builder = new ConcreteHouseBuilder();
            ConstructionDirector director = new ConstructionDirector(builder);

            director.ConstructHouse();
            House house = builder.GetHouse();

            Console.WriteLine(house.ToString());
        }
    }
    /*Explanation
    House Class: This is the complex object that we want to build.

    IHouseBuilder Interface: This defines the steps required to build a house.
    ConcreteHouseBuilder Class: This implements the steps defined in the IHouseBuilder interface to
    build a specific type of house.

    ConstructionDirector Class: This takes a builder and constructs the house by
    executing the building steps in a particular sequence.

    Client Code: The client creates a builder, passes it to the director,
    and then constructs the house. Finally, the client retrieves the house from the builder.

    This example demonstrates how the Builder pattern can be used to construct
    a complex object step by step, allowing for different representations of the object by
    using different builders.*/
}
