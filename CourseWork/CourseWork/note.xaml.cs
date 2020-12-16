using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CourseWork
{
    public partial class note : Window
    {
        public void cout(string value)
        {
            Console.WriteLine(value);
        }
        Collection col = new Collection();
        MainWindow main = (MainWindow)Application.Current.MainWindow;
        List<WrapPanel> todos = new List<WrapPanel>();
        TextBlock textBlock = new TextBlock();
        Note NoteForEdit;
        int index;
        public note()
        {
            InitializeComponent();
            col.Load();
        }
        public void EditCreatedNote(int picked_note_index)
        {
            index = picked_note_index;
            NoteForEdit = col.GetNoteByIndex(index);
            Console.WriteLine(NoteForEdit.Name);
            notename.Text = NoteForEdit.Name;
            txt.Text = NoteForEdit.txt.GetTextFromNote();
            for (int i = 0; i < NoteForEdit.LastTodoIndex(); i++)
            {
                todos.Add(NoteForEdit.ReturnTodoByIndex(i));
                AddTodoToUI();
            }
        }
        private void AddNewTodo(object sender, RoutedEventArgs e)
        {
            NoteForEdit.CreateTodoNote(todoname.Text, false, Convert.ToString("todo_" + todolist.Items.Count));
            NoteForEdit.last_edit_time = DateTime.Now.ToString();
            todos.Add(NoteForEdit.ReturnLastTodo());
            AddTodoToUI();
            todoname.Text = null;
            col.Save();
        }
        private void AddTodoToUI()
        {
            todos[todos.Count - 1].Children[0].AddHandler(CheckBox.CheckedEvent, new RoutedEventHandler(ChangeTodoState));
            todos[todos.Count - 1].Children[0].AddHandler(CheckBox.UncheckedEvent, new RoutedEventHandler(ChangeTodoState));
            todos[todos.Count - 1].Children[0].SetValue(CheckBox.NameProperty, "check_todo_" + todolist.Items.Count);
            todos[todos.Count - 1].Children[1].AddHandler(TextBox.TextChangedEvent, new RoutedEventHandler(ChangeTodoState));
            todos[todos.Count - 1].Children[1].SetValue(TextBox.NameProperty, "text_todo_" + todolist.Items.Count);
            todolist.Items.Add(todos[todos.Count - 1]);
        }
        private void SetNewTextInCurrentNote(object sender, TextChangedEventArgs e)
        {
            NoteForEdit.txt.SetNewText(txt.Text);
            textBlock.Text = txt.Text;
            textBlock.TextWrapping = TextWrapping.Wrap;
            textBlock.Margin = new Thickness(5, 5, 5, 5);
            //main.wrap.Children[index].SetValue(GroupBox.ContentProperty, textBlock);
            col.Save();
        }
        private void SetNewNameOfCurrentNote(object sender, TextChangedEventArgs e)
        {
            notename.Text = notename.Text.Replace(" ", "");
            //main.wrap.Children[index].SetValue(GroupBox.HeaderProperty, notename.Text);
            //main.wrap.Children[index].SetValue(GroupBox.NameProperty, notename.Text);
            //main.wrap.Children[index].SetValue(GroupBox.ToolTipProperty, $"Изменено:\n{DateTime.Now}");
            NoteForEdit.Name = notename.Text;
            NoteForEdit.last_edit_time = DateTime.Now.ToString();
            col.Save();
        }
        private void IsCurrentNoteNameCorrect(object sender, TextCompositionEventArgs e)
        {
            e.Handled = (
                "qwertyuiopasdfghjklzxcvbnm" +
                "QWERTYUIOPASDFGHJKLZXCVBNM" +
                "ёйцукенгшщзхъфывапролджэячсмитьбю" +
                "ЁЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ"
                ).IndexOf(e.Text) < 0;
        }
        private void CheckColorChange(object sender, SelectionChangedEventArgs e)
        {
            foreach (Rectangle a in colors.SelectedItems)
            {
                SolidColorBrush colorone = (SolidColorBrush)new BrushConverter().ConvertFromString(a.Name);
                ColorZoneAssist.SetMode(main.wrap.Children[index], ColorZoneMode.Custom);
                //ColorZoneAssist.SetBackground(main.wrap.Children[index], colorone);
                NoteForEdit.Brhsname = a.Name;
                NoteForEdit.last_edit_time = DateTime.Now.ToString();
                col.Save();
            }
        }
        private void ChangeTodoState(object sender, RoutedEventArgs e)
        {
            if (sender.GetType().Name == "CheckBox")
                for (int i = 0; i < NoteForEdit.LastTodoIndex(); i++)
                    if ((sender as CheckBox).Name.Contains(NoteForEdit.todos[i].TodoName))
                    {
                        NoteForEdit.todos[i].TodoCheck = (bool)(sender as CheckBox).IsChecked;
                        NoteForEdit.last_edit_time = DateTime.Now.ToString();
                        col.Save();
                    }
            if (sender.GetType().Name == "TextBox")
                for (int i = 0; i < NoteForEdit.LastTodoIndex(); i++)
                    if ((sender as TextBox).Name.Contains(NoteForEdit.todos[i].TodoName))
                    {
                        NoteForEdit.todos[i].TodoContent = (sender as TextBox).Text;
                        NoteForEdit.last_edit_time = DateTime.Now.ToString();
                        col.Save();
                    }
        }
    }
}