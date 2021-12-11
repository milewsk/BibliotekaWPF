using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace BibliotekaWPF.Models
{
   public class Group
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<User_Group> User_Groups { get; set; }

        public int MembersCount { get; set; }

        public ICollection<Meeting> Meetings { get; set; }
    }
}
