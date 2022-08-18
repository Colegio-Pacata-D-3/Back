using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio_PacataD3.Models
{
    public class Note
    {
        public int Id { get; set; }
        public int IdEst { get; set; }
        public string Area { get; set; }
        public int Grade { get; set; }
        public int Trimester { get; set; }
        public int Ser { get; set; }
        public int Saber1 { get; set; }
        public int Saber2 { get; set; }
        public int Saber3 { get; set; }
        public int Saber4 { get; set; }
        public int Hacer1 { get; set; }
        public int Hacer2 { get; set; }
        public int Hacer3 { get; set; }
        public int Hacer4 { get; set; }
        public int Decidir { get; set; }
        public int SerE { get; set; }
        public int DecidirE { get; set; }

    }
}
