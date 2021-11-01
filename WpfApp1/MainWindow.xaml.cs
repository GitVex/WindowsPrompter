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

            if (!(Searchbox.Text == string.Empty))
            {
                //insert code for parsing the textbox Text to python.
                if (Resultbox.Height < 200)
                {
                    Resultbox.Height += 10;
                }
            } 
            else
            {
                Resultbox.Height = 50;
            }
        }


        /*TODO List:
        - add dropdown box that expands with each new search hit
            - Dropdown functionality:
                - Whenver the searchbox is not blank and focused, listen for new search hits and if found, expand the dropdown
            - Search algorythm:
                Deconstruction of the prompt into keywords.
                e.g. "start firefox" deconstructs to 'start' and 'firefox', starting firefox
                "python" starts a python terminal
                "google <keyword>" googles a certain keyword in the standard browser - https://www.scaleserp.com/docs/search-api/overview
                "open <directory>" opens a given filepath
                "uninstall <program>" uninstalls a program - https://www.webiboo.com/how-to-uninstall-programs-using-command-prompt
                "webopen <keyword | website>" opens a website, if there is no valid url given it will open the first google search hit that is not an ad - https://www.scaleserp.com/docs/search-api/overview
        - add python link for command line invokation
        - center text horizontally
        - add library of search terms
        - add visibility Toggle on hotkey and enter
        - add options menu for:
            - localised program index
            - changing hotkeys
            - changing color scheme
        - add context-based command palettes:
            - if opened when explorer is focused:
                - "add <filetype> <filename>" adds a new file
                - "symbols <small, large, list, etc.>" changes iconsize of the current directory
            - if opened when browser is open:
                - "new tab" opens a new tab
                - ""
  
        */
    }
}
