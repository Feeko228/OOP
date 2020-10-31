using System;
using System.Collections.Generic;

namespace Lab3_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            ContactsBook book = new ContactsBook();

            book.AddContact("Дима");
            book.AddContact("Стас Петров");
            book.AddContact("Деканат");

            book[0].AddNumber(1, "+7(932)119-13-43");
            book[0].AddNumber(2, "1847046");

            book[1].AddNumber(1, "+88005+453535");
            book[1].AddNumber(2, "127312");

            book[2].AddNumber(1, "+7122342746");
            book[2].AddNumber(5, "982281488");

            book[0].ChangeName("Димо");
            book[2].numbers[0].change(1, "+sdfsdf");


            foreach (ContactsBook.Contact a in book.Show())
            {
                Console.WriteLine(a.name);
                for (int i = 0; i < a.numbers.Count; i++)
                {
                    Console.WriteLine(a.numbers[i].type + " " + a.numbers[i].number);
                }
            }
            Console.WriteLine('\n');
            foreach (ContactsBook.Contact a in book.Find("3"))
            {
                Console.WriteLine(a.name);
                for (int i = 0; i < a.numbers.Count; i++)
                {
                    Console.WriteLine(a.numbers[i].type + " " + a.numbers[i].number);
                }
            }
        }
    }
}
