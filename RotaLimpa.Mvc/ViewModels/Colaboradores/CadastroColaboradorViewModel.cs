using RotaLimpa.Mvc.Models;
using RotaLimpa.Mvc.Services.Colaboradores;
using RotaLimpa.Mvc.Views.Usuarios.Colaborador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RotaLimpa.Mvc.ViewModels.Colaboradores
{
    public class CadastroColaboradorViewModel : BaseViewModel
    {
        private readonly ColaboradorService colaboradorService;

        public Colaborador Colaborador { get; set; }
        public ICommand AutenticarCommand { get; set; }

        public CadastroColaboradorViewModel()
        {
            colaboradorService = new ColaboradorService();
            Colaborador = new Colaborador();
            AutenticarCommand = new Command(async () => await AutenticarColaborador());
        }

        private int id;
        private string pNome;
        private string sNome;
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

        public async Task CadastrarColaborador()
        {
            try
            {
                // Validar os dados do colaborador, se necessário

                // Chamar o serviço para cadastrar o colaborador
                await colaboradorService.PostColaboradorAsync(Colaborador);

                // Limpar os campos após o cadastro bem-sucedido
                Colaborador = new Colaborador();

                await Application.Current.MainPage.DisplayAlert("Sucesso", "Colaborador cadastrado com sucesso!", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", "Erro ao cadastrar o colaborador: " + ex.Message, "OK");
            }
        }

        public async Task AutenticarColaborador()
        {
            try
            {
                Colaborador c = new Colaborador
                {
                    Login = Login,
                    Senha = Senha
                };

                // Adiciona o Id ao modelo de dados do motorista
                // Dentro da ViewModel
              


                Colaborador cAutenticado = await colaboradorService.PostAutenticarColaboradorAsync( c);

                if (!string.IsNullOrEmpty(cAutenticado.SNome))
                {
                    string mensagem = $"Bem-vindo(a) {cAutenticado.PNome + cAutenticado.SNome}.";

                    // Guardando dados do usuário para uso futuro
                    Id = cAutenticado.Id;
                    Preferences.Set("UsuarioId", cAutenticado.Id);
                    Preferences.Set("UsuarioUsername", cAutenticado.Login);

                    //await Application.Current.MainPage.DisplayAlert("Informação", mensagem, "Ok");

                    //Application.Current.MainPage = new RotaLimpa.Mvc.Views.Usuarios.Colaborador.Conta();
                    var detalhesColaboradorViewModel = new DetalhesColaboradorViewModel
                    {
                        NomeCompleto = $"{cAutenticado.PNome} {cAutenticado.SNome}",
                        NomeEmpresa = $" {cAutenticado.NomeEmpresa}",
                        DataInclusao= $" {cAutenticado.Di_Colaborador}",
                        SituacaoColab = $" {cAutenticado.StColaborador}",
                        Cpf = $" {cAutenticado.Cpf}",

                    };

                    // Criar a página e atribuir o ViewModel
                    var detalhesColaboradorPage = new Conta
                    {
                        BindingContext = detalhesColaboradorViewModel
                    };

                    // Navegar para a nova página
                    await Application.Current.MainPage.Navigation.PushAsync(detalhesColaboradorPage);
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
