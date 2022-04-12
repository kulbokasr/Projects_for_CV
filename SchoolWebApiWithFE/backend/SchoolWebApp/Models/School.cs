using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebApp.Models
{
    public class School : NamedEntity
    {
        public List<Student> Students { get; set; }
    }
}
