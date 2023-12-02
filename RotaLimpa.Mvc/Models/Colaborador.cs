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
        
        public Empresa? Empresa { get; set; }
        
        public string PNome { get; set; }
     
        public string SNome { get; set; }
        
        public string NomeEmpresa { get; set; }

        public DateTime Di_Colaborador { get; set; }

        public string StColaborador { get; set; }

        public string Cpf { get; set; }
        
        public string Rg { get; set; }
        
        public string? Login { get; set; }
        
        public string Senha { get; set; }
    }
}
