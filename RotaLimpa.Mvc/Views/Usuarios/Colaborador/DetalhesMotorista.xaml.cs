using AppRpgEtec.ViewModels.Motoristas;

namespace RotaLimpa.Mvc.Views.Usuarios.Colaborador;

public partial class DetalhesMotorista : ContentPage
{
    CadastroMotoristaViewModel cadViewModel;
	public DetalhesMotorista(RotaLimpa.Mvc.Models.Motorista motorista)
	{
            InitializeComponent();
            cadViewModel = new CadastroMotoristaViewModel(motorista);

            BindingContext = cadViewModel; // Atribuir a instância de viewModel ao BindingContext
            Title = "Novo Motorista";
        
    }
}