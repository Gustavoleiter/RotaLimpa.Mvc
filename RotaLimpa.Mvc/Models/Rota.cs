using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.Models
{
    public class Rota
    {
        public int Id { get; set; }

        public int IdColaborador { get; set; }
      
        public int IdSetor { get; set; }

        public int Dt_Rota { get; set; }

        public int Tm_Rota { get; set; }
        public Colaborador? Colaborador { get; set; }
        public ICollection<Rua>? Ruas { get; set; }

        public ICollection<Trajeto>? Trajetos { get; set; }
    }
}
