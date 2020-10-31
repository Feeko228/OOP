using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab3_OOP
{
    class ContactsBook
    {
        private List<Contact> contacts = new List<Contact>();

        public Contact this[int i]
        {
            get { return contacts[i]; }
        }
        public void AddContact(string name)
        {
            this.contacts.Add(new Contact(name));
        }
        public List<Contact> Show()
        {
            List<Contact> newlist = new List<Contact>();
            newlist.AddRange(contacts);
            return newlist;
        }
        public List<Contact> Find(string word)
        { 
            List<Contact> Found = new List<Contact>();
            foreach (Contact a in contacts)
            {
                if (a.name.Contains(word))
                    Found.Add(a);
                else
                    for (int i = 0; i < a.numbers.Count; i++)
                    {
                        if (a.numbers[i].number.Contains(word))
                            Found.Add(a);
                    }
            }
            return Found;
        }
        public void RemoveContact(int index)
        {
            contacts.RemoveAt(index);
        }
        public class Contact
        {
            public string name { get; private set; }
            public List<Numbers> numbers = new List<Numbers>();

            public Contact(string name)
            {
                this.name = name;
            }
            public void AddNumber(short type, string number)
            {
                numbers.Add(new Numbers(type, number));
            }
            public void RemoveNumber(int index)
            {
                numbers.RemoveAt(index);
            }
            public void ChangeName(string name)
            {
                this.name = name;
            }
        }
        public class Numbers
        {
            public string number { get; private set; }
            public string type { get; private set; }
            private string CheckNumber(string num)
            {
                string numm = num;
                if (Regex.IsMatch(num, "^[+][0-9]+$") || Regex.IsMatch(num, "^[0-9]+$"))
                    return numm;
                else
                    return "INVALID NUMBER";
            }
            private string CheckType(short typ)
            {
                switch (typ)
                {
                    case 1:
                        return "MOBILE";
                    case 2:
                        return "HOME";
                    case 3:
                        return "WORK";
                    default:
                        return "INVALID TYPE";
                }
            }
            public void change(short type, string number)
            {
                this.number = CheckNumber(number);
                this.type = CheckType(type);
            }
            public Numbers(short type, string number)
            {
                this.number = CheckNumber(number);
                this.type = CheckType(type);
            }
        }
    }
}