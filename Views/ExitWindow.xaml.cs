using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BibliotekaWPF.Views
{
    /// <summary>
    /// Logika interakcji dla klasy ExitWindow.xaml
    /// </summary>
    public partial class ExitWindow : Window
    {
        public ExitWindow()
        {
            InitializeComponent();
        }

        public void cancelExit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void confirmExit(object sender, RoutedEventArgs e) {
            // wyloguj
            this.Close();
            Environment.Exit(0);
        }
    }
}
