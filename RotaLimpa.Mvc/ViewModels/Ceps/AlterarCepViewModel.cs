using System;
using System.Threading.Tasks;
using RotaLimpa.Mvc.Models;
using RotaLimpa.Mvc.Services.CEPs;

namespace RotaLimpa.Mvc.ViewModels.Ceps
{
    public class AlterarCepViewModel : BaseViewModel
    {
        private readonly CEPService cepService;

        private CEP cep;

        public CEP Cep
        {
            get => cep;
            set
            {
                cep = value;
                OnPropertyChanged();
            }
        }

        public AlterarCepViewModel()
        {
            cepService = new CEPService();
            Cep = new CEP();
        }

        public async Task AlterarCep()
        {
            try
            {
                // Validar os dados do CEP, se necessário

                // Verificar se o CEP existe
                bool cepExiste = await CepExiste(Cep.Cep);
                if (!cepExiste)
                {
                    await Application.Current.MainPage.DisplayAlert("Ops", "CEP não encontrado.", "OK");
                    return;
                }

                // Chamar o serviço para alterar o CEP
                await cepService.PutCEPAsync(Cep);

                await Application.Current.MainPage.DisplayAlert("Sucesso", "CEP alterado com sucesso!", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", "Erro ao alterar o CEP: " + ex.Message, "OK");
            }
        }

        private async Task<bool> CepExiste(int cep)
        {
            // Implemente a lógica para verificar se o CEP existe, por exemplo, consultando um serviço ou banco de dados
            // Retorne true se o CEP existir, ou false caso contrário

            // Exemplo simplificado:
            return await cepService.CepExisteAsync(cep);
        }
    }
}
