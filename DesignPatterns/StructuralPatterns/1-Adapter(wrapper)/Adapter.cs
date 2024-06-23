using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.Adapter_wrapper
{
    /*The Adapter (or Wrapper) pattern is a structural design pattern that allows
      objects with incompatible interfaces to work together.
      This pattern involves a single class which is responsible to
      join functionalities of independent or incompatible interfaces.
      In this way, the Adapter pattern integrates the target class with the existing system.

 Here's a breakdown of how the Adapter pattern works in C#:

 Components of the Adapter Pattern

 Target: The interface that the client expects to work with.
 Client: The class that uses the target interface.
 Adaptee: The existing class that needs to be adapted.
 Adapter: The class that implements the target interface and adapts the Adaptee to the Target interface.
 Example
 Consider a scenario where we have an existing class OldSystem that we want to adapt to a new interface INewSystem.

 1. Target Interface*/


    public interface INewSystem
    {
        void ProcessData(string data);
    }
    /*2. Adaptee Class*/
    public class OldSystem
    {
        public void Execute(string data)
        {
            Console.WriteLine($"Processing data: {data}");
        }
    }
    /*3. Adapter Class*/
    public class Adapter : INewSystem
    {
        private readonly OldSystem _oldSystem;

        public Adapter(OldSystem oldSystem)
        {
            _oldSystem = oldSystem;
        }

        public void ProcessData(string data)
        {
            // Adapt the method call
            _oldSystem.Execute(data);
        }
    }
    /*4. Client Code*/
    public class Client
    {
        private readonly INewSystem _newSystem;

        public Client(INewSystem newSystem)
        {
            _newSystem = newSystem;
        }

        public void Run(string data)
        {
            _newSystem.ProcessData(data);
        }
    }
    /*5. Usage*/
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the old system
            OldSystem oldSystem = new OldSystem();

            // Create an adapter for the old system
            INewSystem adapter = new Adapter(oldSystem);

            // Create a client with the adapter
            Client client = new Client(adapter);

            // Run the client with some data
            client.Run("Sample Data");
        }
    }
    /*Explanation
    The INewSystem interface defines the new method ProcessData that the client expects.
    The OldSystem class has an existing method Execute that we need to adapt.
    The Adapter class implements the INewSystem interface and translates the ProcessData 
    call to the Execute call on the OldSystem instance.
    The Client class uses the INewSystem interface to interact with the system.
    In the Main method, we create an instance of OldSystem, wrap it with an Adapter,
    and then use it through the Client.
    This way, the adapter pattern allows the Client to work with the OldSystem through
    the INewSystem interface without modifying the existing OldSystem class.*/
}
