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
    /// Logika interakcji dla klasy SingleLoanPage.xaml
    /// </summary>
    public partial class SingleLoanPage : Page
    {
        private readonly BookModel bookModel = new BookModel();

        private readonly Book book = new Book();

        private readonly Loan loan = new Loan();
        public SingleLoanPage(string id)
        {
            InitializeComponent();
            int zz = int.Parse(id);

            this.Navbar.Content = new Navbar();
            this.Sidebar.Content = new SideBar();

            using (var context = new Context.AppContext())
            {
                var bookQuery = (from b in context.Books where b.Id == zz select b).First();
                loan = (from l in context.Loans where zz == l.Id select l).First(); 
               
                book = bookQuery;

            }

            TitleText.Text += book.Title;
            DateOfLoanText.Text += loan.DateOfLoan.ToShortDateString();
            DateOfReturnText.Text += loan.ReturnDate.ToShortDateString();
            DateOfUserReturnText.Text += bookModel.getUserReturnDate(zz);
            PriceText.Text += bookModel.showPenaltyPrice(zz);

            if (bookModel.isLoanFinished(zz))
            {
                ReturnButton.Visibility = Visibility.Collapsed;
            }
        }

        public void GoBack(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).MainView.Content = new BooksPage();
        }

        public void ReturnBook(object sender, RoutedEventArgs e)
        {
            if (loan.IsReturned == 0)
            {
                bookModel.PayPenalty(loan);
            }
          // powtierdzenia
          ((MainWindow)System.Windows.Application.Current.MainWindow).MainView.Content = new SingleLoanPage(loan.Id.ToString());
        }

    }
}
