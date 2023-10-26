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

        private void btnAutenticarClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Usuarios.Colaborador.ListaSetores());
        }
    }
}
