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
        
        public int IdEmpresa { get; set; }
        public Empresa Empresa { get; set; }
        public string Primeiro_Nome { get; set; }
     
        public string Sobre_Nome { get; set; }
        
        public string NomeEmpresa { get; set; }

        public string DcColaborador { get; set; }

        public string StColaborador { get; set; }
    }
}
