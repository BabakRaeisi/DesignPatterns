using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.Composite
{
    /*The Composite pattern is a structural design pattern that allows
     * you to compose objects into tree structures to represent part-whole hierarchies.
     * It lets clients treat individual objects and compositions of objects uniformly.

    Example: Building a Graphic Drawing Application
    In this example, we will create a simple graphic drawing application where
    a graphic can be either a simple shape (like a circle or a square) or a
    composite of multiple graphics.

    Step 1: Define the Component Interface*/

    public interface IGraphic
    {
        void Draw();
        void Add(IGraphic graphic);
        void Remove(IGraphic graphic);
        IGraphic GetChild(int index);
    }/*
    Step 2: Implement Leaf Classes*/
    public class Circle : IGraphic
    {
        public void Draw()
        {
            Console.WriteLine("Drawing a Circle");
        }

        public void Add(IGraphic graphic)
        {
            throw new NotImplementedException();
        }

        public void Remove(IGraphic graphic)
        {
            throw new NotImplementedException();
        }

        public IGraphic GetChild(int index)
        {
            throw new NotImplementedException();
        }
    }

    public class Square : IGraphic
    {
        public void Draw()
        {
            Console.WriteLine("Drawing a Square");
        }

        public void Add(IGraphic graphic)
        {
            throw new NotImplementedException();
        }

        public void Remove(IGraphic graphic)
        {
            throw new NotImplementedException();
        }

        public IGraphic GetChild(int index)
        {
            throw new NotImplementedException();
        }
    }
    /*Step 3: Implement Composite Class*/

public class CompositeGraphic : IGraphic
    {
        private readonly List<IGraphic> _graphics = new List<IGraphic>();

        public void Draw()
        {
            foreach (var graphic in _graphics)
            {
                graphic.Draw();
            }
        }

        public void Add(IGraphic graphic)
        {
            _graphics.Add(graphic);
        }

        public void Remove(IGraphic graphic)
        {
            _graphics.Remove(graphic);
        }

        public IGraphic GetChild(int index)
        {
            return _graphics[index];
        }
    }

    /*Step 4: Client Code*/
    class Program
    {
        static void Main(string[] args)
        {
            // Creating simple leaf objects
            IGraphic circle1 = new Circle();
            IGraphic square1 = new Square();
            IGraphic circle2 = new Circle();

            // Creating a composite object
            CompositeGraphic composite = new CompositeGraphic();
            composite.Add(circle1);
            composite.Add(square1);
            composite.Add(circle2);

            // Creating another composite object and adding previous composite to it
            CompositeGraphic composite2 = new CompositeGraphic();
            composite2.Add(composite);

            // Drawing all graphics
            composite2.Draw();
        }
    }

  /*CompositeGraphic (composite2)
    └── CompositeGraphic (composite1)
        ├── Circle (circle1)
        ├── Square (square1)
        └── Circle (circle2)
    */
}
