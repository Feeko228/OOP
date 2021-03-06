﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LAB6_OOP
{
    /// <summary>
    /// Логика взаимодействия для CreateCircle.xaml
    /// </summary>
    public partial class CreateCircle : Window
    {
        public CreateCircle()
        {
            InitializeComponent();
        }
        MainWindow main = (MainWindow)App.Current.MainWindow;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double data = 0;
            try
            {
                Double.TryParse(txt.Text, out data);
            }
            catch
            {
                Close();
            }
            main.radius = data;
            this.DialogResult = true;
        }
    }
}
