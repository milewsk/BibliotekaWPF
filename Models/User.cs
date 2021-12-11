using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BibliotekaWPF.Models
{
   public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(6), MaxLength(25)]
        public string Username { get; set; }
        [Required]
        [MinLength(4), MaxLength(25)]
        public string Password { get; set; }

        [Required]
        [Range(0, 1)]
        public int isAdmin { get; set; }

        public IList<User_Group> User_Groups { get; set; }

        public ICollection<Penalty> Penalties { get; set; }

        public ICollection<Loan> Loans { get; set; }

        public ICollection<Purchase> Purchases { get; set; }
        public User() { }

        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }
    }
}
