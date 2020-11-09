using System;
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
    /// Логика взаимодействия для CreateTriangle.xaml
    /// </summary>
    public partial class CreateTriangle : Window
    {
        public CreateTriangle()
        {
            InitializeComponent();
        }
        MainWindow main = (MainWindow)App.Current.MainWindow;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double data1 = 0;
            double data2 = 0;
            double data3 = 0;
            try
            {
                Double.TryParse(txt1.Text, out data1);
                Double.TryParse(txt2.Text, out data2);
                Double.TryParse(txt3.Text, out data3);
            }
            catch
            {
                Close();
            }
            main.side1 = data1;
            main.side2 = data2;
            main.side3 = data3;
            this.DialogResult = true;
        }
    }
}
