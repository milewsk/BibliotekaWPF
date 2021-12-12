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
    /// Logika interakcji dla klasy BookAdvancePage.xaml
    /// </summary>
    public partial class BookAdvancePage : Page
    {
        private readonly BookModel bookModel = new BookModel();

        private readonly Book book = new Book();
        public BookAdvancePage(string str)
        {
            using (var context = new Context.AppContext()) {
                var bookQuery = (from b in context.Books where b.Title == str select b).First();
                book = bookQuery;
            }

                InitializeComponent();

        }

        public void BorrowBook(object sender, RoutedEventArgs e)
        {
            bookModel.BorrowBook(book.Title);
        }

        public void BuyBook(object sender, RoutedEventArgs e)
        {
            bookModel.BuyBook(book.Title);
        }

        public void GoBack(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).MainView.Content = new BooksPage();
        }
    }
}
