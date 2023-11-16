using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.Models
{
    public class Ocorrencia
    {
        public int Id { get; set; }
        public int Id_Trajeto { get; set; }
        public string Tipo_Ocorrencia { get; set; }
        public DateTime Mt_Ocorrencia { get; set; }
    }
}
