using System;
using System.Collections.Generic;
using System.Threading;

namespace LAb_1_OOP
{
    class Matr
    {
        private int stroki;
        private int stolbci;
        public int[,] matrix;
        public Matr(int str, int stb)
        {
            this.stroki = str;
            this.stolbci = stb;
            this.matrix = new int[str, stb];
        }
        public void InitMatr(Action<int, int> func)
        {
            for (int i = 0; i < this.stroki; i++)
                for (int j = 0; j < this.stolbci; j++)
                    func(i, j);
        }
        public string OutMatr() // ВЫВОД МАТР
        {
            string a = null;
            for (int i = 0; i < this.stroki; i++)
            {
                for (int j = 0; j < this.stolbci; j++)
                {
                    a += Convert.ToString(this.matrix[i, j]);
                    if (j != this.stolbci - 1)
                        a += " ";
                }
                a += "\n";

            }
            return a;
        }
        public Matr SumMatr(Matr matr_one, Matr matr_two) // СЛОЖЕНИЕ МАТР + МАТР
        {
            if ((matr_one.stroki == matr_two.stroki) && (matr_one.stolbci == matr_two.stolbci))
            {
                Matr SumMatrix = new Matr(matr_one.stroki, matr_two.stolbci);

                for (int i = 0; i < SumMatrix.stroki; i++)
                {
                    for (int j = 0; j < SumMatrix.stolbci; j++)
                        SumMatrix.matrix[i, j] = matr_one.matrix[i, j] + matr_two.matrix[i, j];
                }
                return SumMatrix;
            }
            else
                throw new Exception("Stroki or stolbci not similar");
        }
        public Matr SubMatr(Matr matr_one, Matr matr_two) // ВЫЧИТ МАТР + МАТР
        {
            if ((matr_one.stroki == matr_two.stroki) && (matr_one.stolbci == matr_two.stolbci))
            {
                Matr SubMatrix = new Matr(matr_one.stroki, matr_two.stolbci);

                for (int i = 0; i < SubMatrix.stroki; i++)
                {
                    for (int j = 0; j < SubMatrix.stolbci; j++)
                        SubMatrix.matrix[i, j] = matr_one.matrix[i, j] - matr_two.matrix[i, j];
                }
                return SubMatrix;
            }
            else
                throw new Exception("Stroki or stolbci not similar");
        }
        public Matr MultMatr(Matr matr_one, Matr matr_two) // УМНОЖЕНИЕ МАТР
        {
            if (matr_one.stolbci == matr_two.stroki)
            {
                Matr MultMatrix = new Matr(matr_one.stroki, matr_two.stolbci);
                for (int i = 0; i < matr_one.stroki; i++)
                    for (int j = 0; j < matr_two.stolbci; j++)
                    {
                        MultMatrix.matrix[i, j] = 0;
                        for (int k = 0; k < matr_one.stolbci; ++k)
                            MultMatrix.matrix[i, j] += matr_one.matrix[i, k] * matr_two.matrix[k, j];
                    }
                return MultMatrix;
            }
            else
                throw new Exception("Stroki or stolbci not similar");
        }
        public Matr ScalMatr(int scal) // УМНОЖЕНИЕ НА СКАЛЯР
        {
            for (int i = 0; i < this.stroki; i++)
                for (int j = 0; j < this.stolbci; j++)
                    this.matrix[i, j] = this.matrix[i, j] * scal;

            return this;
        }
        public Matr FindChangeElem(int firstpos, int secondpos, int elem)  // ПОИСК И ЗАМЕНА ЭЛЕМНТА
        {
            for (int i = 0; i < this.stroki; i++)
                for (int j = 0; j < this.stolbci; j++)
                    if ((i == firstpos - 1) && (j == secondpos - 1))
                        this.matrix[i, j] = elem;

            return this;
        }
        public string CompareMatr(Matr matr_one, Matr matr_two) // СРАВНЕНИЕ МАТР 
        {
            string a = null;
            if ((matr_one.stroki == matr_two.stroki) && (matr_one.stolbci == matr_two.stolbci))
            {
                bool equal = true;
                for (int i = 0; i < matr_one.stroki; i++)
                    for (int j = 0; j < matr_one.stolbci; j++)
                        if (matr_one.matrix[i, j] != matr_two.matrix[i, j])
                            equal = false;

                if (equal == true)
                {
                    a = "Similar";
                    return a;
                }
                else
                {
                    a = "Not similar";
                    return a;
                }
            }
            else
            {
                a = "Not similar";
                return a;
            }
        }
        public int DetMatr() // ОПРЕДЕЛИТЕЛь
        {
            if (IsSquare() == true && Is2by2() == true)
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            else if (IsSquare() == true && Is2by2() == false)
            {
                int res = 0;
                for (int i = 0; i < this.stolbci; i++)
                    res += (i % 2 == 1 ? 1 : -1) * this.matrix[1, i] * this.CutStolb(i).CutStrok(1).DetMatr();

                return res;
            }
            else
                throw new Exception("Matrix not square");
        }
        public Matr CutStolb(int col)
        {
            if (col < 0 || col >= this.stolbci)
            {
                throw new ArgumentException("invalid column");
            }
            else
            {
                var res = new Matr(this.stroki, this.stolbci - 1);
                res.InitMatr((i, j) => res.matrix[i, j] = j < col ? this.matrix[i, j] : this.matrix[i, j + 1]);
                return res;
            }
        }
        public Matr CutStrok(int row)
        {
            if (row < 0 || row >= this.stroki)
            {
                throw new ArgumentException("invalid row");
            }
            else
            {
                var res = new Matr(this.stroki - 1, this.stolbci);
                res.InitMatr((i, j) => res.matrix[i, j] = i < row ? this.matrix[i, j] : this.matrix[i + 1, j]);

                return res;
            }
        }
        public bool IsSquare()
        {
            if (this.stroki == this.stolbci)
                return true;
            else
                return false;
        }
        public bool Is2by2()
        {
            if (this.stroki == this.stolbci && this.stroki == 2)
                return true;
            else
                return false;
        }
    }
}