using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.PrototypePattern.GameExample
{
    /*Let's create an example using the Prototype pattern for game characters.
      In this scenario, we'll define a prototype for game characters and create concrete implementations 
      for specific types of characters. We'll then demonstrate cloning these characters to create new
      instances efficiently.

Step-by-Step Example
    1-Define the Prototype Interface:*/
    public interface ICharacterPrototype<T>
    {
        T Clone();
    }

    //2-Create Concrete Prototypes:
    public abstract class GameCharacter : ICharacterPrototype<GameCharacter>
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }

        protected GameCharacter(string name, int health, int attack, int defense)
        {
            Name = name;
            Health = health;
            Attack = attack;
            Defense = defense;
        }

        public abstract GameCharacter Clone();

        public override string ToString()
        {
            return $"Name: {Name}, Health: {Health}, Attack: {Attack}, Defense: {Defense}";
        }
    }

    //3-Create Specific Character Types:
    public class Warrior : GameCharacter
    {
        public Warrior(string name, int health, int attack, int defense)
            : base(name, health, attack, defense)
        {
        }

        public override GameCharacter Clone()
        {
            return new Warrior(Name, Health, Attack, Defense);
        }
    }

    public class Mage : GameCharacter
    {
        public Mage(string name, int health, int attack, int defense)
            : base(name, health, attack, defense)
        {
        }

        public override GameCharacter Clone()
        {
            return new Mage(Name, Health, Attack, Defense);
        }
    }
    //4Demonstrate Cloning Game Characters:
    class Program
    {
        static void Main(string[] args)
        {
            // Create prototypes for different types of game characters
            GameCharacter warriorPrototype = new Warrior("Warrior Prototype", 100, 20, 15);
            GameCharacter magePrototype = new Mage("Mage Prototype", 60, 25, 10);

            // Clone the warrior prototype to create new warrior characters
            GameCharacter warrior1 = warriorPrototype.Clone();
            GameCharacter warrior2 = warriorPrototype.Clone();

            // Clone the mage prototype to create new mage characters
            GameCharacter mage1 = magePrototype.Clone();
            GameCharacter mage2 = magePrototype.Clone();

            // Modify properties of cloned characters to demonstrate they are separate instances
            warrior1.Name = "Warrior 1";
            warrior2.Name = "Warrior 2";
            mage1.Name = "Mage 1";
            mage2.Name = "Mage 2";

            // Display the characters
            Console.WriteLine("Original Prototypes:");
            Console.WriteLine(warriorPrototype);
            Console.WriteLine(magePrototype);

            Console.WriteLine("\nCloned Characters:");
            Console.WriteLine(warrior1);
            Console.WriteLine(warrior2);
            Console.WriteLine(mage1);
            Console.WriteLine(mage2);

            Console.ReadKey();
        }
    }

}
/*Explanation
Prototype Interface (ICharacterPrototype<T>):

Declares a Clone method for creating copies of the object.
Base Class (GameCharacter):

Provides common properties and methods for all game characters.
Implements the ICharacterPrototype<GameCharacter> interface.
Defines an abstract Clone method to be implemented by subclasses.
Specific Character Classes (Warrior, Mage):

Inherit from GameCharacter.
Provide concrete implementations of the Clone method.
Each class can have specific attributes and behaviors if needed (not shown in this simple example).
Using the Prototype Pattern:

Create specific prototypes (warriorPrototype, magePrototype).
Clone these prototypes to create new instances (warrior1, warrior2, mage1, mage2).
Modify properties of the cloned instances to show they are independent copies.
Display both the original prototypes and the cloned characters to demonstrate the results.
This refined example clearly differentiates between the prototype (Warrior, Mage) and the base class 
(GameCharacter), making it easier to understand how the Prototype pattern is applied to create specific 
types of game characters.*/