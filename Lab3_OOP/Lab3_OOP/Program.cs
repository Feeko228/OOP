using System;

namespace Lab3_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            ContactsBook book = new ContactsBook();
            /*types 1- mobile, 2 - home, 3 - work, else - unknown*/
            book.AddContact("Дима");
            book.AddContact("Стас Тараканов");
            book.AddContact("Деканат");

            book[0].AddNumber(1, "+79421191444");
            book[0].AddNumber(2,"1847046");

            book[1].AddNumber(1, "+88005453535");
            book[1].AddNumber(2, "127312");
            book[1].AddNumber(2, "1фыв27312");

            book[2].AddNumber(1, "+78122342746");
            book[2].AddNumber(3, "43545345");
            book[2].AddNumber(1, "4+3545345");

            Console.WriteLine(book.ShowContacts());

            book.RemoveContact(1);
            book[0].RemoveNumber(1);
            book.AddContact("КГБ");
            book[2].AddNumber(4, "84952242222");
            Console.WriteLine(book.ShowContacts());

            Console.WriteLine(book.FindContact("3"));
            Console.WriteLine(book.FindContact("84952242222"));
            Console.WriteLine(book.FindContact("а"));
            Console.WriteLine(book.FindContact("Стас"));
            Console.WriteLine(book.FindContact("Деканат"));


        }
    }
}
