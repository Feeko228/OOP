using System.Drawing;
using System;

namespace OOP4_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Figures figures = new Figures();

            figures.AddShape(new Square(new Point(0, 0), new Point(0, 10)));
            figures.AddShape(new Rectangle(new Point(0, 0), new Point(5, 10)));
            figures.AddShape(new Circle(new Point(0, 0), new Point(6, 0)));
            figures.AddShape(new Triangle(new Point(0, 0), new Point(6, 0), new Point(3, 5)));

            ShapeAccumulator acc = new ShapeAccumulator();
            //acc.Add(figures[0]);
            acc.AddAll(figures.RetShape());

            Console.WriteLine(acc.getMaxArea().ToString());
            Console.WriteLine(acc.getMaxPerim().ToString());
            Console.WriteLine(acc.getMinArea().ToString());
            Console.WriteLine(acc.getMinPerim().ToString());
        }
    }
}
