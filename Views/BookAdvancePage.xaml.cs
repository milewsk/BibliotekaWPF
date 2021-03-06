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
        private readonly Author author = new Author();
        public BookAdvancePage(int str)
        {
            string catName;               
            using (var context = new Context.AppContext()) {
                var bookQuery = (from b in context.Books where b.Id == str select b).First();
                catName = (from c in context.Categories where c.Id == bookQuery.IdCategory select c.Name).First();
                author = (from a in context.Authors where a.Id == bookQuery.AuthorId select a).First();
                book = bookQuery;
               
            }

            InitializeComponent();
            this.Navbar.Content = new Navbar();
            this.Sidebar.Content = new SideBar();

            TitleText.Text += book.Title;
            CategoryText.Text += catName;
            PriceText.Text += book.Price.ToString();
            AuthorText.Text += author.Name +" " + author.Surname;
            DateText.Text += book.YearPublished.ToString();
            AvailableText.Text += book.Available > 0 ? "Tak" : "Nie";
        }

        public void BorrowBook(object sender, RoutedEventArgs e)
        {
            if (book.Available > 0)
            {
                bookModel.BorrowBook(book.Title);
                ((MainWindow)System.Windows.Application.Current.MainWindow).MainView.Content = new BooksPage();
                Komunikat kom = new Komunikat("Wypożyczono książkę", true);
                kom.Show();
            }
            else
            {
                Komunikat kom = new Komunikat("Książka nie jest dostępna", false);
                kom.Show();
            }

            // powtierdzenia
      
        }

        public void BuyBook(object sender, RoutedEventArgs e)
        {
            if (book.Available > 0)
            {
                bookModel.BuyBook(book.Title);
                ((MainWindow)System.Windows.Application.Current.MainWindow).MainView.Content = new BooksPage();
                Komunikat kom = new Komunikat("Zakupiono książkę", true);
                kom.Show();
            }
            else
            {
                Komunikat kom = new Komunikat("Książka nie jest dostępna", false);
                kom.Show();
            }
            // powtierdzenia
            
        }

        public void GoBack(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).MainView.Content = new BooksPage();
        }
    }
}
