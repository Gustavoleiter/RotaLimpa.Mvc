using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.Models
{
    public class HisLoginC
    {
        public int Id { get; set; }

        public int IdColaborador { get; set; }

        public Colaborador Colaborador { get; set; }

        public DateTime DataHora { get; set; } = DateTime.Now;
    }
}
