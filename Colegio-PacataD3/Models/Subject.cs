using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio_PacataD3.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public int IdTeacher { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }
    }
}
