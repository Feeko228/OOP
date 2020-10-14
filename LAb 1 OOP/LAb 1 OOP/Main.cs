using System;
using System.Collections.Generic;
using System.Text;

namespace LAb_1_OOP
{
    /*
     список методов для вызова через Matrix name

     CreateMatrix(int size)//создание матрицы
     ShowMatrix(int[,] matrix)//просмотр размерности и вывод матрицы
     SumMatrix(int[,] Firstmatrix, int[,] Secondmatrix)//сложение матриц
     SubMatrix(int[,] Firstmatrix, int[,] Secondmatrix)//вычитание матриц
     MultMatrix(int[,] Firstmatrix, int[,] Secondmatrix)//умножение матриц
     MultScalMatrix(int[,] matrix, int scalar)//уминожение матриц на скаляр
     FindChangeElem(int[,] matrix, int firstpos, int secondpose, int newelement)//поиск и замена элемента матрицы
     
     CompateMatrix(int[,] Firstmatrix, int[,] Secondmatrix)//сравнение матриц
     */
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix();
            int[,] first; 
            int[,] second;
            int[,] newmatrix;

            first = matrix.CreateMatrix(3);
            second = matrix.CreateMatrix(3);

            matrix.ShowMatrix(first);
            Console.WriteLine("\n");
            matrix.ShowMatrix(second);
            Console.WriteLine("\n");

            newmatrix = matrix.MultMatrix(first, second);

            matrix.ShowMatrix(newmatrix);
        }
    }
}
