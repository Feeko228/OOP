using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace LAB6_OOP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Reload();
        }

        Figures figures = new Figures();
        public double side1;
        public double side2;
        public double side3;
        public double radius;

        private void Reload()
        {
            figures.Load();
            int i = 0;
            while (i < figures.LastShapeIndex())
            {
                listbox.Items.Add(figures[i].ToString());
                i++;
            }
        }
        private void remove_Click(object sender, RoutedEventArgs e)
        {
            figures.RemoveShape(listbox.SelectedIndex);
            figures.Save();
            try
            {
                listbox.Items.RemoveAt(listbox.SelectedIndex);
            }
            catch { }
        }
        private void Up_CLick(object sender, RoutedEventArgs e)
        {
            if (listbox.SelectedIndex != 0)
            {
                try
                {
                    ListBox tmpbox = new ListBox();
                    List<IShape> tmpshape = new List<IShape>();
                    int num = listbox.SelectedIndex - 1;

                    tmpshape.Add(figures[listbox.SelectedIndex - 1]);
                    figures[listbox.SelectedIndex - 1] = figures[listbox.SelectedIndex];
                    figures[listbox.SelectedIndex] = tmpshape[0];

                    tmpbox.Items.Add(listbox.Items[listbox.SelectedIndex - 1]);
                    listbox.Items[listbox.SelectedIndex - 1] = listbox.Items[listbox.SelectedIndex];
                    listbox.Items[listbox.SelectedIndex] = tmpbox.Items[0];
                    listbox.SelectedIndex = num;
                    gothrough();
                    figures.Save();
                }
                catch { }
            }
        }

        private void Down_Click(object sender, RoutedEventArgs e)
        {
            if (listbox.SelectedIndex != listbox.Items.Count - 1)
            {
                try
                {
                    ListBox tmpbox = new ListBox();
                    List<IShape> tmpshape = new List<IShape>();
                    int num = listbox.SelectedIndex + 1;

                    tmpshape.Add(figures[listbox.SelectedIndex + 1]);
                    figures[listbox.SelectedIndex + 1] = figures[listbox.SelectedIndex];
                    figures[listbox.SelectedIndex] = tmpshape[0];

                    tmpbox.Items.Add(listbox.Items[listbox.SelectedIndex + 1]);
                    listbox.Items[listbox.SelectedIndex + 1] = listbox.Items[listbox.SelectedIndex];
                    listbox.Items[listbox.SelectedIndex] = tmpbox.Items[0];
                    listbox.SelectedIndex = num;
                    gothrough();
                    figures.Save();
                }
                catch { }
            }
        }
        private void createSquare_Click(object sender, RoutedEventArgs e)
        {
            CreateSquare square = new CreateSquare();
            if (square.ShowDialog() == true)
            {
                figures.AddShape(new MySquare(side1));
                listbox.Items.Add(figures.LastShape().ToString());
                figures.Save();
            }
        }
        private void createRectangle_Click(object sender, RoutedEventArgs e)
        {
            CreateRectangle rectangle = new CreateRectangle();
            if (rectangle.ShowDialog() == true)
            {
                figures.AddShape(new MyRectangle(side1, side2));
                listbox.Items.Add(figures.LastShape().ToString());
                figures.Save();
            }
        }
        private void createCircle_Click(object sender, RoutedEventArgs e)
        {
            CreateCircle circle = new CreateCircle();
            if (circle.ShowDialog() == true)
            {
                figures.AddShape(new MyCircle(radius));
                listbox.Items.Add(figures.LastShape().ToString());
                figures.Save();
            }
        }
        private void createTriangle_Click(object sender, RoutedEventArgs e)
        {
            CreateTriangle triangle = new CreateTriangle();
            if (triangle.ShowDialog() == true)
            {
                figures.AddShape(new MyTriangle(side1, side2, side3));
                listbox.Items.Add(figures.LastShape().ToString());
                figures.Save();
            }
        }
        private void maxp_Click(object sender, RoutedEventArgs e)
        {
            gothrough();
            int index = figures.GetIndex(figures.MaxPerim());
            ListBoxItem lbi = (ListBoxItem)listbox.ItemContainerGenerator.ContainerFromIndex(index);
            if (lbi != null)
                lbi.Foreground = Brushes.Red;
        }
        private void minp_Click(object sender, RoutedEventArgs e)
        {
            gothrough();
            int index = figures.GetIndex(figures.MinPerim());
            ListBoxItem lbi = (ListBoxItem)listbox.ItemContainerGenerator.ContainerFromIndex(index);
            if (lbi != null)
                lbi.Foreground = Brushes.Red;
        }

        private void maxa_Click(object sender, RoutedEventArgs e)
        {
            gothrough();
            int index = figures.GetIndex(figures.MaxArea());
            ListBoxItem lbi = (ListBoxItem)listbox.ItemContainerGenerator.ContainerFromIndex(index);
            if (lbi != null)
                lbi.Foreground = Brushes.Red;
        }

        private void mina_Click(object sender, RoutedEventArgs e)
        {
            gothrough();
            int index = figures.GetIndex(figures.MinArea());
            ListBoxItem lbi = (ListBoxItem)listbox.ItemContainerGenerator.ContainerFromIndex(index);
            if (lbi != null)
                lbi.Foreground = Brushes.Red;
        }
        private void gothrough()
        {
            int num = 0;
            ListBoxItem lbi;
            foreach (var a in listbox.Items)
            {
                lbi = (ListBoxItem)listbox.ItemContainerGenerator.ContainerFromIndex(num);
                if (lbi != null)
                    lbi.Foreground = Brushes.Black;
                num++;
            }
        }
    }
}
