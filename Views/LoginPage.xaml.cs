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
using System.Text.RegularExpressions;
using BibliotekaWPF.Models;
using BibliotekaWPF.ViewModel;

namespace BibliotekaWPF.Views
{
    /// <summary>
    /// Logika interakcji dla klasy LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private static User CurrentUser = new User();
        private AccountModel accountModel = new AccountModel();
        public LoginPage()
        {
            InitializeComponent();
            this.Navbar.Content = new Navbar();
            this.Sidebar.Content = new SideBar();

        }

        public void Login(object sender, RoutedEventArgs e)
        {

            if (UsernameTextBox.Text.Length < 4 || UsernameTextBox.Text.Length > 20)
            {
                UsernameTextBox.Focus();
            }
            else if (PasswordTextBox.Text.Length < 4 || !char.IsUpper(PasswordTextBox.Text[0]))
            {
                PasswordTextBox.Focus();
            }
            else {
                string username = UsernameTextBox.Text;
                string password = PasswordTextBox.Text;
                CurrentUser = accountModel.Login(username, password);

                if(CurrentUser != null)
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).MainView.Content = new HomePage();
                }
                else
                {
                    //error jakby spełniał wymagania ale go nie było
                    PasswordTextBox.Text = "";
                }
               
            }
        }

        public void SignUpClick(object sender, RoutedEventArgs e) {
            ((MainWindow)System.Windows.Application.Current.MainWindow).MainView.Content = new RegisterPage();
        }
    }
}
