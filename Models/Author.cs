using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BibliotekaWPF.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        public string Surname { get; set; }
        public ICollection<Book> Books { get; set; }
        public Author()
        {

        }

        public Author(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }

    }
}
