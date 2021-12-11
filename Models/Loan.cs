using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BibliotekaWPF.Attributes;

namespace BibliotekaWPF.Models
{
  public class Loan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdBook { get; set; }
        public Book Book { get; set; }

        [Required]
        public int IdUser { get; set; }
        public User User { get; set; }

        [Required]
        [DateColumn]
        public DateTime DateOfLoan { get; set; }
        [Required]
        [DateColumn]
        public DateTime ReturnDate { get; set; }

        [Required]
        [Range(0, 1)]
        public int IsReturned { get; set; }


        [DateColumn]
        public DateTime UserReturn { get; set; }
        public Penalty Penalty { get; set; }
    }
}
