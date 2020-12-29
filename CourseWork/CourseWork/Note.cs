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
        private string path = Path.Combine(Environment.CurrentDirectory, "Notes");
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
        public Note LastNote() => notes.Last();
        public int NotesListSize() => notes.Count;
        public int GetIndex(Note note)
        {
            int index = 0;
            foreach (Note a in notes)

                if (note == a)
                    index = notes.IndexOf(a);
            return index;
        }
        public void CreateNewNote(string name, string br, DateTime edittime, int NewNoteIndex)
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
        public void ClearMemmory() => notes.Clear();
        public void DeleteNote(Note notefordelete) => notes.Remove(notefordelete);
    }
    [Serializable]
    class Note
    {
        public string Name;
        public string Brhsname;
        public DateTime last_edit_time;
        public int ThisNoteIndex;
        public TextNote txt = new TextNote();
        public List<TodoNote> todos = new List<TodoNote>();
        public List<ImgeNote> imgs = new List<ImgeNote>();
        public Note(string name, string br, DateTime edittime, int index)
        {
            last_edit_time = edittime;
            this.ThisNoteIndex = index;
            Name = name;
            Brhsname = br;
            txt.SetNewText("");
        }
        public void CreateTodoNote(string content, bool isdo, string name) => todos.Add(new TodoNote(content, isdo, name));
        public void ClearAllTodos() => todos.Clear();
        public void DeleteToDoNote(TodoNote todofordelete) => todos.Remove(todofordelete);
        public int LastTodoIndex() => todos.Count;
        public int LastImgIndex() => imgs.Count;
        public void AddNewPhoto(string imgpath, int PhotoIndex) => imgs.Add(new ImgeNote(imgpath, PhotoIndex));
        public void DeleteImage(ImgeNote imgfordelete) => imgs.Remove(imgfordelete);
    }

    [Serializable]
    class TextNote
    {
        private string content;
        public void SetNewText(string txt) => content = txt;
        public string GetTextFromNote() => content;
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
    }

    [Serializable]
    class ImgeNote
    {
        public string path;
        public int ImgIndex;
        public ImgeNote(string path, int ImgIndex)
        {
            this.path = path;
            this.ImgIndex = ImgIndex;
        }
    }
}
