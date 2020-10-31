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
            // book[0].name = "Другой дима";
            // book[0].numbers[0].number = "345345";

            List<ContactsBook.Contact> contacts = book.Show();
            List<ContactsBook.Contact> names = book.Find("3");
            foreach (ContactsBook.Contact a in contacts)
            {
                Console.WriteLine(a.name);
                for (int i = 0; i < a.numbers.Count; i++)
                {
                    Console.WriteLine(a.numbers[i].number + " " + a.numbers[i].type);
                }
            }
            Console.WriteLine('\n');
            foreach (ContactsBook.Contact a in names)
            {
                Console.WriteLine(a.name);
                for (int i = 0; i < a.numbers.Count; i++)
                {
                    Console.WriteLine(a.numbers[i].number + " " + a.numbers[i].type);
                }
            }
        }
    }
}
