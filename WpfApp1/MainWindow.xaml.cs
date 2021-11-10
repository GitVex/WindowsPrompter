using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;

namespace WpfApp1
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            watermark(Searchbox, Searchbox_Watermark, "Suchen ...");
        }

        private void watermark(TextBox Controller, TextBlock Watermark, string msg)
        {
            Watermark.Text = msg;
            Watermark.Opacity = .3;
            Watermark.Foreground = Brushes.Black;

            Controller.Text = string.Empty;
        }

        private void Searchbox_GotFocus(object sender, RoutedEventArgs e)
        {
            Searchbox.Foreground = Brushes.LightGray;
            Searchbox_Watermark.Text = string.Empty;
        }

        private void Searchbox_LostFocus(object sender, RoutedEventArgs e)
        {
            watermark(Searchbox, Searchbox_Watermark, "Suchen ...");
        }

        private void Searchbox_TextChanged(object sender, RoutedEventArgs e)
        {
            Searchbox.IsReadOnly = true;
            if (!(Searchbox.Text == string.Empty))
            {
                //insert code for parsing the textbox Text to python.
                try
                {
                    //C:\\VSProjects\\WpfApp1\\PythonCLI\\CLIExec.py
                    // This is only for the Debug environemnt path
                    var currentPath = AppDomain.CurrentDomain.BaseDirectory;
                    var pythonPath = System.IO.Path.Combine(currentPath, @"..\..\..\..\PythonCLI\CLIExec.py");
                    pythonPath = System.IO.Path.GetFullPath(pythonPath);
                    pythonPath += ' ' + Searchbox.Text.Replace(' ', '-');

                    ProcessStartInfo pythonStartInfo = new ProcessStartInfo
                    {
                        //FileName = Environment.ExpandEnvironmentVariables("%PYTHON%"),
                        FileName = @"python.exe",
                        Arguments = pythonPath,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    Process python = new Process();
                    python.StartInfo = pythonStartInfo;
                    python.EnableRaisingEvents = true;
                    python.OutputDataReceived += Python_OutputDataRecieved;

                    python.Start();
                    python.BeginOutputReadLine();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                if (Resultbox.Height < 200)
                {
                    Resultbox.Height += 10;
                }

            } 
            else
            {
                Resultbox.Height = 50;
            }
            Searchbox.IsReadOnly = false;
        }

        private void Python_OutputDataRecieved(object sender, DataReceivedEventArgs e)
        {
        
        }
    }
}
