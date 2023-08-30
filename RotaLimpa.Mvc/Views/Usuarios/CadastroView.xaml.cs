
using RotaLimpa.Mvc.ViewModels.Usuarios;

namespace RotaLimpa.Mvc.Views.Usuarios;

public partial class CadastroView : ContentPage
{
	UsuarioViewModel viewModel;
	public CadastroView()
	{
		InitializeComponent();
		viewModel = new UsuarioViewModel();
		BindingContext = viewModel;
	}
}