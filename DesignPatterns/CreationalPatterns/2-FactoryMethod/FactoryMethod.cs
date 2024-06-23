using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Factory Method Pattern
The Factory Method pattern defines an interface for creating an object but allows subclasses
to alter the type of objects that will be created. This pattern is useful when a class cannot
anticipate the class of objects it must create or when a class wants its subclasses to specify
the objects it creates.

Key Components
Product: An interface or abstract class defining the type of objects the factory method creates.
ConcreteProduct: A class that implements the Product interface.

Creator: An abstract class or interface declaring the factory method, which returns a Product type.

ConcreteCreator: A class that overrides the factory method to return an instance of a ConcreteProduct.*/
namespace DesignPatterns.CreationalPatterns.FactoryMethod
{

    public abstract class Creator
    {
        public abstract IProduct FactoryMethod();

        public void AnOperation()
        {
            var product = FactoryMethod();
            product.DoSomething();
        }
    }

    public class ConcreteCreatorA : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ProductA();
        }
    }

    public class ConcreteCreatorB : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ProductB();
        }
    }
  
}

