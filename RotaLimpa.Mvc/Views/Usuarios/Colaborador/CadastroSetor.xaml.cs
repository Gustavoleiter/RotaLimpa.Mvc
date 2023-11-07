using RotaLimpa.Mvc.ViewModels.Setores;

namespace RotaLimpa.Mvc.Views.Usuarios.Colaborador;

public partial class CadastroSetor : ContentPage
{
	private CadastroSetorViewModel viewModel;
	public CadastroSetor()
	{
		InitializeComponent();
		viewModel = new CadastroSetorViewModel();
		BindingContext = viewModel;
	}
    private async void OnCadastrarClicked(object sender, EventArgs e)
    {
        await viewModel.CadastrarSetor();
    }
}