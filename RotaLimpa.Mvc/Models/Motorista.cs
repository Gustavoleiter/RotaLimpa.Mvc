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
        
        public string PNome{ get; set; }
        public string SNome { get; set; }

        public DateTime Di_Motorista { get; set; } = DateTime.Now;

        public string StMotorista { get; set; } = "1";
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        private string Chave { get; set; }
        private string IV { get; set; }
        public ICollection<HisLoginM>? HisLoginMs { get; set; }
        public ICollection<Trajeto>? Trajetos { get; set; }

    }
}
