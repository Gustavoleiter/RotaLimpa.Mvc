using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.Models
{
    public class Trajeto
    {
        public int Id { get; set; }
        public int IdMotorista { get; set; }
        public int IdRota {  get; set; }
        public int IdPeriodo { get; set; }
        public int IdFrota { get; set; }
        public DateTime Mi_Trajeto { get; set; }
        public DateTime Mf_Trajeto { get; set; }
        public ICollection<Ocorrencia> Ocorrencias { get; set; }
        public Frota Frota { get; set; }
        public Rota Rota { get; set; }
    }
}
