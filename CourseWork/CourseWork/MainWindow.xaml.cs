using MaterialDesignThemes.Wpf;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CourseWork
{
    public partial class MainWindow : Window
    {
        public void print(string line)
        {
            Console.WriteLine(line);
        }
        Collection col = new Collection();
        public MainWindow()
        {
            InitializeComponent();
            Reload();
        }
        private void Reload()
        {
            col.ClearMemmory();
            wrap.Children.Clear();
            col.Load();
            for (int i = 0; i < col.NotesListSize(); i++)
            {
                CreateNoteBox(
                    col[i].Name,
                    col[i].Brhsname,
                    col[i].last_edit_time,
                    col[i].txt.GetTextFromNote(),
                    col[i].ThisNoteIndex
                    );
            }
        }
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(col.NotesListSize());
            CreateNoteBox("NewNote", "Red", DateTime.Now.ToString(), "", col.NotesListSize());
            col.CreateNewNote("NewNote", "Red", DateTime.Now.ToString(), col.NotesListSize());
            col.Save();
            Reload();
        }
        public void CreateNoteBox(string Name, string Brush, string last_edit_time, string TextInNote, int index)
        {
            GroupBox box = new GroupBox();
            TextBlock block = new TextBlock();

            SolidColorBrush ColorOne = (SolidColorBrush)new BrushConverter().ConvertFromString(Brush);
            SolidColorBrush ColorTwo = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            ColorZoneAssist.SetMode(box, ColorZoneMode.Custom);
            ColorZoneAssist.SetBackground(box, ColorOne);
            ColorZoneAssist.SetForeground(box, ColorTwo);

            block.TextWrapping = TextWrapping.Wrap;
            block.Margin = new Thickness(5, 5, 5, 5);
            block.Text = TextInNote;

            box.Tag = index;
            box.Content = block;
            box.Name = Name;
            box.Header = Name;
            box.Width = 120;
            box.Height = 120;
            box.Margin = new Thickness(10, 10, 10, 10);
            box.MouseDoubleClick += new MouseButtonEventHandler(EditNote);
            box.ToolTip = $"Изменено:\n{last_edit_time}";
            wrap.Children.Add(box);
        }

        public void EditNote(object sender, MouseButtonEventArgs e)
        {
            note not = new note();
            not.EditCreatedNote(Convert.ToInt32((sender as GroupBox).Tag));
            if (not.ShowDialog() == false)
            {
                print("all was saved");
                Reload();
            }
        }

        private void onlytxt_Checked(object sender, RoutedEventArgs e)
        {
            Reload();
            wrap.Children.Clear();
            for (int i = 0; i < col.NotesListSize(); i++)
                if (col[i].todos.Count <= 0 && col[i].imgs.Count <= 0)
                    CreateNoteBox(col[i].Name, col[i].Brhsname, col[i].last_edit_time, col[i].txt.GetTextFromNote(), col[i].ThisNoteIndex);
        }

        private void onlyimg_Checked(object sender, RoutedEventArgs e)
        {
            Reload();
            wrap.Children.Clear();
            for (int i = 0; i < col.NotesListSize(); i++)
                if (col[i].todos.Count <= 0 && col[i].txt.GetTextFromNote().Length <= 0)
                    CreateNoteBox(col[i].Name, col[i].Brhsname, col[i].last_edit_time, col[i].txt.GetTextFromNote(), col[i].ThisNoteIndex);
        }

        private void onlytodo_Checked(object sender, RoutedEventArgs e)
        {
            Reload();
            wrap.Children.Clear();
            for (int i = 0; i < col.NotesListSize(); i++)
                if (col[i].txt.GetTextFromNote().Length <= 0 && col[i].imgs.Count <= 0)
                    CreateNoteBox(col[i].Name, col[i].Brhsname, col[i].last_edit_time, col[i].txt.GetTextFromNote(), col[i].ThisNoteIndex);
        }

        private void alltypes_Checked(object sender, RoutedEventArgs e)
        {
            Reload();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < col.NotesListSize(); i++)
            {
                print("----");
                print(col[i].Name);
                print(col[i].Brhsname);
                print(col[i].last_edit_time);
                print(col[i].txt.GetTextFromNote());
                print("----");
            }
        }
    }
}
