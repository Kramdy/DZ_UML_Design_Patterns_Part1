using System;

namespace FactoryShapes
{
    internal interface IShape { void Draw(); }
    internal class Circle : IShape { public void Draw() { Console.WriteLine("Drawing a circle"); } }
    internal class Rectangle : IShape { public void Draw() { Console.WriteLine("Drawing a rectangle"); } }
    internal abstract class ShapeFactory { public abstract IShape CreateShape(); }
    internal class CircleFactory : ShapeFactory { public override IShape CreateShape() { return new Circle(); } }
    internal class RectangleFactory : ShapeFactory { public override IShape CreateShape() { return new Rectangle(); } }
    internal class Program
    {
        private static void Main()
        {
            // Задание 2. Создайте IShape с методом Draw, классы Circle и Rectangle.
            // Создайте абстрактную ShapeFactory с CreateShape и конкретные фабрики
            // CircleFactory, RectangleFactory, создающие соответствующие фигуры.
            ShapeFactory circleFactory = new CircleFactory(); IShape circle = circleFactory.CreateShape(); circle.Draw();
            ShapeFactory rectangleFactory = new RectangleFactory(); IShape rectangle = rectangleFactory.CreateShape(); rectangle.Draw();
            Console.ReadKey();
        }
    }
}
