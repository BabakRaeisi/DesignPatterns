using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



/*Let's consider a real-world example of a logistics company that needs to deliver different types of packages.
 * Depending on the destination, the company uses different transportation methods like trucks, ships, and planes.
 * We will use the Factory Method pattern to handle the creation of different transport objects.

Real-World Example: Logistics Company
Product Interface: ITransport
Concrete Products: Truck, Ship, Plane
Creator Abstract Class: Logistics
Concrete Creators: RoadLogistics, SeaLogistics, AirLogistics*/

namespace DesignPatterns.CreationalPatterns.FactoryMethod.LogisticsCompanyExample
{
    //Product Interface(ITransport)
    public interface ITransport
    {
        void Deliver();
    }

    //Concrete Product Classes (Truck, Ship, Plane)
    public class Truck : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("Delivering by land in a truck.");
        }
    }

    public class Ship : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("Delivering by sea in a ship.");
        }
    }

    public class Plane : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("Delivering by air in a plane.");
        }
    }


    //Creator Abstract Class(Logistics)
    public abstract class Logistics
    {
        // Factory Method
        public abstract ITransport CreateTransport();

        // An operation that uses the product
        public void PlanDelivery()
        {
            // Create a transport
            var transport = CreateTransport();

            // Use the transport
            transport.Deliver();
        }
    }


    //Concrete Creator Classes (RoadLogistics, SeaLogistics, AirLogistics)
    public class RoadLogistics : Logistics
    {
        public override ITransport CreateTransport()
        {
            return new Truck();
        }
    }

    public class SeaLogistics : Logistics
    {
        public override ITransport CreateTransport()
        {
            return new Ship();
        }
    }

    public class AirLogistics : Logistics
    {
        public override ITransport CreateTransport()
        {
            return new Plane();
        }
    }

    //usage
    class Program
    {
        static void Main(string[] args)
        {
            Logistics roadLogistics = new RoadLogistics();
            roadLogistics.PlanDelivery(); // Output: Delivering by land in a truck.

            Logistics seaLogistics = new SeaLogistics();
            seaLogistics.PlanDelivery(); // Output: Delivering by sea in a ship.

            Logistics airLogistics = new AirLogistics();
            airLogistics.PlanDelivery(); // Output: Delivering by air in a plane.
        }
    }
}
