using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.Models
{
    public class SetorVeiculo
    {
        public int IdSetor { get; set; }
        public int IdFrota { get; set; }
        public Setor Setor { get; set; }
        public Frota Frota { get; set; }
    }
}
