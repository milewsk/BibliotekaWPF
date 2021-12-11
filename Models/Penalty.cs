using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BibliotekaWPF.Attributes;

namespace BibliotekaWPF.Models
{
   public class Penalty
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Sum { get; set; }

        [DateColumn]
        public DateTime Date { get; set; }
        [Required]
        public int LoanID { get; set; }
        public Loan loan { get; set; }
    }
}
