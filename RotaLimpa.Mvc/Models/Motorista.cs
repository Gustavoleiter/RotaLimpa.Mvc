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

        public int IdMotorista { get; set; }
        
        public string NomeMotorista { get; set; }
     
        public DateTime Dc_Motorista { get; set; } = DateTime.Now;
        
        public string StMotorista { get; set; }

    }
}
