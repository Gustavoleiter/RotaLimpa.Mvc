using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.Models
{
    public class Rua
    {
        public int Id { get; set; }
        public int IdCep { get; set;}
        public int IdRota { get; set; }
        public CEP? CEP { get; set; }
        public virtual Rota? Rota { get; set; }
    }
}
