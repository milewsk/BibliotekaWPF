using BibliotekaWPF.Models;
using BibliotekaWPF.ViewModel;
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
    /// Logika interakcji dla klasy UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {

        private static User CurrentUser = new User();
        private AccountModel accountModel = new AccountModel();
        public UserPage()
        {
            CurrentUser = Views.Navbar.getUser();
            InitializeComponent();
            this.Navbar.Content = new Navbar();
            this.Sidebar.Content = new SideBar();

        }

        public void ChangePassword(object sender, RoutedEventArgs e)
        {
           string oldPassword = oldPasswordTextBox.Text;
           string newPassword = newPassowrdTextBox.Text;
            if (oldPassword != CurrentUser.Password)
            {
                //
            }
            else { 
            if(newPassword.Length >4 && !char.IsUpper(newPassword[0]))
                {
                    accountModel.EditPassword(newPassword);
                    //
                    accountModel.LogOut();
                    ((MainWindow)System.Windows.Application.Current.MainWindow).MainView.Content = new HomePage();
                }
                else
                {
                    //
                }
            }
        }
    }
}
