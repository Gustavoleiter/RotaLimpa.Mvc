using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RotaLimpa.Mvc.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string login;
        private string senha;

        public string Login
        {
            get => login;
            set
            {
                Login = value;
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
            LoginCommand = new Command(async () => await ExecuteLoginCommand());
        }

        private async Task ExecuteLoginCommand()
        {
            // Determinar o tipo de usuário com base no dispositivo
            TipoUsuario userType = ObterTipoUsuario();

            // Redirecionar com base no tipo de usuário
            if (userType == TipoUsuario.Motorista)
            {
                // Redirecionar para a parte do motorista
                // Substitua "MotoristaPage" pela página real que você deseja navegar
                await Shell.Current.GoToAsync($"//MotoristaPage");
            }
            else if (userType == TipoUsuario.Colaborador)
            {
                // Redirecionar para a parte do colaborador
                // Substitua "ColaboradorPage" pela página real que você deseja navegar
                await Shell.Current.GoToAsync($"//ColaboradorPage");
            }
            
        }

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
