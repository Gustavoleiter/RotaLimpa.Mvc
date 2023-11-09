using System.Collections.ObjectModel;
using RotaLimpa.Mvc.Models;
using RotaLimpa.Mvc.Services.Rotas;


namespace RotaLimpa.Mvc.ViewModels.Rotas
{
    public class ListagemRotaViewModel : BaseViewModel
    {
        private readonly RotaService _rotaService;

        public ObservableCollection<Rota> Rotas { get; set; }

        public ListagemRotaViewModel()
        {
            _rotaService = new RotaService();
            Rotas = new ObservableCollection<Rota>();
            _ = ObterRotas();
        }

        private async Task ObterRotas()
        {
            try
            {
                Rotas = await _rotaService.GetRotasAsync();
                OnPropertyChanged(nameof(Rotas));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", "Erro ao obter a lista de rotas: " + ex.Message, "OK");
            }
        }
    }
}
