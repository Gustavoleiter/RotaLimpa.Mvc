

namespace RotaLimpa.Mvc.Views.Usuarios
{
    public partial class LoginView : ContentPage
    {
        

        public LoginView()
        {
            InitializeComponent();
           
            
        }

        private void btnAutenticarClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Usuarios.Colaborador.ListaSetores());
        }
    }
}
