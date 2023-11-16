using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.Models
{
    public class HisLoginM
    {
       
            public int Id { get; set; }

            public int Id_Motorista { get; set; }

            public Motorista Motorista { get; set; }

            public DateTime DataHora { get; set; } = DateTime.Now;
        

    }
}
