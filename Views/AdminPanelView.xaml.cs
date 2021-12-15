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
            BookGrid.Visibility = Visibility.Visible;
         
        }
        public void Groups(object sender, RoutedEventArgs e)
        {
            // powtierdzenia
           
        }
        public void Meetings(object sender, RoutedEventArgs e)
        {
            // powtierdzenia
          
        }

        public void AddBook(object sender, RoutedEventArgs e)
        {
           // powtierdzenia
           bookModel.AddBook(titleBox.Text, nameAuthor.Text, surnameAuthor.Text, dateBox.Text, priceBox, categoryBox.Text,)
           ((MainWindow)System.Windows.Application.Current.MainWindow).MainView.Content = new BooksPage();
        }

        public void DeleteBook(object sender, RoutedEventArgs e)
        {
           // powtierdzenia
           ((MainWindow)System.Windows.Application.Current.MainWindow).MainView.Content = new BooksPage();
        }
    }
}
