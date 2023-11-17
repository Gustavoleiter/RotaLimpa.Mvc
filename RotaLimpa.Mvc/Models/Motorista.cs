using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.Models
{
    public class Motorista
    {

        public int Id { get; set; }
        
        public string Primeiro_Nome{ get; set; }
        public string Sobre_Nome { get; set; }

        public DateTime Di_Motorista { get; set; } = DateTime.Now;
        
        public string StMotorista { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        private string Chave { get; set; }
        private string IV { get; set; }
        public ICollection<HisLoginM>? HisLoginMs { get; set; }
        public ICollection<Trajeto>? Trajetos { get; set; }

    }
}
