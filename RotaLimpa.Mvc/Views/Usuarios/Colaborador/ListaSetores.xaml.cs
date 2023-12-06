
using AppRpgEtec.ViewModels.Setores;
using RotaLimpa.Mvc.Models;
using RotaLimpa.Mvc.ViewModels;
using RotaLimpa.Mvc.ViewModels.Setores;

namespace RotaLimpa.Mvc.Views.Usuarios.Colaborador;

public partial class ListaSetores : ContentPage
{

    ListagemSetorViewModel viewModel;

    public ListaSetores()
    {

        InitializeComponent();
        viewModel = new ListagemSetorViewModel();
        BindingContext = viewModel;       
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _ = viewModel.ObterSetores();
    }

    
}
