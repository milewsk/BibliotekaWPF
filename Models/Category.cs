using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BibliotekaWPF.Models
{
   public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; private set; } = new ObservableCollection<Book>();
    }
}
