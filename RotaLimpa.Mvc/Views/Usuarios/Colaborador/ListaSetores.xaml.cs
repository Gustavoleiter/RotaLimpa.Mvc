using AppRpgEtec.ViewModels.Setores;
using RotaLimpa.Mvc.ViewModels;

namespace RotaLimpa.Mvc.Views.Usuarios.Colaborador;

public partial class ListaSetores : ContentPage
{
    private ListagemSetorViewModel viewModel;

    public ListaSetores()
    {
        InitializeComponent();
        viewModel = new ListagemSetorViewModel();
        BindingContext = viewModel;
        CarregarSetores();
    }

    private async void CarregarSetores()
    {
        await viewModel.ObterSetores();
        // Atribuir a lista de setores à propriedade ItemsSource do seu controle de lista (ListView)
        listasetores.ItemsSource = viewModel.Setores;
    }
}
