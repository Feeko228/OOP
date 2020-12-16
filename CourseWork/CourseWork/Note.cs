using MaterialDesignColors.Recommended;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;

namespace CourseWork
{
    class Collection
    {
        private List<Note> notes = new List<Note>();
        private BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Environment.CurrentDirectory, "Notes");
        public Note this[int i]
        {
            get { return notes[i]; }
            set { notes[i] = value; }
        }
        public Note GetNoteByIndex(int index)
        {
            for (int i = 0; i < NotesListSize(); i++)
                if (notes[i].ThisNoteIndex == index)
                    return notes[i];
            return null;
        }
        public Note LastNote()
        {
            return notes.Last();
        }
        public int NotesListSize()
        {
            return notes.Count;
        }
        public int GetIndex(Note note)
        {
            int index = 0;
            foreach (Note a in notes)

                if (note == a)
                    index = notes.IndexOf(a);
            return index;
        }
        public void CreateNewNote(string name, string br, string edittime, int NewNoteIndex)
        {
            notes.Add(new Note(name, br, edittime, NewNoteIndex));
        }
        public void Save()
        {
            using (FileStream fs = new FileStream(path + $"/notes.nte", FileMode.OpenOrCreate))
                formatter.Serialize(fs, notes);
        }
        public void Load()
        {
            string[] fileEntries = Directory.GetFiles(path, "*.nte");
            foreach (string item in fileEntries)
            {
                using (FileStream fs = new FileStream(item, FileMode.OpenOrCreate))
                {
                    List<Note> not = (List<Note>)formatter.Deserialize(fs);
                    notes.AddRange(not);
                }
            }
        }
        public void ClearMemmory()
        {
            notes.Clear();
        }
    }
    [Serializable]
    class Note
    {
        public string Name;
        public string Brhsname;
        public string last_edit_time;
        public int ThisNoteIndex;
        public TextNote txt;
        public List<TodoNote> todos = new List<TodoNote>();
        public List<ImgeNote> imgs = new List<ImgeNote>();
        public Note(string name, string br, string edittime, int index)
        {
            last_edit_time = edittime;
            this.ThisNoteIndex = index;
            Name = name;
            Brhsname = br;
            txt = new TextNote();
        }
        public void CreateTodoNote(string content, bool isdo, string name)
        {
            todos.Add(new TodoNote(content, isdo, name));
        }
        public void AddNewImg(string path)
        {
            imgs.Add(new ImgeNote(path));
        }
        public int LastTodoIndex()
        {
            return todos.Count;
        }
        public WrapPanel ReturnLastTodo()
        {
            return todos[LastTodoIndex() - 1].CreateNewTodoNote();
        }
        public WrapPanel ReturnTodoByIndex(int index)
        {
            return todos[index].CreateNewTodoNote();
        }
    }

    [Serializable]
    class TextNote
    {
        private string content;
        public void SetNewText(string txt)
        {
            content = txt;
        }
        public string GetTextFromNote()
        {
            return content;
        }
    }
    [Serializable]
    class TodoNote
    {
        public string TodoContent;
        public string TodoName;
        public bool TodoCheck;
        public TodoNote(string Content, bool Check, string Name)
        {
            TodoContent = Content;
            TodoCheck = Check;
            TodoName = Name;
        }
        public WrapPanel CreateNewTodoNote()
        {
            WrapPanel todo = new WrapPanel();
            CheckBox check = new CheckBox();
            TextBox text = new TextBox();
            Button delete = new Button();

            todo.Height = 22;
            todo.Width = Double.NaN;
            todo.Name = TodoName;

            check.Content = null;
            check.IsChecked = TodoCheck;
            text.Text = TodoContent;

            delete.Height = 15;
            delete.Width = 16;
            delete.Background = null;
            delete.BorderBrush = null;
            delete.Foreground = Brushes.Black;
            delete.Margin = new Thickness(10, 0, 0, 0);
            delete.Padding = new Thickness(-1.7, -1.3, 0, 0);
            delete.Content = "❌";

            todo.Children.Add(check);
            todo.Children.Add(text);
            todo.Children.Add(delete);

            return todo;
        }
    }

    [Serializable]
    class ImgeNote
    {
        string path;
        public ImgeNote(string path)
        {
            this.path = path;
        }
    }
}
