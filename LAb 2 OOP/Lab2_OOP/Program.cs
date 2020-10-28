using System;
using System.Collections.Generic;

namespace Lab2_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] xy1 = { 0, 0 };
            double[] xy2 = { 0, 2 };
            double[] xy3 = { 2, 2 };
            double[] xy4 = { 2, 0 };

            double[] xy5 = { 0, 0 };
            double[] xy6 = { 0, 1 };
            double[] xy7 = { 10, 1 };
            double[] xy8 = { 10, 0 };

            double[] xy9 = { 0, 0 };
            double[] xy10 = { 3, 3 };
            double[] xy11 = { 5, 0 };

            double[] xy12 = { 0, 0 };
            double[] xy13 = { 5, 5 };
            double[] xy14 = { 10, 0 };

            double[] xy15 = { 0, 0 };
            double[] xy16 = { 0, 5 };
            double[] xy17 = { 5, 5 };
            double[] xy18 = { 5, 0 };

            double[] xy19 = { 0, 0 };
            double[] xy20 = { 0, 2 };
            double[] xy21 = { 3, 2 };
            double[] xy22 = { 3, 0 };

            double[] xy23 = { 0, 0 };
            double[] xy24 = { 2, 0 };

            double[] xy25 = { 0, 0 };
            double[] xy26 = { 1.5, 0 };

            Figures figures = new Figures();

            figures.Add(new Kvadrat(xy1, xy2, xy3, xy4, "квадрат 1"));
            figures.Add(new Kvadrat(xy15, xy16, xy17, xy18, "квадрат 2"));
            figures.Add(new rectangle(xy5, xy6, xy7, xy8, "прямоугольник 1"));
            figures.Add(new rectangle(xy19, xy20, xy21, xy22, "прямоугольник 2"));
            figures.Add(new Krug(xy23, xy24, "круг 1"));
            figures.Add(new Krug(xy25, xy26, "круг 2"));
            figures.Add(new triangle(xy9, xy10, xy11, "треугольник 1"));
            figures.Add(new triangle(xy12, xy13, xy14, "треугольник 2"));

            Console.WriteLine(figures.ShowP_S());
            Console.WriteLine(figures.P_S_Sum());
            Console.WriteLine(figures.PS_max());
            Console.WriteLine(figures.PS_min());
        }
    }
}
