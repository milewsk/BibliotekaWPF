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

        public List<TextBlock> UsersNames = new List<TextBlock>();

        public List<TextBlock> Meetings = new List<TextBlock>(); 
        public SingleGroupPage(string groupName)
        {
             
            InitializeComponent();

            memberList.ItemsSource = null;
            meetingList.ItemsSource = null;
            using (var context = new Context.AppContext())
            {
                var bookQuery = (from b in context.Groups where b.Name == groupName select b).First();              
                var IsMember = (from x in context.User_Groups where x.IdUser == Views.Navbar.getUser().Id && x.IdGroup == bookQuery.Id select x).Any();
                var allUsers = (from x in context.User_Groups where x.IdGroup == bookQuery.Id select x.IdUser).ToList();
                var allMeetings = (from x in context.Meetings where x.IdGroup == bookQuery.Id select x).ToList();
                group = bookQuery;

                NameTextBlock.Text = group.Name;
                CountTextBlock.Text += group.MembersCount.ToString();

                if (IsMember)
                {
                    buttonAdd.Content = "Odejdź";
                }

                foreach (var user in allUsers)
                {
                    var que = (from u in context.Users where user == u.Id select u.Username).First();
                    var textblock = new TextBlock()
                    {
                        Foreground = new SolidColorBrush(Colors.White),
                        FontSize = 15,
                        HorizontalAlignment =  System.Windows.HorizontalAlignment.Center,
                        Margin = new Thickness(0, 10, 0, 10),
                    }; 
                    textblock.Text = que;
                    UsersNames.Add(textblock);
                }

                foreach(var meeting in allMeetings)
                {
                    var textblock = new TextBlock()
                    {
                        Foreground = new SolidColorBrush(Colors.White),
                        FontSize = 15,
                        HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                        Margin = new Thickness(0, 10, 0, 10),
                    };
                    textblock.Text = $"Data: {meeting.Date.ToShortDateString()} Czas trwania: {meeting.Duration} min";                  
                    Meetings.Add(textblock);
                }

                memberList.ItemsSource = UsersNames;
                meetingList.ItemsSource = Meetings;
            }


            this.Navbar.Content = new Navbar();
            this.Sidebar.Content = new SideBar();
        }

        public void AddToGroup(object sender, RoutedEventArgs e)
        {
           
                if (groupModel.IsMember(group.Name))
                {
                    groupModel.LeaveGroup(group.Name);                
                }
                else
                {
                    groupModel.JoinGroup(group.Name);               
                }                      
            // powtierdzenia
            ((MainWindow)System.Windows.Application.Current.MainWindow).MainView.Content = new SingleGroupPage(group.Name);
        }
    }
}
