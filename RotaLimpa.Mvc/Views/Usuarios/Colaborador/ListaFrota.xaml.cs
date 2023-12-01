using RotaLimpa.Mvc.ViewModels.Frotas;

namespace RotaLimpa.Mvc.Views.Usuarios.Colaborador;

public partial class ListaFrota : ContentPage
{
    private ListagemFrotaViewModel viewModel;
    public ListaFrota()
    {
        viewModel = new ListagemFrotaViewModel();
        InitializeComponent();
        
        BindingContext = viewModel;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _ = viewModel.ObterFrotas();
    }
}