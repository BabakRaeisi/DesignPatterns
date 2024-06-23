using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns
{
    public class SimpleFactory
    {
        public IProduct CreateProduct(string type)
        {
            switch (type)
            {
                case "A":
                    return new ProductA();
                case "B":
                    return new ProductB();
                default:
                    throw new ArgumentException("Invalid type");
            }
        }
    }

     

    public class ProductA : IProduct
    {
        public void DoSomething()
        {
            Console.WriteLine("ProductA doing something");
        }
    }

    public class ProductB : IProduct
    {
        public void DoSomething()
        {
            Console.WriteLine("ProductB doing something");
        }
    }
}
