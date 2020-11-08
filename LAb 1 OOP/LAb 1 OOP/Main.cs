using System;
using System.Collections.Generic;
using System.Text;

namespace LAb_1_OOP
{
    class Program
    {
        static void Main()
        {
            Random rnd = new Random();
            Matr matrix = new Matr(4, 4);
            Matr matrix2 = new Matr(4, 4);

            matrix.InitMatr((i, j) => matrix.matrix[i, j] = rnd.Next(0, 9));
            matrix2.InitMatr((i, j) => matrix2.matrix[i, j] = rnd.Next(0, 9));

            Console.WriteLine(matrix.GetHashCode());
            Console.WriteLine(matrix2.GetHashCode());

            Console.WriteLine(matrix.ToString());
            Console.WriteLine(matrix2.ToString());

            string a;
            Console.WriteLine("Sum");
            Matr Sum = matrix.SumMatr(matrix, matrix2);
            Console.WriteLine(Sum.ToString());

            Console.WriteLine("Sub");
            Matr Sub = matrix.SubMatr(matrix, matrix2);
            Console.WriteLine(Sub.ToString());

            Console.WriteLine("Mult");
            Matr mult = matrix.MultMatr(matrix, matrix2);
            Console.WriteLine(mult.ToString());

            Console.WriteLine("Scal");
            matrix.ScalMatr(2);
            Console.WriteLine(matrix.ToString());

            Console.WriteLine("FindChange");
            matrix.FindChangeElem(2, 2, 100);
            Console.WriteLine(matrix.ToString());

            Console.WriteLine("Compare");
            Console.WriteLine(matrix.Equals(matrix2));

            Console.WriteLine("Det");
            int b = matrix.DetMatr();
            Console.WriteLine(Convert.ToString(b));

            Console.ReadLine();
        }
    }
}
