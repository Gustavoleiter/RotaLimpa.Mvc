using RotaLimpa.Mvc.ViewModels.Motoristas;
using RotaLimpa.Mvc.ViewModels.Setores;

namespace RotaLimpa.Mvc.Views.Usuarios.Colaborador;

public partial class ListaMotoristas : ContentPage
{
    ListagemMotoristaViewModel viewModel;
	public ListaMotoristas()
	{
        viewModel = new ListagemMotoristaViewModel();
		InitializeComponent();
        BindingContext = viewModel;
        Title = "Motoristas";
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _ = viewModel.ObterMotoristas();
    }

   

}