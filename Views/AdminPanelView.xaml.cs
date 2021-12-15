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
using System.Linq;

namespace BibliotekaWPF.Views
{
    /// <summary>
    /// Logika interakcji dla klasy AdminPanelView.xaml
    /// </summary>
    public partial class AdminPanelView : Page
    {
        private readonly BookModel bookModel = new BookModel();
        private readonly GroupModel groupModel = new GroupModel();

        private readonly Book book = new Book();
        private readonly Author author = new Author();
        public AdminPanelView()
        {
            InitializeComponent();
            this.Navbar.Content = new Navbar();
            this.Sidebar.Content = new SideBar();
        }

        public void Books(object sender, RoutedEventArgs e)
        {
            // powtierdzenia
            GroupGrid.Visibility = Visibility.Collapsed;
            MeetingsGrid.Visibility = Visibility.Collapsed;
            BookGrid.Visibility = Visibility.Visible;

         
        }
        public void Groups(object sender, RoutedEventArgs e)
        {
            // powtierdzenia
            BookGrid.Visibility = Visibility.Collapsed;
            MeetingsGrid.Visibility = Visibility.Collapsed;
            GroupGrid.Visibility = Visibility.Visible;
          

        }
        public void Meetings(object sender, RoutedEventArgs e)
        {
            // powtierdzenia
            BookGrid.Visibility = Visibility.Collapsed;
            GroupGrid.Visibility = Visibility.Collapsed;
            MeetingsGrid.Visibility = Visibility.Visible;

        }

        public void AddGroup(object sender, RoutedEventArgs e)
        {
            // powtierdzenia
            if (groupModel.AddGroup(nameGroupText.Text))
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).MainView.Content = new AdminPanelView();
                Komunikat kom = new Komunikat("Dodano grupę", true);
                kom.Show();
            }
            else
            {
                Komunikat kom = new Komunikat("Błąd w podanych danych", false);
                kom.Show();
            }

        }
        public void DeleteGroup(object sender, RoutedEventArgs e)
        {
            // powtierdzenia
            if (groupModel.DeleteGroup(namegroupToDelete.Text))
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).MainView.Content = new AdminPanelView();
                Komunikat kom = new Komunikat("Usunięto grupę", true);
                kom.Show();
            }
            else
            {
                Komunikat kom = new Komunikat("Nie znaleziono grupy", false);
                kom.Show();
            }

        }

        public void AddMeeting(object sender, RoutedEventArgs e)
        {

            // powtierdzenia
            if (groupModel.AddMeeting(meetingGroupText.Text, dateMeetingText.SelectedDate.Value,DurationTimeText.Text))
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).MainView.Content = new AdminPanelView();
                Komunikat kom = new Komunikat("Dodano spotkanie", true);
                kom.Show();
            }
            else
            {
                Komunikat kom = new Komunikat("Błąd w podawaniu danych", false);
                kom.Show();
            }

        }

        public void AddBook(object sender, RoutedEventArgs e)
        {
            // powtierdzenia
            if(bookModel.AddBook(titleBox.Text, nameAuthor.Text, surnameAuthor.Text, dateBox.Text, priceBox.Text, categoryBox.Text, quantityBox.Text))
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).MainView.Content = new AdminPanelView(); 
                Komunikat kom = new Komunikat("Dodano książkę", true);
                kom.Show();
            }
              else
            {
                Komunikat kom = new Komunikat("Błąd w podanych danych", false);
                kom.Show();
            }
          
        }

        public void DeleteBook(object sender, RoutedEventArgs e)
        {
            // powtierdzenia
            if (bookModel.DeleteBook(titleBoxToDelete.Text, quantityBoxToDelete.Text)) {
                ((MainWindow)System.Windows.Application.Current.MainWindow).MainView.Content = new AdminPanelView();
                Komunikat kom = new Komunikat("Usunięto książkę", true);
                kom.Show();
            }
            else
            {
                Komunikat kom = new Komunikat("Błąd w podanych danych", false);
                kom.Show();
            }

        }
    }
}
