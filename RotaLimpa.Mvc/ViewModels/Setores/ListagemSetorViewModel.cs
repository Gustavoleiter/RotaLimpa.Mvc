using RotaLimpa.Mvc.Models;
using RotaLimpa.Mvc.Services.Setores; // Importe o serviço de Setores
using RotaLimpa.Mvc.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppRpgEtec.ViewModels.Setores
{
    public class ListagemSetorViewModel : BaseViewModel
    {
        private SetorService setorService;

        private ObservableCollection<Setor> _setores;
        public ObservableCollection<Setor> Setores
        {
            get { return _setores; }
            set
            {
                _setores = value;
                OnPropertyChanged(nameof(Setores));
            }
        }

        public ListagemSetorViewModel()
        {
            setorService = new SetorService();
            Setores = new ObservableCollection<Setor>();

            _ = ObterSetores();
            NovoSetor = new Command(async () => { await ExibirCadastroSetor(); });
            RemoverSetorCommand = new Command<Setor>(async (Setor setor) => { await RemoverSetor(setor); });
        }

        public ICommand RemoverSetorCommand { get; }
        public ICommand NovoSetor { get; }

        public async Task ObterSetores()
        {
            try
            {
                if (setorService != null)
                {
                    Setores = await setorService.GetSetoresAsync();
                    OnPropertyChanged(nameof(Setores));
                }
                else
                {
                    // Trate o caso em que setorService é null
                    // Por exemplo, exiba uma mensagem de erro ou inicialize setorService novamente.
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message, "Ok");
            }
        }

        //public async Task ObterSetores()
        //{
        //    try
        //    {
        //        Setores = await setorService.GetSetoresAsync();
        //        OnPropertyChanged(nameof(Setores));
        //    }
        //    catch (Exception ex)
        //    {
        //        await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + "Detalhes: " + ex.InnerException, "ok");
        //    }
        //}

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
        private static ListagemSetorViewModel _instance;

        public static ListagemSetorViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ListagemSetorViewModel();
                }
                return _instance;
            }
        }
    }
}

