using RotaLimpa.Mvc.ViewModels.Colaboradores;

namespace RotaLimpa.Mvc.Views.Usuarios.Colaborador;

public partial class Conta : ContentPage
{
	public Conta()
	{
		InitializeComponent();
		BindingContext = new ListagemColaboradorViewModel();
	}
}