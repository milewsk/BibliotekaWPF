using BibliotekaWPF.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BibliotekaWPF.Models
{
   public class Purchase
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        [DateColumn]
        public DateTime Date { get; set; }
    }
}
