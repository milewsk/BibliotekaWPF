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
    /// Logika interakcji dla klasy LoansPage.xaml
    /// </summary>
    public partial class LoansPage : Page
    {
        private readonly BookModel bookModel = new BookModel();
        public LoansPage()
        {
           
            InitializeComponent();

            loansList.ItemsSource = null;
            this.Navbar.Content = new Navbar();
            this.Sidebar.Content = new SideBar();

            List<string> loans = bookModel.GetLoans();
            List<Button> buttonGroups = new List<Button>();
            Dictionary<int, string> loans1 = bookModel.GetLoans1();

            foreach ( var str in loans1)
            {
                Button btn = new Button()
                {
                    FontSize = 15,
                    Style = FindResource("CustomButton") as Style,
                    Margin = new Thickness(0, 10, 0, 10),

                }; ;
                btn.Content = str.Value;
                btn.Click += new RoutedEventHandler(LoanAdvance);
                btn.Tag = str.Key.ToString();

                buttonGroups.Add(btn);
            }
            loansList.ItemsSource = buttonGroups;
        }

        private void LoanAdvance(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string str = button.Tag.ToString();
            ((MainWindow)System.Windows.Application.Current.MainWindow).MainView.Content = new SingleLoanPage(str);
        }
    }
}
