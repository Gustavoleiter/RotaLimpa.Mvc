using RotaLimpa.Mvc.ViewModels.Usuarios;

namespace RotaLimpa.Mvc.Views.Usuarios
{


    public partial class LoginView : ContentPage
    {

        UsuarioViewModel usuarioViewModel;
        

        public LoginView()
        {
            InitializeComponent();
            usuarioViewModel = new UsuarioViewModel();
           

        }
        
        
    }
}