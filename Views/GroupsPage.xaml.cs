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
    /// Logika interakcji dla klasy GroupsPage.xaml
    /// </summary>
    public partial class GroupsPage : Page
    {
        private readonly GroupModel groupModel = new GroupModel();
        public GroupsPage()
        {
            InitializeComponent();

            this.Navbar.Content = new Navbar();
            this.Sidebar.Content = new SideBar();

            List<string> groups = groupModel.GetAllGroups();
            List<Button> buttonGroups = new List<Button>();

            foreach (string str in groups)
            {
                Button btn = new Button();
                btn.Content = str;
                btn.Click += new RoutedEventHandler(GroupAdvance);

                buttonGroups.Add(btn);
            }
            datesList.ItemsSource = buttonGroups;
        }

        public void GroupAdvance(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string str = button.Content.ToString();
            ((MainWindow)System.Windows.Application.Current.MainWindow).MainView.Content = new SingleGroupPage(str);
        }
    }
}
