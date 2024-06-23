using DesignPatterns.CreationalPatterns.FactoryMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.PrototypePattern
{
    /*The Prototype pattern is a creational design pattern used to create new objects by
     * copying an existing object, known as the prototype. 
     * This pattern is useful when the process of creating a new object is expensive or complex.
     * Instead of constructing an object from scratch, a new object is created by copying the prototype.

Here's a simple example in C# demonstrating the Prototype pattern:

Step-by-Step Example
Create the Prototype Interface:

1-Define an interface with a method for cloning objects.*/
    public interface IPrototype<T>
    {
        T Clone();
    }
    /*2-Implement the Prototype Interface:
    Create a class that implements the IPrototype interface.
    This class should provide the actual implementation for the Clone method.*/
    public class Person : IPrototype<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        // Clone method to create a copy of the current object
        public Person Clone()
        {
            return new Person(Name, Age);
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
    /* Use the Prototype Pattern:
     Demonstrate how to use the Clone method to create copies of an object.*/
    class Program
    {
        static void Main(string[] args)
        {
            // Create an original person object
            Person originalPerson = new Person("John Doe", 30);
            Console.WriteLine("Original Person: " + originalPerson);

            // Clone the original person
            Person clonedPerson = originalPerson.Clone();
            Console.WriteLine("Cloned Person: " + clonedPerson);

            // Modify the cloned person's properties
            clonedPerson.Name = "Jane Doe";
            clonedPerson.Age = 25;

            // Display the modified cloned person and the original person
            Console.WriteLine("Modified Cloned Person: " + clonedPerson);
            Console.WriteLine("Original Person after clone modification: " + originalPerson);

            Console.ReadKey();
        }
    }

}

/*Explanation
Prototype Interface (IPrototype<T>):
This interface declares a Clone method that will be used to create a copy of the object.

Concrete Prototype Class (Person):
The Person class implements the IPrototype<Person> interface and
provides the Clone method to return a new Person object with the same property values.

Using the Prototype Pattern:

An originalPerson object is created.
The originalPerson is cloned using the Clone method, resulting in a clonedPerson object.
The properties of the clonedPerson are modified to demonstrate that the original object remains unchanged.
This example demonstrates the Prototype pattern's ability to create a new object by copying an existing one,
thereby reducing the cost and complexity of object creation.*/
