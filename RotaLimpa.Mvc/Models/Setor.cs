﻿using System;
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
        public int IdColaborador { get; set; }
        public int IdEmpresa { get; set; }
        public ServicoEnum TipoServico { get; set; }
        public DateTime DiSetor { get; set; }
        public DateTime DaSetor { get; set; }
        public string StSetor { get; set; } = "1";
        public Empresa? Empresa { get; set; }
        public ICollection<Rota>? Rotas { get; set; }
        public ICollection<RelatorioFinal>? RelatoriosFinais { get; set; }
        public ICollection<SetorVeiculo>? SetorVeiculos { get; set; }
    }
}
