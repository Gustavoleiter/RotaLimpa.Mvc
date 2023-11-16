using System;
using System.Threading.Tasks;
using System.Windows.Input;
using RotaLimpa.Mvc.Models;
using RotaLimpa.Mvc.Services.CEPs;

namespace RotaLimpa.Mvc.ViewModels.CEPs
{
    public class CadastroCEPViewModel : BaseViewModel
    {
        private readonly CEPService cepService;

        public CEP CEP { get; set; }

        public ICommand CadastrarCEPCommand { get; }

        public CadastroCEPViewModel()
        {
            cepService = new CEPService();
            CEP = new CEP();

            CadastrarCEPCommand = new Command(async () => await CadastrarCEP());
        }

        private async Task CadastrarCEP()
        {
            try
            {
                // Validar os dados do CEP, se necessário

                // Chamar o serviço para cadastrar o CEP
                await cepService.PostCEPAsync(CEP);

                // Limpar os campos após o cadastro bem-sucedido
                CEP = new CEP();

                await Application.Current.MainPage.DisplayAlert("Sucesso", "CEP cadastrado com sucesso!", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", "Erro ao cadastrar o CEP: " + ex.Message, "OK");
            }
        }
    }
}
