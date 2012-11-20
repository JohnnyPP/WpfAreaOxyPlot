using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OxyPlot.Wpf;

namespace WpfAreaOxyPlot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// http://oxyplot.codeplex.com/SourceControl/changeset/view/52946448ea08#Source%2fExamples%2fWPF%2fWpfExamples%2fExamples%2fAreaDemo%2fMainViewModel.cs
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var vm = new MainViewModel();
            DataContext = vm;
        }

        private void button1Connect_Click(object sender, RoutedEventArgs e)
        {
            label1Temperature.Content = "Test";
        }

      
    }
}
