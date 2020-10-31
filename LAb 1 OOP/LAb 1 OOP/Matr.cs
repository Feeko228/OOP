using System;
using System.Collections.Generic;
using System.Threading;

namespace LAb_1_OOP
{
    class Matr
    {
        private int columns, strings;
        public int[,] matrix;

        public Matr(int str, int stb)
        {
            this.strings = str;
            this.columns = stb;
            this.matrix = new int[str, stb];
        }

        public void InitMatr(Action<int, int> func)
        {
            for (int i = 0; i < this.strings; i++)
                for (int j = 0; j < this.columns; j++)
                    func(i, j);
        }

        public string OutMatr() // OUTPUT
        {
            string a = null;
            for (int i = 0; i < this.strings; i++)
            {
                for (int j = 0; j < this.columns; j++)
                {
                    a += Convert.ToString(this.matrix[i, j]);
                    if (j != this.columns - 1)
                        a += " ";
                }
                a += "\n";
            }
            return a;
        }

        public Matr SumMatr(Matr matr_one, Matr matr_two) // ADD MATRIX
        {
            if ((matr_one.strings == matr_two.strings) && (matr_one.columns == matr_two.columns))
            {
                Matr SumMatrix = new Matr(matr_one.strings, matr_two.columns);

                for (int i = 0; i < SumMatrix.strings; i++)
                {
                    for (int j = 0; j < SumMatrix.columns; j++)
                        SumMatrix.matrix[i, j] = matr_one.matrix[i, j] + matr_two.matrix[i, j];
                }
                return SumMatrix;
            }
            else
                throw new ArgumentException("strings or columns not similar");
        }

        public Matr SubMatr(Matr matr_one, Matr matr_two) // SUBTRACTING MATRICES
        {
            if ((matr_one.strings == matr_two.strings) && (matr_one.columns == matr_two.columns))
            {
                Matr SubMatrix = new Matr(matr_one.strings, matr_two.columns);

                for (int i = 0; i < SubMatrix.strings; i++)
                {
                    for (int j = 0; j < SubMatrix.columns; j++)
                        SubMatrix.matrix[i, j] = matr_one.matrix[i, j] - matr_two.matrix[i, j];
                }
                return SubMatrix;
            }
            else
                throw new ArgumentException("strings or columns not similar");
        }

        public Matr MultMatr(Matr matr_one, Matr matr_two) // MATRIX MULTIPLICATION
        {
            if (matr_one.columns == matr_two.strings)
            {
                Matr MultMatrix = new Matr(matr_one.strings, matr_two.columns);


                for (int i = 0; i < matr_one.strings; i++)
                    for (int j = 0; j < matr_two.columns; j++)
                    {
                        MultMatrix.matrix[i, j] = 0;
                        for (int k = 0; k < matr_one.columns; ++k)
                            MultMatrix.matrix[i, j] += matr_one.matrix[i, k] * matr_two.matrix[k, j];
                    }
                return MultMatrix;
            }
            else
                throw new ArgumentException("strings or columns not similar");
        }

        public Matr ScalMatr(int scal) // SCALAR MULTIPLICATION
        {
            for (int i = 0; i < this.strings; i++)
                for (int j = 0; j < this.columns; j++)
                    this.matrix[i, j] = this.matrix[i, j] * scal;

            return this;
        }

        public Matr FindChangeElem(int firstpos, int secondpos, int elem)  // SEARCH AND REPLACE ELEMENT
        {
            for (int i = 0; i < this.strings; i++)
                for (int j = 0; j < this.columns; j++)
                    if ((i == firstpos - 1) && (j == secondpos - 1))
                        this.matrix[i, j] = elem;

            return this;
        }

        public string CompareMatr(Matr matr_one, Matr matr_two) // MATRIX COMPARISON
        {
            string a = null;
            if ((matr_one.strings == matr_two.strings) && (matr_one.columns == matr_two.columns))
            {
                bool equal = true;
                for (int i = 0; i < matr_one.strings; i++)
                    for (int j = 0; j < matr_one.columns; j++)
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

        public int DetMatr() // DETERMINANT
        {
            if (IsSquare() == true && Is2by2() == true)
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            else if (IsSquare() == true && Is2by2() == false)
            {
                int res = 0;
                for (int i = 0; i < this.columns; i++)
                    res += (i % 2 == 1 ? 1 : -1) * this.matrix[1, i] * this.CutColumn(i).CutString(1).DetMatr();

                return res;
            }
            else
                throw new ArgumentException("Matrix not square");
        }

        private Matr CutColumn(int col) // COLUMN CUT
        {
            if (col < 0 || col >= this.columns)
            {
                throw new ArgumentException("invalid column");
            }
            else
            {
                var res = new Matr(this.strings, this.columns - 1);
                res.InitMatr((i, j) => res.matrix[i, j] = j < col ? this.matrix[i, j] : this.matrix[i, j + 1]);

                return res;
            }
        }

        private Matr CutString(int row) // STRING CUT
        {
            if (row < 0 || row >= this.strings)
            {
                throw new ArgumentException("invalid string");
            }
            else
            {
                var res = new Matr(this.strings - 1, this.columns);
                res.InitMatr((i, j) => res.matrix[i, j] = i < row ? this.matrix[i, j] : this.matrix[i + 1, j]);

                return res;
            }
        }


        private bool IsSquare()
        {
            if (this.strings == this.columns)
                return true;
            else
                return false;
        }

        private bool Is2by2()
        {
            if (this.strings == this.columns && this.strings == 2)
                return true;
            else
                return false;
        }
    }
}