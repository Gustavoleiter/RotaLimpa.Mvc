using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.Models
{
    public class Kilometragem
    {
        public int Id { get; set; }
        public double Km { get; set; }
        public DateTime Di_Kilometragem { get; set; }
        public virtual Frota? Frota { get; set; }
    }
}
