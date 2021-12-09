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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace BibliotekaWPF.Views
{
    /// <summary>
    /// Logika interakcji dla klasy Navbar.xaml
    /// </summary>
    public partial class Navbar : UserControl
    {
       
        public Navbar()
        {
            InitializeComponent();
            
        }
     
        //może tu zrobić parametry w konsztruktorze

        public Navbar(bool option)
        {

            InitializeComponent();
            ChangeDisplay(option);
        }
        public void ChangeDisplay(bool hi ) {
            if(hi) {
                b1.Content = "test display";
            }
            else
            {
                b1.Content = "Zaloguj";
            }
        }

    }
}
