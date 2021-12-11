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
    /// Logika interakcji dla klasy Navbar.xaml
    /// </summary>
    public partial class Navbar : UserControl
    {
      public static User CurrentUser { get; set; }
      private AccountModel accountModel { get; set; }

        public Navbar()
        {
            InitializeComponent();
            if(CurrentUser != null)
           {
                NavbarButton2.Content = "Moje konto";
                NavbarButton3.Content = "Wyloguj się";
                if (CurrentUser.isAdmin == 1) 
                {
                    NavbarButton1.Visibility = Visibility.Visible;
                }
            }
            
        }
        public static void setUser(User user)
        {
            CurrentUser = user;
        }
        public static User getUser()
        {
            return CurrentUser;
        }

        //może tu zrobić parametry w konsztruktorze

        public void Button1(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).MainView.Content = new AdminPanelView();
        }

        public void Button2(object sender, RoutedEventArgs e)
        {
            if (CurrentUser == null)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).MainView.Content = new LoginPage();
            }
            else
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).MainView.Content = new UserPage();
            }
        }
        public void Button3(object sender, RoutedEventArgs e)
        {
            if (CurrentUser == null)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).MainView.Content = new RegisterPage();
            }
            else
            {
                //logout
                accountModel.LogOut();
                ((MainWindow)System.Windows.Application.Current.MainWindow).MainView.Content = new HomePage();
            }
        }
    }

 }

