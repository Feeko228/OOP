using System;
using System.Collections.Generic;
using System.Threading;

namespace LAb_1_OOP
{
    class Matrix
    {
        private Random rand = new Random();
        private int a = 0;
        private bool isequal;
        public int[,] CreateMatrix(int size)//создание матрицы
        {
            try
            {
                a = size;
                int[,] matrix = new int[a, a];

                for (int i = 0; i < a; i++)
                {
                    for (int j = 0; j < a; j++)
                    {
                        matrix[i, j] = rand.Next(0, 9);
                    }
                }
                return matrix;
            }
            catch
            {
                return null;
            }
        }
        public void ShowMatrix(int[,] matrix)//просмотр размерности и вывод матрицы
        {
            try
            {
                a = Convert.ToInt32(Math.Sqrt(matrix.Length));
                for (int i = 0; i < a; i++)//вывод строк
                {
                    for (int j = 0; j < a; j++)//вывод столбцов
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                    Console.WriteLine("\n");
                }
            }
            catch
            {
                Console.WriteLine("Что-то пошло не так");
            }
        }
        public int[,] SumMatrix(int[,] Firstmatrix, int[,] Secondmatrix)//сложение матриц
        {
            try
            {
                a = Convert.ToInt32(Math.Sqrt(Firstmatrix.Length));//пофиг какя матрица, у них всеравно доложны совпадать размеры
                int[,] Newmatrix = new int[a, a];
                int[,] Failmatrix = new int[a, a];
                for (int i = 0; i < Math.Sqrt(Firstmatrix.Length); i++)
                {
                    for (int j = 0; j < Math.Sqrt(Firstmatrix.Length); j++)
                    {
                        Newmatrix[i, j] = Firstmatrix[i, j] + Secondmatrix[i, j];
                    }
                }
                Console.WriteLine("Результат: ");
                return Newmatrix;
            }
            catch
            {
                Console.WriteLine("Слогаемые матрицы длжны быть одного размера");
                return null;
            }
        }
        public int[,] SubMatrix(int[,] Firstmatrix, int[,] Secondmatrix)//вычитание матриц
        {
            try
            {
                a = Convert.ToInt32(Math.Sqrt(Firstmatrix.Length));//пофиг какя матрица, у них всеравно доложны совпадать размеры
                int[,] Newmatrix = new int[a, a];
                int[,] Failmatrix = new int[a, a];
                for (int i = 0; i < a; i++)
                {
                    for (int j = 0; j < a; j++)
                    {
                        Newmatrix[i, j] = Firstmatrix[i, j] - Secondmatrix[i, j];
                    }
                }
                Console.WriteLine("Результат: ");
                return Newmatrix;
            }
            catch
            {
                Console.WriteLine("Вычитаемые матрицы длжны быть одного размера");
                return null;
            }
        }
        public int[,] MultMatrix(int[,] Firstmatrix, int[,] Secondmatrix)//умножение матриц
        {
            try
            {
                a = Convert.ToInt32(Math.Sqrt(Firstmatrix.Length));//пофиг какя матрица, у них всеравно доложны совпадать размеры
                int[,] Newmatrix = new int[a, a];
                int[,] Failmatrix = new int[a, a];
                for (int i = 0; i < a; i++)
                {
                    for (int j = 0; j < a; j++)
                    {
                        Newmatrix[i, j] = 0;
                        for (int k = 0; k < a; k++)
                        {
                            Newmatrix[i, j] += Firstmatrix[i, k] * Secondmatrix[k, j];
                        }
                    }
                }
                Console.WriteLine("Результат: ");
                return Newmatrix;
            }
            catch
            {
                Console.WriteLine("Умножаемые матрицы длжны быть одного размера");
                return null;
            }
        }
        public int[,] MultScalMatrix(int[,] matrix, int scalar)//уминожение матриц на скаляр
        {
            try
            {
                a = Convert.ToInt32(Math.Sqrt(matrix.Length));//пофиг какя матрица, у них всеравно доложны совпадать размеры
                int[,] Newmatrix = new int[a, a];
                int[,] Failmatrix = new int[a, a];
                for (int i = 0; i < a; i++)
                {
                    for (int j = 0; j < a; j++)
                    {
                        Newmatrix[i, j] = matrix[i, j] * scalar;
                    }
                }
                return Newmatrix;
            }
            catch
            {
                Console.WriteLine("Что-то пошло не так");
                return null;
            }
        }

