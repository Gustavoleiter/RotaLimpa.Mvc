using System;
using System.Threading.Tasks;
using RotaLimpa.Mvc.Models;
using RotaLimpa.Mvc.Services.Rotas;

namespace RotaLimpa.Mvc.ViewModels.Rotas
{
    public class CadastroRotaViewModel : BaseViewModel
    {
        private readonly RotaService _rotaService;

        public Rota Rota { get; set; }

        public CadastroRotaViewModel()
        {
            _rotaService = new RotaService();
            Rota = new Rota();
        }

        public Command CadastrarRotaCommand => new Command(async () => await CadastrarRota());

        private async Task CadastrarRota()
        {
            try
            {
                // Validar os dados da rota, se necessário

                // Chamar o serviço para cadastrar a rota
                await _rotaService.PostRotaAsync(Rota);

                // Limpar os campos após o cadastro bem-sucedido
                Rota = new Rota();

                await Application.Current.MainPage.DisplayAlert("Sucesso", "Rota cadastrada com sucesso!", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", "Erro ao cadastrar a rota: " + ex.Message, "OK");
            }
        }
    }
}
