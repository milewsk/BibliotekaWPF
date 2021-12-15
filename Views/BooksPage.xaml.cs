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
    /// Logika interakcji dla klasy BooksPage.xaml
    /// </summary>
    public partial class BooksPage : Page
    {
        private readonly BookModel bookModel = new BookModel();
        public BooksPage()
        {
            InitializeComponent();

            this.Navbar.Content = new Navbar();
            this.Sidebar.Content = new SideBar();

            datesList.ItemsSource = null;
            List<string> books = bookModel.GetAllBooks();
            List<Button> buttonBooks = new List<Button>();

            foreach(string str in books)
            {
                Button btn = new Button()
                {
                    Style = FindResource("CustomButton") as Style,
                    Margin = new Thickness(0, 10, 0, 10),
                };
                btn.Content = str;
                btn.Click += new RoutedEventHandler(BookAdvance);

                buttonBooks.Add(btn);
            }
            datesList.ItemsSource = buttonBooks;
        }

        private void BookAdvance(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string str = button.Content.ToString();
            ((MainWindow)System.Windows.Application.Current.MainWindow).MainView.Content = new BookAdvancePage(str);
        }

        public void FilterClick(object sender, RoutedEventArgs e) 
        {
            //datesList.Items.Clear();
            datesList.ItemsSource = null;

            List<string> books = bookModel.GetFillteredBooks(FilterTextBox.Text);
            List<Button> buttonBooks = new List<Button>();

            foreach (string str in books)
            {
                Button btn = new Button()
                {
                    Style = FindResource("CustomButton") as Style,
                    Margin = new Thickness(0, 10, 0, 10),
                }; ;
                btn.Content = str;
                btn.Click += new RoutedEventHandler(BookAdvance);
                buttonBooks.Add(btn);
            }
            datesList.ItemsSource = buttonBooks;


        }
        public void Reset(object sender, RoutedEventArgs e)
        {
            datesList.ItemsSource = null;

            List<string> books = bookModel.GetAllBooks();
            List<Button> buttonBooks = new List<Button>();

            foreach (string str in books)
            {
                Button btn = new Button()
                {
                    Style = FindResource("CustomButton") as Style,
                    Margin = new Thickness(0, 10, 0, 10),
                }; ;
                btn.Content = str;
                btn.Click += new RoutedEventHandler(BookAdvance);

                buttonBooks.Add(btn);
            }
            datesList.ItemsSource = buttonBooks;

        }
    }
}
