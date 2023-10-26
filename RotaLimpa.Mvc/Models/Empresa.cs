using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.Models
{
    public class Empresa
    {
        public ICollection<Colaborador>? Colaboradores { get; set; }
        public ICollection<Setor>? Setores { get; set; }

        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? DcEmpresa { get; set; }

        public int StEmpresa { get; set; }

     
        public DateTime DiEmpresa { get; set; }

        public DateTime DaEmpresa { get; set; }

    }
}
