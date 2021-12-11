using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BibliotekaWPF.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string Title { get; set; }

        [Required]
        public int AuthorId { get; set; }
        public Author BookAuthor { get; set; }

        [Required]
        [Range(0, 2021)]
        public int YearPublished { get; set; }

        [Required]
        public float Price { get; set; }

        public int IdCategory { get; set; }

        public Category Category { get; set; }

        [Required]
        public int Available { get; set; }

        public ICollection<Loan> Loans { get; set; }
    }
}
