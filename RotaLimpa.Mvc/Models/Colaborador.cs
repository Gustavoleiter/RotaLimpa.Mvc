using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.Models
{
    public class Colaborador
    {
        public ICollection<Setor>? Setores { get; set; }
        public ICollection<Rota>? Rotas { get; set; }

        public int Id { get; set; }

        public int EmpresaId { get; set; }
      
        public Empresa Empresa { get; set; }

      
        public string Nome { get; set; }

       
        public string DcColaborador { get; set; }

       
        public string StColaborador { get; set; }
    }
}
