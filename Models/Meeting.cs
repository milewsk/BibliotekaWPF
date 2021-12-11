using BibliotekaWPF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BibliotekaWPF.Attributes;

namespace BibliotekaWPF.Models
{
  public class Meeting
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdGroup { get; set; }

        public Group Group { get; set; }

        [Required]
        [DateColumn]
        public DateTime Date { get; set; }
        [Required]
        public int Duration { get; set; }
    }
}
