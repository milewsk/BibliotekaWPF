using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BibliotekaWPF.Models
{
   public class PersonModel
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public PersonModel() {
            Task.Run(() => {
                while (true)
                {
                    Debug.WriteLine($"Name: {Name}");
                    Thread.Sleep(500);
                }
            });
        }

    }
}
