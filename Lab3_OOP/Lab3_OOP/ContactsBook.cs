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
        public string ShowContacts()
        {
            string cout = "Все контакты:" + '\n';
            foreach (Contact a in contacts)
            {
                cout += a.name + ": ";
                for (int i = 0; i < a.numbers.Count; i++)
                    cout += a[i].type + ": " + a[i].number + " ";
                cout += '\n';
            }
            return cout;
        }
        public string FindContact(string word)
        {
            string cout = "Контакт(ы) по запросу \"" + word + "\":" + '\n';
            bool wasfound = false;
            foreach (Contact a in contacts)
            {
                if (a.name.Contains(word))
                {
                    wasfound = true;
                    cout += a.name + ": ";
                    for (int i = 0; i < a.numbers.Count; i++)
                        cout += a[i].type + ": " + a[i].number + "; ";
                    cout += '\n';
                }
                else wasfound = false;
            }
            if (wasfound == false)
                foreach (Contact a in contacts)
                {
                    for (int i = 0; i < a.numbers.Count; i++)
                        if (a[i].number.Contains(word))
                        {
                            cout += a.name + ": ";
                            for (int j = 0; j < a.numbers.Count; j++)
                                if (a[j].number.Contains(word))
                                    cout += a[j].type + ": " + a[j].number + "; ";
                            cout += '\n';
                            break;
                        }
                }
            return cout;
        }
        public void RemoveContact(int index)
        {
            contacts.RemoveAt(index);
        }
        public class Contact
        {
            public string name;
            public List<Numbers> numbers = new List<Numbers>();
            public Numbers this[int i]
            {
                get { return numbers[i]; }
            }
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
        }
        public class Numbers
        {
            public string number, type;
            string CheckNumver(string num)
            {
                string numm = num;
                if (Regex.IsMatch(num, "^[+][0-9]+$") || Regex.IsMatch(num, "^[0-9]+$"))
                    return numm;
                else
                    return "Invalid number";
            }
            string Types(short typ)
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
                        return "UNKNOWN";
                }
            }
            public Numbers(short type, string number)
            {
                this.number = CheckNumver(number);
                this.type = Types(type);
            }
        }
    }
}