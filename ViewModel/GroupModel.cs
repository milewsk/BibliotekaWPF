using BibliotekaWPF.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BibliotekaWPF.Views;

namespace BibliotekaWPF.ViewModel
{
    class GroupModel
    {
        IList<Group> groups = new List<Group>();

        private User currentUser { get; set; }


        public List<string> GetAllGroups()
        {
            List<string> groups = new List<string>();
            using (var context = new Context.AppContext())
            {
                var query = (from g in context.Groups select g.Name).ToList();
                foreach (string book in query)
                {
                    groups.Add(book);
                }
            }
            return groups;
        }

        public List<string> GetMembers(string groupName)
        {
            List<string> users = new List<string>();
            using (var context = new Context.AppContext())
            {
                var group = (from b in context.Groups where b.Name == groupName select b.Id).First();
                var members = (from X in context.User_Groups where X.IdGroup == @group && X.IdUser == Views.Navbar.getUser().Id select X).ToList();

                foreach(var member in members)
                {
                    var user = (from u in context.Users where u.Id == member.IdUser select u).First();
                    users.Add(user.Username);
                }
            }

            return users;
        }

        public bool IsMember(string groupName)
        {
            using (var context = new Context.AppContext())
            {
                var group = (from b in context.Groups where b.Name == groupName select b.Id).First();
                var Joined = (from X in context.User_Groups where X.IdGroup == @group && X.IdUser == Views.Navbar.getUser().Id select X).Any();

                if (Joined) {
                    return true;
                }
            }
                return false;
        }

        public void JoinGroup(string groupName)
        {
            using (var context = new Context.AppContext())
            {
                var group = (from b in context.Groups where b.Name == groupName select b).First();
                if (!IsMember(groupName))
                {
                    context.User_Groups.Add(new User_Group() { IdGroup = group.Id, IdUser = Views.Navbar.getUser().Id });
                    context.SaveChanges();

                }
            }
        }

        public void LeaveGroup(string groupName)
        {
            using (var context = new Context.AppContext())
            {
                var group = (from b in context.Groups where b.Name == groupName select b).First();
                if (IsMember(groupName))
                {
                    var query = (from g in context.User_Groups where g.IdGroup == @group.Id && g.IdUser == Views.Navbar.getUser().Id select g).First();
                    context.User_Groups.Remove(query);
                    context.SaveChanges();

                }
            }
        }
    }
}
