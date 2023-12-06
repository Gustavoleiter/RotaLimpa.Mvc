using RotaLimpa.Mvc.ViewModels;
using RotaLimpa.Mvc.Views.Usuarios.Colaborador;

namespace RotaLimpa.Mvc;

public partial class AppShell : Shell
{
	AppShellViewModel viewModel;
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("cadMotoristaView", typeof(CadastroMotorista));
		Routing.RegisterRoute("cadSetorView", typeof(CadastroSetor));
        Routing.RegisterRoute("cadVeiculoView", typeof(CadastroVeiculo));

        viewModel = new AppShellViewModel();
		BindingContext = viewModel;
		
	}
}
