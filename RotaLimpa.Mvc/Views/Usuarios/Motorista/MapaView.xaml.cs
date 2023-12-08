using RotaLimpa.Mvc.ViewModels.Motoristas;
using RotaLimpa.Mvc.Views.Usuarios.Colaborador;


namespace RotaLimpa.Mvc.Views.Usuarios.Motorista;

public partial class MapaView : ContentPage
{
    MapaViewModel viewModel; 
    public MapaView()
    {
        InitializeComponent();
        MenuBtn.Clicked += AbrirMenu;

        viewModel = new MapaViewModel();
        BindingContext = viewModel;

    }

    private framePhone FramePhone;
    public void AbrirFrame(object sender, EventArgs e)
    {
        framePhone.IsVisible = !framePhone.IsVisible;
    }

    private frameAlert FrameAlert;
    public void AbrirFrame2(object sender, EventArgs e)
    {
        frameAlert.IsVisible = !frameAlert.IsVisible;
    }

    private async void AbrirMenu(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RotaLimpa.Mvc.Views.Usuarios.Motorista.MenuRota());
    }
}