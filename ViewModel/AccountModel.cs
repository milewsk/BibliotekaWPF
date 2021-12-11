using BibliotekaWPF.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BibliotekaWPF.Views;

namespace BibliotekaWPF.ViewModel
{
     class AccountModel
    {
        private readonly User user = Views.Navbar.getUser();

        private User currentUser { get; set; }

        public AccountModel() { }
        public User Login(string username, string password)
        {
            using (var context = new Context.AppContext())
            {
                bool checkUser = (from u in context.Users where username == u.Username && password == u.Password select u).Any();
                if (checkUser) {
                    currentUser = (from u in context.Users where username == u.Username && password == u.Password select u).First();
                    Navbar.setUser(currentUser);
                    return currentUser;
                }
                return null;
            }               
        }

        public void LogOut()
        {
            Views.Navbar.setUser(null);

        }

        public User SingUp(string username, string password)
        {
            User newUser = new User() {Username = username, Password = password };
            using (var context = new Context.AppContext())
            {
                bool checkUser = (from u in context.Users where username == u.Username && password == u.Password select u).Any();
                if (!checkUser)
                {
                    context.Add(newUser);
                    context.SaveChanges();
                    Navbar.setUser(newUser);
                    return newUser;
                }
                return null;
            }
            
        }

        public void DeleteAccount()
        {
            User userToDelete =  Navbar.getUser();
            using (var context = new Context.AppContext())
            {
                context.Users.Remove(userToDelete);
                context.SaveChanges();
            }
        }

        public void EditPassword(string newPassword)
        {
            using (var context = new Context.AppContext())
            {
                User editUser = user;
                if(editUser.Password != newPassword)
                {
                    var query = (from u in context.Users where editUser.Username == u.Username && u.Password == editUser.Password select u).First();
                    query.Password = newPassword;
                    context.Users.Update(query);
                
                }
            }
        }

    }
}
