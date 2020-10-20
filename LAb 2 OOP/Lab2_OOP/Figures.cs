using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2_OOP
{
    class Figures
    {
        protected List<Figures> figures = new List<Figures>();
        protected int[] xy1, xy2, xy3, xy4 = new int[2];
        protected double lenth, hight, P, S, R, p_sum = 0, s_sum = 0, side_r_length, side_l_length, bottom_length;
        protected string name;
        public void Add(Figures figure)//добавление экземпляров фигур в список фигур
        {
            figures.Add(figure);
        }
        public string ShowP_S()//выввод инфы о фигурах в списке
        {
            string a = null;
            for (int i = 0; i < figures.Count; i++)
                a += figures[i].name + ": " + "периметр = " + figures[i].P + " площадь = " + figures[i].S + '\n';
            return a;
        }
        public string P_S_Sum()//общая площадь и периметр всех фигур
        {
            string a = null;
            for (int i = 0; i < figures.Count; i++)
                p_sum += figures[i].P;
            for (int i = 0; i < figures.Count; i++)
                s_sum += figures[i].S;
            a = "сумма периметров фигур: " + p_sum + "\n" + "сумма площадей фигур: " + s_sum + '\n';
            return a;
        }
        public string SuperFig()//поиск фигуры с макс и мин пл и пер
        {
            string a = null; ;
            string name_p_max = "u", name_s_max = "u";
            string name_p_min = "u", name_s_min = "u";
            double max_P = 0, max_S = 0;
            double min_P = 1.5E45, min_S = 1.5E45;

            for (int i = 0; i < figures.Count; i++)
            {
                if (figures[i].P > max_P)
                {
                    max_P = figures[i].P;
                    name_p_max = figures[i].name;
                }
                if (figures[i].S > max_S)
                {
                    max_S = figures[i].S;
                    name_s_max = figures[i].name;
                }
                if (figures[i].P < min_P)
                {
                    min_P = figures[i].P;
                    name_p_min = figures[i].name;
                }
                if (figures[i].S < min_P)
                {
                    min_S = figures[i].S;
                    name_s_min = figures[i].name;
                }
            }
            a += name_p_max + " имеет наибольший периметр (" + max_P + ")" + '\n';
            a += name_s_max + " имеет наибольшую площадь (" + max_S + ")" + '\n';
            a += '\n';
            a += name_p_min + " имеет наименьший периметр (" + min_P + ")" + '\n';
            a += name_s_min + " имеет наименьшую площадь (" + min_S + ")" + '\n';
            return a;

        }
    }
    class Kvadrat : Figures
    {
        public Kvadrat(int[] xy1, int[] xy2, int[] xy3, int[] xy4, string name)
        {
            this.name = name;
            this.xy1 = xy1;
            this.xy2 = xy2;
            this.xy3 = xy3;
            this.xy4 = xy4;
            this.lenth = Math.Abs(this.xy1[0] - this.xy4[0]);
            this.hight = Math.Abs(this.xy1[1] - this.xy2[1]);
            if (this.lenth != this.hight)
                throw new IndexOutOfRangeException("the sides of the square must be the same!");
            this.P = this.lenth * 4;
            this.S = this.lenth * this.hight;
        }
    }
    class rectangle : Figures
    {
        public rectangle(int[] xy1, int[] xy2, int[] xy3, int[] xy4, string name)
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
    class Krug : Figures
    {
        public Krug(double R, string name)
        {
            this.name = name;
            this.R = R;
            this.P = 2 * this.R * 3.14;
            this.S = 3.14 * Math.Pow(this.R, 2);
        }
    }
    class triangle : Figures
    {
        public triangle(int[] xy1, int[] xy2, int[] xy3, string name)
        {
            this.name = name;
            this.xy1 = xy1;
            this.xy2 = xy2;
            this.xy3 = xy3;
            this.side_r_length = Math.Abs(Math.Sqrt(Math.Pow((xy2[0] - xy1[0]), 2) + Math.Pow((xy2[1] - xy1[1]), 2)));
            this.side_l_length = Math.Abs(Math.Sqrt(Math.Pow((xy3[0] - xy2[0]), 2) + Math.Pow((xy3[1] - xy2[1]), 2)));
            this.bottom_length = Math.Abs(Math.Sqrt(Math.Pow((xy3[0] - xy1[0]), 2) + Math.Pow((xy3[1] - xy1[1]), 2)));
            this.P = (this.side_r_length + this.side_l_length + this.bottom_length) / 2;
            this.S = Math.Sqrt(this.P * (this.P - this.side_r_length) * (this.P - this.side_l_length) * (this.P - this.bottom_length));
        }
    }
}

