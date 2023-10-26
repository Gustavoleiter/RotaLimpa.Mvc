using RotaLimpa.Mvc.ViewModels.Motoristas;

namespace RotaLimpa.Mvc.Views.Usuarios.Colaborador;

public partial class CadastroColaborador : ContentPage
{
	MotoristaViewModel viewModel;
	public CadastroColaborador()
	{
        InitializeComponent();
		viewModel = new MotoristaViewModel();
		BindingContext = viewModel;
	}
   
}