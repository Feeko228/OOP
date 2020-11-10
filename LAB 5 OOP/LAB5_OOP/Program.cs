using System;
using System.Collections.Generic;
using System.Drawing;

namespace Lab2_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Figures figures = new Figures();

            Console.Write("Нажми 1 если хочешь сохранить то,  что ввел в мейне, нажми 2 чтобы восстановить то что ты уже сохранил: ");
            string a = Console.ReadLine();
            int b = Convert.ToInt32(a);
            if (b == 1)
            {
                figures.AddShape(new Square(new Point(0, 0), new Point(0, 10)));//координаты углов одной из сторон
                figures.AddShape(new Rectangle(new Point(0, 0), new Point(5, 10)));//координаты нижнего левого и правого верхеного углов
                figures.AddShape(new Circle(new Point(0, 0), new Point(6, 0)));
                figures.AddShape(new Triangle(new Point(0, 0), new Point(6, 0), new Point(3, 5)));

                Console.WriteLine("ты сохраняешь данные фигуры:");
                Console.WriteLine(figures[0].ToString());
                Console.WriteLine(figures[1].ToString());
                Console.WriteLine(figures[2].ToString());
                Console.WriteLine(figures[3].ToString());

                figures.Save();
            }
            if (b == 2)
            {
                try
                {
                    figures.Load();
                    Console.WriteLine(figures[0].ToString());
                    Console.WriteLine(figures[1].ToString());
                    Console.WriteLine(figures[2].ToString());
                    Console.WriteLine(figures[3].ToString());
                }
                catch
                {
                    Console.WriteLine("список файлов для загрузки пуст");
                }
            }
        }
    }
}
