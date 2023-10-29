using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RotaLimpa.Mvc.Models.Enuns;

namespace RotaLimpa.Mvc.Models
{
    public class Setor
    {
        public int Id { get; set; }
        public int ColaboradorId { get; set; }
        public int EmpresaId { get; set; }
        public ServicoEnum TipoServico { get; set; }
        public DateTime DiSetor { get; set; }
        public DateTime DaSetor { get; set; }
        public string StSetor { get; set; }
        public Colaborador Colaborador { get; set; }
        public Empresa Empresa { get; set; }
    }
}
