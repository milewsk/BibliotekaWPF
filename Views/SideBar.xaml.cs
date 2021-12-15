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
    /// Logika interakcji dla klasy SideBar.xaml
    /// </summary>
    public partial class SideBar : UserControl
    {
       
        public SideBar()
        {
            InitializeComponent();
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            ExitWindow exitWin = new ExitWindow();
            exitWin.Show();
        }

        public void BookPage(object sender, RoutedEventArgs e)
        {
            if (Views.Navbar.getUser() != null)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).MainView.Content = new BooksPage();
            }
        }

        public void GruopPage(object sender, RoutedEventArgs e)
        {
            if (Views.Navbar.getUser() != null)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).MainView.Content = new GroupsPage();
            }
        }

        public void LoanPage(object sender, RoutedEventArgs e)
        {
            if (Views.Navbar.getUser() != null)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).MainView.Content = new LoansPage();
            }
        }
    }
}
