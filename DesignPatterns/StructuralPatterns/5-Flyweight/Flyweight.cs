using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.Flyweight
{
    /*The Flyweight Design Pattern is a structural pattern that is used to minimize memory usage
     * or computational expenses by sharing as much as possible with similar objects.
     * It is particularly useful when a large number of similar objects are required.
     * The Flyweight pattern achieves this by storing common properties externally
     * and passing them in as required.

    Key Concepts

    Intrinsic State: This state is shared among all objects and stored in the flyweight.
    Extrinsic State: This state is unique to each object and stored outside the flyweight.
    Example
    Suppose we are developing a drawing application where we need to create a large number 
    of shapes (e.g., circles) with various colors and sizes. Instead of creating separate
    objects for each shape, we can use the Flyweight pattern to share the common properties 
    (intrinsic state) among the shapes.

    Flyweight Interface*/
    public interface IShape
    {
        void Draw(int x, int y);
    }
    /*Concrete Flyweight Class*/
    public class Circle : IShape
    {
        private readonly string _color; // Intrinsic state

        public Circle(string color)
        {
            _color = color;
        }

        public void Draw(int x, int y) // Extrinsic state
        {
            Console.WriteLine($"Drawing a {_color} circle at ({x}, {y}).");
        }
    }
    /*Flyweight Factory*/
    public class ShapeFactory
    {
        private readonly Dictionary<string, IShape> _shapes = new Dictionary<string, IShape>();

        public IShape GetShape(string color)
        {
            if (!_shapes.ContainsKey(color))
            {
                _shapes[color] = new Circle(color);
                Console.WriteLine($"Creating a circle of color: {color}");
            }

            return _shapes[color];
        }
    }
    /*Client Code
    */
    public class Program
    {
        public static void Main()
        {
            var factory = new ShapeFactory();

            var redCircle1 = factory.GetShape("Red");
            redCircle1.Draw(10, 10);

            var redCircle2 = factory.GetShape("Red");
            redCircle2.Draw(20, 20);

            var blueCircle = factory.GetShape("Blue");
            blueCircle.Draw(30, 30);

            var redCircle3 = factory.GetShape("Red");
            redCircle3.Draw(40, 40);
        }
    }


}
