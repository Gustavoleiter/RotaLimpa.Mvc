using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RotaLimpa.Mvc.Models;

namespace RotaLimpa.Mvc.Models
{
    public class Colaborador
    {

        public int Id { get; set; }
        public string Nome { get; set; }

        public int EmpresaId { get; set; }
      
        public string NomeEmpresa { get; set; }

        public string DcColaborador { get; set; }

        public string StColaborador { get; set; }
    }
}
