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
using System.IO.Ports;
using System.Threading;
using System.Windows.Threading;

namespace WpfAreaOxyPlot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// http://oxyplot.codeplex.com/SourceControl/changeset/view/52946448ea08#Source%2fExamples%2fWPF%2fWpfExamples%2fExamples%2fAreaDemo%2fMainViewModel.cs
    /// </summary>
    public partial class MainWindow : Window
    {
        SerialPort serialPort1 = new SerialPort();
        string recieved_data;

        public MainWindow()
        {
            InitializeComponent();
            var vm = new MainViewModel();
            DataContext = vm;
        }

       

        private void button1Connect_Click(object sender, RoutedEventArgs e)
        {
            label1Temperature.Content = "Test";

            serialPort1.PortName = "COM3";
            serialPort1.BaudRate = 9600;
            serialPort1.DtrEnable = true;
            serialPort1.Open();
            
            serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(Recieve);


            if (serialPort1.IsOpen)
            {
                button1.IsEnabled = false;
                button2.IsEnabled = true;
            }
        }

      

        private delegate void UpdateUiTextDelegate(string text);
        private void Recieve(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            recieved_data = serialPort1.ReadLine();
            Dispatcher.Invoke(DispatcherPriority.Send, new UpdateUiTextDelegate(LineReceived), recieved_data);
        }

        private void LineReceived(string line)
        {
            
            try
            {
                label1Temperature.Content = line;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            

        }

        private void button2Disconnect_Click(object sender, RoutedEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();

                button1.IsEnabled = true;
                button2.IsEnabled = false;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
        }
      
    }
}