        public int[,] FindChangeElem(int[,] matrix, int firstpos, int secondpose, int newelement)//поиск и замена элемента матрицы
        {
            if (firstpos < 0)
                firstpos *= -1;
            if (secondpose < 0)
                secondpose *= -1;
            try
            {
                for (int i = 0; i < a; i++)
                {
                    for (int j = 0; j < a; j++)
                    {
                        if ((i == firstpos - 1) && (j == secondpose - 1))
                        {
                            matrix[i, j] = newelement;
                        }
                    }
                }
                return matrix;
            }
            catch
            {
                Console.WriteLine("Что-то пошло не так");
                return matrix;
            }
        }
        public int MatrixDet(int[,] matrix)
        {
            a = Convert.ToInt32(Math.Sqrt(matrix.Length));

            int n = a + (a - 1);
            int[,] buffer = new int[a, a - 1];
            int[,] newmatrix = new int[a, n];

            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < a - 1; j++)
                {
                    buffer[i, j] = matrix[i, j];
                }
            }
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < a; j++)
                {
                    newmatrix[i, j] = matrix[i, j];
                }
            }
            for (int i = 0; i < a; i++)
            {
                for (int j = a; j < n; j++)
                {
                    newmatrix[i, j] = buffer[i, j - a];
                }
            }

            int minusdet = MinusDet(newmatrix, a, n);
            int plusdet = PlusDet(newmatrix, a, n);

            int det = plusdet - minusdet;
            return det;
        }
        private int MinusDet(int[,] m, int a, int n)
        {
            int tmpdet = 1;
            int tmp = 0;
            int mindet = 0;
            int l = 0;
            int k = 0;
            while (k < n)
            {
                for (int i = a-1; i > -1; i--)
                {
                    for (int j = k; j < n; j++)
                    {
                        if (j == l + k)
                        {
                            tmpdet = tmpdet * m[i, j];
                            
                        }
                    }
                    l++; tmp = tmpdet;
                    if (l == a)
                    {
                        l = 0; tmpdet = 1;
                    }
                }
                mindet += tmp;
                k++;
                if (k == a)
                    break;
            }
            return mindet;
        }
        private int PlusDet(int[,] m, int a, int n)
        {
            int tmpdet = 1;
            int tmp = 0;
            int plusdet = 0;
            int l = 0;
            int k = 0;
            while (k < n)
            {
                for (int i = 0; i < a; i++)
                {
                    for (int j = k; j < n; j++)
                    {
                        if (j == l + k)
                        {
                            tmpdet = tmpdet * m[i, j];

                        }
                    }
                    l++; tmp = tmpdet;
                    if (l == a)
                    {
                        l = 0; tmpdet = 1;
                    }
                }
                plusdet += tmp;
                k++;
                if (k == a)
                    break;
            }
            return plusdet;
        }

        public void CompateMatrix(int[,] Firstmatrix, int[,] Secondmatrix)//сравнение матриц
        {
            isequal = false;
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < a; j++)
                {
                    if (Firstmatrix[i, j] != Secondmatrix[i, j])
                    {
                        isequal = false;
                    }
                    else
                    {
                        isequal = true;
                    }
                }
            }
            if (isequal == false)
            {
                Console.WriteLine("Разные");
            }
            else
            {
                Console.WriteLine("Одинаковые");
            }
        }
    }
}
