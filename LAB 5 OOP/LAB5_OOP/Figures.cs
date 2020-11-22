using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab2_OOP
{
    class Figures
    {
        List<IShape> figures = new List<IShape>();
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Environment.CurrentDirectory, "figures");
        public Figures()
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
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
            double max = 0;
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
            double min = 1.7976931348623158e+308;
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
            double max = 0;
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
            double min = 1.7976931348623158e+308;
            IShape found = null;
            foreach (IShape a in figures)
                if (a.CalcPerim() < min)
                {
                    min = a.CalcPerim();
                    found = a;
                }
            return found;
        }
        public void Save()
        {
            using (FileStream fs = new FileStream(path + $"/figures.shape", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, figures);
            }
        }
        public void Load()
        {
            string[] fileEntries = Directory.GetFiles(path, "*.shape");
            foreach (string item in fileEntries)
            {

                using (FileStream fs = new FileStream(item, FileMode.OpenOrCreate))
                {
                    List<IShape> fig = (List<IShape>)formatter.Deserialize(fs);
                    figures.AddRange(fig);
                }
            }
        }
    }
    interface IShape
    {
        double CalcArea();
        double CalcPerim();
        string ToString();
    }
    [Serializable]
    class Square : IShape
    {
        private double SideLength;
        public Square(Point p1, Point p2) { SideLength = Math.Abs(p1.Y - p2.Y); }
        public double CalcArea() { return Math.Pow(SideLength, 2); }
        public double CalcPerim() { return SideLength * 4; }
        public override string ToString() { return $"Perimeter of Square is {CalcPerim()} and Area is {CalcArea()}"; }
    }
    [Serializable]
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
    [Serializable]
    class Circle : IShape
    {
        private double Radius;
        public Circle(Point p1, Point p2) { Radius = Math.Abs(p1.X - p2.X); }
        public double CalcArea() { return 3.14 * Math.Pow(Radius, 2); }
        public double CalcPerim() { return 2 * Radius * 3.14; }
        public override string ToString() { return $"Perimeter of Circle is {CalcPerim()} and Area is {CalcArea()}"; }

    }
    [Serializable]
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
}