using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RotaLimpa.Mvc.Models.Enuns;

namespace RotaLimpa.Mvc.Models
{
    public class Setor
    {
        public int Id { get; set; }
        public int idColaborador { get; set; }
        public int idEmpresa { get; set; }
        public ServicoEnum tipoServico { get; set; }
        public DateTime diSetor { get; set; }
        public DateTime daSetor { get; set; }
        public string stSetor { get; set; }
        public Empresa? Empresa { get; set; }
        public ICollection<Rota>? Rotas { get; set; }
        public ICollection<RelatorioFinal>? relatoriosFinais { get; set; }
        public ICollection<SetorVeiculo>? setorVeiculos { get; set; }
    }
}
