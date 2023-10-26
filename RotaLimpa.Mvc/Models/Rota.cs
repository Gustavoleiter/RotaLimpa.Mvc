using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.Models
{
    public class Rota
    {
        

        public int IdRota { get; set; }

        public int ColaboradorId { get; set; }
        public Colaborador Colaborador { get; set; }
      
        public int SetorId { get; set; }

        public Setor Setor { get; set; }

        public int DtRota { get; set; }

        public int TmRota { get; set; }
    }
}
