using System;
using System.Collections.Generic;

namespace Lab2_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] xy1 = { 0, 0 };
            int[] xy2 = { 0, 1 };
            int[] xy3 = { 1, 1 };
            int[] xy4 = { 1, 0 };

            int[] xy5 = { 0, 0 };
            int[] xy6 = { 0, 1 };
            int[] xy7 = { 10, 1 };
            int[] xy8 = { 10, 0 };

            int[] xy9 = { 0, 0 };
            int[] xy10 = { 3, 3 };
            int[] xy11 = { 5, 3 };

            int[] xy12 = { 0, 0 };
            int[] xy13 = { 5, 5 };
            int[] xy14 = { 10, 5 };

            int[] xy15 = { 0, 0 };
            int[] xy16 = { 0, 5 };
            int[] xy17 = { 5, 5 };
            int[] xy18 = { 5, 0 };

            int[] xy19 = { 0, 0 };
            int[] xy20 = { 0, 2 };
            int[] xy21 = { 3, 2 };
            int[] xy22 = { 3, 0 };


            Figures figures = new Figures();

            figures.Add(new Figures.Kvadrat(xy1, xy2, xy3, xy4, "квадрат 1"));
            figures.Add(new Figures.Kvadrat(xy15, xy16, xy17, xy18, "квадрат 2"));
            figures.Add(new Figures.rectangle(xy5, xy6, xy7, xy8, "прямоугольник 1"));
            figures.Add(new Figures.rectangle(xy19, xy20, xy21, xy22, "прямоугольник 2"));
            figures.Add(new Figures.Krug(2, "круг 1"));
            figures.Add(new Figures.Krug(1.5, "круг 2"));
            figures.Add(new Figures.triangle(xy9, xy10, xy11, "треугольник 1"));
            figures.Add(new Figures.triangle(xy12, xy13, xy14, "треугольник 2"));


            figures.ShowP_S();
            Console.WriteLine('\n');
            figures.P_S_Sum();
            Console.WriteLine('\n');
            figures.SuperFig();
        }
    }
}
