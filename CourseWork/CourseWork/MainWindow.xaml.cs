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
            BlackTheme();
        }

        private void BlackTheme()
        {
            var paletteHelper = new PaletteHelper();
            ITheme themee = paletteHelper.GetTheme();
            themee.SetBaseTheme(Theme.Dark);
            themee.SetPrimaryColor(Color.FromRgb(105, 176, 255));
            paletteHelper.SetTheme(themee);
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
            alltypes.IsChecked = true;
            CreateNoteBox("NewNote", "Red", DateTime.Now, "", col.NotesListSize());
            col.CreateNewNote("NewNote", "Red", DateTime.Now, col.NotesListSize());
            col.Save();
            Reload();
        }
        public void CreateNoteBox(string Name, string Brush, DateTime last_edit_time, string TextInNote, int index)
        {
            ContextMenu contextmenu = new ContextMenu();
            var delete = new MenuItem();
            delete.Header = "Delete " + "\"" + Name + "\"" + " ?";
            delete.Tag = index;
            contextmenu.Items.Add(delete);
            delete.AddHandler(MenuItem.ClickEvent, new RoutedEventHandler(ItemClick));

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
            box.Header = Name;
            box.Width = 120;
            box.Height = 120;
            box.Margin = new Thickness(10, 10, 10, 10);
            box.MouseDoubleClick += new MouseButtonEventHandler(EditNote);
            box.ToolTip = $"Изменено:\n{last_edit_time}";
            box.ContextMenu = contextmenu;
            wrap.Children.Add(box);
        }
        private void ItemClick(object sender, RoutedEventArgs e)
        {
            int IndexForDelete = Convert.ToInt32((sender as MenuItem).Tag);
            for (int i = 0; i < col.NotesListSize(); i++)
            {
                if (IndexForDelete == col[i].ThisNoteIndex)
                    col.DeleteNote(col[i]);
                col.Save();
            }
            Reload();
        }
        public void EditNote(object sender, MouseButtonEventArgs e)
        {
            note not = new note();
            not.EditCreatedNote(Convert.ToInt32((sender as GroupBox).Tag), wrap.Children.IndexOf(sender as GroupBox));
            try
            {
                not.ShowDialog();
            }
            catch { }
            Reload();
            alltypes.IsChecked = true;
        }

        private void ContainsPhoto_check(object sender, RoutedEventArgs e)
        {
            if (fromdate.SelectedDate != null || todate.SelectedDate != null)
            {
                fromdate.SelectedDate = null;
                todate.SelectedDate = null;
            }
            wrap.Children.Clear();
            for (int i = 0; i < col.NotesListSize(); i++)
                if (col[i].imgs.Count != 0)
                    CreateNoteBox(col[i].Name, col[i].Brhsname, col[i].last_edit_time, col[i].txt.GetTextFromNote(), col[i].ThisNoteIndex);
        }
        private void ContainsTodoo_check(object sender, RoutedEventArgs e)
        {
            wrap.Children.Clear();
            for (int i = 0; i < col.NotesListSize(); i++)
                if (col[i].todos.Count != 0)
                    CreateNoteBox(col[i].Name, col[i].Brhsname, col[i].last_edit_time, col[i].txt.GetTextFromNote(), col[i].ThisNoteIndex);
        }
        private void alltypes_Checked(object sender, RoutedEventArgs e)
        {
            Reload();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            alltypes.IsChecked = true;
            wrap.Children.Clear();
            for (int i = 0; i < col.NotesListSize(); i++)
            {
                if (col[i].Name.Contains((sender as TextBox).Text) ||
                    col[i].txt.GetTextFromNote().Contains((sender as TextBox).Text))
                    CreateNoteBox(col[i].Name, col[i].Brhsname, col[i].last_edit_time,
                    col[i].txt.GetTextFromNote(), col[i].ThisNoteIndex
                    );
            }
        }

        private void FindByDate_Click(object sender, RoutedEventArgs e)
        {
            DateTime Date1;
            DateTime Date2;
            try
            {
                Date1 = (DateTime)fromdate.SelectedDate;
                Date2 = (DateTime)todate.SelectedDate;
            }
            catch
            {
                Date1 = DateTime.Today;
                Date2 = DateTime.Today;
            }
            alltypes.IsChecked = true;
            wrap.Children.Clear();
            for (int i = 0; i < col.NotesListSize(); i++)
            {
                if (col[i].last_edit_time >= Date1 && col[i].last_edit_time <= Date2.AddHours(24))
                {
                    CreateNoteBox(col[i].Name, col[i].Brhsname, col[i].last_edit_time,
                    col[i].txt.GetTextFromNote(), col[i].ThisNoteIndex
                    );
                }
            }
        }
    }
}