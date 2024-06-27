using DesignPatterns.CreationalPatterns.FactoryMethod;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace DesignPatterns.CreationalPatterns.AbstractFactory
{
    /* Abstract Factory Pattern
     The Abstract Factory pattern provides an interface for creating families of related 
    or dependent objects without specifying their concrete classes.
    This pattern is useful when a system needs to be independent of
    how its objects are created and composed, or when the creation process involves
    multiple types of related objects.

     Example Scenario
  Consider a furniture store that produces different types of furniture sets.
    Each set includes a chair and a sofa.
    The store offers modern and Victorian styles of furniture.

     Implementation

     Abstract Products: IChair and ISofa
     Concrete Products: ModernChair, VictorianChair, ModernSofa, VictorianSofa
     Abstract Factory: IFurnitureFactory
     Concrete Factories: ModernFurnitureFactory, VictorianFurnitureFactory
  Client: Uses the abstract factory to create families of related objects

 Step-by-Step Implementation
 Define the Abstract Product Interfaces*/
    public interface IChair
    {
        void SitOn();
    }

    public interface ISofa
    {
        void LieOn();
    }

    //Implement Concrete Product Classes
    public class ModernChair : IChair
    {
        public void SitOn()
        {
            Console.WriteLine("Sitting on a modern chair.");
        }
    }

    public class VictorianChair : IChair
    {
        public void SitOn()
        {
            Console.WriteLine("Sitting on a Victorian chair.");
        }
    }

    public class ModernSofa : ISofa
    {
        public void LieOn()
        {
            Console.WriteLine("Lying on a modern sofa.");
        }
    }

    public class VictorianSofa : ISofa
    {
        public void LieOn()
        {
            Console.WriteLine("Lying on a Victorian sofa.");
        }
    }
    //Create the Abstract Factory Interface
    public interface IFurnitureFactory
    {
        IChair CreateChair();
        ISofa CreateSofa();
    }
    //Implement Concrete Factory Classes
    public class ModernFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair()
        {
            return new ModernChair();
        }

        public ISofa CreateSofa()
        {
            return new ModernSofa();
        }
    }

    public class VictorianFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair()
        {
            return new VictorianChair();
        }

        public ISofa CreateSofa()
        {
            return new VictorianSofa();
        }
    }


    //Client Code
    class Client
    {
        private readonly IChair _chair;
        private readonly ISofa _sofa;

        public Client(IFurnitureFactory factory)
        {
            _chair = factory.CreateChair();
            _sofa = factory.CreateSofa();
        }

        public void DescribeFurniture()
        {
            _chair.SitOn();
            _sofa.LieOn();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create Modern Furniture
            IFurnitureFactory modernFactory = new ModernFurnitureFactory();
            Client modernClient = new Client(modernFactory);
            modernClient.DescribeFurniture();
            // Output: Sitting on a modern chair.
            //         Lying on a modern sofa.

            // Create Victorian Furniture
            IFurnitureFactory victorianFactory = new VictorianFurnitureFactory();
            Client victorianClient = new Client(victorianFactory);
            victorianClient.DescribeFurniture();
            // Output: Sitting on a Victorian chair.
            //         Lying on a Victorian sofa.
        }
    }
}
