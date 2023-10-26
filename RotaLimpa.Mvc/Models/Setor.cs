using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.Models
{
    public class Setor
    {
        public ICollection<Rota>? Rotas { get; set; }

        public int Id { get; set; }

        public int ColaboradorId { get; set; }
        public Colaborador Colaborador { get; set; }

        public int EmpresaId { get; set; }

        public Empresa Empresa { get; set; }

        public DateTime DiSetor { get; private set; } = DateTime.Now;

        public DateTime DaSetor { get; set; }

        public string StSetor { get; set; }
    }
}
