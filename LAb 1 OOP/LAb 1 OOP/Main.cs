using System;
using System.Collections.Generic;
using System.Text;

namespace LAb_1_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Matr matrix = new Matr(4, 4);
            Matr matrix2 = new Matr(4, 4);

            matrix.InitMatr((i, j) => matrix.matrix[i, j] = rnd.Next(0, 9));
            matrix2.InitMatr((i, j) => matrix2.matrix[i, j] = rnd.Next(0, 9));

            string a = matrix.OutMatr();
            Console.WriteLine(a);
            a = matrix2.OutMatr();
            Console.WriteLine(a);

            Console.WriteLine("Sum");
            Matr Sum = matrix.SumMatr(matrix, matrix2);
            a = Sum.OutMatr();
            Console.WriteLine(a);

            Console.WriteLine("Sub");
            Matr Sub = matrix.SubMatr(matrix, matrix2);
            a = Sub.OutMatr();
            Console.WriteLine(a);

            Console.WriteLine("Mult");
            Matr mult = matrix.MultMatr(matrix, matrix2);
            a = mult.OutMatr();
            Console.WriteLine(a);

            Console.WriteLine("Scal");
            matrix.ScalMatr(2);
            a = matrix.OutMatr();
            Console.WriteLine(a);

            Console.WriteLine("FindChange");
            matrix.FindChangeElem(2, 2, 100);
            a = matrix.OutMatr();
            Console.WriteLine(a);

            Console.WriteLine("Compare");
            a = matrix.CompareMatr(matrix, matrix2);
            Console.WriteLine(a);

            Console.WriteLine("Det");
            int b = matrix.DetMatr();
            Console.WriteLine(Convert.ToString(b));

            Console.ReadLine();
        }
    }
}
