
using RotaLimpa.Mvc.Models;
using RotaLimpa.Mvc.Services.Motoristas;
using RotaLimpa.Mvc.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows.Input;


namespace AppRpgEtec.ViewModels.Motoristas
{
    [QueryProperty("MotoristaSelecionadoId", "mId")]

    public class CadastroMotoristaViewModel : BaseViewModel
    {
        private MotoristaService motoristaService;

        public ICommand SalvarCommand { get; }
        public ICommand CancelarCommand { get; }

        private string motoristaSelecionadoId;

        public string MotoristaSelecionadoId
        {
            set
            {
                if (value != null)
                {
                    motoristaSelecionadoId = Uri.UnescapeDataString(value);
                    CarregarMotorista();
                }
            }
        }

        private int id;
        private string nome;
        private string dcColaborador;
        private string stColaborador;

        public int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        public string Nome
        {
            get => nome;
            set
            {
                nome = value;
                OnPropertyChanged();
            }
        }

        public string DcColaborador
        {
            get => dcColaborador;
            set
            {
                dcColaborador = value;
                OnPropertyChanged();
            }
        }

        public string StColaborador
        {
            get => stColaborador;
            set
            {
                stColaborador = value;
                OnPropertyChanged();
            }
        }

        public CadastroMotoristaViewModel()
        {
            motoristaService = new MotoristaService();

            SalvarCommand = new Command(async () => await SalvarMotorista());
            CancelarCommand = new Command(CancelarCadastro);
        }

        public string MotoristaSelecionado { get => motoristaSelecionadoId; set => motoristaSelecionadoId = value; }

        public async Task SalvarMotorista()
        {
            try
            {
                
               

                Motorista model = new Motorista()
                {
                    NomeMotorista = this.nome,
                    Dc_Motorista = DateTime.Now, // ou ajuste conforme necessário
                    StMotorista = this.stColaborador,
                    IdMotorista = this.id
                };

                if (model.IdMotorista == 0)
                    await motoristaService.PostMotoristaAsync(model);
                else
                    await motoristaService.PutMotoristaAsync(model);

                await Application.Current.MainPage.DisplayAlert("Mensagem", "Dados salvos com sucesso!", "Ok");

                await Shell.Current.GoToAsync(".");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
            }
        }


        private async void CancelarCadastro()
        {
            await Shell.Current.GoToAsync("..");
        }

        public async void CarregarMotorista()
        {
            try
            {
                Motorista motorista = await motoristaService.GetMotoristaAsync(int.Parse(motoristaSelecionadoId));

                this.Nome = motorista.NomeMotorista ;
                this.DcColaborador = motorista.Dc_Motorista.ToString("dd/MM/yyyy"); ;
                this.StColaborador = motorista.StMotorista;
                this.Id = motorista.IdMotorista;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
            }
        }
    }
}
