using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2_OOP
{
    class Figures
    {
        protected List<Figures> figures = new List<Figures>();
        protected double[] xy1, xy2, xy3, xy4 = new double[2];
        protected double lenth, hight, P, S, R, p_sum = 0, s_sum = 0, side_r_length, side_l_length, bottom_length;

        public string name { get; private set; }

        public void Add(Figures figure)//adding instances of shapes to the list of shapes
        {
            figures.Add(figure);
        }
        public string ShowP_S()//displaying information about the shapes in the list
        {
            string a = null;
            for (int i = 0; i < figures.Count; i++)
                a += figures[i].name + ": " + "perimeter = " + figures[i].P + " square = " + figures[i].S + '\n';
            return a;
        }
        public string P_S_Sum()//total area and perimeter of all shapes
        {
            string a = null;
            for (int i = 0; i < figures.Count; i++)
                p_sum += figures[i].P;
            for (int i = 0; i < figures.Count; i++)
                s_sum += figures[i].S;
            a = "sum of perimeters of figures: " + p_sum + "\n" + "sum of perimeters of figures: " + s_sum + '\n';
            return a;
        }
        public string PS_max()//search for the largest areas and perimeters
        {
            string a = null, nameP = null, nameS = null;
            double maxP = 0;
            double maxS = 0;
            for (int i = 0; i < figures.Count; i++)
            {
                if (figures[i].P > maxP)
                {
                    maxP = figures[i].P;
                    nameP = figures[i].name;
                }
            }
            for (int i = 0; i < figures.Count; i++)
            {
                if (figures[i].S > maxS)
                {
                    maxS = figures[i].S;
                    nameS = figures[i].name;
                }
            }
            a += nameP + " has the largest perimeter (" + maxP + ")" + '\n';
            a += nameS + " has the largest area (" + maxS + ")" + '\n';
            return a;
        }
        public string PS_min()//finding the smallest areas and perimeters
        {
            string a = null, nameP = null, nameS = null;
            double minP = 1.5E45;
            double minS = 1.5E45;
            for (int i = 0; i < figures.Count; i++)
            {
                if (figures[i].P < minP)
                {
                    minP = figures[i].P;
                    nameP = figures[i].name;
                }
            }
            for (int i = 0; i < figures.Count; i++)
            {
                if (figures[i].S < minS)
                {
                    minS = figures[i].S;
                    nameS = figures[i].name;
                }
            }
            a += nameP + " has the smallest perimeter (" + minP + ")" + '\n';
            a += nameS + " has the smallest area (" + minS + ")" + '\n';
            return a;
        }

        class Square
        {
            public Square(double[] xy1, double[] xy2, double[] xy3, double[] xy4, string name)
            {
                this.name = name;
                this.xy1 = xy1;
                this.xy2 = xy2;
                this.xy3 = xy3;
                this.xy4 = xy4;
                this.lenth = Math.Abs(this.xy1[0] - this.xy4[0]);
                this.hight = Math.Abs(this.xy1[1] - this.xy2[1]);
                if (this.lenth != this.hight)
                    throw new IndexOutOfRangeException("NotEqualSidesEx");
                this.P = this.lenth * 4;
                this.S = this.lenth * this.hight;
            }
        }
        class rectangle
        {
            private string name = null;
            private string name = null;
            public rectangle(double[] xy1, double[] xy2, double[] xy3, double[] xy4, string name)
            {
                this.name = name;
                this.xy1 = xy1;
                this.xy2 = xy2;
                this.xy3 = xy3;
                this.xy4 = xy4;
                this.lenth = Math.Abs(this.xy1[0] - this.xy4[0]);
                this.hight = Math.Abs(this.xy1[1] - this.xy2[1]);
                this.P = this.lenth * 2 + this.hight * 2;
                this.S = this.lenth * this.hight;
            }
        }
        class circle
        {
            public circle(double[] xy1, double[] xy2, string name)
            {
                this.name = name;
                this.xy1 = xy1;
                this.xy2 = xy2;
                this.R = Math.Abs(xy1[0] - this.xy2[0]);
                this.P = 2 * this.R * 3.14;
                this.S = 3.14 * Math.Pow(this.R, 2);
            }
        }
        class triangle
        {
            public triangle(double[] xy1, double[] xy2, double[] xy3, string name)
            {
                this.name = name;
                this.xy1 = xy1;
                this.xy2 = xy2;
                this.xy3 = xy3;
                this.side_r_length = Math.Abs(Math.Sqrt(Math.Pow((xy2[0] - xy1[0]), 2) + Math.Pow((xy2[1] - xy1[1]), 2)));
                this.side_l_length = Math.Abs(Math.Sqrt(Math.Pow((xy3[0] - xy2[0]), 2) + Math.Pow((xy3[1] - xy2[1]), 2)));
                this.bottom_length = Math.Abs(Math.Sqrt(Math.Pow((xy3[0] - xy1[0]), 2) + Math.Pow((xy3[1] - xy1[1]), 2)));
                this.P = Math.Round((this.side_r_length + this.side_l_length + this.bottom_length) / 2, 2);
                this.S = Math.Round(Math.Sqrt(this.P * (this.P - this.side_r_length) * (this.P - this.side_l_length) * (this.P - this.bottom_length)), 2);
            }
        }
    }
}