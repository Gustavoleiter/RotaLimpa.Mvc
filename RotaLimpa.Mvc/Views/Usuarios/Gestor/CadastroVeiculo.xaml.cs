
using RotaLimpa.Mvc.ViewModels.Usuarios;

namespace RotaLimpa.Mvc.Views.Usuarios;

public partial class CadastroVeiculo : ContentPage
{
	UsuarioViewModel viewModel;
	public CadastroVeiculo()
	{
		InitializeComponent();
		viewModel = new UsuarioViewModel();
		BindingContext = viewModel;
	}
}