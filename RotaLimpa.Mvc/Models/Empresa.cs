using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Dc_Empresa { get; set; }
        public string St_Empresa { get; set; }
        public DateTime Di_Empresa { get; private set; } = DateTime.Now;
        public DateTime? Da_Empresa { get; private set; } = DateTime.Now;
        public ICollection<Colaborador> Colaboradores { get; set; }
        public ICollection<Setor> Setores { get; set; }

    }
}
