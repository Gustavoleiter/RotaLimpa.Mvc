using RotaLimpa.Mvc.Models;
using RotaLimpa.Mvc.Services.Motoristas;
using RotaLimpa.Mvc.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using RotaLimpa.Mvc;
using RotaLimpa.Mvc.Views.Usuarios.Motorista;

namespace AppRpgEtec.ViewModels.Motoristas
{
    [QueryProperty("MotoristaSelecionadoId", "mId")]
    public class CadastroMotoristaViewModel : BaseViewModel
    {
        private MotoristaService motoristaService;

        public ObservableCollection<Setor> Setores { get; set; }

        public ICommand SalvarCommand { get; }
        public ICommand CancelarCommand { get; }
        public ICommand AutenticarCommand { get; set; }

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


        public CadastroMotoristaViewModel()
        {
            motoristaService = new MotoristaService();

            SalvarCommand = new Command(async () => await SalvarMotorista());
            AutenticarCommand = new Command(async () => await AutenticarMotorista());
        }

        public CadastroMotoristaViewModel(Motorista mot)
        {
            motoristaService = new MotoristaService();

            SalvarCommand = new Command(async () => await SalvarMotorista());
            AutenticarCommand = new Command(async () => await AutenticarMotorista());

            Id = mot.Id;
            PNome = mot.PNome;
            SNome = mot.SNome;
            Cpf = mot.Cpf;
            Rg = mot.Rg;
            StMotorista = mot.StMotorista;
            Di_Motorista = mot.Di_Motorista;


        }

        private int id;
        private string pNome;
        private string sNome;
        private string cNome;
        private DateTime diMotorista;
        private string stMotorista;
        private string cpf;
        private string rg;
        private string login;
        private string senha;

        public int Id
        {
            get => id;
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string PNome
        {
            get => pNome;
            set
            {
                pNome = value;
                OnPropertyChanged();
            }
        }

        public string SNome
        {
            get => sNome;
            set
            {
                sNome = value;
                OnPropertyChanged();
            }
        }

        public string CNome
        {
            get => $"{pNome} {sNome}";
            set
            {
                cNome = value;
                OnPropertyChanged();
            }
        }

        public DateTime Di_Motorista
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

        public string Cpf
        {
            get => cpf;
            set
            {
                cpf = value;
                OnPropertyChanged();
            }
        }

        public string Rg
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


        public string MotoristaSelecionado { get => motoristaSelecionadoId; set => motoristaSelecionadoId = value; }

        public async Task SalvarMotorista()
        {
            try
            {
                

                Motorista model = new Motorista()
                {
                    PNome = this.pNome,
                    SNome = this.sNome,
                    Di_Motorista = DateTime.Now,
                    Cpf = this.cpf,
                    Rg = this.rg,
                    Senha = this.senha,
                    Id = this.id
                };
                if (model.Id == 0)
                {
                    await motoristaService.PostMotoristaAsync(model);
                    //Motorista MotoristaCadastrado = await motoristaService.PostMotoristaAsync(model);
                    //model.Id = MotoristaCadastrado.Id;
                }
                else
                {
                    await motoristaService.PutMotoristaAsync(model);
                }
                    

                await Application.Current.MainPage.DisplayAlert("Mensagem", "Dados salvos com sucesso!", "Ok");


                await Shell.Current.GoToAsync("..");
                //if (Application.Current.MainPage is NavigationPage navigationPage)
                //{
                //    await navigationPage.PopAsync(); // Isso remove a página atual (CadastroMotorista)
                //}
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
                Motorista m = await motoristaService.GetMotoristaAsync(int.Parse(motoristaSelecionadoId));

                this.PNome = m.PNome;
                this.SNome = m.SNome;
                this.Di_Motorista = m.Di_Motorista;
                this.StMotorista = m.StMotorista;
                this.Cpf = m.Cpf;
                this.Rg = m.Rg;
                this.Login = m.Login;
                this.Senha = m.Senha;
                this.Id = m.Id;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task AutenticarMotorista()
        {
            try
            {
                Motorista m = new Motorista
                {
                    Login = Login,
                    Senha = Senha
                };

                // Adiciona o Id ao modelo de dados do motorista
                // Dentro da ViewModel



                Motorista mAutenticado = await motoristaService.PostAutenticarMotoristaAsync(m);

                if (!string.IsNullOrEmpty(mAutenticado.SNome))
                {
                    string mensagem = $"Bem-vindo(a) {mAutenticado.PNome + mAutenticado.SNome}.";

                    // Guardando dados do usuário para uso futuro
                    Id = mAutenticado.Id;
                    Preferences.Set("UsuarioId", mAutenticado.Id);
                    Preferences.Set("UsuarioUsername", mAutenticado.Login);

                    //await Application.Current.MainPage.DisplayAlert("Informação", mensagem, "Ok");

                    //Application.Current.MainPage = new RotaLimpa.Mvc.Views.Usuarios.Colaborador.Conta();
                    //var detalhesColaboradorViewModel = new DetalhesColaboradorViewModel
                    //{
                    //    NomeCompleto = $"{mAutenticado.PNome} {mAutenticado.SNome}",
                    //    NomeEmpresa = $" {mAutenticado.NomeEmpresa}",
                    //    DataInclusao = $" {mAutenticado.Di_Colaborador}",
                    //    SituacaoColab = $" {mAutenticado.StColaborador}",
                    //    Cpf = $" {mAutenticado.Cpf}",

                    //};

                    //// Criar a página e atribuir o ViewModel
                    //var detalhesColaboradorPage = new Conta
                    //{
                    //    BindingContext = detalhesColaboradorViewModel
                    //};

                    // Navegar para a nova página
                    await Application.Current.MainPage.Navigation.PushAsync(new RotaLimpa.Mvc.Views.Usuarios.Motorista.ListaTurno());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Informação", "Dados incorretos :(", "Ok");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }
    }


}
