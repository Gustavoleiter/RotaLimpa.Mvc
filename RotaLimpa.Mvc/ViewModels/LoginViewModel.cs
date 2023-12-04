using System;
using System.Threading.Tasks;
using RotaLimpa.Mvc.Services;
using RotaLimpa.Mvc.Services.Autenticar;



namespace RotaLimpa.Mvc.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly AutenticarService autenticarService;

        private string login;
        private string senha;

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

        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            autenticarService = new AutenticarService();

            LoginCommand = new Command(async () => await ExecuteLoginCommand());
        }

        private async Task ExecuteLoginCommand()
        {
            // Chamar o método RealizarLogin com as credenciais fornecidas
            //await RealizarLogin(Login, Senha);
        }

        //private async Task RealizarLogin(string username, string senha)
        //{
        //    if (await autenticarService.AutenticarAsync(username, senha, out string perfil))
        //    {
        //        // Login bem-sucedido
        //        Preferences.Set("PerfilUsuario", perfil);

        //        // Redirecionar com base no tipo de usuário
        //        TipoUsuario userType = ObterTipoUsuario();
        //        if (userType == TipoUsuario.Motorista)
        //        {
        //            // Redirecionar para a parte do motorista
        //            // Substitua "MotoristaPage" pela página real que você deseja navegar
        //            await Shell.Current.GoToAsync($"//MotoristaPage");
        //        }
        //        else if (userType == TipoUsuario.Colaborador)
        //        {
        //            // Redirecionar para a parte do colaborador
        //            // Substitua "ColaboradorPage" pela página real que você deseja navegar
        //            await Shell.Current.GoToAsync($"//ColaboradorPage");
        //        }
        //    }
        //    else
        //    {
        //        // Falha no login
        //        await Application.Current.MainPage.DisplayAlert("Falha no login", "Credenciais inválidas", "OK");
        //    }
        //}

        private TipoUsuario ObterTipoUsuario()
        {
            // Determinar a largura da tela
            double larguraTela = DeviceDisplay.MainDisplayInfo.Width;

            // Lógica para determinar o tipo de usuário com base na largura da tela
            if (larguraTela < 600)
            {
                // Se a largura da tela for menor que 600, assumimos que é um motorista
                return TipoUsuario.Motorista;
            }
            else
            {
                return TipoUsuario.Colaborador;
            }
        }
    }

    public enum TipoUsuario
    {
        Desconhecido,
        Motorista,
        Colaborador
    }
}
