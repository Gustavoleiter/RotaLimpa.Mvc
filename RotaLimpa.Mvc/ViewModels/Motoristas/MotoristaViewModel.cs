using RotaLimpa.Mvc.Models;
using RotaLimpa.Mvc.Services.Motoristas;
using RotaLimpa.Mvc.Views.Usuarios.Colaborador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RotaLimpa.Mvc.ViewModels.Motoristas
{
    public class MotoristaViewModel : BaseViewModel
    {
        private MotoristaService uService;

        public ICommand RegistarCommand { get; set; }
        public ICommand DirecionarCadastroCommand { get; set; }

        public MotoristaViewModel()
        {
            uService = new MotoristaService();
            InicializarCommands();

        }
        public void InicializarCommands()
        {
            RegistarCommand = new Command(async () => await RegistrarMotorista());
            DirecionarCadastroCommand = new Command(async () => await DirecionarParaCadastro());
        }


        private string login = string.Empty;
        public string Login
        { get { return login; } set { login = value; OnPropertyChanged(); } }

        private string senha = string.Empty;
        public string Senha
        { get { return senha; } set { senha = value; OnPropertyChanged(); } }


        public async Task RegistrarMotorista()//Método para registrar um usuário     
        {
            try
            {
                Motorista u = new Motorista();
                u.StMotorista = Login;
                u.NomeMotorista = Senha;

                Motorista uRegistrado = await uService.PostRegistrarMotoristaAsync(u);

                if (uRegistrado.IdMotorista != 0)
                {
                    string mensagem = $"Usuário Id {uRegistrado.IdMotorista} registrado com sucesso.";
                    await Application.Current.MainPage.DisplayAlert("Informação", mensagem, "Ok");

                    await Application.Current.MainPage
                        .Navigation.PopAsync();//Remove a página da pilha de visualização
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }


        //public async Task AutenticarUsuario()//Método para autenticar um usuário     
        //{
        //    try
        //    {
        //        Usuario u = new Usuario();
        //        u.Username = Login;
        //        u.PasswordString = Senha;

        //        Usuario uAutenticado = await uService.PostAutenticarUsuarioAsync(u);

        //        if (!string.IsNullOrEmpty(uAutenticado.Token))
        //        {
        //            string mensagem = $"Bem-vindo(a) {uAutenticado.Username}.";

        //            //Guardando dados do usuário para uso futuro
        //            Preferences.Set("UsuarioId", uAutenticado.Id);
        //            Preferences.Set("UsuarioUsername", uAutenticado.Username);
        //            Preferences.Set("UsuarioPerfil", uAutenticado.Perfil);
        //            Preferences.Set("UsuarioToken", uAutenticado.Token);

        //            await Application.Current.MainPage
        //                    .DisplayAlert("Informação", mensagem, "Ok");

        //            Application.Current.MainPage = new AppShell();
        //        }
        //        else
        //        {
        //            await Application.Current.MainPage
        //                .DisplayAlert("Informação", "Dados incorretos :(", "Ok");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        await Application.Current.MainPage
        //            .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
        //    }
        //}

        public async Task DirecionarParaCadastro()
        {
            try
            {
                await Application.Current.MainPage.Navigation.PushAsync(new CadastroColaborador());
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Informação", ex.Message + "Detalhes:" + ex.InnerException, "Ok");
            }
        }
    }
}
