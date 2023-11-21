using RotaLimpa.Mvc.Models;
using RotaLimpa.Mvc.Services.Colaboradores;
using System;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.ViewModels.Colaboradores
{
    public class DetalhesColaboradorViewModel : BaseViewModel
    {
        private readonly ColaboradorService colaboradorService;

        private Colaborador colaborador;

        public Colaborador Colaborador
        {
            get => colaborador;
            set
            {
                colaborador = value;
                OnPropertyChanged();
            }
        }

        public DetalhesColaboradorViewModel(int colaboradorId)
        {
            colaboradorService = new ColaboradorService();
            CarregarDetalhesColaborador(colaboradorId);
        }

        private async Task CarregarDetalhesColaborador(int colaboradorId)
        {
            try
            {
                Colaborador = await colaboradorService.GetColaboradorAsync(colaboradorId);
            }
            catch (Exception ex)
            {
                // Lidar com exceções conforme necessário
                Console.WriteLine("Erro ao carregar detalhes do colaborador: " + ex.Message);
            }
        }
    }
}
