


using RotaLimpa.Mvc.ViewModels.Colaboradores;

namespace RotaLimpa.Mvc.Views.Usuarios.Colaborador
{
    public partial class LoginView : ContentPage
    {
        CadastroColaboradorViewModel colaboradorViewModel;

        public LoginView()
        {
            InitializeComponent();
           colaboradorViewModel = new CadastroColaboradorViewModel();
            BindingContext = colaboradorViewModel;
            
        }

        
    }
}
