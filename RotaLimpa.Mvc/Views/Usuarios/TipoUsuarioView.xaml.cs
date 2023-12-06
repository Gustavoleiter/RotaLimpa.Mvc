namespace RotaLimpa.Mvc.Views.Usuarios;

public partial class TipoUsuarioView : ContentPage
{
	public TipoUsuarioView()
	{
		InitializeComponent();
	}

    private async void btnMotoristaView(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RotaLimpa.Mvc.Views.Usuarios.Motorista.LoginView());
    }

    private async void btnColaboradorView(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RotaLimpa.Mvc.Views.Usuarios.Colaborador.LoginView());
    }
}