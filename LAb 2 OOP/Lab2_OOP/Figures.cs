using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Lab2_OOP
{
    class Figures
    {
        List<IShape> figures = new List<IShape>();

        public IShape this[int i]
        {
            get { return figures[i]; }
        }
        public void AddShape(IShape shape)
        {
            figures.Add(shape);
        }
        public double AllAreaSumm()
        {
            double num = 0;
            foreach (IShape a in figures)
                num += a.CalcArea();
            return num;
        }
        public double AllPerimSumm()
        {
            double num = 0;
            foreach (IShape a in figures)
                num += a.CalcPerim();
            return num;
        }
        public double MaxArea()
        {
            double max = 0;
            foreach (IShape a in figures)
                if (a.CalcArea() > max)
                    max = a.CalcArea();
            return max;
        }
        public double MinArea()
        {
            double min = 1.7976931348623158e+308;
            foreach (IShape a in figures)
                if (a.CalcArea() < min)
                    min = a.CalcArea();
            return min;
        }
        public double MaxPerim()
        {
            double max = 0;
            foreach (IShape a in figures)
                if (a.CalcPerim() > max)
                    max = a.CalcPerim();
            return max;
        }
        public double MinPerim()
        {
            double min = 1.7976931348623158e+308;
            foreach (IShape a in figures)
                if (a.CalcPerim() < min)
                    min = a.CalcPerim();
            return min;
        }
    }
    interface IShape
    {
        double CalcArea();
        double CalcPerim();
    }
    class Square : IShape
    {
        double SideLength;
        public Square(Point p1, Point p2)
        {
            SideLength = Math.Abs(p1.X - p2.Y);
        }
        public double CalcArea()
        {
            return Math.Pow(SideLength, 2);
        }
        public double CalcPerim()
        {
            return SideLength * 4;
        }
    }
    class Rectangle : IShape
    {
        private double LeftSide;
        private double BottomSide;
        public Rectangle(Point p1, Point p2)
        {
            LeftSide = Math.Abs(p1.Y - p2.Y);
            BottomSide = Math.Abs(p1.X - p2.X);
        }
        public double CalcArea()
        {
            return LeftSide * BottomSide;
        }
        public double CalcPerim()
        {
            return (LeftSide * 2) + (BottomSide * 2);
        }
    }
    class Circle : IShape
    {
        private double Radius;
        public double CalcArea()
        {
            return 3.14 * Math.Pow(Radius, 2);
        }
        public double CalcPerim()
        {
            return 2 * Radius * 3.14;
        }
        public Circle(Point p1, Point p2)
        {
            Radius = Math.Abs(p1.X - p2.X);
        }
    }
    class Triangle : IShape
    {
        private int side_r_length, side_l_length, bottom_length;
        public double CalcArea()
        {
            return Math.Sqrt(CalcPerim() / 2 * (CalcPerim() / 2 - side_r_length) * (CalcPerim() / 2 - side_l_length) * (CalcPerim() / 2 - bottom_length));
        }
        public double CalcPerim()
        {
            return side_r_length + side_l_length + bottom_length;
        }
        public Triangle(Point p1, Point p2, Point p3)
        {
            side_r_length = Math.Abs(p3.Y - p2.Y);
            side_l_length = Math.Abs(p1.Y - p3.Y);
            bottom_length = Math.Abs(p1.X - p2.X);
        }
    }
}