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
using System.Linq;
using System.Windows.Shapes;

namespace BibliotekaWPF.Views
{
    /// <summary>
    /// Logika interakcji dla klasy UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        private readonly BookModel bookModel = new BookModel();
        private static User CurrentUser = new User();
        private AccountModel accountModel = new AccountModel();

        public List<TextBlock> PurchaseList = new List<TextBlock>();
        public UserPage()
        {
           
            CurrentUser = Views.Navbar.getUser();
            InitializeComponent();
            buyList.ItemsSource = null;
            this.Navbar.Content = new Navbar();
            this.Sidebar.Content = new SideBar();

            using (var context = new Context.AppContext())
            {
                var Purchases = (from c in context.Purchases where c.UserId == Views.Navbar.getUser().Id select c).ToList();

                foreach (var pur in Purchases)
                {
                    var book = (from x in context.Books where x.Id == pur.BookId select x).FirstOrDefault();
                    var textblock = new TextBlock()
                    {
                        Foreground = new SolidColorBrush(Colors.White),
                        FontSize = 15,
                        HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                        Margin = new Thickness(0, 10, 0, 10),
                    };
                    textblock.Text ="Tytuł: "+ book.Title +"Data: "+ pur.Date.ToShortDateString() +" Cena: "+book.Price;
                    PurchaseList.Add(textblock);
                }

                buyList.ItemsSource = PurchaseList;

            }

        }

        public void ChangePassword(object sender, RoutedEventArgs e)
        {
           string oldPassword = oldPasswordTextBox.Text;
           string newPassword = newPassowrdTextBox.Text;
            if (oldPassword != CurrentUser.Password)
            {
                Komunikat kom = new Komunikat("Hasło jest identyczne jak poprzednie", false);
                kom.Show();
            }
            else { 
            if(newPassword.Length >4 && char.IsUpper(newPassword[0]))
                {
                    accountModel.EditPassword(newPassword);                    
                    accountModel.LogOut();
                    ((MainWindow)System.Windows.Application.Current.MainWindow).MainView.Content = new HomePage();
                    Komunikat kom = new Komunikat("Hasło zostało pomyślnie zmienione", true);
                    kom.Show();
                }
                else
                {
                    Komunikat kom = new Komunikat("Hasło nie spełnia wymogów", true);
                    kom.Show();
                }
            }
        }
    }
}
