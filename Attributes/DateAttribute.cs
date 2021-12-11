using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BibliotekaWPF.Attributes
{
    public class DateColumnAttribute : ColumnAttribute
    {
        public DateColumnAttribute()
        {
            TypeName = "DateTime";
        }
    }
}
