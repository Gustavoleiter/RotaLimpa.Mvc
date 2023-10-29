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
        public string DcEmpresa { get; set; }
        public int StEmpresa { get; set; }
        public DateTime DiEmpresa { get; set; }
        public DateTime DaEmpresa { get; set; }

        // Coleção de colaboradores (se necessário)
        public List<Colaborador> Colaboradores { get; set; }

        // Coleção de setores (se necessário)
        public List<Setor> Setores { get; set; }
    }
}
