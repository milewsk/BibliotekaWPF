using BibliotekaWPF.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BibliotekaWPF.Views;
using Microsoft.EntityFrameworkCore;

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
                {
                if (!IsMember(groupName))
                    context.User_Groups.Add(new User_Group() { IdGroup = group.Id, IdUser = Views.Navbar.getUser().Id });
                    group.MembersCount++;
                    context.Attach(group).State = EntityState.Modified;
                    context.SaveChanges();

                }
            }
        }

        public void LeaveGroup(string groupName)
        {
            using (var context = new Context.AppContext())
            {
                var group = (from b in context.Groups where b.Name == groupName select b).First();
              
                    var query = (from g in context.User_Groups where g.IdGroup == @group.Id && g.IdUser == Views.Navbar.getUser().Id select g).First();
                    context.User_Groups.Remove(query);
                    group.MembersCount--;
                    context.Attach(group).State = EntityState.Modified;
                    context.SaveChanges();              
            }
        }

        public bool AddMeeting(string groupName, DateTime date, string durationStr)
        {
            int duration;
           bool pr1 = int.TryParse(durationStr, out duration);
            if (pr1)
            {
                using (var context = new Context.AppContext())
                {
                    var validGroup = (from x in context.Groups where x.Name == groupName select x).Any();
                    if(validGroup || date > DateTime.Now)
                    {
                        var groupID = (from x in context.Groups where x.Name == groupName select x.Id).First();
                        Meeting newMeet = new Meeting() { IdGroup = groupID, Duration = duration, Date = date };
                        context.Meetings.Add(newMeet);
                        context.SaveChanges();

                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }
        public bool AddGroup(string groupName)
        {
            using (var context = new Context.AppContext())
            {
                var validGroup = (from x in context.Groups where x.Name == groupName select x).Any();
                if (validGroup)
                {
                    return false;
                }
                else
                {
                    Group newGroup = new Group() { Name = groupName, MembersCount = 0 };
                    context.Groups.Add(newGroup);
                    context.SaveChanges();
                }
            }
                return true;
        }
        public bool DeleteGroup(string groupName)
        {
            using (var context = new Context.AppContext())
            {
                var validGroup = (from x in context.Groups where x.Name == groupName select x).Any();
                if (validGroup)
                {
                    var gr = (from x in context.Groups where x.Name == groupName select x).First();
                    context.Groups.Remove(gr);
                    context.SaveChanges();
                }
                else
                {
                    return false;
                }
            }
                return true;
        }
    }
}
