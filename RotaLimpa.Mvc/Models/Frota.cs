using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.Models
{
    public class Frota
    {
        public int Id { get; set; }
        public string P_Veiculo { get; set; }
        public double Tmn_Veiculo { get; set; }
        public DateTime Di_Veiculo { get; set; }
        public string St_Veiculo { get; set; }
        public Kilometragem? Kilometragem { get; set;}
        public ICollection<SetorVeiculo>? SetorVeiculos { get; set; }
        public ICollection<Trajeto>? Trajetos { get; set; }
    }
}
