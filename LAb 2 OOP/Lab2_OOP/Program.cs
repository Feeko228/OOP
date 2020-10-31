using System;
using System.Collections.Generic;
using System.Drawing;

namespace Lab2_OOP
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

            Console.WriteLine("Периметр Всех фигур: " + figures.AllPerimSumm());
            Console.WriteLine("Площадь Всех фигур: " + figures.AllAreaSumm());

            Console.WriteLine("периметр первой фигуры: " + figures[0].CalcPerim() + " площадь первой фигуры: " + figures[0].CalcArea());
            Console.WriteLine("периметр второй фигуры: " + figures[1].CalcPerim() + " площадь второй фигуры: " + figures[1].CalcArea());
            Console.WriteLine("периметр третьей фигуры: " + figures[2].CalcPerim() + " площадь третьей фигуры: " + figures[2].CalcArea());
            Console.WriteLine("периметр четвертой фигуры: " + figures[3].CalcPerim() + " площадь четвертой фигуры: " + figures[3].CalcArea());

            Console.WriteLine("Максимальная площадь: " + figures.MaxArea());
            Console.WriteLine("Минимальная площадь: " + figures.MinArea());
            Console.WriteLine("Максимальный периметр: " + figures.MaxPerim());
            Console.WriteLine("Минимальный периметр: " + figures.MinPerim());
        }
    }
}
