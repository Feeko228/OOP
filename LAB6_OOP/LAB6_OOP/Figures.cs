using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;

namespace LAB6_OOP
{
    class Figures
    {
        List<IShape> figures = new List<IShape>();
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Environment.CurrentDirectory, "figures");
        public IShape this[int i]
        {
            get { return figures[i]; }
            set { figures[i] = value; }
        }
        public IShape LastShape()
        {
            return figures.Last();
        }
        public int LastShapeIndex()
        {
            return figures.Count;
        }
        public void RemoveShape(int index)
        {
            try
            {
                figures.RemoveAt(index);
            }
            catch
            {

            }
        }
        public int GetIndex(IShape shape)
        {
            int index = 0;
            foreach (IShape a in figures)

                if (shape == a)
                    index = figures.IndexOf(a);
            return index;
        }
        public Figures()
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
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
                if (a.CalcArea() > max)
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
    class MySquare : IShape
    {
        double SideLength;
        public MySquare(double side) { this.SideLength = side; }
        public double CalcArea() { return Math.Pow(SideLength, 2); }
        public double CalcPerim() { return SideLength * 4; }
        public override string ToString() { return $"Square ({SideLength}), P: {CalcPerim()}, S: {CalcArea()}"; }
    }
    [Serializable]
    class MyRectangle : IShape
    {
        private double LeftSide;
        private double BottomSide;

        public MyRectangle(double side1, double side2)
        {
            LeftSide = side1;
            BottomSide = side2;
        }
        public double CalcArea() { return LeftSide * BottomSide; }
        public double CalcPerim() { return (LeftSide * 2) + (BottomSide * 2); }
        public override string ToString() { return $"Rectangle ({LeftSide}, {BottomSide}), P: {CalcPerim()}, S: {CalcArea()}"; }
    }
    [Serializable]
    class MyCircle : IShape
    {
        private double Radius;
        public MyCircle(double rad) { Radius = rad; }
        public double CalcArea() { return 3.14 * Math.Pow(Radius, 2); }
        public double CalcPerim() { return 2 * Radius * 3.14; }
        public override string ToString() { return $"Circle ({Radius}), P: {CalcPerim()}, S: {CalcArea()}"; }
    }
    [Serializable]
    class MyTriangle : IShape
    {
        private double side_r_length, side_l_length, bottom_length;
        public double CalcArea()
        {
            return Math.Sqrt(CalcPerim() / 2 * (CalcPerim() / 2 - side_r_length) * (CalcPerim() / 2 - side_l_length) * (CalcPerim() / 2 - bottom_length));
        }
        public double CalcPerim() { return side_r_length + side_l_length + bottom_length; }
        public MyTriangle(double side1, double side2, double side3)
        {
            side_r_length = side1;
            side_l_length = side2;
            bottom_length = side3;
        }
        public override string ToString() { return $"Triangle ({side_r_length}, {side_l_length}, {bottom_length}) P: {CalcPerim()}, S: {CalcArea()}"; }
    }
}
