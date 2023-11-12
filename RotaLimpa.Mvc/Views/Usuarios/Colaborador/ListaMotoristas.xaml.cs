using RotaLimpa.Mvc.ViewModels.Motoristas;
using RotaLimpa.Mvc.ViewModels.Setores;

namespace RotaLimpa.Mvc.Views.Usuarios.Colaborador;

public partial class ListaMotoristas : ContentPage
{
	public ListaMotoristas()
	{
		InitializeComponent();
        BindingContext = new ListagemMotoristaViewModel();
    }
}