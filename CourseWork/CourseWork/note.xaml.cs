using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CourseWork
{
    public partial class note : Window
    {

        Collection col = new Collection();
        MainWindow main = (MainWindow)Application.Current.MainWindow;
        List<WrapPanel> todos = new List<WrapPanel>();
        TextBlock textBlock = new TextBlock();
        Note NoteForEdit;
        int index;
        int indexInMain;
        public note()
        {
            InitializeComponent();
            col.Load();
            this.KeyDown += new KeyEventHandler(DeletePress);
            this.KeyDown += new KeyEventHandler(OpenImg);
   
        }

        public void EditCreatedNote(int picked_note_index, int mainindex)
        {
            indexInMain = mainindex;
            index = picked_note_index;
            NoteForEdit = col.GetNoteByIndex(index);
            if (NoteForEdit == null)
            {
                MessageBox.Show("I can`t find any notes!", "WTF?", MessageBoxButton.OK);
                this.Close();
            }
            else
            {
                colors1.Color = (Color)ColorConverter.ConvertFromString(NoteForEdit.Brhsname);
                this.Title = NoteForEdit.Name;
                notename.Text = NoteForEdit.Name;
                txt.Text = NoteForEdit.txt.GetTextFromNote();
                for (int i = 0; i < NoteForEdit.LastTodoIndex(); i++)
                {
                    todos.Add(
                        CreateNewTodoNote(
                        NoteForEdit.todos[i].TodoContent,
                        NoteForEdit.todos[i].TodoCheck,
                        NoteForEdit.todos[i].TodoName));
                    AddTodoToUI();
                }
                for (int i = 0; i < NoteForEdit.LastImgIndex(); i++)
                {
                    CreateImgTempplate(NoteForEdit.imgs[i].path, i);
                }

            }
        }
        private void AddNewTodo(object sender, RoutedEventArgs e)
        {
            NoteForEdit.CreateTodoNote(TodoContent.Text, false, "todo_" + todolist.Items.Count);
            NoteForEdit.last_edit_time = DateTime.Now;
            todos.Add(CreateNewTodoNote(TodoContent.Text, false, "todo_" + todolist.Items.Count));
            AddTodoToUI();
            TodoContent.Text = null;
            col.Save();
        }
        private void AddTodoToUI()
        {
            todos[todos.Count - 1].Children[0].AddHandler(CheckBox.CheckedEvent, new RoutedEventHandler(ChangeTodoState));
            todos[todos.Count - 1].Children[0].AddHandler(CheckBox.UncheckedEvent, new RoutedEventHandler(ChangeTodoState));
            todos[todos.Count - 1].Children[0].SetValue(CheckBox.NameProperty, "todo_" + todolist.Items.Count);

            todos[todos.Count - 1].Children[1].AddHandler(TextBox.TextChangedEvent, new RoutedEventHandler(ChangeTodoState));
            todos[todos.Count - 1].Children[1].SetValue(TextBox.NameProperty, "todo_" + todolist.Items.Count);

            todos[todos.Count - 1].Children[2].AddHandler(Button.ClickEvent, new RoutedEventHandler(ChangeTodoState));
            todos[todos.Count - 1].Children[2].SetValue(Button.NameProperty, "todo_" + todolist.Items.Count);
            todolist.Items.Add(todos[todos.Count - 1]);

        }
        private void SetNewTextInCurrentNote(object sender, TextChangedEventArgs e)
        {
            NoteForEdit.txt.SetNewText(txt.Text);
            textBlock.Text = txt.Text;
            textBlock.TextWrapping = TextWrapping.Wrap;
            textBlock.Margin = new Thickness(5, 5, 5, 5);
            main.wrap.Children[indexInMain].SetValue(GroupBox.ContentProperty, textBlock);
            col.Save();
        }
        private void SetNewNameOfCurrentNote(object sender, TextChangedEventArgs e)
        {
            main.wrap.Children[indexInMain].SetValue(GroupBox.HeaderProperty, notename.Text);
            main.wrap.Children[indexInMain].SetValue(GroupBox.ToolTipProperty, $"Изменено:\n{DateTime.Now}");
            this.Title = NoteForEdit.Name;
            NoteForEdit.Name = notename.Text;
            NoteForEdit.last_edit_time = DateTime.Now;
            col.Save();
        }
        private void ChangeTodoState(object sender, RoutedEventArgs e)
        {
            if (sender.GetType().Name == "CheckBox")
                for (int i = 0; i < NoteForEdit.LastTodoIndex(); i++)
                    if (NoteForEdit.todos[i].TodoName == (sender as CheckBox).Name)
                    {
                        NoteForEdit.todos[i].TodoCheck = (bool)(sender as CheckBox).IsChecked;
                        NoteForEdit.last_edit_time = DateTime.Now;
                        col.Save();
                    }
            if (sender.GetType().Name == "TextBox")
                for (int i = 0; i < NoteForEdit.LastTodoIndex(); i++)
                    if (NoteForEdit.todos[i].TodoName == (sender as TextBox).Name)
                    {
                        NoteForEdit.todos[i].TodoContent = (sender as TextBox).Text;
                        NoteForEdit.last_edit_time = DateTime.Now;
                        col.Save();
                    }
            if (sender.GetType().Name == "Button")
                for (int i = 0; i < NoteForEdit.LastTodoIndex(); i++)
                    if (NoteForEdit.todos[i].TodoName == (sender as Button).Name)
                    {
                        NoteForEdit.DeleteToDoNote(NoteForEdit.todos[i]);
                        todolist.Items.RemoveAt(i);
                        NoteForEdit.last_edit_time = DateTime.Now;
                        col.Save();
                    }
        }
        public WrapPanel CreateNewTodoNote(string content, bool Ischeck, string name)
        {
            WrapPanel todo = new WrapPanel();
            CheckBox check = new CheckBox();
            TextBox text = new TextBox();
            Button delete = new Button();

            todo.Height = 30;
            todo.Width = Double.NaN;
            todo.Name = name;

            check.Content = null;
            check.IsChecked = Ischeck;
            text.Text = content;

            delete.Height = 15;
            delete.Width = 16;
            delete.Background = null;
            delete.BorderBrush = null;
            delete.Foreground = Brushes.White;
            delete.Margin = new Thickness(10, 0, 0, 0);
            delete.Padding = new Thickness(-1.7, -1.3, 0, 0);
            delete.Content = "❌";

            todo.Children.Add(check);
            todo.Children.Add(text);
            todo.Children.Add(delete);

            return todo;
        }
        private void EnterPress(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddTodoClick.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }
        private void AddPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
            if (openFileDialog.ShowDialog() == true)
            {
                NoteForEdit.AddNewPhoto(openFileDialog.FileName, NoteForEdit.LastImgIndex());
                CreateImgTempplate(openFileDialog.FileName, NoteForEdit.LastImgIndex() - 1);
                NoteForEdit.last_edit_time = DateTime.Now;
                col.Save();
            }
        }
        public void CreateImgTempplate(string path, int thisimgindex)
        {
            var img = new Image();
            img.Height = 110;
            img.Width = 110;
            img.Tag = thisimgindex;
            try
            {
                img.Source = (new ImageSourceConverter()).ConvertFromString(path) as ImageSource;
            }
            catch
            {
                string pathToTemplate = Directory.GetCurrentDirectory();
                img.Source = (new ImageSourceConverter()).ConvertFromString(pathToTemplate + @"\template.jpg") as ImageSource;
            }
            images.Items.Add(img);
        }
        private void DeletePress(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Delete)
            {
                Image selectedImage = (Image)images.SelectedItem;
                if (selectedImage != null)
                    for (int i = 0; i < NoteForEdit.LastImgIndex(); i++)
                    {
                        if (Convert.ToInt32(selectedImage.Tag) == NoteForEdit.imgs[i].ImgIndex)
                        {
                            NoteForEdit.DeleteImage(NoteForEdit.imgs[i]);
                            NoteForEdit.last_edit_time = DateTime.Now;
                            col.Save();
                        }

                    }
                images.Items.Remove(images.SelectedItem);
                col.Save();
            }
        }
        private void OpenImg(object sender, KeyEventArgs e)
        {
            Image selectedImage = (Image)images.SelectedItem;
            if (selectedImage != null)
                if (e.Key == Key.Enter)
                {
                    for (int i = 0; i < NoteForEdit.LastImgIndex(); i++)
                        if (Convert.ToInt32(selectedImage.Tag) == NoteForEdit.imgs[i].ImgIndex)
                        {
                            try
                            {
                                Process.Start(NoteForEdit.imgs[i].path);
                            }
                            catch
                            {
                                MessageBox.Show("I can`t open this photo! You can delete it...");
                            }
                        }
                    images.SelectedItem = null;
                }
        }
        private void ColorChanger(object sender, MouseEventArgs e)
        {
            SolidColorBrush brush = new SolidColorBrush(colors1.Color);
            ColorZoneAssist.SetBackground(main.wrap.Children[indexInMain], brush);
            NoteForEdit.Brhsname = colors1.Color.ToString();
            NoteForEdit.last_edit_time = DateTime.Now;
            col.Save();

        }
    }
}