using RotaLimpa.Mvc.Models;
using RotaLimpa.Mvc.ViewModels.Motoristas;
using RotaLimpa.Mvc.ViewModels.Setores;
using RotaLimpa.Mvc.Views.Usuarios.Colaborador;



namespace RotaLimpa.Mvc.Views.Usuarios.Motorista;

public partial class MapaView : ContentPage
{
    MapaViewModel viewModel;

    ListagemSetorMotoristaViewModel setorViewModel;
    public MapaView()
    {
        InitializeComponent();

        viewModel = new MapaViewModel();
        BindingContext = viewModel;
        viewModel.InicializarMapa();
        
        MenuBtn.Clicked += AbrirMenu;
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
        await Navigation.PushAsync(new MenuRota());
    }
}