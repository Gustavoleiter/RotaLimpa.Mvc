


using RotaLimpa.Mvc.ViewModels.Frotas;

namespace RotaLimpa.Mvc.Views.Usuarios.Colaborador;

public partial class CadastroVeiculo : ContentPage
{
    private CadastroFrotaViewModel cadViewModel;
	public CadastroVeiculo()
	{
        cadViewModel = new CadastroFrotaViewModel();
        InitializeComponent();
       
        BindingContext = cadViewModel; // Atribuir a instância de viewModel ao BindingContext

        Title = "Novo Setor";



    }
}