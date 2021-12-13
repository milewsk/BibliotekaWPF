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
    /// Logika interakcji dla klasy SingleGroupPage.xaml
    /// </summary>
    public partial class SingleGroupPage : Page
    {
        private readonly GroupModel groupModel = new GroupModel();

        private readonly Group group = new Group();

        public List<string> UsersNames = new List<string>();
        public SingleGroupPage(string groupName)
        {
            using (var context = new Context.AppContext())
            {
                var bookQuery = (from b in context.Groups where b.Name == groupName select b).First();
                var IsMember = (from x in context.User_Groups where x.IdUser == Views.Navbar.getUser().Id && x.IdGroup == bookQuery.Id select x).Any();
                var allUsers = (from x in context.User_Groups where  x.IdGroup == bookQuery.Id select x.IdUser).ToList();
                group = bookQuery;

                if (IsMember)
                {
                    buttonAdd.Content = "Odejdź";
                }

                foreach(var user in allUsers)
                {
                    var que = (from u in context.Users where user == u.Id select u.Username).First();
                    UsersNames.Add(que);
                }

            }

            InitializeComponent();
            this.Navbar.Content = new Navbar();
            this.Sidebar.Content = new SideBar();
        }

        public void AddToGroup(object sender, RoutedEventArgs e)
        {
          
            // powtierdzenia
            ((MainWindow)System.Windows.Application.Current.MainWindow).MainView.Content = new BooksPage();
        }
    }
}
