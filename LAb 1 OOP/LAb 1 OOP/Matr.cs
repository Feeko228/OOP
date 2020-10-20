using System;
using System.Collections.Generic;
using System.Threading;

namespace LAb_1_OOP
{
    class Matr
    {
        private Random rnd = new Random();
        private int stroki;
        private int stolbci;
        private int[,] matrix;

        public Matr(int str, int stb)
        {
            stroki = str;
            stolbci = stb;
            Matr matrix = new Matr(str, stb);

            for (int i = 0; i < str; ++i)
                for (int j = 0; j < stb; ++j)
                    matrix.matrix[i, j] = rnd.Next(-9, 9);
        }

        private bool isSquare(Matr matrix)
        {
            if (matrix.stroki == matrix.stolbci)
                return true;
            else
                return false;
        }

        private bool is2by2(Matr matrix)
        {
            if (matrix.stroki == matrix.stolbci && matrix.stroki == 2)
                return true;
            else
                return false;
        }

        public void OutMatr() // ВЫВОД МАТР
        {
            for (int i = 0; i < stroki; ++i)
            {
                for (int j = 0; j < stolbci; ++j)
                    Console.Write(matrix[i, j] + " ");
                Console.WriteLine("\n");
            }
        }

        public int[,] SumMatr(Matr matr_one, Matr matr_two) // СЛОЖЕНИЕ МАТР + МАТР
        {
            if ((matr_one.stroki == matr_two.stroki) && (matr_one.stolbci == matr_two.stolbci))
            {
                Matr SumMatrix = new Matr(matr_one.stroki, matr_two.stolbci);

                for (int i = 0; i < SumMatrix.stroki; ++i)
                    for (int j = 0; j < SumMatrix.stolbci; ++j)
                        SumMatrix.matrix[i, j] = matr_one.matrix[i, j] + matr_two.matrix[i, j];

                return SumMatrix.matrix;
            }
            else
            {
                Console.WriteLine("Sum error!");
                return null;
            }
        }

        public int[,] AntiSumMatr(Matr matr_one, Matr matr_two) // СЛОЖЕНИЕ МАТР + МАТР
        {
            if ((matr_one.stroki == matr_two.stroki) && (matr_one.stolbci == matr_two.stolbci))
            {
                Matr SumMatrix = new Matr(matr_one.stroki, matr_two.stolbci);

                for (int i = 0; i < SumMatrix.stroki; ++i)
                    for (int j = 0; j < SumMatrix.stolbci; ++j)
                        SumMatrix.matrix[i, j] = matr_one.matrix[i, j] - matr_two.matrix[i, j];

                return SumMatrix.matrix;
            }
            else
            {
                Console.WriteLine("Sum error!");
                return null;
            }
        }

        public int[,] MultMatr(Matr matr_one, Matr matr_two) // УМНОЖЕНИЕ МАТР
        {
            if (matr_one.stolbci == matr_two.stroki)
            {
                Matr MultMatrix = new Matr(matr_one.stroki, matr_two.stolbci);

                for (int i = 0; i < MultMatrix.stroki; ++i)
                    for (int j = 0; j < MultMatrix.stolbci; ++j)
                        for (int k = 0; k < matr_one.stolbci; ++k)
                            MultMatrix.matrix[i, j] = matr_one.matrix[i, k] * matr_two.matrix[k, j];

                return MultMatrix.matrix;
            }
            else
            {
                Console.WriteLine("Mult error!");
                return null;
            }
        }

        public int[,] ScalMatr(Matr matrix, int scal) // УМНОЖЕНИЕ НА СКАЛЯР
        {
            Matr MultMatrix = new Matr(matrix.stroki, matrix.stolbci);

            for (int i = 0; i < MultMatrix.stroki; ++i)
                for (int j = 0; j < MultMatrix.stolbci; ++j)
                    MultMatrix.matrix[i, j] = matrix.matrix[i, j] * scal;

            return MultMatrix.matrix;
        }

        public int[,] FindChangeElem(Matr matrix, int firstpos, int secondpos, int elem)  // ПОИСК И ЗАМЕНА ЭЛЕМНТА
        {
            for (int i = 0; i < matrix.stroki; ++i)
                for (int j = 0; j < matrix.stolbci; ++j)
                    if ((i == firstpos - 1) && (j == secondpos - 1))
                        matrix.matrix[i, j] = elem;

            return matrix.matrix;
        }

        public void CompareMatr(Matr matr_one, Matr matr_two) // СРАВНЕНИЕ МАТР 
        {
            if ((matr_one.stroki == matr_two.stroki) && (matr_one.stolbci == matr_two.stolbci))
            {
                for (int i = 0; i < matr_one.stroki; ++i)
                    for (int j = 0; j < matr_one.stolbci; ++j)
                        if (matr_one.matrix[i, j] != matr_two.matrix[i, j])
                        {
                            Console.WriteLine("Not similar");
                            break;
                        }

                Console.WriteLine("Similar");
            }
        }

        public int DetMatr(Matr matrix) // ОПРЕДЕЛИТЕЛь
        {
            if (isSquare(matrix) == true && is2by2(matrix) == true)
                return matrix.matrix[0, 0] * matrix.matrix[1, 1] - matrix.matrix[0, 1] * matrix.matrix[1, 0];
            else if (isSquare(matrix) == true && is2by2(matrix) == false)
            {
                int res = 0;
                for (int i = 0; i < matrix.stroki; ++i)
                {
                    res += (i % 2 == 1 ? 1 : -1) * matrix.matrix[1, i] * CutStolb(matrix).CutStrok(matrix).DetMatr(matrix);
                }

                return res;
            }
            else
            {
                Console.WriteLine("Not square matrix");
                return 0;
            }
        }

        private Matr CutStolb(Matr matrix)
        {
            Matr res = new Matr(matrix.stroki, matrix.stolbci - 1);
            for (int i = 0; i < res.stroki; ++i)
                for (int j = 0; j < res.stolbci; ++j)
                    res.matrix[i, j] = matrix.matrix[i, j + 1];

            return res;
        }

        private Matr CutStrok(Matr matrix)
        {
            Matr res = new Matr(matrix.stroki - 1, matrix.stolbci);
            for (int i = 0; i < res.stroki; ++i)
                for (int j = 0; j < res.stolbci; ++j)
                    res.matrix[i, j] = matrix.matrix[i + 1, j];

            return res;
        }
    }
}