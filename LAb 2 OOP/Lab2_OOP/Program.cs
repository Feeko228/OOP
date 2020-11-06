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

            figures.AddShape(new Square(new Point(0, 0), new Point(0, 10)));//координаты углов одной из сторон
            figures.AddShape(new Rectangle(new Point(0, 0), new Point(5, 10)));//координаты нижнего левого и правого верхеного углов
            figures.AddShape(new Circle(new Point(0, 0), new Point(6, 0)));
            figures.AddShape(new Triangle(new Point(0, 0), new Point(6, 0), new Point(3, 5)));

            Console.WriteLine("Периметр Всех фигур: " + figures.AllPerimSumm());
            Console.WriteLine("Площадь Всех фигур: " + figures.AllAreaSumm());

            Console.WriteLine(figures[0].ToString());
            Console.WriteLine(figures[1].ToString());
            Console.WriteLine(figures[2].ToString());
            Console.WriteLine(figures[3].ToString());

            Console.WriteLine("Фигура с максимальной площадью: " + figures.MaxArea().ToString());
            Console.WriteLine("Фигура с минимальной площадью: " + figures.MinArea().ToString());
            Console.WriteLine("Фигура с максимальным периметром: " + figures.MaxPerim().ToString());
            Console.WriteLine("Фигура с минимальным периметром: " + figures.MinPerim().ToString());
        }
    }
}
