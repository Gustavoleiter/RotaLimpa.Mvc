using RotaLimpa.Mvc.Models;
using RotaLimpa.Mvc.Services.Motoristas; // Importe o serviço de Motoristas
using RotaLimpa.Mvc.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RotaLimpa.Mvc.ViewModels.Motoristas
{
    public class ListagemMotoristaViewModel : BaseViewModel
    {
        private MotoristaService motoristaService;

        private ObservableCollection<Motorista> _motoristas;
        public ObservableCollection<Motorista> Motoristas
        {
            get { return _motoristas; }
            set
            {
                _motoristas = value;
                OnPropertyChanged(nameof(Motoristas));
            }
        }

        public ListagemMotoristaViewModel()
        {
            motoristaService = new MotoristaService();
            Motoristas = new ObservableCollection<Motorista>();

            _ = ObterMotoristas();
            NovoMotorista = new Command(async () => { await ExibirCadastroMotorista(); });
            RemoverMotoristaCommand = new Command<Motorista>(async (Motorista motorista) => { await RemoverMotorista(motorista); });
        }

        public ICommand RemoverMotoristaCommand { get; }
        public ICommand NovoMotorista { get; }

        public async Task ObterMotoristas()
        {
            try
            {
                Motoristas = await motoristaService.GetMotoristasAsync();
                OnPropertyChanged(nameof(Motoristas));
            }
            catch (Exception ex)
            {
                // Trate erros aqui, como exibir uma mensagem de erro para o usuário
                Console.WriteLine($"Erro ao obter motoristas: {ex.Message}");
            }
        }

        public async Task ExibirCadastroMotorista()
        {
            try
            {
                // Substitua "cadSetorView" pelo nome correto da página de cadastro de motorista
                await Shell.Current.GoToAsync("cadMotoristaView");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task RemoverMotorista(Motorista motorista)
        {
            try
            {
                if (await Application.Current.MainPage
                    .DisplayAlert("Confirmação", $"Confirma a remoção do motorista {motorista.IdMotorista}?", "Sim", "Não"))
                {
                    await motoristaService.DeleteMotoristaAsync(motorista.IdMotorista);

                    await Application.Current.MainPage.DisplayAlert("Mensagem",
                        "Motorista removido com sucesso!", "Ok");
                    _ = ObterMotoristas();
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
            }
        }

        private static ListagemMotoristaViewModel _instance;

        public static ListagemMotoristaViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ListagemMotoristaViewModel();
                }
                return _instance;
            }
        }
    }
}
