using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio_PacataD3.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Birth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int NumberReference { get; set; }
    }
}
