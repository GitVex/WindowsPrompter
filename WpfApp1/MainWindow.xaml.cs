using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            watermark(Searchbox);
        }

        private void watermark(TextBox toWatermark)
        {
            toWatermark.Text = "Suchen ...";
            toWatermark.Opacity = 1;
            toWatermark.Foreground = Brushes.Black;
        }

        private void Searchbox_GotFocus(object sender, RoutedEventArgs e)
        {
            Searchbox.Text = string.Empty;
            Searchbox.Foreground = Brushes.LightGray;
        }
    }
}
