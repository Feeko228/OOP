using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace OOP4_Lab
{
    class Figures
    {
        List<IShape> figures = new List<IShape>();
        public List<IShape> RetShape()
        {
            return figures;
        }
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
        public IShape MaxArea()
        {
            double max = Double.MinValue;
            IShape found = null;
            foreach (IShape a in figures)
                if (a.CalcPerim() > max)
                {
                    max = a.CalcArea();
                    found = a;
                }
            return found;
        }
        public IShape MinArea()
        {
            double min = Double.MaxValue;
            IShape found = null;
            foreach (IShape a in figures)
                if (a.CalcPerim() < min)
                {
                    min = a.CalcArea();
                    found = a;
                }
            return found;
        }
        public IShape MaxPerim()
        {
            double max = Double.MinValue;
            IShape found = null;
            foreach (IShape a in figures)
                if (a.CalcPerim() > max)
                {
                    max = a.CalcPerim();
                    found = a;
                }
            return found;
        }
        public IShape MinPerim()
        {
            double min = Double.MaxValue;
            IShape found = null;
            foreach (IShape a in figures)
                if (a.CalcPerim() < min)
                {
                    min = a.CalcPerim();
                    found = a;
                }
            return found;
        }
    }
    interface IShape
    {
        double CalcArea();
        double CalcPerim();
        string ToString();
    }
    class Square : IShape
    {
        double SideLength;
        public Square(Point p1, Point p2) { SideLength = Math.Abs(p1.Y - p2.Y); }
        public double CalcArea() { return Math.Pow(SideLength, 2); }
        public double CalcPerim() { return SideLength * 4; }
        public override string ToString() { return $"Perimeter of Square is {CalcPerim()} and Area is {CalcArea()}"; }
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
        public double CalcArea() { return LeftSide * BottomSide; }
        public double CalcPerim() { return (LeftSide * 2) + (BottomSide * 2); }
        public override string ToString() { return $"Perimeter of Rectangle is {CalcPerim()} and Area is {CalcArea()}"; }
    }
    class Circle : IShape
    {
        private double Radius;
        public Circle(Point p1, Point p2) { Radius = Math.Abs(p1.X - p2.X); }
        public double CalcArea() { return 3.14 * Math.Pow(Radius, 2); }
        public double CalcPerim() { return 2 * Radius * 3.14; }
        public override string ToString() { return $"Perimeter of Circle is {CalcPerim()} and Area is {CalcArea()}"; }

    }
    class Triangle : IShape
    {
        private int side_r_length, side_l_length, bottom_length;
        public double CalcArea()
        {
            return Math.Sqrt(CalcPerim() / 2 * (CalcPerim() / 2 - side_r_length) * (CalcPerim() / 2 - side_l_length) * (CalcPerim() / 2 - bottom_length));
        }
        public double CalcPerim() { return side_r_length + side_l_length + bottom_length; }
        public Triangle(Point p1, Point p2, Point p3)
        {
            side_r_length = Math.Abs(p3.Y - p2.Y);
            side_l_length = Math.Abs(p1.Y - p3.Y);
            bottom_length = Math.Abs(p1.X - p2.X);
        }
        public override string ToString() { return $"Perimeter of Triangle is {CalcPerim()} and Area is {CalcArea()}"; }

    }
    class ShapeAccumulator
    {
        List<IShape> shapes = new List<IShape>();
        IShape MinArea, MaxArea, MinPerim, MaxPerim;
        double TotalArea, TotalPerim;
        public ShapeAccumulator()
        {
            MinArea = null;
            MaxArea = null;
            MinPerim = null;
            MaxPerim = null;
            TotalArea = 0;
            TotalPerim = 0;
        }
        public void Add(IShape shape)
        {
            shapes.Add(shape);
            TotalArea += shape.CalcArea();
            TotalPerim += shape.CalcPerim();
            if (shapes.Count == 1)
            {
                MinArea = shape;
                MaxArea = shape;
                MinPerim = shape;
                MaxPerim = shape;
                return;
            }
        }
        public void AddAll(List<IShape> add)
        {
            for (int i = 0; i < add.Count; i++)
                Add(add[i]);
        }
        public IShape getMinPerim()
        {
            double min = Double.MaxValue;
            foreach (IShape a in shapes)
                if (a.CalcPerim() < min)
                {
                    min = a.CalcPerim();
                    MinPerim = a;
                }
            return MinPerim;
        }
        public IShape getMinArea()
        {
            double min = Double.MaxValue;
            foreach (IShape a in shapes)
                if (a.CalcArea() < min)
                {
                    min = a.CalcArea();
                    MinArea = a;
                }
            return MinArea;
        }
        public IShape getMaxPerim()
        {
            double max = Double.MinValue;
            foreach (IShape a in shapes)
                if (a.CalcPerim() > max)
                {
                    max = a.CalcPerim();
                    MaxPerim = a;
                }
            return MaxPerim;
        }
        public IShape getMaxArea()
        {
            double max = Double.MinValue;
            foreach (IShape a in shapes)
                if (a.CalcArea() > max)
                {
                    max = a.CalcArea();
                    MaxArea = a;
                }
            return MaxArea;
        }
        public double GetTotalArea()
        {
            return TotalArea;
        }
        public double GetTotalPerimeter()
        {
            return TotalPerim;
        }
        public int Count()
        {
            return shapes.Count;
        }
        public IShape this[int i]
        {
            get { return shapes[i]; }
        }
    }
}