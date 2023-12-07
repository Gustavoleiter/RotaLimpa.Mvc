using AppRpgEtec.ViewModels.Motoristas;
using RotaLimpa.Mvc.Models;
using RotaLimpa.Mvc.Services.Motoristas; // Importe o serviço de Motoristas
using RotaLimpa.Mvc.ViewModels;
using RotaLimpa.Mvc.Views.Usuarios.Colaborador;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RotaLimpa.Mvc.ViewModels.Motoristas
{
    public class ListagemMotoristaViewModel : BaseViewModel
    {
        private MotoristaService motoristaService;

        public ObservableCollection<Motorista> Motoristas {  get; set; }
     

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
                    .DisplayAlert("Confirmação", $"Confirma a remoção do motorista {motorista.Id}?", "Sim", "Não"))
                {
                    await motoristaService.DeleteMotoristaAsync(motorista.Id);

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

       
        public void NavegarParaCadastro(Motorista motorista)
        {
             Application.Current.MainPage.Navigation.PushAsync(new RotaLimpa.Mvc.Views.Usuarios.Colaborador.DetalhesMotorista(motorista));
            

        }


        private Motorista motoristaSelecionado;
        public Motorista MotoristaSelecionado
        {
            get { return motoristaSelecionado; }
            set
            {
                if (value != null)
                {
                    motoristaSelecionado = value;
                    NavegarParaCadastro(motoristaSelecionado);

                    //Shell.Current.GoToAsync($"cadMotoristaView?mId={motoristaSelecionado.Id}");
                    
                }
            }
        }

        

    }
}
