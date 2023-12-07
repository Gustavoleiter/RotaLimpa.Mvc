using RotaLimpa.Mvc.Models;
using RotaLimpa.Mvc.Services.Setores; // Importe o serviço de Setores
using RotaLimpa.Mvc.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RotaLimpa.Mvc.ViewModels.Setores
{
    public class ListagemSetorViewModel : BaseViewModel
    {
        private SetorService setorService;
        

        private ObservableCollection<Setor> setores;
        public ObservableCollection<Setor> Setores { get; set;  }
        

        public ListagemSetorViewModel()
        {
            setorService = new SetorService();
            Setores = new ObservableCollection<Setor>();
            

            _ = ObterSetores();
            NovoSetor = new Command(async () => { await ExibirCadastroSetor(); });
            
        }

        public ICommand RemoverSetorCommand { get; }
        public ICommand NovoSetor { get; }
        

        public async Task ObterSetores()
        {
            try
            {
                Setores = await setorService.GetSetoresAsync();
                OnPropertyChanged(nameof(Setores));
            }
            catch (Exception ex)
            {
                // Trate erros aqui, como exibir uma mensagem de erro para o usuário
                Console.WriteLine($"Erro ao obter setores: {ex.Message}");
            }
       }
    


        public async Task ExibirCadastroSetor()
        {
            try
            {
                await Shell.Current.GoToAsync("cadSetorView");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
            }
        }

       
        public async Task RemoverSetor(Setor setor)
        {
            try
            {
                if (await Application.Current.MainPage
                    .DisplayAlert("Confirmação", $"Confirma a remoção do setor {setor.Id}?", "Sim", "Não"))
                {
                    await setorService.DeleteSetorAsync(setor.Id);

                    await Application.Current.MainPage.DisplayAlert("Mensagem",
                        "Setor removido com sucesso!", "Ok");
                    _ = ObterSetores();
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public void NavegarParaCadastro(Setor setor)
        {
            Application.Current.MainPage.Navigation.PushAsync(new RotaLimpa.Mvc.Views.Usuarios.Colaborador.DetalhesSetor(setor));


        }


        private Setor setorSelecionado;
        public Setor SetorSelecionado
        {
            get { return setorSelecionado; }
            set
            {
                if (value != null)
                {
                    setorSelecionado = value;
                    NavegarParaCadastro(setorSelecionado);

                    //Shell.Current.GoToAsync($"cadMotoristaView?mId={motoristaSelecionado.Id}");

                }
            }
        }



    }
}

