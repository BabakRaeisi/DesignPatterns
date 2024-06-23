using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.OppositeOfAbstractFactory
{
    /*The opposite scenario of using the Abstract Factory pattern would be a situation where the system does not require
     * flexibility in creating families of related or dependent objects and where the creation process is straightforward
     * and does not involve multiple related objects. In such cases, the creation process can be tightly coupled to the specific
     * classes needed, and simplicity and directness are prioritized over flexibility and scalability.

Opposite Scenario: Direct Object Instantiation

Characteristics
Tight Coupling: The system is tightly coupled to the specific classes it uses, directly instantiating concrete
classes without the need for factories.

Simplicity: The object creation process is straightforward and does not require the abstraction or flexibility provided by
factory patterns.

Low Overhead: There is minimal overhead in terms of code complexity and maintenance since 
the system directly creates and uses the objects it needs.

No Families of Objects: The system does not involve creating multiple related objects that need to be compatible with each other.

Example Scenario: Simple Calculator
Consider a simple calculator application that performs basic arithmetic operations.
    Each operation (addition, subtraction, multiplication, division) is handled by a specific class.
    There is no need to create families of related objects, and the object creation process can be direct and straightforward.

Direct Implementation
Operation Interface: IOperation
Concrete Operation Classes: Addition, Subtraction, Multiplication, Division
Client: Directly uses the concrete classes
Implementation
Define the Operation Interface*/
    public interface IOperation
    {
        double Calculate(double a, double b);
    }
    /*Implement Concrete Operation Classes*/
    public class Addition : IOperation
    {
        public double Calculate(double a, double b)
        {
            return a + b;
        }
    }

    public class Subtraction : IOperation
    {
        public double Calculate(double a, double b)
        {
            return a - b;
        }
    }

    public class Multiplication : IOperation
    {
        public double Calculate(double a, double b)
        {
            return a * b;
        }
    }

    public class Division : IOperation
    {
        public double Calculate(double a, double b)
        {
            if (b == 0) throw new DivideByZeroException();
            return a / b;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IOperation addition = new Addition();
            IOperation subtraction = new Subtraction();
            IOperation multiplication = new Multiplication();
            IOperation division = new Division();

            double a = 10;
            double b = 5;

            Console.WriteLine($"Addition: {addition.Calculate(a, b)}");         // Output: 15
            Console.WriteLine($"Subtraction: {subtraction.Calculate(a, b)}");   // Output: 5
            Console.WriteLine($"Multiplication: {multiplication.Calculate(a, b)}"); // Output: 50
            Console.WriteLine($"Division: {division.Calculate(a, b)}");         // Output: 2
        }
    }
}
