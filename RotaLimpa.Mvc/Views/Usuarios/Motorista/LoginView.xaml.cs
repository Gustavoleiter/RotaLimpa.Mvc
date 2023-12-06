

using AppRpgEtec.ViewModels.Motoristas;
using RotaLimpa.Mvc.ViewModels.Motoristas;

namespace RotaLimpa.Mvc.Views.Usuarios.Motorista
{
    public partial class LoginView : ContentPage
    {
        CadastroMotoristaViewModel motoristViewModel;

        public LoginView()
        {
            InitializeComponent();
           motoristViewModel = new CadastroMotoristaViewModel();
            BindingContext =  motoristViewModel;
            
        }

        
    }
}
