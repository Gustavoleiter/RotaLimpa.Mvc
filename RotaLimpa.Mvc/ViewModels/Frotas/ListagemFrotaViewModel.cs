using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using RotaLimpa.Mvc.Models;
using RotaLimpa.Mvc.Services.Frotas;


namespace RotaLimpa.Mvc.ViewModels.Frotas
{
    public class ListagemFrotaViewModel : BaseViewModel
    {
        private FrotaService frotaService;

        private ObservableCollection<Frota> _frotas;
        public ObservableCollection<Frota> Frotas
        {
            get { return _frotas; }
            set
            {
                _frotas = value;
                OnPropertyChanged(nameof(Frotas));
            }
        }

        public ListagemFrotaViewModel()
        {
            frotaService = new FrotaService();
            Frotas = new ObservableCollection<Frota>();

            _ = ObterFrotas();
            NovaFrotaCommand = new Command(async () => { await ExibirCadastroFrota(); });
            RemoverFrotaCommand = new Command<Frota>(async (frota) => { await RemoverFrota(frota); });
        }

        public ICommand RemoverFrotaCommand { get; }
        public ICommand NovaFrotaCommand { get; }

        public async Task ObterFrotas()
        {
            try
            {
                Frotas = await frotaService.GetFrotasAsync();
                OnPropertyChanged(nameof(Frotas));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter frotas: {ex.Message}");
            }
        }

        public async Task ExibirCadastroFrota()
        {
            try
            {
                await Shell.Current.GoToAsync("cadFrotaView");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task RemoverFrota(Frota frota)
        {
            try
            {
                if (await Application.Current.MainPage
                    .DisplayAlert("Confirmação", $"Confirma a remoção da frota {frota.Id}?", "Sim", "Não"))
                {
                    await frotaService.DeleteFrotaAsync(frota.Id);

                    await Application.Current.MainPage.DisplayAlert("Mensagem",
                        "Frota removida com sucesso!", "Ok");
                    _ = ObterFrotas();
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
            }
        }
    }
}
