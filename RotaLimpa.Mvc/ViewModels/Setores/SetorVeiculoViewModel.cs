using RotaLimpa.Mvc.Models;
using RotaLimpa.Mvc.Models.Enuns;

namespace RotaLimpa.Mvc.ViewModels
{
    public class SetorVeiculoViewModel
    {
        public int SetorId { get; set; }
        public int IdColaborador { get; set; }
        public int IdEmpresa { get; set; }
        public ServicoEnum TipoServico { get; set; }
        public DateTime DiSetor { get; set; }
        public DateTime DaSetor { get; set; }
        public string StSetor { get; set; }
        public string VeiculoPlaca { get; set; }
        public double TmnVeiculo { get; set; }
        public DateTime Di_Veiculo { get; set; }
        public string St_Veiculo { get; set; }

        // Outras propriedades relacionadas ao setor e veículo que você deseja incluir

        public SetorVeiculoViewModel(Setor setor, SetorVeiculo setorVeiculo)
        {
            SetorId = setor.Id;
            IdColaborador = setor.IdColaborador;
            IdEmpresa = setor.IdEmpresa;
            TipoServico = setor.TipoServico;
            DiSetor = setor.DiSetor;
            DaSetor = setor.DaSetor;
            StSetor = setor.StSetor;

            if (setorVeiculo != null)
            {
                VeiculoPlaca = setorVeiculo.Frota?.PVeiculo;
                TmnVeiculo = setorVeiculo.Frota?.TmnVeiculo ?? 0;
                Di_Veiculo = setorVeiculo.Frota?.Di_Veiculo ?? DateTime.MinValue;
                St_Veiculo = setorVeiculo.Frota?.St_Veiculo;
            }

            // Inclua outras propriedades conforme necessário
        }
    }
}
