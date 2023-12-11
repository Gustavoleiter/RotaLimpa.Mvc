namespace RotaLimpa.Mvc.Views.Usuarios.Motorista;

public partial class MenuRota : ContentPage
{
    public MenuRota()
    {
        InitializeComponent();
        DetalhesBtn.Clicked += AbrirDetalhes;
        IniciarBtn.Clicked += AbrirMapa;
    }

    private async void AbrirDetalhes(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DetalhesMenu());
    }

    private async void AbrirMapa(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MapaView());
    }
}
