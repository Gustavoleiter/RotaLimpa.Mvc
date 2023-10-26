namespace RotaLimpa.Mvc.Views.Usuarios.Motorista;

public partial class DetalhesMenu : ContentPage
{
	public DetalhesMenu()
	{
		InitializeComponent();
        MenuBtn.Clicked += AbrirMenu;
    }
    private async void AbrirMenu(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RotaLimpa.Mvc.Views.Usuarios.Motorista.MenuRota());
    }
}