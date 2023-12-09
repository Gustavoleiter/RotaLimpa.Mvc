using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.Models
{
    public class CEP
    {
        public int Id { get; set; }
        public int Cep {  get; set; }
        public string Logradouro { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public  double latitude { get; set; }
        public double longitude { get; set; }
        public ICollection<Rua>? Ruas { get; set; }
    }
}
