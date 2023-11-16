using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using RotaLimpa.Mvc.Models;
using RotaLimpa.Mvc.Services.CEPs;

namespace RotaLimpa.Mvc.ViewModels.CEPs
{
    public class ListaCEPsViewModel : BaseViewModel
    {
        private readonly CEPService cepService;

        public ObservableCollection<CEP> ListaCEPs { get; set; }

        public ICommand CarregarCEPsCommand { get; }

        public ListaCEPsViewModel()
        {
            cepService = new CEPService();
            ListaCEPs = new ObservableCollection<CEP>();

            CarregarCEPsCommand = new Command(async () => await CarregarCEPs());
        }

        private async Task CarregarCEPs()
        {
            try
            {
                // Chamar o serviço para obter a lista de CEPs
                var ceps = await cepService.GetCEPsAsync();

                // Limpar a lista atual e adicionar os novos CEPs
                ListaCEPs.Clear();
                foreach (var cep in ceps)
                {
                    ListaCEPs.Add(cep);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", "Erro ao carregar a lista de CEPs: " + ex.Message, "OK");
            }
        }
    }
}
