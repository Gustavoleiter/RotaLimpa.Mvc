using AppRpgEtec.ViewModels.Setores;
using RotaLimpa.Mvc.Views.Usuarios.Colaborador;

namespace RotaLimpa.Mvc;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("cadSetorView", typeof(CadastroSetor));
	}
}
