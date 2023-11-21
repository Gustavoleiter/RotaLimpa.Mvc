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
        private string cpf;
        private string rg;
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

        public string CPF
        {
            get => cpf;
            set
            {
                cpf = value;
                OnPropertyChanged();
            }
        }

        public string RG
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
            
        }

        public string MotoristaSelecionado { get => motoristaSelecionadoId; set => motoristaSelecionadoId = value; }

        public async Task SalvarMotorista()
        {
            try
            {
                Motorista model = new Motorista()
                {
                    PNome = this.primeiroNome,
                    SNome = this.sobreNome,
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

                // Limpar os campos
                this.primeiroNome = string.Empty;
                this.sobreNome = string.Empty;
                this.stMotorista = string.Empty;
                this.cpf = string.Empty;
                this.rg = string.Empty;
                this.login = string.Empty;
                this.senha = string.Empty;

                if (Application.Current.MainPage is NavigationPage navigationPage)
                {
                    await navigationPage.PopAsync(); // Isso remove a página atual (CadastroMotorista)
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
            }
        }


        public async void CarregarMotorista()
        {
            try
            {
                Motorista motorista = await motoristaService.GetMotoristaAsync(int.Parse(motoristaSelecionadoId));

                this.PrimeiroNomeMotorista = motorista.PNome;
                this.SobreNomeMotorista = motorista.SNome;
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
