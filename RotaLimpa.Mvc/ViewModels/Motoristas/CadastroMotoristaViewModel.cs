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
        private string primeiroNome;
        private string sobreNome;
        private DateTime diMotorista;
        private string stMotorista;
        private int cpf;
        private int rg;
        private string login;
        private string senha;

        public int IdMotorista
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        public string PrimeiroNomeMotorista
        {
            get => primeiroNome;
            set
            {
                primeiroNome = value;
                OnPropertyChanged();
            }
        }

        public string SobreNomeMotorista
        {
            get => sobreNome;
            set
            {
                sobreNome = value;
                OnPropertyChanged();
            }
        }

        public DateTime DiMotorista
        {
            get => diMotorista;
            set
            {
                diMotorista = value;
                OnPropertyChanged();
            }
        }

        public string StMotorista
        {
            get => stMotorista;
            set
            {
                stMotorista = value;
                OnPropertyChanged();
            }
        }

        public int CPF
        {
            get => cpf;
            set
            {
                cpf = value;
                OnPropertyChanged();
            }
        }

        public int RG
        {
            get => rg;
            set
            {
                rg = value;
                OnPropertyChanged();
            }
        }

        public string Login
        {
            get => login;
            set
            {
                login = value;
                OnPropertyChanged();
            }
        }

        public string Senha
        {
            get => senha;
            set
            {
                senha = value;
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
                    Primeiro_Nome = this.primeiroNome,
                    Sobre_Nome = this.sobreNome,
                    Di_Motorista = DateTime.Now, // ou ajuste conforme necessário
                    StMotorista = this.stMotorista,
                    CPF = this.cpf,
                    RG = this.rg,
                    Login = this.login,
                    Senha = this.senha,
                    Id = this.id
                };

                if (model.Id == 0)
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

                this.PrimeiroNomeMotorista = motorista.Primeiro_Nome;
                this.SobreNomeMotorista = motorista.Sobre_Nome;
                this.DiMotorista = motorista.Di_Motorista;
                this.StMotorista = motorista.StMotorista;
                this.CPF = motorista.CPF;
                this.RG = motorista.RG;
                this.Login = motorista.Login;
                this.Senha = motorista.Senha;
                this.IdMotorista = motorista.Id;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
            }
        }
    }
}
