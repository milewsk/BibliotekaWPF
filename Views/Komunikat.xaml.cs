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
    /// Logika interakcji dla klasy Komunikat.xaml
    /// </summary>
    public partial class Komunikat : Window
    {
        public Komunikat(string message, bool isGood)
        {
            InitializeComponent();
            messageText.Text = message;
            if (isGood)
            {
                messageText.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                messageText.Foreground = new SolidColorBrush(Colors.Red);
            }
        }
        public void confirmExit(object sender, RoutedEventArgs e)
        {
            // wyloguj
            this.Close();
           
        }
    }
}
