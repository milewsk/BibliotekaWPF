using BibliotekaWPF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotekaWPF.Models
{
   public class User_Group
    {
        public int IdUser { get; set; }

        public User User { get; set; }

        public int IdGroup { get; set; }

        public Group Group { get; set; }
    }
}
