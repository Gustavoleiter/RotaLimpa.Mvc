using RotaLimpa.Mvc.ViewModels.Motoristas;
using RotaLimpa.Mvc.Models;

namespace RotaLimpa.Mvc.Views.Usuarios.Colaborador;

public partial class DetalhesMotorista : ContentPage
{
    CadastroMotoristaViewModel cadViewModel;
	public DetalhesMotorista(Models.Motorista motorista)
	{
            InitializeComponent();
            cadViewModel = new CadastroMotoristaViewModel(motorista);

            BindingContext = cadViewModel; // Atribuir a instância de viewModel ao BindingContext
            Title = "Novo Motorista";
        
    }
}