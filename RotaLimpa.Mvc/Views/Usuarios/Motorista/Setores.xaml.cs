using RotaLimpa.Mvc.ViewModels.Motoristas;

namespace RotaLimpa.Mvc.Views.Usuarios.Motorista;

public partial class Setores : ContentPage
{
	private MapaViewModel _model;
	public Setores()
	{
		InitializeComponent();


		_model = new MapaViewModel();
        BindingContext = _model;

    }
}